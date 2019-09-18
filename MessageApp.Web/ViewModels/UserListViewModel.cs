using System.ComponentModel.DataAnnotations;

namespace MessageApp.Web.ViewModels
{
    public class UserListViewModel
    {
        public string Id { get; set; }

        [Display(Name ="UserName")]
        public string UserName { get; set; }
    }
}
