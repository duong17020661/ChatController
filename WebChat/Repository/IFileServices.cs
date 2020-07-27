
using System.Collections.Generic;
using WebChat.Models;

namespace WebChat.Repository
{
    public interface IFileServices
    {
        PostFileResponse PostFile(FileAndImage file);
        //lấy file theo số lượng
        IEnumerable<FileAndImage> getFile(int amount, string convId);

        //lấy tất cả các file của cuộc trò chuyện
        IEnumerable<FileAndImage> getAllFile(string convId);

        //lấy một số hình ảnh của cuộc trò chuyện
        IEnumerable<FileAndImage> getImage(int amount, string convId);

        //lấy tất cả các ảnh của cuộc trò chuyện
        IEnumerable<FileAndImage> getAllImage(string convId);
    }
}
