using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        //code behind
        public bool isLoaded = false;
        public MainViewModel()
        {
            if (isLoaded)
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }
            isLoaded = true;
        }
    }
}
