using System;
using System.ComponentModel.DataAnnotations;

namespace MessageApp.Web.ViewModels
{
    public class IncomingMessageViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Message text")]
        public string MessageText { get; set; }

        [Display(Name = "Read message")]
        public bool IsReadMessage { get; set; }

        [Display(Name = "Created time")]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "Sender name")]
        public string SenderName { get; set; }
    }
}
