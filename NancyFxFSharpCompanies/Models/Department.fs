namespace NancyFxFSharpCompanies

type Department(id: int, name: string) = 
    member x.Id: int = id
    member x.Name: string = name
