using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventoryItem blankIcon;
    //비어있는 슬롯 위치 아이콘을 10개씩 4줄로 배치하자.
    // Start is called before the first frame update
    public float xSize = 10;
    public float ySize = 10;
    public int rowCount = 10; // 가로 갯수
    public int lineCount = 4;

    public List<InventoryItem> posItems = new List<InventoryItem>();

    private void Awake()
    {
        posItems.Clear();
    }
    [ContextMenu("아이콘 생성")]
    void Start()
    {
        // 기존의 아이템을 삭제하자.
        posItems.ForEach(x => Destroy(x.gameObject));

        blankIcon.gameObject.SetActive(true);
        for (int lineIndex = 0; lineIndex < lineCount; lineIndex++)
        {
            for (int x = 0; x < rowCount; x++)
            {
                GameObject newGo = Instantiate(blankIcon.gameObject);
                newGo.transform.SetParent(transform); //RectTransform 에 있는 GO를 부모 지정할때는 항상 SetParent사용해야 한다.
                InventoryItem inventoryItem = newGo.GetComponent<InventoryItem>();
                float animationPos = (float)x / (rowCount - 1);
                inventoryItem.SetPos(animationPos, lineIndex);

                posItems.Add(inventoryItem);
            }
        }
        blankIcon.gameObject.SetActive(false);


        //내가 가진 아이템을 배치 해보자.
        for (int i = 0; i < UserDataManager.instance.myItems.Count; i++)
        {
            var myItem = UserDataManager.instance.myItems[i];
            posItems[i].SetItem(myItem);
        }
    }
}
