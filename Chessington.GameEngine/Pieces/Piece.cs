using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected bool neverMoved;

        protected Piece(Player player)
        {
            Player = player;
            neverMoved = true;
        }

        protected HashSet<Square> LateralMoves(Board board)
        {
            var moves = new HashSet<Square>();
            var position = board.FindPiece(this);

            for (var i = 3; i < 7; i++)
            {
                var rowDiff = Convert.ToInt32(Math.Pow(-(i % 2), i / 2));
                var colDiff = Convert.ToInt32(Math.Pow(-1 + (i % 2), i / 2));

                var row = position.Row;
                var col = position.Col;

                row += rowDiff;
                col += colDiff;

                while (Math.Min(row, col) >= 0 && Math.Max(row, col) <= 7)
                {
                    if (board.GetPiece(Square.At(row, col)) != null)
                    {
                        if (board.GetPiece(Square.At(row, col)).Player != Player)
                        {
                            moves.Add(Square.At(row, col));
                            break;
                        }

                        if (board.GetPiece(Square.At(row, col)).Player == Player)
                        {
                            break;
                        }
                    }

                    moves.Add(Square.At(row, col));

                    row += rowDiff;
                    col += colDiff;
                }
            }

            return moves;
        }
        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            neverMoved = false;
        }
    }
}