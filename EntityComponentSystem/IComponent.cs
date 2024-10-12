using System;

namespace EntityComponentSystem;

/// <summary>
/// A component without an accompanying data structure is called a tag.
/// </summary>
public interface IComponent
{
  /// <summary>
  /// Entity that the component is attached to.
  /// </summary>
  uint Entity { get; }
}

/// <summary>
/// Represents static entities in the world.
/// </summary>
public class StaticComponent : IComponent
{
  public uint Entity { get; protected set; }
  public StaticComponent(uint entity) {
    Entity = entity;
  }
}

public struct PlayerData {
  
}