namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay3_3ProteinTranslation =

    // Translate RNA sequences into proteins.

    // RNA can be broken into three nucleotide sequences called codons, and then translated to a polypeptide like so:

    // RNA: `"AUGUUUUCU"` => translates to

    // Codons: `"AUG", "UUU", "UCU"`
    // => which become a polypeptide with the following sequence =>

    // Protein: `"Methionine", "Phenylalanine", "Serine"`

    // There are 64 codons which in turn correspond to 20 amino acids; however, all of the codon sequences and resulting amino acids are not important in this exercise.  If it works for one codon, the program should work for all of them.
    // However, feel free to expand the list in the test suite to include them all.

    // There are also three terminating codons (also known as 'STOP' codons); if any of these codons are encountered (by the ribosome), all translation ends and the protein is terminated.

    // All subsequent codons after are ignored, like this:

    // RNA: `"AUGUUUUCUUAAAUG"` =>

    // Codons: `"AUG", "UUU", "UCU", "UAA", "AUG"` =>

    // Protein: `"Methionine", "Phenylalanine", "Serine"`

    // Note the stop codon `"UAA"` terminates the translation and the final methionine is not translated into the protein sequence.

    // Below are the codons and resulting Amino Acids needed for the exercise.

    // Codon                 | Protein
    // :---                  | :---
    // AUG                   | Methionine
    // UUU, UUC              | Phenylalanine
    // UUA, UUG              | Leucine
    // UCU, UCC, UCA, UCG    | Serine
    // UAU, UAC              | Tyrosine
    // UGU, UGC              | Cysteine
    // UGG                   | Tryptophan
    // UAA, UAG, UGA         | STOP

    // Learn more about [protein translation on Wikipedia](http://en.wikipedia.org/wiki/Translation_(biology))

    let proteins rna = 
        let codons = rna |> Seq.chunkBySize 3
        let codonToProtein = 
            [ "AUG", "Methionine"
              "UUU", "Phenylalanine"
              "UUC", "Phenylalanine"
              "UUA", "Leucine"
              "UUG", "Leucine"
              "UCU", "Serine"
              "UCC", "Serine"
              "UCA", "Serine"
              "UCG", "Serine"
              "UAU", "Tyrosine"
              "UAC", "Tyrosine"
              "UGU", "Cysteine"
              "UGC", "Cysteine"
              "UGG", "Tryptophan"
              "UAA", "STOP"
              "UAG", "STOP"
              "UGA", "STOP" ]
        codons
        |> Seq.map (fun codon -> codonToProtein |> List.tryFind (fun (c,_) -> c = codon))
        |> Seq.choose id
        |> Seq.takeWhile (fun (_,protein) -> protein <> "STOP")
        |> Seq.map snd
        |> Seq.toList

    

    [<Test>]
    let ``Empty RNA sequence results in no proteins`` () =
        proteins "" |> should be Empty

    [<Test>]
    let ``Methionine RNA sequence`` () =
        proteins "AUG" |> AssertEquality ["Methionine"]

    [<Test>]
    let ``Phenylalanine RNA sequence 1`` () =
        proteins "UUU" |> AssertEquality ["Phenylalanine"]

    [<Test>]
    let ``Phenylalanine RNA sequence 2`` () =
        proteins "UUC" |> AssertEquality ["Phenylalanine"]

    [<Test>]
    let ``Leucine RNA sequence 1`` () =
        proteins "UUA" |> AssertEquality ["Leucine"]

    [<Test>]
    let ``Leucine RNA sequence 2`` () =
        proteins "UUG" |> AssertEquality ["Leucine"]

    [<Test>]
    let ``Serine RNA sequence 1`` () =
        proteins "UCU" |> AssertEquality ["Serine"]

    [<Test>]
    let ``Serine RNA sequence 2`` () =
        proteins "UCC" |> AssertEquality ["Serine"]

    [<Test>]
    let ``Serine RNA sequence 3`` () =
        proteins "UCA" |> AssertEquality ["Serine"]

    [<Test>]
    let ``Serine RNA sequence 4`` () =
        proteins "UCG" |> AssertEquality ["Serine"]

    [<Test>]
    let ``Tyrosine RNA sequence 1`` () =
        proteins "UAU" |> AssertEquality ["Tyrosine"]

    [<Test>]
    let ``Tyrosine RNA sequence 2`` () =
        proteins "UAC" |> AssertEquality ["Tyrosine"]

    [<Test>]
    let ``Cysteine RNA sequence 1`` () =
        proteins "UGU" |> AssertEquality ["Cysteine"]

    [<Test>]
    let ``Cysteine RNA sequence 2`` () =
        proteins "UGC" |> AssertEquality ["Cysteine"]

    [<Test>]
    let ``Tryptophan RNA sequence`` () =
        proteins "UGG" |> AssertEquality ["Tryptophan"]

    [<Test>]
    let ``STOP codon RNA sequence 1`` () =
        proteins "UAA" |> should be Empty

    [<Test>]
    let ``STOP codon RNA sequence 2`` () =
        proteins "UAG" |> should be Empty

    [<Test>]
    let ``STOP codon RNA sequence 3`` () =
        proteins "UGA" |> should be Empty

    [<Test>]
    let ``Sequence of two protein codons translates into proteins`` () =
        proteins "UUUUUU" |> AssertEquality ["Phenylalanine"; "Phenylalanine"]

    [<Test>]
    let ``Sequence of two different protein codons translates into proteins`` () =
        proteins "UUAUUG" |> AssertEquality ["Leucine"; "Leucine"]

    [<Test>]
    let ``Translate RNA strand into correct protein list`` () =
        proteins "AUGUUUUGG" |> AssertEquality ["Methionine"; "Phenylalanine"; "Tryptophan"]

    [<Test>]
    let ``Translation stops if STOP codon at beginning of sequence`` () =
        proteins "UAGUGG" |> should be Empty

    [<Test>]
    let ``Translation stops if STOP codon at end of two-codon sequence`` () =
        proteins "UGGUAG" |> AssertEquality ["Tryptophan"]

    [<Test>]
    let ``Translation stops if STOP codon at end of three-codon sequence`` () =
        proteins "AUGUUUUAA" |> AssertEquality ["Methionine"; "Phenylalanine"]

    [<Test>]
    let ``Translation stops if STOP codon in middle of three-codon sequence`` () =
        proteins "UGGUAGUGG" |> AssertEquality ["Tryptophan"]

    [<Test>]
    let ``Translation stops if STOP codon in middle of six-codon sequence`` () =
        proteins "UGGUGUUAUUAAUGGUUU" |> AssertEquality ["Tryptophan"; "Cysteine"; "Tyrosine"]

