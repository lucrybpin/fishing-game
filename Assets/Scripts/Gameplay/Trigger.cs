using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntruderGameObjectEvent : UnityEvent<GameObject> {
}

public class Trigger : MonoBehaviour
{
    [Header("Basic Actions")]
    [SerializeField] UnityEvent OnEnter;
    [SerializeField] UnityEvent OnExit;
    [Header( "Intruder Actions" )]
    [SerializeField] IntruderGameObjectEvent OnIntruderEnter;
    [SerializeField] IntruderGameObjectEvent OnIntruderExit;

    private void OnTriggerEnter (Collider other)
    {
        OnEnter?.Invoke();
        OnIntruderEnter?.Invoke( other.gameObject );
    }

    private void OnTriggerExit (Collider other)
    {
        OnExit?.Invoke();
        OnIntruderExit?.Invoke( other.gameObject );
    }
}
