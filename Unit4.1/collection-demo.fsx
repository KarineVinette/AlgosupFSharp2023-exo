#time

// Scenario 1 - accessing the last element
// List vs Array vs Sequence

let listLength = 10_000_000

let scenario1_list() =
    let bigList = [ 1 .. listLength ]
    for _ in 1 .. 100 do
        let lastElement = bigList.[listLength - 1]
        // printfn "%i" lastElement
        ()

let scenario1_array() =
    let bigList = [| 1 .. listLength |]
    for _ in 1 .. 100 do
        let lastElement = bigList.[listLength - 1]
        // printfn "%i" lastElement
        ()

let scenario1_lazy() =
    let bigList = seq { 1 .. listLength }
    for _ in 1 .. 100 do
        let lastElement = Seq.item (listLength - 1) bigList
        // printfn "%i" lastElement
        ()

scenario1_list()
scenario1_array()
scenario1_lazy()

// -----------------------------------------------------------------

// Scenario 2 - create a list and accessing the first element
// List vs Array vs Sequence



let listLength2 = 1000_000

let scenario2_list() =
    for _ in 1 .. 100 do
        let bigList = [ 1 .. listLength2 ]
        let lastElement = bigList.[1]
        // printfn "%i" lastElement
        ()

let scenario2_array() =
    for _ in 1 .. 100 do
        let bigList = [| 1 .. listLength2 |]
        let lastElement = bigList.[1]
        // printfn "%i" lastElement
        ()

let scenario2_lazy() =
    for _ in 1 .. 100 do
        let bigList = seq { 1 .. listLength2 }
        let lastElement = Seq.item  1 bigList
        // printfn "%i" lastElement
        ()

scenario2_list()
scenario2_array()
scenario2_lazy()

// -----------------------------------------------------------------

// Scenario 3 - testing if an element exists
// List vs Set

let scenario3_list() =
    let list = [ 1 .. listLength2 ]
    let item = listLength / 2
    for _ in 1 .. 500 do
        List.contains item list |> ignore
        ()

let scenario3_set() =
    let list = [| 1 .. listLength2 |] |> Set.ofArray
    let item = listLength / 2
    for _ in 1 .. 500 do
        Set.contains item list |> ignore
        ()

scenario3_list()
scenario3_set()
