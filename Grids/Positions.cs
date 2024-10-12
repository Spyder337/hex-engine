namespace Grids.Positions;

public enum OffsetType
{
  //  Odd and even rows.
  OddR,
  EvenR,
  //  Odd and even columns.
  OddQ,
  EvenQ
}

public class OffsetPos
{
  public OffsetType OffsetType { get; set; }
  /// <summary>
  /// Column.
  /// </summary>
  public int Q { get; set; }
  /// <summary>
  /// Row.
  /// </summary>
  public int R { get; set; }

  public OffsetPos()
  {
    OffsetType = OffsetType.OddR;
    Q = 0;
    R = 0;
  }

  public OffsetPos(int q, int r)
  {
    Q = q;
    R = r;
  }

  public OffsetPos(int q, int r, OffsetType type) : this(q, r)
  {
    OffsetType = type;
  }

  public static OffsetPos FromAxial(AxialPos pos, OffsetType type)
  {
    int q, r;
    switch (type)
    {
      case OffsetType.OddR:
        q = pos.Q + (pos.R - (pos.R & 1)) / 2;
        r = pos.R;
        return new OffsetPos(q, r, type);
      case OffsetType.EvenR:
        q = pos.Q + (pos.R + (pos.R & 1)) / 2;
        r = pos.R;
        return new OffsetPos(q, r, type);
      case OffsetType.OddQ:
        q = pos.Q;
        r = pos.R + (pos.Q - (pos.Q & 1)) / 2;
        return new OffsetPos(q, r, type);
      case OffsetType.EvenQ:
        q = pos.Q;
        r = pos.R + (pos.Q + (pos.Q & 1)) / 2;
        return new OffsetPos(q, r, type);
      default:
        return new OffsetPos();
    }
  }

  public static OffsetPos FromCube(CubePos pos, OffsetType type)
  {
    int q, r;
    switch (type)
    {
      case OffsetType.OddR:
        q = pos.Q + (pos.R - (pos.R & 1)) / 2;
        r = pos.R;
        return new OffsetPos(q, r, type);
      case OffsetType.EvenR:
        q = pos.Q + (pos.R + (pos.R & 1)) / 2;
        r = pos.R;
        return new OffsetPos(q, r, type);
      case OffsetType.OddQ:
        q = pos.Q;
        r = pos.R + (pos.Q - (pos.Q & 1)) / 2;
        return new OffsetPos(q, r, type);
      case OffsetType.EvenQ:
        q = pos.Q;
        r = pos.R + (pos.Q + (pos.Q & 1)) / 2;
        return new OffsetPos(q, r, type);
      default:
        return new OffsetPos();
    }
  }
}

public class CubePos
{
  public int Q { get; set; }
  public int R { get; set; }
  public int S { get; set; }

  public CubePos()
  {
    Q = 0;
    R = 0;
    S = 0;
  }

  public CubePos(int q, int r, int s)
  {
    Q = q;
    R = r;
    S = s;
  }

  public static CubePos FromAxial(AxialPos pos)
  {
    int q = pos.Q;
    int r = pos.R;
    int s = -q - r;
    return new CubePos(q, r, s);
  }

  public static CubePos FromOffset(OffsetPos pos)
  {
    int q, r;
    switch (pos.OffsetType)
    {
      case OffsetType.OddR:
        q = pos.Q - (pos.R - (pos.R & 1)) / 2;
        r = pos.R;
        return new CubePos(q, r, -q - r);
      case OffsetType.EvenR:
        q = pos.Q - (pos.R + (pos.R & 1)) / 2;
        r = pos.R;
        return new CubePos(q, r, -q - r);
      case OffsetType.OddQ:
        q = pos.Q;
        r = pos.R - (pos.Q - (pos.Q & 1)) / 2;
        return new CubePos(q, r, -q - r);
      case OffsetType.EvenQ:
        q = pos.Q;
        r = pos.R - (pos.Q + (pos.Q & 1)) / 2;
        return new CubePos(q, r, -q - r);
      default:
        return new CubePos();
    }
  }

