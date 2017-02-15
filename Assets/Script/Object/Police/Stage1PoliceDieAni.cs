using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1PoliceDieAni : MonoBehaviour {

	public void AniFin()
    {
        transform.GetComponent<Animator>().SetBool("Die",false);
    }
    public void deathSound()
    {
        GM.AudioManager.instance.deathPolice();
    }
}
