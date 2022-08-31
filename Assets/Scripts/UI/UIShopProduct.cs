using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIShopProduct : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] string prefix;
    [SerializeField] string posfix;

    
    [SerializeField] TMP_Text text;
    [SerializeField] WatchableInt playerCoins;

    private void LateUpdate ()
    {
        text.text = $"{prefix}{price}{posfix}";
    }
}
