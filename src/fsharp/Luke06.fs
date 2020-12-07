module FSharp.Luke06

open System
open System.IO

let run =
    let bags =
        Path.Combine("Luke06", "godteri.txt")
        |> File.ReadAllText
        |> (fun s -> s.Split(',', StringSplitOptions.TrimEntries))
        |> Array.map int
        
    let totalPieces = bags |> Array.sum
    
    bags
    |> Array.rev
    |> Array.fold (fun total bag -> if total % 127 = 0 then total else total - bag) totalPieces
    |> (fun i -> i / 127)
    |> printfn "%i"
