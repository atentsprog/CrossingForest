using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    internal static DialogUI instance;
    // 투명 - 나타날땐 안하고 사라질때 있음. 
    // 위치이동. - 없음.
    // 스케일 했음
    // 이름표 먼저 나타남, 대화창 뒤에 스케일 애니메이션으로 나타남.

    public Transform bgTr;
    //go -> GameObject
    //tr -> Transform

    public Text text;
    CanvasGroup canvasGroup;

    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public float duration = 1;

    //void Update()
    //{
    //    //if (Input.GetKeyDown(KeyCode.Alpha1))
    //    //{   //bgTr.//  스케일이 서서히 커지게 하자.
    //    //    bgTr.localScale = Vector3.one * 0.1f;
    //    //    bgTr.DOScale(new Vector3(1, 1, 1), duration);// Vector3.one
    //    //}
    //    //if (Input.GetKeyDown(KeyCode.Alpha2))
    //    //    canvasGroup.alpha = 1;
    //    //if (Input.GetKeyDown(KeyCode.Alpha3))
    //    //{
    //    //    // 사라졌다가 시간을 두고 서서히 나타나자.
    //    //    canvasGroup.alpha = 0;
    //    //    canvasGroup.DOFade(1, duration);
    //    //}
    //    //if (Input.GetKeyDown(KeyCode.Alpha4))
    //    //{
    //    //    // 시간을 두고 서서히 사라진다
    //    //    canvasGroup.alpha = 1;
    //    //    canvasGroup.DOFade(0, duration);
    //    //}
    //}

    public float charDuration = 0.2f;
    internal void Show(string talkSring)
    {
        gameObject.SetActive(true);
        //text.text = talkSring;
        text.text = "";
        text.DOText(talkSring, talkSring.Length * charDuration);

        bgTr.localScale = Vector3.one * 0.1f;
        bgTr.DOScale(new Vector3(1, 1, 1), duration);// Vector3.one
    }
    internal void Close()
    {
        gameObject.SetActive(false);
    }
}
