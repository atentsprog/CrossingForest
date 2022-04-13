using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IClick
{
    void OnClickMessage();
}
public class GameManager : MonoBehaviour
{
    public LayerMask groundLayer;
    public InventoryUI inventoryUI;
    public DialogUI dialogUI;
    public Vector3 mousePosition;
    public Vector3 hitPoint;
    public bool isHit;
    public Ray ray;
    public RaycastHit hitData;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            mousePosition = Input.mousePosition;
            ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out hitData, 1000, groundLayer))
            {
                isHit = true;
                hitPoint = hitData.point;
                //transform.position = hitData.point;
                IClick iClick = hitData.transform.GetComponent<IClick>();
                if (iClick != null)
                    iClick.OnClickMessage();
                else
                {
                    //플레이어 위치 이동
                    Player.instance.agent.destination = hitData.point;
                }
            }
            else
            {
                isHit = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            dialogUI.Show(dialogString);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            dialogUI.Close();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventoryUI.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            inventoryUI.gameObject.SetActive(false);
        }

    }
    public string dialogString = "<color=#00ff00>너구리</color>야 밥은 먹었니?";
    //public float rayLength = 1000f;
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(ray.origin, ray.direction * rayLength);
    //}
}