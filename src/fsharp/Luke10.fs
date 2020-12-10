module FSharp.Luke10

open System.IO

let run =
    Path.Combine("Luke10", "leker.txt")
    |> File.ReadAllLines
    |> Seq.map (fun s -> s.Split(','))
    |> Seq.collect (fun positions ->
        positions
        |> Seq.mapi (fun pos elf -> elf, (positions.Length - (pos + 1))))
    |> Seq.fold (fun agg (elf, score) ->
        agg
        |> Map.change elf (fun value ->
               value
               |> Option.map (fun s -> s + score)
               |> Option.orElse (Some score))) Map.empty
    |> Map.toSeq
    |> Seq.sortByDescending (fun (_, score) -> score)
    |> Seq.head
    |> (fun (elf, score) -> printfn "%s-%i" elf score)
