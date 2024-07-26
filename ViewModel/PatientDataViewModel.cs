using FocalTest2.Model;
using FocalTest2.Services;
using Microsoft.Win32;
using System.ComponentModel;
using System.Windows.Input;

namespace FocalTest2.ViewModel
{
    internal class PatientDataViewModel : INotifyPropertyChanged
    {
        private PatientData _patientData;
        private PatientDataLoader _loader;
        private PatientDataSaver _saver;

        public PatientDataViewModel()
        {
            _patientData = new PatientData();
            _loader = new PatientDataLoader();
            _saver = new PatientDataSaver();
        }

        public int PatientId
        {
            get { return _patientData.PatientId; }
            set
            {
                if (_patientData.PatientId != value)
                {
                    _patientData.PatientId = value;
                    OnPropertyChanged(nameof(PatientId));
                }
            }
        }

        public string FirstName
        {
            get { return _patientData.FirstName; }
            set
            {
                if (_patientData.FirstName != value)
                {
                    _patientData.FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get { return _patientData.LastName; }
            set
            {
                if (_patientData.LastName != value)
                {
                    _patientData.LastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return _patientData.DateOfBirth; }
            set
            {
                if (_patientData.DateOfBirth != value)
                {
                    _patientData.DateOfBirth = value;
                    OnPropertyChanged(nameof(DateOfBirth));
                }
            }
        }

        public string Gender
        {
            get { return _patientData.Gender; }
            set
            {
                if (_patientData.Gender != value)
                {
                    _patientData.Gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        public string PhoneNumber
        {
            get { return _patientData.PhoneNumber; }
            set
            {
                if (_patientData.PhoneNumber != value)
                {
                    _patientData.PhoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public string EmailAddress
        {
            get { return _patientData.EmailAddress; }
            set
            {
                if (_patientData.EmailAddress != value)
                {
                    _patientData.EmailAddress = value;
                    OnPropertyChanged(nameof(EmailAddress));
                }
            }
        }

        public string MedicalHistory
        {
            get { return _patientData.MedicalHistory; }
            set
            {
                if (_patientData.MedicalHistory != value)
                {
                    _patientData.MedicalHistory = value;
                    OnPropertyChanged(nameof(MedicalHistory));
                }
            }
        }

        public string Allergies
        {
            get { return _patientData.Allergies; }
            set
            {
                if (_patientData.Allergies != value)
                {
                    _patientData.Allergies = value;
                    OnPropertyChanged(nameof(Allergies));
                }
            }
        }

        private ICommand _loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                return _loadCommand ?? (_loadCommand = new RelayCommand(param => ExecuteLoadCommand()));
            }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(param => ExecuteSaveCommand()));
            }
        }

        private async void ExecuteLoadCommand()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _patientData = await _loader.LoadPatientDataAsync(openFileDialog.FileName);
            }
        }

        private async void ExecuteSaveCommand()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                await _saver.SavePatientDataAsync(_patientData, saveFileDialog.FileName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
