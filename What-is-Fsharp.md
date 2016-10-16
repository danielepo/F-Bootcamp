A [[functional first language|functional programming]] that emphasizes writing code that applies functions to data. 
Why do we say it's functional first? 
That's because it it's also compatible with the object oriented paradigm but it's construct enfisises the use of the functional paradigm.

## Characteristics
- **It's as general purpose as C#**
  Any program that you can write in C# could be written in F#, the problem is that most of the tooling is meat to be used by C# developers so you could find it difficult write a Razor MVC View in F#.
- **Static Type**
  F# has a better type system than C# where you can express business concepts more easilly than in C#. For example you could declare FizzBuzz type that could either be an int, a Fizz, a Buzz or a FizzBuzz (this types are known as [[Discriminated Unions]])
  Another greate tool that the higher level type system gives us is the powerfull [[Type Inference]]
- **Concise Syntax**
  Thanks to the [[Type Inferance]] you don't have to write most of the types declaration you are asked to write in other languages and it feels like you are writting in a Dinamically Typed language.
```fsharp
  let rec fib =
     function 
     | 0 -> 0
     | 1 -> 1
     | n ->  fib (n - 1) + fib (n - 2)
```
- **Composibility**
  small pices of functionalities that can be pieced toghether
- **Significance of whitespace**
  You don't have to write parenthesis any more! you use tabs
  why is this better? because in C# you use parentesys to denote a block for the compiler *then* you use identation to denote the block for the programmer. With significance of whitespace you get both advantages with one construct.