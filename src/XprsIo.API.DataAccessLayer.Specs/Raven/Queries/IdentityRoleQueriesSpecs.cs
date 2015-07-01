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
        private Establish context =
            () => _repository = Enumerable
                .Range(1, 3)
                .Select(i => (IdentityRole)Machine
                    .IdentityRole
                    .WithId(i)
                    .WithName(i.ToString())
                )
                .ToQueryableRepository();

        private Because of =
            () => _result = _repository
                .QueryByName("2")
                .ToArray();

        private It should_contain_a_single_value =
            () => _result.Length
                .ShouldEqual(1);

        private It should_be_a_user_with_id_2 =
            () => _result.First().Id
                .ShouldEqual(2);

        private static IQueryableRepository<IdentityRole> _repository;
        private static IdentityRole[] _result;
    }

    [Subject(typeof(IdentityRoleQueries))]
    public class When_QueryIdentityRoleByName_EmptySource
    {
        private Establish context =
            () => _repository = Enumerable
                .Empty<IdentityRole>()
                .ToQueryableRepository();

        private Because of =
            () => _result = _repository
                .QueryByName("2")
                .ToArray();

        private It should_be_empty =
            () => _result.Length
                .ShouldEqual(0);

        private static IQueryableRepository<IdentityRole> _repository;
        private static IdentityRole[] _result;
    }

    [Subject(typeof(IdentityRoleQueries))]
    public class When_QueryIdentityRoleByName_NoMatch
    {
        private Establish context =
            () => _repository = Enumerable
                .Range(1, 3)
                .Select(i => (IdentityRole)Machine
                    .IdentityRole
                    .WithId(i)
                    .WithName(i.ToString())
                )
                .ToQueryableRepository();

        private Because of =
            () => _result = _repository
                .QueryByName("0")
                .ToArray();

        private It should_be_empty =
            () => _result.Length
                .ShouldEqual(0);

        private static IQueryableRepository<IdentityRole> _repository;
        private static IdentityRole[] _result;
    }
}