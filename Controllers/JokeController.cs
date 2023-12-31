﻿using JokeWebApp.JokeApi;
using JokeWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JokeWebApp.Controllers
{
    public class JokeController : Controller
    {
        private readonly IJokeService _jokeService;
        public JokeController(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> GetJokeFromApi()
        {
            var results = await GetRandomJoke.GetJoke();

            await _jokeService.SaveJokeToDatabase(results);
            ViewData["Joke"] = results;
            return View("User");
        }
        [AllowAnonymous]

        public async Task<IActionResult> GetAllJokesFromDatabase()
        {
            var results = await _jokeService.GetJokesFromDatabase();
            ViewData["Jokes"] = results;
            return View("JokesList");
        }
    }
}
