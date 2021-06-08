using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkUI_Sample : MonoBehaviour
{
    // UI나타날때 스케일 애니메이션,
    // 알파 애니메이션
    // 위치 애니메이션하자.

    CanvasGroup canvasGroup;
    public float duration = 1f;

    public Vector2 startPosition = new Vector2( -100, 0); // 위치 애니
    public float startScale = 0.7f;
    public float startAlpha = 0;

    //인스펙터에서 확인 하는 용도
    public Vector3 originalLocalPosition;
    public Vector3 originalScale;
    public float originalAlpha;
    Text text;

    // 실행순서 Awake -> OnEnable -> Start -> Update
    void Awake()
    {
        //  컴포넌트 할당및 원래값 저장
        text = transform.Find("BG/Text").GetComponent<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalLocalPosition = transform.localPosition;
        originalAlpha = canvasGroup.alpha;
        originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        // 초기 설정값 지정
        transform.localPosition = originalLocalPosition + (Vector3)startPosition;
        canvasGroup.alpha = startAlpha;
        transform.localScale = originalScale * startScale;

        // 트윈 애니메이션 설정
        transform.DOLocalMove(originalLocalPosition, duration); // 위치,
        transform.DOScale(originalScale, duration); // 크기,
        canvasGroup.DOFade(originalAlpha, duration);

        StartCoroutine(ShowTextCo());

        // Invoke를 사용한 호출(StartCoroutine와 비슷하지만 텍스트로 함수 호출 하다보니 함수이름 바꿀때 종종 실수한다. 난독화 과정에서 추가작업 필요하다 -> 비추천
        //text.text = "";
        //Invoke("ShowTextInvoke", 0.1f); 


        //스크립트로 구현 -> 불필요한 코딩은 최대한 줄이자. 코디이 길어질수록 버그 발생 확률은 증가한다.
        //StartCoroutine(MyShowTextCo(@"좋아- <color=#ff0000>용남이</color>!
        //지금부터 나랑
        //섬 100바퀴 달리기 시작이다-!"));
    }

    public float beginInterval = 0.3f;
    private IEnumerator ShowTextCo()
    {
        text.text = "";
        textHandle?.Kill();
        yield return new WaitForSeconds(beginInterval);
        string showText = @"좋아- <color=#ff0000>용남이</color>!
지금부터 나랑
섬 100바퀴 달리기 시작이다-!";

        textHandle = text.DOText(showText, showText.VisibleTextLength() * textInterval);
    }
    TweenerCore<string, string, StringOptions> textHandle;
    //    private void ShowTextInvoke()
    //    {
    //        string showText = @"좋아- <color=#ff0000>용남이</color>!
    //지금부터 나랑
    //섬 100바퀴 달리기 시작이다-!";
    //        text.DOText(showText, showText.VisibleTextLength() * textInterval);

    //    }

    public float textInterval = 0.1f;
    //private IEnumerator MyShowTextCo(string fullText)
    //{
    //    string showText = "";
    //    for (int i = 0; i < fullText.Length; i++)
    //    {
    //        showText += fullText[i];
    //        text.text = showText;
    //        yield return new WaitForSeconds(textInterval);
    //    }
    //}
}
