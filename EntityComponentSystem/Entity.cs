using System;

namespace EntityComponentSystem;

public class Entity
{
  public uint Id { get; private set; }

  public Entity(uint id) {
    Id = id;
  }
}
