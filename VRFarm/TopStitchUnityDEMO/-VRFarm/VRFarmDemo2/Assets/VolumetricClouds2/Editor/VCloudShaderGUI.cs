using UnityEngine;
using UnityEditor;

public class VCloudShaderGUI : MaterialEditor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Help"))
            Application.OpenURL("https://docs.google.com/document/d/1vUXzQ5Ww9NR7m7F5n7adUWXJnWUH0u47JHmcifKK48w/edit?usp=sharing");

        base.OnInspectorGUI();
        UpdateRenderQueue();
    }



    void UpdateRenderQueue()
    {
        serializedObject.Update();

        var shader = serializedObject.FindProperty("m_Shader");
        if (!isVisible || shader.objectReferenceValue == null)
            return;
        if (shader.hasMultipleDifferentValues)
            return;
        if (shader.objectReferenceValue == null)
            return;
        if (!(target is Material))
            return;

        Material m = (Material)target;
        m.renderQueue = m.GetInt("_RenderQueue");
    }
}

