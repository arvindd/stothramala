// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System.IO
open Jurassic

[<EntryPoint>]
let main _ =
    let execprog prog args= async {
        use n=
            new System.Diagnostics.Process(
                StartInfo=System.Diagnostics.ProcessStartInfo(
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    FileName = prog,
                    Arguments=args))
        n.Start() |> ignore
        return (n.StandardOutput).ReadToEnd()
    }

    let sanscript (input:string) (fromlang:string) (tolang:string) = async {
        let args = $"sanscript.js {input} {fromlang} {tolang}"
        return! execprog "node" args
    }

    let output = sanscript "sugrIva" "hk" "tamil" |> Async.RunSynchronously
    printfn "Output is: \n%s" (string output)
    0