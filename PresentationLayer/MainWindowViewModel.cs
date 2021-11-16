using BusinessLayer;
using Entities;
using PresentationLayer.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationLayer
{
    public class MainWindowViewModel : ObservableObject
    {
        public VehicleController controller = new VehicleController();
        public Vehicle Vehicle = new Vehicle();

        public RelayCommand ExitCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand ReadCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public ObservableCollection<VehicleType> VehicleTypeList { get; set; }
        public ObservableCollection<VehicleMake> VehicleMakeList { get; set; }
        private ObservableCollection<Vehicle> _vehicleList;
        public ObservableCollection<Vehicle> VehicleList
        {
            get => _vehicleList;
            set
            {
                _vehicleList = value;
                OnPropertyChanged(nameof(VehicleList));
            }
        }

        public MainWindowViewModel()
        {
            ExitCommand = new RelayCommand(ExitBtn_Clicked);
            CreateCommand = new RelayCommand(CreateBtn_Clicked);
            ReadCommand = new RelayCommand(ReadBtn_Clicked);
            UpdateCommand = new RelayCommand(UpdateBtn_Clicked);
            DeleteCommand = new RelayCommand(DeleteBtn_Clicked);

            VehicleList = new ObservableCollection<Vehicle>(controller.GetAllVehicles());
            VehicleTypeList = new ObservableCollection<VehicleType>(controller.GetAllVehicleTypes());
            VehicleMakeList = new ObservableCollection<VehicleMake>(controller.GetAllVehicleMakes());

            SetTime();
        }

        private VehicleType _selectedType;
        public VehicleType SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }
        private VehicleMake _selectedMake;
        public VehicleMake SelectedMake
        {
            get => _selectedMake;
            set
            {
                _selectedMake = value;
                OnPropertyChanged(nameof(SelectedMake));
            }
        }
        private Vehicle _selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get => _selectedVehicle;
            set
            {
                _selectedVehicle = value;
                OnPropertyChanged(nameof(SelectedVehicle));
                UpdateFromReg();
            }
        }
        private void UpdateFromReg()
        {
            if (SelectedVehicle != null)
            {
                Description = SelectedVehicle.Description;
                foreach (var type in VehicleTypeList)
                {
                    if (type.TypeId == SelectedVehicle.TypeId)
                    {
                        NewTypeId = type.Description;
                    }
                }
                foreach (var make in VehicleMakeList)
                {
                    if (make.MakeId == SelectedVehicle.MakeId)
                    {
                        NewMakeId = make.Description;
                    }
                }
            }
        }
        private string _newRegId;

        public string NewRegId
        {
            get =>  _newRegId;
            set { _newRegId = value; OnPropertyChanged(nameof(NewRegId)); }
        }
        private string _newTypeId;

        public string NewTypeId
        {
            get => _newTypeId;
            set { _newTypeId = value; OnPropertyChanged(nameof(NewTypeId)); }
        }
        private string _newMakeId;

        public string NewMakeId
        {
            get => _newMakeId; 
            set { _newMakeId = value; OnPropertyChanged(nameof(NewMakeId)); }
        }
        private string _description;

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }
        private string _date;
        public string Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }
        private void SetTime()
        {
            Date = DateTime.Now.ToLongTimeString();
        }

        private void CreateBtn_Clicked(object obj)
        {
            if (NewRegId != null)
            {
                if (Regex.IsMatch(NewRegId, "^[A-Za-z]{3,3}[0-9]{3,3}$"))
                {
                    Vehicle.RegistrationId = NewRegId;
                    Vehicle.TypeId = SelectedType.TypeId;
                    Vehicle.MakeId = SelectedMake.MakeId;
                    Vehicle.Description = Description;
                    controller.CreateVehicle(Vehicle);
                    VehicleList = new ObservableCollection<Vehicle>(controller.GetAllVehicles());
                    NewRegId = "";
                    NewTypeId = "";
                    NewMakeId = "";
                    Description = "";
                    SetTime();
                }
                else
                {
                    MessageBox.Show("Format for Registration nummber is [AAA111]", "Error");
                }
            }
            else
            {
                MessageBox.Show("Registration number is needed.", "Error");
            }

        }
        private void ReadBtn_Clicked(object obj)
        {
            VehicleList = new ObservableCollection<Vehicle>(controller.GetAllVehicles());
            NewRegId = "";
            NewTypeId = "";
            NewMakeId = "";
            Description = "";
            SetTime();
        }
        private void UpdateBtn_Clicked(object obj)
        {
            if (SelectedVehicle != null) { 
                Vehicle = SelectedVehicle;
                Vehicle.TypeId = SelectedType.TypeId;
                Vehicle.MakeId = SelectedMake.MakeId;
                Vehicle.Description = Description;
                controller.UpdateVehicle(Vehicle);
                SetTime();
            }
            else
            {
                MessageBox.Show("Registration number is needed to update vehicle information.", "Error");
            }
        }
        private void DeleteBtn_Clicked(object obj)
        {
            if(SelectedVehicle != null)
            {
                controller.DeleteVehicle(SelectedVehicle);
                VehicleList = new ObservableCollection<Vehicle>(controller.GetAllVehicles());
                NewRegId = "";
                NewTypeId = "";
                NewMakeId = "";
                Description = "";
                SetTime();
            }
            else
            {
                MessageBox.Show("Registration number needed for deleting a vehicle.", "Error");
            }

        }

        private void ExitBtn_Clicked(object obj)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
