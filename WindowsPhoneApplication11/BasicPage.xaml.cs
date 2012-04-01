using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace WindowsPhoneApplication11
{
    public partial class BasicPage : PhoneApplicationPage
    {
        public BasicPage()
        {
            InitializeComponent();
        }

        // this does *not* work because it always zooms around the image center.
        // Stick two fingers in the eyes and you'll see that after the scaling
        // the eyes won't be under your fingers anymore.

        double initialScale = 1d;

        private void OnPinchStarted(object sender, PinchStartedGestureEventArgs e)
        {
            initialScale = ((CompositeTransform)ImgZoom.RenderTransform).ScaleX;
        }

        private void OnPinchDelta(object sender, PinchGestureEventArgs e)
        {
            var transform = (CompositeTransform)ImgZoom.RenderTransform;
            transform.ScaleX = initialScale * e.DistanceRatio;
            transform.ScaleY = transform.ScaleX;
        }
    }
}