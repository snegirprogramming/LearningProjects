using Gatherly.Application.Abstractions.Messaging;
using Gatherly.Domain.Shared;

namespace Gatherly.Application.Members.Commands.CreateMember;

public sealed record CreateMemberCommand(
    string Email,
    string FirstName, 
    string LastName) : ICommand<Guid>;