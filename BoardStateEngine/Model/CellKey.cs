namespace BoardStateEngine.Model
{
    public struct CellKey
    {
        public int Row { get; }
        public int Col { get; }

        public CellKey(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override bool Equals(object? obj) => obj is CellKey other && Equals(other);
        public bool Equals(CellKey p) => Row == p.Row && Col == p.Col;
        public override int GetHashCode() => (Row, Col).GetHashCode();
        public static bool operator ==(CellKey lhs, CellKey rhs) => lhs.Equals(rhs);
        public static bool operator !=(CellKey lhs, CellKey rhs) => !(lhs == rhs);
    }
}
