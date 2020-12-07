module FSharp.Luke07

open System.IO

let run =
    let trees =
        Path.Combine("Luke07", "forest.txt")
        |> File.ReadAllLines

    let mutable count = 0
    let mutable treeStart = 0
    for i in 0 .. ((trees |> Array.head).Length - 2) do
        count <- count + if ([ 0 .. trees.Length - 1 ] |> List.forall (fun j -> trees.[j].[i] = ' ' && trees.[j].[i + 1] = ' ')) &&
           (trees
            |> Array.map (fun line -> line.Substring(treeStart, i - treeStart))
            |> Array.forall (fun line -> line = new string(line.ToCharArray() |> Array.rev)))
           then
               treeStart <- i + 2
               1
           else 0
    
    count
    |> printfn "Not correct: %i"
