public static class CleaningService {
    public static void Clean(ICleanable toClean) => toClean.Clean();

    public static void Clean(List<ICleanable> listToClean) {
        foreach (ICleanable toClean in listToClean) {
            Clean(toClean);
        }
    }
}