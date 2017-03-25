module NancyFSharp

open System
open System.Threading
open System.Threading.Tasks
open Nancy

let (?) (p : obj) prop = 
    let ddv = (p :?> DynamicDictionary).[prop] :?> DynamicDictionaryValue
    match ddv.HasValue with
    | false -> None
    | _ -> ddv.TryParse<'a>() |> Some

// https://dusted.codes/asynchronous-fsharp-workflows-in-nancyfx
let nancyAsyncTask(f : DynamicDictionary -> CancellationToken -> Task<'T>): obj -> CancellationToken -> Task<obj> = 
    fun ctx ct -> 
        let t: Task<'T> = f (ctx :?> DynamicDictionary) ct
        Task.FromResult(t.Result :> obj)

let wait(x) = 
    async {
        do! Async.Sleep(1500)
        return x
    } |> Async.StartAsTask