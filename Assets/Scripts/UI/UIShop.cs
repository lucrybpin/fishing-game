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
        fishValues.Add( typeof( Mackerel ), 10 );
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

        if (totalGold > 10)
        {
            _ = gameManager.AddCoinsOverTime( totalGold, 1f );
            _ = Utils.MultipleExecutionAsync( 21, 0.052f, () => {
                gameManager.AudioManager.PlayGameSound( AudioManager.GameSoundEvents.EarnCoin );
            } );
        }
        else {
            _ = Utils.MultipleExecutionAsync( totalGold, 0.052f, () => {
                gameManager.AddCoins( 1 );
                gameManager.AudioManager.PlayGameSound( AudioManager.GameSoundEvents.EarnCoin );
            } );
        }

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
