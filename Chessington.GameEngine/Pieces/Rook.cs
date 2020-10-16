using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square position = board.FindPiece(this);
            var moves = new List<Square>();
            for (var col = 0; col < 8; col++)
            {
                moves.Add(Square.At(position.Row, col));
            }

            for (var row = 0; row < 8; row++)
            {
                moves.Add(Square.At(row, position.Col));
            }

            moves.Remove(position);
            return moves;
        }
    }
}