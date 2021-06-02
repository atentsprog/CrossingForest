using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//NameToLayer T 레이어마스크(LayerMask)가 아니다!, 레이어의 인덱스(0~31)를 반환한다. 
//layer에 인스펙터에서 "Player"만 지정한것과 아래 결과는 같다.
//layer = 1 << LayerMask.NameoLayer("Ground");
//= 1 << 6; // 64
// 0b000000001; // 2 ^ 0
// 0b000000010; // 2 ^ 1
// 0b000000100; // 2 ^ 2
// 0b000001000; // 2 ^ 3
// 0b000010000; // 2 ^ 4
// 0b000100000; // 2 ^ 5
// 0b001000000; // 2 ^ 6 == 64


////특정 Layer만 raycast하기
//int layerMask = 1 << LayerMask.NameToLayer("Ground");  // Player 레이어만 충돌 체크함
//Physics.Raycast(ray, out hitData, 1000, layerMask)


////두개 이상 raycast하기
//// 0b001100000; // 2^6 + 2^5 == 64 + 32 = 96
//int layerMask = (1 << LayerMask.NameToLayer("Ground")) + (1 << LayerMask.NameToLayer("UI"));
//Physics.Raycast(ray, out hitData, 1000, layerMask)


////특정 layer만 raycast제외방법 1
//int layerMask = (-1) - (1 << LayerMask.NameToLayer("Ground"));  // Everything에서 Player 레이어만 제외하고 충돌 체크함
////  0b111111111;
////- 0b001000000;
////- 0b110111111    
//Physics.Raycast(ray, out hitData, 1000, layerMask)


////특정 layer만 raycast제외방법 2
//int layerMask = (1 << LayerMask.NameToLayer("Ground"));  // Everything에서 Player 레이어만 제외하고 충돌 체크함 , 0b001000000; // 2 ^ 6
//layerMask = ~layerMask; //0b110111111
//Physics.Raycast(ray, out hitData, 1000, layerMask)

////특정 2개이상 layer raycast 제외하기
//int layerMask = ((1 << LayerMask.NameToLayer("Ground")) | (1 << LayerMask.NameToLayer("UI")));
//layerMask = ~layerMask;
//Physics.Raycast(ray, out hitData, 1000, layerMask)
public class RecordMouseEvent : MonoBehaviour
{
    private void OnMouseEnter()
    {
        print(transform.GetPath() + " OnMouseEnter 마우스 위에있음");
    }
    private void OnMouseOver()
    {
        print(transform.GetPath() + " OnMouseOver 마우스 위에 있음");
    }
    private void OnMouseDown()
    {
        print(transform.GetPath() + " OnMouseDown 마우스 다운");
    }
    private void OnMouseUp()
    {
        print(transform.GetPath() + " OnMouseUp 마우스 업");
    }

    private void OnMouseExit()
    {
        print(transform.GetPath() + " OnMouseExit 마우스 벗어남");
    }

    public LayerMask checkLayerMask;
    public int layerTest1;
    public int layerTest2;
    public int layerTest3;
    private void OnMouseDrag()
    {
        print(transform.GetPath() + " OnMouseDrag 마우스 드래그중");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        layerTest1 = checkLayerMask;
        layerTest2 = LayerMask.NameToLayer("Ground");
        layerTest3 = 1 << layerTest2;

        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 1000, checkLayerMask))
        {
            transform.position = hitData.point;
        }
    }
}
