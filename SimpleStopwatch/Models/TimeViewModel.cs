namespace SimpleStopwatch.Models
{
    public record TimeViewModel
    {
        public int Milliseconds { get; init; }

        public string? TimeToPrint { get; set; }
    }
}
