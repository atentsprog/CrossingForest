using UnityEditor;
using UnityEngine;

public class MenuTest
{ 
    //% (Ctrl), # (shift), & (alt)

    [MenuItem("MyMenu/Do Something", false, 1)]
    static void DoSomething()
    {
        Debug.Log("Doing Something...");
    }
    [MenuItem("MyMenu/Log Selected Transform Name", false, 3)]
    static void LogSelectedTransformName()
    {
        Debug.Log("Selected Transform is on " + Selection.activeTransform.gameObject.name + ".");
    }

    [MenuItem("MyMenu/Log Selected Transform Name", true)]
    static bool ValidateLogSelectedTransformName1111()
    {
        return Selection.activeTransform != null;
    }

    [MenuItem("MyMenu/프리오리티 2 %g", false, 2)]
    static void DoSomethingWithAShortcutKey()
    {
        Debug.Log("Doing something with a Shortcut Key...");
    }


    [MenuItem("MyMenu/g _g", false, 100)]
    static void DoSomethingWithAShortcutKey1()
    {
        Debug.Log("Doing something with a Shortcut Key...");
    }

    [MenuItem("MyMenu/k k")]
    static void DoSomethingWithAShortcutKey2()
    {
        Debug.Log("Doing something with a Shortcut Key...");
    }

    [MenuItem("CONTEXT/Rigidbody/Double Mass")]
    static void DoubleMass(MenuCommand command)
    {
        Rigidbody body = (Rigidbody)command.context;
        body.mass = body.mass * 2;
        Debug.Log("Doubled Rigidbody's Mass to " + body.mass + " from Context Menu.");
    }

    [MenuItem("GameObject/MyCategory/Custom Game Object", false, 10)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = new GameObject("Custom Game Object");
        //// Ensure it gets reparented if this was a context click (otherwise does nothing)
        //GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        //Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}