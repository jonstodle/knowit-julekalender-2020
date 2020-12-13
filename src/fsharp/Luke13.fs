module FSharp.Luke13

open System.IO

let run =
    Path.Combine("Luke13", "text.txt")
    |> File.ReadAllText
    |> Seq.fold (fun (letters, count) letter ->
        let newCount =
            count
            |> Map.change letter (fun value ->
                   value
                   |> Option.map (fun v -> v + 1)
                   |> Option.orElse (Some 1))

        (if newCount |> Map.find letter = (letter |> int) - 96
         then [letter] |> List.append letters
         else letters),
        newCount) (List.empty, Map.empty)
    |> (fun (letters, _) -> new string(letters |> List.toArray))
    |> printf "%s"
