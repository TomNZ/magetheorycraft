using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MageTalentSelector
{
    public class TalentBox : Label
    {
        public enum TalentType
        {
            Important,
            Normal,
            NonImplemented
        }

        private TalentType _type = TalentType.Normal;
        public TalentType Type
        {
            get { return _type; }
            set { _type = value; SetColor(); }
        }

        private int _maxValue = 1;
        public int MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
        }

        public TalentBox()
        {
            this.Text = "0";
            this.AutoSize = false;
            this.Size = new Size(40, 20);
            this.TextAlign = ContentAlignment.MiddleCenter;
            
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                if (toInt(this.Text) >= _maxValue)
                {
                    this.Text = _maxValue.ToString();
                }
                else
                {
                    int newValue = toInt(this.Text) + 1;
                    this.Text = newValue.ToString();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (toInt(this.Text) <= 0)
                {
                    this.Text = "0";
                }
                else
                {
                    int newValue = toInt(this.Text) - 1;
                    this.Text = newValue.ToString();
                }
            }
        }

        private void SetColor()
        {
            switch (_type)
            {
                case TalentType.Important:
                    {
                        this.BackColor = Color.PaleGreen;
                    } break;
                case TalentType.Normal:
                    {
                        this.BackColor = Color.White;
                    } break;
                case TalentType.NonImplemented:
                    {
                        this.BackColor = Color.PaleVioletRed;
                    } break;
            }
        }

        private int toInt(string input)
        {
            int result;
            if (int.TryParse(input, out result))
                return result;

            return 0;
        }
    }
}
