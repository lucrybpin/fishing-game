using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Fish : MonoBehaviour
{
    [SerializeField] bool inSea = false;
    [SerializeField] Vector3 direction = Vector3.zero;
    [SerializeField] float speed = 0;

    public bool InSea { get => inSea; set => inSea =  value ; }

    public enum FishRotation {
        left,
        right
    }


    public void Setup(float speed, FishRotation rotation = FishRotation.left, bool inSea = true)
    {
        this.inSea = inSea;
        this.speed = speed;
        switch (rotation)
        {
            case FishRotation.left:
            this.transform.rotation = Quaternion.Euler( 0, 270, 0 );
            break;
            case FishRotation.right:
            this.transform.rotation = Quaternion.Euler( 0, 90, 0 );
            break;
        }
    }

    void Update()
    {
        Move();
        DestroyOnBoundaries();
    }

    public void Move ()
    {
        transform.Translate( Vector3.forward * this.speed * Time.deltaTime );
    }

    private void DestroyOnBoundaries ()
    {
        if (!inSea)
            return;

        if (transform.position.x < -25f || transform.position.x > 25f)
            Destroy( gameObject );
    }

}
