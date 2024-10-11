# Hex Engine
## Why?
There are two reasons to create a custom game engine centered around hex-grids. One is to achieve better integration than can be achieved in Unity. The other is as a learning project in creating an ECS based game engine.

## Primary Source
This project will be made using a blog series from [Red Blob Games](https://www.redblobgames.com/). [This](https://www.redblobgames.com/grids/hexagons/) page covers the math behind generating a hexagon grid. [This](https://www.redblobgames.com/grids/hexagons/implementation.html) page covers the implementation details of the grid.

I also use the following references for making an ECS:
- [ecs-faq](https://github.com/SanderMertens/ecs-faq)
- [Entity Relationships](https://ajmmertens.medium.com/building-games-in-ecs-with-entity-relationships-657275ba2c6c)
- [Hexops blog](https://devlog.hexops.com/categories/build-an-ecs/)
- [David Colson's Blog](https://www.david-colson.com/2020/02/09/making-a-simple-ecs.html)

# Stages
## Stage 1: ECS 
### What is an ECS?
An **Entity Component System** is comprised of three parts:
1. Entities: Id or Index.
2. Components
    1. Tags: Empty Component
    2. Components are data.
3. Systems: Defines behaviour on sets of components.

#### C# Examples
```C#
//  Entity definition
public struct Entity{
    ulong Id { get; set; }
}

//  Component poses just data
public struct Vector3{
    double X {get; set;}
    double Y {get; set;}
    double Z {get; set;}
}

//  Component Tag definition
public struct PlayerTag{}
```

#### Sources
- [Unity GDC 2019](https://www.youtube.com/watch?v=0_Byw9UMn9g)

### ECS Storage
There are four ways to primarily implement an ECS:
#### Archetypes (aka "Dense ECS", "Table based ECS")
An **archetype ECS** stores entities in tables, where components are columns and entities are rows. Archetype implementations are fast to query and iterate.

Examples of archetype implementations:
- [Flecs](https://github.com/SanderMertens/flecs)
- [DOTS](https://unity.com/dots)
- [bevy](https://bevyengine.org/)
- [Arch](https://github.com/genaray/Arch)

> [!Note]
> This is helpful in cases where there are many components and entities being managed at once.
#### Sparse Set ECS (aka "Sparse ECS")
A sparse set based ECS stores each component in its own aprse set which has the entity id as key. Sparse set implementations allow for fast add/remove operations.

Example implementations:
- [EnTT](https://github.com/skypjack/entt)
- [Shipyard](https://github.com/leudz/shipyard)

> [!Note]
> This is helpful in cases where many entities are changing components or being instantiated and deleted.
#### Bitset based ECS
A bitset-based ECS stores components in arrays where the entity id is used as index, and uses a bitset to indicate if an entity has a specific component. Differentn flavors of bitset-based approaches exist. One approach is too have an array for each component with an accompanying bitset to indicate which entities have the component. Another approach uses the [hibiset](https://github.com/SanderMertens/ecs-faq?tab=readme-ov-file#hibitset) data structure.

Examples implementations:
- [EntityX](https://github.com/alecthomas/entityx)
- [Specs](https://github.com/amethyst/specs)
#### Reactive ECS
A reactive ECS uses signals resulting from entity mutations to keep track of which entities match systems/queries.

Example implementation:
- [Entitas](https://github.com/sschmid/Entitas-CSharp)

### Entity-Component Matching
There are three popular ways of implementing this:
1. **Archetype**: A query stores a list of matched tables, where a table can contain mainy entities. This approach has an advantage that as the tables stabilize quickly, query evaluation overhead is reduced to zero on average.

2. **Sparse Set**: A query iterates all entities in one of the queried for components (usually the one with the least entities) and tests for each subsequent component if thee entity has it. Bitset implementations are similar.

3. **Reactive**: A system collects entities that have the right set of components by listening for signals that could cause an entity to match.

## Stage 2: Grid Implementation
- [ ] Coordinates
- [ ] Layouts
- [ ] Fractional Hex
- [ ] Map
- [ ] Rotation
- [ ] Offset Coordinates

## Stage 3: Rendering

## Stage 4: Demo 