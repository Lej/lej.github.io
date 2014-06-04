using Caliburn.Micro;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfValidationTest.Validation;

namespace WpfValidationTest.ViewModels
{
    public class FormViewModel : ValidationViewModel
    {
        private string _personnummer;
        [Required(ErrorMessage = "Personnummer är obligatoriskt")]
        [RegularExpression(@"^(18|19|20)\d{6}-\d{4}$", ErrorMessage = "Ogiltigt personnummer")]
        public string Personnummer
        {
            get { return _personnummer; }
            set
            {
                _personnummer = value;
                NotifyOfPropertyChange(() => Personnummer);
            }
        }

        private string _namn;
        [Required(ErrorMessage="Namn är obligatoriskt")]
        [StringLength(10, MinimumLength=3, ErrorMessage="Namn måste vara 3-10 tecken")]
        public string Namn
        {
            get { return _namn; }
            set
            {
                _namn = value;
                NotifyOfPropertyChange(() => Namn);
            }
        }

    }
}
