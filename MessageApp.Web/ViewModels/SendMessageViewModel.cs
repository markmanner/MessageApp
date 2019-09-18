using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessageApp.Web.ViewModels
{
    public class SendMessageViewModel
    {
        [Required]
        [Display(Name ="Recipient")]
        public string RecipientId { get; set; }

        [Required]
        [Display(Name ="Message")]
        public string MessageText { get; set; }

        public SelectList Users { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "I am sorry, you can't send any more messages today.")]
        public bool IsAvailableMessageSending { get; set; }
    }
}
