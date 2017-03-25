namespace NancyFxFSharpCompanies

open System
open System.Collections.Generic
open System.Threading
open System.Threading.Tasks
open Nancy
open NancyFSharp

type CompanyModule(companyService : ICompanyService) as self =
    inherit NancyModule("companies")
    

    do
        self.Get.["/", true] <- nancyAsyncTask( fun ctx ct -> companyService.GetCompanies() )
        self.Get.["/{id:int}", true] <- nancyAsyncTask( fun ctx ct -> companyService.GetCompany(int (ctx?id).Value) )