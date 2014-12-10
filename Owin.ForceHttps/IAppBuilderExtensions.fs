[<System.Runtime.CompilerServices.Extension>]
module Microsoft.Owin

open Microsoft.Owin
open System
open System.Threading.Tasks

type Owin.IAppBuilder with
    [<System.Runtime.CompilerServices.Extension>]
    member x.UseForcedHttps(port:int) =
        let httpser (ctx:IOwinContext) (next:Func<Task>) =
            match ctx.Request.Uri.Scheme with
                | "http" ->
                    sprintf "https://%s:%d%s" ctx.Request.Uri.Host port ctx.Request.Uri.PathAndQuery
                        |> ctx.Response.Redirect
                    next.Invoke()
                | _ -> next.Invoke()

        x.Use httpser |> ignore

    [<System.Runtime.CompilerServices.Extension>]
    member x.UseForcedHttps() =
        x.UseForcedHttps(443)