namespace Owin

[<System.Runtime.CompilerServices.Extension>]
module ForceHttps =
    open Microsoft.Owin
    open System
    open System.Threading.Tasks

    [<System.Runtime.CompilerServices.Extension>]
    let UseForcedHttps (app : Owin.IAppBuilder) (port : int) =
        let httpser (ctx : IOwinContext) (next : Func<Task>) =
            match ctx.Request.Uri.Scheme with
            | "http" ->
                sprintf "https://%s:%d%s" ctx.Request.Uri.Host port ctx.Request.Uri.PathAndQuery
                |> ctx.Response.Redirect
                next.Invoke()
            | _ -> next.Invoke()
        app.Use httpser |> ignore
