﻿using Bc3.Forms;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ControlsTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class BasisExperimentPage : Page
    {
        public BasisExperimentPage()
        {
            this.InitializeComponent();
        }

        private void X_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void X_Toggled(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void OnLabel2AutoSwitchToggled(object sender, RoutedEventArgs args)
        {
            if (autoSwitch2 is null || relativeSwitch2 is null)
                return;
            if (autoSwitch2.IsOn)
            {
                System.Diagnostics.Debug.WriteLine("Switch 2 On");
                FlexLayout.SetBasis(label2, FlexBasis.Auto.ToString());
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Switch 2 Off");
                FlexLayout.SetBasis(label2, new FlexBasis((float)slider2.Value, relativeSwitch2.IsOn));
            }
        }

        void OnLabel2IsRelativeSwitchToggled(object sender, RoutedEventArgs args)
        {
            if (slider2 is null)
                return;
            if (relativeSwitch2.IsOn)
            {
                // From absolute to relative
                double value = slider2.Value;
                slider2.Maximum = 1;
                slider2.Value = value / 1000;
            }
            else
            {
                // From relative to absolute
                double value = slider2.Value;
                slider2.Maximum = 1000;
                slider2.Value = 1000 * value;
            }
        }

        void OnLabel2SliderValueChanged(object sender, RangeBaseValueChangedEventArgs args)
        {
            if (label2 is null || relativeSwitch2 is null)
                return;
            FlexLayout.SetBasis(label2, new FlexBasis(args.NewValue, relativeSwitch2.IsOn));
        }

        // Label 4 event handlers
        void OnLabel4AutoSwitchToggled(object sender, RoutedEventArgs args)
        {
            if (slider4 is null || autoSwitch4 is null)
                return;
            if (autoSwitch4.IsOn)
            {
                System.Diagnostics.Debug.WriteLine("Switch 4 On");
                FlexLayout.SetBasis(label4, FlexBasis.Auto.ToString());
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Switch 4 Off");
                FlexLayout.SetBasis(label4, new FlexBasis((float)slider4.Value, relativeSwitch4.IsOn));
            }
        }

        void OnLabel4IsRelativeSwitchToggled(object sender, RoutedEventArgs args)
        {
            if (slider4 is null || relativeSwitch4 is null)
                return;
            if (relativeSwitch4.IsOn)
            {
                // From absolute to relative
                double value = slider4.Value;
                slider4.Maximum = 1;
                slider4.Value = value / 1000;
            }
            else
            {
                // From relative to absolute
                double value = slider4.Value;
                slider4.Maximum = 1000;
                slider4.Value = 1000 * value;
            }
        }

        void OnLabel4SliderValueChanged(object sender, RangeBaseValueChangedEventArgs args)
        {
            if (label4 is null || relativeSwitch4 is null)
                return;
            FlexLayout.SetBasis(label4, new FlexBasis((float)args.NewValue, relativeSwitch4.IsOn));
        }

    }
}
