using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public static UserDataManager instance;
    public List<Sprite> myItems;

    private void Awake()
    {
        instance = this;
    }
}
