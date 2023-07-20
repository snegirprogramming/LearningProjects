﻿using Gatherly.Domain.Primitives;
using Gatherly.Domain.ValueObjects;

namespace Gatherly.Domain.Entities;

public sealed class Member : AggregateRoot
{
    private Member(Guid id, Email email, FirstName firstName, LastName lastName)
        : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public Email Email { get; set; }
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }

    public static Member Create(
        Guid id,
        Email email,
        FirstName firstName,
        LastName lastName,
        bool isEmailUnique)
    {
        if (isEmailUnique)
        {
            return null;
        }

        var member = new Member(id, email, firstName, lastName);

        return member;
    }
}