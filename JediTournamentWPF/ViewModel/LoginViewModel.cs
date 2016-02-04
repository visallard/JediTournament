using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            Login = "test";
        }
    }
}
