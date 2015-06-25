using System;

using Machine.Specifications;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Extensions;

namespace XprsIo.API.DataAccessLayer.Specs.Raven.Extensions
{
	[Subject(typeof (IdentityUserExtensions))]
	public class When_GetUserName
	{
		Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

		Because of = () => { _result = _user.GetUserName(); };

		It should_be_the_username_part_of_the_id =
			() => { _result.ShouldEqual("1"); };

		static IdentityUser _user;
		static string _result;
	}

	[Subject(typeof(IdentityUserExtensions))]
	public class When_SetUserName
	{
		Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

		Because of = () => { _user.SetUserName("2"); };

		It should_set_the_id_to_the_username =
			() => { _user.Id.ShouldEqual("IdentityUsers/2"); };

		static IdentityUser _user;
	}

	[Subject(typeof(IdentityUserExtensions))]
	public class When_Empty_ToIdentityUserId
	{
		Establish context = () => { _userName = string.Empty; };

		Because of = () => { _exception = Catch.Exception(() => _userName.ToIdentityUserId()); };

		It should_fail = 
			() => { _exception.ShouldBeOfExactType<InvalidOperationException>(); };
		It should_have_a_specific_reason =
			() => { _exception.Message.ShouldContain("invalid"); };

		static string _userName;
		static Exception _exception;
	}

	[Subject(typeof(IdentityUserExtensions))]
	public class When_Value_ToIdentityUserId
	{
		Establish context = () => { _userName = "1"; };

		Because of = () => { _result = _userName.ToIdentityUserId(); };

		It should_turn_the_username_as_a_valid_raven_id =
			() => { _result.ShouldEqual("IdentityUsers/1"); };

		static string _userName;
		static string _result;
	}

	[Subject(typeof(IdentityUserExtensions))]
	public class When_Empty_FromIdentityUserId
	{
		Establish context = () => { _id = string.Empty; };

		Because of = () => { _exception = Catch.Exception(() => _id.FromIdentityUserId()); };

		It should_fail =
			() => { _exception.ShouldBeOfExactType<InvalidOperationException>(); };
		It should_have_a_specific_reason =
			() => { _exception.Message.ShouldContain("invalid"); };

		static string _id;
		static Exception _exception;
	}

	[Subject(typeof(IdentityUserExtensions))]
	public class When_Value_FromIdentityUserId
	{
		Establish context = () => { _id = "IdentityUsers/1"; };

		Because of = () => { _result = _id.FromIdentityUserId(); };

		It should_be_the_username_part_of_the_id =
			() => { _result.ShouldEqual("1"); };

		static string _id;
		static string _result;
	}
}