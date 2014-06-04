using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfValidationTest.Validation
{
    public class ValidationViewModel : ViewAware, INotifyDataErrorInfo
    {

        /* Errors */
        internal class Error : Tuple<string, string>
        {
            public Error(string propertyName, string errorMessage) : base(propertyName, errorMessage) { }
            public string PropertyName { get { return Item1; } }
            public string ErrorMessage { get { return Item2; } }
        }

        private List<Error> _errors = new List<Error>();

        /* Constructor */
        public ValidationViewModel() : base() {
            PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                Validate(e.PropertyName);
            };
        }

        /* Validation */
        private object _lock = new object();
        private void Validate(string propertyName)
        {
            Task.Factory.StartNew(() =>
            {
                lock (_lock)
                {
                    var context = new ValidationContext(this);
                    var results = new List<ValidationResult>();
                    Validator.TryValidateObject(this, context, results, true);

                    var newErrors = results
                        .SelectMany(result => result.MemberNames, (result, property) => new Error(property, result.ErrorMessage))
                        .Where(error => error.PropertyName == propertyName)
                        .Distinct()
                        .ToList();

                    var oldErrors = _errors;

                    _errors = _errors.Where(error => error.PropertyName != propertyName).Concat(newErrors).ToList();

                    _errors.Union(oldErrors).Except(_errors.Intersect(oldErrors)).ToList().Select(error => error.PropertyName).Distinct().ToList().ForEach(property =>
                    {
                        var handler = ErrorsChanged;
                        if (handler != null)
                        {
                            handler(this, new DataErrorsChangedEventArgs(propertyName));
                        }
                    });
                }
            });
        }

        /* Error Events */
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.Where(error => error.PropertyName == propertyName).Select(error => error.ErrorMessage);
        }

        public bool HasErrors
        {
            get { return _errors.Count > 0; }
        }



    }
}
