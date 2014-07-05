using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 密码入门
{
    class encode
    {
        private string originCode;
        private string unknownCode;
        public string type;
        public encode()
        {
            originCode = "";
            unknownCode = "";
            type = "";
        }
        public void init(string origin)
        {
            originCode = origin;
        }
        public string getCode()
        {
            return unknownCode;
        }
        public string getAns()
        {
            return originCode;
        }
        public void kaisa()
        {
            int i;
            Random seed = new Random();
            int k = seed.Next(0,26) % 4;
            int []arr = new int[4]{10, 13, 21, 20};
            k = arr[k];
            string tCode = "";
            for (i = 0; i < originCode.Length; i++)
            {
                int asc = Convert.ToInt32(originCode[i]);
                char ch = Convert.ToChar(97 + (asc - 97 + k) % 26);
                tCode += ch;
            }
            type = "凯撒加密";
            unknownCode = tCode;
        }
        public void zhalan()
        {
            int len = originCode.Length;
            int k = 2;
            int i;
            for (i = 3; i <= 7; i++)
                if (len % i == 0)
                    k = i;
            if (k > 2 || (k == 2 && originCode.Length % 2 == 0))
            {
                string tCode = "";
                int j;
                for (i = 0; i < k; i++)
                    for (j = 0; j < len; j = j + k)
                        tCode += originCode[j + i];
                type = "栅栏加密";
                unknownCode = tCode;
            }
            else
            {
                keyboard();
            }
        }
        public void keyboard()
        {
            string []flect = new string[26]{"21","22","23", "31","32","33", "41","42","43", "51","52","53", "61","62","63", "71","72","73","74", "81","82","83", "91","92","93","94"};
            string tCode = "";
            int i;
            for (i = 0; i < originCode.Length; i++)
            {
                int asc = Convert.ToInt32(originCode[i]);
                asc -= 97;
                tCode += flect[asc];
            }
            type = "键盘加密";
            unknownCode = tCode;
        }
        public void alnum()
        {
            string tCode = "";
            int i;
            for (i = 0; i < originCode.Length; i++)
            {
                int asc = Convert.ToInt32(originCode[i]);
                asc -= 96;
                tCode += Convert.ToString(asc);
            }
            type = "字母-数字加密";
            unknownCode = tCode;
        }
        public void selectCode(int i)
        {
            if (i == 0)
            {
                kaisa();
                return;
            }
            if (i == 1)
            {
                zhalan();
                return;
            }
            if (i == 2)
            {
                keyboard();
                return;
            }
            if (i == 3)
            {
                alnum();
                return;
            }
        }
    }
}
