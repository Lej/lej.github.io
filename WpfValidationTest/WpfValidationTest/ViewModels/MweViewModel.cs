using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfValidationTest.Validation
{
    public class MweViewModel : PropertyChangedBase
    {
        public MweViewModel() : base()
        {
            PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                // Find control (i.e. TextBox) bound to e.PropertyName
                //TextBox textBox = ...
            };
        }
    }
}
