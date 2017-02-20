using UnityEngine;
using System.Collections;

public class RoomIntoBt : MonoBehaviour
{

    public Sprite OutSpr;
    public Sprite IntoSpr;

    public bool finishRoom = false;
    public bool MinigameRoom = false;

    public GameObject MiniGame2;

    public GameObject Room;

    void Update()
    {
        // 문들어가는거 클릭
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (!SMng.Instance.MiniGameStart && hit.transform.CompareTag("GoDoor") 
                    && transform.parent.GetComponentInChildren<Animator>().GetBool("Into").Equals(false) 
                    && !SMng.interection && MinigameRoom && SMng.Instance._inventory.ishaveItem(7))
                {
                    if (SMng.Instance.MGComplite[1])
                    {
                        if (Room != null)
                        {
                            if (!SMng.RoomInit)
                            {
                                Room.SetActive(true);
                                SMng.RoomInit = true;
                            }
                            else
                            {
                                Room.SetActive(false);
                                SMng.RoomInit = false;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("GameStart");
                        SMng.Instance.MiniGameStart = true;
                        SMng.interection = true;
                        SMng.Instance.hideWeapon.SetActive(true);
                        SMng.Direction = 3;
                        SMng.Hide = true;
                        MiniGame2.SetActive(true);
                    }
                }
                else if (hit.transform.CompareTag("GoDoor") && transform.parent.GetComponentInChildren<Animator>().GetBool("Into").Equals(false) 
                    && !SMng.interection && !MinigameRoom)
                {
                    if (finishRoom)
                    {
                        if (GM.LevelManager.myLevel.Equals(0) && SMng.Instance._inventory.ishaveWeapon() && !SMng.sit)              // 1스테이지 무기유무
                        {
                            StartCoroutine(SMng.Instance._level.loading(true));
                            IntRoom();
                        }
                        if (GM.LevelManager.myLevel.Equals(1) && SMng.Instance.MGComplite[0] && !SMng.sit)
                        {
                            StartCoroutine(SMng.Instance._level.loading(true));
                            IntRoom();
                        }
                        if (GM.LevelManager.myLevel.Equals(2) && SMng.Instance.MGComplite[2] && !SMng.sit)
                        {
                            StartCoroutine(SMng.Instance._level.loading(true));
                            IntRoom();
                        }
                    }
                    else
                    {
                        IntRoom();
                    }
                }
            }
        }
    }

    void IntRoom()
    {

        GM.AudioManager.instance.doorIn();
        SMng.interection = true;
        SMng.Instance.hideWeapon.SetActive(true);
        SMng.Direction = 3;
        transform.parent.GetComponentInChildren<Animator>().SetBool("Into", true);
    }

    public void AniFinsh()
    {
        SMng.Instance.Hero.GetComponent<Hero>().AniFinsh_statusCh();
    }
}
