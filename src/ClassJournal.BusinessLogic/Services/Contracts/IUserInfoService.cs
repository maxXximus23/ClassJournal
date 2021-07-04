namespace ClassJournal.BusinessLogic.Services.Contracts
{
    public interface IUserInfoService
    {
        string Username { get; }
        string Role { get; }
        int Id { get; }
        bool IsLoggedIn { get; }
    }
}