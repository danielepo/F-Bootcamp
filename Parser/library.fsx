module Library 
#I __SOURCE_DIRECTORY__
#load "base.fsx"

open Parser

(** map **)

let parseThreeDigits = 
    parseDigit .>>. parseDigit .>>. parseDigit 

let mapP f parser =
    let innerFn input = 
        let result = run parser input
        match result with 
        | Success (value,remaining) -> 
            let value1 = f value
            Success (value1, remaining)
        | Failure message -> Failure message
    Parser innerFn

let ( <!> ) = mapP
let ( |>> ) x f = mapP f x


let parseThreeDigitsAsString = 
    (parseDigit .>>. parseDigit .>>. parseDigit)
    |>> (fun ((a, b), c) -> System.String [|a; b; c|])

let parseThreeDigitsAsInt = 
    mapP int parseThreeDigitsAsString     

let returnP x =
    let innerFn input =
        Success (x, input)
    Parser innerFn

let applyP fP xP = 
    // create a Parser containing a pair (f,x)
    (fP .>>. xP) 
    // map the pair by applying f to x
    |> mapP (fun (f,x) -> f x)

let ( <*> ) = applyP

let lift2 f xP yP =
    returnP f <*> xP <*> yP

let addP = lift2 (+)

let startsWith (str:string) prefix =
    str.StartsWith(prefix)  

let startsWithP =
    lift2 startsWith

let rec sequence parserList =
    // define the "cons" function, which is a two parameter function
    let cons head tail = head::tail

    // lift it to Parser World
    let consP = lift2 cons

    // process the list of parsers recursively
    match parserList with
    | [] ->  returnP []
    | head::tail -> consP head (sequence tail)

let parsers = [pchar 'A'; pchar 'B'; pchar 'C']
let combined = sequence parsers
run combined "AdCD" 
let charListToStr charList =
    System.String(List.toArray charList)
/// Match a specific string
let pstring (str:string)= 
    str
    |> List.ofSeq
    |> List.map pchar
    |> sequence
    |> mapP charListToStr

let parseABC = pstring "ABC"

run parseABC "ABCDE"  // Success ("ABC", "DE")
run parseABC "A|CDE"  // Failure "Expecting 'B'. Got '|'"
run parseABC "AB|DE"  // Failure "Expecting 'C'. Got '|'"