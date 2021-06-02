using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IClick
{
    public void OnClickMessage()
    {
        print(transform.GetPath() + " OnClickMessage 실행");
        // 플레이어가 나에게 들어와 있는 상태인가?
        // 2가지 방식으로 확인가능.
        if(isInPlayer)
        {
            Animator[] animators = GetComponentsInChildren<Animator>();
            for (int i = 0; i < animators.Length; i++)
            {
                animators[i].Play("DropFruit", 0, 0);
            }

            //레가시 애니메이션을 사용한 예제
            //Animation[] animations = GetComponentsInChildren<Animation>();
            //for (int i = 0; i < animations.Length; i++)
            //{
            //    animations[i].Play("DropFruit");
            //}
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

}
