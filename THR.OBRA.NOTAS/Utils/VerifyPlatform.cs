using System.Runtime.InteropServices;

namespace THR.OBRA.NOTAS.Utils
{
    public class VerifyPlatform
    {
        public OSPlatform GetPlatform()
        {
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return OSPlatform.Windows;

            return OSPlatform.Linux;
        }
    }
}
