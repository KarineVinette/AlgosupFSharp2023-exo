namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay5And6_1RunLengthEncoding =

    // Implement run-length encoding and decoding.

    // Run-length encoding (RLE) is a simple form of data compression, where runs
    // (consecutive data elements) are replaced by just one data value and count.

    // For example we can represent the original 53 characters with only 13.

    // ```text
    // "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"  ->  "12WB12W3B24WB"
    // ```

    // RLE allows the original data to be perfectly reconstructed from
    // the compressed data, which makes it a lossless data compression.

    // ```text
    // "AABCCCDEEEE"  ->  "2AB3CD4E"  ->  "AABCCCDEEEE"
    // ```

    // For simplicity, you can assume that the unencoded string will only contain
    // the letters A through Z (either lower or upper case) and whitespace. This way
    // data to be encoded will never contain any numbers and numbers inside data to
    // be decoded always represent the count for the following character.

    let encode input = __

    let decode input = __

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Encode empty string`` () =
        encode "" |> AssertEquality ""

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Encode single characters only are encoded without count`` () =
        encode "XYZ" |> AssertEquality "XYZ"

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Encode string with no single characters`` () =
        encode "AABBBCCCC" |> AssertEquality "2A3B4C"

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Encode single characters mixed with repeated characters`` () =
        encode "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB" |> AssertEquality "12WB12W3B24WB"

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Encode multiple whitespace mixed in string`` () =
        encode "  hsqq qww  " |> AssertEquality "2 hs2q q2w2 "

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Encode lowercase characters`` () =
        encode "aabbbcccc" |> AssertEquality "2a3b4c"

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Decode empty string`` () =
        decode "" |> AssertEquality ""

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Decode single characters only`` () =
        decode "XYZ" |> AssertEquality "XYZ"

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Decode string with no single characters`` () =
        decode "2A3B4C" |> AssertEquality "AABBBCCCC"

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Decode single characters with repeated characters`` () =
        decode "12WB12W3B24WB" |> AssertEquality "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Decode multiple whitespace mixed in string`` () =
        decode "2 hs2q q2w2 " |> AssertEquality "  hsqq qww  "

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Decode lowercase string`` () =
        decode "2a3b4c" |> AssertEquality "aabbbcccc"

    [<Ignore("Not implemented");Test>]
    let ``RunLengthEncoding - Encode followed by decode gives original string`` () =
        "zzz ZZ  zZ" |> encode |> decode |> AssertEquality "zzz ZZ  zZ"

