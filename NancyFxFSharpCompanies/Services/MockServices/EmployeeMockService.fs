namespace NancyFxFSharpCompanies

open System
open System.Linq
open System.Collections.Generic
open System.Threading.Tasks
open NancyFSharp

type EmployeeMockService() = 
    let employeesList = [ for i in 0..9 do yield new Employee(i, "Employee"+i.ToString()) ]
    let employees: ICollection<Employee> = new List<Employee>(employeesList) :> ICollection<Employee>

    interface IEmployeeService with
        member this.GetEmployees(): Task<ICollection<Employee>> = wait employees
        member this.GetEmployee(id: int): Task<Employee> = 
            let pred: Employee -> bool = fun x -> x.Id = id
            let result = employees.Where(pred).FirstOrDefault();
            wait result