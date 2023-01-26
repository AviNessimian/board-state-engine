namespace BoardStateEngine.Model
{
    public class Cell
    {
        public Cell(int row, int col,  CellState state) 
        {
            Row = row;
            Col = col;
            State = state;
        }   

        public int Row { get; }
        public int Col { get; }
        public CellState State { get; }
    }
}
