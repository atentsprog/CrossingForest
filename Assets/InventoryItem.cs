using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public float offsetStartY = 430.5f;
    public float height = -92;
    public Image itemIcon;
    private void Awake()
    {
        itemIcon = GetComponent<Image>();
    }
    internal void SetPos(float pos, int lineIndex)
    {
        StartCoroutine(SetPosCo(pos, lineIndex));
    }
    private IEnumerator SetPosCo(float pos, int lineIndex)
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("InventoryPos", 0, pos);
        animator.speed = 0;

        yield return null;

        animator.enabled = false;
        //y위치값 수정하자.
        transform.Translate(0, offsetStartY + lineIndex * height, 0, Space.Self);
    }

    internal void SetItem(Sprite sprite)
    {
        itemIcon.sprite = sprite;
        itemIcon.SetNativeSize();
    }
}
