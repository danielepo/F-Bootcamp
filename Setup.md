fsharp.org

visualstudiocode

ionide
	
## [[F# Basics]]
- defining a variable 
  - let it's immutable: can't assign
 - let mutable it's mutable:	can assign with <-		
 - collections are immutable:	the lists doesn't change
 - explain the signature
 - type inferace
- defining functions
 - anonimous functions
			
		
## [[Operators]]
- pipline instead of parentesis to better understand the flow of transformation
- data transformation
  -  Seq.map,Seq.filter, Seq.sort
- pattern matching
- parameter destructoring

## [[Functional Concepts]]
- partial application		
	
				f(x,y) -> x * (y + 1) 
				y = 10 => g(x) -> x * (10 + 1) 
			
- function composition ?

				f(x) -> (x + 1)^2
				k(x) -> x^2
				g(x) -> x * 1
				f(x) -> k(g(x)) -> (k >> g)(x)


				
## [[Working With Types]]
 - Record types
	 - container for set of value-pair
	 - value equality

 - Discriminated unions
	 - like an enum on steroids
	 - every value can have data attached to it
	 - Option