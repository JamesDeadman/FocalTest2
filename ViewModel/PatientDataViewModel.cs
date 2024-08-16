using FocalTest2.Model;
using FocalTest2.Services;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

namespace FocalTest2.ViewModel
{
    internal class PatientDataViewModel : ViewModelBase
    {
        private PatientData _patientData;
        private PatientDataLoader _loader;
        private PatientDataSaver _saver;
        private Visibility _errorMsgVisibility = Visibility.Hidden;
        private string _errorMessage;

        //Should be comment everywhere.

        /// <summary>
        /// Show error message on the patient data form
        /// </summary>
        public Visibility ErrorMsgVisibility
        {
            get { return this._errorMsgVisibility; }
            set
            {
                this._errorMsgVisibility = value;
                this.OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set
            {
                this._errorMessage = value;
                this.OnPropertyChanged();
            }
        }

        public PatientDataViewModel()
        {
            this._patientData = new PatientData();
            this._loader = new PatientDataLoader();
            this._saver = new PatientDataSaver();
        }



        public PatientData PatientData
        {
            get { return this._patientData; }
            set
            {
                this._patientData = value;
                this.OnPropertyChanged();
            }
        }

        public int PatientId
        {
            get { return this._patientData.PatientId; }
            set
            {
                if (this._patientData.PatientId != value)
                {
                    this._patientData.PatientId = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string FirstName
        {
            get { return this._patientData.FirstName; }
            set
            {
                if (this._patientData.FirstName != value)
                {
                    this._patientData.FirstName = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get { return _patientData.LastName; }
            set
            {
                if (this._patientData.LastName != value)
                {
                    this._patientData.LastName = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return this._patientData.DateOfBirth; }
            set
            {
                if (this._patientData.DateOfBirth != value)
                {
                    this._patientData.DateOfBirth = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Gender
        {
            get { return _patientData.Gender; }
            set
            {
                if (this._patientData.Gender != value)
                {
                    this._patientData.Gender = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string PhoneNumber
        {
            get { return this._patientData.PhoneNumber; }
            set
            {
                if (this._patientData.PhoneNumber != value)
                {
                    this._patientData.PhoneNumber = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string EmailAddress
        {
            get { return this._patientData.EmailAddress; }
            set
            {
                if (this._patientData.EmailAddress != value)
                {
                    _patientData.EmailAddress = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string MedicalHistory
        {
            get { return this._patientData.MedicalHistory; }
            set
            {
                if (this._patientData.MedicalHistory != value)
                {
                    this._patientData.MedicalHistory = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Allergies
        {
            get { return this._patientData.Allergies; }
            set
            {
                if (this._patientData.Allergies != value)
                {
                    this._patientData.Allergies = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private ICommand _loadCommand;

        public ICommand LoadCommand
        {
            get { return this._loadCommand ?? (_loadCommand = new RelayCommand(param => ExecuteLoadCommand())); }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get { return this._saveCommand ?? (_saveCommand = new RelayCommand(param => ExecuteSaveCommand())); }
        }

        private async void ExecuteLoadCommand()
        {
            this.ErrorMsgVisibility = Visibility.Hidden;
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    this.PatientData = await _loader.LoadPatientDataAsync(openFileDialog.FileName);
                }
                catch (Exception e)
                {
                    //Clear previous data on GUI
                    this.PatientData = new PatientData();
                    this.SetErrorMessage(e.Message);
                    //example log4net(e).
                }

            }
        }

        private void SetErrorMessage(string message)
        {
            this.ErrorMessage = "Can not load file";
            this.ErrorMsgVisibility = Visibility.Visible;
        }

        private async void ExecuteSaveCommand()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    await _saver.SavePatientDataAsync(this._patientData, saveFileDialog.FileName);
                }
                catch (Exception e)
                {
                    this.SetErrorMessage(e.Message);
                    //example log4net(e).
                }

            }

        }
    }
}