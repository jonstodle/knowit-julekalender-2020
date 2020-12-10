module FSharp.Luke09

open System.IO

let run =
    let elves =
        Path.Combine("Luke09", "elves.txt")
        |> File.ReadAllLines
        |> Seq.map (fun line -> line.ToCharArray())
        |> Seq.toList
    
    let uninfected =
        elves
        |> Seq.mapi (fun row rowElves -> row, rowElves)
        |> Seq.collect (fun (row, rowElves) ->
            rowElves
            |> Seq.mapi (fun col elf -> if elf = 'F' then [row, col] else [])
            |> Seq.collect id)
        
    "Failed"
    |> printfn "%s"
