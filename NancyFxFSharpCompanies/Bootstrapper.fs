

namespace FsMvc4MonoSample
open System
open Nancy

type Bootstrapper() = 
    inherit DefaultNancyBootstrapper()

type MyModule() as x =
    inherit NancyModule()

    do
        x.Get.["/"] <- fun _ -> box "hello world"
