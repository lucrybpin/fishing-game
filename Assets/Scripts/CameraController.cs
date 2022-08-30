using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] Transform fishHook;
    float smoothTime = 0.21f;
    Vector3 velocity = Vector3.zero;

    private void Update ()
    {
        FollowHook();
    }
    private void FollowHook()
    {
        Vector3 targetPosition = fishHook.position + offset;
        this.transform.position = Vector3.SmoothDamp( transform.position, targetPosition, ref velocity, smoothTime );
    }

}
