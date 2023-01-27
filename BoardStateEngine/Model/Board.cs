using BoardStateEngine.Rules;
using System.Text;

namespace BoardStateEngine.Model
{
    public class Board
    {
        private readonly Dictionary<Cell, BordCell> _grid;
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
            var bordCellToUpdate = new List<BordCell>();
            foreach (var g in _grid)
            {
                var liveNeighbors = GetNeighborsCountByState(g.Value);
                var rules = _rules[g.Value.State];
                var nextState = rules.Execute(g.Value.State, liveNeighbors);
                boardNextStates[g.Value.Row, g.Value.Col] = Convert.ToInt32(nextState);

                if (nextState == g.Value.State) continue;
                bordCellToUpdate.Add(new BordCell(g.Value.Row, g.Value.Col, nextState));
            }

            foreach (var cellToUpdate in bordCellToUpdate)
            {
                ChangeCellState(cellToUpdate);
            }
            return boardNextStates;
        }

        public void ChangeCellState(BordCell newCell)
        {
            _grid[newCell] = newCell;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            int lineNum = 0;
            foreach (var g in _grid)
            {
                if (g.Value.Row != 0 && g.Value.Row != lineNum)
                {
                    sb.AppendLine();
                    lineNum++;
                }
                sb.Append(((int)g.Value.State).ToString());
            }
            sb.AppendLine();
            return sb.ToString();
        }


        private readonly static int[] OffsetVertical = { -1, -1, 0, 1, 1, 1, 0, -1 };
        private readonly static int[] OffsetHrizontal = { 0, 1, 1, 1, 0, -1, -1, -1 };

        private int GetNeighborsCountByState(BordCell cell, CellStateTypes cellState = CellStateTypes.Live)
        {
            int neighborsCountByState = 0;
            for (int i = 0; i < 8; i++)
            {
                int ny = cell.Row + OffsetVertical[i];
                int nx = cell.Col + OffsetHrizontal[i];

                if (nx>=0 && nx<_colsLength && ny>=0 && ny<_rowsLength)
                {
                    var neighborCell = _grid[new Cell(ny, nx)];
                    if (neighborCell.State == cellState)
                    {
                        neighborsCountByState++;
                    }
                }
            }
            return neighborsCountByState;
        }

        private Dictionary<Cell, BordCell> ConvertToDictionary(int[,] matrix)
        {
            var grid = new Dictionary<Cell, BordCell>();
            for (int i = 0; i < _rowsLength; i++)
            {
                for (int j = 0; j < _colsLength; j++)
                {
                    var state = (CellStateTypes)matrix[i, j];
                    var boardCell = new BordCell(i, j, state);
                    grid.Add(boardCell, boardCell);
                }
            }
            return grid;
        }
    }
}
