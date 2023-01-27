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

        public CellStateTypes Execute(CellStateTypes state, int liveNeighbors)
        {
            ValidateLiveState(state);

            if (liveNeighbors == 2 || liveNeighbors == 3) return CellStateTypes.Live;
            return _nextBoardRule.Execute(state, liveNeighbors);
        }
    }
}
