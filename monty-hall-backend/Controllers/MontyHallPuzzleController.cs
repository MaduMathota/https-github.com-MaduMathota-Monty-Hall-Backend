﻿using Microsoft.AspNetCore.Mvc;
using monty_hall_backend.Entity;


namespace monty_hall_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MontyHallPuzzleController : ControllerBase
    {
        [HttpGet("Simulation/Montyhall")]
        public ActionResult RunSimulation(int simulations, bool changeDoor)
        {
            var simulation = new MontyHallPuzzle(simulations, changeDoor);
            simulation.RunSimulations();
            return Ok(new
            {
                SwitchWinRate = simulation.GetSwitchWinRate(),
                StayWinRate = simulation.GetStayWinRate()

            });
        }
    }
}
