using BoardStateEngine.Model;

namespace BoardStateEngine.Rules
{
    public class OverPopulationRule : BoardRule, IBoardRule
    {
        private readonly IBoardRule _nextBoardRule;

        public OverPopulationRule(IBoardRule nextBoardRule)
        {
            _nextBoardRule = nextBoardRule;
        }

        public CellStateTypes Execute(CellStateTypes state, int liveNeighbors)
        {
            ValidateLiveState(state);

            if (liveNeighbors > 3) return CellStateTypes.Dead;
            return _nextBoardRule.Execute(state, liveNeighbors);
        }
    }
}
