using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IClick
{
    void OnClickMessage();
}
public class GameManager : MonoBehaviour
{
    public LayerMask layer;

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

            if (Physics.Raycast(ray, out hitData, 1000, layer))
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
            DialogUI.instance.Show(@"너구리야 밥은 먹었니?");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DialogUI.instance.Close();
        }
    }
    //public float rayLength = 1000f;
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(ray.origin, ray.direction * rayLength);
    //}
}