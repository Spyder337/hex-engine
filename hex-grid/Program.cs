using Grids.Positions;
using Grids.Neighbors;

var pos = new CubePos(2, 2,-4);
var pos2 = new CubePos(0, -1, 1);

var pos3 = pos + pos2;

Console.WriteLine($"X: {pos3.Q}, Y: {pos3.R}");

var pos4 = Cube.CubeNeighbor(pos3, 0);

Console.WriteLine($"X: {pos4.Q}, Y: {pos4.R}");