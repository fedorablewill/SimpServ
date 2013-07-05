using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
<<<<<<< HEAD
=======
using Windows.Data.Json;
using Windows.Storage;
>>>>>>> Created graphics, login splash, and communicator

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SimpServ
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
<<<<<<< HEAD
=======

        private StorageFile fData;

>>>>>>> Created graphics, login splash, and communicator
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
<<<<<<< HEAD
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
=======
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var var1 = ApplicationData.Current.LocalFolder;
            this.fData = await var1.GetFileAsync("login.dat");
            try
            {
                var da = await FileIO.ReadLinesAsync(this.fData);
                Array data = da.ToArray();
                foreach (string dat in data)
                {
                    string[] sp = dat.Split('~');
                    if (sp[0] == "ip")
                        this.txtIP.Text = sp[1];
                    else if (sp[0] == "port")
                        this.txtPort.Text = sp[1];
                    else if (sp[0] == "user")
                        this.txtUser.Text = sp[1];
                    else if (sp[0] == "pass")
                        this.txtPass.Password = sp[1];
                    else if (sp[0] == "salt")
                        this.txtSalt.Password = sp[1];
                }
            }
            catch (NullReferenceException ex)
            {
                this.fData = ApplicationData.Current.LocalFolder.CreateFileAsync("login.dat").GetResults();
            }
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            await FileIO.WriteLinesAsync(this.fData, new string[] { "ip~" + this.txtIP.Text, 
                "port~" + this.txtPort.Text, "user~" + this.txtUser.Text, "pass~" + this.txtPass.Password, 
                "salt~" + this.txtSalt.Password }, Windows.Storage.Streams.UnicodeEncoding.Utf8);
            this.Frame.Navigate(typeof(Dashboard), new JSONAPI(this.txtIP.Text, Convert.ToInt32(this.txtPort.Text), this.txtUser.Text, this.txtPass.Password, this.txtSalt.Password));
>>>>>>> Created graphics, login splash, and communicator
        }
    }
}
