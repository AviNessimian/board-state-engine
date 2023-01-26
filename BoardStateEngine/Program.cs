using BoardStateEngine.Model;

var grid = new Cell[4, 3];
var board = new Board(grid);

board.ChangeCellState(new Cell(0, 0, CellState.Dead));
board.ChangeCellState(new Cell(0, 1, CellState.Live));
board.ChangeCellState(new Cell(0, 2, CellState.Dead));

board.ChangeCellState(new Cell(1, 0, CellState.Dead));
board.ChangeCellState(new Cell(1, 1, CellState.Dead));
board.ChangeCellState(new Cell(1, 2, CellState.Live));

board.ChangeCellState(new Cell(2, 0, CellState.Live));
board.ChangeCellState(new Cell(2, 1, CellState.Live));
board.ChangeCellState(new Cell(2, 2, CellState.Live));

board.ChangeCellState(new Cell(3, 0, CellState.Dead));
board.ChangeCellState(new Cell(3, 1, CellState.Dead));
board.ChangeCellState(new Cell(3, 2, CellState.Dead));

var currentState = board.GetCurrentState();
Print(currentState);

//board.ChangeCellState(new Cell(1, 1, CellState.Live));
//currentState = board.GetCurrentState();
//Print(currentState);

Console.ReadKey();


static void Print(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write("{0} ", array[i, j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}