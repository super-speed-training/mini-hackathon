using System;
using System.Collections.Generic;
using System.IO;
using Emmellsoft.IoT.Rpi.SenseHat;
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
using System.Threading.Tasks;
using Windows.UI;
using System.Diagnostics;
using Microsoft.Azure.Devices.Client;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SecondRound
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
 
        public MainPage()
        {
            this.InitializeComponent();

            Task.Run(async () =>
            {
                var hat = await SenseHatFactory.GetSenseHat().ConfigureAwait(true);
                hat.Display.Fill(Colors.Aqua);
                hat.Display.Update();
                hat.Sensors.HumiditySensor.Update();
               

                while (true)
                {
                    hat.Sensors.HumiditySensor.Update();
                    var currentTemp = hat.Sensors.Temperature.GetValueOrDefault();
                    Debug.WriteLine(currentTemp);
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        DisplayTemp.Text = currentTemp.ToString("#.##");
                    });
                    await Task.Delay(1000);
                }
            }).ConfigureAwait(false);



        }
    }
}
