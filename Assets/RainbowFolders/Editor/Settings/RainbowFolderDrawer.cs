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

using UnityEngine;
using UnityEditor;

namespace Borodar.RainbowFolders.Editor.Settings
{
    [CustomPropertyDrawer(typeof(RainbowFolder))]
    public class RainbowFolderDrawer : PropertyDrawer
    {
        private const float PADDING = 4f;
        private const float LINE_HEIGHT = 16f;
        private const float PREVIEW_SIZE_SMALL = 16f;
        private const float PREVIEW_SIZE_LARGE = 64f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var originalPosition = position;

            var folderName = property.FindPropertyRelative("Name");
            var smallIcon = property.FindPropertyRelative("SmallIcon");
            var largeIcon = property.FindPropertyRelative("LargeIcon");

            position.y += PADDING;
            position.width -= PREVIEW_SIZE_LARGE + PADDING;
            position.height = LINE_HEIGHT;
            EditorGUI.PropertyField(position, folderName);

            position.y += LINE_HEIGHT;
            EditorGUI.PropertyField(position, smallIcon);
            
            position.y += LINE_HEIGHT;
            EditorGUI.PropertyField(position, largeIcon);

            position.x = originalPosition.width - PREVIEW_SIZE_LARGE + 16f;
            position.y = originalPosition.y;
            position.width = position.height = PREVIEW_SIZE_LARGE;
            GUI.DrawTexture(position, (Texture2D) largeIcon.objectReferenceValue ?? GetDefaultFolderIcon());

            position.y += PREVIEW_SIZE_LARGE - PREVIEW_SIZE_SMALL - PADDING;
            position.width = position.height = PREVIEW_SIZE_SMALL;
            GUI.DrawTexture(position, (Texture2D) smallIcon.objectReferenceValue ?? GetDefaultFolderIcon());
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return PREVIEW_SIZE_LARGE;
        }

        private static Texture2D GetDefaultFolderIcon()
        {
            return EditorGUIUtility.FindTexture("Folder Icon");
        }
    }
}