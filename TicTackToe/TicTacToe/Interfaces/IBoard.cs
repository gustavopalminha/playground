using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Interfaces
{
    public interface IBoard
    {
        public Field[,] Initialialize();

        public int GetHorizontalCount(int HorizontalIdex, Field Symbol);

        public int GetVerticalCount(int VerticalIndex, Field Symbol);

        public int GetDiagonalLeftRightCount(Field Symbol);

        public int GetDiagonalRightLeftCount(Field Symbol);

        public void ChangeSymbol(Field Symbol, int HorizontalIndex, int VerticalIndex);

        public Field GetSymbol(int HorizontalIndex, int VerticalIndex);

    }
}
