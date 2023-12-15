using Microsoft.ReactNative.Managed;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Metadata;
using Windows.ApplicationModel;
using Windows.Foundation.Collections;
using System.Linq;
using System.IO;
using System.Net.Http;
using Windows.Storage;
using Newtonsoft.Json.Linq;
using Windows.UI.Xaml;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using MetadataExtractor;
using System.Dynamic;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.WindowsRuntime;

namespace nowcandid_camera_app
{
    [ReactModule]
    public class CameraController
    {
        public event EventHandler<bool> IsSDKProcessStopped;

        public CameraController() { }

        [ReactEvent]
        public ReactEvent<string> Log { get; set; }

        [ReactEvent]
        public ReactEvent<string> OnCameraNameChanged { get; set; }

        [ReactEvent]
        public ReactEvent<bool> OnCameraLoadingChanged { get; set; }

        [ReactEvent]
        public ReactEvent<string> OnSSIDChanged { get; set; }

        [ReactEvent]
        public ReactEvent<string> OnNewImage { get; set; }

        [ReactEvent]
        public ReactEvent<string> OnBarcodeScanned { get; set; }
    }
}
