using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CameraMode currentCameraMode = CameraMode.Hook;
    [SerializeField] Vector3 hookOffset;
    [SerializeField] Vector3 hookOffsetRotation;
    [SerializeField] Vector3 boatOffset;
    [SerializeField] Vector3 boatOffsetRotation;
    [SerializeField] Transform fishHook;
    [SerializeField] Transform boat;
    float smoothTime = 0.21f;
    Vector3 velocity = Vector3.zero;

    private void Update ()
    {
        switch (currentCameraMode)
        {
            case CameraMode.Hook:
            FollowHook();
            break;

            case CameraMode.Boat:
            FollowBoat();
            break;
        }
        
    }

    private void FollowHook()
    {
        Vector3 targetPosition = fishHook.position + hookOffset;
        this.transform.position = Vector3.SmoothDamp( transform.position, targetPosition, ref velocity, smoothTime );
        this.transform.rotation = Quaternion.Euler( hookOffsetRotation );
    }

    private void FollowBoat ()
    {
        Vector3 targetPosition = boat.position + boatOffset;
        this.transform.position = Vector3.SmoothDamp( transform.position, targetPosition, ref velocity, smoothTime );
        this.transform.rotation = Quaternion.Euler( boatOffsetRotation );
    }

    enum CameraMode {
        Hook,
        Boat
    }

}
