using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform listParent;
    public InventoryItem posItem;
    public int maxWidthCount = 10;
    public int inventoryCount = 30;
    public float lineHeight = 100f;

    public List<InventoryItem> posItems = new List<InventoryItem>();
    public float startPosY = -60;

    void Start()
    {
        InitInventoryPos();

        //내가 가진 아이템을 배치 해보자.
        for (int i = 0; i < UserDataManager.instance.myItems.Count; i++)
        {
            var myItem = UserDataManager.instance.myItems[i];
            posItems[i].SetItem(myItem);
        }
    }

    [ContextMenu("배치")]
    void InitInventoryPos()
    {
        posItems.ForEach(x => Destroy(x.gameObject));

        posItem.gameObject.SetActive(true);
        for (int index = 0; index < inventoryCount; index++) // 세로 인덱스. 
        {
            int rowIndex = index % maxWidthCount;
            int lineIndex = (int)((float)index / maxWidthCount);
            float addHeight = lineIndex * lineHeight + startPosY;
            InventoryItem item = (Instantiate(posItem, transform));
            Animator animator = item.GetComponent<Animator>();
            posItems.Add(item);
            float pos = (float)rowIndex / (maxWidthCount - 1);
            item.SetPos(pos, addHeight, listParent);
        }
        posItem.gameObject.SetActive(false);
    }

    // 손가락 표시.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) MoveHand(0, -1);
        if (Input.GetKeyDown(KeyCode.DownArrow)) MoveHand(0, 1);
        if (Input.GetKeyDown(KeyCode.RightArrow)) MoveHand(1, 0);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) MoveHand(-1, 0);
    }

    public Transform handIcon;
    int handPosIndex;
    private void MoveHand(int moveX, int moveY)
    {
        handPosIndex += moveX;

        // 갈 수 있는 포지션인지 확인.
        handPosIndex += (moveY * maxWidthCount);

        handPosIndex = Math.Min(handPosIndex, inventoryCount - 1); // 최대값.
        handPosIndex = Math.Max(handPosIndex, 0);                   // 최소값

        //손 가락 위치 시키자. -> handPosIndex에 해당하는 위치
        handIcon.position = posItems[handPosIndex].transform.position;
    }
}
