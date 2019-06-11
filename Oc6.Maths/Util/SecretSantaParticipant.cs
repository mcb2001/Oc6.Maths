using System.Diagnostics;

namespace Oc6.Maths.Util
{
    [DebuggerDisplay("{Are} is for {IsFor}")]
    public class SecretSantaParticipant
    {
        public string Are { get; set; }
        public string IsFor { get; set; }
    }
}
