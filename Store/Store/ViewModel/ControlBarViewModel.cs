using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Store.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        #region commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }
        public ICommand MouseLeftButtonDownCommand { get; set; }

        #endregion

        public ControlBarViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                if ((window as Window) != null)
                    (window as Window).Close();
            });
            MaximizeCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                Window w = window as Window;
                if (w != null)
                {
                    if (w.WindowState == WindowState.Normal)
                        w.WindowState = WindowState.Maximized;
                    else
                        w.WindowState = WindowState.Normal;
                }
            });
            MinimizeCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                if ((window as Window) != null)
                    (window as Window).WindowState = WindowState.Minimized;
            });
            MouseLeftButtonDownCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                if ((window as Window) != null)
                    (window as Window).DragMove();
            });
        }
        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;

            while(parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement; 
            }

            return parent;
        }
    }
}
