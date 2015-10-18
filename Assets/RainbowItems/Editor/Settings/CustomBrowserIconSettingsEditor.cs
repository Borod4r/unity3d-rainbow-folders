using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Borodar.RainbowItems.Editor
{
    [CustomEditor(typeof (CustomBrowserIconSettings))]
    public class CustomBrowserIconSettingsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Please set your icons for folder names here", MessageType.Info);
            DrawDefaultInspector();
        }
    }
}