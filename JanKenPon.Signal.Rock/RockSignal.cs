using JanKenPon.Common;
using System.Collections.Generic;

namespace JanKenPon.Signal.Rock
{
    public class RockSignal : ISignal
    {
        public string Name { get; set; }

        public IEnumerable<SignalAttributes> LosesTo { get; set; }
        public IEnumerable<SignalAttributes> Do { get; set; }

        public RockSignal()
        {
            this.Name = "Rock";
            this.LosesTo = new[] { SignalAttributes.Covers };
            this.Do = new[] { SignalAttributes.Crushes };
        }
    }
}
