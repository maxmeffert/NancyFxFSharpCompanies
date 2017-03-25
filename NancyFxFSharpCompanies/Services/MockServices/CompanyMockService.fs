namespace NancyFxFSharpCompanies

open System
open System.Threading.Tasks


type CompanyMockService() = 
    let delay = 1500
    let companies = [ for i in 0..9 do yield new Company(i, "Company"+i.ToString()) ]

    let wait(x) = 
        async {
            do! Async.Sleep(delay)
            return x
        } |> Async.StartAsTask

    interface ICompanyService with
        member this.GetCompanies(): Task<list<Company>> = wait companies
        member this.GetCompany(id): Task<Company> = Task.FromResult(new Company(0, "adsf"))