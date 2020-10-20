﻿using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            var possibleMoves = new List<Square>(new[]
            {
                Square.At(position.Row - 1, position.Col - 2),
                Square.At(position.Row - 1, position.Col + 2),
                Square.At(position.Row + 1, position.Col - 2),
                Square.At(position.Row + 1, position.Col + 2),
                Square.At(position.Row - 2, position.Col - 1),
                Square.At(position.Row - 2, position.Col + 1),
                Square.At(position.Row + 2, position.Col - 1),
                Square.At(position.Row + 2, position.Col + 1),
            });

            var moves = new List<Square>();

            foreach (var square in possibleMoves)
            {
                if (IsValidMove(board, square))
                {
                    moves.Add(square);
                }
            }

            return moves;
        }
    }
}