using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace EmpireBuilderAssistant.ViewModel
{
    class DrawIcon
    {
        static readonly double cardIconOpacity = 1;
        static readonly double cardMapPickupOpacity = .5;
        static readonly double cardMapDestinationOpacity = .7;

        static public void DrawCardIcon(Canvas canvas, Color fillColor, ContractShape shape)
        {
            switch (shape)
            {
                case ContractShape.Circle:
                    DrawCircle(canvas, false, false, canvas.ActualWidth / 2, canvas.ActualHeight / 2, fillColor);
                    break;
                case ContractShape.Square:
                    DrawSquare(canvas, false, false, canvas.ActualWidth / 2, canvas.ActualHeight / 2, fillColor);
                    break;
                case ContractShape.Triangle:
                    DrawTriangle(canvas, false, false, canvas.ActualWidth / 2, canvas.ActualHeight / 2, fillColor);
                    break;
            }
        }

        static public void DrawMapIcon(Canvas canvas, Color fillColor, ContractShape shape, bool destination, double posX, double posY)
        {
            switch (shape)
            {
                case ContractShape.Circle:
                    DrawCircle(canvas, true, destination, posX, posY, fillColor);
                    break;
                case ContractShape.Square:
                    DrawSquare(canvas, true, destination, posX, posY, fillColor);
                    break;
                case ContractShape.Triangle:
                    DrawTriangle(canvas, true, destination, posX, posY, fillColor);
                    break;
            }
        }

        static public void GetShapeSize(Canvas canvas, bool map, ref double width, ref double height)
        {
            if (map)
            {
                width = height = 80;
            }
            else
            {
                width = canvas.ActualWidth - 5;
                height = canvas.ActualHeight - 5;
            }
        }

        static public void DrawSquare(Canvas canvas, bool map, bool destination, double posX, double posY, Color fillColor)
        {
            double width = 0, height = 0;
            GetShapeSize(canvas, map, ref width, ref height);

            System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.Fill = new SolidColorBrush(fillColor);
            rect.Width = width;
            rect.Height = height;

            if (map)
            {
                rect.Opacity = cardMapPickupOpacity;
            }
            else
            {
                rect.Opacity = cardIconOpacity;
            }
            if (destination)
            {
                rect.StrokeThickness = 10;
                rect.Opacity = cardMapDestinationOpacity;
            }
            else
            {
                rect.StrokeThickness = 0;
            }

            Canvas.SetLeft(rect, posX - rect.Width / 2);
            Canvas.SetTop(rect, posY - rect.Height / 2);
            canvas.Children.Add(rect);
        }

        static public void DrawCircle(Canvas canvas, bool map, bool destination, double posX, double posY, Color fillColor)
        {
            double width = 0, height = 0;
            GetShapeSize(canvas, map, ref width, ref height);

            System.Windows.Shapes.Ellipse circle = new System.Windows.Shapes.Ellipse();
            circle.Stroke = new SolidColorBrush(Colors.Black);
            circle.Fill = new SolidColorBrush(fillColor);

            circle.Width = width;
            circle.Height = height;

            if (map)
            {
                circle.Opacity = cardMapPickupOpacity;
            }
            else
            {
                circle.Opacity = cardIconOpacity;
            }
            if (destination)
            {
                circle.StrokeThickness = 10;
                circle.Opacity = cardMapDestinationOpacity;
            }
            else
            {
                circle.StrokeThickness = 0;
            }

            Canvas.SetLeft(circle, posX - width / 2);
            Canvas.SetTop(circle, posY - height / 2);
            canvas.Children.Add(circle);
        }

        static public void DrawTriangle(Canvas canvas, bool map, bool destination, double posX, double posY, Color fillColor)
        {
            double width = 0, height = 0;
            GetShapeSize(canvas, map, ref width, ref height);

            System.Windows.Shapes.Polygon poly = new System.Windows.Shapes.Polygon();
            poly.Stroke = new SolidColorBrush(Colors.Black);
            poly.Fill = new SolidColorBrush(fillColor);

            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(new System.Windows.Point(posX, posY - height / 2));
            myPointCollection.Add(new System.Windows.Point(posX - width / 2, posY + height / 2));
            myPointCollection.Add(new System.Windows.Point(posX + width / 2, posY + height / 2));
            poly.Points = myPointCollection;

            if (map)
            {
                poly.Opacity = cardMapPickupOpacity;
            }
            else
            {
                poly.Opacity = cardIconOpacity;
            }
            if (destination)
            {
                poly.StrokeThickness = 10;
                poly.Opacity = cardMapDestinationOpacity;
            }
            else
            {
                poly.StrokeThickness = 0;
            }

            Canvas.SetLeft(poly, posX - poly.Width / 2);
            Canvas.SetTop(poly, posY - poly.Height / 2);
            canvas.Children.Add(poly);
        }
    }
}
