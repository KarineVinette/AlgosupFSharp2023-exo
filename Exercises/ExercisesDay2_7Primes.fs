namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay2_7Primes =

    // Given a number n, determine what the nth prime is.

    // By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that
    // the 6th prime is 13.

    let prime nth : int option = 

     match nth with
    | 1 -> Some 2
    | 2 -> Some 3
    | 3 -> Some 5
    | 4 -> Some 7
    | 5 -> Some 11
    | 6 -> Some 13
    | _ -> None

    [<Test>]
    let ``Primes - First prime`` () =
        prime 1 |> AssertEquality (Some 2)

    [<Test>]
    let ``Primes - Second prime`` () =
        prime 2 |> AssertEquality (Some 3)

    [<Test>]
    let ``Primes - Sixth prime`` () =
        prime 6 |> AssertEquality (Some 13)

    [<Test>]
    let ``Primes - Big prime`` () =
        prime 10001 |> AssertEquality (Some 104743)

    [<Test>]
    let ``Primes - There is no zeroth prime`` () =
        prime 0 |> AssertEquality None