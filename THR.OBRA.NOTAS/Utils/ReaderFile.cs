using SharpCifs.Smb;
using System.Runtime.InteropServices;
using System.Text;

namespace THR.OBRA.NOTAS.Utils
{
    public class ReaderFile
    {
        public readonly VerifyPlatform verifyPlatform;

        public ReaderFile(VerifyPlatform verifyPlatform)
        {
            this.verifyPlatform = verifyPlatform;

        }

        public StreamReader GetFileReader(string caminho)
        {
            if (verifyPlatform.GetPlatform() == OSPlatform.Windows) return ReaderInWindows(caminho);
            return ReaderInLinux(caminho);
        }

        private static StreamReader ReaderInWindows(string caminho)
        {
            return new StreamReader(caminho, Encoding.GetEncoding("ISO-8859-1"), true);

        }
        private static StreamReader ReaderInLinux(string caminho)
        {
            var smb = new SmbFile(caminho).GetInputStream();
            return new StreamReader(smb, Encoding.GetEncoding("ISO-8859-1"), true);

        }
    }
}
