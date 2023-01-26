using BoardStateEngine.Model;

namespace BoardStateEngine.Rules
{
    public class NextGenerationRule : BoardRule, IBoardRule
    {
        private readonly IBoardRule _nextBoardRule;

        public NextGenerationRule(IBoardRule nextBoardRule)
        {
            _nextBoardRule = nextBoardRule;
        }

        public CellState Execute(CellState state, int liveNeighbors)
        {
            ValidateLiveState(state);

            if (liveNeighbors == 2 || liveNeighbors == 3) return CellState.Live;
            return _nextBoardRule.Execute(state, liveNeighbors);
        }
    }
}
