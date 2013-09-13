using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft
{
    public class DPSProfile
    {
        private IList<Damage> _damages;
        public IList<Damage> Damages
        {
            get { return _damages; }
            set { _damages = value; Calculate(); }
        }

        private double _resolution = 5.0;
        public double Resolution
        {
            get { return _resolution; }
            set { _resolution = value; Calculate(); }
        }

        private int _rollingAverageOrder = 5;
        public int RollingAverageOrder
        {
            get { return _rollingAverageOrder; }
            set { _rollingAverageOrder = value; Calculate(); }
        }

        private IList<double> _values = new List<Double>();
        public IList<double> Values
        {
            get { return _values; }
        }

        public double TotalDPS
        {
            get { return (double)_totalDamage / _totalTime; }
        }

        private int _totalDamage = 0;
        public int TotalDamage
        {
            get { return _totalDamage; }
        }

        private double _totalTime = 0;
        public double TotalTime
        {
            get { return _totalTime; }
        }

        public DPSProfile(IList<Damage> damages)
        {
            _damages = damages;
            Calculate();
        }

        private void Calculate()
        {
            _values.Clear();
            _totalDamage = 0;
            _totalTime = 0;

            double[] lastValues = new double[_rollingAverageOrder];

            double maxTime = _damages[0].Time;

            foreach (Damage d in _damages)
            {
                if (d.Time > maxTime)
                    maxTime = d.Time;
            }

            // Round down to nearest Resolution
            _totalTime = maxTime - (maxTime % _resolution);

            int[] damageValues = new int[(int)(_totalTime / _resolution) + 1];

            foreach (Damage d in _damages)
            {
                damageValues[(int)(d.Time / _resolution)] += (int)d.Value;
                _totalDamage += (int)d.Value;
            }

            for (int i = 0; i < damageValues.Length - _rollingAverageOrder; i++)
            {
                double averageDamage = 0;

                for (int j = 0; j < _rollingAverageOrder; j++)
                {
                    averageDamage += damageValues[i + j];
                }

                averageDamage /= _rollingAverageOrder;

                _values.Add(averageDamage / _resolution);
            }
        }
    }
}
