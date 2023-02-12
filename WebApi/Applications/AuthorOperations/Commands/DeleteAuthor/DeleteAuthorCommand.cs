using WebApi.DBOperations;

namespace WebApi.Applications.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _context;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Silinecek yazar bulunamadı.");
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}