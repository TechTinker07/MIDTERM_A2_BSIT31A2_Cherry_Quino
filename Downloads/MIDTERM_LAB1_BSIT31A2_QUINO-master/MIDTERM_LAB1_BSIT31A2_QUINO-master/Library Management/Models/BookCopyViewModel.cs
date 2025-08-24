namespace Library_Management.Models
{
    public class BookCopyViewModel
    {
        public Guid Id { get; set; }                // unique identifier ng bawat copy
        public string? Condition { get; set; }      // kondisyon ng libro (e.g., New, Good, Worn)
        public DateTime? PulloutDate { get; set; }  // kung kelan na-pull out
        public string? PulloutReason { get; set; }  // reason ng pag-pull out (Damaged, Lost, etc.)
    }
}
