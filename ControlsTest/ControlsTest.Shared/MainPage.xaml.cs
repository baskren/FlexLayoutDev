using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Microsoft.Toolkit.Uwp.UI.Animations;
using Windows.UI;
using Bc3.Forms;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ControlsTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            /*
            this.InitializeComponent();

            _wrapCombo.ItemsSource = Enum.GetNames(typeof(FlexWrap));
            _wrapCombo.SelectedItem = FlexWrap.NoWrap.ToString();

            _positionCombo.ItemsSource = Enum.GetNames(typeof(FlexPosition));
            _positionCombo.SelectedItem = FlexPosition.Relative.ToString();

            _alignItemsCombo.ItemsSource = Enum.GetNames(typeof(FlexAlignItems));
            _alignItemsCombo.SelectedItem = FlexAlignItems.Stretch.ToString();

            _alignContentCombo.ItemsSource = Enum.GetNames(typeof(FlexAlignContent));
            _alignContentCombo.SelectedItem = FlexAlignContent.Stretch.ToString();

            _justifyContentCombo.ItemsSource = Enum.GetNames(typeof(FlexJustify));
            _justifyContentCombo.SelectedItem = FlexJustify.Start.ToString();

            _dirCombo.ItemsSource = Enum.GetNames(typeof(FlexDirection));
            _dirCombo.SelectedItem = FlexDirection.Row.ToString();
            */

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(FlexDemoHomePage));
        }

        void OnWrapChanged(object sender, SelectionChangedEventArgs e)
            => _customPanel.Wrap = Enum.Parse<FlexWrap>(_wrapCombo.SelectedItem as string);

        void OnPositionChanged(object sender, SelectionChangedEventArgs e)
            => _customPanel.Position = Enum.Parse<FlexPosition>(_positionCombo.SelectedItem as string);

        void OnAlignItemsChanged(object sender, SelectionChangedEventArgs e)
            => _customPanel.AlignItems = Enum.Parse<FlexAlignItems>(_alignItemsCombo.SelectedItem as string);

        void OnAlignContentChanged(object sender, SelectionChangedEventArgs e)
            => _customPanel.AlignContent = Enum.Parse<FlexAlignContent>(_alignContentCombo.SelectedItem as string);

        void OnJustifyContentChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedText = _justifyContentCombo.SelectedItem as string;
            _customPanel.JustifyContent = Enum.Parse<FlexJustify>(selectedText);
        }

        void OnDirectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _customPanel.Direction = Enum.Parse<FlexDirection>(_dirCombo.SelectedItem as string);
        }

        void OnDelClicked(object sender, RoutedEventArgs args)
        {
            if (_customPanel.Children.LastOrDefault() is UIElement last)
                _customPanel.Children.Remove(last);
        }

        void OnAddClicked(object sender, RoutedEventArgs args)
        {
            //System.Diagnostics.Debug.WriteLine(GetType() + ". CLICKED  TYPE: " + ppup.GetType());


            /*
            
            if (ppup.IsOpen == false)
            {
                ppup.IsOpen = true;
            }
            else
            {
                ppup.IsOpen = false;
            }
            */

            //pText.Scale(0.5f, 0.5f, (float)(pText.ActualWidth / 2), (float)(pText.ActualHeight / 2), duration: 1000).Start();
            //pText.Fade(0.25f, 1000).Start();

            pText2.ToggleVisibility();

            /* only works in UWP
            string text = "Lorem ipsum dolor sit amet";
            CanvasTextFormat textFormat = new CanvasTextFormat
            {
                FontSize = 16,
                WordWrapping = CanvasWordWrapping.WholeWord,
            };
            var device = CanvasDevice.GetSharedDevice();
            var layout = new CanvasTextLayout(device, text, textFormat, 40f, float.MaxValue);

            System.Diagnostics.Debug.WriteLine(GetType() + ". DrawBounds: " + layout.LayoutBounds.Width + ", " + layout.LayoutBounds.Height);
            var width = layout.DrawBounds.Width;
            var height = layout.DrawBounds.Height;
            */

            var tb = new TextBlock
            {
                Text = "Lorem ipsum dolor sit amet",
                FontSize = 16,
                TextWrapping = TextWrapping.WrapWholeWords
            };

            tb.Measure(new Size(40, double.MaxValue));

            var desiredSize = tb.DesiredSize;
            //var actualSize = tb.ActualSize;
            var actualWidth = tb.ActualWidth;
            var actualHeight = tb.ActualHeight;

            System.Diagnostics.Debug.WriteLine(GetType() + ". Desired: " + desiredSize + "   Actual: " + $"[{actualWidth}, {actualHeight}]");

            var newTextBlock = new TextBlock { Text = "PIZZA", Foreground = new SolidColorBrush(Colors.Pink), Margin=new Thickness(5) };
            _customPanel.Children.Add(newTextBlock);

            var xTextBlock = CustomPanel.GetTextBlock(newTextBlock);
            var flexItem = CustomPanel.GetFlexItem(newTextBlock);

            System.Diagnostics.Debug.WriteLine(GetType() + ".");

            //_customPanelChild0.Text = "NEW TEXT HERE";
        }

        void OnGenerateContentClick(object sender, RoutedEventArgs e)
        {
            var colorsType = typeof(Colors);
            foreach (var property in colorsType.GetProperties())
            {
                //System.Diagnostics.Debug.WriteLine(GetType() + ". Property: " + property.Name + "   Type: " + property.PropertyType);
                if (property.PropertyType == typeof(Color))
                {
                    var colorObj = property.GetValue(null);
                    var color = (Color)colorObj;
                    _customPanel.Children.Add(new TextBox
                    {
                        Text = property.Name,
                        Foreground = new SolidColorBrush(color)
                    });
                }
            }
        }

        void OnColorChanged(object sender, ColorChangedEventArgs e)
        {
            //_textBox.Foreground = new SolidColorBrush(e.NewColor);
        }


    }
}
