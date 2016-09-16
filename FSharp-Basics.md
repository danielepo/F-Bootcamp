## FSI
FSI is a REPL () that lets you run parts of your code without running the entire application

### Exercise 
* Open your command line console and type fsi
* Type `#help;;`
* Do a sum operation
  `(+)` operator
* Do a print on the screen
  `printf`

## Defining a value
* `let` keyword is the most used keyword, it definds a binding between a value an its representation in the program
 * the definded binding is immutable in the sense that you cannot change the value that the simble is bound to. 
 * the immutability gives you some advantages, for example you are sure that a given value doesn't change after a function call exists
* `let mutable` is used in those cases when you need to change the state of a value
 * inside a for loop
 * working with objects from the .Net Framework like Credentials

## Defining functions
* `let` keyword to define a function. Why the same keyworkd? because funcions are values too!
  f(x) = 1 + x when x is 1 f(x) is 2 so f(x) is somewhat bound to the value x plus the value 1 for every x in the domain
  
### explain the signature
 - type inferace
- defining functions
 - anonimous functions

## Modules Vs Namespaces