namespace NancyFxFSharpCompanies

open System
open System.Collections.Generic
open System.Threading.Tasks
open Nancy

// https://dusted.codes/asynchronous-fsharp-workflows-in-nancyfx

type CompanyModule(companyService : ICompanyService) as self =
    inherit NancyModule("companies")

    let nancyAsync(t : Task<'T>) = fun ctx ct -> Task.FromResult(t.Result :> obj)

    do
        self.Get.["/", true] <- nancyAsync(companyService.GetCompanies())

        //self.Get.["/"] <- fun _ -> companyService.GetCompanies() :> obj