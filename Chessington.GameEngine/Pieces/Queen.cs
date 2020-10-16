using System;
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
            Square position = board.FindPiece(this);
            var moves = LateralMoves(board);

            moves.UnionWith(DiagonalMoves(board));

            moves.Remove(position);
            return moves;
        }
    }
}