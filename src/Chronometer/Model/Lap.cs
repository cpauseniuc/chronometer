using Fuxion.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chronometer.Model
{
    public class Lap : Notifier<Lap>
    {
        public string Name
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
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
    }
}
