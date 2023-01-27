using BoardStateEngine.Model;

var grid = new int[4, 3]
{
    { 0, 1, 0 },
    { 0, 0, 1 },
    { 1, 1, 1 },
    { 0, 0, 0 }
};
var board = new Board(grid);

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