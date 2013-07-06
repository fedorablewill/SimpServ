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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Json;
using System.Net.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SimpServ
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dashboard : Page
    {
        private JSONAPI server;
        
        public Dashboard()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.loading.IsActive = true;

            this.server = (JSONAPI) e.Parameter;
            JsonValue val = await this.server.call("getServer", null);
            JsonObject info = val.GetObject().GetNamedObject("success");

            this.txtServerName.Text = info.GetNamedString("serverName");

            JsonArray players = info.GetNamedArray("players");
            int playNum = players.Count;
            this.txtServerData.Text = "Online     " + playNum + "/" + info.GetNamedNumber("maxPlayers") + " Players";

            if (playNum == 1)
                this.imgPlayer1.Source = new BitmapImage(new Uri(this.imgPlayer1.BaseUri, "https://minotar.net/avatar/" + players.ToArray()[0] +"/70.png"));
            if (playNum > 1)
                this.imgPlayer2.Source = new BitmapImage(new Uri(this.imgPlayer1.BaseUri, "https://minotar.net/avatar/" + players.ToArray()[1] + "/70.png"));
            if (playNum > 2)
                this.imgPlayer3.Source = new BitmapImage(new Uri(this.imgPlayer1.BaseUri, "https://minotar.net/avatar/" + players.ToArray()[2] + "/70.png"));
            if (playNum > 3)
                this.imgPlayer4.Source = new BitmapImage(new Uri(this.imgPlayer1.BaseUri, "https://minotar.net/avatar/" + players.ToArray()[3] + "/70.png"));
            if (playNum > 4)
                this.imgPlayer5.Source = new BitmapImage(new Uri(this.imgPlayer1.BaseUri, "https://minotar.net/avatar/" + players.ToArray()[4] + "/70.png"));

            this.loading.IsActive = false;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {

        }
    }
}
