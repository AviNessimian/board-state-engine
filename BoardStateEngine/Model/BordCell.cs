namespace BoardStateEngine.Model
{
    public class BordCell: Cell
    {
        public BordCell(int row, int col,  CellStateTypes state)
            : base(row, col)
        {
            State = state;
        }   

        public CellStateTypes State { get; }
    }
}
