using BoardStateEngine.Model;

var grid = new int[4, 3]
{
    { 0, 1, 0 },
    { 0, 0, 1 },
    { 1, 1, 1 },
    { 0, 0, 0 }
};
var board = new Board(grid);
Console.WriteLine("Input:");
Console.WriteLine(board.ToString());

var nextStates = board.GetNextState();
Console.WriteLine("Output:");
Console.WriteLine(board.ToString());

//board.ChangeCellState(new BordCell(1, 1, CellStateTypes.Live));
//currentState = board.GetCurrentState();
//Console.WriteLine(board.ToString());

Console.ReadKey();
