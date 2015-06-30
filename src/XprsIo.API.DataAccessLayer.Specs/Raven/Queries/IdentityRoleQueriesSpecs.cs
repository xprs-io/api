using System.Linq;
using Machine.Specifications;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven.Queries;
using XprsIo.API.DataAccessLayer.Specs.Extensions;

namespace XprsIo.API.DataAccessLayer.Specs.Raven.Queries
{
    [Subject(typeof (IdentityRoleQueries))]
    public class When_QueryIdentityRoleByName
    {
        private Establish context = () =>
        {
            _repository = Enumerable.Range(1, 3)
                .Select(i => new IdentityRole { Id = i, Name = i.ToString() })
                .ToQueryableRepository();
        };

        private Because of = () => { _result = _repository.QueryByName("2").ToArray(); };

        private It should_contain_a_single_value =
            () => { _result.Length.ShouldEqual(1); };

        private It should_be_a_user_with_id_2 =
            () => { _result[0].Id.ShouldEqual(2); };

        private static IQueryableRepository<IdentityRole> _repository;
        private static IdentityRole[] _result;
    }
}