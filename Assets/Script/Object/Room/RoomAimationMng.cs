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
        if (Room != null)
        {
            if (!SMng.RoomInit)
            {
                Room.SetActive(true);
                SMng.RoomInit = true;
            }
            else
            {
                Room.SetActive(false);
                SMng.RoomInit = false;
            }
        }
    }
}