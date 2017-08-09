﻿using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Operations;
using Finances.Infrastructure.DTO;
using Finances.Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    [Route("[controller]")]
    public class OperationController : ApiBaseController
    {
        private readonly IOperationServices _operationServices;

        public OperationController(IOperationServices operationServices, ICommandDispatcher commandDispatcher)
            :base(commandDispatcher)
        {
            _operationServices = operationServices;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAsync(string name)
        {
            var operation = await _operationServices.GetAsync(name);

            return Json(operation);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOperation command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"operation/{command.Name}", new object());
        }
    }
}
