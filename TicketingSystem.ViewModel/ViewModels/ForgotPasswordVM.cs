﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class ForgotPasswordVM
    {
        public string UserName { get; set; }
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Password should be at least 4 characters")]
        public string NewPassword { get; set; }
    }
}
