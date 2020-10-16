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
            var result = new List<Square>();

            var pos = board.FindPiece(this);

            var step = (Player == Player.Black 
                    ? 1
                    : -1
                );

            result.Add(Square.At(pos.Row + step, pos.Col));

            if (neverMoved)
            {
                result.Add(Square.At(pos.Row + step*2, pos.Col));
            }

            return result;
        }
    }
}