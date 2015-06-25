using System;
using System.Linq;
using Machine.Specifications;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven.Extensions;
using XprsIo.API.DataAccessLayer.Providers.Raven.Queries;
using XprsIo.API.DataAccessLayer.Specs.Extensions;

namespace XprsIo.API.DataAccessLayer.Specs.Raven.Queries
{
	[Subject(typeof (IdentityUserQueries))]
	public class When_QueryByUserName
	{
		Establish context = () =>
		{
			_repository = Enumerable.Range(1, 3)
				.Select(i => new IdentityUser { Id = i.ToString().ToIdentityUserId() })
				.ToQueryableRepository();
		};

		Because of = () => { _result = _repository.QueryByUserName("2").ToArray(); };

		It should_contain_a_single_value =
			() => { _result.Length.ShouldEqual(1); };
		It should_be_a_user_with_id_2 =
			() => { _result[0].Id.ShouldEqual("2".ToIdentityUserId()); };

		static IQueryableRepository<IdentityUser> _repository;
		static IdentityUser[] _result;
	}
}