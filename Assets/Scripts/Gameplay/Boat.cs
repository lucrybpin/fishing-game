using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private void Update ()
    {
        float horizontalInput = Input.GetAxisRaw( "Horizontal" );
        if (transform.transform.position.x >= 30 && horizontalInput > 0)
            return;
        transform.Translate( new Vector3( horizontalInput * Time.deltaTime, 0, 0 ) );
    }
}
