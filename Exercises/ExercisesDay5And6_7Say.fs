namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay5And6_7Say =

    // Given a number from 0 to 999,999,999,999, spell out that number in English.

    // ## Step 1

    // Handle the basic case of 0 through 99.

    // If the input to the program is `22`, then the output should be
    // `'twenty-two'`.

    // Your program should complain loudly if given a number outside the
    // blessed range.

    // Some good test cases for this program are:

    // - 0
    // - 14
    // - 50
    // - 98
    // - -1
    // - 100

    // ### Extension

    // If you're on a Mac, shell out to Mac OS X's `say` program to talk out
    // loud. If you're on Linux or Windows, eSpeakNG may be available with the command `espeak`.

    // ## Step 2

    // Implement breaking a number up into chunks of thousands.

    // So `1234567890` should yield a list like 1, 234, 567, and 890, while the
    // far simpler `1000` should yield just 1 and 0.

    // The program must also report any values that are out of range.

    // ## Step 3

    // Now handle inserting the appropriate scale word between those chunks.

    // So `1234567890` should yield `'1 billion 234 million 567 thousand 890'`

    // The program must also report any values that are out of range.  It's
    // fine to stop at "trillion".

    // ## Step 4

    // Put it all together to get nothing but plain English.

    // `12345` should give `twelve thousand three hundred forty-five`.

    // The program must also report any values that are out of range.

    // ### Extensions

    // Use _and_ (correctly) when spelling out the number in English:

    // - 14 becomes "fourteen".
    // - 100 becomes "one hundred".
    // - 120 becomes "one hundred and twenty".
    // - 1002 becomes "one thousand and two".
    // - 1323 becomes "one thousand three hundred and twenty-three".

    let say number = __

    [<Ignore("Not implemented");Test>]
    let ``Say - Zero`` () =
        say 0L |> AssertEquality (Some "zero")

    [<Ignore("Not implemented");Test>]
    let ``Say - One`` () =
        say 1L |> AssertEquality (Some "one")

    [<Ignore("Not implemented");Test>]
    let ``Say - Fourteen`` () =
        say 14L |> AssertEquality (Some "fourteen")

    [<Ignore("Not implemented");Test>]
    let ``Say - Twenty`` () =
        say 20L |> AssertEquality (Some "twenty")

    [<Ignore("Not implemented");Test>]
    let ``Say - Twenty-two`` () =
        say 22L |> AssertEquality (Some "twenty-two")

    [<Ignore("Not implemented");Test>]
    let ``Say - Thirty`` () =
        say 30L |> AssertEquality (Some "thirty")

    [<Ignore("Not implemented");Test>]
    let ``Say - Ninety-nine`` () =
        say 99L |> AssertEquality (Some "ninety-nine")

    [<Ignore("Not implemented");Test>]
    let ``Say - One hundred`` () =
        say 100L |> AssertEquality (Some "one hundred")

    [<Ignore("Not implemented");Test>]
    let ``Say - One hundred twenty-three`` () =
        say 123L |> AssertEquality (Some "one hundred twenty-three")

    [<Ignore("Not implemented");Test>]
    let ``Say - Two hundred`` () =
        say 200L |> AssertEquality (Some "two hundred")

    [<Ignore("Not implemented");Test>]
    let ``Say - Nine hundred ninety-nine`` () =
        say 999L |> AssertEquality (Some "nine hundred ninety-nine")

    [<Ignore("Not implemented");Test>]
    let ``Say - One thousand`` () =
        say 1000L |> AssertEquality (Some "one thousand")

    [<Ignore("Not implemented");Test>]
    let ``Say - One thousand two hundred thirty-four`` () =
        say 1234L |> AssertEquality (Some "one thousand two hundred thirty-four")

    [<Ignore("Not implemented");Test>]
    let ``Say - One million`` () =
        say 1000000L |> AssertEquality (Some "one million")

    [<Ignore("Not implemented");Test>]
    let ``Say - One million two thousand three hundred forty-five`` () =
        say 1002345L |> AssertEquality (Some "one million two thousand three hundred forty-five")

    [<Ignore("Not implemented");Test>]
    let ``Say - One billion`` () =
        say 1000000000L |> AssertEquality (Some "one billion")

    [<Ignore("Not implemented");Test>]
    let ``Say - A big number`` () =
        say 987654321123L |> AssertEquality (Some "nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three")

    [<Ignore("Not implemented");Test>]
    let ``Say - Numbers below zero are out of range`` () =
        say -1L |> AssertEquality None

    [<Ignore("Not implemented");Test>]
    let ``Say - Numbers above 999,999,999,999 are out of range`` () =
        say 1000000000000L |> AssertEquality None