namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay5And6_5MatchingBrackets =

    // Given a string containing brackets `[]`, braces `{}`, parentheses `()`,
    // or any combination thereof, verify that any and all pairs are matched
    // and nested correctly.

    let isPaired input = __

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Paired square brackets`` () =
        isPaired "[]" |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Empty string`` () =
        isPaired "" |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Unpaired brackets`` () =
        isPaired "[[" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Wrong ordered brackets`` () =
        isPaired "}{" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Wrong closing bracket`` () =
        isPaired "{]" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Paired with whitespace`` () =
        isPaired "{ }" |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Partially paired brackets`` () =
        isPaired "{[])" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Simple nested brackets`` () =
        isPaired "{[]}" |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Several paired brackets`` () =
        isPaired "{}[]" |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Paired and nested brackets`` () =
        isPaired "([{}({}[])])" |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Unopened closing brackets`` () =
        isPaired "{[)][]}" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Unpaired and nested brackets`` () =
        isPaired "([{])" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Paired and wrong nested brackets`` () =
        isPaired "[({]})" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Paired and wrong nested brackets but innermost are correct`` () =
        isPaired "[({}])" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Paired and incomplete brackets`` () =
        isPaired "{}[" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Too many closing brackets`` () =
        isPaired "[]]" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Early unexpected brackets`` () =
        isPaired ")()" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Early mismatched brackets`` () =
        isPaired "{)()" |> AssertEquality false

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Math expression`` () =
        isPaired "(((185 + 223.85) * 15) - 543)/2" |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``MatchingBrackets - Complex latex expression`` () =
        isPaired "\left(\begin{array}{cc} \frac{1}{3} & x\\ \mathrm{e}^{x} &... x^2 \end{array}\right)" |> AssertEquality true
