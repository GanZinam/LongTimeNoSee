using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAnimationMng : MonoBehaviour
{

    public void _AniFinsh()
    {
        SMng.Instance.Hero.GetComponent<Hero>().AniFinsh_statusCh();
        GetComponent<Animator>().SetBool("BookInto", false);
    }

    public void cameraShake()
    {
        SMng.Instance.cam.shaking();
    }
}
