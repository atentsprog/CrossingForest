using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Animator animator;
    public Image itemIcon;
    public Image itemHover;
    public Sprite blankSprite;
    public Sprite blankSpriteHover;

    internal void SetPos(float pos, float addHeight, Transform listParent)
    {
        SetImage(blankSprite);
        animator.enabled = true;
        animator.Play("InventoryPos", 0, pos);
        animator.speed = 0;
        StartCoroutine(SetHeightCo(addHeight, listParent));
    }

    private IEnumerator SetHeightCo(float addHeight, Transform listParent)
    {
        yield return null; // 애니메이션 진행될 수 있도록 1frame쉬기
        animator.enabled = false;
        transform.Translate(0, addHeight, 0, Space.Self);
        transform.SetParent(listParent);
    }

    internal void SetItem(Sprite sprite)
    {
        SetImage(sprite);
    }

    private void SetImage(Sprite sprite)
    {
        itemIcon.sprite = sprite;
        itemIcon.SetNativeSize();
    }

    internal void SetHover(bool state)
    {
        if (state)
        {
            //아이콘이 커진다.
            // 배경에 호버 이미지가 보인다.
        }
        else
        {
            // 우너래 아이콘 크기로 수정.
            // 배경 호버 이미지 안보이게 한다.
        }
    }
}
