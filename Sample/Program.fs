open Microsoft.Owin.Hosting
open Sample

// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    let options = StartOptions();
    options.Urls.Add "https://localhost:44300"
    options.Urls.Add "http://localhost:8089"

    use app = WebApp.Start<Startup>(options)
    printfn "Running on %A" options.Urls
    System.Console.ReadLine() |> ignore

    0 // return an integer exit code
