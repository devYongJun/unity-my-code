using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class YJEdtiorDefine
{
    public const int defineData = 10;
}

#if UNITY_EDITOR
public class YJEditor : EditorWindow
{
    [MenuItem("YJ/YJEditor")]
    static void ShowEditorWindow()
    {
        EditorWindow.GetWindow(typeof(YJEditor)).Show();
    }

    Vector2 scrollPosition;
    int windowSizeX;
    int windowSizeY;

    void OnGUI()
    {
        scrollPosition = GUI.BeginScrollView(new Rect(0, 0, position.width, position.height), scrollPosition, new Rect(0, 0, windowSizeX, windowSizeY));
        BeginWindows();
        Handles.BeginGUI();
        GUILayout.Box("YJ의 샘플 에디터", GUILayout.MaxWidth(405));
        GUILayout.BeginHorizontal();
        windowSizeX = EditorGUILayout.IntField("Window width", windowSizeX, GUILayout.MaxWidth(200));
        windowSizeY = EditorGUILayout.IntField("Window height", windowSizeY, GUILayout.MaxWidth(200));
        GUILayout.EndHorizontal();
        OnMain();
        Handles.EndGUI();
        EndWindows();
        GUI.EndScrollView();
    }

    Rect windowRect = new Rect(30, 30, 300, 100);
    void OnMain()
    {
        windowRect = GUILayout.Window(0, windowRect, OnWindow, "Window name");

        Handles.DrawBezier(windowRect.position, Vector3.zero, new Vector3(windowRect.position.x, 0f, 0f), new Vector3(0f, windowRect.position.y, 0f), Color.red, null, 3f);

    }

    void OnWindow(int wID)
    {
        GUILayout.Box("wID :" + wID, GUILayout.Width(500));
        GUI.DragWindow();
    }

}
#endif