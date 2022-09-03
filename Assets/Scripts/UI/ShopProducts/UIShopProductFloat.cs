using NaughtyAttributes;
using UnityEngine;

public class UIShopProductFloat : UIShopProduct
{
    [Header( "UI Shop Product Sink" )]
    [SerializeField] [Required] int level;
    [SerializeField] [Required] private WatchableInt currentFloatSpeedLevel;

    protected override void Start ()
    {
        base.Start();
        int price = GamePresetsData.GetFloatSpeedPriceByUpgradeLevel( level );
        float speed = GamePresetsData.GetFloatSpeedByUpgradeLevel( level );

        this.prefix = $"Level {level} ({speed}m/s) - ";
        this.price = price;
        this.posfix = " coins";
    }

    protected override void DisableConditions ()
    {
        base.DisableConditions();
        if (currentFloatSpeedLevel.Value >= this.level)
            button.interactable = false;
    }

    protected override void FillConditions ()
    {
        base.FillConditions();
        if (currentFloatSpeedLevel.Value == this.level)
            this.image.color = Color.blue;
        else
            this.image.color = Color.white;
    }

    protected override void OnBuy ()
    {
        base.OnBuy();
        FindObjectOfType<GameManager>().SetFloatLevel( this.level );
    }
}
