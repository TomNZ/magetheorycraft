using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace BitmapGraph
{
    // Unfortunately this class is a little messy due to thread safety!

    public partial class BitmapGraph : UserControl
    {
        // Acceptable values for axes divisions
        private int[] _divisions = new int[] { 1, 2, 5, 10, 20, 25, 50, 100, 200, 250, 500, 1000, 2000, 2500, 5000, 10000 };

        // Pixels to leave on each side of the graph
        private const int _margin = 30;

        int _minX, _minY, _maxX, _maxY;
        private int _width, _height;

        // Data points
        private List<List<Point>> _lines;
        public List<List<Point>> Lines
        {
            get { return _lines; }
            set 
            {
                if (_lines != null)
                {
                    lock (_lines)
                    {
                        _lines = value;
                    }
                }
                else
                {
                    _lines = value;
                }

                if (_autoUpdate) Redraw(); 
            }
        }

        // Curve pens
        private Hashtable _pens;
        public Hashtable Pens
        {
            get { return _pens; }
            set 
            {
                if (_pens != null)
                {
                    lock (_pens)
                    {
                        _pens = value;
                    }
                }
                else
                {
                    _pens = value;
                }
                
                if (_autoUpdate) Redraw();
            }
        }

        // Whether to display points as a curve
        private bool _curved = true;
        public bool Curved
        {
            get { return _curved; }
            set { _curved = value; if (_autoUpdate) Redraw(); }
        }

        // Cached bitmap
        public Image GraphBitmap
        {
            get
            {
                return this.BackgroundImage;
            }
        }

        private bool _autoUpdate = true;
        public bool AutoUpdate
        {
            get { return _autoUpdate; }
            set { _autoUpdate = value; }
        }

        private Thread _redrawThread;

        public BitmapGraph()
        {
            this.MinimumSize = new Size(2 * _margin, 2 * _margin);

            InitializeComponent();

            _lines = new List<List<Point>>();
            _pens = new Hashtable();

            this.BackgroundImageLayout = ImageLayout.Center;
            _width = Width;
            _height = Height;
            this.BackgroundImage = GraphBitmap;
            this.DoubleBuffered = true;
        }

        private delegate void StartedAsyncRedraw();

        public void Redraw()
        {
            if (!this.IsHandleCreated || !this.Created || this.RecreatingHandle)
                return;

            if (_redrawThread != null)
            {
                if (_redrawThread.IsAlive)
                {
                    _redrawThread.Abort();
                    _redrawThread.Join();
                }
                
                _redrawThread = null;
            }

            try
            {
                lblGenerating.Show();
                this.BackgroundImage = null;
            }
            catch (Exception e)
            {
                // Ignore
            }

            _redrawThread = new Thread(new ThreadStart(AsyncRedraw));
            _redrawThread.Start();
        }

        private void AsyncRedraw()
        {
            Bitmap b = null;
            try
            {
                if (_lines == null)
                {
                    _lines = new List<List<Point>>();
                }

                b = new Bitmap(Math.Max(2 * _margin, _width), Math.Max(2 * _margin, _height));

                Graphics g = Graphics.FromImage(b);

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                // Get scale
                // Make sure we always have the origin on our graph
                _minX = 0;
                _maxX = 0;
                _minY = 0;
                _maxY = 0;

                lock (_lines)
                {
                    foreach (List<Point> line in _lines)
                    {
                        foreach (Point point in line)
                        {
                            if (point.X < _minX)
                                _minX = point.X;

                            if (point.X > _maxX)
                                _maxX = point.X;

                            if (point.Y < _minY)
                                _minY = point.Y;

                            if (point.Y > _maxY)
                                _maxY = point.Y;
                        }
                    }
                }

                // Axes at origin
                Pen blackPen = new Pen(Color.Black, 1);
                Pen lightBlackPen = new Pen(Color.FromArgb(20, 0, 0, 0));

                blackPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                Point xAxisStart = TranslatePoint(new Point(0, _minY));
                Point xAxisEnd = TranslatePoint(new Point(0, _maxY));

                Point yAxisStart = TranslatePoint(new Point(_minX, 0));
                Point yAxisEnd = TranslatePoint(new Point(_maxX, 0));

                g.DrawLine(blackPen, xAxisStart, xAxisEnd);
                g.DrawLine(blackPen, yAxisStart, yAxisEnd);

                blackPen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;

                // Draw the scale
                int xDivisionSize = GetBestDivision(this.Width - 2 * _margin, _maxX - _minX);
                int yDivisionSize = GetBestDivision(this.Height - 2 * _margin, _maxY - _minY);

                Brush textBrush = Brushes.Black;
                StringFormat scaleFormat = new StringFormat();
                scaleFormat.Alignment = StringAlignment.Center;
                scaleFormat.LineAlignment = StringAlignment.Near;

                for (int x = (_minX / xDivisionSize) * xDivisionSize; x <= _maxX; x += xDivisionSize)
                {
                    Point scalePoint = TranslatePoint(new Point(x, 0));
                    scalePoint.Y += 2;

                    if (x != 0)
                    {
                        // Scale number
                        g.DrawString(x.ToString(), this.Font, textBrush, scalePoint, scaleFormat);

                        // Graph line
                        g.DrawLine(lightBlackPen, TranslatePoint(new Point(x, _minY)), TranslatePoint(new Point(x, _maxY)));
                    }
                }

                scaleFormat.LineAlignment = StringAlignment.Center;
                scaleFormat.Alignment = StringAlignment.Far;

                for (int y = (_minY / yDivisionSize) * yDivisionSize; y <= _maxY; y += yDivisionSize)
                {
                    Point scalePoint = TranslatePoint(new Point(0, y));
                    scalePoint.X -= 2;

                    if (y != 0)
                    {
                        // Scale number
                        g.DrawString(y.ToString(), this.Font, textBrush, scalePoint, scaleFormat);

                        // Graph line
                        g.DrawLine(lightBlackPen, TranslatePoint(new Point(_minX, y)), TranslatePoint(new Point(_maxX, y)));
                    }
                }

                // Draw the lines
                lock (_lines)
                {
                    for (int i = 0; i < _lines.Count; i++)
                    {
                        Pen linePen;

                        lock (_pens)
                        {
                            if (_pens == null || !_pens.ContainsKey(i))
                                linePen = new Pen(Color.FromArgb(180, 0, 0, 0));
                            else
                                linePen = (Pen)_pens[i];
                        }

                        List<Point> line = _lines[i];

                        if (line.Count >= 2)
                        {
                            Point[] linePoints = line.ToArray();

                            for (int j = 0; j < linePoints.Length; j++)
                            {
                                linePoints[j] = TranslatePoint(linePoints[j]);
                            }

                            if (_curved)
                            {
                                g.DrawCurve(linePen, linePoints, 0.2F);
                            }
                            else
                            {
                                g.DrawLines(linePen, linePoints);
                            }
                        }
                        else if (line.Count == 1)
                        {
                            Point point = TranslatePoint(new Point(line[0].X, line[0].Y));

                            g.DrawEllipse(linePen, point.X, point.Y, 4, 4);
                        }
                    }
                }

                g.Dispose();
            }
            catch (ThreadAbortException e)
            {
                // Clean up
                if (b != null)
                {
                    b.Dispose();
                    b = null;
                }
            }
            finally
            {
                FinishAsyncRedraw(b);
            }
        }

        private delegate void FinishedAsyncRedraw(Bitmap b);

        private void FinishAsyncRedraw(Bitmap b)
        {
            if (!this.IsHandleCreated || !this.Created || this.RecreatingHandle)
                return;

            if (this.InvokeRequired || (this.TopLevelControl != null && this.TopLevelControl.InvokeRequired))
            {
                this.BeginInvoke(new FinishedAsyncRedraw(FinishAsyncRedraw), b);
                return;
            }

            try
            {
                this.BackgroundImage = b;
                lblGenerating.Hide();
            }
            catch (Exception e)
            {
                // ignore
                this.BackgroundImage = null;
            }
        }

        private Point TranslatePoint(Point actualPoint)
        {
            actualPoint.X = (int)(((double)(_width - 2 * _margin) / (double)(_maxX - _minX)) * (double)(-_minX + actualPoint.X) + _margin);
            actualPoint.Y = (int)(_height - _margin - ((double)(_height - 2 * _margin) / (double)(_maxY - _minY)) * (double)(-_minY + actualPoint.Y));

            return actualPoint;
        }

        private int GetBestDivision(int pixelWidth, double actualWidth)
        {
            // Maximum of one div per 15 pixels
            foreach (int div in _divisions)
            {
                if ((int)(((double)pixelWidth / actualWidth) * (double)div) > 25)
                {
                    return div;
                }
            }

            return 1;
        }

        private void BitmapGraph_Resize(object sender, EventArgs e)
        {
            _width = this.Width;
            _height = this.Height;
            Redraw();
        }
    }
}