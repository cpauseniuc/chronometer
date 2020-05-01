using Fuxion.ComponentModel;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chronometer.Helpers
{
    public interface ITimer
    {
        short Hours { get; set; }
        short Minutes { get; set; }
        short Seconds { get; set; }
        void Start();
        void Pause();
        void Stop();
    }
    public class Timer : Notifier<Timer>, ITimer
    {
        public Timer()
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
            ClearValues();
        }
        #region Timer Logic
        readonly System.Timers.Timer _timer;
        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            IncreaseSeconds();
        }
        private void IncreaseSeconds()
        {
            if (Seconds == 59)
            {
                Seconds = 0;
                IncreaseMinutes();
            }
            else
                Seconds++;

        }
        private void IncreaseMinutes()
        {
            if (Minutes == 59)
            {
                Minutes = 0;
                IncreaseHours();
            }
            else
                Minutes++;
        }
        private void IncreaseHours()
        {
            //Since no day needed, hours have no limit
            Hours++;
        }
        private void ClearValues()
        {
            Hours = 00;
            Minutes = 00;
            Seconds = 00;
        }
        #endregion
        #region Public Properties
        public short Hours
        {
            get => GetValue<short>();
            set => SetValue(value);
        }
        public short Minutes
        {
            get => GetValue<short>();
            set => SetValue(value);
        }
        public short Seconds
        {
            get => GetValue<short>();
            set => SetValue(value);
        }
        #endregion
        #region Public Methods
        public void Start() => _timer.Enabled = true;
        public void Pause() => _timer.Enabled = false;
        public void Stop()
        {
            _timer.Enabled = false;
            ClearValues();
        }
        #endregion
    }
}
