module FSharp.Luke11

open System.IO

let run =
    let transform (prev: string) (s: string) =
        s
        |> Seq.map int
        |> Seq.map (fun i -> if i = 122 then 97 else i + 1)
        |> Seq.zip (prev |> Seq.map int)
        |> Seq.map (fun (p, c) -> ((c - 97) + (p - 97)) % 26)
        |> Seq.map (fun i -> i + 97)
        |> Seq.map char

    Path.Combine("Luke11", "hint.txt")
    |> File.ReadAllLines
    |> Seq.filter (fun s -> s.Length >= 6)
    |> Seq.find (fun s ->
        let mutable transformations = [s]
        while transformations.Head.Length > 1 do
            let newTransformation = transformations.Head.Substring(1)
                                    |> transform transformations.Head
                                    |> Seq.toArray
                                    |> (fun chars -> new string(chars))
            transformations <- newTransformation::transformations
            
        [0 .. s.Length - 1]
        |> Seq.choose (fun i ->
            transformations
            |> Seq.choose (fun s -> s |> Seq.tryItem i)
            |> Seq.toArray
            |> (fun chars -> if chars.Length >= 6 then Some(new string(chars)) else None))
        |> Seq.exists (fun s -> s.Contains("aiqmae")))
    |> printfn "%s"
