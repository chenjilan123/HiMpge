using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HiMpge.Data
{
    public class FrameProvider
    {
        private const string textFilePath = ".\\Src\\h264data.txt";
        private const string h264FilePath = ".\\Src\\10.h264";
        public static byte[] GetFrameData()
        {
            var s = File.ReadAllText(textFilePath).Replace("\r\n", "");
            var data = HexTransfer.GetBytes(s);
            return data;
        }

        public static byte[] GetH264FileData()
        {
            var data = File.ReadAllBytes(h264FilePath);
            return data;
        }
    }
}
