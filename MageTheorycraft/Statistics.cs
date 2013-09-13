using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MageTheorycraft
{
    public class Statistics
    {
        private IList<State> _states;
        public IList<State> States
        {
            get { return _states; }
        }

        private Config _config;
        public Config Config
        {
            get { return _config; }
        }

        private IList<DPSProfile> _dpsProfiles;
        public IList<DPSProfile> DPSProfiles
        {
            get { return _dpsProfiles; }
        }

        internal Statistics(Config config)
        {
            _states = new List<State>();
            _dpsProfiles = new List<DPSProfile>();
            _config = config;
        }

        private bool _finalised = false;
        private double _averageTotalDPS;
        private double _averageTotalDamage;
        private List<Point> _averageDPSProfile;

        public double AverageTotalDPS
        {
            get
            {
                if (_finalised)
                    return _averageTotalDPS;

                double averageDPS = 0;

                foreach (DPSProfile profile in _dpsProfiles)
                {
                    averageDPS += profile.TotalDPS;
                }

                averageDPS /= _dpsProfiles.Count;

                return averageDPS;
            }
        }

        public double AverageTotalDamage
        {
            get
            {
                if (_finalised)
                    return _averageTotalDamage;

                double averageDamage = 0;

                foreach (DPSProfile profile in _dpsProfiles)
                {
                    averageDamage += profile.TotalDamage;
                }

                averageDamage /= _dpsProfiles.Count;

                return averageDamage;
            }
        }

        public List<Point> AverageDPSProfile
        {
            get
            {
                if (_finalised)
                    return _averageDPSProfile;

                List<Point> line = new List<Point>();

                if (_dpsProfiles.Count == 0)
                    return line;

                int numPoints = _dpsProfiles[0].Values.Count;

                double[] totalDamages = new double[numPoints];

                foreach (DPSProfile profile in _dpsProfiles)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        totalDamages[i] += profile.Values[i];
                    }
                }

                for (int i = 0; i < numPoints; i++)
                {
                    Point p = new Point(i * (int)_dpsProfiles[0].Resolution, (int)(totalDamages[i] / (double)_dpsProfiles.Count));

                    line.Add(p);
                }

                return line;
            }
        }

        internal void Finalise()
        {
            if (!_finalised)
            {
                _averageDPSProfile = AverageDPSProfile;
                _averageTotalDamage = AverageTotalDamage;
                _averageTotalDPS = AverageTotalDPS;

                _dpsProfiles.Clear();
                _states.Clear();

                // Request a garbage collection
                System.GC.Collect();

                _finalised = true;
            }
        }
    }
}
