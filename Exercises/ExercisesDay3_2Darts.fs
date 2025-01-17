namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay3_2Darts =

    // Write a function that returns the earned points in a single toss of a Darts game.

    // [Darts](https://en.wikipedia.org/wiki/Darts) is a game where players
    // throw darts at a [target](https://en.wikipedia.org/wiki/Darts#/media/File:Darts_in_a_dartboard.jpg).

    // In our particular instance of the game, the target rewards 4 different amounts of points, depending on where the dart lands:

    // * If the dart lands outside the target, player earns no points (0 points).
    // * If the dart lands in the outer circle of the target, player earns 1 point.
    // * If the dart lands in the middle circle of the target, player earns 5 points.
    // * If the dart lands in the inner circle of the target, player earns 10 points.

    // The outer circle has a radius of 10 units (this is equivalent to the total radius for the entire target), the middle circle a radius of 5 units, and the inner circle a radius of 1. Of course, they are all centered at the same point (that is, the circles are [concentric](http://mathworld.wolfram.com/ConcentricCircles.html)) defined by the coordinates (0, 0).

    // Write a function that given a point in the target (defined by its [Cartesian coordinates](https://www.mathsisfun.com/data/cartesian-coordinates.html) `x` and `y`, where `x` and `y` are [real](https://www.mathsisfun.com/numbers/real-numbers.html)), returns the correct amount earned by a dart landing at that point.

    let score (x: double) (y: double): int = 
        let distance = Math.Sqrt(x * x + y * y)
        if distance > 10.0 then 0
        elif distance > 5.0 then 1
        elif distance > 1.0 then 5
        else 10

    

    [<Test>]
    let ``Darts - Missed target`` () =
        score -9.0 9.0 |> AssertEquality 0

    [<Test>]
    let ``Darts - On the outer circle`` () =
        score 0.0 10.0 |> AssertEquality 1

    [<Test>]
    let ``Darts - On the middle circle`` () =
        score -5.0 0.0 |> AssertEquality 5

    [<Test>]
    let ``Darts - On the inner circle`` () =
        score 0.0 -1.0 |> AssertEquality 10

    [<Test>]
    let ``Darts - Exactly on centre`` () =
        score 0.0 0.0 |> AssertEquality 10

    [<Test>]
    let ``Darts - Near the centre`` () =
        score -0.1 -0.1 |> AssertEquality 10

    [<Test>]
    let ``Darts - Just within the inner circle`` () =
        score 0.7 0.7 |> AssertEquality 10

    [<Test>]
    let ``Darts - Just outside the inner circle`` () =
        score 0.8 -0.8 |> AssertEquality 5

    [<Test>]
    let ``Darts - Just within the middle circle`` () =
        score -3.5 3.5 |> AssertEquality 5

    [<Test>]
    let ``Darts - Just outside the middle circle`` () =
        score -3.6 -3.6 |> AssertEquality 1

    [<Test>]
    let ``Darts - Just within the outer circle`` () =
        score -7.0 7.0 |> AssertEquality 1

    [<Test>]
    let ``Darts - Just outside the outer circle`` () =
        score 7.1 -7.1 |> AssertEquality 0

    [<Test>]
    let ``Darts - Asymmetric position between the inner and middle circles`` () =
        score 0.5 -4.0 |> AssertEquality 5
