/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System;

namespace Matrix
{
    class Symbol
    {
        private char value;
        private Random random;

        public float X;
        public float Y;
        public int Speed;
        public Boolean IsFirst;

        public string Char
        {
            get
            {
                return value.ToString();
            }
        }

        public Symbol()
        {
            random = new Random();
        }

        public void SetToRandomSymbol()
        {
            value = (char)(0x30A0 + random.Next(0, 96));
        }
    }
}
