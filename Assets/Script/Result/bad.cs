using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bad : MonoBehaviour {

    public GameObject Black;

	public void GunShootSound()
    {
        GM.AudioManager.instance.suicide();
        Black.SetActive(true);
    }
}
