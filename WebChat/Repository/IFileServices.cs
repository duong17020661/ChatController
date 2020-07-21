
using WebChat.Models;

namespace WebChat.Repository
{
    public interface IFileServices
    {
        PostFileResponse PostFile(FileAndImage file);
    }
}
