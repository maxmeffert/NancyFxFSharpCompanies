namespace NancyFxFSharpCompanies

open System
open System.Collections.Generic
open System.Threading
open System.Threading.Tasks
open Nancy
open NancyFSharp

type EmployeeModule(employeeService : IEmployeeService) as self =
    inherit NancyModule("employees")

    do
        self.Get.["/", true] <- nancyAsyncTask( fun ctx ct -> employeeService.GetEmployees() )
        self.Get.["/{id:int}", true] <- nancyAsyncTask( fun ctx ct -> employeeService.GetEmployee(int (ctx?id).Value) )