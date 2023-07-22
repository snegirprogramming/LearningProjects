﻿using Gatherly.Domain.Shared;

namespace Gatherly.Domain.Errors;

public static class DomainErrors
{
    public static class Gathering
    {
        public static Error InvitingCreator => new Error(
            "Gathering.InvitingCreator",
            "Can't send invitation to the gathering creator.");

        public static Error AlreadyPassed => new Error(
            "Gathering.AlreadyPassed",
            "Can't send invitation for the gathering in the past.");

        public static Error Expired => new Error(
            "Gathering.Expired",
            "Invitation is expired.");

        public static Error NotFound(Guid id) => new Error(
            "Gathering.NotFound",
            $"The gathering with the identifier {id} was not found.");
    }

    public static class Invitation
    {
        public static Error AlreadyAccepted(Guid id) => new Error(
            "Invitation.AlreadyAccepted",
            $"The invitation with the identifier {id} is already accepted.");
    }

    public static class Member
    {
        public static Error EmailAlreadyInUse => new Error(
            "Member.EmailAlreadyInUse",
            "Email is already in use.");
    }
}