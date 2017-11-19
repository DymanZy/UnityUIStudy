using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorWindowTest : EditorWindow
{

    [MenuItem("MyMenu/OpenWindow")]
    static void OpenWindow()
    {
        //  创建窗口
        Rect wr = new Rect(0, 0, 500, 500);
        EditorWindowTest window = (EditorWindowTest)EditorWindow.GetWindowWithRect(typeof(EditorWindowTest),wr, true, "测试创建窗口");
        window.Show();
    }


    private string text;
    private Texture texture;

    public void Awake()
    {
        texture = Resources.Load("SF Background") as Texture;
    }


    private void OnGUI()
    {
        text = EditorGUILayout.TextField("输入名字", text);

        if (GUILayout.Button("打开通知", GUILayout.Width(200))) 
        {
            this.ShowNotification(new GUIContent("This is a Notification"));
        }

        if (GUILayout.Button("关闭通知", GUILayout.Width(200)))
        {
            this.RemoveNotification();
        }

        EditorGUILayout.LabelField("鼠标在窗口的位置", Event.current.mousePosition.ToString());

        if (GUILayout.Button("关闭窗口", GUILayout.Width(200)))
        {
            this.Close();
        }

    }

    private void Update()
    {
        
    }

    private void OnFocus()
    {
        Debug.Log("当窗口获得焦点时调用一次");
    }

    private void OnLostFocus()
    {
        Debug.Log("当窗口丢失焦点是调用一次");
    }

    private void OnHierarchyChange()
    {
        Debug.Log("当 Hierarchy 视图中的任何对象发生改变是调用一次");
    }

    private void OnProjectChange()
    {
        Debug.Log("当 Project 视图中的资源发生改变是调用一次");
    }

    private void OnInspectorUpdate()
    {
        //  窗口面板更新
        //  这里开启窗口重绘，不然窗口信息不会刷新
        this.Repaint();
    }

    private void OnSelectionChange()
    {
        //  当窗口处于开启状态，并且在Hierarchys视图中选择某游戏对象时调用
        foreach(Transform t in Selection.transforms)
        {
            Debug.Log("OnSelectionChange  " + t.name);
        }
    }


    private void OnDestroy()
    {
        Debug.Log("当窗口关闭时调用");
    }

}