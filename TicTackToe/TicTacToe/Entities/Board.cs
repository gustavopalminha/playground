using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Entities
{
    public class Board : IBoard
    {
        private Field[,] Matrix;

        public Board()
        {
            Matrix = Initialialize();
        }

        public void ChangeSymbol(Field Symbol, int HorizontalIndex, int VerticalIndex)
        {
            Matrix[HorizontalIndex, VerticalIndex] = Symbol;
        }

        public int GetDiagonalLeftRightCount(Field Symbol)
        {
            throw new NotImplementedException();
        }

        public int GetDiagonalRightLeftCount(Field Symbol)
        {
            throw new NotImplementedException();
        }

        public int GetHorizontalCount(int HorizontalIndex, Field Symbol)
        {
            int Count = 0;
            var VerticalIndex = 0;
            for (int i = 0; i < Matrix.GetLength(HorizontalIndex); i++)
            {
                if (Matrix[VerticalIndex, i] == Symbol)
                {
                    Count++;
                }
            }

            return Count;
        }

        public Field GetSymbol(int HorizontalIndex, int VerticalIndex)
        {
            return Matrix[HorizontalIndex, VerticalIndex];
        }

        public int GetVerticalCount(int VerticalIndex, Field Symbol)
        {
            int Count = 0;
            var HorizontalIndex = 0;

            for (int i = 0; i < Matrix.GetLength(HorizontalIndex); i++)
            {
                if (Matrix[i, VerticalIndex] == Symbol)
                {
                    Count++;
                }
            }

            return Count;
        }

        public Field[,] Initialialize()
        {
            return new Field[,] {
                { Field.Empty, Field.Empty, Field.Empty},
                { Field.Empty, Field.Empty,Field.Empty},
                { Field.Empty, Field.Empty, Field.Empty }
            };
        }
    }
}
