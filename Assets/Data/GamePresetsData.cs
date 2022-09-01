using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePresetsData
{
    static Dictionary<int, int> linesUpgradesLimits = new Dictionary<int, int>();
    static Dictionary<int, int> linesUpgradesPrices = new Dictionary<int, int>();

    public static void Setup()
    {
        FillLineUpgradeLimits();
        FillLineUpgradePrices();
    }

    private static void FillLineUpgradeLimits ()
    {
        linesUpgradesLimits.Add( 0, 1 );
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
        linesUpgradesPrices.Add( 8, 160 );
        linesUpgradesPrices.Add( 9, 160 );
        linesUpgradesPrices.Add( 7, 320 );
        linesUpgradesPrices.Add( 10, 640 );
        linesUpgradesPrices.Add( 11, 1280 );
        linesUpgradesPrices.Add( 12, 2560 );
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
}
