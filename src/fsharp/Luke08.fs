module FSharp.Luke08

open System
open System.IO
open System.Text.RegularExpressions

type Location =
    { name: string
      x: int
      y: int
      timePassed: double }

let parseLocation (line: string) =
    let matches = Regex.Matches(line, @"([-\w ']+)")

    { name = matches.[0].Value
      x = matches.[2].Value |> int
      y = matches.[3].Value |> int
      timePassed = 0. }

let calculateProgress (x: int, y: int, locations: Location seq) (newX, newY) =
    0,
    0,
    locations
    |> Seq.map (fun location ->
        let timePassed =
            match Math.Abs(newX - location.x)
                  + Math.Abs(newY - location.y) with
            | 0 -> 0.
            | n when n < 5 -> 0.25
            | n when n < 20 -> 0.5
            | n when n < 50 -> 0.75
            | _ -> 1.

        { location with
              timePassed = location.timePassed + timePassed })

let run =
    let lines =
        Path.Combine("Luke08", "input.txt")
        |> File.ReadAllLines

    let locations =
        lines
        |> Seq.take 50
        |> Seq.map parseLocation
        |> Seq.toList

    lines
    |> Seq.skip 50
    |> Seq.map (fun l ->
        let location = locations |> List.find (fun location -> location.name = l)
        location.x, location.y)
    |> Seq.append [ 0, 0 ]
    |> Seq.windowed 2
    |> Seq.collect (fun pair ->
        let (fromX, fromY) = pair.[0]
        let (toX, toY) = pair.[1]

        let xs =
            [ fromX .. toX ]
            |> Seq.scan (fun (x, y) newX -> newX, y) (fromX, fromY)

        let ys =
            [ fromY .. toY ]
            |> Seq.scan (fun (x, y) newY -> x, newY) (xs |> Seq.last |> (fun (x, _) -> x), fromY)

        Seq.append xs ys)
    |> Seq.fold calculateProgress (0, 0, locations |> List.toSeq)
    |> (fun (_, _, locations) ->
        let max =
            locations
            |> Seq.maxBy (fun l -> l.timePassed)

        let min =
            locations
            |> Seq.minBy (fun l -> l.timePassed)

        max.timePassed - min.timePassed)
    |> printfn "%f"
