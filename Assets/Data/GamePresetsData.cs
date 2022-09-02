using System.Collections.Generic;

public static class GamePresetsData
{
    static Dictionary<int, int> linesUpgradesLimits = new Dictionary<int, int>();
    static Dictionary<int, int> linesUpgradesPrices = new Dictionary<int, int>();

    static Dictionary<int, int> bucketsUpgradesSizes = new Dictionary<int, int>();
    static Dictionary<int, int> bucketsUpgradesPrices = new Dictionary<int, int>();

    static Dictionary<int, float> sinkSpeedLimits = new Dictionary<int, float>();
    static Dictionary<int, int> sinkSpeedPrices = new Dictionary<int, int>();

    public static void Setup()
    {
        FillBucketUpgradeSizes();
        FillBucketUpgradePrices();
        FillLineUpgradeLimits();
        FillLineUpgradePrices();
        FillSinkSpeedLimits();
        FillSinkSpeedPrices();
    }

    

    private static void FillSinkSpeedLimits ()
    {
        sinkSpeedLimits.Add( 0, .25f );
        sinkSpeedLimits.Add( 1, .52f );
        sinkSpeedLimits.Add( 2, .7f );
        sinkSpeedLimits.Add( 3, 1f );
        sinkSpeedLimits.Add( 5, 1.5f );
        sinkSpeedLimits.Add( 6, 1.7f );
        sinkSpeedLimits.Add( 7, 2 );
        sinkSpeedLimits.Add( 8, 2.5f );
        sinkSpeedLimits.Add( 9, 3f );
        sinkSpeedLimits.Add( 10, 3.52f );
        sinkSpeedLimits.Add( 11, 3f );
        sinkSpeedLimits.Add( 12, 4f );
    }

    private static void FillSinkSpeedPrices ()
    {
        sinkSpeedPrices.Add( 0, 0 );
        sinkSpeedPrices.Add( 1, 10 );
        sinkSpeedPrices.Add( 2, 60 );
        sinkSpeedPrices.Add( 3, 100 );
        sinkSpeedPrices.Add( 4, 250 );
        sinkSpeedPrices.Add( 5, 370 );
        sinkSpeedPrices.Add( 6, 520 );
        sinkSpeedPrices.Add( 7, 700 );
        sinkSpeedPrices.Add( 8, 1000 );
        sinkSpeedPrices.Add( 9, 4000 );
        sinkSpeedPrices.Add( 10, 7000 );
        sinkSpeedPrices.Add( 11, 14000 );
        sinkSpeedPrices.Add( 12, 21000 );
    }

    private static void FillLineUpgradeLimits ()
    {
        linesUpgradesLimits.Add( 0, 2 );
        linesUpgradesLimits.Add( 1, 4 );
        linesUpgradesLimits.Add( 2, 10 );
        linesUpgradesLimits.Add( 3, 22 );
        linesUpgradesLimits.Add( 4, 29 );
        linesUpgradesLimits.Add( 5, 38 );
        linesUpgradesLimits.Add( 6, 48 );
        linesUpgradesLimits.Add( 7, 54 );
        linesUpgradesLimits.Add( 8, 76 );
        linesUpgradesLimits.Add( 9, 98 );
        linesUpgradesLimits.Add( 10, 104 );
        linesUpgradesLimits.Add( 11, 126 );
        linesUpgradesLimits.Add( 12, 149 );
    }

    private static void FillLineUpgradePrices ()
    {
        linesUpgradesPrices.Add( 0, 0 );
        linesUpgradesPrices.Add( 1, 5 );
        linesUpgradesPrices.Add( 2, 10 );
        linesUpgradesPrices.Add( 3, 20 );
        linesUpgradesPrices.Add( 4, 40 );
        linesUpgradesPrices.Add( 5, 80 );
        linesUpgradesPrices.Add( 6, 160 );
        linesUpgradesPrices.Add( 7, 320 );
        linesUpgradesPrices.Add( 8, 640 );
        linesUpgradesPrices.Add( 9, 1280 );
        linesUpgradesPrices.Add( 10, 2560 );
        linesUpgradesPrices.Add( 11, 5120 );
        linesUpgradesPrices.Add( 12, 10240 );
    }

    private static void FillBucketUpgradeSizes ()
    {
        bucketsUpgradesSizes.Add( 0, 2 );
        bucketsUpgradesSizes.Add( 1, 4 );
        bucketsUpgradesSizes.Add( 2, 8 );
        bucketsUpgradesSizes.Add( 3, 22 );
        bucketsUpgradesSizes.Add( 4, 29 );
        bucketsUpgradesSizes.Add( 5, 38 );
        bucketsUpgradesSizes.Add( 6, 48 );
        bucketsUpgradesSizes.Add( 7, 54 );
        bucketsUpgradesSizes.Add( 8, 76 );
        bucketsUpgradesSizes.Add( 9, 98 );
        bucketsUpgradesSizes.Add( 10, 104 );
        bucketsUpgradesSizes.Add( 11, 126 );
        bucketsUpgradesSizes.Add( 12, 149 );
    }

    private static void FillBucketUpgradePrices ()
    {
        bucketsUpgradesPrices.Add( 0, 0 );
        bucketsUpgradesPrices.Add( 1, 4 );
        bucketsUpgradesPrices.Add( 2, 10 );
        bucketsUpgradesPrices.Add( 3, 22 );
        bucketsUpgradesPrices.Add( 4, 29 );
        bucketsUpgradesPrices.Add( 5, 38 );
        bucketsUpgradesPrices.Add( 6, 48 );
        bucketsUpgradesPrices.Add( 7, 54 );
        bucketsUpgradesPrices.Add( 8, 76 );
        bucketsUpgradesPrices.Add( 9, 98 );
        bucketsUpgradesPrices.Add( 10, 104 );
        bucketsUpgradesPrices.Add( 11, 126 );
        bucketsUpgradesPrices.Add( 12, 149 );
    }

    public static int GetBucketSizeByUpgradeLevel (int upgradeLevel)
    {
        int limit = -1;
        if (bucketsUpgradesSizes.TryGetValue( upgradeLevel, out int value ))
            limit = value;
        return limit;
    }

    public static int GetBucketPriceByUpgradeLevel (int upgradeLevel)
    {
        int cost = -1;
        if (bucketsUpgradesPrices.TryGetValue( upgradeLevel, out int value ))
            cost = value;
        return cost;
    }

    public static int GetLineLimitByUpgradeLevel(int upgradeLevel)
    {
        int limit = -1;
        if (linesUpgradesLimits.TryGetValue(upgradeLevel, out int value))
            limit = value;
        return limit;
    }

    public static int GetLinePriceByUpgradeLevel (int upgradeLevel)
    {
        int cost = -1;
        if (linesUpgradesPrices.TryGetValue( upgradeLevel, out int value ))
            cost = value;
        return cost;
    }

    public static float GetSinkSpeedByUpgradeLevel (int upgradeLevel)
    {
        float limit = -1;
        if (sinkSpeedLimits.TryGetValue( upgradeLevel, out float value ))
            limit = value;
        return limit;
    }

    public static int GetSinkPriceByUpgradeLevel (int upgradeLevel)
    {
        int cost = -1;
        if (sinkSpeedPrices.TryGetValue( upgradeLevel, out int value ))
            cost = value;
        return cost;
    }
}
