/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BarnsleyFern
{
    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            using (var provider = new RNGCryptoServiceProvider())
            {
                int n = list.Count;

                while (n > 1)
                {
                    byte[] box = new byte[1];

                    do
                    {
                        provider.GetBytes(box);
                    }
                    while (!(box[0] < n * (Byte.MaxValue / n)));

                    int k = (box[0] % n);

                    n--;

                    T value = list[k];
                    list[k] = list[n];
                    list[n] = value;
                }
            }
        }

        public static double Map(this double value, double from1, double to1, double from2, double to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }
}
