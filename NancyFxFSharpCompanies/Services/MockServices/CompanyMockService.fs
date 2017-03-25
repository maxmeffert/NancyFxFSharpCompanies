namespace NancyFxFSharpCompanies

open System
open System.Linq
open System.Collections.Generic
open System.Threading.Tasks


type CompanyMockService() = 
    let delay = 1500
    let companiesList = [ for i in 0..9 do yield new Company(i, "Company"+i.ToString()) ]
    let companies: ICollection<Company> = new List<Company>(companiesList) :> ICollection<Company>

    let wait(x) = 
        async {
            do! Async.Sleep(delay)
            return x
        } |> Async.StartAsTask

    interface ICompanyService with
        member this.GetCompanies(): Task<ICollection<Company>> = wait companies
        member this.GetCompany(id: int): Task<Company> = 
            let pred: Company -> bool = fun x -> x.Id = id
            let result = companies.Where(pred).FirstOrDefault();
            wait result