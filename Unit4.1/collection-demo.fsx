#time

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
