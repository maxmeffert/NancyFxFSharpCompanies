namespace NancyFxFSharpCompanies

open System
open Nancy
open Nancy.Bootstrapper
open Nancy.Responses.Negotiation

type Bootstrapper() = 
    inherit DefaultNancyBootstrapper()

    override x.InternalConfiguration = 
        NancyInternalConfiguration.WithOverrides (
            fun cfg -> 
                cfg.ResponseProcessors.Clear(); 
                cfg.ResponseProcessors.Add(typeof<JsonProcessor>) 
            )