  public static CubePos FromDouble(DoublePos pos)
  {

    int q = 0, r = 0;
    switch (pos.DoubleType)
    {
      case DoubleType.Height:
        q = pos.Q;
        r = (pos.R - pos.Q) / 2;
        break;
      case DoubleType.Width:
        q = (pos.Q - pos.R) / 2;
        r = pos.R;
        break;
    }
    return new CubePos(q, r, -q - r);
  }

  public static CubePos operator +(CubePos a, CubePos b)
  {
    return new CubePos(a.Q + b.Q, a.R + b.R, a.S + b.S);
  }

  public static CubePos operator -(CubePos a, CubePos b)
  {
    return new CubePos(a.Q - b.Q, a.R - b.R, a.S - b.S);
  }
}

public class AxialPos
{
  public int Q { get; set; }
  public int R { get; set; }

  public AxialPos()
  {
    Q = 0;
    R = 0;
  }

  public AxialPos(int q, int r)
  {
    Q = q;
    R = r;
  }

  public static AxialPos FromCube(CubePos pos)
  {
    int q = pos.Q;
    int r = pos.R;
    return new AxialPos(q, r);
  }

  public static AxialPos FromOffset(OffsetPos pos)
  {
    int q = 0, r = 0;
    switch (pos.OffsetType)
    {
      case OffsetType.OddR:
        q = pos.Q - (pos.R - (pos.R & 1)) / 2;
        r = pos.R;
        break;
      case OffsetType.EvenR:
        q = pos.Q - (pos.R + (pos.R & 1)) / 2;
        r = pos.R;
        break;
      case OffsetType.OddQ:
        q = pos.Q;
        r = pos.R - (pos.Q - (pos.Q & 1)) / 2;
        break;
      case OffsetType.EvenQ:
        q = pos.Q;
        r = pos.R - (pos.Q + (pos.Q & 1)) / 2;
        break;
    }
    return new AxialPos(q, r);
  }
  public static AxialPos FromDouble(DoublePos pos)
  {
    int q = 0, r = 0;
    switch (pos.DoubleType)
    {
      case DoubleType.Height:
        q = pos.Q;
        r = (pos.R - pos.Q) / 2;
        break;
      case DoubleType.Width:
        q = (pos.Q - pos.R) / 2;
        r = pos.R;
        break;
    }
    return new AxialPos(q, r);
  }

  public static AxialPos operator +(AxialPos pos1, AxialPos pos2)
  {
    return new AxialPos(pos1.Q + pos2.Q, pos1.R + pos2.R);
  }

  public static AxialPos operator -(AxialPos pos1, AxialPos pos2)
  {
    return new AxialPos(pos1.Q - pos2.Q, pos1.R - pos2.R);
  }
}

public enum DoubleType
{
  Height,
  Width
}

public class DoublePos
{
  public DoubleType DoubleType { get; set; }
  public int Q { get; set; }
  public int R { get; set; }

  public DoublePos()
  {
    DoubleType = DoubleType.Height;
    Q = 0;
    R = 0;
  }

  public DoublePos(int q, int r)
  {
    Q = q;
    R = r;
  }

  public DoublePos(int q, int r, DoubleType doubleType) : this(q, r)
  {
    DoubleType = doubleType;
  }

  public static DoublePos FromAxial(AxialPos pos, DoubleType type)
  {
    int q = 0, r = 0;
    switch (type)
    {
      case DoubleType.Height:
        q = pos.Q;
        r = (pos.R + pos.Q) * 2;
        break;
      case DoubleType.Width:
        q = (pos.Q + pos.R) * 2;
        r = pos.R;
        break;
    }
    return new DoublePos(q, r, type);
  }

  public static DoublePos FromCube(CubePos pos, DoubleType type)
  {
    int q = 0, r = 0;
    switch (type)
    {
      case DoubleType.Height:
        q = pos.Q;
        r = (pos.R - pos.Q) * 2;
        break;
      case DoubleType.Width:
        q = (pos.Q - pos.R) * 2;
        r = pos.R;
        break;
    }
    return new DoublePos(q, r, type);
  }

  public static DoublePos operator +(DoublePos a, DoublePos b){
    return new DoublePos(a.Q + b.Q, a.R + b.R);
  }

  public static DoublePos operator -(DoublePos a, DoublePos b){
    return new DoublePos(a.Q - b.Q, a.R - b.R);
  }
}
