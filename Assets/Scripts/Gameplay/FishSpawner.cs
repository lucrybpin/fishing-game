

using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    [SerializeField] [Range( 1f, 100f )] float interval = 1f;
    [SerializeField] [Range( 1f, 150f )] int top = 1;
    [SerializeField] [Range( 1f, 150f )] int bottom = 1;
    //[SerializeField] 
    [SerializeField] List<GameObject> prefabs;

    private void OnValidate ()
    {
        if (top > bottom )
            top = bottom;
    }

    private void Start ()
    {
        _ = Spawn();
    }

    private async UniTask Spawn ()
    {

        while (true)
        {
            await UniTask.Delay( TimeSpan.FromSeconds( this.interval ) );
            float xPosition = 0;
            Fish.FishRotation rotation;
            if (UnityEngine.Random.Range( 0, 100 ) > 50)
            {
                xPosition = -21f;
                rotation = Fish.FishRotation.right;
            }
            else
            {
                xPosition = 21f;
                rotation = Fish.FishRotation.left;
            }

            Fish newFish = Instantiate( prefabs [ 0 ], new Vector3( xPosition, UnityEngine.Random.Range( -top, -bottom ), 0 ), Quaternion.identity ).GetComponent<Fish>();
            newFish.Setup( UnityEngine.Random.Range( .5f, 1.4f ), rotation );
        }

    }
}
