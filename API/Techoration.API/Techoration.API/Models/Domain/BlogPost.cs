namespace Techoration.API.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; } 

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Content { get; set; }

        public int FeaturedImageURL { get; set; }

        public int URLHandle { get; set; }

        public DateTime PublishedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string Author { get; set; }

        public bool IsVisible { get; set; }
    }
}
