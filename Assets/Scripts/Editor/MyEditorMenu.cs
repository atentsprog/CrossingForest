using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        if (GUILayout.Button("설정 복사"))
        {
            CopyShaderConfig();
        }

        if (GUILayout.Button("설정 붙여넣기"))
        {
            PasteShaderConfig();
        }

        return true;
    }

    private void CopyShaderConfig()
    {
        // 내가 지금 선택한 오브젝트에 있는 메테리얼에 접근,
        // 메테리얼의 설정을 모두 복사하자
        Debug.Assert(Selection.objects.Length == 1, $"선택된 오브젝트의 개숫가 {Selection.objects.Length}개 입니다");
        Renderer renderer = Selection.activeGameObject.GetComponent<Renderer>();
        //Material toMat = renderer.material;
        Material toMat = renderer.sharedMaterial;
        Shader toShader = toMat.shader;

        int count = ShaderUtil.GetPropertyCount(toShader);
        properties = new List<ShaderPropertyInfo>(count);
        for (var i = 0; i < count; ++i)
        {
            var name = ShaderUtil.GetPropertyName(toShader, i);
            var type = ShaderUtil.GetPropertyType(toShader, i);
            properties.Add(new ShaderPropertyInfo(name, type));
        }

        foreach (var item in properties)
        {
            switch (item.type)
            {
                case ShaderUtil.ShaderPropertyType.Color:
                    item.value = toMat.GetColor(item.name);
                    break;
                case ShaderUtil.ShaderPropertyType.Vector:
                    item.value = toMat.GetVector(item.name);
                    break;
                case ShaderUtil.ShaderPropertyType.Float:
                    item.value = toMat.GetFloat(item.name);
                    break;
                case ShaderUtil.ShaderPropertyType.Range:
                    toMat.GetFloatArray(item.name, item.value);
                    break;
                    //case ShaderUtil.ShaderPropertyType.TexEnv: // 텍스쳐는 복사할 필요 없으므로 제외
                    //    item.textureValue = toMat.GetTexture(item.name);
                    //break;
            }
        }
    }
    private List<ShaderPropertyInfo> properties;
    internal class ShaderPropertyInfo
    {
        public string name; // 쉐이더에서 값 읽음
        public ShaderUtil.ShaderPropertyType type;// 쉐이더에서 값 읽음

        public dynamic value; // 메테리얼에 있는 값 읽기, 이 값을 다른 메테리얼에 붙여넣음.

        public ShaderPropertyInfo(string name, ShaderUtil.ShaderPropertyType type)
        {
            this.name = name;
            this.type = type;
        }
    }
    private void PasteShaderConfig()
    {
        List<Material> desMaterials = GetSelectedMaterials();

        foreach (var desMat in desMaterials)
        {
            foreach (var item in properties)
            {
                switch (item.type)
                {
                    case ShaderUtil.ShaderPropertyType.Color:
                        desMat.SetColor(item.name, item.value);
                        break;
                    case ShaderUtil.ShaderPropertyType.Vector:
                        desMat.SetVector(item.name, item.value);
                        break;
                    case ShaderUtil.ShaderPropertyType.Float:
                        desMat.SetFloat(item.name, item.value);
                        break;
                    case ShaderUtil.ShaderPropertyType.Range:
                        desMat.SetFloatArray(item.name, item.value); // 테스트 안해봤음.
                        break;
                        //case ShaderUtil.ShaderPropertyType.TexEnv:
                        //    desMat.SetTexture(item.name, item.textureValue);
                        //    break;
                }
            }
        }
    }

    private static List<Material> GetSelectedMaterials()
    {
        List<Material> desMaterials = new List<Material>();
        foreach (var item in Selection.objects)
        {
            if (item == null)
                continue;
            System.Type itemType = item.GetType();
            if (itemType == typeof(Material))
                desMaterials.Add((Material)item);
            else if (itemType == typeof(GameObject))
            {
                //var materials = ((GameObject)item).GetComponentsInChildren<Renderer>().Select(x => x.sharedMaterial);
                //desMaterials.AddRange(materials);

                var renderers = ((GameObject)item).GetComponentsInChildren<Renderer>();
                for (int i = 0; i < renderers.Length; i++)
                {
                    desMaterials.Add( renderers[i].sharedMaterial);
                }
            }
        }
        return desMaterials;
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