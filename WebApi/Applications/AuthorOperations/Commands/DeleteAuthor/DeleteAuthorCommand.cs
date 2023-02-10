using WebApi.DBOperations;

namespace WebApi.Applications.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(BookStoreDbContext context)
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

            _context.Remove(author);
            _context.SaveChanges();
        }
    }
}