using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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
    Image semo;
    //go -> GameObject
    //tr -> Transform

    public Text text;
    CanvasGroup canvasGroup;

    private void Awake()
    {
        instance = this;
        canvasGroup = GetComponent<CanvasGroup>();
        semo = transform.Find("BG/Semo").GetComponent<Image>();
        gameObject.SetActive(false);
    }

    //void Start()
    //{
    //}
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
    public float typingDelay = 0.3f;

    TweenerCore<string, string, StringOptions> typingHandle;
    internal void Show(string talkSring)
    {
        gameObject.SetActive(true);
        semo.gameObject.SetActive(false);
        //text.text = talkSring;
        text.text = "";

        if (typingHandle != null)
            typingHandle.Kill();

        typingHandle = text.DOText(talkSring, talkSring.VisibleTextLength() * charDuration)
            .SetDelay(typingDelay)
            .OnComplete(() => { semo.gameObject.SetActive(true); });
        //.OnComplete(ShowSemo);

        bgTr.localScale = Vector3.one * 0.1f;
        bgTr.DOScale(new Vector3(1, 1, 1), duration);// Vector3.one
        //void ShowSemo()
        //{
        //    semo.gameObject.SetActive(true);
        //}
    }

    internal void Close()
    {
        gameObject.SetActive(false);
    }
}
