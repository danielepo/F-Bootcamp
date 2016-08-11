let rec fib n =
    match n with
    | 1 | 2 -> 1
    | _ -> (fib (n-1) )+(fib (n - 2)) 


printf "%d" (fsi.CommandLineArgs 
            |> Seq.last |> System.Int32.Parse |> fib)
