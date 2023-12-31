﻿// AutolinkedNativeModules.g.cs contents generated by "react-native autolink-windows"

using System.Collections.Generic;

// Namespaces from @react-native-community/netinfo
using ReactNativeNetInfo;

// Namespaces from @react-native-picker/picker
using ReactNativePicker;

// Namespaces from react-native-device-info
using RNDeviceInfoCPP;

// Namespaces from react-native-fs
using RNFS;

// Namespaces from react-native-linear-gradient
using BVLinearGradient;

// Namespaces from react-native-svg
using RNSVG;

namespace Microsoft.ReactNative.Managed
{
    internal static class AutolinkedNativeModules
    {
        internal static void RegisterAutolinkedNativeModulePackages(IList<IReactPackageProvider> packageProviders)
        { 
            // IReactPackageProviders from @react-native-community/netinfo
            packageProviders.Add(new ReactNativeNetInfo.ReactPackageProvider());
            // IReactPackageProviders from @react-native-picker/picker
            packageProviders.Add(new ReactNativePicker.ReactPackageProvider());
            // IReactPackageProviders from react-native-device-info
            packageProviders.Add(new RNDeviceInfoCPP.ReactPackageProvider());
            // IReactPackageProviders from react-native-fs
            packageProviders.Add(new RNFS.ReactPackageProvider());
            // IReactPackageProviders from react-native-linear-gradient
            packageProviders.Add(new BVLinearGradient.ReactPackageProvider());
            // IReactPackageProviders from react-native-svg
            packageProviders.Add(new RNSVG.ReactPackageProvider());
        }
    }
}
