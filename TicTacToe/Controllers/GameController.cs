using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Linq;

using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using TicTacToeApi.TicTacToe.Repositories;
using TicTacToeApi.TicTacToe.Dtos;
using TicTacToeApi.TicTacToe.Entities;
using System.Net.Http;
using System.Net;

namespace TicTacToeApi.TicTacToe.Controllers
{
    //Controller for game repository
    [ApiController]
    [Route("games")]
    public class GameController : ControllerBase
    {
        private readonly IGamesRepository gameRepo;


        public GameController(IGamesRepository repository)
        {
            this.gameRepo = repository;
        }

        //Get /games
        [HttpGet]
        public IList<GameDto> GetGames()
        {
            var games = gameRepo.GetGames().Select(game => game.asGameDto());
            return games.ToList();
        }

        //Get /games/{id}
        [HttpGet("{gameId}")]
        public ActionResult<GameDto> GetGame(Guid gameId)
        {
            var game = gameRepo.GetGame(gameId);

            if (game is not null)
            {
                return game.asGameDto();
            }
            return NotFound();
        }


        [HttpPost]
        public ActionResult<CreatedGameDto> CreateGame(string name1, string name2)
        {

            Game game = new Game(name1, name2);

            gameRepo.CreateGame(game);

            return game.asCreatedDto();

        }


        [HttpPut("{playerId}")]
        public ActionResult<MoveResponseDto> UpdateGame(Guid playerId, int coordinate)
        {

            Game currentGame = gameRepo.GetGameFromPlayer(playerId);

            if (currentGame is not null)
            {

                Player currentPlayer = gameRepo.GetPlayer(currentGame.GameId, playerId);

                if (currentPlayer is not null)
                {
                    int status = currentGame.MakeMove(currentPlayer, coordinate);

                    if (status == 1)
                    {

                        MoveResponseDto response = new MoveResponseDto
                        {
                            BoardState = currentGame.GameBoard.BoardRep,
                            MoveMessage = currentGame.GameState
                        };

                        gameRepo.UpdateGame(currentGame);

                        if(currentGame.EndState == true){
                            gameRepo.DeleteGame(currentGame.GameId);
                        }

                        return response;

                    }
                    else
                    {
                        return BadRequest("Invalid Turn! Choose an empty space or wait for your opponent!");
                    }
                }

                else
                {
                    return NotFound();
                }
            }

            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{gameId}")]
        public ActionResult DeleteGame(Guid gameId){
            
            var existingGame = gameRepo.GetGame(gameId);

            if(existingGame is null){
                return NotFound("Cannot Find Game to Delete");
            }

            gameRepo.DeleteGame(gameId);

            return NoContent();

        }


    }
}