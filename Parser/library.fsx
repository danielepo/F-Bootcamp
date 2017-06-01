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

let rec parseZeroOrMore parser input =
    let result = run parser input
    
    match result with
    | Failure m -> ([], input)
    | Success (firstValue, firstRemaining) -> 
        let (subsequetValues, subsequentRemainig) = parseZeroOrMore parser firstRemaining
        (firstValue :: subsequetValues, subsequentRemainig)

let many parser =
    let innerFn input = Success (parseZeroOrMore parser input)
    Parser innerFn

run (many <| pstring "AB") "ABABdl"

let whitespaceChar = anyOf [' '; '\t'; '\n']
let whitespace = many whitespaceChar 
run whitespace "ABC"  // Success ([], "ABC")
run whitespace " ABC"  // Success ([' '], "ABC")
run whitespace "\tABC"  // Success (['\t'], "ABC")
run whitespace "\nABC"  // Success (['\t'], "ABC")

let many1 parser= 
    let innerFn input = 
        let result = run parser input

        match result with
        | Failure m -> Failure m
        | Success (firstValue,firstRemaining) -> 
            let (subsequentValues,subsequentRemainig) = parseZeroOrMore parser firstRemaining
            Success (firstValue::subsequentValues, subsequentRemainig)
    Parser innerFn

// define parser for one digit
let digit = anyOf ['0'..'9']

// define parser for one or more digits
let digits = many1 digit 


let pint = 
    let resultToInt result = 
        System.String(Array.ofList result) |> int
    let digit = anyOf ['0'..'9']
    let digits = many1 digit

    digits
    |> mapP resultToInt

run pint "1ABC"  // Success (['1'], "ABC")
run pint "12BC"  // Success (['1'; '2'], "BC")
run pint "123C"  // Success (['1'; '2'; '3'], "C")
run pint "1234"  // Success (['1'; '2'; '3'; '4'], "")
run pint "ABC"   // Failure "Expecting '9'. Got 'A'"

let opt p = 
    // map the result of a a parser to Some
    let some = p |>> Some
    // lift None
    let none = returnP None
    // if the combinator orelse to choose none if some fails
    some <|> none