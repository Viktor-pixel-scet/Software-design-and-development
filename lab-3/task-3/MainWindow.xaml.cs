using System.Collections.Generic;
using System.IO;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Threading.Tasks;
using System.Windows.Input;

namespace task_3
{
    public partial class MainWindow : Window
    {
        private IRenderer currentRenderer;
        private Shape currentShape;
        private Dictionary<string, Func<IRenderer, Shape>> shapeFactory;
        private Color selectedColor = Color.FromRgb(67, 97, 238);
        private double currentSize = 200;
        private bool isAnimating = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeShapeFactory();
            currentRenderer = new VectorRenderer();
            UpdateShape();
            ShapeComboBox.SelectedIndex = 0;
            RendererComboBox.SelectedIndex = 0;
        }

        private void InitializeShapeFactory()
        {
            shapeFactory = new Dictionary<string, Func<IRenderer, Shape>>
        {
            {
                    "Коло", renderer => new Circle(renderer)
                },
            {
                    "Квадрат", renderer => new Square(renderer)
                },
            {
                    "Трикутник", renderer => new Triangle(renderer)
                }
        };
        }

        private void ShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count == 0)
                return;

            UpdateShape();

            var console = new StringWriter();
            Console.SetOut(console);

            currentShape.Draw();
            OutputTextBox.Text += console.ToString() + Environment.NewLine;
        }

        private void RendererComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count == 0)
                return;

            var selectedRenderer = (RendererComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            currentRenderer = selectedRenderer == "Векторне" ? new VectorRenderer() : new RasterRenderer();

            UpdateShape();
            var console = new StringWriter();
            Console.SetOut(console);

            currentShape.Draw();
            OutputTextBox.Text += console.ToString() + Environment.NewLine;
        }

        private void UpdateShape()
        {
            var selectedShape = (ShapeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedShape != null && shapeFactory.ContainsKey(selectedShape))
            {
                currentShape = shapeFactory[selectedShape](currentRenderer);
            }
            else
            {
                currentShape = new Circle(currentRenderer);
            }

            DrawOnCanvas();
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            var console = new StringWriter();
            Console.SetOut(console);

            currentShape.Draw();
            OutputTextBox.Text += console.ToString() + Environment.NewLine;

            DrawOnCanvas();
        }

        private void ColorBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            if (border != null)
            {
                var brush = border.Background as SolidColorBrush;
                if (brush != null)
                {
                    selectedColor = brush.Color;
                    if (!isAnimating)
                    {
                        DrawOnCanvas();
                    }
                }
            }
        }

        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            currentSize = e.NewValue;
            if (!isAnimating)
            {
                DrawOnCanvas();
            }
        }

        private async void DrawOnCanvas()
        {
            isAnimating = true;
            System.Windows.Shapes.Shape figure = null;

            switch (currentShape)
            {

                case Circle:
                    figure = new Ellipse { Width = currentSize, Height = currentSize };

                    break;
                case Square:
                    figure = new Rectangle { Width = currentSize, Height = currentSize };
                    break;
                case Triangle:
                    var height = Math.Sqrt(3) * currentSize / 2;
                    var polygon = new Polygon
                    {
                        Points = new PointCollection
                    {
                        new Point(currentSize/2, 0),
                        new Point(0, height),
                        new Point(currentSize, height)
                    }
                    };
                    figure = polygon;
                    break;
            }

            if (figure != null)
            {
                if (GradientCheckBox.IsChecked == true && currentRenderer is VectorRenderer)
                {
                    var gradientBrush = new LinearGradientBrush
                    {
                        StartPoint = new Point(0, 0),
                        EndPoint = new Point(1, 1)
                    };

                    gradientBrush.GradientStops.Add(new GradientStop(selectedColor, 0));
                    gradientBrush.GradientStops.Add(new GradientStop(
                        Color.FromRgb(
                            (byte)(selectedColor.R * 0.7),
                            (byte)(selectedColor.G * 0.7),
                            (byte)(selectedColor.B * 0.7)
                        ), 1));

                    figure.Fill = gradientBrush;
                }
                else
                {
                    figure.Fill = new SolidColorBrush(selectedColor);
                }

                figure.Stroke = Brushes.White;
                figure.StrokeThickness = 3;

                if (ShadowCheckBox.IsChecked == true)
                {
                    figure.Effect = new DropShadowEffect
                    {
                        BlurRadius = 15,
                        Direction = 270,
                        ShadowDepth = 5,
                        Color = Color.FromArgb(40, 0, 0, 0)
                    };
                }

                double left = (DrawingCanvas.ActualWidth - currentSize) / 2;
                double top = (DrawingCanvas.ActualHeight - (figure is Polygon ? Math.Sqrt(3) * currentSize / 2 : currentSize)) / 2;
                Canvas.SetLeft(figure, left);
                Canvas.SetTop(figure, top);
                DrawingCanvas.Children.Clear();
                DrawingCanvas.Children.Add(figure);

                if (AnimationCheckBox.IsChecked == true)
                {
                    figure.Opacity = 0;
                    figure.RenderTransform = new ScaleTransform(0.5, 0.5);
                    figure.RenderTransformOrigin = new Point(0.5, 0.5);

                    var fadeIn = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut }
                    };

                    var scaleX = new DoubleAnimation
                    {
                        From = 0.5,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut }
                    };

                    var scaleY = new DoubleAnimation
                    {
                        From = 0.5,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut }
                    };

                    figure.BeginAnimation(UIElement.OpacityProperty, fadeIn);
                    (figure.RenderTransform as ScaleTransform).BeginAnimation(ScaleTransform.ScaleXProperty, scaleX);
                    (figure.RenderTransform as ScaleTransform).BeginAnimation(ScaleTransform.ScaleYProperty, scaleY);

                    await Task.Delay(300);
                }
            }
            isAnimating = false;
        }
    }
}