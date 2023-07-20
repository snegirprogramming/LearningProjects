using Gatherly.Domain.Shared;

namespace Gatherly.Domain.Errors;

public static class DomainErrors
{
    public static class Gathering
    {
        public static readonly Error InvitingCreator = new Error(
            "Gathering.InvitingCreator",
            "Can't send invitation to the gathering creator.");

        public static readonly Error AlreadyPassed = new Error(
            "Gathering.AlreadyPassed",
            "Can't send invitation for the gathering in the past.");

        public static readonly Error Expired = new Error(
            "Gathering.Expired",
            "Invitation is expired.");
    }

    public static class Member
    {
        public static readonly Error EmailAlreadyInUse = new Error(
            "Member.EmailAlreadyInUse",
            "Email is already in use.");
    }
}