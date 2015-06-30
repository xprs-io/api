using System;
using Machine.Specifications;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Extensions;

namespace XprsIo.API.DataAccessLayer.Specs.Raven.Extensions
{
    [Subject(typeof (IdentityUserExtensions))]
    public class When_GetUserName
    {
        private Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

        private Because of = () => { _result = _user.GetUserName(); };

        private It should_be_the_username_part_of_the_id =
            () => { _result.ShouldEqual("1"); };

        private static IdentityUser _user;
        private static string _result;
    }

    [Subject(typeof (IdentityUserExtensions))]
    public class When_SetUserName
    {
        private Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

        private Because of = () => { _user.SetUserName("2"); };

        private It should_set_the_id_to_the_username =
            () => { _user.Id.ShouldEqual("IdentityUsers/2"); };

        private static IdentityUser _user;
    }

    [Subject(typeof (IdentityUserExtensions))]
    public class When_Empty_ToIdentityUserId
    {
        private Establish context = () => { _userName = string.Empty; };

        private Because of = () => { _exception = Catch.Exception(() => _userName.ToIdentityUserId()); };

        private It should_fail =
            () => { _exception.ShouldBeOfExactType<InvalidOperationException>(); };

        private It should_have_a_specific_reason =
            () => { _exception.Message.ShouldContain("invalid"); };

        private static string _userName;
        private static Exception _exception;
    }

    [Subject(typeof (IdentityUserExtensions))]
    public class When_Value_ToIdentityUserId
    {
        private Establish context = () => { _userName = "1"; };

        private Because of = () => { _result = _userName.ToIdentityUserId(); };

        private It should_turn_the_username_as_a_valid_raven_id =
            () => { _result.ShouldEqual("IdentityUsers/1"); };

        private static string _userName;
        private static string _result;
    }

    [Subject(typeof (IdentityUserExtensions))]
    public class When_Empty_FromIdentityUserId
    {
        private Establish context = () => { _id = string.Empty; };

        private Because of = () => { _exception = Catch.Exception(() => _id.FromIdentityUserId()); };

        private It should_fail =
            () => { _exception.ShouldBeOfExactType<InvalidOperationException>(); };

        private It should_have_a_specific_reason =
            () => { _exception.Message.ShouldContain("invalid"); };

        private static string _id;
        private static Exception _exception;
    }

    [Subject(typeof (IdentityUserExtensions))]
    public class When_Value_FromIdentityUserId
    {
        private Establish context = () => { _id = "IdentityUsers/1"; };

        private Because of = () => { _result = _id.FromIdentityUserId(); };

        private It should_be_the_username_part_of_the_id =
            () => { _result.ShouldEqual("1"); };

        private static string _id;
        private static string _result;
    }
}