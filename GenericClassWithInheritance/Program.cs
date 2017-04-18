using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassWithInheritance
{
    public class MainView<T> : System.Windows.Window 
        where T : INotifyPropertyChanged
    {
        public MainView()
        { }
        public MainView(T viewModel)
        { }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
