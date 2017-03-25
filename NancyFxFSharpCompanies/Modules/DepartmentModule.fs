namespace NancyFxFSharpCompanies

open System
open System.Collections.Generic
open System.Threading
open System.Threading.Tasks
open Nancy
open NancyFSharp

type DepartmentModule(departmentService : IDepartmentService) as self =
    inherit NancyModule("departments")

    do
        self.Get.["/", true] <- nancyAsyncTask( fun ctx ct -> departmentService.GetDepartments() )
        self.Get.["/{id:int}", true] <- nancyAsyncTask( fun ctx ct -> departmentService.GetDepartment(int (ctx?id).Value) )