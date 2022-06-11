using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
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
        /// Crosshair offset
        /// </summary>
        public double crosshairXOffset;
        public double crosshairYOffset;

        /// <summary>
        /// The selected HOT KEYS
        /// </summary>
        private CrosshairOverlay.Class.Hotkey.Key ModifierKey;
        private CrosshairOverlay.Class.Hotkey.Key Hotkey;

        /// <summary>
        /// Determines the Hotkey ID
        /// Unique for each set of hotkeys (this app onyl hots 1 hotkey)
        /// </summary>
        private const int HotkeyID = 9000;

        /// <summary>
        /// Window Source
        /// Used for hotkeys
        /// </summary>
        private IntPtr _windowHandle;
        private HwndSource _source;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Load the remembered hot keys
            ModifierKey = CrosshairOverlay.Properties.Settings.Default.ModifierKey != 0 ? CrosshairOverlay.Class.Hotkey.FindKeyByWindowsNum(CrosshairOverlay.Properties.Settings.Default.ModifierKey) : CrosshairOverlay.Class.Hotkey.Key.CONTROL;
            Hotkey = CrosshairOverlay.Properties.Settings.Default.HotKey != 0 ? CrosshairOverlay.Class.Hotkey.FindKeyByWindowsNum(CrosshairOverlay.Properties.Settings.Default.HotKey) : CrosshairOverlay.Class.Hotkey.Key.C;

            // Update the UI with the selected hotkeys
            HotKeyModToggleButton.Content = ModifierKey.ToString();
            HotKeyToggleButton.Content = Hotkey.ToString();
        }


        /// <summary>
        /// Starts the crosshair overlay
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

                        // Set the crosshair window to null
                        crosshairWindow = null;

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
        /// Handles which hotkey is currently being setup
        /// NONE
        /// HOTKEY
        /// MODIFIER
        /// </summary>
        private enum KeyMonitorType
        {
            None = 0,
            HotKey = 1,
            HotKeyModifier = 2
        }
        private KeyMonitorType KeyMonitor = KeyMonitorType.None;


        /// <summary>
        /// Allows the hot key to be set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetHotKey_Click(object sender, EventArgs e)
        {
            KeyMonitor = KeyMonitorType.HotKey;
        }

        /// <summary>
        /// Allows the hot key modifier to be set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void SetHotKeyModifier_Click(object sender, EventArgs e)
        {
            KeyMonitor = KeyMonitorType.HotKeyModifier;
        }






        


        // Register the initial hotkey
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            // Load the initial hotkey setup
            _windowHandle = new WindowInteropHelper(this).Handle;
            _source = HwndSource.FromHwnd(_windowHandle);
            _source.AddHook(HwndHook);

            CrosshairOverlay.Class.Hotkey.RegisterHotKey(_windowHandle, HotkeyID, (uint)ModifierKey, (uint)Hotkey);

        }

        /// <summary>
        /// Fallback for when the hotkey is triggered
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="handled"></param>
        /// <returns></returns>
        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case HotkeyID:

                            int vkey = (((int)lParam >> 16) & 0xFFFF);
                            if (vkey == (int)CrosshairOverlay.Class.Hotkey.Key.CONTROL)
                            {
                            }

                            if(crosshairWindow != null)
                            {
                                if (crosshairWindow.Visibility == Visibility.Visible)
                                {
                                    crosshairWindow.Visibility = Visibility.Hidden;
                                }
                                else {
                                    crosshairWindow.Visibility = Visibility.Visible;
                                }
                            }

                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        /// <summary>
        /// Remove all hook instances when the application is closed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            _source.RemoveHook(HwndHook);
            CrosshairOverlay.Class.Hotkey.UnregisterHotKey(_windowHandle, HotkeyID);
            base.OnClosed(e);
        }

        /// <summary>
        /// Used to setup hotkeys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (KeyMonitor)
            {
                case KeyMonitorType.None:

                    return;
                    break;
                case KeyMonitorType.HotKeyModifier:

                    ModifierKey = CrosshairOverlay.Class.Hotkey.FindKeyByWindowsNum(Convert.ToInt32("0x" + e.Key.ToString("x"), 16));

                    HotKeyModToggleButton.Content = ModifierKey.ToString();
                    CrosshairOverlay.Properties.Settings.Default.ModifierKey = Convert.ToInt32("0x" + e.Key.ToString("x"), 16);
                    CrosshairOverlay.Properties.Settings.Default.Save();

                    _source.RemoveHook(HwndHook);
                    CrosshairOverlay.Class.Hotkey.UnregisterHotKey(_windowHandle, HotkeyID);

                    break;
                case KeyMonitorType.HotKey:

                    Hotkey = CrosshairOverlay.Class.Hotkey.FindKeyByWindowsNum(Convert.ToInt32("0x" + e.Key.ToString("x"), 16));

                    HotKeyToggleButton.Content = Hotkey.ToString();
                    CrosshairOverlay.Properties.Settings.Default.HotKey = Convert.ToInt32("0x" + e.Key.ToString("x"), 16);
                    CrosshairOverlay.Properties.Settings.Default.Save();

                    _source.RemoveHook(HwndHook);
                    CrosshairOverlay.Class.Hotkey.UnregisterHotKey(_windowHandle, HotkeyID);

                    break;

            }

            // Load the new hotkey setup
            _windowHandle = new WindowInteropHelper(this).Handle;
            _source = HwndSource.FromHwnd(_windowHandle);
            _source.AddHook(HwndHook);

            CrosshairOverlay.Class.Hotkey.RegisterHotKey(_windowHandle, HotkeyID, (uint)ModifierKey, (uint)Hotkey);

            KeyMonitor = KeyMonitorType.None;
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

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            switch( ((Slider)sender).Name ){

                case "xslider":

                    crosshairXOffset = ((Slider)sender).Value;

                    break;
                case "yslider":

                    crosshairYOffset = ((Slider)sender).Value;

                    break;

            }

            if(crosshairWindow != null)
            {
                crosshairWindow.HandleOffset();
            }
        }
    }
}
