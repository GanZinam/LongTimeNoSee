using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GM
{
    public class LevelManager : MonoBehaviour
    {
        //public GameObject loadingCanvas;
        public static int myLevel;

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

        [SerializeField]
        CameraFollow cam;

        bool _Touch = false;

        void Start()
        {
            if (myLevel.Equals(0))
                introCanvas.SetActive(true);
            else
            {
                GM.AudioManager.instance.ingameBG();

                cam.gameObject.GetComponent<Animator>().enabled = false;
            }

            if (myLevel.Equals(2))
                Hero.upSize = 4;
            else
                Hero.upSize = 6;
        }

        void Update()
        {
            if (SMng.Instance.LevelMng_PoliceDie && !_Touch)
            {
                _Touch = true;
                Sit.GetComponent<SpriteRenderer>().sprite = Sit_;
                SMng.Instance.Hero.SetActive(true);
                MurderIcon.SetActive(false);
            }
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

        bool isLight = true;

        public IEnumerator direct_0()
        {
            if (isLight)
            {
                // 불 꺼짐
                yield return new WaitForSeconds(8);
                thunderAnimator.SetTrigger("Light0");
                yield return new WaitForSeconds(1);
                thunderScreenAnimator.SetBool("Bright", false);
                thunderScreenAnimator.SetTrigger("Thunder");
                isLight = false;
            }

            if (!isLight)
            {
                // 불 켜짐
                yield return new WaitForSeconds(15);
                thunderAnimator.SetTrigger("Light1");
                yield return new WaitForSeconds(1);
                thunderScreenAnimator.SetBool("Bright", true);
                thunderScreenAnimator.SetTrigger("Thunder");
                MurderIcon.SetActive(false);
                if (SMng.Instance.LevelMng_PoliceDie)
                {
                    SMng.Instance.hideWeapon.SetActive(false);
                    SMng.Instance.Hero.SetActive(true);
                    SMng.Direction = 0;
                }
                isLight = true;
            }

            if (isLight)
            {
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
                isLight = false;
            }

            if (!isLight)
            {
                // 불 켜짐
                yield return new WaitForSeconds(16);
                thunderAnimator.SetTrigger("Light1");
                yield return new WaitForSeconds(1);
                thunderScreenAnimator.SetBool("Bright", true);
                thunderScreenAnimator.SetTrigger("Thunder");
                MurderIcon.SetActive(false);
                if (SMng.Instance.LevelMng_PoliceDie)
                {
                    SMng.Instance.hideWeapon.SetActive(false);
                    SMng.Instance.Hero.SetActive(true);
                    SMng.Direction = 0;
                }
                isLight = true;
            }
        }
    }
}