using JobStation.Core;
using JobStation.Core.Domain;
using JobStation.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobStation.API.Controllers
{
    public class LogInHistoryController : ControllerBase
    {
        private readonly IunitOfWork unitOfWork;

        public LogInHistoryController(IunitOfWork unitOfWork
            )
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("{Userid}")]
        public async Task<IActionResult> Post(string Userid)
        {
            var logInHistory = new LogInHistory()
            {
                UserId = Userid,
                CreatedOn = DateTime.Now
            };

            unitOfWork.LogInHistoryRepository.Add(logInHistory);
            var result = await unitOfWork.SaveChangesAsync();
            if (result > 0)
            {
                var resultCondition = await unitOfWork.SaveChangesAsync();
                if (resultCondition > 0)
                    return StatusCode(StatusCodes.Status201Created, new Response<LogInHistory>());
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
