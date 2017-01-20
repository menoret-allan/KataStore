module Diamond

let letterToInt (c:char) = (int c) - (int 'A')

let createLine (sideChars, inBetweenChars, middleChars) =
    sideChars + inBetweenChars + middleChars + inBetweenChars + sideChars + "\n"

let repeatSpace nb = String.replicate nb " "

let getMiddle letter = repeatSpace (1+(letterToInt letter-1)*2)

let generateLine charMax = function
    | 'A' -> (repeatSpace (letterToInt charMax), "", "A") |> createLine
    | char -> (repeatSpace (int charMax-int char), string char, getMiddle char) |> createLine

let createDiamond highestChar =
    let chars = ['A'..char(int highestChar - 1)]
    seq {
        yield! chars |> Seq.map (generateLine highestChar)
        yield generateLine highestChar highestChar
        yield! chars |> List.rev  |> Seq.map (generateLine highestChar)
    } |> Seq.reduce (+)

module Tests = 
    open Xunit
    open FsUnit.Xunit

    type ``Given a letter should return the right diamond``() = 
        let diamondB = " A \n" +
                       "B B\n" +
                       " A \n"

        let diamondC = "  A  \n" +
                       " B B \n" +
                       "C   C\n" +
                       " B B \n" +
                       "  A  \n"
    
        let diamondF = "     A     \n" +
                       "    B B    \n" +
                       "   C   C   \n" +
                       "  D     D  \n" +
                       " E       E \n" +
                       "F         F\n" +
                       " E       E \n" +
                       "  D     D  \n" +
                       "   C   C   \n" +
                       "    B B    \n" +
                       "     A     \n"
    
        [<Fact>] member x.``Given A should return the A diamond``() = createDiamond 'A' |> should equal "A\n"
        [<Fact>] member x.``Given B should return the B diamond``() = createDiamond 'B' |> should equal diamondB
        [<Fact>] member x.``Given C should return the C diamond``() = createDiamond 'C' |> should equal diamondC
        [<Fact>] member x.``Given F should return the F diamond``() = createDiamond 'F' |> should equal diamondF

    type ``Given a char capital letter should return the correct position in alphabet``() = 
        [<Fact>] member x.``Given 'A' should return 0 ``() = letterToInt 'A' |> should equal 0
        [<Fact>] member x.``Given 'B' should return 1 ``() = letterToInt 'B' |> should equal 1
        [<Fact>] member x.``Given 'Z' should return 25``() = letterToInt 'Z' |> should equal 25
