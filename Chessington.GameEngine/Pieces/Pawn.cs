using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Win32.SafeHandles;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new HashSet<Square>();

            var pos = board.FindPiece(this);

            var step = (Player == Player.Black 
                    ? 1
                    : -1
                );

            if (board.GetPiece(Square.At(pos.Row + step, pos.Col)) != null)
            {
                return moves;
            }

            moves.Add(Square.At(pos.Row + step, pos.Col));

            if (neverMoved && board.GetPiece(Square.At(pos.Row + step*2, pos.Col)) == null)
            {
                moves.Add(Square.At(pos.Row + step*2, pos.Col));
            }

            return moves;
        }
    }
}