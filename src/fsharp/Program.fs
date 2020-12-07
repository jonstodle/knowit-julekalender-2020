﻿open FSharp

[<EntryPoint>]
let main argv =
    match argv |> Array.toList with
    | head::_ when head = "1" -> Luke01.run
    | head::_ when head = "2" -> Luke02.run
    | head::_ when head = "3" -> Luke03.run
    | head::_ when head = "4" -> Luke04.run
    | head::_ when head = "5" -> Luke05.run
    | head::_ when head = "6" -> Luke06.run
    | _ -> failwith "Requires exactly one (1) argument. The argument must be a number between 1 and 24"
    
    0 // return an integer exit code