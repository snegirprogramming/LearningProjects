using MediatR;

namespace Gatherly.Application.Members.Commands.CreateMemeber;

public sealed record CreateMemeberCommnad(
    string Email,
    string FirstName, 
    string LastName) : IRequest<Unit>;