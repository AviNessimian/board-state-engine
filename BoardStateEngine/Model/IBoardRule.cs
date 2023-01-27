namespace BoardStateEngine.Model
{
    public interface IBoardRule
    {
        public CellStateTypes Execute(CellStateTypes state, int liveNeighbors);
    }


    public abstract class BoardRule
    {
        public virtual void ValidateLiveState(CellStateTypes state)
        {
            if (state != CellStateTypes.Live)
                throw new Exception($"Rule is for {CellStateTypes.Live} state only");
        }

        public virtual void ValidateDeadState(CellStateTypes state)
        {
            if (state != CellStateTypes.Dead)
                throw new Exception($"Rule is for {CellStateTypes.Dead} state only");
        }
    }
}
