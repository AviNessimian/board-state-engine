namespace BoardStateEngine.Model
{
    public interface IBoardRule
    {
        public CellState Execute(CellState state, int liveNeighbors);
    }


    public abstract class BoardRule
    {
        public virtual void ValidateLiveState(CellState state)
        {
            if (state != CellState.Live)
                throw new Exception($"Rule is for {CellState.Live} state only");
        }

        public virtual void ValidateDeadState(CellState state)
        {
            if (state != CellState.Dead)
                throw new Exception($"Rule is for {CellState.Dead} state only");
        }
    }
}
