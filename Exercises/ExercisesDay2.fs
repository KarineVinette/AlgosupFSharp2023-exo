namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

module ExercisesUnit3 =

    [<Test>]
    let LetInfersTheTypesOfValuesWherePossible() =
        let x = 50
        let typeOfX = x.GetType()

        let y = "a string"
        let typeOfY = y.GetType()

        AssertEquality typeOfX typeof<int>
        AssertEquality typeOfY typeof<string>

    [<Test>]
    let YouCanMakeTypesExplicit() =
        // the only difference from the previous test is the type annotations
        // which can sometimes be useful
        let (x:int) = 42
        let typeOfX = x.GetType()

        let y:string = "forty two"
        let typeOfY = y.GetType()

        AssertEquality typeOfX typeof<int>
        AssertEquality typeOfY typeof<string>

    [<Test>]
    let FloatsAndInts() =
        let x = 20
        let typeOfX = x.GetType()

        let y = 20.0
        let typeOfY = y.GetType()

        AssertEquality typeOfX typeof<int>
        AssertEquality typeOfY typeof<float>

    type MyTypeAlias = int

    [<Test>]
    let TypeAliasInAction() =
        let t = typeof<MyTypeAlias>

        //you don't need to modify these
        AssertEquality t typeof<int>

    [<Test>]
    let CreatingTuples() =
        let actualValue = ("one", 2)

        AssertEquality ("one", 2) actualValue

    [<Test>]
    let CreatingTuplesMoreTuples() =
        let actualValue = ("one", 2, 3., 4)

        AssertEquality ("one", 2, 3., 4) actualValue

    [<Test>]
    let AccessingTupleElements() =
        let items = ("apple", "dog")

        // fst and snd are definited in the F# standard library, can you guess what they mean?

        let fruit = fst items
        let animal = snd items

        AssertEquality fruit "apple"
        AssertEquality animal "dog"

    [<Test>]
    let AccessingTupleElementsWithPatternMatching() =

        let items = ("apple", "dog", "Mustang")

        let fruit, animal, car = items

        AssertEquality fruit "apple"
        AssertEquality animal "dog"
        AssertEquality car "Mustang"


    [<Test>]
    let ReturningMultipleValuesFromAFunction() =
        let squareAndCube x =
            (x ** 2.0, x ** 3.0)

        let squared, cubed = squareAndCube 3.0


        AssertEquality squared 9.0
        AssertEquality cubed 27.0

    [<Test>]
    let SwappingTuples() =
        let swap (a,b) = (b,a)

        AssertEquality ('b', 'a') (swap ('a', 'b'))
        AssertEquality (2, 1) (swap (1, 2))
        AssertEquality (2., 1.) (swap (1., 2.))
        AssertEquality ("two", "one") (swap ("one", "two"))

    [<Test>]
    let PrettyPrintingTuples() =
        let input = (6,"seven",8)

        let actualValue = "(6, seven, 8)"

        AssertEquality "(6, seven, 8)" actualValue

    type Person =
        { FirstName: string;
          LastName: string; }

    [<Test>]
    let AccessingMembers() =
        let input =
            { FirstName = "Robert";
              LastName = "Pickering" }

        let actualValue1 = input.LastName
        let actualValue2 = input.FirstName

        AssertEquality "Pickering" actualValue1
        AssertEquality "Robert" actualValue2

    [<Test>]
    let UpdatingRecords() =
        let input =
            { FirstName = "Robert";
              LastName = "Pickering" }

        let actualValue1 = { input with FirstName = "Fred" }
        let actualValue2 = { input with FirstName = "Fran" }
        let actualValue3 = { input with LastName = "Zimmerman" }

        AssertEquality { FirstName = "Fred"; LastName = "Pickering" } actualValue1
        AssertEquality { FirstName = "Fran"; LastName = "Pickering" } actualValue2
        AssertEquality { FirstName = "Robert"; LastName = "Zimmerman" } actualValue3

    [<Test>]
    let SomeSimplePatternMatching() =

        let numberConverter x =
            match x with
            // add other cases here!
            | 1 -> "the first number"
            | 7 -> "lucky"
            | 13 -> "baker's dozen"
            

        AssertEquality "the first number" (numberConverter 1)
        AssertEquality "lucky" (numberConverter 7)
        AssertEquality "baker's dozen" (numberConverter 13)

    type Condiment =
        | Mustard
        | Ketchup
        | Relish
        | Vinegar

    [<Test>]
    let DiscriminatedUnionsCaptureASetOfOptions() =

        let toColor condiment =
            match condiment with
            | Mustard -> "yellow"
            | Ketchup -> "red"
            | Relish -> "green"
            | Vinegar -> "brownish?"

        let choice = Mustard

        AssertEquality (toColor choice) "yellow"

    [<Test>]
    let OptionTypesMightContainAValue() =
        let someValue = Some 10

        AssertEquality someValue.IsSome true
        AssertEquality someValue.IsNone false
        AssertEquality someValue.Value 10

    [<Test>]
    let OrTheyMightNot() =
        let noValue = None

        AssertEquality noValue.IsSome false
        AssertEquality noValue.IsNone true
        AssertThrows<FILL_IN_THE_EXCEPTION> (fun () -> noValue.Value)

    type Game =
        { Name: string
          Platform: string
          Score: int option }

    [<Test>]
    let UsingOptionTypesWithPatternMatching() =
        let chronoTrigger = { Name = "Chrono Trigger"; Platform = "SNES"; Score = Some 5 }
        let halo = { Name = "Halo"; Platform = "Xbox"; Score = None }

        let translate score =
            match score with
            | 5 -> "Great"
            | 4 -> "Good"
            | 3 -> "Decent"
            | 2 -> "Bad"
            | 1 -> "Awful"
            | _ -> "Unknown"

        let getScore game =
            match game.Score with
            | Some score -> translate score
            | None -> "Unknown"

        AssertEquality (getScore chronoTrigger) "Great"
        AssertEquality (getScore halo) "Unknown"

    [<Test>]
    let FindingJustOneOrZeroItem() =
        let names = [ "Alice"; "Bob"; "Eve"; ]

        // tryFind returns an option so you can handle 0 rows returned
        let eve =
            names
            |> List.tryFind (fun name -> name = "Eve" )
        let zelda =
            names
            |> List.tryFind (fun name -> name = "Zelda" )

        AssertEquality eve (Some "Eve")
        AssertEquality zelda None

    [<Test>]
    let CreatingListsWithComprehensions() =
        let list = [for i in 0..4 do yield i ]

        AssertEquality list [0;1;2;3;4]

    [<Test>]
    let ComprehensionsWithConditions() =
        let list = [for i in 0..10 do
                        if i % 2 = 0 then yield i ]

        AssertEquality list [0;2;4;6;8;10]

    [<Test>]
    let TransformingListsWithMap() =
        let square x =
            x * x

        let original = [0..5]
        let result = List.map square original

        AssertEquality original [0;1;2;3;4;5]
        AssertEquality result [0;1;4;9;16;25]

    [<Ignore("Not implemented");Test>]
    let FilteringListsWithFilter() =
        let isEven x =
            x % 2 = 0

        let original = [0..5]
        let result = List.filter isEven original

        AssertEquality original __
        AssertEquality result __

    [<Test>]
    let DividingListsWithPartition() =
        let isOdd x =
            x % 2 <> 0

        let original = [0..5]
        let result1, result2 = List.partition isOdd original

        AssertEquality result1 [1;3;5]
        AssertEquality result2 [0;2;4]

    [<Test>]
    let CreatingArrays() =
        let fruits = [| "apple"; "pear"; "peach"|]

        AssertEquality fruits.[0] "apple"
        AssertEquality fruits.[1] "pear"
        AssertEquality fruits.[2] "peach"

    [<Test>]
    let ArraysAreMutable() =
        let fruits = [| "apple"; "pear" |]
        fruits.[1] <- "peach"

        AssertEquality fruits [| "apple"; "peach" |]

    [<Test>]
    let YouCanCreateArraysWithComprehensions() =
        let numbers =
            [| for i in 0..10 do
                   if i % 2 = 0 then yield i |]

        AssertEquality numbers [|0;2;4;6;8;10|]

    [<Test>]
    let ThereAreAlsoSomeOperationsYouCanPerformOnArrays() =
        let cube x =
            x * x * x

        let original = [| 0..5 |]
        let result = Array.map cube original

        AssertEquality original [|0;1;2;3;4;5|]
        AssertEquality result [|0;1;8;27;64;125|]

    [<Test>]
    let SkippingElements() =
        let original = [0..5]
        let result = Seq.skip 2 original

        AssertEquality result [2;3;4;5]

    [<Test>]
    let FindingTheMax() =
        let values = new ResizeArray<int>()

        values.Add(11)
        values.Add(20)
        values.Add(4)
        values.Add(2)
        values.Add(3)

        let result = Seq.max values

        AssertEquality result 20

    [<Test>]
    let FindingTheMaxUsingACondition() =
        let getNameLength (name:string) =
            name.Length

        let names = [| "Harry"; "Lloyd"; "Nicholas"; "Mary"; "Joe"; |]
        let result = Seq.maxBy getNameLength names

        AssertEquality result "Nicholas"

    [<Test>]
    let MaxMinSum() =
        // Given five positive integers, find the minimum and maximum values that can be calculated by
        // summing exactly four of the five integers. Then print the respective minimum and maximum
        // values as a single line of two space-separated long integers.

        let calculateMaxMin centimes =
            let sums = centimes |> Seq.map (fun c -> centimes |> Seq.except [c] |> Seq.sum)
            (sums |> Seq.min, sums |> Seq.max)

        AssertEquality (16, 24) (calculateMaxMin [1;3;5;7;9])
        AssertEquality (10, 14) (calculateMaxMin [1;2;3;4;5])

    [<Test>]
    let FizzBuzzCodingTest() =
        // The FizzBuzz problem is a classic test given in coding interviews. The task
        // is simple: Print integers 1 to N, but print “Fizz” if an integer is divisible
        // by 3, “Buzz” if an integer is divisible by 5, and “FizzBuzz” if an integer
        // is divisible by both 3 and 5. In this case the results should be in the form
        // of an F# list.

        let fizzBuzzList n =
               [1..n] 
               |> List.map (fun x -> 
                if x % 3 = 0 && x % 5 = 0 then "FizzBuzz"
                 elif x % 3 = 0 then "Fizz"
                 elif x % 5 = 0 then "Buzz"
                 else x.ToString())

        let result = ["1"; "2"; "Fizz"; "4"; "Buzz"; "Fizz"; "7"; "8"; "Fizz"; "Buzz"; "11"; "Fizz"; "13"; "14"; "FizzBuzz"; "16"; "17"; "Fizz"; "19"; "Buzz"]

        AssertEquality result (fizzBuzzList 20)