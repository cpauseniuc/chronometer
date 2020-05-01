using Chronometer.Helpers;
using Chronometer.Model;
using Fuxion.ComponentModel;
using Fuxion.Windows.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Chronometer.ViewModels
{
    public interface ITimer_ViewModel
    {
        Timer Timer { get; set; }
        GenericCommand StartTimerCommand { get; }
        GenericCommand PauseTimerCommand { get; }
        GenericCommand StopTimerCommand { get; }

    }
    public class Timer_ViewModel : Notifier<Timer_ViewModel>, ITimer_ViewModel
    {
        public Timer Timer { get => GetValue(() => new Timer()); set => SetValue(value); }
        public GenericCommand StartTimerCommand
        {
            get => GetValue(() => new GenericCommand(() => Timer.Start()));
        }
        public GenericCommand PauseTimerCommand
        {
            get => GetValue(() => new GenericCommand(() =>
            {
                Timer.Pause();
                Laps.Add(new Lap
                {
                    Name = "Lap " + (Laps.Count + 1),
                    Hours = Timer.Hours,
                    Minutes = Timer.Minutes,
                    Seconds = Timer.Seconds
                });
            }));
        }
        public GenericCommand StopTimerCommand
        {
            get => GetValue(() => new GenericCommand(() => 
            {
                Timer.Stop();
                Laps.Clear();
            }));
        }
        public ObservableCollection<Lap> Laps { get => GetValue(() => new ObservableCollection<Lap>()); set => SetValue(value); }

    }
}
