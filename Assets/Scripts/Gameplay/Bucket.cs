using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] WatchableInt currentSize;
    [SerializeField] WatchableInt maxSize;

    //[SerializeField] [Range(1, 100)] int bucketMaxSize;
    [SerializeField] List<Fish> fishes = new List<Fish>();
    [SerializeField] Transform fishStackPosition;

    public List<Fish> Fishes { get => fishes; set => fishes =  value ; }

    private void Start ()
    {
        SyncWatchables();
    }

    public void AddFish(Fish newFish)
    {
        newFish.InSea = false;
        fishes.Add( newFish );
        newFish.transform.SetParent( this.transform );
        newFish.transform.position = this.fishStackPosition.position;
        SyncWatchables();
    }

    private void SyncWatchables ()
    {
        currentSize.Value = fishes.Count;
    }

    public bool IsFull()
    {
        //fishesList.Value.Count
        return fishes.Count >= maxSize.Value;
    }

    public void Clear()
    {
        foreach (Fish fish in fishes)
            Destroy( fish.gameObject );
        fishes.Clear();
        SyncWatchables();
    }
}
