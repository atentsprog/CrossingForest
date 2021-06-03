using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyEditorMenu : ScriptableWizard
{
    private void OnWizardCreate()
    {
        
    }
    public Type type;
    public enum Type
    {
        선택한것만,
        디렉토리에_있는것을_대상으로
    }
    protected override bool DrawWizardGUI()
    {
        base.DrawWizardGUI();

        if (GUILayout.Button("쉐이더 교체"))
        {
            ChangeSelctedShader();
        }

        return true;
    }

    private void ChangeSelctedShader()
    {
        // 내가 선택한 오브젝트의 쉐이더를 내가 지정한 쉐이더로 교체하자.
        //Selection.objects // 내가 선택한 모든 오브젝트 들어가 있다.
        foreach (var item in Selection.objects)
        {
            GameObject go = (GameObject)item;
            // 렌더러접근, -> 메테리얼 접근 -> 쉐이더 교체
            var renderer = go.GetComponent<Renderer>();

            if(renderer)
                renderer.sharedMaterial.shader = toShader;
        }
    }

    public Shader toShader;

    [MenuItem("Assets/MyMenu", false, 1)]
    static void MyMenu()
    {
        Debug.Log("나의 메뉴 실행됨, UI를 열자");
        DisplayWizard<MyEditorMenu>("나의 메뉴", "닫기");
    }
}
