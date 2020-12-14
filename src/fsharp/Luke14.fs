module FSharp.Luke14

open System

let run =
    let isPrime num =
        match num with
        | num when num <= 1 -> false
        | num when num = 2 -> true
        | num when num % 2 = 0 -> false
        | num ->
            let limit =
                num |> float |> Math.Sqrt |> Math.Floor |> int

            seq { 3 .. 2 .. limit }
            |> Seq.exists (fun i -> num % i = 0)
            |> not

    seq { 2 .. 1800812 }
    |> Seq.fold (fun (n2, n1, primes, u: Set<int>) n ->
        let n =
            if n2 < n || u.Contains (n2 - n) then n + n2 else n2 - n

        let primes = if isPrime n then primes + 1 else primes

        let u = u |> Set.add n

        n1, n, primes, u) (0, 1, 0, Set.ofList [ 0; 1 ])
    |> (fun (_, _, primes, _) -> primes)
    |> printfn "%i"
