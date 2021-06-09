﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Animator animator;
    public Image image;
    public Sprite blankSprite;
    public Sprite blankSpriteSelected;

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
        image.sprite = sprite;
        image.SetNativeSize();
    }
}
