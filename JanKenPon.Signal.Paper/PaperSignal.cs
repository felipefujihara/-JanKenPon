using JanKenPon.Common;
using System.Collections.Generic;

namespace JanKenPon.Signal.Paper
{
    public class PaperSignal : ISignal
    {
        public string Name { get; set; }

        public IEnumerable<SignalAttributes> LosesTo { get; set; }
        public IEnumerable<SignalAttributes> Do { get; set; }

        public PaperSignal()
        {
            this.Name = "P";
            this.LosesTo = new[] { SignalAttributes.Cuts };
            this.Do = new[] { SignalAttributes.Covers };
        }
    }
}
