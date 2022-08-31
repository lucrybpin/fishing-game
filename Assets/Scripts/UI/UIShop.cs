using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour {

    GameManager gameManager;
    Dictionary<Type, int> fishValues = new Dictionary<Type, int>();

    private void Start ()
    {
        fishValues.Add( typeof( Tuna ), 1 );
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SellAll ()
    {
        Bucket bucket = FindObjectOfType<Bucket>();

        int totalGold = 0;
        foreach (Fish fish in bucket.Fishes)
        {
            if (fishValues.TryGetValue( fish.GetType(), out int value ))
            {
                totalGold += value;
            }
            else
            {
                Debug.Log( "Couldn't find value of " + fish.GetType() );
            }
        }
        bucket.Clear();

        gameManager.AddCoin( totalGold );
    }

    [Button( "Show" )]
    public void Show ()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1;
    }

    [Button( "Hide" )]
    public void Hide ()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
    }
}
