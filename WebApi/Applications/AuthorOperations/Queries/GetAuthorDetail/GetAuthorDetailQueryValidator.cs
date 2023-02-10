using FluentValidation;
using WebApi.DBOperations;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(query => query.AuthorId).NotEmpty().GreaterThan(0);
        }
    }
}