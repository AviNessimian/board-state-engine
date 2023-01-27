namespace BoardStateEngine.Model
{
    public class Cell
    {
        public int Row { get; }
        public int Col { get; }

        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override bool Equals(object? other)
        {
            return other is Cell c
                && Row == c.Row
                && Col == c.Col;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }
    }
}
