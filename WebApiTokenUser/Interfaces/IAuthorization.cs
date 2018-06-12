namespace WebApiTokenUser.Interfaces
{
    public interface IAuthorization
    {
        string Authorize(string login, string password);
    }
}
