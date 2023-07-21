﻿namespace Gatherly.Presentation.Contracts;

public sealed record RegisterMemberRequest(
    string Email,
    string FirstName,
    string LastName);