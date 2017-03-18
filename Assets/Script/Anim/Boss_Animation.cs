using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Animation : MonoBehaviour
{
    [SerializeField]
    Animator movieHide;

    public void e()
    {
        SMng.Instance.HeroAnimator.SetBool("Final", false);
        SMng.Instance.BossLife = true;
        //GM.AudioManager.instance.init();
        //SceneManager.LoadScene("End");
        SMng.Direction = 0;
        movieHide.SetTrigger("SHOW");
    }
}
