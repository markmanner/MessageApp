using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageApp.Core.Entities
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string MessageText { get; set; }

        [Required]
        public bool IsReadMessage { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        [Required]
        public string SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        [Required]
        public string RecipientId { get; set; }
        public virtual ApplicationUser Recipient { get; set; }
    }
}
