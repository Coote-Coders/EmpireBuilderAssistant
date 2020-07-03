using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace EmpireBuilderAssistant
{
    class BooleanToInkCanvasEditingModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is bool && (bool)value == true)
            {
                return InkCanvasEditingMode.Ink;
            }
            else
            {
                return InkCanvasEditingMode.None;
            }
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is InkCanvasEditingMode && (InkCanvasEditingMode)value == InkCanvasEditingMode.Ink)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
