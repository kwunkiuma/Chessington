using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            var moves = new HashSet<Square>();

            for (var row = 0; row < 8; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    var rowDiff = Math.Abs(position.Row - row);
                    var colDiff = Math.Abs(position.Col - col);

                    if (board.GetPiece(Square.At(row, col)) != null && board.GetPiece(Square.At(row, col)).Player == this.Player)
                    {
                        continue;
                    }

                    if (rowDiff + colDiff == 3 && rowDiff * colDiff != 0)
                    {
                        moves.Add(Square.At(row, col));
                    }
                }
            }

            return moves;
        }
    }
}