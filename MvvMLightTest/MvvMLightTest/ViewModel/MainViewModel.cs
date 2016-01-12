using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvMLightTest.ViewModel
{
    public class MainViewModel
    {
        public string MSG { get; set; }
        public MainViewModel()
        {
            MSG = "Test message";
        }
    }
}
