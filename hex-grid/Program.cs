using Grids.Positions;

var pos = new CubePos(2, 2,-4);
var pos2 = OffsetPos.FromCube(pos, OffsetType.OddR);

Console.WriteLine($"X: {pos2.Q}, Y: {pos2.R}");
