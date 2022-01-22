using System;
using System.Data;
using test1.Models;
using static System.Net.Mime.MediaTypeNames;

namespace test1.Entity
{
    public class PostEntity
    {

        public Guid ID { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public byte[] BannerImage { get; set; }

        [Required]
        public string Content { get; set; }

        public Post ToModel(PostEntity entity)
        {
            var postmodel = new Post()
            {
                Id = entity.ID,
                Title = entity.Title,
                Content = entity.Content,
                BannerImage = getimage(entity.BannerImage)

            };
            return postmodel;
        }
        public static IFormFile getimage(byte[] data)
        {
            var stream = new MemoryStream(data);
            IFormFile file = new FormFile(stream, 0, data.Length, "Raim.jpg", ".jpg");
            return file;
        }
    }
}