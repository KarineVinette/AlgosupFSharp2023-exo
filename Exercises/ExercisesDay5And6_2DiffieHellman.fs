namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework
open System

module ExercisesDay5And6_2DiffieHellman =

    // # Instructions

    // Diffie-Hellman key exchange.

    // Alice and Bob use Diffie-Hellman key exchange to share secrets.  They
    // start with prime numbers, pick private keys, generate and share public
    // keys, and then generate a shared secret key.

    // ## Step 0

    // The test program supplies prime numbers p and g.

    // ## Step 1

    // Alice picks a private key, a, greater than 1 and less than p.  Bob does
    // the same to pick a private key b.

    // ## Step 2

    // Alice calculates a public key A.

    //     A = gᵃ mod p

    // Using the same p and g, Bob similarly calculates a public key B from his
    // private key b.

    // ## Step 3

    // Alice and Bob exchange public keys.  Alice calculates secret key s.

    //     s = Bᵃ mod p

    // Bob calculates

    //     s = Aᵇ mod p

    // The calculations produce the same result!  Alice and Bob now share
    // secret s.

    // # Hints

    // For this exercise the following F# feature comes in handy:

    // - [BigInt](https://docs.microsoft.com/en-us/dotnet/api/system.numerics.biginteger?view=net-5.0)

    let privateKey primeP = __

    let publicKey primeP primeG privateKey = __

    let secret primeP publicKey privateKey = __

    [<Ignore("Not implemented");Test>]
    let ``DiffieHellman - Private key is greater than 1 and less than p`` () =
        let p = 7919I
        let privateKeys = [for _ in 0 .. 10 -> privateKey p]
        privateKeys |> List.forall (fun x -> x > 1I) |> AssertEquality true
        privateKeys |> List.forall (fun x -> x < p) |> AssertEquality true

    [<Ignore("Not implemented");Test>]
    let ``DiffieHellman - Private key is random`` () =
        let p = 7919I
        let privateKeys = [for _ in 0 .. 10 -> privateKey p]
        List.distinct privateKeys |> List.length |> AssertEquality (List.length privateKeys)

    [<Ignore("Not implemented");Test>]
    let ``DiffieHellman - Can calculate public key using private key`` () =
        let p = 23I
        let g = 5I
        let privateKey = 6I
        publicKey p g privateKey |> AssertEquality 8I

    [<Ignore("Not implemented");Test>]
    let ``DiffieHellman - Can calculate public key when given a different private key`` () =
        let p = 23I
        let g = 5I
        let privateKey = 15I
        publicKey p g privateKey |> AssertEquality 19I

    [<Ignore("Not implemented");Test>]
    let ``DiffieHellman - Can calculate secret using other party's public key`` () =
        let p = 23I
        let theirPublicKey = 19I
        let myPrivateKey = 6I
        secret p theirPublicKey myPrivateKey |> AssertEquality 2I

    [<Ignore("Not implemented");Test>]
    let ``DiffieHellman - Key exchange`` () =
        let p = 23I
        let g = 5I
        let alicePrivateKey = privateKey p
        let alicePublicKey = publicKey p g alicePrivateKey
        let bobPrivateKey = privateKey p
        let bobPublicKey = publicKey p g bobPrivateKey
        let secretA = secret p bobPublicKey alicePrivateKey
        let secretB = secret p alicePublicKey bobPrivateKey
        secretA |> AssertEquality secretB