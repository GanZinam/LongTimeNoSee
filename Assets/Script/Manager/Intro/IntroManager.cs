using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    void Start()
    {
        //! 테스트하기 위해 사용 ( 추출 시 주석 할 것 )
        if (PlayerPrefs.HasKey("myLevel")) PlayerPrefs.DeleteKey("myLevel");
        //PlayerPrefs.SetInt("myLevel", 0);
        
        if (PlayerPrefs.HasKey("myLevel"))
        {
            // 기존 데이터 불러오기
            GM.LevelManager.myLevel = PlayerPrefs.GetInt("myLevel");
            for (int i = 0; i < 10; i++)
            {
                string tempStr = PlayerPrefs.GetString(string.Format("ITEM_{0}", i));
                string[] words = tempStr.Split(':');

                int code = System.Convert.ToInt32(words[0]);
                int num = System.Convert.ToInt32(words[1]);

                if (code > 0)
                {
                    Inventory.saveItems[i].code = code;
                    Inventory.saveItems[i].num = num;
                }
            }
            Inventory.items = Inventory.saveItems;
        }
        else
        {
            // 초기화
            PlayerPrefs.SetInt("myLevel", 0);
            for (int i = 0; i < 10; i++)
                PlayerPrefs.SetString(string.Format("ITEM_{0}", i), "0:0");
        }
        StartCoroutine("changeScene");
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(2);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
