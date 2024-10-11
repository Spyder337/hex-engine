using Grids.Positions;
using Grids.Neighbors;

var pos = new CubePos(2, 2,-4);
var pos2 = new CubePos(0, -1, 1);

var pos3 = pos + pos2;

Console.WriteLine($"X: {pos2.Q}, Y: {pos2.R}");
