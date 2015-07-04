using System;
using System.Linq;
using Machine.Specifications;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Extensions;

namespace XprsIo.API.DataAccessLayer.Specs.Raven.Extensions
{
    [Subject(typeof (IdentityUserExtensions))]
    public class When_GetUserName
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser
                .WithEmail(b => b.WithPrimary(true));

        private Because of =
            () => _result = _user
                .GetUserName();

        private It should_be_the_primary_email =
            () => _result
                .ShouldEqual(Machine.DefaultEmail);

        private static IdentityUser _user;
        private static string _result;
    }

    public class When_GetUserName_NoPrimary
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser
                .WithEmail();

        private Because of =
            () => _exception = Catch.Exception(
                () => _user
                    .GetUserName()
            );

        private It should_fail =
            () => _exception
                .ShouldBeOfExactType<InvalidOperationException>();

        private It should_have_a_specific_reason =
            () => _exception.Message
                .ShouldContain("no primary email");

        private static IdentityUser _user;
        private static Exception _exception;
    }

    [Subject(typeof (IdentityUserExtensions))]
    public class When_SetUserName
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser
                .WithEmail(b => b.WithPrimary(true));

        private Because of =
            () => _user
                .Mutate()
                .SetUserName("override+" + Machine.DefaultEmail);

        private It should_add_a_new_primary_email =
            () => _user.Emails.First(e => e.IsPrimary).Email
                .ShouldEqual("override+" + Machine.DefaultEmail);

        private It should_have_the_previous_email_as_secondary =
            () => _user.Emails.First(e => !e.IsPrimary).Email
                .ShouldEqual(Machine.DefaultEmail);

        private static IdentityUser _user;
   }

    [Subject(typeof(IdentityUserExtensions))]
    public class When_SetUserName_First
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser;

        private Because of =
            () => _user
                .Mutate()
                .SetUserName("override+" + Machine.DefaultEmail);

        private It should_add_a_new_primary_email =
            () => _user.Emails.First(e => e.IsPrimary).Email
                .ShouldEqual("override+" + Machine.DefaultEmail);

        private It should_have_no_secondary_emails =
            () => _user.Emails.Any(e => !e.IsPrimary)
                .ShouldBeFalse();

        private static IdentityUser _user;
    }

    [Subject(typeof(IdentityUserExtensions))]
    public class When_SetUserName_Empty
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser
                .WithEmail(b => b.WithPrimary(true));

        private Because of =
            () => _exception = Catch.Exception(
                () => _user
                    .Mutate()
                    .SetUserName(string.Empty)
            );

        private It should_fail =
            () => _exception
                .ShouldBeOfExactType<InvalidOperationException>();

        private It should_have_a_specific_reason =
            () => _exception.Message
                .ShouldContain("empty");

        private static IdentityUser _user;
        private static Exception _exception;
    }

    [Subject(typeof(IdentityUserExtensions))]
    public class When_SetUserName_Invalid
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser
                .WithEmail(b => b.WithPrimary(true));

        private Because of =
            () => _exception = Catch.Exception(
                () => _user
                    .Mutate()
                    .SetUserName("not an email")
            );

        private It should_fail =
            () => _exception
                .ShouldBeOfExactType<InvalidOperationException>();

        private It should_have_a_specific_reason =
            () => _exception.Message
                .ShouldContain("invalid");

        private static IdentityUser _user;
        private static Exception _exception;
    }
}