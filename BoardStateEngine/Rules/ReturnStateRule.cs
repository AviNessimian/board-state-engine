using BoardStateEngine.Model;

namespace BoardStateEngine.Rules
{
    public class ReturnStateRule : IBoardRule
    {
        public CellStateTypes Execute(CellStateTypes state, int liveNeighbors) => state;
    }
}
