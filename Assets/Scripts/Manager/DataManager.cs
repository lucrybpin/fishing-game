using UnityEngine;
using BayatGames.SaveGameFree;
using NaughtyAttributes;
using System.Collections.Generic;
using System;

public class DataManager : MonoBehaviour
{
    [SerializeField] GameSave currentSave;

    [SerializeField] WatchableInt watchableCoins;
    [SerializeField] WatchableInt watchableBucketcurrent;
    [SerializeField] WatchableInt watchableBucketMax;
    [SerializeField] WatchableFloat watchableLineCurrent;
    [SerializeField] WatchableFloat watchableLineMax;


    [Button("Save Game")]
    public void SaveState()
    {
        currentSave = new GameSave();
        currentSave.coins = PlayerCoins;
        currentSave.bucketCurrent = BucketCurrent;
        currentSave.bucketMax = BucketMax;
        currentSave.lineCurrent = LineCurrent;
        currentSave.lineMax = LineMax;
        currentSave.currentBucketFishes = FishesToSaveData( FindObjectOfType<Bucket>().Fishes );
        SaveGame.Save<GameSave>( "save_0", currentSave );
    }

    [Button("Load Save")]
    public void LoadSave()
    {
        currentSave = SaveGame.Load<GameSave>( "save_0" );
        watchableCoins.Value = currentSave.coins;
        watchableBucketcurrent.Value = currentSave.bucketCurrent;
        watchableBucketMax.Value = currentSave.bucketMax;
        watchableLineCurrent.Value = currentSave.lineCurrent;
        watchableLineMax.Value = currentSave.lineMax;
        FindObjectOfType<Bucket>().Fishes = DataManager.FishSaveDataToFish( currentSave.currentBucketFishes );
    }

    private List<FishSaveData> FishesToSaveData (List<Fish> fishes)
    {
        List<FishSaveData> fishDataList = new List<FishSaveData>();
        foreach (Fish fish in fishes)
        {
            Type fishType = fish.GetType();
            FishSaveData fishData = new FishSaveData( fishType );
            fishDataList.Add( fishData );
        }
        return fishDataList;
    }

    public static List<Fish> FishSaveDataToFish(List<FishSaveData> fishesSaveData)
    {
        //TODO: This is all hardcoded by types. Foreach new fish type this is chaning
        //      improve this later
        List<Fish> fishes = new List<Fish>();
        foreach (FishSaveData fishSaveData in fishesSaveData)
        {
            GameObject fishGameObject = Utils.GetPrefabByName<GameObject>( fishSaveData.typeName );
            Fish newFish = Instantiate( fishGameObject, new Vector3(0, 100, 0), Quaternion.identity ).GetComponent<Fish>();
            fishes.Add( newFish );
            //if (fishSaveData.typeName == "Tuna")
            //{
                
                
                
            //} else
            //{
            //    Debug.LogError( "Please add to DataManager.FishSaveDataToFish() an implementation for fish of type: " + fishSaveData.typeName );
            //}
        }
        return fishes;
    }

    public int PlayerCoins
    {
        get { return watchableCoins.Value; }
        set { watchableCoins.Value = value; }
    }

    public int BucketCurrent
    {
        get { return watchableBucketcurrent.Value; }
        set { watchableBucketcurrent.Value = value; }
    }

    public int BucketMax
    {
        get { return watchableBucketMax.Value; }
        set { watchableBucketMax.Value = value; }
    }

    public float LineCurrent
    {
        get { return watchableLineCurrent.Value; }
        set { watchableLineCurrent.Value = value; }
    }

    public float LineMax
    {
        get { return watchableLineMax.Value; }
        set { watchableLineMax.Value = value; }
    }

}
