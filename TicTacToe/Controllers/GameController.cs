using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Linq;

using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using TicTacToeApi.TicTacToe.Repositories;
using TicTacToeApi.TicTacToe.Dtos;

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

    }
}