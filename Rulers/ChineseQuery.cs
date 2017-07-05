using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rulers
{
    class ChineseQuery
    {
        // 拼音检索              
        public static string GetChineseSpell(string strText)
        {
            string Acronyms = "";
            for (int i = 0; i < strText.Length; i++)
            {
                Acronyms += getSpell(strText.Substring(i, 1));
            }
            return Acronyms;
        }

        public static Task<string> GetChineseSpellAsync(string strText)
        {
            Task<string> t = new Task<string>(() => {
                return GetChineseSpell(strText);
            });

            t.Start();
            return t;
        }
        // 得到首字母     
        public static string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "";
            }
            else
                return cnChar;
        }

        public static Task<string> getSpellAsync(string cnChar)
        {
            Task<string> t = new Task<string>(() =>
            {
                return getSpell(cnChar);
            });

            t.Start();
            return t;
        }
    }
}
