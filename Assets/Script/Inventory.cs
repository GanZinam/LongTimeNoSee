using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ITEM
{
    public int code;
    public int num;
}

public class Inventory : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Button[] invenItems = new UnityEngine.UI.Button[10];
    public static ITEM[] items = new ITEM[10];

    /**
     * @brief 아이템 획득했을때
     * @param 아이템 코드명
     */
    public void getItem(int itemCode)
    {
        SMng.Instance.createState(itemCode);

        // 이미 해당 아이템을 가지고 있다면 그 수만 증가 시켜줌
        for (int j = 0; j < items.Length; j++)
        {
            if (items[j].code.Equals(itemCode))
            {
                items[j].num++;
                return;
            }
        }

        // 해당 아이템을 가지고 있지 않다면 빈공간에 새로 만들어줌        
        for (int i = 0; i < items.Length; i++)
        {
            // 빈공간 찾기
            if (items[i].num.Equals(0))
            {
                items[i].code = itemCode;
                invenItems[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(itemCode + "");
                items[i].num++;
                return;
            }
        }

        // 이 구간까지 온것은 공간이 없다는 뜻이거나 에러
        Debug.LogWarning("공간이 부족합니다.");
    }

    [SerializeField]
    Animator invenAnimator;
    bool isOpen = false;        // 인벤토리 창 열려 있는지 유무

    /**
     * @brief 인벤토리창 열고 닫기
     */
    public void openInventory()
    {
        if (!isOpen)
        {
            invenAnimator.SetTrigger("open");
            isOpen = true;
        }
        else
        {
            invenAnimator.SetTrigger("close");
            isOpen = false;
        }
    }
}