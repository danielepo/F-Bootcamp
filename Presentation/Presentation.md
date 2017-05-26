<!-- $theme: gaia -->

# Fuctional Programming With F#
## What is functional programming
### What it's not
ever used C or C++, or even Assembly? 
- Assembly is an abstraction of the bare metal
  - you change directly the state of the memory cells
  - your whole program focuses on doing calculations changing state of some memory
- C, C++ and all its derivates are only abstractio of this
  - a pointer is an address of the memory
  - OO paradigm uses object that have state and some methods to modify it

### The world of Mathmathics
Remember the definition of a function?
- put definition here

asigning a value to x means that x represents that value in the word of possible values, you cant change the value of x, 
- for example the number two is a mathematical concept that can't change if you apply the number two to a funciton you obtain a result and that will always be the result of that function for that number

#### let's do some phisics:

the line function: 

  x = v.t

can be rearanged to find t as a funciton of space, we say t=f(x)

  t = x / v

the projectale funciton
  x = vx.t 				=> t = x/vx 	=> t = f(x)
  y = vy.t + (g*t^2)/2  => y = g(t) 	=> y = g(f(x)) = g°f(x)

you have **referential transparency**

why all this?
- all this just to sound smart!

this has two purposes:
- put you in the right mindset for what is comming
- now when we talk about functions you know what I mean
- it will be easier to not think about memory cells and instead thing about function applications


### So what is functional programming

it's a programming paradigm that, as mathematics, uses function application in order to express the relationship between the possible inputs (domain) and the possible outputs of a system.
let's see others definitions:
	quotes

#### Key elements 
key elements of a functional programming language are
- immutability by default 
  - you have values not variables
- Functions and functions application as main way to do calculations
- Every function has One input and One output
- Referential transparency

## F#

