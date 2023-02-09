using FluentValidation;

namespace WebApi.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidor : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidor()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
        }
    }
}