using System;
using test1.Models;

namespace test1.Entity
{
    public class PostEntity
    {

        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public byte[] BannerImage { get; set; }

        [Required]
        public string Content { get; set; }
        
        public  Post ToModel(PostEntity entity)
        {
            var postmodel =new Post()
            {
                Id=entity.ID,
                Title=entity.Title,
                Content=entity.Content,
                BannerImage=Getfile(entity.BannerImage)
            };
            return postmodel;
        }
        public static IFormFile Getfile(byte[] st){
            using (var stream = new MemoryStream(st))
            {
                var file = new FormFile(stream, 0, st.Length,"rasim","rasim.png")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = ".png",
                };

                return file;
            }
        
        }
    }
}