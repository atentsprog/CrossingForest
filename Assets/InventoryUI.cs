using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject posItem;
    public Sprite[] itemList;
    void Start()
    {
        // 10개를 배치하자.
        int maxWidthCount = 10;
        for (int i = 0; i < maxWidthCount; i++)
        {
            Animator animator = (Instantiate(posItem, transform)).GetComponent<Animator>();
            float pos = (float)i / maxWidthCount;
            animator.Play("InventoryPos", 0, pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
