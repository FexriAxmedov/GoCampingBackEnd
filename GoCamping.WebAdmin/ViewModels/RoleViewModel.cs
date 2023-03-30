using System.ComponentModel;

namespace GoCamping.WebAdmin.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [DisplayName("Role adı")]
        public string Name { get; set; }
    }
}
