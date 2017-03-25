namespace NancyFxFSharpCompanies

open System
open System.Linq
open System.Collections.Generic
open System.Threading.Tasks
open NancyFSharp

type CompanyMockService() = 
    let companiesList = [ for i in 0..9 do yield new Company(i, "Company"+i.ToString()) ]
    let companies: ICollection<Company> = new List<Company>(companiesList) :> ICollection<Company>

    interface ICompanyService with
        member this.GetCompanies(): Task<ICollection<Company>> = wait companies
        member this.GetCompany(id: int): Task<Company> = 
            let pred: Company -> bool = fun x -> x.Id = id
            let result = companies.Where(pred).FirstOrDefault();
            wait result