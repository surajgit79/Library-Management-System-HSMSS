namespace LibraryManagementAPI.Models
{
    public class BookIssue
    {
        public int BookIssueId { get; set; }
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }
        public bool Status { get; set; } = true;

        // Navigation properties
        public Book? Book { get; set; }
        public Student? Student { get; set; }
    }
}