using System;
using System.Linq;
using Machine.Specifications;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven.Queries;
using XprsIo.API.DataAccessLayer.Specs.Extensions;

namespace XprsIo.API.DataAccessLayer.Specs.Raven.Queries
{
    [Subject(typeof (IdentityUserQueries))]
    public class When_QueryIdentityUserByUserName
    {
        private Establish context =
            () => _repository = _ids
                .Select((g, i) => (IdentityUser)Machine
                    .IdentityUser
                    .WithId(g)
                    .WithEmail(b => b
                        .WithEmail(i.ToString() + "+" + Machine.DefaultEmail)
                        .WithPrimary(true)
                    )
                )
                .ToQueryableRepository();

        private Because of =
            () => _result = _repository
                .QueryByUserName("2+" + Machine.DefaultEmail)
                .ToArray();

        private It should_contain_a_single_value =
            () => _result.Length
                .ShouldEqual(1);

        private It should_be_a_user_with_matching_primary_email =
            () => _result.First().Emails.First(e => e.IsPrimary).Email
                .ShouldEqual("2+" + Machine.DefaultEmail);

        private static Guid[] _ids =
        {
            new Guid("b45f62eb-dfed-4cd1-ae3f-39f8c545c6da"),
            new Guid("5cfd72b2-5306-49ff-a789-6e18fe15bb22"),
            new Guid("6223c78a-e95f-47e3-98ed-bf7d673d75c7")
        };
        private static IQueryableRepository<IdentityUser> _repository;
        private static IdentityUser[] _result;
    }

    [Subject(typeof(IdentityUserQueries))]
    public class When_QueryIdentityUserByUserName_EmptySource
    {
        private Establish context =
            () => _repository = Enumerable
                .Empty<IdentityUser>()
                .ToQueryableRepository();

        private Because of =
            () => _result = _repository
                .QueryByUserName(Machine.DefaultEmail)
                .ToArray();

        private It should_be_empty =
            () => _result.Length
                .ShouldEqual(0);

        private static IQueryableRepository<IdentityUser> _repository;
        private static IdentityUser[] _result;
    }

    [Subject(typeof(IdentityUserQueries))]
    public class When_QueryIdentityUserByUserName_NoMatch
    {
        private Establish context =
            () => _repository = _ids
                .Select((g, i) => (IdentityUser)Machine
                    .IdentityUser
                    .WithId(g)
                    .WithEmail(b => b
                        .WithEmail(i.ToString() + "+" + Machine.DefaultEmail)
                        .WithPrimary(true)
                    )
                )
                .ToQueryableRepository();

        private Because of =
            () => _result = _repository
                .QueryByUserName("0+" + Machine.DefaultEmail)
                .ToArray();

        private It should_be_empty =
            () => _result.Length
                .ShouldEqual(0);
        
        private static Guid[] _ids =
        {
            new Guid("b45f62eb-dfed-4cd1-ae3f-39f8c545c6da"),
            new Guid("5cfd72b2-5306-49ff-a789-6e18fe15bb22"),
            new Guid("6223c78a-e95f-47e3-98ed-bf7d673d75c7")
        };
        private static IQueryableRepository<IdentityUser> _repository;
        private static IdentityUser[] _result;
    }

    [Subject(typeof(IdentityUserQueries))]
    public class When_QueryIdentityUserByUserName_LookingForSecondaryEmail
    {
        private Establish context =
            () => _repository = _ids
                .Select((g, i) => (IdentityUser)Machine
                    .IdentityUser
                    .WithId(g)
                    .WithEmail(b => b
                        .WithEmail("1" + i.ToString() + "+" + Machine.DefaultEmail)
                        .WithPrimary(true)
                    )
                    .WithEmail(b => b.WithEmail("2" + i.ToString() + "+" + Machine.DefaultEmail))
                    .WithEmail(b => b.WithEmail("3" + i.ToString() + "+" + Machine.DefaultEmail))
                )
                .ToQueryableRepository();

        private Because of =
            () => _result = _repository
                .QueryByUserName("12+" + Machine.DefaultEmail)
                .ToArray();

        private It should_be_empty =
            () => _result.Length
                .ShouldEqual(0);

        private static Guid[] _ids =
        {
            new Guid("b45f62eb-dfed-4cd1-ae3f-39f8c545c6da"),
            new Guid("5cfd72b2-5306-49ff-a789-6e18fe15bb22"),
            new Guid("6223c78a-e95f-47e3-98ed-bf7d673d75c7")
        };
        private static IQueryableRepository<IdentityUser> _repository;
        private static IdentityUser[] _result;
    }
}