namespace Chessington.GameEngine
{
    public class Direction
    {
        public int RowChange;
        public int ColChange;

        public Direction(int rowChange, int colChange)
        {
            RowChange = rowChange;
            ColChange = colChange;
        }
    }
}
