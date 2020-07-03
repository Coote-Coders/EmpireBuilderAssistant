using EmpireBuilderAssistant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireBuilderAssistant.ViewModel
{
    class ActionList
    {
        public ObservableCollection<PlayerAction> Actions { get; }
        public ActionList()
        {
            Actions = new ObservableCollection<PlayerAction> {};
        }

        public void AddContractActions(Contract contract)
        {
            // Only add if a pickup location was selected and not the "All Cities" option
            if (contract.SelectedPickup.PickupCity.PosX != 0)
            {
                PlayerAction pickUpAction = new PlayerAction(contract, "Pickup " + contract.Cargo.Name + " in " + contract.SelectedPickup.PickupCity.Name);
                PlayerAction dropOffAction = new PlayerAction(contract, "Drop " + contract.Cargo.Name + " at " + contract.Destintion.Name + " for $" + contract.Value + "M");

                Actions.Add(pickUpAction);
                Actions.Add(dropOffAction);
            }
        }
    }
}
