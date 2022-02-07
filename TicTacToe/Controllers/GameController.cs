/// <summary>
/// TicTacToe API Controller. Defines API endpoints for TicTacToe service
/// </summary>
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TicTacToeApi.TicTacToe.Repositories;
using TicTacToeApi.TicTacToe.Dtos;
using TicTacToeApi.TicTacToe.Entities;


namespace TicTacToeApi.TicTacToe.Controllers
{
    //Controller for game repository
    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly IGamesRepository gameRepo;


        public GameController(IGamesRepository repository)
        {
            this.gameRepo = repository;
        }

        
        [HttpPost]
        [Route("startgame")]
        //Endpoint #1: Starts game using a StartGameDto that requires player names as input.
        //Returns a CreatedGameDto that includes the Game Id and Id of the two players
        public ActionResult<CreatedGameDto> CreateGame(StartGameDto names)
        {

            Game game = new Game(names.Player1Name, names.Player2Name);

            gameRepo.CreateGame(game);

            return game.asCreatedDto();

        }

        [HttpPut]
        [Route("makemove")]
        //Endpoint #2: Registers a players move and updates the game state based on the players Id and
        //the desired board coordinate. Input taken as a MoveDto.
        //Returns a M<oveRepsoneDto containing a visual representation of the boardstate as well as a message notifying
        //the player of a win,tie or exception.
        public ActionResult<MoveResponseDto> UpdateGame(MoveDto moveInput)
        {
            Game currentGame = gameRepo.GetGameFromPlayer(moveInput.PlayerId);

            if (currentGame is not null)
            {
                Player currentPlayer = gameRepo.GetPlayer(currentGame.GameId, moveInput.PlayerId);

                //Check if player id exists in repository
                if (currentPlayer is not null)
                {   
                    //Check to ensure first turn is played by player 1. Current game logic requires p1 to move first 
                    if(currentPlayer.Equals(currentGame.Player2) && currentGame.GameBoard.MoveCount == 0){
                        return BadRequest("Invalid Turn! Player1 Must Start the Game");
                    }
                    //Performs move on board, status variable used to pass information 
                    //to controller to throw errors at presentation level
                    int status = currentGame.MakeMove(currentPlayer, moveInput.Coordinate);

                    //Consecutive turn exception catch
                    if(status == 0){
                        return BadRequest("Invalid Turn! Cannot Play Two Consecutive Turns.");
                    }
                    
                    //Empty space exception catch
                    if(!currentGame.GameBoard.IsEmpty){
                        return BadRequest("Invalid Turn! Please Choose an Empty Space.");
                    }

                    else
                    {   //Successful turn creates move response
                        MoveResponseDto response = new MoveResponseDto
                        {
                            BoardState = currentGame.GameBoard.BoardRep,
                            MoveMessage = currentGame.GameState
                        };

                        //Updates game in repository
                        gameRepo.UpdateGame(currentGame);

                        //Checks for win state. If game is complete it is removed from the repository
                        if(currentGame.EndState == true){
                            gameRepo.DeleteGame(currentGame.GameId);
                        }

                        return response;
                    }
                }
                else
                {
                    return NotFound("Player Id Not Found");
                }
            }
            else
            {
                return NotFound("No Games Contain That Player ID");
            }
        }

        [HttpGet]
        [Route("getgames")]
        //Endpoint #3: Returns a list of currently live games. As games are completed they are removed from the
        //game repository. This endpoint returns all games currently in the gameRepo as GameDtos which includes
        //GameId, PlayerInfo(Ids, Names and Symbol) and current boards state with movecount
        public IList<GameDto> GetGames()
        {
            var games = gameRepo.GetGames().Select(game => game.asGameDto());
            return games.ToList();
        }

    }
}