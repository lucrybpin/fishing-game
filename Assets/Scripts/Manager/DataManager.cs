using UnityEngine;
using BayatGames.SaveGameFree;
using NaughtyAttributes;
using System.Collections.Generic;
using System;

public class DataManager : MonoBehaviour {
    [SerializeField] GameSave currentSave;

    [SerializeField] WatchableInt watchableCoins;
    [SerializeField] WatchableInt watchableBucketLevel;
    [SerializeField] WatchableInt watchableBucketcurrent;
    [SerializeField] WatchableInt watchableBucketMax;
    [SerializeField] WatchableInt watchableLineLevel;
    [SerializeField] WatchableInt watchableSinkSpeedLevel;
    [SerializeField] WatchableFloat watchableSinkSpeed;
    [SerializeField] WatchableInt watchableFloatLevel;
    [SerializeField] WatchableFloat watchableFloatSpeed;
    [SerializeField] WatchableFloat watchableLineCurrent;
    [SerializeField] WatchableFloat watchableLineMax;

    private void Start ()
    {
        //LoadSave();
    }

    [Button( "Clear Current Save" )]
    public void ClearCurrentSave ()
    {
        currentSave = new GameSave();
        currentSave.coins = 0;
        currentSave.bucketLevel = 0;
        currentSave.bucketCurrent = 0;
        currentSave.bucketMax = GamePresetsData.GetBucketSizeByUpgradeLevel( 0 );
        currentSave.lineLevel = 0;
        currentSave.lineCurrent = 0;
        currentSave.lineMax = GamePresetsData.GetLineLimitByUpgradeLevel( 0 );
        currentSave.sinkSpeedLevel = 0;
        currentSave.sinkSpeed = GamePresetsData.GetSinkSpeedByUpgradeLevel( 0 );
        currentSave.floatLevel = 0;
        currentSave.floatSpeed = GamePresetsData.GetFloatSpeedByUpgradeLevel( 0 );
        currentSave.currentBucketFishes = new List<FishSaveData>();
        SaveGame.Save<GameSave>( "save_0", currentSave );
    }


    [Button( "Save Game" )]
    public void SaveState ()
    {
        currentSave = new GameSave();
        currentSave.coins = PlayerCoins;
        currentSave.bucketLevel = BucketLevel;
        currentSave.bucketCurrent = BucketCurrent;
        currentSave.bucketMax = BucketMax;
        currentSave.lineLevel = LineLevel;
        currentSave.lineCurrent = LineCurrent;
        currentSave.lineMax = LineMax;
        currentSave.sinkSpeedLevel = SinkSpeedLevel;
        currentSave.sinkSpeed = SinkSpeed;
        currentSave.floatLevel = FloatSpeedLevel;
        currentSave.floatSpeed = FloatSpeed;
        currentSave.currentBucketFishes = FishesToSaveData( FindObjectOfType<Bucket>().Fishes );
        SaveGame.Save<GameSave>( "save_0", currentSave );
    }

    [Button( "Load Save" )]
    public void LoadSave ()
    {
        currentSave = SaveGame.Load<GameSave>( "save_0" );
        watchableCoins.Value = currentSave.coins;
        watchableBucketLevel.Value = currentSave.bucketLevel;
        watchableBucketcurrent.Value = currentSave.bucketCurrent;
        watchableBucketMax.Value = currentSave.bucketMax;
        watchableLineLevel.Value = currentSave.lineLevel;
        watchableLineCurrent.Value = currentSave.lineCurrent;
        watchableLineMax.Value = currentSave.lineMax;
        watchableSinkSpeedLevel.Value = currentSave.sinkSpeedLevel;
        watchableSinkSpeed.Value = currentSave.sinkSpeed;
        watchableFloatLevel.Value = currentSave.floatLevel;
        watchableFloatSpeed.Value = currentSave.floatSpeed;
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

    public static List<Fish> FishSaveDataToFish (List<FishSaveData> fishesSaveData)
    {
        //TODO: This is all hardcoded by types. Foreach new fish type this is chaning
        //      improve this later
        List<Fish> fishes = new List<Fish>();
        foreach (FishSaveData fishSaveData in fishesSaveData)
        {
            GameObject fishGameObject = Utils.GetPrefabByName<GameObject>( fishSaveData.typeName );
            Fish newFish = Instantiate( fishGameObject, new Vector3( 0, 100, 0 ), Quaternion.identity ).GetComponent<Fish>();
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

    public int BucketLevel
    {
        get { return watchableBucketLevel.Value; }
        set { watchableBucketLevel.Value = value; }
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

    public int LineLevel
    {
        get { return watchableLineLevel.Value; }
        set { watchableLineLevel.Value = value; }
    }

    public int SinkSpeedLevel
    {
        get { return watchableSinkSpeedLevel.Value; }
        set { watchableSinkSpeedLevel.Value = value; }
    }

    public float SinkSpeed
    {
        get { return watchableSinkSpeed.Value; }
        set { watchableSinkSpeed.Value = value; }
    }

    public int FloatSpeedLevel
    {
        get { return watchableFloatLevel.Value; }
        set { watchableFloatLevel.Value = value; }
    }

    public float FloatSpeed
    {
        get { return watchableFloatSpeed.Value; }
        set { watchableFloatSpeed.Value = value; }
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
