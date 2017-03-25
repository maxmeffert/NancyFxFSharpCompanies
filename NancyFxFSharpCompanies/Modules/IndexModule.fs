namespace NancyFxFSharpCompanies

open System
open Nancy

type App() = 
    member x.Name: string = "NancyFxFSharpCompanies"
    member x.Author: string = "Maximilian Meffert"

type IndexModule() as self = 
    inherit NancyModule()
    do
        self.Get.["/"] <- fun _ -> new App() :> obj
