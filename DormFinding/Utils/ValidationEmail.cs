using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormFinding
{
    class ValidationEmail : ObservableObject
    {
        private string _email;

        [Required(ErrorMessage = "Email must note empty!")]
        [EmailAddress(ErrorMessage = "Email invalid!")]
        public string Email
        {
            get => _email;
            set
            {
                ValidateProperty(value, "Email");
                OnPropertyChanged(ref _email, value);
            }
        }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }
    }
}

