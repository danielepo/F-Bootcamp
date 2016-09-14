F# Bootcamp
===

## What is F#?
A functional first language that emphasizes writing code that applies functions to data. also compatible with object oriented paradigm.

- It's as general purpose as C#.
- static type -> typechecking
- concise syntax
- small pices of functionalities that can be pieced toghether
- Significance of whitespace
 -  tabs forbidden
	
## What is functional programming?

è un paradigma che utilizza le funzioni come livello astrazione principale inviece degli oggetti

funzioni nel senso matematico

immutable
	
	
	
## How to install F#, Visual Studio Code, and the Ionide extension
fsharp.org

visualstudiocode

ionide
	
## Basics	
- defining a variable 
  - let it's immutable: can't assign
 - let mutable it's mutable:	can assign with <-		
 - collections are immutable:	the lists doesn't change
 - explain the signature
 - type inferace
- defining functions
 - anonimous functions
			
		
## Operators
- pipline instead of parentesis to better understand the flow of transformation
- data transformation
  -  Seq.map,Seq.filter, Seq.sort
- pattern matching
- parameter destructoring

## Functional
- partial application		
	
				f(x,y) -> x * (y + 1) 
				y = 10 => g(x) -> x * (10 + 1) 
			
- function composition ?

				f(x) -> (x + 1)^2
				k(x) -> x^2
				g(x) -> x * 1
				f(x) -> k(g(x)) -> (k >> g)(x)


				
## types	
 - Record types
	 - container for set of value-pair
	 - value equality

 - Discriminated unions
	 - like an enum on steroids
	 - every value can have data attached to it
	 - Option




