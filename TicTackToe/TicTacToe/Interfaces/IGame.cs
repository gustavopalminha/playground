using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Interfaces
{
    public interface IGame
    {
        public void Start();

        public void End();

        public void Play(IPlayer player, int HorizontalIndex, int VerticalIndex);

        public IPlayer? GetWinner();

    }
}
