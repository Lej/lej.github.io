using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfValidationTest.Validation;
using WpfValidationTest.ViewModels;

namespace WpfValidationTest
{
    public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            //ConventionManager.ApplyValidation = (binding, viewModelType, property) =>
            //{
            //    binding.ValidatesOnExceptions = true;
            //    binding.ValidatesOnDataErrors = true;
            //};

            //ConventionManager.ApplyUpdateSourceTrigger += (bindableProperty, element, binding, info) =>
            //{
            //    if (typeof(ValidationViewModel).IsAssignableFrom(info.DeclaringType)
            //       && typeof(TextBox).IsAssignableFrom(element.GetType()))
            //    {
            //        //var viewModel = (ValidationViewModel)info.DeclaringType;
            //        var textBox = (TextBox)element;
            //        //textBox.LostFocus += 
            //    }
            //};

        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<FormViewModel>();
        }
    }
}
