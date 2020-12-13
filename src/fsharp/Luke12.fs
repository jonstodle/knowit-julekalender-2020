module FSharp.Luke12

open System
open System.IO

let run =
    Path.Combine("Luke12", "family.txt")
    |> File.ReadAllText
    |> Seq.fold (fun (gen, count) c ->
        match c with
        | '(' -> gen + 1, count
        | ')' -> gen - 1, count
        | other when Char.IsUpper other -> gen, count |> Map.change gen (fun value -> value |> Option.map (fun g -> g + 1) |> Option.orElse (Some 1))
        | _ -> gen, count) (0, Map.empty)
    |> (fun (_, count) -> count |> Seq.maxBy (fun pair -> pair.Value) |> (fun pair -> pair.Value))
    |> printfn "%i"
