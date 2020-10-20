using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public bool EnPassant { get; private set; }

        public Pawn(Player player)
            : base(player)
        {
            EnPassant = false;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new HashSet<Square>();

            var position = board.FindPiece(this);

            var step = (Player == Player.Black
                ? 1
                : -1
            );

            var rightCapture = Square.At(position.Row + step, position.Col + 1);
            if (IsValidMove(board, rightCapture) && !board.IsEmpty(rightCapture))
            {
                moves.Add(rightCapture);
            }
            
            var leftCapture= Square.At(position.Row + step, position.Col - 1);
            if (IsValidMove(board, leftCapture) && !board.IsEmpty(leftCapture))
            {
                moves.Add(leftCapture);
            }

            var oneForward = Square.At(position.Row + step, position.Col);
            if (IsValidMove(board, oneForward) && board.IsEmpty(oneForward))
            {
                moves.Add(oneForward);
            }
            else
            {
                return moves;
            }

            var twoForward = Square.At(position.Row + step * 2, position.Col);
            if (NeverMoved && IsValidMove(board, twoForward) && board.IsEmpty(twoForward))
            {
                moves.Add(twoForward);
            }

            return moves;
        }
    }
}