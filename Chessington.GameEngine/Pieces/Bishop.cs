using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new HashSet<Square>();
            var position = board.FindPiece(this);

            for (var row = 0; row < 8; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    if (Math.Abs(row - position.Row) == Math.Abs(col - position.Col))
                    {
                        moves.Add((Square.At(row, col)));
                    }
                }
            }

            moves.Remove(position);

            return moves;
        }
    }
}