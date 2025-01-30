﻿using System.ComponentModel.DataAnnotations;

namespace BlogTutorialHammadMaqbool.ViewModel
{
    public class LoginVM
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
