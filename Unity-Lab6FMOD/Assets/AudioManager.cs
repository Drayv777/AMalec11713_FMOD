using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    [SerializeField] UnityEvent TurnOnBothAmbient;
    [SerializeField] UnityEvent TurnOffOutsideAmbient;
    [SerializeField] UnityEvent TurnOffInsideAmbient;

    bool player_inside = false;
    bool inside_check = false;

    public void PlayerEnter(bool enter)
    {
        inside_check = enter;
    }

    public void DoorOpen(bool open)
    {
        //player inside, door closed -> player inside
        if (!open && inside_check)
        {
            player_inside = true;
        }
        //player outside, door closed -> player outside
        //player inside doors
        if ((!open && !inside_check) || (player_inside && open))
        {
            player_inside = false;
        }
        //turn on both ambient
        TurnOnBothAmbient.Invoke();
    }

    public void DoorClosed()
    {
        if (player_inside)
            TurnOffOutsideAmbient.Invoke();
        else
            TurnOffInsideAmbient.Invoke();
    }

}
