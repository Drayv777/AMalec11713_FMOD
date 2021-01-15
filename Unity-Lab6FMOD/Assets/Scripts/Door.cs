using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour {
    [SerializeField] Animator animator;
    [SerializeField] UnityEvent onDoorOpen = new UnityEvent();
    [SerializeField] UnityEvent onDoorClosing = new UnityEvent();
    [SerializeField] UnityEvent onDoorClosed = new UnityEvent();

    [SerializeField, EventRef] string doorOpen;
    [SerializeField, EventRef] string doorClose;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            animator.SetBool("character_nearby", true);
            onDoorOpen.Invoke();
            RuntimeManager.PlayOneShot(doorOpen, transform.position);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            animator.SetBool("character_nearby", false);
            onDoorClosing.Invoke();
            RuntimeManager.PlayOneShot(doorClose, transform.position);
        }
    }

    void DoorClosed()
    {
        onDoorClosed.Invoke();
    }
}
