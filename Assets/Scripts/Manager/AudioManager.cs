using Cysharp.Threading.Tasks;
using FMODUnity;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Required] [SerializeField] EventReference catchFishSound;
    [Required] [SerializeField] EventReference earnCoinSound;

    public enum GameSoundEvents {
        CatchFish,
        EarnCoin
    }

    public EventReference GetGameSound (GameSoundEvents soundEvent)
    {
        switch (soundEvent)
        {
            case GameSoundEvents.CatchFish:
            return catchFishSound;

            case GameSoundEvents.EarnCoin:
            return earnCoinSound;

            default:
            return catchFishSound;
        }
    }

    public void PlayGameSound(GameSoundEvents soundEvent)
    {
        PlaySound( GetGameSound( soundEvent ) );
    }


    public void PlaySound(EventReference audioKey)
    {
        RuntimeManager.CreateInstance( audioKey ).start();
    }

    public async UniTask PlaySequenceDelayed (EventReference audioKey, int amountOfTimes, float interval)
    {
        for (int i = 0; i < amountOfTimes; i++)
        {
            PlaySound( audioKey );
            await UniTask.Delay( TimeSpan.FromSeconds( interval ) );
        }
    }

    public async UniTask PlaySequenceDelayed (GameSoundEvents soundEvent, int amountOfTimes, float interval)
    {
        EventReference audioKey = GetGameSound( soundEvent );
        for (int i = 0; i < amountOfTimes; i++)
        {
            PlaySound( audioKey );
            await UniTask.Delay( TimeSpan.FromSeconds( interval ) );
        }
    }
}
