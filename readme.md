# OWIN Force HTTPS

A middleware to force HTTPS for OWIN applications.

# Install

```ps
PS> Install-Package Owin.ForceHttps
```

# Usage

1. ### Make sure your project has SSL enabled

    * Find your web project and hit `F4` to get the Properties window
    * Toggle `SSL Enabled` to `True` and note the port number for the `SSL URL`
    ![VS project Properties window snip](http://i.imgur.com/kn8ENIa.png)

2. ### Add `app.UseForcedHttps()` to `Startup.cs` class:

```csharp
using Owin;
using Microsoft.Owin;

namespace MyApplication {
    public class Startup {
        public void Configuration(IAppBuilder app) {
#if DEBUG
            app.UseForcedHttps(44309);  // IIS Express
#else
            app.UseForcedHttps(443);
#endif

            //configure other middleware
        }
    }
}
```

# License

MIT
