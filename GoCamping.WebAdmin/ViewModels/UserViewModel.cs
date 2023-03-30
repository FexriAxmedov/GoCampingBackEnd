using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GoCamping.WebAdmin.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
