#I __SOURCE_DIRECTORY__
#load "./models.fsx"
#load "./gameWorld.fsx"
module Game =
    open Models
    open GameWorld
    //
    // --------- Model ---------
    //
    (*
        Let's build a text adventure game
        -- setup
        Everything has a name and a description

        the wold contains a set of Rooms and a Player

        A Player can be in a Room
        A Player has an Inventory of Items

        A Room can have a Items in it
        a Room can have 4 Exists: North, South, East, West
        a Room have an identifier called RoomId

        an Exit can be Locked or Passable
        an Exit can be marked as NoExit to

        a Locked Exit can be Opened with specific key

        -- the game
        Every turn the player can do some action (eg. Move, Look, Pick, Act)
            the player can Move from one Room to one of the 4 Directions
            it can change room only if the Exit is Passable
            otherwise it remains in the same Room

            the player can Look one of the four Directions

            the player can unlock Locked exits
    *)
    

    
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
            printf "You need to open the door with the key %s\n" key.Details.Name
            player
        | Some (PassableExit (_,RoomId room)) -> 
            printf "You entered room %s\n" room
            {player with Location = RoomId room}
        | None -> 
            printf "You remain in the same room \n"
            player

    let look gameWorld (direction:Direction)  =
        printf "Player Can't do this action"

    let openExit gameWorld (exit:Exit) =
        printf "Player Can't do this action"

    let rec game gameWorld quit= 
        let readCommand() = System.Console.ReadLine().ToUpper()
        let getDirections() = 
            printf "In which direction?\n"
            printf "(N)orth\n"
            printf "(S)outh\n"
            printf "(E)ast\n"
            printf "(W)est\n"

            match readCommand() with
            | "N" -> North
            | "S" -> South
            | "E" -> East
            | "W" -> West
            | _ -> Stay

        if quit then ()
        else
            printf "What do you want to do?\n"
            printf "(L)ook\n"
            printf "(M)ove\n"
            printf "(A)ct\n"
            printf "(Q)uit\n"

            match readCommand() with
            | "L" -> 
                getDirections() |> look gameWorld 
                game gameWorld true  
            | "M" -> 
                let player = getDirections() |> move gameWorld
                game {gameWorld with Player = player} false        
            | "A" -> game gameWorld true        
            | "Q" -> game gameWorld true
            | _ -> game gameWorld true       

    game gameWorld false