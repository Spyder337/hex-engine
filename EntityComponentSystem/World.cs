using System;

namespace EntityComponentSystem;

public class World
{
  /// <summary>
  /// Current list of all entities in the world.
  /// </summary>
  public static List<Entity> Entities
  {
    get; 
    protected set;
  } = new();
  /// <summary>
  /// Components stored by type and then organized by entity Id and the component
  /// value.
  /// </summary>
  public static Dictionary<IComponent, Dictionary<uint, IComponent>> Components
  {
    get;
    protected set;
  } = new();
  /// <summary>
  /// Systems stored by their name.
  /// </summary>
  public static Dictionary<string, ISystem> Systems {
    get;
    protected set;
  } = new();

  public World()
  {

  }

  public World(string worldFile)
  {

  }

  public void OnLoad()
  {

  }

  public void Start()
  {

  }

  public void Update()
  {

  }

  public void CreateSystem(ISystem system) {
    //  Add the system to the dictionary of registered systems.
  }

  public bool DestroySystem(string systemName) {
    //  Remove the system from the list of registered systems.
    return false;
  }

  public void RegisterComponent(uint entityId, IComponent component) {
    //  Add the component to the dictionary with the entityId.
  }

  public bool DestroyComponent(uint entityId, IComponent component) {
    return false;
  }

  public void CreateEntity(List<IComponent> components)
  {
    //  Increment the global entity counter to ensure unique Ids.
    //  Add the components to the world dictionary.
  }

  public bool DestroyEntity(uint entityId)
  {
    //  Iterate through the components and destroy the ones related to the
    //  entityId.
    return false;
  }
}
