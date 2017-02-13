using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GM
{
    public class LevelManager : MonoBehaviour
    {
        //public GameObject loadingCanvas;
        public static int myLevel = 1;

        [SerializeField]
        GameObject introCanvas;
        [SerializeField]
        GameObject loadingObj;

        // LevelManager.cs
        [SerializeField]
        Animator thunderScreenAnimator;
        [SerializeField]
        Animator thunderAnimator;
        
        [SerializeField]
        GameObject Sit;
        [SerializeField]
        Sprite Sit_;


        void Start()
        {
            //DontDestroyOnLoad(this);

            if (myLevel.Equals(0))
            {
                introCanvas.SetActive(true);
            }
        }

        public IEnumerator loading(bool isClear)
        {
            SMng.Direction = 3;

            SMng.interection = true;

            loadingObj.SetActive(true);

            yield return new WaitForSeconds(1);
            if (isClear)
            {
                myLevel++;
            }
            else
            {

            }

            SceneManager.LoadScene("Game");
            yield return new WaitForSeconds(4);

            SMng.Direction = 0;

            SMng.interection = false;
        }


       

        public IEnumerator direct_0()
        {
            // 불 꺼짐
            yield return new WaitForSeconds(8);
            thunderAnimator.SetTrigger("Light0");
            yield return new WaitForSeconds(1);
            thunderScreenAnimator.SetBool("Bright", false);
            thunderScreenAnimator.SetTrigger("Thunder");


            // 불 켜짐
            yield return new WaitForSeconds(15);
            thunderAnimator.SetTrigger("Light1");
            yield return new WaitForSeconds(1);
            thunderScreenAnimator.SetBool("Bright", true);
            thunderScreenAnimator.SetTrigger("Thunder");
            Sit.GetComponent<SpriteRenderer>().sprite = Sit_;
            SMng.Instance.Hero.SetActive(true);
            SMng.Direction = 0;

            // 불 꺼짐
            yield return new WaitForSeconds(9);
            thunderAnimator.SetTrigger("Light0");
            yield return new WaitForSeconds(1);
            thunderScreenAnimator.SetBool("Bright", false);
            thunderScreenAnimator.SetTrigger("Thunder");

            // 불 켜짐
            yield return new WaitForSeconds(16);
            thunderAnimator.SetTrigger("Light1");
            yield return new WaitForSeconds(1);
            thunderScreenAnimator.SetBool("Bright", true);
            thunderScreenAnimator.SetTrigger("Thunder");
        }
    }
}