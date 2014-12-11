namespace Sample

open Owin
open Microsoft.Owin
open Owin.ForceHttps

type Startup() =
    member x.Configuration (app:IAppBuilder) =
        app.UseForcedHttps(44300)

        app.Run(fun ctx ->
            ctx.Response.ContentType <- "text/plain"
            ctx.Response.WriteAsync("Site it running")
        ) |> ignore