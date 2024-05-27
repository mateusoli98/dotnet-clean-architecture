﻿using CleanArchitecture.Application.UseCases.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            //var validator = new CreateUserValidator();
            //var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //if (!validationResult.IsValid)
            //{
            //    var erros = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            //    return BadRequest(new { ErrorMessages = erros });
            //}

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
