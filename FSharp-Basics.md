## FSI
FSI is a REPL (read-evaluate-print loop) that lets you run parts of your code without running the entire application.
It has two main functions:
* runnig parts of scripts while developing
* running scripts to automate tasks like a scripting language

you can run the fsi in the console by typing `fsi` or you can use the integrated fsi in the Ionide plugin

The FSI is isolated and runs in its own context. 

### it
When you don’t explicitly name something (as when performing a simple calculation or checking the output of a function), FSI automatically binds the result to the it identifier. You can refer to it in subsequent evaluationsWhen you don’t explicitly name something (as when performing a simple calculation or checking the output of a function), FSI automatically binds the result to the it identifier. You can refer to it in subsequent evaluations

### Directives

* #help;;
  to lookup the directives
* #quit;;
  will quit the current session, you loose all job and values saved
* #load;;
  used to import code form other source files. You can use it by appending the path to the files you want to load
  `#load ".\framework.fs"`
* #r;;
  used to import assemblies. You can use it by appending the path to the files you want to load
  `#r "System.FSharp.Data.dll"`
  You can load assemblies by path or you can just call the assebly if the file is in one directory listed in the search directory
* #I;;
  To add a folder to the search path in order to avoid writing the full path for asseblies that are not already in the search path
  `#I @"C:\Temp`
* #time "on";;
  to enable the diplay of timing information and something more when the program prints to console

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

## Expressions everywhere

### Implicit return value