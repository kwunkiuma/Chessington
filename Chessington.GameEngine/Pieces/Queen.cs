using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = MoveHelper.GetStraightMoves(board, this, typeof(Lateral));
            moves.UnionWith(MoveHelper.GetStraightMoves(board, this, typeof(Diagonal)));
            return moves;
        }
    }
}