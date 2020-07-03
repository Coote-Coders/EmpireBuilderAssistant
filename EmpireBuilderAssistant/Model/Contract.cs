using EmpireBuilderAssistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xaml;

public enum ContractShape
{
    Square,
    Circle,
    Triangle
}

namespace EmpireBuilderAssistant.Model
{
    public class PickupInfo
    {
        public City PickupCity { get; }
        public string PickupText { get; }
        public PickupInfo(City city, string pickupText)
        {
            PickupCity = city;
            PickupText = pickupText;
        }
    }

    public class Contract : ViewModelUpdate
    {
        uint _value;
        public uint Value
        { 
            get 
            { 
                return _value; 
            } 
            set 
            { 
                if (_value != value) 
                {
                    _value = value; 
                    OnPropertyChanged(); 
                } 
            } 
        }

        City _destination;
        public City Destintion
        {
            get
            {
                return _destination;
            }
            set
            {
                if (_destination != value)
                {
                    _destination = value;
                    OnPropertyChanged();
                }
            }
        }

        Cargo _cargo;
        public Cargo Cargo
        {
            get
            {
                return _cargo;
            }
            set
            {
                if (_cargo != value)
                {
                    _cargo = value;
                    OnPropertyChanged();
                }
            }
        }

        PickupInfo _selectedPickup;
        public PickupInfo SelectedPickup
        {
            get
            {
                return _selectedPickup;
            }
            set
            {
                if (_selectedPickup != value)
                {
                    _selectedPickup = value;
                    OnPropertyChanged();
                }
            }
        }

        bool _isContractVisible;
        public bool IsContractVisible
        {
            get
            {
                return _isContractVisible;
            }
            set
            {
                if (_isContractVisible != value)
                {
                    _isContractVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public ContractShape IconShape { get; }
        public Color IconColor { get; }
        public ObservableCollection<PickupInfo> PickupList { get; }

        public Contract( ContractShape contractShape,
                        Color contractColor) : this(null, null, 0, contractShape, contractColor)
        {            
        }

        public Contract(City contractDestination,
                        Cargo contractCargo,
                        uint contractValue,
                        ContractShape contractShape,
                        Color contractColor)
        {
            IsContractVisible = false;
            Value = contractValue;
            Destintion = contractDestination;
            Cargo = contractCargo;
            IconShape = contractShape;
            IconColor = contractColor;
            PickupList = new ObservableCollection<PickupInfo> { };            
            
            RecalcPickupInfo();
        }

        public void SetContractInfo(City destination, Cargo cargo, uint value)
        {
            Value = value;
            Destintion = destination;
            Cargo = cargo;

            RecalcPickupInfo();
        }

        public void RecalcPickupInfo()
        {
            // Set not visible
            IsContractVisible = true;

            PickupList.Clear();            
            if (Destintion != null)
            {
                PickupList.Add(new PickupInfo(ObjectLists.allCities, "$" + Value + "M: Show all pickups to " + Destintion.Name));
            }
            else
            {
                PickupList.Add(new PickupInfo(ObjectLists.allCities, "Show all pickups"));
            }
            SelectedPickup = PickupList[0];

            if (Cargo != null)
            {
                foreach (string cityname in Cargo.Pickup)
                {
                    City city = ObjectLists.FindCity(cityname);
                    PickupList.Add(new PickupInfo(city, "$" + Value + "M: " + Cargo.Name + " from " + city.Name + " to " + Destintion.Name));
                }
            }
        }
    }
}
