using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Animation : MonoBehaviour
{
    public void e()
    {
        GM.AudioManager.instance.init();
        SceneManager.LoadScene("End");
    }
}
