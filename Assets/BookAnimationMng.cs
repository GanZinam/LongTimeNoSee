using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAnimationMng : MonoBehaviour
{

    public void AniFinsh()
    {
        SMng.Instance.Hero.GetComponent<Hero>().AniFinsh_statusCh();
        GetComponent<Animator>().SetBool("Into", false);
        if (!SMng.RoomInit)
        {
            SMng.RoomInit = true;
        }
        else
        {
            SMng.RoomInit = false;
        }
    }

    public void cameraShake()
    {
        SMng.Instance.cam.shaking();
    }
}
