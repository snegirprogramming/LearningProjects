using Gatherly.Application.Members.Commands.CreateMemeber;
using Gatherly.Application.Members.Queries.GetMemberById;
using Gatherly.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gatherly.Presentation.Controllers;

[Route("api/members")]
public sealed class MembersController : ApiController
{
    public MembersController(ISender sender)
        : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> RegisterMember(CancellationToken cancellationToken)
    {
        var command = new CreateMemeberCommand(
            "milan@milanjovanovic.tech",
            "Milan",
            "Jovanovic");

        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetMemberById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetMemberByIdQuery(id);

        var response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }
}