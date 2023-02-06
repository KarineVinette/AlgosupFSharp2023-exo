namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay5And6_10GoCounting =

    // Count the scored points on a Go board.

    // In the game of go (also known as baduk, igo, cờ vây and wéiqí) points
    // are gained by completely encircling empty intersections with your
    // stones. The encircled intersections of a player are known as its
    // territory.

    // Write a function that determines the territory of each player. You may
    // assume that any stones that have been stranded in enemy territory have
    // already been taken off the board.

    // Write a function that determines the territory which includes a specified coordinate.

    // Multiple empty intersections may be encircled at once and for encircling
    // only horizontal and vertical neighbors count. In the following diagram
    // the stones which matter are marked "O" and the stones that don't are
    // marked "I" (ignored).  Empty spaces represent empty intersections.

    // ```text
    // +----+
    // |IOOI|
    // |O  O|
    // |O OI|
    // |IOI |
    // +----+
    // ```

    // To be more precise an empty intersection is part of a player's territory
    // if all of its neighbors are either stones of that player or empty
    // intersections that are part of that player's territory.

    // For more information see
    // [wikipedia](https://en.wikipedia.org/wiki/Go_%28game%29) or [Sensei's
    // Library](http://senseis.xmp.net/).

    type Owner = None | Black | White
    type Coord = int * int
    type Board = Owner [,]

    let territory _ = __

    let territories _ = __

    [<Ignore("Not implemented");Test>]
    let ``GoCounting - Black corner territory on 5x5 board`` () =
        let board =
            [ "  B  ";
            " B B ";
            "B W B";
            " W W ";
            "  W  " ]
        let position = (0, 1)
        let expected = Option.Some (Owner.Black, [(0, 0); (0, 1); (1, 0)])
        territory board position |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``GoCounting - White center territory on 5x5 board`` () =
        let board =
            [ "  B  ";
            " B B ";
            "B W B";
            " W W ";
            "  W  " ]
        let position = (2, 3)
        let expected = Option.Some (Owner.White, [(2, 3)])
        territory board position |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``GoCounting - Open corner territory on 5x5 board`` () =
        let board =
            [ "  B  ";
            " B B ";
            "B W B";
            " W W ";
            "  W  " ]
        let position = (1, 4)
        let expected = Option.Some (Owner.None, [(0, 3); (0, 4); (1, 4)])
        territory board position |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``GoCounting - A stone and not a territory on 5x5 board`` () =
        let board =
            [ "  B  ";
            " B B ";
            "B W B";
            " W W ";
            "  W  " ]
        let position = (1, 1)
        let expected: (Owner * (int * int) list) option = Option.Some (Owner.None, [])
        territory board position |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``GoCounting - Invalid because X is too low for 5x5 board`` () =
        let board =
            [ "  B  ";
            " B B ";
            "B W B";
            " W W ";
            "  W  " ]
        let position = (-1, 1)
        let expected = Option.None
        territory board position |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``GoCounting - Invalid because X is too high for 5x5 board`` () =
        let board =
            [ "  B  ";
            " B B ";
            "B W B";
            " W W ";
            "  W  " ]
        let position = (5, 1)
        let expected = Option.None
        territory board position |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``GoCounting - Invalid because Y is too low for 5x5 board`` () =
        let board =
            [ "  B  ";
            " B B ";
            "B W B";
            " W W ";
            "  W  " ]
        let position = (1, -1)
        let expected = Option.None
        territory board position |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``GoCounting - Invalid because Y is too high for 5x5 board`` () =
        let board =
            [ "  B  ";
            " B B ";
            "B W B";
            " W W ";
            "  W  " ]
        let position = (1, 5)
        let expected = Option.None
        territory board position |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``GoCounting - One territory is the whole board`` () =
        let board = [" "]
        let expected =
            [ (Owner.Black, []);
            (Owner.White, []);
            (Owner.None, [(0, 0)]) ]
            |> Map.ofList
        territories board |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``GoCounting - Two territory rectangular board`` () =
        let board =
            [ " BW ";
            " BW " ]
        let expected =
            [ (Owner.Black, [(0, 0); (0, 1)]);
            (Owner.White, [(3, 0); (3, 1)]);
            (Owner.None, []) ]
            |> Map.ofList
        territories board |> AssertEquality expected

    [<Ignore("Not implemented");Test>]
    let ``GoCounting - Two region rectangular board`` () =
        let board = [" B "]
        let expected =
            [ (Owner.Black, [(0, 0); (2, 0)]);
            (Owner.White, []);
            (Owner.None, []) ]
            |> Map.ofList
        territories board |> AssertEquality expected

