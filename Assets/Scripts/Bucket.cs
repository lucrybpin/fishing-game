using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] WatchableInt currentSize;
    [SerializeField] WatchableInt maxSize;

    [SerializeField] [Range(1, 100)] int bucketMaxSize;
    [SerializeField] List<Fish> fishes = new List<Fish>();
    [SerializeField] Transform fishStackPosition;

    private void Start ()
    {
        SyncWatchables();
    }

    public void AddFish(Fish newFish)
    {
        fishes.Add( newFish );
        newFish.transform.position = this.fishStackPosition.position;
        SyncWatchables();
    }

    private void SyncWatchables ()
    {
        currentSize.Value = fishes.Count;
        maxSize.Value = bucketMaxSize;
    }

    public bool IsFull()
    {
        return fishes.Count >= bucketMaxSize;
    }
}
