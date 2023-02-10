using AutoMapper;
using WebApi.Applications.AuthorOperations.Command.CreateAuthor;
using WebApi.Applications.AuthorOperations.Queries.GetAuthors;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.BookOperations.GetBooks;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Common.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookByIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, GetBookByIdViewModel>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
        }
    }
}