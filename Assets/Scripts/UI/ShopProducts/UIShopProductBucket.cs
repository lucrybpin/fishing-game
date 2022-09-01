using NaughtyAttributes;
using UnityEngine;

public class UIShopProductBucket : UIShopProduct {

    [Header( "UI Shop Product Bucket" )]
    [SerializeField] [Required] int level;
    [SerializeField] [Required] private WatchableInt currentBucketLevel;

    protected override void Start ()
    {
        base.Start();
        int price = GamePresetsData.GetBucketPriceByUpgradeLevel( level );
        int limit = GamePresetsData.GetBucketSizeByUpgradeLevel( level );

        this.prefix = $"Level {level} ({limit}un) - ";
        this.price = price;
        this.posfix = " coins";
    }

    protected override void DisableConditions ()
    {
        base.DisableConditions();
        if (currentBucketLevel.Value >= this.level)
            button.interactable = false;
    }

    protected override void FillConditions ()
    {
        base.FillConditions();
        if (currentBucketLevel.Value == this.level)
            this.image.color = Color.blue;
        else
            this.image.color = Color.white;
    }

    protected override void OnBuy ()
    {
        base.OnBuy();
        FindObjectOfType<GameManager>().SetBucketLevel( this.level );
    }
}
