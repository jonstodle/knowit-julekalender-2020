module FSharp.Luke05

open System.IO

let run =
    File.ReadAllText(Path.Combine("Luke05", "rute.txt")).ToCharArray()
    |> (fun moves -> moves |> Seq.append [moves |> Seq.head])
    |> Seq.map (fun move ->
        match move with
        | 'H' -> (1, 0)
        | 'V' -> (-1, 0)
        | 'O' -> (0, 1)
        | 'N' -> (0, -1))
    |> Seq.fold (fun (prevX, prevY, total) (deltaX, deltaY) ->
        let newX = prevX + deltaX
        let newY = prevY + deltaY
        (newX, newY, total + (prevX * newY - prevY * newX))) (1, 1, 0)
    |> (fun (_, _, total) -> total / 2)
    |> printfn "%i"
    
