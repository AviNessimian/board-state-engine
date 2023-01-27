namespace BoardStateEngine.Model
{
    public class BordCell
    {
        public int Row { get; }
        public int Col { get; }
        public CellStateTypes State { get; }

        public BordCell(int row, int col, CellStateTypes state)
         {
            Row = row;
            Col = col;
            State = state;
        }

        public override bool Equals(object? other)
        {
            return other is BordCell c
                && Row == c.Row
                && Col == c.Col;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        } 
    }
}
