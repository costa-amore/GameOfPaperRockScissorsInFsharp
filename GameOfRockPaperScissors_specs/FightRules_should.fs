module GameOfRockPaperScissors_specs

open GameOfRockPaperScissors
open NUnit.Framework

let fightData:obj[][] = [|
    [|CellType.Rock; CellType.Rock; Result.Draw|]       
    [|CellType.Paper; CellType.Paper; Result.Draw|]       
    [|CellType.Scissors; CellType.Scissors; Result.Draw|]
    
    [|CellType.Paper; CellType.Rock; Result.Win|]
    [|CellType.Rock; CellType.Scissors; Result.Win|]
    [|CellType.Scissors; CellType.Paper; Result.Win|]

    [|CellType.Scissors; CellType.Rock; Result.Loss|]
    [|CellType.Rock; CellType.Paper; Result.Loss|]
    [|CellType.Paper; CellType.Scissors; Result.Loss|]
|]
   
[<Test>]
[<TestCaseSource(nameof(fightData))>]
let Resolve_single_combat ((attacker:CellType, defender:CellType, expected:Result)) =
    Assert.That(fight attacker defender, Is.EqualTo(expected))
    
let battleData:obj[][] = [|
    [|CellType.Paper; [CellType.Rock]; Result.Win|]       
    [|CellType.Scissors; [CellType.Rock]; Result.Loss|]       
    [|CellType.Scissors; [CellType.Scissors]; Result.Draw|]

    [|CellType.Paper; [CellType.Paper; CellType.Rock]; Result.Win|]       
    [|CellType.Paper; [CellType.Rock; CellType.Paper]; Result.Win|]
    
    [|CellType.Paper; [CellType.Paper; CellType.Scissors]; Result.Loss|]       
    [|CellType.Paper; [CellType.Scissors; CellType.Paper]; Result.Loss|]       
    
    [|CellType.Paper; [CellType.Paper; CellType.Paper]; Result.Draw|]
    [|CellType.Paper; [CellType.Scissors; CellType.Rock]; Result.Draw|]

    [|CellType.Paper; [CellType.Paper; CellType.Rock; CellType.Scissors; CellType.Scissors]; Result.Loss|]       

    [|CellType.Rock;  [CellType.Paper; CellType.Scissors; CellType.Scissors]; Result.Win|]       
    
|]

[<Test>]
[<TestCaseSource(nameof(battleData))>]
let Resolve_combat((attacker:CellType, neighbors:CellType list, expected:Result)) =
    Assert.That(battle attacker neighbors , Is.EqualTo(expected))
    
[<Test>]
let Empty_world_stays_empty() =
    let EMPTY_WORLD : World = {cells = list.Empty}
    Assert.That(applyTick EMPTY_WORLD, Is.EqualTo(EMPTY_WORLD))
    