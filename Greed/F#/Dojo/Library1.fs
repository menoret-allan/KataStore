module Greed

type DiceValue = int
type Score = int
type DiceScoring = DiceValue * Score * Score

let ScoreMultiplier y =
    (pown 2 (y - 3))

let rec ComputeDices (set:(DiceScoring * int) list) =
    match set with
    | [] -> 0
    | ((_, score, _), y)::rest when y >= 3 -> score * (ScoreMultiplier y) + ComputeDices rest
    | ((1, _, score), y)::rest | ((5, _, score), y)::rest -> score * y + ComputeDices rest
    | _::rest -> ComputeDices rest

let MapDiceToScore:int->DiceScoring = function
    | 1 -> (1, 1000, 100) | x -> (x, x*100, x*10)
    
let (|IsStraigt|IsOnlyPair|Else|) = function
    | (6, _) -> IsStraigt
    | (3, true) -> IsOnlyPair
    | _ -> Else

let Calculate dices =
    let pullDices = dices |> Seq.sort |> Seq.map (fun x -> x |> MapDiceToScore) |> Seq.countBy id
    (pullDices |> Seq.length, pullDices |> Seq.forall (fun (x, y) -> y = 2)) |> function
        | IsStraigt -> 1200
        | IsOnlyPair -> 800
        | Else -> pullDices |> Seq.toList |> ComputeDices

module Tests =
    open Xunit
    open FsUnit.Xunit

    type ``Given a list of dices should return the sum of one dices``() = 
        [<Fact>]let ``Given [1;1;1;5;5] should be 1100``() = Calculate [1;1;1;5;5] |> should equal 1100
        [<Fact>]let ``Given [2;3;4;6;2] should be 0   ``() = Calculate [2;3;4;6;2] |> should equal 0
        [<Fact>]let ``Given [3;4;5;3;3] should be 350 ``() = Calculate [3;4;5;3;3] |> should equal 350
        [<Fact>]let ``Given [1;5;1;2;4] should be 250 ``() = Calculate [1;5;1;2;4] |> should equal 250
        [<Fact>]let ``Given [5;5;5;1;4] should be 600 ``() = Calculate [5;5;5;1;4] |> should equal 600

        [<Fact>]let ``Given [5;5;5;1] should be 600 ``() = Calculate [5;7;7;7] |> should equal 750

        [<Fact>]let ``Given [2;2;2;2;4] should be 400 ``() = Calculate [2;2;2;2;4] |> should equal 400
        [<Fact>]let ``Given [2;2;2;2;2] should be 800 ``() = Calculate [2;2;2;2;2] |> should equal 800
        [<Fact>]let ``Given [5;5;5;5;5] should be 2000``() = Calculate [5;5;5;5;5] |> should equal 2000
        [<Fact>]let ``Given [1;1;1;5;1] should be 2050``() = Calculate [1;1;1;5;1] |> should equal 2050

        [<Fact>]let ``Given [2;2;2;2;2;2] should be 1600``() = Calculate [2;2;2;2;2;2] |> should equal 1600
        [<Fact>]let ``Given [1;1;1;1;1;1] should be 8000``() = Calculate [1;1;1;1;1;1] |> should equal 8000
        [<Fact>]let ``Given [1;2;3;4;5;6] should be 1200``() = Calculate [1;2;3;4;5;6] |> should equal 1200

        [<Fact>]let ``Given [2;2;6;4;4;6] should be 800``() = Calculate [2;2;6;4;4;6] |> should equal 800
        [<Fact>]let ``Given [3;5;3;1;5;1] should be 800``() = Calculate [3;5;3;1;5;1] |> should equal 800
