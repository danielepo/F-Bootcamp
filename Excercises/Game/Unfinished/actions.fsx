
#load "../Core/models.fsx"
#load "../Core/gameWorld.fsx"

module Actions =
    open Models
    open GameWorld
    let exrtactId (room: RoomId)= 
        let (RoomId roomId) = room
        roomId 
    let move (gameWorld:World) (direction:Direction):Player  =
        // trova l'id della location del player
        // trova l'uscita 
        // se attraversabile rova la nuova stanza
        // creare umn nuovo player nella nuova stanza
        printf "Player Can't do this action"
        player

    let look gameWorld (direction:Direction)  =
        printf "Player Can't do this action"

    let openExit gameWorld (exit:Exit) =
        printf "Player Can't do this action"