namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay5And6_8SpiralMatrix =

    // Given the size, return a square matrix of numbers in spiral order.

    // The matrix should be filled with natural numbers, starting from 1
    // in the top-left corner, increasing in an inward, clockwise spiral order,
    // like these examples:

    // ## Examples

    // ### Spiral matrix of size 3

    // ```text
    // 1 2 3
    // 8 9 4
    // 7 6 5
    // ```

    // ### Spiral matrix of size 4

    // ```text
    //  1  2  3 4
    // 12 13 14 5
    // 11 16 15 6
    // 10  9  8 7
    // ```

    let spiralMatrix size = __

    [<Ignore("Not implemented");Test>]
    let ``SpiralMatrix - Empty spiral`` () =
        spiralMatrix 0 |> AssertEquality []

    [<Ignore("Not implemented");Test>]
    let ``SpiralMatrix - Trivial spiral`` () =
        spiralMatrix 1 |> AssertEquality [[1]]

    [<Ignore("Not implemented");Test>]
    let ``SpiralMatrix - Spiral of size 2`` () =
        spiralMatrix 2 |> AssertEquality
            [ [1; 2];
            [4; 3] ]

    [<Ignore("Not implemented");Test>]
    let ``SpiralMatrix - Spiral of size 3`` () =
        spiralMatrix 3 |> AssertEquality
            [ [1; 2; 3];
            [8; 9; 4];
            [7; 6; 5] ]

    [<Ignore("Not implemented");Test>]
    let ``SpiralMatrix - Spiral of size 4`` () =
        spiralMatrix 4 |> AssertEquality
            [ [1; 2; 3; 4];
            [12; 13; 14; 5];
            [11; 16; 15; 6];
            [10; 9; 8; 7] ]

    [<Ignore("Not implemented");Test>]
    let ``SpiralMatrix - Spiral of size 5`` () =
        spiralMatrix 5 |> AssertEquality
            [ [1; 2; 3; 4; 5];
            [16; 17; 18; 19; 6];
            [15; 24; 25; 20; 7];
            [14; 23; 22; 21; 8];
            [13; 12; 11; 10; 9] ]