using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // 3D오브젝트 클릭 이벤트
    private void OnMouseDown()
    {
        print(transform.GetPath() + " OnMouseDown 마우스 다운");
        // 플레이어가 나에게 들어와 있는 상태인가?
        // 2가지 방식으로 확인가능.
        if(isInPlayer)
        {
            DropFruit();
        }
    }

    public bool isInPlayer = false;
    private void OnTriggerEnter(Collider other)
    {
        // 부딪히면 나뭇잎을 흔들어라.
        if(other.CompareTag("Player"))
        {
            isInPlayer = true;
            Animator[] animators = GetComponentsInChildren<Animator>();
            for (int i = 0; i < animators.Length; i++)
            {
                animators[i].Play("SwingLeaf", 0, 0);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInPlayer = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            DropFruit();
        }
    }

    private void DropFruit()
    {
        Animator[] animators = GetComponentsInChildren<Animator>();
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].Play("DropFruit", 0, 0);
        }
    }
}
