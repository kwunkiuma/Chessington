using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return MoveHelper.GetStraightMoves(board, this, MoveHelper.Lateral).Concat(MoveHelper.GetStraightMoves(board, this, MoveHelper.Diagonal));
        }
    }
}