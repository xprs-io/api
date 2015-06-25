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
		Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

		Because of = () =>
		{
			_result = Machine
				.GetInstance<IUserService>()
				.GetUserIdAsync(_user, CancellationToken.None)
				.Await();
		};

		It should_be_the_raven_id =
			() => { _result.ShouldEqual("IdentityUsers/1"); };
		It should_be_qual_to_the_id =
			() => { _user.Id.ShouldEqual("IdentityUsers/1"); };

		static IdentityUser _user;
		static string _result;
	}

	[Subject(typeof(UserService))]
	public class When_GetUserName
	{
		Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

		Because of = () =>
		{
			_result = Machine
				.GetInstance<IUserService>()
				.GetUserNameAsync(_user, CancellationToken.None)
				.Await();
		};

		It should_be_the_raven_id_without_the_index_name =
			() => { _result.ShouldEqual("1"); };
		It should_be_equal_to_the_username =
			() => { _user.GetUserName().ShouldEqual("1"); };

		static IdentityUser _user;
		static string _result;
	}

	[Subject(typeof(UserService))]
	public class When_GetUserName_InvalidSource
	{
		Establish context = () => { _user = new IdentityUser { Id = "1" }; };

		Because of = () =>
		{
			_exception = Catch.Exception(() =>Machine
				.GetInstance<IUserService>()
				.GetUserNameAsync(_user, CancellationToken.None)
				.Await()
			);
		};

		It should_fail =
			() => { _exception.ShouldBeOfExactType<InvalidOperationException>(); };
		It should_have_a_specific_reason =
			() => { _exception.Message.ShouldContain("invalid"); };

		static IdentityUser _user;
		static Exception _exception;
	}

	[Subject(typeof(UserService))]
	public class When_SetUserName
	{
		Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

		Because of = () =>
		{
			Machine
				.GetInstance<IUserService>()
				.SetUserNameAsync(_user, "2", CancellationToken.None)
				.Await();
		};

		It should_be_the_raven_id_without_the_index_name =
			() => { _user.Id.ShouldEqual("IdentityUsers/2"); };
		It should_be_equal_to_the_username =
			() => { _user.GetUserName().ShouldEqual("2"); };

		static IdentityUser _user;
	}

	[Subject(typeof(UserService))]
	public class When_SetUserName_Empty
	{
		Establish context = () => { _user = new IdentityUser { Id = "IdentityUsers/1" }; };

		Because of = () =>
		{
			_exception = Catch.Exception(() => Machine
				.GetInstance<IUserService>()
				.SetUserNameAsync(_user, string.Empty, CancellationToken.None)
				.Await()
			);
		};

		It should_fail =
			() => { _exception.ShouldBeOfExactType<InvalidOperationException>(); };
		It should_have_a_specific_reason =
			() => { _exception.Message.ShouldContain("empty"); };

		static IdentityUser _user;
		static Exception _exception;
	}
}