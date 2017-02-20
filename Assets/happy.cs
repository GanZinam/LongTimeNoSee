using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class happy : MonoBehaviour {

    public GameObject Black;
    public GameObject Text;

    public void GunShootSound()
    {
        Black.SetActive(true);
        Text.SetActive(true);
    }

    public void ring()
    {
        GM.AudioManager.instance.call();
    }       
}
