module FSharp.Luke01

open System
open System.IO

let run =
    let nums =
        File.ReadAllText("numbers.txt").Split(',')
        |> Array.toList
        |> List.map (fun s -> s.Trim())
        |> List.map int
        
    [1..100000]
    |> Seq.except nums
    |> Seq.head
    |> printfn "%i"
    |> ignore
