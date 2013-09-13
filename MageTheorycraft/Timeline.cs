using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft
{
    public class Timeline
    {
        private IList<TimelineEvent> _events;
        public IList<TimelineEvent> Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public Timeline()
        {
            _events = new List<TimelineEvent>();
        }

        public void AddEvent(TimelineEvent newEvent)
        {
            _events.Add(newEvent);
        }

        public TimelineEvent NextEvent(double startTime)
        {
            double earliestTime = 0;
            TimelineEvent earliestEvent = null;

            foreach (TimelineEvent e in _events)
            {
                if (!e.Triggered && e.TriggerTime >= startTime)
                {
                    if (earliestEvent == null || e.TriggerTime < earliestTime)
                    {
                        earliestEvent = e;
                        earliestTime = e.TriggerTime;
                    }
                }
            }

            return earliestEvent;
        }
    }
}
