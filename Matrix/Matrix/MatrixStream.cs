/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System;
using System.Collections.Generic;

namespace Matrix
{
    class MatrixStream
    {
        private List<Symbol> symbols;
        private readonly int totalSymbols;
        private readonly int speed;

        public int SymbolSize;

        public List<Symbol> Symbols
        {
            get
            {
                return symbols;
            }
        }

        public MatrixStream(Random random)
        {
            totalSymbols = random.Next(5, 30);
            speed = random.Next(5, 20);
            symbols = new List<Symbol>();
        }

        public void GenerateSymbols(int startX, int startY)
        {
            Symbol symbol;
            int x;
            int y;
            Boolean isFirst;

            y = startY;
            x = startX;
            isFirst = true;

            for (int i = 0; i <= totalSymbols; i++)
            {
                symbol = new Symbol
                {
                    X = x,
                    Y = y,
                    Speed = speed,
                    IsFirst = isFirst
                };

                symbol.SetToRandomSymbol();

                symbols.Add(symbol);

                y -= SymbolSize;
                isFirst = false;
            }
        }
    }
}
