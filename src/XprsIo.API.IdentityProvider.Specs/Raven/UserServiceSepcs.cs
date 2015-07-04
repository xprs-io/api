using System;
using System.Threading;
using Machine.Specifications;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Extensions;
using XprsIo.API.IdentityProvider.Stores.Interfaces;
using XprsIo.API.IdentityProvider.Stores.Raven;

namespace XprsIo.API.IdentityProvider.Specs.Raven
{
    [Subject(typeof (UserService))]
    public class When_GetUserId
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser;

        private Because of =
            () => _result = Machine
                .GetService<IUserService>()
                .GetUserIdAsync(_user, CancellationToken.None)
                .Await();

        private It should_be_the_raven_id =
            () => _result
                .ShouldEqual(Machine.DefaultGuid.ToString());

        private static IdentityUser _user;
        private static string _result;
    }

    [Subject(typeof (UserService))]
    public class When_GetUserName
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser
                .WithEmail(b => b.WithPrimary(true));

        private Because of =
            () => _result = Machine
                .GetService<IUserService>()
                .GetUserNameAsync(_user, CancellationToken.None)
                .Await();

        private It should_be_the_primary_email =
            () => _result
                .ShouldEqual(Machine.DefaultEmail);

        private static IdentityUser _user;
        private static string _result;
    }

    [Subject(typeof (UserService))]
    public class When_GetUserName_NoPrimary
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser;

        private Because of =
            () => _exception = Catch.Exception(
                () => Machine
                    .GetService<IUserService>()
                    .GetUserNameAsync(_user, CancellationToken.None)
                    .Await()
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

    [Subject(typeof (UserService))]
    public class When_SetUserName
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser
                .WithEmail(b => b.WithPrimary(true));

        private Because of =
            () => Machine
                .GetService<IUserService>()
                .SetUserNameAsync(_user, "override+" + Machine.DefaultEmail, CancellationToken.None)
                .Await();
        
        private It should_be_equal_to_the_username =
            () => _user.GetUserName()
                .ShouldEqual("override+" + Machine.DefaultEmail);

        private static IdentityUser _user;
    }

    [Subject(typeof (UserService))]
    public class When_SetUserName_Empty
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser
                .WithEmail(b => b.WithPrimary(true));

        private Because of =
            () => _exception = Catch.Exception(
                () => Machine
                    .GetService<IUserService>()
                    .SetUserNameAsync(_user, string.Empty, CancellationToken.None)
                    .Await()
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

    [Subject(typeof(UserService))]
    public class When_SetUserName_Invalid
    {
        private Establish context =
            () => _user = Machine
                .IdentityUser
                .WithEmail(b => b.WithPrimary(true));

        private Because of =
            () => _exception = Catch.Exception(
                () => Machine
                    .GetService<IUserService>()
                    .SetUserNameAsync(_user, "not an email", CancellationToken.None)
                    .Await()
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