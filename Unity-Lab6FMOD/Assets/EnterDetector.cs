using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterDetector : MonoBehaviour
{
    [SerializeField] UnityEvent onPlayerInsideCheckEnter = new UnityEvent();
    [SerializeField] UnityEvent onPlayerInsideCheckLeave = new UnityEvent();


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerInsideCheckEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerInsideCheckLeave.Invoke();
        }
    }
}
