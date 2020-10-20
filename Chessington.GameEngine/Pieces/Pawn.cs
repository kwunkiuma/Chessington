using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
            if (IsValid(board, rightCapture) && !board.IsEmpty(rightCapture))
            {
                moves.Add(rightCapture);
            }
            
            var leftCapture= Square.At(position.Row + step, position.Col - 1);
            if (IsValid(board, leftCapture) && !board.IsEmpty(leftCapture))
            {
                moves.Add(leftCapture);
            }

            var oneForward = Square.At(position.Row + step, position.Col);
            if (IsValid(board, oneForward) && board.IsEmpty(oneForward))
            {
                moves.Add(oneForward);
            }
            else
            {
                return moves;
            }

            var twoForward = Square.At(position.Row + step * 2, position.Col);
            if (NeverMoved && IsValid(board, twoForward) && board.IsEmpty(twoForward))
            {
                moves.Add(twoForward);
            }

            return moves;
        }
    }
}