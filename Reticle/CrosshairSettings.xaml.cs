using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace Reticle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Holds the chosen reticle image
        /// </summary>
        public BitmapImage ReticleImage;

        /// <summary>
        /// Holds the selected preset
        /// </summary>
        private int ChosenPreset = 0;

        /// <summary>
        /// Holds reference to the crosshair window
        /// </summary>
        private Crosshair crosshairWindow;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Starts the reticle overlay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartRecticleButton_Click(object sender, EventArgs e)
        {
            try
            {

                switch (StartCrosshairButton.Content)
                {

                    case "STOP CROSSHAIR OVERLAY":

                        // Change start crosshair overlay button text to reflect the fact that overlay has started
                        StartCrosshairButton.Content = "START CROSSHAIR OVERLAY";

                        // Close the crosshair window
                        crosshairWindow.Close();

                        break;

                    case "START CROSSHAIR OVERLAY":

                        // Ensure a crosshair has been selected
                        if (ReticleImage == null)
                        {
                            MessageBox.Show("No crosshair selected!");
                            return;
                        }

                        // Change start crosshair overlay button text to reflect the fact that overlay has started
                        StartCrosshairButton.Content = "STOP CROSSHAIR OVERLAY";

                        // Load the crosshair window
                        crosshairWindow = new Crosshair(this);
                        crosshairWindow.Show();

                        break;

                }

            } catch(Exception ex)
            {
                MessageBox.Show("An error occured starting the crosshair overlay");
            }

        }

        /// <summary>
        /// Choose new reticle image button click event
        /// Occurs when the "Choose Image..." button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseReticleImage_Button(object sender, EventArgs e)
        {

            try
            {

                // New instance of the open file dialog from the Win32 API
                OpenFileDialog dialog = new OpenFileDialog();

                // Set the dialog filters so only PNG and GIFs can be opened
                // We only use these filetypes as they support transparency
                dialog.Filter = "Transparent Image Files (*.png;*.gif)|*.png;*.gif";

                // Set the dialog initial directory to the desktop
                dialog.InitialDirectory = String.Format(@"C:\Users\{0}\Desktop\", Environment.UserName);

                // Disable multiselect
                dialog.Multiselect = false;

                // Open the dialog for the user to choose image
                if (dialog.ShowDialog() == true)
                {
                    // Load the selected image into memory as a bitmap
                    ReticleImage = new BitmapImage();
                    ReticleImage.BeginInit();
                    ReticleImage.UriSource = new Uri(dialog.FileName);
                    ReticleImage.EndInit();

                    // Set the chosen image to the preview window
                    ReticleImagePreview.Source = ReticleImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured when choosing the crosshair image");
            }
        }

        /// <summary>
        /// Event is called when a preset is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsePresetButton_Click(object sender, EventArgs e)
        {

            try
            {
                // Get the selected preset tag ID
                string selectedPreset = ((Button)sender).Tag.ToString();

                // Disable the previously selected preset (if exists)
                if (ChosenPreset != 0)
                {
                    // Remote the existing border change
                    // Find the button that corrosponds with the chosen preset value
                    foreach (object child in LogicalTreeHelper.GetChildren(PresetPanel))
                    {
                        Border b = (Border)child;
                        if (b.Tag.ToString() == ChosenPreset.ToString())
                        {
                            b.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Gray");
                            break;
                        }

                    }
                }

                // Set the border of the chosen preset to show that it has been selected
                ChosenPreset = int.Parse(selectedPreset);

                // Set the border of the chosen preset to highlight that it has been selected
                foreach (object child in LogicalTreeHelper.GetChildren(PresetPanel))
                {
                    Border b = (Border)child;
                    if (b.Tag.ToString() == selectedPreset.ToString())
                    {
                        b.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                        break;
                    }

                }

                // Apply the cross hair to the preview image pane
                ReticleImage = new BitmapImage();
                ReticleImage.BeginInit();
                ReticleImage.UriSource = new Uri("pack://application:,,,/Crosshairs/" + selectedPreset + ".png");
                ReticleImage.EndInit();
                ReticleImagePreview.Source = ReticleImage;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured when attempting to use a crosshair preset");
            }

        }

        /// <summary>
        /// Occurs when the window is no longer the frame of reference
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Deactivated(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event occurs when the window is closed
        /// Force closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown(0);
        }
    }
}
