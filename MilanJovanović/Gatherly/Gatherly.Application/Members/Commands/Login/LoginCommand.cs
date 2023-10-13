using Gatherly.Application.Abstractions.Messaging;

namespace Gatherly.Application.Members.Commands.Login;

public sealed record LoginCommand(string Email) : ICommand<string>;
