using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[System.Serializable]
public struct Pos
{
    float x;
    float y;
    float z;
}
[System.Serializable]
public struct Rota
{
    float x;
    float y;
    float z;
}
[System.Serializable]
public struct Scale
{
    float x;
    float y;
    float z;
}
public class GetObjTransform : EditorWindow
{
    private static Rect windowRect = new Rect(200, 200, 700, 300);
    string content = "选中物体信息";
    [MenuItem("Tools/GetObjTransform")]
    static void Init()
    {
        GetObjTransform window = (GetObjTransform)EditorWindow.GetWindow(typeof(GetObjTransform));
        window.position = windowRect;  //设置窗口坐标和宽高
        window.Show();
    }
    void OnGUI()
    {
        createWindow();
    }
    void createWindow()
    {
        GUILayout.TextArea(content, GUILayout.Width(700), GUILayout.Height(250));
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Get", GUILayout.Width(50), GUILayout.Height(30)))
        {
            content = "";
            Object[] targetObjs = Selection.GetFiltered(typeof(GameObject), SelectionMode.TopLevel);
            foreach (GameObject item in targetObjs)
            {
                setContent(item, "f,", ref content);
            }
        }
        if (GUILayout.Button("Clear", GUILayout.Width(50), GUILayout.Height(30)))
        {
            content = "";
        }
        EditorGUILayout.EndHorizontal();
    }
    void OnInspectorUpdate()
    {
        Repaint(); //重新绘制
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="item">物体</param>
    /// <param name="intervalStr">间隔字符</param>
    /// <param name="content">要改变的str</param>
    void setContent(GameObject item, string intervalStr, ref string content)
    {
        content += item.name + "       Pos: " + item.transform.localPosition.x.ToString("F3") + intervalStr + item.transform.localPosition.y.ToString("F3") + intervalStr + item.transform.localPosition.z.ToString("F3") + intervalStr + " Rota: "
            + item.transform.localRotation.x.ToString("F3") + intervalStr + item.transform.localRotation.y.ToString("F3") + intervalStr
            + item.transform.localRotation.z.ToString("F3") + intervalStr + " Scale: "
            + item.transform.localScale.x.ToString("F3") + intervalStr + item.transform.localScale.y.ToString("F3") + intervalStr
            + item.transform.localScale.z.ToString("F3") + intervalStr + "\n";
    }
    //
    void setContent(GameObject item, ref string content)
    {
        content += item.name + "       Pos:" + item.transform.localPosition + " Rota:" + item.transform.localRotation + " Scale:" + item.transform.localScale + "\n";
    }
}
