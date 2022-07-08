using FluentValidation;
using Masa.Webaligner.Application.UseCases.CreateAlignment;

namespace Masa.Webaligner.Application.Validators.Alignments
{
    internal class CreateAlignmentValidation :
        AbstractValidator<BaseCreateAlignmentInput>
    {
        public CreateAlignmentValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("E-mail is required.")
                .EmailAddress()
                .WithMessage("Invalid e-mail format.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.");

            RuleFor(x => x.OnlyStageI)
                .NotNull()
                .WithMessage("Must define if only stage I will be processed.");
        }
    }

    /// <summary>
    /// Define a validação do input para requisição de alinhamentos via API NCBI.
    /// </summary>
    public class CreateNcbiAlignmentValidation :
        AbstractValidator<CreateNcbiAlignmentInput>
    {
        /// <summary>
        /// Método construtor de CreateNcbiAlignmentValidation.
        /// </summary>
        public CreateNcbiAlignmentValidation()
        {
            RuleFor(x => x).SetValidator(new CreateAlignmentValidation());

            RuleFor(x => x.FirstSequenceName)
                .NotEmpty()
                .WithMessage("Both sequences names are required.");

            RuleFor(x => x.SecondSequenceName)
                .NotEmpty()
                .WithMessage("Both sequences names are required.");
        }
    }
}
