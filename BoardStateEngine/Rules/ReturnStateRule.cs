using BoardStateEngine.Model;

namespace BoardStateEngine.Rules
{
    public class ReturnStateRule : IBoardRule
    {
        public CellState Execute(CellState state, int liveNeighbors) => state;
    }
}
