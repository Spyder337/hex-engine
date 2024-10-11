using Grids.Positions;
using System.Collections.Generic;

namespace Grids.Neighbors;

public static class Cube
{
    /// <summary>
    /// Directions in the cube coordinate space.
    /// 0 = North, 1 = North-East, 2 = South-East, 3 = South,
    /// 4 = South-West, 5 = North-West.
    /// </summary>
    public const CubePos[] CUBE_DIRS = new CubePos[
        //  Flat top directions.
        //  North
        new CubePos(0, -1, 1),
        //  North-East
        new CubePos(1, -1, 0),
        //  South-East
        new CubePos(1, 0, -1),
        //  South
        new CubePos(0, 1, -1),
        //  South-West
        new CubePos(-1, 1, 0),
        //  North-West
        new CubePos(-1, 0, 1)
    ];

    public static CubePos CubeDirection(int dir)
    {
        return CUBE_DIRS[dir];
    }
}

