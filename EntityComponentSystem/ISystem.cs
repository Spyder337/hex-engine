using System;

namespace EntityComponentSystem;

public interface ISystem
{
  uint SystemId {get; protected set;}
  string SystemName {get; protected set;}
  /// <summary>
  /// Initialize any variables or extra state information for the system.
  /// </summary>
  void OnLoad();
  /// <summary>
  /// Initialize any variables necessary at the world start.
  /// </summary>
  void Start();
  /// <summary>
  /// The update function is called either every frame update or every physics 
  /// update.
  /// </summary>
  void Update();
}
