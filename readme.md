# OWIN Force HTTPS

A middleware to force HTTPS for OWIN applications.

# Install

```ps
PS> Install-Package Owin.ForceHttps
```

# Usage

```csharp
using Owin;
using Microsoft.Owin;

namespace MyApplication {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.UseForcedHttps(443);

            //configure other middleware
        }
    }
}
```

There is also an overload which allows you to specify a different port for HTTPS. Useful for local development.

# License

MIT
