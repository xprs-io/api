using System;
using System.Threading;
using Machine.Specifications;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Extensions;
using XprsIo.API.IdentityProvider.Stores.Interfaces;
using XprsIo.API.IdentityProvider.Stores.Raven.Services;

namespace XprsIo.API.IdentityProvider.Specs.Raven.Services
{
    [Subject(typeof (UserService))]
    public class When_GetUserId
    {
        private Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

        private Because of = () =>
        {
            _result = Machine
                .GetInstance<IUserService>()
                .GetUserIdAsync(_user, CancellationToken.None)
                .Await();
        };

        private It should_be_the_raven_id =
            () => { _result.ShouldEqual("IdentityUsers/1"); };

        private It should_be_qual_to_the_id =
            () => { _user.Id.ShouldEqual("IdentityUsers/1"); };

        private static IdentityUser _user;
        private static string _result;
    }

    [Subject(typeof (UserService))]
    public class When_GetUserName
    {
        private Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

        private Because of = () =>
        {
            _result = Machine
                .GetInstance<IUserService>()
                .GetUserNameAsync(_user, CancellationToken.None)
                .Await();
        };

        private It should_be_the_raven_id_without_the_index_name =
            () => { _result.ShouldEqual("1"); };

        private It should_be_equal_to_the_username =
            () => { _user.GetUserName().ShouldEqual("1"); };

        private static IdentityUser _user;
        private static string _result;
    }

    [Subject(typeof (UserService))]
    public class When_GetUserName_InvalidSource
    {
        private Establish context = () => { _user = new IdentityUser { Id = "1" }; };

        private Because of = () =>
        {
            _exception = Catch.Exception(
                () => Machine
                    .GetInstance<IUserService>()
                    .GetUserNameAsync(_user, CancellationToken.None)
                    .Await()
                );
        };

        private It should_fail =
            () => { _exception.ShouldBeOfExactType<InvalidOperationException>(); };

        private It should_have_a_specific_reason =
            () => { _exception.Message.ShouldContain("invalid"); };

        private static IdentityUser _user;
        private static Exception _exception;
    }

    [Subject(typeof (UserService))]
    public class When_SetUserName
    {
        private Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

        private Because of = () =>
        {
            Machine
                .GetInstance<IUserService>()
                .SetUserNameAsync(_user, "2", CancellationToken.None)
                .Await();
        };

        private It should_be_the_raven_id_without_the_index_name =
            () => { _user.Id.ShouldEqual("IdentityUsers/2"); };

        private It should_be_equal_to_the_username =
            () => { _user.GetUserName().ShouldEqual("2"); };

        private static IdentityUser _user;
    }

    [Subject(typeof (UserService))]
    public class When_SetUserName_Empty
    {
        private Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

        private Because of = () =>
        {
            _exception = Catch.Exception(
                () => Machine
                    .GetInstance<IUserService>()
                    .SetUserNameAsync(_user, string.Empty, CancellationToken.None)
                    .Await()
                );
        };

        private It should_fail =
            () => { _exception.ShouldBeOfExactType<InvalidOperationException>(); };

        private It should_have_a_specific_reason =
            () => { _exception.Message.ShouldContain("empty"); };

        private static IdentityUser _user;
        private static Exception _exception;
    }
}