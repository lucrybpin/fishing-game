using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xRotation = 0;
    float yRotation = 0;

    [SerializeField] Rigidbody rigidbody;

    [SerializeField] float speed = 7f;

    private void Update ()
    {
        xRotation -= Input.GetAxisRaw( "Mouse Y" ) * Time.deltaTime * 100;
        yRotation += Input.GetAxisRaw( "Mouse X" ) * Time.deltaTime * 100;
        xRotation = Mathf.Clamp( xRotation, -90f, 90 );

        transform.rotation = Quaternion.Euler( xRotation, yRotation, 0 );
        rigidbody.transform.rotation = Quaternion.Euler( 0, yRotation, 0 );

        Vector3 moveDirection = Input.GetAxisRaw( "Horizontal" ) * rigidbody.transform.transform.right +
                                Input.GetAxisRaw( "Vertical" ) * rigidbody.transform.forward;

        rigidbody.AddForce( moveDirection.normalized * speed, ForceMode.Force );
    }
}
