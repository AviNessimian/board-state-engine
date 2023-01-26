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

        public CellState Execute(CellState state, int liveNeighbors)
        {
            ValidateDeadState(state);

            if (liveNeighbors == 3) return CellState.Dead;
            return _nextBoardRule.Execute(state, liveNeighbors);
        }
    }
}
