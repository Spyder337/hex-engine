using Grids.Positions;

namespace Grids.Neighbors;

public static class Cube
{
  /// <summary>
  /// Directions in the cube coordinate space.
  /// 0 = North, 1 = North-East, 2 = South-East, 3 = South,
  /// 4 = South-West, 5 = North-West.
  /// </summary>
  public static readonly CubePos[] CUBE_DIRS = [
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

  public static CubePos CubeNeighbor(CubePos origin, int dir)
  {
    return CUBE_DIRS[dir] + origin;
  }
}

public static class Axial
{
  public static readonly AxialPos[] AXIAL_DIRS = [
      new AxialPos(0, -1),
        new AxialPos(1, -1),
        new AxialPos(1, 0),
        new AxialPos(0, 1),
        new AxialPos(-1, 1),
        new AxialPos(-1, 0)
  ];

  public static AxialPos AxialDirection(int dir)
  {
    return AXIAL_DIRS[dir];
  }

  public static AxialPos AxialNeighbor(AxialPos origin, int dir)
  {
    return AXIAL_DIRS[dir] + origin;
  }
}

public static class Offset
{
  // The array is in the format for Odd-R. Even-R is just the arrays inverted.
  // Therefore there is no need to duplicate data. Just invert the parity for
  // Even-R.
  public static readonly int[][][] OFFSET_ROW_DIRS = [
      [
            [-1, -1],
            [0, -1],
            [1, 0],
            [0, 1],
            [-1, 1],
            [-1, 0]

        ],
        [
            [0, -1],
            [1, -1],
            [1, 0],
            [1, 1],
            [0, 1],
            [-1, 0]
        ]
  ];

  //  The same rules that apply to the ROW_DIRS also applies to the COL DIRS
  public static readonly int[][][] OFFSET_COL_DIRS = [
      [
            [0, -1],
            [1, -1],
            [1, 0],
            [0, 1],
            [-1, 0],
            [-1, -1],
        ],
        [
            [0, -1],
            [1, 0],
            [1, 1],
            [0, 1],
            [-1, 1],
            [-1, 0]
        ]
  ];

  public static OffsetPos OffsetNeighbor(OffsetPos origin, int dir)
  {
    int parity = origin.R & 1;
    int[] diffs;

    switch (origin.OffsetType)
    {
      case OffsetType.OddR:
        diffs = OFFSET_ROW_DIRS[parity][dir];
        break;
      case OffsetType.EvenR:
        if (parity == 1)
        {
          parity = 0;
        }
        else
        {
          parity = 1;
        }
        diffs = OFFSET_ROW_DIRS[parity][dir];
        break;
      case OffsetType.OddQ:
        diffs = OFFSET_COL_DIRS[parity][dir];
        break;
      case OffsetType.EvenQ:
        if (parity == 1)
        {
          parity = 0;
        }
        else
        {
          parity = 1;
        }
        diffs = OFFSET_COL_DIRS[parity][dir];
        break;
      default:
        diffs = new int[2];
        break;
    }
    return new OffsetPos(origin.Q + diffs[0], origin.R + diffs[1]);
  }
}