open System
open System.IO

let existsHorizontal (matrix: string list) (word: string) =
    matrix
    |> Seq.exists (fun line -> line.Contains word)
    |> (fun exists -> not exists)
    
let existsHorizontalR (matrix: string list) (word: string) =
    String.Join("", word.ToCharArray() |> Array.rev)
    |> existsHorizontal matrix

[<EntryPoint>]
let main argv =
    let matrix = File.ReadAllLines("matrix.txt") |> Array.toList
    
    File.ReadAllLines "wordlist.txt"
    |> Seq.filter (existsHorizontal matrix)
    |> (fun words -> String.Join(",", words))
    |> Console.WriteLine
    |> ignore
    
    0 // return an integer exit code
