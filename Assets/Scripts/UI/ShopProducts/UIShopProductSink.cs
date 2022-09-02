using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopProductSink : UIShopProduct
{
    [Header( "UI Shop Product Sink" )]
    [SerializeField] [Required] int level;
    [SerializeField] [Required] private WatchableInt currentSinkSpeedLevel;

    protected override void Start ()
    {
        base.Start();
        int price = GamePresetsData.GetSinkPriceByUpgradeLevel( level );
        float speed = GamePresetsData.GetSinkSpeedByUpgradeLevel( level );

        this.prefix = $"Level {level} ({speed}m/s) - ";
        this.price = price;
        this.posfix = " coins";
    }

    protected override void DisableConditions ()
    {
        base.DisableConditions();
        if (currentSinkSpeedLevel.Value >= this.level)
            button.interactable = false;
    }

    protected override void FillConditions ()
    {
        base.FillConditions();
        if (currentSinkSpeedLevel.Value == this.level)
            this.image.color = Color.blue;
        else
            this.image.color = Color.white;
    }

    protected override void OnBuy ()
    {
        base.OnBuy();
        FindObjectOfType<GameManager>().SetSinkSpeedLevel( this.level );
    }
}
