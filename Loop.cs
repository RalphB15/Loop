using System;
using System.Threading;
using System.Threading.Tasks;

namespace TMS.Utils
{
    /// <summary>
    /// Represents a loop that executes a specified action with a specified interval.
    /// </summary>
    public class Loop
    {
        private readonly Func<Task> _asyncAction;
        private readonly int _intervalMs;
        private Timer _timer;
        private bool _isPaused;

        /// <summary>
        /// Creates a new instance of the Loop class with the specified async action and interval.
        /// </summary>
        /// <param name="asyncAction">The async action to execute in the loop.</param>
        /// <param name="intervalMs">The interval at which to execute the action, in milliseconds.</param>
        public Loop(Func<Task> asyncAction, int intervalMs)
        {
            _asyncAction = asyncAction;
            _intervalMs = intervalMs;
        }
        
        public void Start()
        {
            _timer = new Timer(async state => await DoLoopAsync(), null, 0, _intervalMs);
            _isPaused = false;
        }

        public void Stop()
        {
            _timer.Dispose();
        }
        
        public void Pause()
        {
            _isPaused = true;
        }
        
        public void Resume()
        {
            _isPaused = false;
        }

        private async Task DoLoopAsync()
        {
            if (_isPaused)
            {
                return;
            }

            await _asyncAction.Invoke();
        }
    }
}