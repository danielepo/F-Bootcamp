One of the most exiting features
The compiler can deduce the data type based on individal values and usage. It looks like a dynamically typed language but in fact is statically typed. In C# the type inferance works only with the var type for local instances, you still have to declare fields, properties, parameters and even method returns. In F# you can avoid all this, 

```csharp
// C#
using System;

public class Person
{
  public Person(Guid id, string name, int age)
  {
    Id = id;
    Name = name;
    Age = age;
  }

  public Guid Id { get; private set; }
  public string Name { get; private set; }
  public int Age { get; private set; }
}
```
6 type declarations and even if you would like to use readonly backing fields they would become 9.

```fsharp
type Person (id : System.Guid, name : string, age : int) =
  member x.Id = id
  member x.Name = name
  member x.Age = age
```