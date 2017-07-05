using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rulers
{
    class SearchEngines
    {
        public static string GeneralQuery(String SearchResults)
        {
            String strWord = null;
            String[] s = SearchResults.Split(' ');
            for (int ia = 0; ia < s.Length; ia++)
            {
                try
                {
                    s[ia] = s[ia].Substring(0, 1).ToUpper();
                }
                catch
                {
                    //空格分割出错或其他匹配错误
                }
                strWord += s[ia];
            }
            return strWord;
        }

        public static Task<string> GeneralQueryAsync(String SearchResults)
        {
            Task<string> t = new Task<string>(() =>
            {
                return GeneralQuery(SearchResults);
            });

            t.Start();
            return t;
        }
    }
}
