using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


//  定制特性
[CustomEditor(typeof(EditorTest))]
[ExecuteInEditMode]
public class MyEditor : Editor {

    //  重载OnInspectorGUI方法，来绘制控件
    public override void OnInspectorGUI() {
        
        EditorTest editorTest = (EditorTest)target;
        //  绘制一个窗口
        editorTest.mRectValue = EditorGUILayout.RectField("窗口坐标", editorTest.mRectValue);
        //  绘制一个贴图槽
        editorTest.texture = EditorGUILayout.ObjectField("增加一个贴图", editorTest.texture, typeof(Texture), true) as Texture;
    }



}
