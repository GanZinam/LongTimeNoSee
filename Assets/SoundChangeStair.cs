using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChangeStair : MonoBehaviour
{
    public bool stage_0_room;
    public GM.LevelManager l;

    public void changeSound()
    {
        if (stage_0_room)
        {
            l.StartCoroutine("direct_0");
            StartCoroutine(GM.AudioManager.instance.changeVolume(GM.AudioManager.instance.rainBG));
        }
        else
        {
            l.StopCoroutine("direct_0");
            StartCoroutine(GM.AudioManager.instance.changeVolume(GM.AudioManager.instance.ingameBG));
        }
    }
}
