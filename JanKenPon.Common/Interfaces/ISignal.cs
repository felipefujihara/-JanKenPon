using System.Collections.Generic;

namespace JanKenPon.Common
{
    public interface ISignal
    {
        string Name { get; set; }
        IEnumerable<SignalAttributes> LosesTo { get; set; }
        IEnumerable<SignalAttributes> Do { get; set; }
    }
}
