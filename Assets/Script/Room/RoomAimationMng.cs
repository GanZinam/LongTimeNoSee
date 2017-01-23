using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAimationMng : MonoBehaviour
{
    public GameObject Room;

    public void AniFinsh()
    {
        SMng.Instance.Hero.GetComponent<Hero>().AniFinsh_statusCh();
        GetComponent<Animator>().SetBool("Into", false);
        if (!SMng.Instance.RoomInit)
        {
            Room.SetActive(true);
            SMng.Instance.RoomInit = true;
        }
        else
        {
            Room.SetActive(false);
            SMng.Instance.RoomInit = false;
        }
    }
}
