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
    public class RainbowFoldersPopupWindow : DraggablePopupWindow
    {
        private const float PADDING = 8f;
        private const float SPACING = 1f;
        private const float LINE_HEIGHT = 16f;
        private const float LABELS_WIDTH = 85f;
        private const float PREVIEW_SIZE_SMALL = 16f;
        private const float PREVIEW_SIZE_LARGE = 64f;
        private const float BUTTON_WIDTH = 55f;

        private const float WINDOW_WIDTH = 325f;
        private const float WINDOW_HEIGHT = 86f;

        private static readonly Vector2 WINDOW_SIZE = new Vector2(WINDOW_WIDTH, WINDOW_HEIGHT);
        private static readonly Rect WINDOW_RECT = new Rect(Vector2.zero, WINDOW_SIZE);

        private string _path;
        private RainbowFoldersSettings _settings;
        private RainbowFolder _existingFolder;
        private RainbowFolder _currentFolder;

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public static RainbowFoldersPopupWindow GetDraggableWindow()
        {
            return GetDraggableWindow<RainbowFoldersPopupWindow>();
        }

        public void ShowWithParam(Vector2 position, string path)
        {
            _path = path;
            _settings = RainbowFoldersSettings.Instance;
            _currentFolder = new RainbowFolder(KeyType.Path, _path);
            _existingFolder = _settings.GetFolderByPath(_path);

            if (_existingFolder != null) _currentFolder.CopyFrom(_existingFolder);

            var rect = new Rect(position, WINDOW_SIZE);
            Show<RainbowFoldersPopupWindow>(rect);
        }

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        public override void OnGUI()
        {
            base.OnGUI();

            // Labels

            var rect = WINDOW_RECT;
            rect.x += 0.5f * PADDING;
            rect.y += PADDING;
            rect.width = LABELS_WIDTH - PADDING;
            rect.height = LINE_HEIGHT;

            _currentFolder.Type = (KeyType)EditorGUI.EnumPopup(rect, _currentFolder.Type);

            rect.y += LINE_HEIGHT + SPACING;
            EditorGUI.LabelField(rect, "Small Icon");
            rect.y += LINE_HEIGHT + SPACING;
            EditorGUI.LabelField(rect, "Large Icon");

            // Values

            rect.x += LABELS_WIDTH;
            rect.y = WINDOW_RECT.y + PADDING;
            rect.width = WINDOW_RECT.width - LABELS_WIDTH - PREVIEW_SIZE_LARGE - 2f * PADDING;

            GUI.enabled = false;
            _currentFolder.Key = (_currentFolder.Type == KeyType.Path) ? _path : Path.GetFileNameWithoutExtension(_path);
            EditorGUI.TextField(rect, GUIContent.none, _currentFolder.Key);
            GUI.enabled = true;

            rect.y += LINE_HEIGHT + SPACING;
            _currentFolder.SmallIcon = (Texture2D)EditorGUI.ObjectField(rect, _currentFolder.SmallIcon, typeof(Texture2D), false);
            rect.y += LINE_HEIGHT + SPACING;
            _currentFolder.LargeIcon = (Texture2D)EditorGUI.ObjectField(rect, _currentFolder.LargeIcon, typeof(Texture2D), false);

            // Preview

            rect.x += rect.width + PADDING;
            rect.y = WINDOW_RECT.y;
            rect.width = rect.height = PREVIEW_SIZE_LARGE;
            GUI.DrawTexture(rect, _currentFolder.LargeIcon ?? RainbowFoldersEditorUtility.GetDefaultFolderIcon());

            rect.y += PREVIEW_SIZE_LARGE - PREVIEW_SIZE_SMALL - 4f;
            rect.width = rect.height = PREVIEW_SIZE_SMALL;
            GUI.DrawTexture(rect, _currentFolder.SmallIcon ?? RainbowFoldersEditorUtility.GetDefaultFolderIcon());

            // Buttons

            rect.x = PADDING;
            rect.y = WINDOW_HEIGHT - LINE_HEIGHT - 0.75f * PADDING;            
            rect.width = 20f;
            if (GUI.Button(rect, "S"))
            {
                Selection.activeObject = _settings;
                Close();
            }

            rect.x += 20f + 4f;
            if (GUI.Button(rect, "D"))
            {
                _settings.RemoveAll(_existingFolder);
                Close();
            }

            rect.x = WINDOW_WIDTH - 2f * (BUTTON_WIDTH + PADDING);
            rect.width = BUTTON_WIDTH;
            if (GUI.Button(rect, "Cancel"))
            {
                Close();
            }

            rect.x = WINDOW_WIDTH - BUTTON_WIDTH - PADDING;
            if (GUI.Button(rect, "Apply"))
            {
                _settings.UpdateFolder(_existingFolder, _currentFolder);
                Close();
            }
        }
    }
}