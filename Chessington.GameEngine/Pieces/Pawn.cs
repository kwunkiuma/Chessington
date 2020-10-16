using System.Collections.Generic;

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

            result.Add(Player == Player.Black
                ? Square.At(pos.Row + 1, pos.Col)
                : Square.At(pos.Row - 1, pos.Col));

            return result;
        }
    }
}