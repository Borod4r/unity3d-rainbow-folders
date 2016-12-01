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

using System.ComponentModel.Design;
using System.IO;
using Borodar.RainbowFolders.Editor.Settings;
using UnityEditor;
using UnityEngine;
using KeyType = Borodar.RainbowFolders.Editor.Settings.RainbowFolder.KeyType;

namespace Borodar.RainbowFolders.Editor
{
    public class RainbowFoldersPopupWindow : PopupWindowContent
    {
        private const float WINDOW_WIDTH = 325f;
        private const float WINDOW_HEIGHT = 75f;

        private const float PADDING = 8f;
        private const float SPACING = 1f;
        private const float LINE_HEIGHT = 16f;
        private const float LABELS_WIDTH = 100f;
        private const float PREVIEW_SIZE_SMALL = 16f;
        private const float PREVIEW_SIZE_LARGE = 64f;

        private static readonly Vector2 WINDOW_SIZE = new Vector2(WINDOW_WIDTH, WINDOW_HEIGHT);

        private readonly RainbowFoldersSettings _settings;
        private readonly string _path;
        private readonly RainbowFolder _existingFolder;
        private readonly RainbowFolder _currentFolder;
        
        //---------------------------------------------------------------------
        // Ctors
        //---------------------------------------------------------------------

        public RainbowFoldersPopupWindow(string path)
        {
            _settings = RainbowFoldersSettings.Instance;
            _path = path;
            _currentFolder = new RainbowFolder(KeyType.Path, _path);
            _existingFolder = _settings.GetFolderByPath(_path);

            if (_existingFolder != null) _currentFolder.CopyFrom(_existingFolder);
        }

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        public override Vector2 GetWindowSize()
        {
            return WINDOW_SIZE;
        }

        public override void OnGUI(Rect rect)
        {            
            var originalPosition = rect;  

            // Labels

            rect.y += PADDING;
            rect.width = LABELS_WIDTH - PADDING;
            rect.height = LINE_HEIGHT;

            _currentFolder.Type = (KeyType) EditorGUI.EnumPopup(rect, _currentFolder.Type);

            rect.y += LINE_HEIGHT + SPACING;
            EditorGUI.LabelField(rect, "Small Icon");
            rect.y += LINE_HEIGHT + SPACING;
            EditorGUI.LabelField(rect, "Large Icon");

            // Values

            rect.x += LABELS_WIDTH;
            rect.y = originalPosition.y + PADDING;
            rect.width = originalPosition.width - LABELS_WIDTH - PREVIEW_SIZE_LARGE - PADDING;

            GUI.enabled = false;
            _currentFolder.Key = (_currentFolder.Type == KeyType.Path) ? _path : Path.GetFileNameWithoutExtension(_path);
            EditorGUI.TextField(rect, GUIContent.none, _currentFolder.Key);
            GUI.enabled = true;

            rect.y += LINE_HEIGHT + SPACING;
            _currentFolder.SmallIcon = (Texture2D) EditorGUI.ObjectField(rect, _currentFolder.SmallIcon, typeof(Texture2D), false);
            rect.y += LINE_HEIGHT + SPACING;
            _currentFolder.LargeIcon = (Texture2D) EditorGUI.ObjectField(rect, _currentFolder.LargeIcon, typeof(Texture2D), false);

            // Preview

            rect.x += rect.width + PADDING;
            rect.y = originalPosition.y;
            rect.width = rect.height = PREVIEW_SIZE_LARGE;
            GUI.DrawTexture(rect, _currentFolder.LargeIcon ?? RainbowFoldersEditorUtility.GetDefaultFolderIcon());

            rect.y += PREVIEW_SIZE_LARGE - PREVIEW_SIZE_SMALL - 4f;
            rect.width = rect.height = PREVIEW_SIZE_SMALL;
            GUI.DrawTexture(rect, _currentFolder.SmallIcon ?? RainbowFoldersEditorUtility.GetDefaultFolderIcon());
        }

        public override void OnClose()
        {
            _settings.UpdateFolder(_existingFolder, _currentFolder);
        }
    }
}