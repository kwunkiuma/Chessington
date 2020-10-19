using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square position = board.FindPiece(this);
            var moves = LateralMoves(board);

            moves.Remove(position);
            return moves;
        }
    }
}