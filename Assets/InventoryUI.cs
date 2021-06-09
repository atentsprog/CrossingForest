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
}
