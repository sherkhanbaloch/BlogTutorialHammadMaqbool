namespace BlogTutorialHammadMaqbool.ViewModel
{
    public class PostVM
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public IFormFile Image { get; set; }
        public string Slug { get; set; }
    }
}
