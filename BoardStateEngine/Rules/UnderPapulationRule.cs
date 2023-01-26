using BoardStateEngine.Model;

namespace BoardStateEngine.Rules
{
    public class UnderPapulationRule : BoardRule, IBoardRule
    {
        private readonly IBoardRule _nextBoardRule;

        public UnderPapulationRule(IBoardRule nextBoardRule)
        {
            _nextBoardRule = nextBoardRule;
        }

        public CellState Execute(CellState state, int liveNeighbors)
        {
            ValidateLiveState(state);

            if (liveNeighbors < 2) return CellState.Dead;
            return _nextBoardRule.Execute(state, liveNeighbors);
        }
    }
}
