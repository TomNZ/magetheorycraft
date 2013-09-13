using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MageTheorycraft
{
    public class Simulation : IDisposable
    {
        // Properties
        private int _maxThreads = 5;
        public int MaxThreads
        {
            get { return _maxThreads; }
            set { _maxThreads = value; }
        }

        private int _repetitions = 20;
        public int Repetitions
        {
            get { return _repetitions; }
            set { _repetitions = value; }
        }

        private Config _config;
        public Config Config
        {
            get { return _config; }
            set { _config = value; }
        }

        private Statistics _statistics;
        public Statistics Statistics
        {
            get { lock (_statistics) { return _statistics; } }
            set { lock (_statistics) { _statistics = value; } }
        }

        private Thread _asyncWorker;

        private int _asyncThreadsRun = 0;
        public int AsyncThreadsRun
        {
            get { return _asyncThreadsRun; }
        }

        private bool _asyncRunning = false;
        public bool AsyncRunning
        {
            get { return _asyncRunning; }
        }

        // Constructors
        public Simulation(Config config)
        {
            _statistics = new Statistics(config);
            _config = config;
        }

        public Simulation(Config config, int repetitions)
            :
            this(config)
        {
            _repetitions = repetitions;
        }

        public void Run()
        {
            Thread[] threads = new Thread[_maxThreads];
            State[] states = new State[_maxThreads];
            int threadsRun = 0;

            while (threadsRun < _repetitions)
            {
                // Check for null threads
                for (int i = 0; i < threads.Length; i++)
                {
                    if (threads[i] == null && threadsRun < _repetitions)
                    {
                        // Start a new thread
                        states[i] = new State(_config);

                        threads[i] = new Thread(new ThreadStart(states[i].Run));
                        threads[i].Start();
                    }
                }

                // Check for finished threads
                for (int i = 0; i < threads.Length; i++)
                {
                    if (threads[i] != null && !threads[i].IsAlive)
                    {
                        ProcessStateStats(states[i]);
                        threads[i] = null;
                        threadsRun++;
                    }
                }
            }
        }

        public void AsyncRun()
        {
            if (_asyncRunning)
                AsyncCancel();

            _asyncThreadsRun = 0;

            _asyncWorker = new Thread(new ThreadStart(AsyncWorker));
            _asyncWorker.Start();
        }

        public void AsyncCancel()
        {
            lock (_asyncWorker)
            {
                if (_asyncWorker != null && _asyncWorker.IsAlive)
                {
                    _asyncWorker.Abort();
                    _asyncWorker.Join();
                    _asyncWorker = null;
                }
            }

            _asyncRunning = false;
        }

        private void AsyncWorker()
        {
            _asyncRunning = true;

            IList<Thread> asyncThreads = new List<Thread>();
            IList<State> asyncStates = new List<State>();

            try
            {

                while (_asyncThreadsRun < _repetitions)
                {
                    // Check for null threads
                    if (asyncThreads.Count < _maxThreads && _asyncThreadsRun < _repetitions)
                    {
                        // Start a new thread
                        Thread t;

                        State s = new State(_config);
                        asyncStates.Add(s);
                        t = new Thread(new ThreadStart(s.Run));

                        asyncThreads.Add(t);
                        t.Start();
                    }

                    // Check for finished threads
                    for (int i = 0; i < asyncThreads.Count; i++)
                    {
                        if (!asyncThreads[i].IsAlive)
                        {
                            ProcessStateStats(asyncStates[i]);
                            asyncStates.RemoveAt(i);
                            asyncThreads.RemoveAt(i);
                            _asyncThreadsRun++;
                            break;
                        }
                    }
                }
            }
            catch (ThreadAbortException)
            {
                while (asyncThreads.Count > 0)
                {
                    Thread t = asyncThreads[0];

                    if (t.IsAlive)
                    {
                        t.Abort();
                        t.Join();
                        t = null;
                    }

                    asyncThreads.Remove(t);
                }
            }
            finally
            {
                lock (_statistics)
                {
                    _statistics.Finalise();
                }

                _asyncRunning = false;
            }
        }

        private void ProcessStateStats(State state)
        {
            //_statistics.States.Add(state);
            lock (_statistics)
            {
                _statistics.DPSProfiles.Add(new DPSProfile(state.Damages));
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            AsyncCancel();
        }

        #endregion
    }
}
