namespace Chessington.GameEngine
{
    public class Direction
    {
        public readonly int RowChange;
        public readonly int ColChange;

        public Direction(int rowChange, int colChange)
        {
            RowChange = rowChange;
            ColChange = colChange;
        }
    }
}
