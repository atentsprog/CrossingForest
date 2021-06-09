using System;
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
    IEnumerator Start()
    {
        // 기존의 아이템을 삭제하자.
        posItems.ForEach(x => Destroy(x.gameObject));

        blankIcon.gameObject.SetActive(true);
        var list = transform.Find("List");
        for (int lineIndex = 0; lineIndex < lineCount; lineIndex++)
        {
            for (int x = 0; x < rowCount; x++)
            {
                GameObject newGo = Instantiate(blankIcon.gameObject);
                newGo.transform.SetParent(list); //RectTransform 에 있는 GO를 부모 지정할때는 항상 SetParent사용해야 한다.
                InventoryItem inventoryItem = newGo.GetComponent<InventoryItem>();
                newGo.name = blankIcon.gameObject.name + $"{lineIndex + 1}_{x + 1}";
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

        // 손을 표시하자.
        // <- 아직 posItems[0]의 위치가 이동하기 전에 호출 해서 의도한 위치로 가지 않아다.
        // posItems[0]에서 SetItem 함수 실행후 1frame지나야지 정상위치로 이동한다.
        // 1Frame쉬고 위치 이동시키자.
        yield return null;
        MoveHandIndex(0);
    }
    private void MoveHandIndex(int index)
    {
        hand.position = posItems[index].transform.position;
    }

    public Transform hand;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) HandMove(0, -1);
        if (Input.GetKeyDown(KeyCode.DownArrow)) HandMove(0, 1);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) HandMove(-1, 0);
        if (Input.GetKeyDown(KeyCode.RightArrow)) HandMove(1, 0);
    }
    int currentHandPosIndex = 0;
    private void HandMove(int moveX, int moveY)
    {
        //if(IsValidMove(moveY) == false)
        //{
        //    moveY = 0;
        //}

        // 작성중
        //bool IsValidMove(int moveY) 
        //{
        //    int currentLine = currentHandPosIndex / rowCount; // 0~ 10 : 0
        //    //moveY 가 음수일때 -> 현재 라인이 0보다 커야한다.
        //    if (moveY < 0)
        //    {

        //        return false;
        //    }

        //    //moveY 가 양수일때 -> 현재 라인이 최대라인 -1보다 작아야한다.

        //    return true;
        //}

        currentHandPosIndex += moveX;
        currentHandPosIndex += (moveY * rowCount);



        currentHandPosIndex = Math.Max(0, currentHandPosIndex); //0크거나 같아야 하고, 
        //if (currentHandPosIndex < 0)
        //    currentHandPosIndex = 0;

        // 최대갯수 보단 작아야 한다.
        currentHandPosIndex = Math.Min(rowCount * lineCount - 1, currentHandPosIndex);

        // 손을 움직이자.
        MoveHandIndex(currentHandPosIndex);
    }
}
