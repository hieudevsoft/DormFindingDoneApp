using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormFinding
{
    class ValidationPassword:ObservableObject
    {
        private string _password;

        [Required(ErrorMessage = "Password must note empty!")]
        [StringLength(maximumLength:50,MinimumLength =6,ErrorMessage ="Miimum Password character is 6 ")]
        public string Password
        {
            get => _password;
            set
            {
                ValidateProperty(value, "Password");
                OnPropertyChanged(ref _password, value);
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
