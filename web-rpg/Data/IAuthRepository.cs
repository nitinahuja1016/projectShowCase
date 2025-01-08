namespace web_rpg.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, String password);
        Task<ServiceResponse<String>> Login(String username, String password);
        Task<bool> UserExist(String username);
    }
}
