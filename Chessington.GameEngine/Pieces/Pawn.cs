using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new HashSet<Square>();
            Square newPosition;

            var pos = board.FindPiece(this);

            var step = (Player == Player.Black 
                    ? 1
                    : -1
                );

            newPosition = Square.At(pos.Row + step, pos.Col + 1);
            if (!newPosition.OutOfBounds() && board.GetPiece(newPosition) != null && !Friendly(board.GetPiece(newPosition)))
            {
                moves.Add(newPosition);
            }

            newPosition = Square.At(pos.Row + step, pos.Col - 1);

            if (!newPosition.OutOfBounds() && board.GetPiece(newPosition) != null && !Friendly(board.GetPiece(newPosition)))
            {
                moves.Add(newPosition);
            }

            newPosition = Square.At(pos.Row + step, pos.Col);

            if (newPosition.OutOfBounds() || board.GetPiece(newPosition) != null)
            {
                return moves;
            }

            moves.Add(newPosition);

            newPosition = Square.At(pos.Row + step * 2, pos.Col);

            if (NeverMoved && board.GetPiece(newPosition) == null && !newPosition.OutOfBounds())
            {
                moves.Add(newPosition);
            }

            return moves;
        }
    }
}