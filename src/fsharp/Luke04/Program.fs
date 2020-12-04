open System
open System.IO

type Delivery = {
    Sugar: int
    Flour: int
    Milk: int
    Eggs: int
}

let sufficientQuantities delivery =
    delivery.Sugar >= 2 && delivery.Flour >= 3 && delivery.Milk >= 3 && delivery.Eggs >= 1

[<EntryPoint>]
let main argv =
    File.ReadAllLines "leveringsliste.txt"
    |> Array.toList
    |> List.collect (fun line -> line.Split(',') |> Array.toList)
    |> List.map (fun pair -> pair.Split(':')
                             |> Array.toList
                             |> List.map (fun s -> s.Trim(' ', ',')))
    |> List.fold (fun total pair ->
                  match pair with
                  | i::q::_ when i = "sukker" -> {total with Sugar = total.Sugar + int q}
                  | i::q::_ when i = "mel" -> {total with Flour = total.Flour + int q}
                  | i::q::_ when i = "melk" -> {total with Milk = total.Milk + int q}
                  | i::q::_ when i = "egg" -> {total with Eggs = total.Eggs + int q}
                  | _ -> total) { Sugar = 0; Flour = 0; Milk = 0; Eggs = 0 }
    |> List.unfold (fun total -> if sufficientQuantities total
                                 then Some(1, { Sugar = total.Sugar - 2; Flour = total.Flour - 3; Milk = total.Milk - 3; Eggs = total.Eggs - 1 })
                                 else None)
    |> List.sum
    |> printfn "%i"
    
    0 // return an integer exit code
