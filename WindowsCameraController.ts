import type { TurboModule } from "react-native/Libraries/TurboModule/RCTExport";
import { TurboModuleRegistry } from "react-native";

export interface Spec extends TurboModule {
  Initialize: (mainOrderNo: string, folderName: string) => void;
  UploadLogs: (
    reason: string,
    email: string,
    filePath: string,
    databaseFiles: string[]
  ) => void;
  OpenImagesFolder: () => void;
  OpenEventFolder: (mainOrderNo: string, folderName: string) => void;

  GetImageSize: (filePath: string) => Promise<{
    /** Width */
    Item1: number;
    /** Height */
    Item2: number;
  }>;

  GetImageAsBytes: (filePath: string) => Promise<string>;
  GetEXIFData: (filePath: string) => Promise<any>;
}

export default TurboModuleRegistry.get<Spec>("CameraController") as Spec | null;
