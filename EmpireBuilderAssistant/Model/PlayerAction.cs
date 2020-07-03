using EmpireBuilderAssistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace EmpireBuilderAssistant.Model
{
    class PlayerAction
    {
        public string ActionText { get; set; }
        public Color ActionColor { get; set; }
        public ContractShape ActionShape { get; set; }

        public PlayerAction(Contract contract, string testText)
        {
            ActionColor = contract.IconColor;
            ActionShape = contract.IconShape;

            ActionText = testText;
        }
    }
}
