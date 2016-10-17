* Boolean `bool` exposes `System.Boolean` and has two values `true` and `false`

 opetors are 

 * not
 * || 
 * &&

* Numeric types
* String 
 * String literal: enclosed with quotation marks "hello, world!"
 * Verbatim strings: preceded by @ to ignore escape sequeces @"domain\username"
 * triple-quoted strings: ignores escapes and double quotes for example for working with xml files
* Character

## [[Type Inference]]

## Nullability
* null almost never used
 * types definded allow null only if decorated with [<AllowNullLiteral>]
 * less checks for nulls or null pointer exceptions
 
What to do when somethong doesn't have a value?
* Option<'T> type:generic [[discriminated union]] with two values Some<'T> and None. 
The advantage is that's explicit.
Used also for optional parameters marked with the `?` sign


# Generics