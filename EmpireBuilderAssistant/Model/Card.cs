using EmpireBuilderAssistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EmpireBuilderAssistant.Model
{
    public class Card : ViewModelUpdate
    {
        public ObservableCollection<Contract> Contracts { get; }
        public Color IconColor { get; }
        public string CardName { get; }
        public bool NeedRecalc { get; set; }

        bool _isCardVisible;
        public bool IsCardVisible
        {
            get
            {
                return _isCardVisible;
            }
            set
            {
                if (_isCardVisible != value)
                {
                    _isCardVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public Card(string cardName, Color cardColorSet)
        {
            NeedRecalc = false;
            IconColor = cardColorSet;
            Contracts = new ObservableCollection<Contract> { new Contract(ContractShape.Circle, IconColor),
            new Contract(ContractShape.Triangle, IconColor), new Contract(ContractShape.Square, IconColor)};
            IsCardVisible = true;
            CardName = cardName;
        }

        public void RecalcContracts()
        {
            if (NeedRecalc)
            {
                // Contracts updated so update the contract text
                foreach (Contract contract in Contracts)
                {
                    contract.RecalcPickupInfo();
                }                
                NeedRecalc = false;

                // As it was updated lets make it visible on map
                IsCardVisible = true;
            }
        }

        // Used for debug
        public void MakeRandomContracts()
        {
            foreach (Contract contract in Contracts)
            {
                contract.SetContractInfo(ObjectLists.Cities[ObjectLists.GetRandomNumber(ObjectLists.Cities.Count)],
                                         ObjectLists.Cargos[ObjectLists.GetRandomNumber(ObjectLists.Cargos.Count)],
                                         (uint)((ObjectLists.GetRandomNumber(20)+1) * 5));
            }
        }
    }
}
