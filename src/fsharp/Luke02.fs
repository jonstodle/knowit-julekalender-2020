module FSharp.Luke02

open System
open System.IO

let run =
    let primes =
        File.ReadAllText "primes.txt"
        |> (fun s -> s.Split(' '))
        |> Seq.map (fun s -> s.Trim())
        |> Seq.filter (fun s -> String.IsNullOrWhiteSpace(s) = false)
        |> Seq.map int
        |> Seq.toList

    [ 0 .. 5_433_000 ]
    |> Seq.fold (fun pair curr ->
        match pair with
        | (skip, tally) when skip > 0 -> (skip - 1, tally)
        | (_, tally) when curr.ToString().Contains('7') -> (primes |> List.findBack (fun i -> i <= curr), tally)
        | (_, tally) -> (0, tally + 1)) (0, 0)
    |> (fun (_, tally) -> tally)
    |> printfn "%i"
    |> ignore
