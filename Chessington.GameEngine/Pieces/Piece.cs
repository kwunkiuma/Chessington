using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        public Player Player { get; private set; }

        protected bool NeverMoved { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            NeverMoved = false;
        }

        public bool IsFriendly(Piece piece)
        {
            return (piece != null && piece.Player == Player);
        }

        protected Piece(Player player)
        {
            Player = player;
            NeverMoved = true;
        }

        protected bool IsValid(Board board, Square square)
        {
            return !square.OutOfBounds() && !IsFriendly(board.GetPiece(square));
        }
    }
}