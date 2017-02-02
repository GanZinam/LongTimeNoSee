using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static int[] items = new int[4];

    /**
     * @brief 아이템 획득했을때
     * @param 아이템 코드명
     */
    public static void getItem(int itemCode)
    {
        int i = 0;
        for (; i < items.Length; i++)
        {
            if (items[i].Equals(0))
            {
                items[i] = itemCode;
                SMng.Instance.createState();
                break;
            }
        }

        if (i > items.Length)
            Debug.Log("공간이 부족합니다.");
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
