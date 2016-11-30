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

using System.IO;
using Borodar.RainbowFolders.Editor.Settings;
using UnityEditor;
using UnityEngine;
using KeyType = Borodar.RainbowFolders.Editor.Settings.RainbowFolder.KeyType;

namespace Borodar.RainbowFolders.Editor
{
    public class RainbowFoldersPopupWindow : PopupWindowContent
    {
        private const float PADDING = 8f;
        private const float SPACING = 1f;
        private const float LINE_HEIGHT = 16f;
        private const float LABELS_WIDTH = 100f;
        private const float PREVIEW_SIZE_SMALL = 16f;
        private const float PREVIEW_SIZE_LARGE = 64f;

        private readonly string _path;
        private readonly RainbowFolder _folder;

        //---------------------------------------------------------------------
        // Ctors
        //---------------------------------------------------------------------

        public RainbowFoldersPopupWindow(string path)
        {
            _path = path;
            _folder = RainbowFoldersSettings.Instance.GetFolder(_path);

            if (_folder != null) return;
            _folder = new RainbowFolder(KeyType.Path, _path);
            RainbowFoldersSettings.Instance.AddFolder(_folder);
        }

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        public override void OnGUI(Rect rect)
        {
            var originalPosition = rect;  

            // Labels

            rect.y += PADDING;
            rect.width = LABELS_WIDTH - PADDING;
            rect.height = LINE_HEIGHT;

            _folder.Type = (KeyType) EditorGUI.EnumPopup(rect, _folder.Type);

            rect.y += LINE_HEIGHT + SPACING;
            EditorGUI.LabelField(rect, "Small Icon");
            rect.y += LINE_HEIGHT + SPACING;
            EditorGUI.LabelField(rect, "Large Icon");

            // Values

            rect.x += LABELS_WIDTH;
            rect.y = originalPosition.y + PADDING;
            rect.width = originalPosition.width - LABELS_WIDTH - PREVIEW_SIZE_LARGE - PADDING;

            GUI.enabled = false;
            _folder.Key = (_folder.Type == KeyType.Path) ? _path : Path.GetFileNameWithoutExtension(_path);
            EditorGUI.TextField(rect, GUIContent.none, _folder.Key);
            GUI.enabled = true;

            rect.y += LINE_HEIGHT + SPACING;
            _folder.SmallIcon = (Texture2D) EditorGUI.ObjectField(rect, _folder.SmallIcon, typeof(Texture2D), false);
            rect.y += LINE_HEIGHT + SPACING;
            _folder.LargeIcon = (Texture2D) EditorGUI.ObjectField(rect, _folder.LargeIcon, typeof(Texture2D), false);

            // Preview

            rect.x += rect.width + PADDING;
            rect.y = originalPosition.y;
            rect.width = rect.height = PREVIEW_SIZE_LARGE;
            GUI.DrawTexture(rect, _folder.LargeIcon ?? RainbowFoldersEditorUtility.GetDefaultFolderIcon());

            rect.y += PREVIEW_SIZE_LARGE - PREVIEW_SIZE_SMALL - 4f;
            rect.width = rect.height = PREVIEW_SIZE_SMALL;
            GUI.DrawTexture(rect, _folder.SmallIcon ?? RainbowFoldersEditorUtility.GetDefaultFolderIcon());
        }

        public override void OnClose()
        {
            if (!_folder.HasAtLeastOneIcon())
                RainbowFoldersSettings.Instance.RemoveAll(_folder);
        }

        public override Vector2 GetWindowSize()
        {
            return new Vector2(325f, 75f);
        }
    }
}