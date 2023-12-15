using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Devices.Enumeration;
using Windows.Foundation.Collections;
using NLog;

namespace BackgroundService
{
    public partial class App : Application
    {
        private AppServiceConnection connection = null;
        private string path = string.Empty;

        private DeviceWatcher deviceWatcher;

        public event EventHandler<string> OnWifiStatusChanged;

        private static ILogger logger;

        public App()
        {
            // Initialize the app service connection
            var task = Task.Run(async () => await InitializeAppServiceConnection());
            task.Wait();

            DispatcherUnhandledException += OnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedException;

            StartDeviceWatcher();
        }

        private void StartDeviceWatcher()
        {
            deviceWatcher = DeviceInformation.CreateWatcher(DeviceClass.PortableStorageDevice);

            deviceWatcher.Added += DeviceWatcher_Added;
            deviceWatcher.Removed += DeviceWatcher_Removed;

            deviceWatcher.Start();
        }

        public void Log(string text)
        {
            logger.Info(text);
        }

        public void OnCameraLoadingChanged(bool uri)
        {
            if (connection != null)
                _ = connection.SendMessageAsync(new ValueSet { { "OnCameraLoadingChanged", uri } });
        }

        public void OnNewImage(string isLoading)
        {
            if (connection != null)
                _ = connection.SendMessageAsync(new ValueSet { { "OnNewImage", isLoading } });
        }

        public void OnCameraNameChanged(string name)
        {
            if (connection != null)
                _ = connection.SendMessageAsync(new ValueSet { { "OnCameraNameChanged", name } });
        }

        public void OnSSIDChanged(string ssid)
        {
            if (connection != null)
                _ = connection.SendMessageAsync(new ValueSet { { "OnSSIDChanged", ssid } });
        }

        private async void DeviceWatcher_Added(
            DeviceWatcher sender,
            DeviceInformation deviceInfo
        ) { }

        private void DeviceWatcher_Removed(
            DeviceWatcher sender,
            DeviceInformationUpdate deviceInfoUpdate
        ) { }

        private async Task InitializeAppServiceConnection()
        {
            try
            {
                connection = new AppServiceConnection
                {
                    AppServiceName = "BackgroundService",
                    PackageFamilyName = Package.Current.Id.FamilyName
                };

                connection.RequestReceived -= Connection_RequestReceived;
                connection.ServiceClosed -= Connection_ServiceClosed;
                connection.RequestReceived += Connection_RequestReceived;
                connection.ServiceClosed += Connection_ServiceClosed;

                var status = await connection.OpenAsync();
            }
            catch (Exception ex)
            {
                ClearSessionAndCloseApplication();
            }
        }

        private async void Connection_RequestReceived(
            AppServiceConnection sender,
            AppServiceRequestReceivedEventArgs args
        ) { }

        private void ClearSessionAndCloseApplication()
        {
            Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                new Action(() =>
                {
                    Current.Shutdown();
                })
            );
        }

        private void Connection_ServiceClosed(
            AppServiceConnection sender,
            AppServiceClosedEventArgs args
        )
        {
            ClearSessionAndCloseApplication();
        }

        private void Application_Startup(object sender, StartupEventArgs e) { }

        private void OnDispatcherUnhandledException(
            object sender,
            DispatcherUnhandledExceptionEventArgs e
        )
        {
            Log(
                $"Application stops unexpectedly. DispatcherUnhandledException: {e.Exception.Message}"
            );
        }

        private void OnUnobservedException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            // Occurs when an exception is not handled on a background thread.
            // ie. A task is fired and forgotten Task.Run(() => {...})
            Log($"Application stops unexpectedly. {e.Exception.Message}");
            e.SetObserved();
        }
    }
}
