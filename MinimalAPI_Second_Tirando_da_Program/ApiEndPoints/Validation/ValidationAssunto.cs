using FluentValidation;
using MinimalAPI_Second_Tirando_da_Program.Models;

namespace MinimalAPI_Second_Tirando_da_Program.ApiEndPoints.Validation
{
    public class ValidationAssunto : AbstractValidator<Assunto>
    {
        public ValidationAssunto()
        {
            RuleFor(x => x.CodAs).NotEmpty();
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("Não pode ser vazio.");
        }
    }
}
