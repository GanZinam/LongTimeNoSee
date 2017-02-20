using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAimationMng : MonoBehaviour
{
    public GameObject Room;

    public void AniFinsh_()
    {
        Debug.Log("AOISJFWAOIEJ");
        try
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
        catch (Exception e)
        {
            Debug.Log(e);
        }
        //catch (UnityException ed)
        //{
        //    Debug.Log(e);
        //}

    }
}