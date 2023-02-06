namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay5And6_9Forth =

    // Implement an evaluator for a very simple subset of Forth.

    // [Forth](https://en.wikipedia.org/wiki/Forth_%28programming_language%29)
    // is a stack-based programming language. Implement a very basic evaluator
    // for a small subset of Forth.

    // Your evaluator has to support the following words:

    // - `+`, `-`, `*`, `/` (integer arithmetic)
    // - `DUP`, `DROP`, `SWAP`, `OVER` (stack manipulation)

    // Your evaluator also has to support defining new words using the
    // customary syntax: `: word-name definition ;`.

    // To keep things simple the only data type you need to support is signed
    // integers of at least 16 bits size.

    // You should use the following rules for the syntax: a number is a
    // sequence of one or more (ASCII) digits, a word is a sequence of one or
    // more letters, digits, symbols or punctuation that is not a number.
    // (Forth probably uses slightly different rules, but this is close
    // enough.)

    // Words are case-insensitive.

    let evaluate input = __

    [<Ignore("Not implemented");Test>]
    let ``Forth - Parsing and numbers - numbers just get pushed onto the stack`` () =
        let expected = Some [1; 2; 3; 4; 5]
        evaluate ["1 2 3 4 5"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Parsing and numbers - pushes negative numbers onto the stack`` () =
        let expected = Some [-1; -2; -3; -4; -5]
        evaluate ["-1 -2 -3 -4 -5"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Addition - can add two numbers`` () =
        let expected = Some [3]
        evaluate ["1 2 +"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Addition - errors if there is nothing on the stack`` () =
        let expected = None
        evaluate ["+"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Addition - errors if there is only one value on the stack`` () =
        let expected = None
        evaluate ["1 +"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Subtraction - can subtract two numbers`` () =
        let expected = Some [-1]
        evaluate ["3 4 -"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Subtraction - errors if there is nothing on the stack`` () =
        let expected = None
        evaluate ["-"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Subtraction - errors if there is only one value on the stack`` () =
        let expected = None
        evaluate ["1 -"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Multiplication - can multiply two numbers`` () =
        let expected = Some [8]
        evaluate ["2 4 *"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Multiplication - errors if there is nothing on the stack`` () =
        let expected = None
        evaluate ["*"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Multiplication - errors if there is only one value on the stack`` () =
        let expected = None
        evaluate ["1 *"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Division - can divide two numbers`` () =
        let expected = Some [4]
        evaluate ["12 3 /"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Division - performs integer division`` () =
        let expected = Some [2]
        evaluate ["8 3 /"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Division - errors if dividing by zero`` () =
        let expected = None
        evaluate ["4 0 /"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Division - errors if there is nothing on the stack`` () =
        let expected = None
        evaluate ["/"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Division - errors if there is only one value on the stack`` () =
        let expected = None
        evaluate ["1 /"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Combined arithmetic - addition and subtraction`` () =
        let expected = Some [-1]
        evaluate ["1 2 + 4 -"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Combined arithmetic - multiplication and division`` () =
        let expected = Some [2]
        evaluate ["2 4 * 3 /"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Dup - copies a value on the stack`` () =
        let expected = Some [1; 1]
        evaluate ["1 dup"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Dup - copies the top value on the stack`` () =
        let expected = Some [1; 2; 2]
        evaluate ["1 2 dup"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Dup - errors if there is nothing on the stack`` () =
        let expected = None
        evaluate ["dup"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Drop - removes the top value on the stack if it is the only one`` () =
        let expected: int list option = Some []
        evaluate ["1 drop"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Drop - removes the top value on the stack if it is not the only one`` () =
        let expected = Some [1]
        evaluate ["1 2 drop"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Drop - errors if there is nothing on the stack`` () =
        let expected = None
        evaluate ["drop"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Swap - swaps the top two values on the stack if they are the only ones`` () =
        let expected = Some [2; 1]
        evaluate ["1 2 swap"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Swap - swaps the top two values on the stack if they are not the only ones`` () =
        let expected = Some [1; 3; 2]
        evaluate ["1 2 3 swap"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Swap - errors if there is nothing on the stack`` () =
        let expected = None
        evaluate ["swap"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Swap - errors if there is only one value on the stack`` () =
        let expected = None
        evaluate ["1 swap"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Over - copies the second element if there are only two`` () =
        let expected = Some [1; 2; 1]
        evaluate ["1 2 over"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Over - copies the second element if there are more than two`` () =
        let expected = Some [1; 2; 3; 2]
        evaluate ["1 2 3 over"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Over - errors if there is nothing on the stack`` () =
        let expected = None
        evaluate ["over"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Over - errors if there is only one value on the stack`` () =
        let expected = None
        evaluate ["1 over"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - User-defined words - can consist of built-in words`` () =
        let expected = Some [1; 1; 1]
        evaluate [": dup-twice dup dup ;"; "1 dup-twice"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - User-defined words - execute in the right order`` () =
        let expected = Some [1; 2; 3]
        evaluate [": countup 1 2 3 ;"; "countup"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - User-defined words - can override other user-defined words`` () =
        let expected = Some [1; 1; 1]
        evaluate [": foo dup ;"; ": foo dup dup ;"; "1 foo"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - User-defined words - can override built-in words`` () =
        let expected = Some [1; 1]
        evaluate [": swap dup ;"; "1 swap"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - User-defined words - can override built-in operators`` () =
        let expected = Some [12]
        evaluate [": + * ;"; "3 4 +"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - User-defined words - can use different words with the same name`` () =
        let expected = Some [5; 6]
        evaluate [": foo 5 ;"; ": bar foo ;"; ": foo 6 ;"; "bar foo"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - User-defined words - can define word that uses word with the same name`` () =
        let expected = Some [11]
        evaluate [": foo 10 ;"; ": foo foo 1 + ;"; "foo"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - User-defined words - cannot redefine non-negative numbers`` () =
        let expected = None
        evaluate [": 1 2 ;"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - User-defined words - cannot redefine negative numbers`` () =
        let expected = None
        evaluate [": -1 2 ;"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - User-defined words - errors if executing a non-existent word`` () =
        let expected = None
        evaluate ["foo"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - User-defined words - only defines locally`` () =
        evaluate [": + - ;"; "1 1 +"] |> AssertEquality (Some [0])
        evaluate ["1 1 +"] |> AssertEquality (Some [2])

    [<Ignore("Not implemented");Test>]
    let ``Forth - Case-insensitivity - DUP is case-insensitive`` () =
        let expected = Some [1; 1; 1; 1]
        evaluate ["1 DUP Dup dup"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Case-insensitivity - DROP is case-insensitive`` () =
        let expected = Some [1]
        evaluate ["1 2 3 4 DROP Drop drop"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Case-insensitivity - SWAP is case-insensitive`` () =
        let expected = Some [2; 3; 4; 1]
        evaluate ["1 2 SWAP 3 Swap 4 swap"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Case-insensitivity - OVER is case-insensitive`` () =
        let expected = Some [1; 2; 1; 2; 1]
        evaluate ["1 2 OVER Over over"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Case-insensitivity - user-defined words are case-insensitive`` () =
        let expected = Some [1; 1; 1; 1]
        evaluate [": foo dup ;"; "1 FOO Foo foo"] |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``Forth - Case-insensitivity - definitions are case-insensitive`` () =
        let expected = Some [1; 1; 1; 1]
        evaluate [": SWAP DUP Dup dup ;"; "1 swap"] |> AssertEquality expected

