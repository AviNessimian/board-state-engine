
# Senior BackEnd Engineer Exercise:

The board is made up of an m x n grid of cells, 
where each cell has an initial state: live (represented by a 1) or dead (represented by a 0). 

Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules:
1.	Any live cell with fewer than two live neighbors dies as if caused by under-population.
2.	Any live cell with two or three live neighbors lives on to the next generation.
3.	Any live cell with more than three live neighbors dies, as if by over-population.
4.	Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

The next state is created by applying the above rules simultaneously to every cell in the current state, where births and deaths occur simultaneously. 
Given the current state of the m x n grid board, return the next state. 

Input: board =
[
[0,1,0],
[0,0,1],
[1,1,1],
[0,0,0]
]

Output:
[
[0,0,0],
[1,0,1],
[0,1,1],
[0,1,0]
]


![exercise](Exercise.png)
