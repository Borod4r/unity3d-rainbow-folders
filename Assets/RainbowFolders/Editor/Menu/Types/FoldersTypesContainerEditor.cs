﻿using Borodar.ReorderableList;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Editor
{
    [CustomEditor(typeof(FolderTypesStorage))]
    public class FoldersTypesContainerEditor : UnityEditor.Editor
    {
        private const string PROP_NAME_FOLDERS = "TypeFolderIcons";

        private SerializedProperty _foldersProperty;

        protected void OnEnable()
        {
            _foldersProperty = serializedObject.FindProperty(PROP_NAME_FOLDERS);
        }

        public override void OnInspectorGUI()
        {
            GUI.enabled = false;
            EditorGUILayout.HelpBox("This is internal file for RainbowFolders. Do not edit.", MessageType.Warning);

            serializedObject.Update();
            ReorderableListGUI.Title("Internal storage of colorful folder icons");
            ReorderableListGUI.ListField(_foldersProperty);
            serializedObject.ApplyModifiedProperties();
        }
    }
}