using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Chessington.GameEngine.Pieces
{
    enum Lateral
    {
        Up,
        Down,
        Left,
        Right
    }

    enum Diagonal
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
    }

    class MoveHelper
    {
        private Square position;

        public MoveHelper()
        {
        }

        private static void GetChange(Object direction, out int rowChange, out int colChange)
        {
            switch (direction)
            {
                case Diagonal.TopLeft:
                    rowChange = -1;
                    colChange = -1;
                    break;
                case Diagonal.TopRight:
                    rowChange = -1;
                    colChange = 1;
                    break;
                case Diagonal.BottomLeft:
                    rowChange = 1;
                    colChange = -1;
                    break;
                case Diagonal.BottomRight:
                    rowChange = 1;
                    colChange = 1;
                    break;
                case Lateral.Up:
                    rowChange = -1;
                    colChange = 0;
                    break;
                case Lateral.Down:
                    rowChange = 1;
                    colChange = 0;
                    break;
                case Lateral.Left:
                    rowChange = 0;
                    colChange = -1;
                    break;
                case Lateral.Right:
                    rowChange = 0;
                    colChange = 1;
                    break;
                default:
                    rowChange = 0;
                    colChange = 0;
                    break;
            }
        }

        public static HashSet<Square> GetStraightMoves(Board board, Piece piece, Type directions)
        {
            var moves = new HashSet<Square>();

            foreach (var direction in Enum.GetValues(directions))
            {
                var newPosition = board.FindPiece(piece);

                GetChange(direction, out var rowChange, out var colChange);

                do
                {
                    newPosition = NextMove(newPosition, rowChange, colChange);

                    if (newPosition.OutOfBounds() || piece.IsFriendly(board.GetPiece(newPosition)))
                    {
                        break;
                    }

                    moves.Add(newPosition);
                } while (board.IsEmpty(newPosition));
            }

            return moves;
        }

        private static Square NextMove(Square position, int rowChange, int colChange)
        {
            return Square.At(position.Row + rowChange, position.Col + colChange);
        }
    }
}