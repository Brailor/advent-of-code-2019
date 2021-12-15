open System.IO

let input = File.ReadAllLines "input.txt" |> Array.map int

let problem1 (inventory: array<int>) =
    inventory
        |> Array.map (fun item -> int(floor (float (item / 3))) - 2)
        |> Array.sum


let result = input
            |> problem1
printfn "result: %A" result


let rec calc_fuel_usage (item: int) =
    let calc = int(floor (float (item / 3))) - 2
    let next = int(floor (float (calc / 3))) - 2 
    match next with
    | i when i <= 0 -> calc
    | _ -> calc + calc_fuel_usage calc

let problem2 (inventory: array<int>) = 
    inventory
        |> Array.map calc_fuel_usage
        |> Array.sum

printfn "calc: %A" (problem2 input)
