// Copyright (c) 2015 Anders Gustafsson, Cureos AB.
// All rights reserved.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using Accord.Imaging.Filters;
using Accord.Vision.Detection;
using Xamarin.Forms;

namespace Form
{
    using Color = System.Drawing.Color;
    using Image = System.Drawing.Image;

    public partial class MainPage
    {
        #region FIELDS

        private Stream imageSourceStream;
        private Bitmap bitmap;
        private readonly HaarObjectDetector detector;

        #endregion

        #region CONSTRUCTORS

        public MainPage()
        {
            InitializeComponent();

            var assembly = Assembly_.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Form.Images.judybats.jpg"))
            {
                this.ImageView.Source = this.GetImageSourceFromStream(stream);

                stream.Seek(0, SeekOrigin.Begin);
                this.bitmap = ((Bitmap)Image.FromStream(stream)).Clone(PixelFormat.Format32bppArgb);
            }

            foreach (var searchMode in Enum.GetNames(typeof(ObjectDetectorSearchMode)))
            {
                this.SearchModePicker.Items.Add(searchMode);
            }
            foreach (var scalingMode in Enum.GetNames(typeof(ObjectDetectorScalingMode)))
            {
                this.ScalingModePicker.Items.Add(scalingMode);
            }

            this.SearchModePicker.SelectedIndex =
                this.SearchModePicker.Items.IndexOf(ObjectDetectorSearchMode.NoOverlap.ToString());
            this.ScalingModePicker.SelectedIndex =
                this.ScalingModePicker.Items.IndexOf(ObjectDetectorScalingMode.SmallerToGreater.ToString());

            using (var stream = assembly.GetManifestResourceStream("FaceDetection.Files.haarcascade_frontalface_alt.xml"))
            {
                var cascade = HaarCascade.FromXml(stream);
                this.detector = new HaarObjectDetector(cascade, 30);
            }
        }

        #endregion

        #region SURL


        /*
        private async void MainPage_OnLoaded()
        {
            var assembly = Assembly_.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("FaceDetection.Images.judybats.jpg"))
            {
                this.ImageView.Source = this.GetImageSourceFromStream(stream);

                stream.Seek(0, SeekOrigin.Begin);
                this.bitmap = ((Bitmap)Image.FromStream(stream)).Clone(PixelFormat.Format32bppArgb);
            }
        }

        private void DetectButton_OnClick(object sender, EventArgs e)
        {
            var threshold = 10;// (float)Math.Pow(10.0, this.LogThresholdSlider.Value);
            var octaves = 10;// (int)this.OctaveSlider.Value;
            var initial = 10;// (int)this.InitialSlider.Value;

            // Create a new SURF Features Detector using the given parameters
            var surf = new SpeededUpRobustFeaturesDetector(threshold, octaves, initial);

            var points = surf.ProcessImage(this.bitmap);

            // Create a new AForge's Corner Marker Filter
            var features = new FeaturesMarker(points);

            // Apply the filter and display it on a picturebox
            this.LenaImage.Source = (BitmapSource)features.Apply(bitmap);
        }
        */

        #endregion

        #region EVENT HANDLERS

        private void OnDetectButtonClicked(object sender, EventArgs args)
        {
            int searchModeIndex, scalingModeIndex;
            ObjectDetectorSearchMode searchMode;
            ObjectDetectorScalingMode scalingMode;
            if ((searchModeIndex = this.SearchModePicker.SelectedIndex) < 0
                || (scalingModeIndex = this.ScalingModePicker.SelectedIndex) < 0
                || !Enum.TryParse(this.SearchModePicker.Items[searchModeIndex], out searchMode)
                || !Enum.TryParse(this.ScalingModePicker.Items[scalingModeIndex], out scalingMode))
            {
                return;
            }

            this.detector.SearchMode = searchMode;
            this.detector.ScalingMode = scalingMode;
            this.detector.ScalingFactor = 1.5f;
            this.detector.UseParallelProcessing = false;

            // Process frame to detect objects
            var objects = this.detector.ProcessFrame(this.bitmap);

            if (objects.Length > 0)
            {
                var marker = new RectanglesMarker(objects, Color.FromArgb(0xff, 0xff, 0x00, 0xff));

                using (var stream = new MemoryStream())
                {
                    marker.Apply(this.bitmap).Save(stream, ImageFormat.Jpeg);
                    this.ImageView.Source = this.GetImageSourceFromStream(stream);
                }
            }
        }

        #endregion

        #region METHODS

        private ImageSource GetImageSourceFromStream(Stream stream)
        {
            this.imageSourceStream = new MemoryStream();
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(this.imageSourceStream);
            stream.Flush();

            return ImageSource.FromStream(
                () =>
                {
                    this.imageSourceStream.Seek(0, SeekOrigin.Begin);
                    return this.imageSourceStream;
                });
        }

        #endregion
    }
}
