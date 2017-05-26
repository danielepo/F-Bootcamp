// fsi
1 + 1

"My name is Daniele"

(********************* Exercise 2 *********************)
(* type and execute (Alt+Enter) "Hello World", 54.3, 3 * 11
   then try something else *)
//...


(********************* defining values *********************)
let two = 2
let five = 3 + two
let myName = "Daniele Pozzobon"

let mutable variable  = 5
variable <- 6

(********************* Exercise 3 *********************)
(* Define a value and a value resulting from the multiplication of two values
   try changing it's value
   Turn the bingding mutable and try again
   Then try change it with a different type  *)
//...


(********************* Defining functions *********************)
let add (a:int) b : int = a + b
let addOne a = add 1 a
let multiplyByTwo a = 2 * a
let applyTen f = f 10
addOne 3
applyTen addOne

if true then 3 else 3

add 1

let curriedAdd a = fun b -> (+) a b

let addTen = add 10
let addTen2 = fun b -> (+) 10 b
let addTen3 b = (+) 10 b


(********************* Exercise 4 *********************)
(* Define
    - A function to multiply two numbers
    - Use it to make to multiply a number by a factor of ten
    - Compute the factorial of a number 
            9! = 9 * 8 * 7 * 6 * 5 * 4 * 3 * 2 * 1  
            *)
//..


(********************* Tuples  *********************)
let divide x y =
    match y with
    | 0 -> None
    | _ -> Some (x / y, x % y)
let otto = (8,"otto")

fst otto
snd otto 
let d, s = otto
#help
divide 1 5 
divide 144 12
divide 150 7
divide 150 0

(*********************  Records  *********************)
type RGBColor = {
     R : byte; 
     G : byte; 
     B : byte}
let red = { R = 255uy; G = 0uy; B = 0uy }
red.B
let yellow = { red with G = 255uy }
//let blue = { red && yellow with G = 255uy }

(********************* Discriminated Unions  *********************)

type Shape = 
    | Circle of float
    | Rectangle of float * float 
    | Triangle of float * float * float
Circle 3.3
let Rectangle (l,m) = Rectangle (2.1,4.2)
(********************* Exercise 5 *********************)
(*
  Define a function that given two ints returns the result of the 4 operations 
  (summation, substraction, multiplication, division) as a tuple
    let calculate a b = 
  Define a record type for the result of the above function and define a second function
  that returns the result as a record type instead
    type OperationResult = 
  Define the Number type that can be a float, an integer or nothing
    type Number = 
*)

let calculate a b = ()

type OperationResult = unit
let calculate2 a b:OperationResult = ()

type Nunmber = Union

(*********************  Pattern Matching  *********************)
let numberToString input =
  match input with
  | 0 -> "zero"
  | 1 -> "one"
  | 2 -> "two"
  | 3 -> "three"
let numberToString2 input =
  match input with
  | 0 -> "zero"
  | 1 -> "one"
  | 2 -> "two"
  | 3 -> "three"
  | _ -> "unknown"
let numberToString3 input =
  match input with
  | 0 -> "zero"
  | 1 -> "one"
  | 2 -> "two"
  | 3 -> "three"
  | n -> sprintf "%O" n

let dayOfWeek  =
    function
    | 1 -> "Monday"
    | 2 -> "Tuesday"
    | 3 -> "Wednesday"
    | 4 -> "Thursday"
    | 5 -> "Friday"
    | 6 -> "Saturday"
    | 7 -> "Sunday"
    | _ -> sprintf "  Not a day of week"

dayOfWeek 2

let getPerimeter shape =
  match shape with
  | Circle(r) -> 2.0 * System.Math.PI * r   
  | Rectangle(w, h) -> 2.0 * (w + h)
  | Triangle(l1, l2, l3) -> l1 + l2 + l3

let rectangle = Rectangle (3.0,4.0)
getPerimeter (rectangle)

Rectangle (3.0,4.0) |> getPerimeter

getPerimeter <| Circle 5.0


(*********************  Exercise 6 *********************)
(*Add Pentagon to the Shape discriminated union 
   change the getPerimeter function accordigly
  
  Write a getAreaFunction for the Shapes
    Area of the penthagon =  (5*Pow(s,2) / (4*sqrt(5-2*sqrt(5)))

*)
open System
let areaPentagon side = 5.0 * Math.Pow(side, 2.0) / (4.0 * Math.Sqrt(5.0 - 2.0 * Math.Sqrt(5.0)))

(*********************  Lists  *********************)

let emptyList = []

let listWithCons = 3 :: 23 :: 12 :: []
let initializzedList = [1; 2; 3; 5; 28; 12]
let sequentialList = [1..10]
let computedList = [ for a in 1 .. 10 do yield (a * a) ]
let anotherInitList = List.init 5 (fun index -> index * 3)

let append n = n :: initializzedList
append 3

seq {1..100}


(********************* Pipe  *********************)
addOne |> List.map

let forwardFunctionChains = 
  [1..10] 
  |> List.map addOne
  |> List.map multiplyByTwo 
  |> List.sum


let listanu = [1..10]
let standardFuctionCalls = List.sum(List.map multiplyByTwo (List.map addOne listanu))

let smarterForwardFunctionChains =
    [1..10] 
    |> List.map (addOne >> multiplyByTwo)
    |> List.sum
"Hello".[0]
Array.head ("hello".ToCharArray())
(********************* Exercise 6 *********************)

(*
  Given a list of names select all the names that start with the letter ‘A’ and prepend “Hello “ to it
    Example [“Elena”; “Amelia”] -> [“Hello Amelia”]

  Bonus points, make the letter a parameter of the function
*)

(fun (x:string) -> x.[0])
let names = [ "Yajaira";"Leah";"Vernie";"Tien";"Ja";"Bradly";"Terrilyn";"Anneliese";"Tennie";"Petrina";"Alison";"Teofila";
              "Jaunita";"Stacy";"Quincy";"Darlene";"Cindy";"Earl";"Shiloh";"Berenice";"Terrie";"Sanford";"Ciara";"Raylene"; 
              "Hilary";"Jesus";"Weston";"Maricruz";"Jolynn";"Elodia";"Fumiko";"Ricardo";"Emma";"Lena";"Heath";"Maryanne";
              "Raye";"Helen";"Morton";"Terrance";"Stefani";"Waylon";"Sabine";"Blanch";"Jaimie";"Paulene";"Sunny";"Frieda";"Oliver";"Bula"]

let greet () = ()

(* bonus *)
let getLength n =
  let rec len c l =
    match l with
    | [] -> c
    | _ :: t -> len (c + 1) t
  len 0 n

let rec invertiOgniDue l= 
    match l with 
        | e1 :: e2 :: ls -> (-e1) :: e2 :: (invertiOgniDue ls)
        | e1 :: ls -> (-e1) :: (invertiOgniDue ls)
        | [] -> []

[1..11] |> invertiOgniDue
