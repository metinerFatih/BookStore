using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x => x.Genre).Include(x => x.Author).OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            //new List<BooksViewModel>();
            // foreach (var book in bookList)
            // {
            //     vm.Add(new BooksViewModel()
            //     {
            //         Title = book.Title,
            //         Genre = ((GenreEnum)book.GenreId).ToString(),
            //         PublishDate = book.PublishDate.Date.ToString("dd/mm/yyy"),
            //         PageCount = book.PageCount
            //     });
            // }
            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; } = null!;
        public int PageCount { get; set; }
        public string Author { get; set; } = null!;
        public string PublishDate { get; set; } = null!;
        public string Genre { get; set; } = null!;
    }
}