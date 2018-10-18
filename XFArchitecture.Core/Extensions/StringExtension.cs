using System;
using System.Drawing;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace XFArchitecture.Core.Extensions
{
    public static class StringExtension
    {
        public static Dictionary<string,string> ToDictionary(this string key,dynamic obj)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { key, JsonConvert.SerializeObject(obj) }
            };
            return dictionary;
        }

        public static Color ToColor(this string color)
        {
            try
            {
                if (color.StartsWith("#", StringComparison.Ordinal))
                {
                    // Undefined
                    if (color.Length < 3)
                        return Color.Black;
                    int idx = (color[0] == '#') ? 1 : 0;

                    switch (color.Length - idx)
                    {
                        case 3: //#rgb => ffrrggbb
                            var t1 = ToHexD(color[idx++]);
                            var t2 = ToHexD(color[idx++]);
                            var t3 = ToHexD(color[idx]);
                            return Color.FromArgb((int)t1, (int)t2, (int)t3);

                        case 4: //#argb => aarrggbb
                            var f1 = ToHexD(color[idx++]);
                            var f2 = ToHexD(color[idx++]);
                            var f3 = ToHexD(color[idx++]);
                            var f4 = ToHexD(color[idx]);
                            return Color.FromArgb((int)f2, (int)f3, (int)f4, (int)f1);

                        case 6: //#rrggbb => ffrrggbb
                            return Color.FromArgb((int)(ToHex(color[idx++]) << 4 | ToHex(color[idx++])),
                                    (int)(ToHex(color[idx++]) << 4 | ToHex(color[idx++])),
                                    (int)(ToHex(color[idx++]) << 4 | ToHex(color[idx])));

                        case 8: //#aarrggbb
                            var a1 = ToHex(color[idx++]) << 4 | ToHex(color[idx++]);
                            return Color.FromArgb((int)(ToHex(color[idx++]) << 4 | ToHex(color[idx++])),
                                                  (int)(ToHex(color[idx++]) << 4 | ToHex(color[idx++])),
                                                  (int)(ToHex(color[idx++]) << 4 | ToHex(color[idx])),
                                                  (int)a1);

                        default: //everything else will result in unexpected results
                            return Color.Black;
                    }
                }
                else
                {
                    return Color.FromName(color);
                }
            }
            catch(Exception)
            {
                return Color.Black;
            }
        }

        static uint ToHex(char c)
        {
            ushort x = (ushort)c;
            if (x >= '0' && x <= '9')
                return (uint)(x - '0');

            x |= 0x20;
            if (x >= 'a' && x <= 'f')
                return (uint)(x - 'a' + 10);
            return 0;
        }

        static uint ToHexD(char c)
        {
            var j = ToHex(c);
            return (j << 4) | j;
        }
    }
}
