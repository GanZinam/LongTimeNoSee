using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("changeScene");
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(3);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
