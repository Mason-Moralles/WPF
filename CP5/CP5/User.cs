using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace CP5
{
    public class User : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private string email;
        private string password;
        private int age;
        private readonly Dictionary<string, List<string>> _errors = new();

        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                    ValidateEmail();
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                    ValidatePassword();
                }
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged(nameof(Age));
                    ValidateAge();
                }
            }
        }

        public bool HasErrors => _errors.Any();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void OnErrorsChanged(string propertyName) =>
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.Values.SelectMany(x => x);
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        private void ValidateEmail()
        {
            _errors.Remove(nameof(Email));
            if (string.IsNullOrWhiteSpace(Email))
                _errors[nameof(Email)] = new() { "Email is required" };
            else if (!Regex.IsMatch(Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                _errors[nameof(Email)] = new() { "Invalid email format" };
            OnErrorsChanged(nameof(Email));
        }

        private void ValidatePassword()
        {
            _errors.Remove(nameof(Password));
            if (string.IsNullOrWhiteSpace(Password))
                _errors[nameof(Password)] = new() { "Password is required" };
            else if (Password.Length < 6)
                _errors[nameof(Password)] = new() { "Password too short" };
            OnErrorsChanged(nameof(Password));
        }

        private void ValidateAge()
        {
            _errors.Remove(nameof(Age));
            if (Age < 18 || Age > 99)
                _errors[nameof(Age)] = new() { "Age must be between 18 and 99" };
            OnErrorsChanged(nameof(Age));
        }
    }
}