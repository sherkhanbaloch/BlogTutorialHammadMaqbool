using System.ComponentModel.DataAnnotations;

namespace BlogTutorialHammadMaqbool.ViewModel
{
    public class ProfileVM
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Bio { get; set; }
        public IFormFile Image { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Not Match.")]
        public string ConfirmPassword { get; set; }
    }
}
