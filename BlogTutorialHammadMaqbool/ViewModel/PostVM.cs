using System.ComponentModel;

namespace BlogTutorialHammadMaqbool.ViewModel
{
    public class PostVM
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }

        [DisplayName("Cover Image")]
        public IFormFile Image { get; set; }
        public string Slug { get; set; }
    }
}
