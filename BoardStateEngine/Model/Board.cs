using BoardStateEngine.Rules;

namespace BoardStateEngine.Model
{
    public class Board
    {
        private readonly Cell[,] _grid;
        private readonly Dictionary<CellState, IBoardRule> _boardRules;
        private readonly int _rowsLength;
        private readonly int _colsLength;

        private readonly static int[] OffsetVertical = { -1, -1, 0, 1, 1, 1, 0, -1 };
        private readonly static int[] OffsetHrizontal = { 0, 1, 1, 1, 0, -1, -1, -1 };
        public Board(Cell[,] grid)
        {
            _rowsLength =  grid.GetLength(0);
            _colsLength = grid.GetLength(1);

            _grid = grid;

            _boardRules = new Dictionary<CellState, IBoardRule>
            {
                {
                    CellState.Live,
                    new UnderPapulationRule(
                        new NextGenerationRule(
                            new OverPopulationRule(
                                new ReturnStateRule())))
                },
                {
                    CellState.Dead,
                    new ReproductionRule(
                        new ReturnStateRule())
                }
            };
        }

        public void ChangeCellState(Cell newCell)
        {
            _grid[newCell.Row, newCell.Col]  = newCell;
        }

        public int[,] GetCurrentState()
        {
            var boardCurrentState = new int[_rowsLength, _colsLength];

            for (int i = 0; i < _rowsLength; i++)
            {
                for (int j = 0; j < _colsLength; j++)
                {
                    var cell = _grid[i, j];
                    var liveNeighbors = GetNeighborsCountByState(cell);
                    var rules = _boardRules[cell.State];
                    var currentState = rules.Execute(cell.State, liveNeighbors);

                    boardCurrentState[i, j] = Convert.ToInt32(currentState);
                }
            }

            return boardCurrentState;
        }

        private int GetNeighborsCountByState(Cell cell, CellState cellState = CellState.Live)
        {
            int neighborsCountByState = 0;

            for (int i = 0; i < 8; i++)
            {
                int ny = cell.Row + OffsetVertical[i];
                int nx = cell.Col + OffsetHrizontal[i];

                if (nx>=0 && nx<_rowsLength && ny>=0 && ny<_colsLength)
                {
                    var neighborCell = _grid[nx, ny];
                    if (neighborCell.State == cellState)
                    {
                        neighborsCountByState++;
                    }
                }
            }

            return neighborsCountByState;
        }
    }
}
