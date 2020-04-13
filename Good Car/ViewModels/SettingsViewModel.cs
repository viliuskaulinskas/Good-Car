using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Good Car.ViewModels
{
	public class SettingsViewModel : ContentView
{
    public SettingsViewModel()
    {
        Content = new StackLayout
        {
            Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
        };
    }
}
}