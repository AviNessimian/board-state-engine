using System.Text;

namespace BoardStateEngine.Model
{
    public class Board
    {
        private readonly static object _lock = new object(); 
        private readonly static int[] OffsetVertical = { -1, -1, 0, 1, 1, 1, 0, -1 };
        private readonly static int[] OffsetHrizontal = { 0, 1, 1, 1, 0, -1, -1, -1 };

        private readonly Dictionary<CellKey, BordCell> _grid;
        private readonly Dictionary<CellStateTypes, IBoardRule> _rules;
        private readonly int _rowsLength;
        private readonly int _colsLength;

        public Board(int[,] matrix, Dictionary<CellStateTypes, IBoardRule> rules)
        {
            _rowsLength = matrix.GetLength(0);
            _colsLength = matrix.GetLength(1);
            _grid = ConvertToDictionary(matrix);
            _rules = rules;
        }

        public int[,] GetNextState()
        {
            var boardNextStates = new int[_rowsLength, _colsLength];
            lock(_lock)
            {
                var bordCellToUpdate = new List<BordCell>();
                foreach (var g in _grid)
                {
                    var liveNeighbors = GetNeighborsCountByState(g.Value);
                    var rules = _rules[g.Value.State];
                    var nextState = rules.Execute(g.Value.State, liveNeighbors);
                    if (nextState == g.Value.State) continue;

                    boardNextStates[g.Value.Key.Row, g.Value.Key.Col] = Convert.ToInt32(nextState);
                    bordCellToUpdate.Add(new BordCell(g.Value.Key.Row, g.Value.Key.Col, nextState));
                }

                foreach (var cellToUpdate in bordCellToUpdate)
                {
                    _grid[cellToUpdate.Key] = cellToUpdate;
                }
            }

            return boardNextStates;
        }

        public void ChangeCellState(BordCell bordCell)
        {
            lock (_lock)
            {
                _grid[bordCell.Key] = bordCell;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            int lineNum = 0;
            foreach (var g in _grid)
            {
                if (g.Value.Key.Row != 0 && g.Value.Key.Row != lineNum)
                {
                    sb.AppendLine();
                    lineNum++;
                }
                sb.Append(((int)g.Value.State).ToString());
            }
            sb.AppendLine();
            return sb.ToString();
        }

        private int GetNeighborsCountByState(BordCell bordCell, CellStateTypes cellState = CellStateTypes.Live)
        {
            int neighborsCountByState = 0;
            for (int i = 0; i < 8; i++)
            {
                int ny = bordCell.Key.Row + OffsetVertical[i];
                int nx = bordCell.Key.Col + OffsetHrizontal[i];

                if (nx>=0 && nx<_colsLength && ny>=0 && ny<_rowsLength)
                {
                    var neighborCell = _grid[new CellKey(ny, nx)];
                    if (neighborCell.State == cellState)
                    {
                        neighborsCountByState++;
                    }
                }
            }
            return neighborsCountByState;
        }

        private Dictionary<CellKey, BordCell> ConvertToDictionary(int[,] matrix)
        {
            var grid = new Dictionary<CellKey, BordCell>();
            for (int i = 0; i < _rowsLength; i++)
            {
                for (int j = 0; j < _colsLength; j++)
                {
                    var state = (CellStateTypes)matrix[i, j];
                    var boardCell = new BordCell(i, j, state);
                    grid.Add(boardCell.Key, boardCell);
                }
            }
            return grid;
        }
    }
}
