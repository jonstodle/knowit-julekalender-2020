module FSharp.Luke15

open System.IO

let run =
    let wordList =
        Path.Combine("Luke15", "wordlist.txt")
        |> File.ReadLines
        |> Seq.map (fun s -> s.Trim())
        |> Set.ofSeq
        
    let wordPairs =
        Path.Combine("Luke15", "riddles.txt")
        |> File.ReadLines
        |> Seq.map (fun l ->
            let split = l.Split ','
            split.[0].Trim(), split.[1].Trim())
        |> List.ofSeq
        
    wordList
    |> Seq.fold (fun (result: Set<string>) word ->
        (if result.Contains word
            then Seq.empty
            else
                wordPairs
                |> Seq.choose (fun (pre, post) ->
                    if wordList.Contains (pre + word) && wordList.Contains (word + post)
                    then (Some word)
                    else None))
        |> Seq.fold (fun set w -> set |> Set.add w) result) Set.empty
    |> Seq.sumBy (fun s -> s.Length)
    |> printfn "%i"
    
