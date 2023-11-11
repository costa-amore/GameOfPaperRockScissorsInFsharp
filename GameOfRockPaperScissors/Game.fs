module GameOfRockPaperScissors

type Result = Draw | Win | Loss

type CellType = Rock | Paper | Scissors

type Cell = {
    cellType:CellType
}

type World = {
    cells:Cell list
}

let applyTick world =
    let cell:Cell = { cellType = Scissors }
    {cells=list.Empty}
    

let private nrOf result results =
    results |> List.where (fun r -> r = result) |> List.length
    
let private countResults (wins, losses) result =
    match result with
        | Win  ->   (wins+1, losses)
        | Loss ->   (wins, losses+1)
        | _    ->   (wins, losses)
    

let fight attacker defender = 
    match attacker, defender with
        | Paper, Rock | Rock, Scissors | Scissors, Paper -> Win
        | Scissors, Rock | Rock, Paper | Paper, Scissors -> Loss
        | _ -> Draw
        
let battle cell (neighbors:CellType list) = 
    neighbors
        |> List.map (fight cell)
        |> List.fold countResults (0,0) 
        |> function 
            |  wins, losses when wins > losses    -> Win
            |  wins, losses when wins < losses    -> Loss
            |  _                                  -> Draw
