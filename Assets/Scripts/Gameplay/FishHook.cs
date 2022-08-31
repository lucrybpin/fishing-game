using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHook : MonoBehaviour {

    
    [SerializeField] Bucket bucket;
    [SerializeField] Fish fish;

    [SerializeField] [Range( 0.52f, 3f )] float downSpeed = .52f;
    [SerializeField] [Range(2f, 7f)] float upSpeed = 2f;
    float verticalSpeed;
    [SerializeField] float fishiReleaseLevel = 1.25f;

    [SerializeField] WatchableFloat lineCurrent;
    [SerializeField] WatchableFloat lineMax;

    GameManager gameManager;

    private void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update ()
    {
        SyncWatchables();

        verticalSpeed = 0;

        if (( Input.GetKey( KeyCode.Space ) || Input.GetKey( KeyCode.W ) ) && !IsAtReleaseLevel())
            verticalSpeed = -upSpeed;

        if (( Input.GetKey( KeyCode.DownArrow ) || Input.GetKey( KeyCode.S ) ) && transform.position.y > -lineMax.Value)
            verticalSpeed = downSpeed;

        if (IsAtReleaseLevel())
            ReleaseFish();

        transform.Translate( 0, -verticalSpeed * Time.deltaTime, 0 );
    }

    private void SyncWatchables ()
    {
        Vector3 position = transform.position;
        position.y = Mathf.Clamp( transform.position.y, -gameManager.DataManager.LineMax, 0 );
        lineCurrent.Value = -position.y;
    }

    private bool IsAtReleaseLevel ()
    {
        return transform.position.y >= fishiReleaseLevel;
    }

    public void SetFish(Fish fish)
    {
        this.fish = fish;
        this.fish.Setup( 0f );
        fish.transform.SetParent( this.transform );
    }

    public void ReleaseFish()
    {
        if (this.fish == null)
            return;

        if (bucket.IsFull())
        {
            Fish fishDiscard = this.fish;
            this.fish = null;
            Destroy( fishDiscard.gameObject );
            return;
        }

        bucket.AddFish( this.fish );
        this.fish = null;
    }

    private void OnTriggerEnter (Collider other)
    {
        CatchFish( other );
    }

    private void CatchFish (Collider other)
    {
        if (this.fish != null)
            return;

        if (other.gameObject.transform.parent.TryGetComponent( out Fish fish ))
        {
            SetFish( fish );
        }
    }
}
