global using System.Reflection;
global using System.ComponentModel.DataAnnotations;
using test1.Entity;

namespace test1.Models
{
    public class Post
    {
        public Guid Id{ get; set;}=Guid.NewGuid();
        public IFormFile BannerImage{ get; set;}
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public  PostEntity ToEntity(Post model)
        {
            var post =new PostEntity()
            {
                ID=model.Id,
                Title=model.Title,
                Content=model.Content,
            //     BannerImage=GetImageEntity(model.BannerImage)
            // };
            };
            return post;
        }
            // private static byte[] GetImageEntity(IFormFile file)
            // {
            // using var stream = new MemoryStream();

            // // file.CopyTo(stream);
            // // var Data = stream.Read();
            // // return Data;
            // }
        
    }
}