namespace NancyFxFSharpCompanies

open System
open System.Collections.Generic
open System.Threading.Tasks

[<Interface>]
type IEmployeeService = 
    abstract member GetEmployees: unit -> Task<ICollection<Employee>>
    abstract member GetEmployee: int -> Task<Employee>
        