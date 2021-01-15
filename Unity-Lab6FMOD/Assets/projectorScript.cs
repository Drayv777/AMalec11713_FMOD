using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class projectorScript : MonoBehaviour
{
    [SerializeField, EventRef] string globeAppear; 
    [SerializeField, EventRef] string globeHide;

    EventInstance globeAppearInstance;
    
    [SerializeField] UnityEvent onGlobeAppear= new UnityEvent();
    [SerializeField] UnityEvent onGlobeHide = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onGlobeAppear.Invoke();
            globeAppearInstance = RuntimeManager.CreateInstance(globeAppear);
            globeAppearInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
            globeAppearInstance.start();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onGlobeHide.Invoke();
            if (globeAppearInstance.isValid()) {
                globeAppearInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                globeAppearInstance.release();
                globeAppearInstance.clearHandle();
            }
                
            RuntimeManager.PlayOneShot(globeHide);
        }
    }
}
