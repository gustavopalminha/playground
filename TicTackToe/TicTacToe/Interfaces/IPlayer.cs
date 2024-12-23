using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Interfaces
{
    public interface IPlayer
    {
        Field Symbol { get; set; }

        string Name { get; set; }
    }
}
