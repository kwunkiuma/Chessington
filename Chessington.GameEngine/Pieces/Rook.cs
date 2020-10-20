﻿using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return MoveHelper.GetStraightMoves(board, this, typeof(Lateral));
        }
    }
}