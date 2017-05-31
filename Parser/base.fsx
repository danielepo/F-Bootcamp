module Parser 

open System
    
type Result<'a> =
  | Success of 'a
  | Failure of string

type Parser<'T> = Parser of (string -> Result<'T * string>)
let pchar charToMatch =
    let innerFn str = 
      if String.IsNullOrEmpty(str) then
          let msg = "No more input"
          Failure msg
      else 
          let first = str.[0] 
          if first = charToMatch then
              let remaining = str.[1..]
              let msg = sprintf "Found %c" charToMatch
              Success (first,remaining)
          else
              let msg = sprintf "Expecting '%c'. Got '%c'" charToMatch first
              Failure msg
    Parser innerFn
let inputs = [('A',"");('A',"ABC");('B',"ABC")]

let parserA = pchar 'A'
let inputABC = "ABC"

let run parser input = 
  let (Parser innerFn) = parser
  innerFn input

run parserA "input"

let andThen parser1 parser2 =
    let innerFn input =
        // run parser1 with the input
        let result1 = run parser1 input
        
        // test the result for Failure/Success
        match result1 with
        | Failure err -> 
            // return error from parser1
            Failure err  

        | Success (value1,remaining1) -> 
            // run parser2 with the remaining input
            let result2 =  run parser2 remaining1
            
            // test the result for Failure/Success
            match result2 with 
            | Failure err ->
                // return error from parser2 
                Failure err 
            
            | Success (value2,remaining2) -> 
                // combine both values as a pair
                let newValue = (value1,value2)
                // return remaining input after parser2
                Success (newValue,remaining2)

    // return the inner function
    Parser innerFn 

let (.>>.) = andThen
let parserB = pchar 'B'
let parseAandThenB = parserA .>>. parserB


let orElse parser1 parser2 =
    let innerFn input =
        // run parser1 with the input
        let result1 = run parser1 input
        // test the result for Failure/Success
        match result1 with
        | Success (value1,remaining1) -> result1
        | Failure err -> 
            let result2 =  run parser2 input
            result2
            

    // return the inner function
    Parser innerFn 
let (<|>) = orElse

let parseAorB = parserA <|> parserB

["ABC";"BCE";"ZZD"] |> List.map (run parseAorB)

let parseC = pchar 'C'
let bOrElseC = parserB <|> parseC
let aAndThenBorC = parserA .>>. bOrElseC 

run aAndThenBorC "ABZ"  // Success (('A', 'B'), "Z")
run aAndThenBorC "ACZ"  // Success (('A', 'C'), "Z")
run aAndThenBorC "QBZ"  // Failure "Expecting 'A'. Got 'Q'"
run aAndThenBorC "AQZ"  // Failure "Expecting 'C'. Got 'Q'"

let choice listOfParsers =
  List.reduce (<|>) listOfParsers

let anyOf characterList =
  characterList |> List.map pchar |> choice

let parseLowercase = ['a' .. 'z'] |> anyOf
let parseDigit = ['0'..'9'] |> anyOf

run parseLowercase "aBC"  // Success ('a', "BC")
run parseLowercase "ABC"  // Failure "Expecting 'z'. Got 'A'"
run parseDigit "1ABC"  // Success ("1", "ABC")
run parseDigit "9ABC"  // Success ("9", "ABC")
run parseDigit "|ABC"  // Failure "Expecting '9'. Got '|'"
