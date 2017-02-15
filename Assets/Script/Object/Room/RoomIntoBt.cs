using UnityEngine;
using System.Collections;

public class RoomIntoBt : MonoBehaviour
{

    public Sprite OutSpr;
    public Sprite IntoSpr;

    public bool finishRoom = false;

    void Start()
    {

    }

    void Update()
    {
        // 문들어가는거 클릭
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("GoDoor") && transform.parent.GetComponentInChildren<Animator>().GetBool("Into").Equals(false) && !SMng.interection)
                {
                    GM.AudioManager.instance.doorIn();
                    SMng.interection = true;
                    SMng.Instance.hideWeapon.SetActive(true);
                    SMng.Direction = 3;
                    transform.parent.GetComponentInChildren<Animator>().SetBool("Into", true);

                    if (finishRoom)
                    {
                        if(GM.LevelManager.myLevel.Equals(0)&&SMng.Instance._inventory.ishaveWeapon())              // 1스테이지 무기유무
                            StartCoroutine(SMng.Instance._level.loading(true));
                        if(GM.LevelManager.myLevel.Equals(1)&&SMng.Instance.MGComplite[0])
                            StartCoroutine(SMng.Instance._level.loading(true));
                    }
                }
            }
        }
    }

    public void AniFinsh()
    {
        SMng.Instance.Hero.GetComponent<Hero>().AniFinsh_statusCh();
    }
}
