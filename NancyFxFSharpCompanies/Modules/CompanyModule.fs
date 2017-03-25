namespace NancyFxFSharpCompanies

open System
open System.Collections.Generic
open System.Threading.Tasks
open System.Threading;
open Nancy

// https://dusted.codes/asynchronous-fsharp-workflows-in-nancyfx



type CompanyModule(companyService : ICompanyService) as self =
    inherit NancyModule("companies")

    let (?) (p : obj) prop = 
        let ddv = (p :?> DynamicDictionary).[prop] :?> DynamicDictionaryValue
        match ddv.HasValue with
        | false -> None
        | _ -> ddv.TryParse<'a>() |> Some

    let nancyAsyncTask(f : DynamicDictionary -> CancellationToken -> Task<'T>): obj -> CancellationToken -> Task<obj> = 
        fun ctx ct -> 
            let t: Task<'T> = f (ctx :?> DynamicDictionary) ct
            Task.FromResult(t.Result :> obj)
    

    do
        self.Get.["/", true] <- nancyAsyncTask( fun ctx ct -> companyService.GetCompanies() )
        self.Get.["/{id:int}", true] <- nancyAsyncTask( fun ctx ct -> companyService.GetCompany(int (ctx?id).Value) )