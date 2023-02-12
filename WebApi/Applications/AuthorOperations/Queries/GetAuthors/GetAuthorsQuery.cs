using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.Id).ToList();
            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(authors);
            return vm;
        }
    }

    public class AuthorsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? BirthDate { get; set; }
    }
}