namespace NancyFxFSharpCompanies

open System
open System.Collections.Generic
open System.Threading.Tasks

[<Interface>]
type ICompanyService = 
    abstract member GetCompanies: unit -> Task<ICollection<Company>>
    abstract member GetCompany: int -> Task<Company>
