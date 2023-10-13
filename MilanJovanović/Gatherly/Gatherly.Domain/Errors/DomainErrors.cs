using Gatherly.Domain.Shared;

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

        public static Error NotFound(Guid id) => new Error(
            "Member.NotFound",
            $"The member with the identifier {id} was not found.");

        public static Error InvalidCredentials => new Error(
            "Member.InvalidCredentials",
            "Email credentials are not valid.");
    }

    public static class Email
    {
        public static Error Empty => new Error(
            "Email.Empty",
            "Email is empty.");

        public static Error TooLong => new Error(
            "Email.TooLong",
            "Email is too long.");

        public static Error InvalidFormat => new Error(
            "Email.InvalidFormat",
            "Email has invalid format.");
    }
}