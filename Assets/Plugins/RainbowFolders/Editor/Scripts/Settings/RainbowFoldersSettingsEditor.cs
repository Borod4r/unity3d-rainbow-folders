/*
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 */

using Borodar.ReorderableList;
using UnityEditor;

namespace Borodar.RainbowFolders.Editor.Settings
{
    [CustomEditor(typeof (RainbowFoldersSettings))]
    public class RainbowFoldersSettingsEditor : UnityEditor.Editor
    {
        private const string PROP_NAME_FOLDERS = "Folders";

        private SerializedProperty _foldersProperty;

        protected void OnEnable()
        {
            _foldersProperty = serializedObject.FindProperty(PROP_NAME_FOLDERS);
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Please set your custom folder icons by specifying:\n\n" +
                                    "- Folder Name\n" +
                                    "Icon will be applied to all folders with the same name\n\n" +
                                    "- Folder Path\n" +
                                    "Icon will be applied to a single folder. The path format: Assets/SomeFolder/YourFolder", MessageType.Info);

            serializedObject.Update();
            ReorderableListGUI.Title("Rainbow Folders");
            ReorderableListGUI.ListField(_foldersProperty);
            serializedObject.ApplyModifiedProperties();
        }

    }
}