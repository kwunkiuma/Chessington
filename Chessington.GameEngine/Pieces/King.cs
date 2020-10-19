using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {

            var position = board.FindPiece(this);
            var moves = new HashSet<Square>();

            for (var row = -1; row <= 1; row++)
            {
                for (var col = -1; col <= 1; col++)
                {
                    var newPosition = Square.At(position.Row + row, position.Col + col);
                    if (!newPosition.OutOfBounds())
                    {
                        moves.Add(newPosition);
                    }
                }
            }

            moves.Remove(position);
            return moves;
        }
    }
}