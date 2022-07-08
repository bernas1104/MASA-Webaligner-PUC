using Bogus;
using Masa.Webaligner.Application.UseCases.CreateAlignment;
using Masa.Webaligner.Core.Entities;
using Masa.Webaligner.Core.Enums;

namespace Masa.Webaligner.Shared.Applications
{
    public static class CreateAlignmentsMock
    {
        private static Faker<TCreateAlignment> BaseAlignmentInputFaker<TCreateAlignment>()
            where TCreateAlignment : BaseCreateAlignmentInput =>
            new Faker<TCreateAlignment>()
                .RuleFor(x => x.Email, f => f.Internet.Email())
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(
                    x => x.LastName,
                    f => f.Random.Bool() ?
                        f.Person.LastName :
                        null
                )
                .RuleFor(x => x.OnlyStageI, f => f.Random.Bool());

        public static Faker<CreateNcbiAlignmentInput> CreateNcbiAlignmentInputFaker =>
            new Faker<CreateNcbiAlignmentInput>()
                .CustomInstantiator(f => {
                    return BaseAlignmentInputFaker<CreateNcbiAlignmentInput>()
                        .RuleFor(x => x.FirstSequenceName, "MT126808.1")
                        .RuleFor(x => x.SecondSequenceName, "NC_045512.2");
                });

        public static Faker<CreateAlignmentOutput> CreateAlignmentOutputFaker =>
            new Faker<CreateAlignmentOutput>()
                .CustomInstantiator(f => {
                    var user = new User(
                        null,
                        f.Internet.Email(),
                        f.Person.FirstName,
                        f.Person.LastName
                    );
                    var alignment = new NcbiAlignment(
                        user,
                        f.Random.Bool(),
                        AlignmentStatus.Requested,
                        "MT126808.1",
                        "NC_045512.2"
                    );

                    return CreateAlignmentOutput.FromEntity(alignment);
                });
    }
}
