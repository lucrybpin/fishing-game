using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using NaughtyAttributes;

public class UIShopProduct : MonoBehaviour
{
    [Header( "UI Shop Product" )]
    [SerializeField] protected int price;
    [SerializeField] protected string prefix;
    [SerializeField] protected string posfix;

    
    [SerializeField] protected TMP_Text text;
    [SerializeField] [Required] protected WatchableInt playerCoins;
    [SerializeField] protected Button button;
    [SerializeField] protected Image image;

    protected virtual void Start ()
    {
        this.text = GetComponentInChildren<TMP_Text>();
        this.button = GetComponent<Button>();
        this.image = GetComponent<Image>();
        this.button.onClick.AddListener( OnBuy );
    }

    private void LateUpdate ()
    {
        UpdateText();
        DisableConditions();
        FillConditions();
    }

    protected virtual void FillConditions ()
    {
        
    }

    protected virtual void DisableConditions ()
    {
        this.button.interactable = true;
        if (playerCoins.Value < this.price)
            this.button.interactable = false;
    }

    protected virtual void UpdateText ()
    {
        text.text = $"{prefix}{price}{posfix}";
    }

    protected virtual void OnBuy()
    {
        FindObjectOfType<GameManager>().SubtractCoins( this.price );
    }
}
