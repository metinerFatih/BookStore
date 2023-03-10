using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public GetBookByIdViewModel Handle()
        {
            var book = _dbContext.Books.Include(x => x.Genre).Where(x => x.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamad─▒");

            GetBookByIdViewModel vm = _mapper.Map<GetBookByIdViewModel>(book);
            //new GetBookByIdViewModel();
            // vm.Title = book.Title;
            // vm.Genre = ((GenreEnum)book.GenreId).ToString();
            // vm.PublishDate = book.PublishDate.Date.ToString("dd/mm/yyy");
            // vm.PageCount = book.PageCount;
            return vm;

        }
    }
    public class GetBookByIdViewModel
    {
        public string Title { get; set; } = null!;
        public int PageCount { get; set; }
        public string Author { get; set; } = null!;
        public string PublishDate { get; set; } = null!;
        public string Genre { get; set; } = null!;
    }
}