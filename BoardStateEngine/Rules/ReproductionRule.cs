using BoardStateEngine.Model;

namespace BoardStateEngine.Rules
{
    public class ReproductionRule : BoardRule, IBoardRule
    {
        private readonly IBoardRule _nextBoardRule;

        public ReproductionRule(IBoardRule nextBoardRule)
        {
            _nextBoardRule = nextBoardRule;
        }

        public CellStateTypes Execute(CellStateTypes state, int liveNeighbors)
        {
            ValidateDeadState(state);

            if (liveNeighbors == 3) return CellStateTypes.Live;
            return _nextBoardRule.Execute(state, liveNeighbors);
        }
    }
}
