using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCube : MonoBehaviour, IClick
{
    public void OnClickMessage()
    {
        var rotate = GetComponent<GORotate>();
        rotate.enabled = !rotate.enabled;
    }
}
