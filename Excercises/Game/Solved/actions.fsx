
#load "../Core/models.fsx"
#load "../Core/gameWorld.fsx"
module Actions =
    open Models
    open GameWorld
    let move gameWorld (direction:Direction):Player  =
        let findRoom ()=
            gameWorld.Rooms.Item gameWorld.Player.Location

        let findExit (room:Room) =
            match direction with
                | North -> Some room.Exits.North
                | South -> Some room.Exits.South
                | East -> Some room.Exits.East
                | West -> Some room.Exits.West
                | Stay -> None
        
        match findRoom() |> findExit with
        | Some(NoExit message) -> 
            match message with
            | None -> printf "There is no exit here\n" 
            | Some s -> printf "%s\n" s 
            player
        | Some(LockedExit (_, key, _)) -> 
            printf "You need to open the door with the key '%s'\n" key.Details.Name
            player
        | Some (PassableExit (_,RoomId room)) -> 
            printf "You entered room %s\n" room
            {player with Location = RoomId room}
        | None -> 
            printf "You remain in the same room \n"
            player

    let private exitIn direction = 
        let currentRoom = gameWorld.Player.Location
        let room = gameWorld.Rooms |> Map.find currentRoom
        let exits = room.Exits
    
        let exit = 
            match  direction with
            | North -> Some exits.North
            | East -> Some exits.East
            | South -> Some exits.South
            | West -> Some exits.West
            | Stay -> None
        (room, exit, exits)
        
    let look gameWorld direction  =
        let currentRoom, exit,exits = exitIn direction
        match exit with
        | Some (NoExit (Some m)) -> printf "%s\n" m
        | Some (NoExit None) -> printf "No Exits in this direction\n"
        | Some (LockedExit (m,_,_)) -> printf "%s\n" m
        | Some (PassableExit (m,_)) -> printf "%s\n" m
        | None -> printf "Player Can't do this action\n"
        

    let openExit gameWorld direction =
        
        let currentRoom, exit,exits = exitIn direction
        let player = gameWorld.Player
        let hasKey (player:Player) = 
            let key = player.Inventory |> List.tryFind (fun x -> x.Details.Name = "A shiny key")
            match key with 
            | None -> false
            | Some _ -> true

        match exit with 
        | Some (NoExit _) -> 
            printf "There are no exits in this direction\n"
            gameWorld
        | Some (LockedExit (_,_,next)) when hasKey player -> 
            printf "door opened"
            let newExits =
                match  direction with
                | North ->  {exits with North = next}
                | East ->  {exits with East = next}
                | South ->  {exits with South = next}
                | West ->  {exits with West = next}
                | Stay ->  exits
            let otherRooms = gameWorld.Rooms |> Map.filter (fun x y -> x <> gameWorld.Player.Location) 
            let newRoom = {currentRoom with Exits =newExits}
            otherRooms.Add( newRoom.Id, newRoom) |> ignore
            {gameWorld with Rooms = otherRooms}
        | Some (LockedExit _) when not <| hasKey player -> 
            printf "You need a key to open this door\n"
            gameWorld   
        | Some (PassableExit _) -> 
            printf "This exit is locked\n"
            gameWorld   
        | None -> 
            printf "There are no exits in this direction\n"
            gameWorld

        