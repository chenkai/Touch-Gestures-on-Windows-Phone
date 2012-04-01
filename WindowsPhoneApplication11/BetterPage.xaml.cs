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
    public partial class BetterPage : PhoneApplicationPage
    {
        public BetterPage()
        {
            InitializeComponent();
        }

        // this works the first time, but on subsequent zooms you'll see that the image
        // re-centers giving an unwanted movement.

        double initialScale = 1d;

        private void OnPinchStarted(object sender, PinchStartedGestureEventArgs e)
        {
            initialScale = ((CompositeTransform)ImgZoom.RenderTransform).ScaleX;
        }

        private void OnPinchDelta(object sender, PinchGestureEventArgs e)
        {
            var finger1 = e.GetPosition(ImgZoom, 0);
            var finger2 = e.GetPosition(ImgZoom, 1);

            var center = new Point(
                (finger2.X + finger1.X) / 2 / ImgZoom.ActualWidth,
                (finger2.Y + finger1.Y) / 2 / ImgZoom.ActualHeight);

            ImgZoom.RenderTransformOrigin = center;

            var transform = (CompositeTransform)ImgZoom.RenderTransform;
            transform.ScaleX = initialScale * e.DistanceRatio;
            transform.ScaleY = transform.ScaleX;
        }
    }
}