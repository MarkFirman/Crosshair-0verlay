using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Reticle
{
    /// <summary>
    /// Interaction logic for Crosshair.xaml
    /// </summary>
    public partial class Crosshair : Window
    {

        /// <summary>
        /// Holds reference to the settings window
        /// </summary>
        private MainWindow settingsWindow;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="crosshairSettingsWindow"></param>
        public Crosshair(MainWindow crosshairSettingsWindow)
        {
            InitializeComponent();

            // Set reference to the settings window
            this.settingsWindow = crosshairSettingsWindow;

            // Handle the offset
            HandleOffset();

            // Set self window to be center of the screen
            // Startup is in the middle of the screen, but that does not always work, so we should get the screen settings
            // including height and width and set the to the center manually

            // Set the cross hair image
            CrossHairImageOverlay.Source = settingsWindow.ReticleImage;

            // Set the window focus
            // The topmost setting cannot be used until the focus of the window has been set
            this.Focus();
            
        }

        /// <summary>
        /// Force crosshair to be topmost when always on top is checked
        /// This is required when the game forces itself fullscreen
        /// Occurs when the window is no longer the frame of reference
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Deactivated(object sender, EventArgs e)
        {
            if (this.settingsWindow.AlwaysOnTopCheckbox.IsChecked == true)
            {
                // Create a new action to continually set the window to topmost
                // Intentionally do not await the result
                // Some games may call themselves topmost over and over, therefore we also need to repeat to prevent
                // third party apps from taking the top spot
                // This can cause flickering, but that can be dampened using waits and retries
                App.Current.Dispatcher.BeginInvoke(new Action(async () => await RetrySetTopMost()));
            }

        }

        /// <summary>
        /// This will force the window to be the topmost
        /// The window must get focus with a mouse click to work, though.
        /// Best bet is to simulate a mouse click on the window first
        /// </summary>
        private const int RetrySetTopMostDelay = 1000;
        private const int RetrySetTopMostMax = 9999999;
        private static async Task RetrySetTopMost()
        {
            try
            {
                for (int i = 0; i < RetrySetTopMostMax; i++)
                {
                    await Task.Delay(RetrySetTopMostDelay);

                    foreach (Window w in App.Current.Windows)
                    {
                        if (w.Title == "Crosshair")
                        {

                            w.Topmost = false;
                            w.Topmost = true;

                            break;
                        }
                    }


                }

                // Intentionally do not await the result
                App.Current.Dispatcher.BeginInvoke(new Action(async () => await RetrySetTopMost()));

            } catch(Exception ex)
            {
                MessageBox.Show("An error occured whilst attempting to overlay the crosshair");
            }

        }



        double lXoffset;
        double lYoffset;

        public void HandleOffset()
        {

            double differenceX = (settingsWindow.crosshairXOffset - lXoffset) * 4;
            double differenceY = (settingsWindow.crosshairYOffset - lYoffset) * 4;


            this.Left += differenceX;
            this.Top -= differenceY;
 
            lXoffset = settingsWindow.crosshairXOffset;
            lYoffset = settingsWindow.crosshairYOffset;

        }




    }
}
