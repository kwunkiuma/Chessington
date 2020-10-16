using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square position = board.FindPiece(this);
            var moves = new HashSet<Square>();

            for (var col = 0; col < 8; col++)
            {
                moves.Add(Square.At(position.Row, col));
            }

            for (var row = 0; row < 8; row++)
            {
                moves.Add(Square.At(row, position.Col));
            }

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