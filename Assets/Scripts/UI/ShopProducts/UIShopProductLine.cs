using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopProductLine : UIShopProduct {
    [Header( "UI Shop Product Line" )]
    [SerializeField] int level;
    [SerializeField] private WatchableInt currentLineLevel;

    protected override void Start ()
    {
        base.Start();
        int price = GamePresetsData.GetLinePriceByUpgradeLevel( level );
        int limit = GamePresetsData.GetLineLimitByUpgradeLevel( level );

        this.prefix = $"Level {level} ({limit}m) - ";
        this.price = price;
        this.posfix = " coins";
    }

    protected override void DisableConditions ()
    {
        base.DisableConditions();
        if (currentLineLevel.Value >= this.level)
            button.interactable = false;
    }

    protected override void FillConditions ()
    {
        base.FillConditions();
        if (currentLineLevel.Value == this.level)
            this.image.color = Color.blue;
        else
            this.image.color = Color.white;
    }

    protected override void OnBuy ()
    {
        base.OnBuy();
        FindObjectOfType<GameManager>().SetLineLevel( this.level );
    }
}
