using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    public enum FishRotation {
        left,
        right
    }


    public void Setup(float speed, FishRotation rotation = FishRotation.left)
    {
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
        if (transform.position.x < -25f || transform.position.x > 25f)
            Destroy( gameObject );
    }

}
