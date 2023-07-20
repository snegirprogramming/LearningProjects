﻿using Gatherly.Application.Abstractions.Messaging;

namespace Gatherly.Application.Members.Commands.CreateMemeber;

public sealed record CreateMemeberCommand(
    string Email,
    string FirstName, 
    string LastName) : ICommand;