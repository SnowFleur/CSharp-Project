using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ServerMonitor
{
    class CWindowController
    {
        TextBox         monitorTextBox_;
        ScrollViewer    monitorScroll_;

        public CWindowController(TextBox MonitorTextBox, ScrollViewer MonitorScroll) {

            monitorTextBox_ = MonitorTextBox;
            monitorScroll_  = MonitorScroll;
            

        
        }


        private void CallBack_ReceiveData(object sender, EventArgs e) { 
        
        
        }



    }
}
