# Design Patterns Practice

| Completed | Incomplete |
|-----------|------------|
| ✅         | ❌          | 

### Creational patterns

\- provides object creation mechanisms that increase flexibility and reuse existing code.

| Design Pattern                                      | Practice completed? | Notes                                                                                                                       |
|-----------------------------------------------------|---------------------|-----------------------------------------------------------------------------------------------------------------------------|
| [Factory Method](/Creational/Factory%20Method/)     | ✅                   | Different factories produce different concrete implementations                                                              |
| [Abstract Factory](/Creational/Abstract%20Factory/) | ✅                   | Different factories produce different families of concrete implementations                                                  |
| Builder                                             | ❌                   | Instead of using many constructor parameters, a Builder will construct an object using many methods that modify the object. |
| [Prototype](/Creational/Prototype/)                 | ✅                   | Allows for deep cloning. Store clones as references for cloning.                                                            |
| [Singleton](/Creational/Singleton/)                 | ✅                   | Single global instance.                                                                                                     |

### Structural patterns

\- explains how to assemble objects and classes into larger structures, while keeping those structures flexible and efficient.

| Design Pattern                      | Practice completed? | Notes                                                                                                                                                        |
|-------------------------------------|---------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Adapter                             | ✅                   | Single wrapper to adapt data                                                                                                                                 |
| Bridge                              | ✅                   | Single abstraction to multiple implementations (ex. cross-platform)                                                                                          |
| [Composite](/Structural/Composite/) | ✅                   | Tree structure                                                                                                                                               |
| [Decorator](/Structural/Decorator)  | ✅                   | Multiple wrappers that are executed in stack                                                                                                                 |
| Facade                              | ❌                   | Single facade that exposes simple interface to perform complex operations on complex subsystems                                                              |
| Flyweight                           | ❌                   | Memory optimization technique where repeating data is accessed in a shared reference                                                                         |
| Proxy                               | ❌                   | Proxy object copies the interface of a real service, allowing Proxy to insert additional processing such as lazy init, logging, access control, caching etc. |

### Behavioral patterns

\- takes care of effective communication and the assignment of responsibilities between objects.

| Design Pattern                    | Practice completed? | Notes                                                                                                                                                                                                      |
|-----------------------------------|---------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Chain of Responsibility           | ❌                   | Chain of receivers that can execute arbitrary operations (ex. modify the chain) on a request .                                                                                                             |
| [Command](/Behavioral/Command/)   | ✅                   | Request object that performs an action on a Receiver. Commands can be queued, and used for undo-able operations.                                                                                           |
| Iterator                          | ❌                   | Provides simple interface for traversal logic of unique complex data structure.                                                                                                                            |
| Mediator                          | ❌                   | Mediator is called by components to interact with other components.                                                                                                                                        |
| Memento                           | ❌                   | Originator can save it's state into Mementos that are stored in a Caretaker. Important that Memento is mostly private to Caretaker.                                                                        |
| Observer                          | ❌                   | Dynamic runtime Pub/Sub.                                                                                                                                                                                   |
| [State](/Behavioral/State/)       | ✅                   | State machine as objects.                                                                                                                                                                                  |
| [Strategy](/Behavioral/Strategy/) | ✅                   | Runtime selection of a Strategy.                                                                                                                                                                           |
| Template Method                   | ❌                   | Single Template Method that performs a series of method steps. The method steps implementations are different between children, but the Template Method step order is the same.                            |
| Visitor                           | ❌                   | Visitor that can perform a process on unknown inherited components in a data structure. Can be implemented without modifying components (Open/Closed principle), using runtime type checking (reflection). |

## Sources

[Refactoring.Guru Design Patterns](https://refactoring.guru/design-patterns)