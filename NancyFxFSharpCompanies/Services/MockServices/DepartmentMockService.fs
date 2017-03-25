namespace NancyFxFSharpCompanies

open System
open System.Linq
open System.Collections.Generic
open System.Threading.Tasks
open NancyFSharp

type DepartmentMockService() = 
    let departmentsList = [ for i in 0..9 do yield new Department(i, "Department"+i.ToString()) ]
    let departments: ICollection<Department> = new List<Department>(departmentsList) :> ICollection<Department>

    interface IDepartmentService with
        member this.GetDepartments(): Task<ICollection<Department>> = wait departments
        member this.GetDepartment(id: int): Task<Department> = 
            let pred: Department -> bool = fun x -> x.Id = id
            let result = departments.Where(pred).FirstOrDefault();
            wait result