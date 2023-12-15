import { Text, View } from "react-native";
import { SafeAreaProvider } from "react-native-safe-area-context";
import "./styles";

export default function App() {
  return (
    <SafeAreaProvider>
      <View className="flex-row">
        <View className="grow bg-black">
          <Text className="text-white">oh hello there</Text>
        </View>
      </View>
    </SafeAreaProvider>
  );
}
