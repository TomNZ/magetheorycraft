using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft
{
    public class Log
    {
        private IList<LogEvent> _events;
        public IList<LogEvent> Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public Log()
        {
            _events = new List<LogEvent>();
        }

        public void AddEvent(LogEvent newEvent)
        {
            _events.Add(newEvent);
        }
    }
}
