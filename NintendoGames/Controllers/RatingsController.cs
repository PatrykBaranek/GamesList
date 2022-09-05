﻿using Microsoft.AspNetCore.Mvc;
using NintendoGames.Models.RatingModels;
using NintendoGames.Services.RatingService;

namespace NintendoGames.Controllers
{
    [ApiController]
    [Route("api/games/{gameId:guid}/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPatch("updateUserScoreDto")]
        public async Task<ActionResult> UpdateUserScore([FromRoute] Guid gameId, [FromBody] UpdateUserScoreDto updateUserScoreDto)
        {
            await _ratingService.UpdateUserScore(gameId, updateUserScoreDto);

            return Ok();
        }
    }
}