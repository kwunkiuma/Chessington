using System;

namespace Chessington.GameEngine
{
    private Square position;
    private int rowChange;
    private int colChange;

    public MoveGenerator(Square position, int rowChange, int colChange)
    {
        this.position = position;
        this.rowChange = rowChange;
        this.colChange = colChange;
    }

    protected nextMove()
    {
        position = Square.At 
    }
}
