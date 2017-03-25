namespace NancyFxFSharpCompanies

open System

type Company(id: int, name: string) = 
    member x.Id: int = id
    member x.Name: string = name
