open System.IO

let input =
    File.ReadAllText "input.txt"
    |> (fun s -> s.Split ",")
    |> Array.map int

let rec interpreter (step: int) (opcode: array<int>) =
    let action = opcode.[step..step + 3]

    match action.[0] with
    | 99 -> opcode
    | 1 ->
        Array.set opcode action.[3] (opcode.[action.[1]] + opcode.[action.[2]])
        interpreter (step + 4) opcode
    | 2 ->
        Array.set opcode action.[3] (opcode.[action.[1]] * opcode.[action.[2]])
        interpreter (step + 4) opcode
    | _ -> opcode

let result =
    let input = input |> Array.copy
    input.[1] <- 12
    input.[2] <- 2
    interpreter 0 input |> Array.head

printfn "result for problem 1: %A" result

for i in 0 .. 99 do
    for j in 0 .. 99 do
        let new_input = input |> Array.copy
        new_input.[1] <- i
        new_input.[2] <- j
        let res = new_input |> interpreter 0 |> Array.head

        if 19690720 = res then
            printfn "result for problem 2: %A" (100 * i + j)