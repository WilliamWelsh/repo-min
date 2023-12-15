module.exports = function (api) {
  // api.cache(true);

  const plugins = ["nativewind/babel"];

  if (api.env("production")) {
    plugins.push("transform-remove-console");
  }

  return {
    presets: ["babel-preset-expo", "module:metro-react-native-babel-preset"],
    plugins: plugins,
  };
};
