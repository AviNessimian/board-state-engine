namespace BoardStateEngine.Model
{
    public class BordCell
    {
        public CellKey Key { get; }
        public BordCell(int row, int col,  CellStateTypes state)
        {
            State = state;
            Key = new CellKey(row, col);  
        }   

        public CellStateTypes State { get; }
    }
}
