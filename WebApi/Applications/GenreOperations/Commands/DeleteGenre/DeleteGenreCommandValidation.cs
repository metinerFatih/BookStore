using FluentValidation;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatior : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidatior()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}