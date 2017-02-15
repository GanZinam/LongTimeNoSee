using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GM
{
    public class LevelManager : MonoBehaviour
    {
        //public GameObject loadingCanvas;
        public static int myLevel = 0;

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

        [SerializeField]
        GameObject MurderIcon;
        [SerializeField]
        GameObject Police;


        void Start()
        {
            if (myLevel.Equals(0))
                introCanvas.SetActive(true);
            else
                GM.AudioManager.instance.ingameBG();
            
            if (myLevel.Equals(2))
                Hero.upSize = 4;
            else
                Hero.upSize = 6;
        }

        public IEnumerator loading(bool isClear)
        {
            SMng.Instance.hideWeapon.SetActive(true);
            SMng.Direction = 3;

            SMng.interection = true;

            loadingObj.SetActive(true);

            yield return new WaitForSeconds(1);
            if (isClear)
            {
                myLevel++;
                Inventory.saveItems = Inventory.items;
                SMng.Instance._inventory.refeshInventory();
                PlayerPrefs.SetInt("myLevel", myLevel);
                for (int i = 0; i < 10; i++)
                    PlayerPrefs.SetString(string.Format("ITEM_{0}", i), Inventory.saveItems[i].code + ":" + Inventory.saveItems[i].num);
            }
            else
            {
                Inventory.items = Inventory.saveItems;
            }

            SceneManager.LoadScene("Game");
            yield return new WaitForSeconds(4);

            SMng.Instance.hideWeapon.SetActive(false);
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
            MurderIcon.SetActive(true);

            // 불 켜짐
            yield return new WaitForSeconds(15);
            thunderAnimator.SetTrigger("Light1");
            yield return new WaitForSeconds(1);
            thunderScreenAnimator.SetBool("Bright", true);
            thunderScreenAnimator.SetTrigger("Thunder");
            MurderIcon.SetActive(false);

            if (SMng.Instance.LevelMng_PoliceDie)
            {
                Sit.GetComponent<SpriteRenderer>().sprite = Sit_;
                SMng.Instance.hideWeapon.SetActive(false);
                SMng.Instance.Hero.SetActive(true);
                SMng.Direction = 0;
            }
            // 불 꺼짐
            yield return new WaitForSeconds(9);
            thunderAnimator.SetTrigger("Light0");
            yield return new WaitForSeconds(1);
            thunderScreenAnimator.SetBool("Bright", false);
            thunderScreenAnimator.SetTrigger("Thunder");
            if (!SMng.Instance.LevelMng_PoliceDie)
            {
                MurderIcon.SetActive(true);
            }

            // 불 켜짐
            yield return new WaitForSeconds(16);
            thunderAnimator.SetTrigger("Light1");
            yield return new WaitForSeconds(1);
            thunderScreenAnimator.SetBool("Bright", true);
            thunderScreenAnimator.SetTrigger("Thunder");
            MurderIcon.SetActive(false);
            if (SMng.Instance.LevelMng_PoliceDie)
            {
                Sit.GetComponent<SpriteRenderer>().sprite = Sit_;
                SMng.Instance.hideWeapon.SetActive(false);
                SMng.Instance.Hero.SetActive(true);
                SMng.Direction = 0;
            }
        }
    }
}