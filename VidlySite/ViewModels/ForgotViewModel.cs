using System.ComponentModel.DataAnnotations;

namespace VidlySite.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
