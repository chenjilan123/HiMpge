using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiMpge.Data
{
    public class HexTransfer
    {
        public static byte[] GetBytes(string s)
        {
            byte[] data = new byte[s.Length / 2];
            for (int i = 0; i < data.Length; i++)
            {
                var subStr = s.Substring(i * 2, 2);
                data[i] = Convert.ToByte(subStr, 16);
            }
            return data;
        }
    }
}
