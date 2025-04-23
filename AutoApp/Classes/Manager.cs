using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AutoApp.Classes
{
    public static class Manager
    {
        public static Frame MainFrame { get; set; }
        public static Data.User CurrentUser { get; set; }
    }
}
