namespace NancyFxFSharpCompanies

open System
open System.Collections.Generic
open System.Threading.Tasks

[<Interface>]
type IDepartmentService = 
    abstract member GetDepartments: unit -> Task<ICollection<Department>>
    abstract member GetDepartment: int -> Task<Department>
    