﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TdWindows;
using Unigram.Common;
using Unigram.ViewModels;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Unigram.Controls.Messages.Content
{
    public sealed partial class VenueContent : Grid, IContent
    {
        private MessageViewModel _message;

        public VenueContent(MessageViewModel message)
        {
            InitializeComponent();
            UpdateMessage(message);
        }

        public void UpdateMessage(MessageViewModel message)
        {
            _message = message;

            var venue = message.Content as MessageVenue;
            if (venue == null)
            {
                return;
            }

            var latitude = venue.Venue.Location.Latitude.ToString(CultureInfo.InvariantCulture);
            var longitude = venue.Venue.Location.Longitude.ToString(CultureInfo.InvariantCulture);

            Texture.Source = new BitmapImage(new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Imagery/Map/Road/{0},{1}/{2}?mapSize={3}&key=FgqXCsfOQmAn9NRf4YJ2~61a_LaBcS6soQpuLCjgo3g~Ah_T2wZTc8WqNe9a_yzjeoa5X00x4VJeeKH48wAO1zWJMtWg6qN-u4Zn9cmrOPcL", latitude, longitude, 15, "320,240")));
            Texture.Constraint = message;

            // string.Format("https://ss3.4sqi.net/img/categories_v2/{0}_88.png", venue)

            VenueDot.Visibility = Visibility.Visible;
            VenueGlyph.UriSource = null;
        }

        public bool IsValid(MessageContent content, bool primary)
        {
            return content is MessageVenue;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var venue = _message.Content as MessageVenue;
            if (venue == null)
            {
                return;
            }

            var user = _message.GetSenderUser();
            if (user != null)
            {
                _message.Delegate.OpenLocation(venue.Venue.Location, user.GetFullName());
            }
        }
    }
}
