namespace ClassJournal.BusinessLogic.Services.Contracts.Models
{
    public record AuthResult
    {
        public bool Success { get; init; }
        public string Token { get; init; }
        public string Error { get; init; }
    }
}