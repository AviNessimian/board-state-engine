namespace BoardStateEngine.Model
{
    public interface IBoardRule
    {
        public CellStateTypes Execute(CellStateTypes state, int liveNeighbors);
    }
}
