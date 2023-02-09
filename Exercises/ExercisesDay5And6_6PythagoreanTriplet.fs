namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay5And6_6PythagoreanTriplet =

    // A Pythagorean triplet is a set of three natural numbers, {a, b, c}, for
    // which,

    // ```text
    // a² + b² = c²
    // ```

    // and such that,

    // ```text
    // a < b < c
    // ```

    // For example,

    // ```text
    // 3² + 4² = 9 + 16 = 25 = 5².
    // ```

    // Given an input integer N, find all Pythagorean triplets for which `a + b + c = N`.

    // For example, with N = 1000, there is exactly one Pythagorean triplet for which `a + b + c = 1000`: `{200, 375, 425}`.

    let tripletsWithSum sum = __

    [<Ignore("Not implemented");Test>]
    let ``PythagoreanTriplet - Triplets whose sum is 12`` () =
        tripletsWithSum 12 |> AssertEquality [(3, 4, 5)]

    [<Ignore("Not implemented");Test>]
    let ``PythagoreanTriplet - Triplets whose sum is 108`` () =
        tripletsWithSum 108 |> AssertEquality [(27, 36, 45)]

    [<Ignore("Not implemented");Test>]
    let ``PythagoreanTriplet - Triplets whose sum is 1000`` () =
        tripletsWithSum 1000 |> AssertEquality [(200, 375, 425)]

    [<Ignore("Not implemented");Test>]
    let ``PythagoreanTriplet - No matching triplets for 1001`` () =
        tripletsWithSum 1001 |> AssertEquality []

    [<Ignore("Not implemented");Test>]
    let ``PythagoreanTriplet - Returns all matching triplets`` () =
        tripletsWithSum 90 |> AssertEquality [(9, 40, 41); (15, 36, 39)]

    [<Ignore("Not implemented");Test>]
    let ``PythagoreanTriplet - Several matching triplets`` () =
        tripletsWithSum 840 |> AssertEquality [(40, 399, 401); (56, 390, 394); (105, 360, 375); (120, 350, 370); (140, 336, 364); (168, 315, 357); (210, 280, 350); (240, 252, 348)]

    [<Ignore("Not implemented");Test>]
    let ``PythagoreanTriplet - Triplets for large number`` () =
        tripletsWithSum 30000 |> AssertEquality [(1200, 14375, 14425); (1875, 14000, 14125); (5000, 12000, 13000); (6000, 11250, 12750); (7500, 10000, 12500)]

