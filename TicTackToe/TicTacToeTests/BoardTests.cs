using TicTacToe.Entities;
using TicTacToe.Interfaces;

namespace TicTacToeTests
{
    public class BoardTests
    {
        [Fact]
        public void ShouldBeEmpty()
        {
            var board = new Board();
            var matrix = board.Initialialize();

            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    if (matrix[i, j] == TicTacToe.Entities.Field.Empty)
                    {
                        count++;
                    }
                }
            }

            Assert.Equal(9, count);
        }

        [Theory]
        [InlineData (0)]
        [InlineData (1)]
        [InlineData (2)]
        public void ShouldReturnHorizontalCountByIndex(int verticalIndex)
        {
            var board = new Board();
            var matrix = board.Initialialize();
            
            
            board.ChangeSymbol(Field.X, 0, verticalIndex);

            int result = board.GetHorizontalCount(0 ,Field.X);
            
            Assert.Equal(1, result);


            board.ChangeSymbol(Field.X, 1, verticalIndex);
            int result2nRow = board.GetHorizontalCount(1, Field.X);
            
            Assert.Equal(1, result2nRow);

        }

        [Fact]
        public void ShouldGetSymbolFromIndexes()
        {
            var board = new Board();

            Field result = board.GetSymbol(0, 0);

            Assert.Equal(Field.Empty, result);

        }


    }
}