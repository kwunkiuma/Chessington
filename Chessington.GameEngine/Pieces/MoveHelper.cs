using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    class MoveHelper
    {
        public static Direction[] Lateral = new Direction[]
        {
            new Direction(1, 0),
            new Direction(-1, 0),
            new Direction(0, 1),
            new Direction(0, -1)
        };

        public static Direction[] Diagonal = new Direction[]
        {
            new Direction(1, 1),
            new Direction(-1, 1),
            new Direction(1, -1),
            new Direction(-1, -1)
        };

        public static List<Square> GetStraightMoves(Board board, Piece piece, Direction[] directions)
        {
            var moves = new List<Square>();

            foreach (var direction in directions)
            {
                var newPosition = board.FindPiece(piece);

                do
                {
                    newPosition = NextMove(newPosition, direction);

                    if (newPosition.OutOfBounds() || piece.IsFriendly(board.GetPiece(newPosition)))
                    {
                        break;
                    }

                    moves.Add(newPosition);
                } while (board.IsEmpty(newPosition));
            }

            return moves;
        }

        private static Square NextMove(Square position, Direction direction)
        {
            return Square.At(position.Row + direction.RowChange, position.Col + direction.ColChange);
        }
    }
}