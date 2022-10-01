using NZWalkTutorial.Models.Domains;

namespace NZWalkTutorial.Repositories
{
    public interface Itokenhandler
    {
        Task<string> Createtokenasync(User user);
    }
}
