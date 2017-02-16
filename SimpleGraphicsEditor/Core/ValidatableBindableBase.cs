namespace SimpleGraphicsEditor.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents a base class which can be used to validate a ViewModel.
    /// Derived from <see cref="BindableBase" /> which ensures that the
    /// ViewModel of this type will still be a <see cref="BindableBase" />.
    /// </summary>
    public class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo
    {
        /// <summary>
        /// A collection which holds the validaion errors for the ViewModel
        /// </summary>
        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        /// <summary>
        /// An event fires when Error collection has modified.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = (obj, eventArgs) => { };

        /// <summary>
        /// Gets a value indicating whether flag which inidicates whether ViewModel has validation errors.
        /// </summary>
        public bool HasErrors
        {
            get { return this.errors.Count > 0; }
        }

        /// <summary>
        /// Returns all validation errors for a property in the ViewModel
        /// </summary>
        /// <param name="propertyName">Name of the property in the ViewModel</param>
        /// <returns>Collection of Validation errors for a property</returns>
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (this.errors.ContainsKey(propertyName))
            {
                return this.errors[propertyName];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Overridden version of SetProperty method from <see cref="BindableBase"/>
        /// </summary>
        /// <typeparam name="T">The type of the ViewModel</typeparam>
        /// <param name="member">Property of the ViewModel which has been changed.</param>
        /// <param name="val">Value assigned to property.</param>
        /// <param name="propertyName">Name of the property obtained via Compiler Options</param>
        protected override void SetProperty<T>(
            ref T member,
            T val,
            [CallerMemberName] string propertyName = null)
        {
            base.SetProperty<T>(ref member, val, propertyName);
            this.ValidateProperty(propertyName, val);
        }

        /// <summary>
        /// Validates properties of ViewModel based on their attributes
        /// </summary>
        /// <typeparam name="T">The type of the ViewModel</typeparam>
        /// <param name="propertyName">Property of the ViewModel which has been changed.</param>
        /// <param name="value">Value assigned to property.</param>
        private void ValidateProperty<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
            context.MemberName = propertyName;
            Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {
                this.errors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
            }
            else
            {
                this.errors.Remove(propertyName);
            }

            this.ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
