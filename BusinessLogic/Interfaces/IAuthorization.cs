namespace BusinessLogic.Interfaces
{
    public interface IAuthorization
    {
        string Authorize(string login, string password);
    }
}
