const os = require("os");

if (os.platform() === "win32") {
  // Windows config
  const fs = require("fs");
  const path = require("path");
  const exclusionList = require("metro-config/src/defaults/exclusionList");

  const rnwPath = fs.realpathSync(
    path.resolve(require.resolve("react-native-windows/package.json"), ".."),
  );

  module.exports = {
    resolver: {
      blockList: exclusionList([
        new RegExp(
          `${path.resolve(__dirname, "windows").replace(/[/\\]/g, "/")}.*`,
        ),
        new RegExp(`${rnwPath}/build/.*`),
        new RegExp(`${rnwPath}/target/.*`),
        /.*\.ProjectImports\.zip/,
      ]),
    },
    transformer: {
      getTransformOptions: async () => ({
        transform: {
          experimentalImportSupport: false,
          inlineRequires: true,
        },
      }),
      assetRegistryPath: "react-native/Libraries/Image/AssetRegistry",
    },
  };
} else if (os.platform() === "darwin") {
  // iOS/Expo config
  const { getDefaultConfig } = require("expo/metro-config");
  module.exports = getDefaultConfig(__dirname);
}
