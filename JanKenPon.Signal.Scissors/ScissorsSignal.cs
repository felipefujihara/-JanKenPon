using JanKenPon.Common;
using System.Collections.Generic;

namespace JanKenPon.Signal.Scissors
{
    public class ScissorsSignal : ISignal
    {
        public string Name { get; set; }

        public IEnumerable<SignalAttributes> LosesTo { get; set; }
        public IEnumerable<SignalAttributes> Do { get; set; }

        public ScissorsSignal()
        {
            this.Name = "S";
            this.LosesTo = new[] { SignalAttributes.Crushes };
            this.Do = new[] { SignalAttributes.Cuts };
        }
    }
}
