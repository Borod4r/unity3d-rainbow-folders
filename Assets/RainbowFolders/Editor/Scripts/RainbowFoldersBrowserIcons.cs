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

using System.Collections.Generic;
using System.Linq;
using Borodar.RainbowFolders.Editor.Settings;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Editor
{
    /*
    * This script allows you to set custom icons for folders in project browser.
    * Recommended icon sizes - small: 16x16 px, large: 64x64 px;
    */

    [InitializeOnLoad]
    public class RainbowFoldersBrowserIcons
    {
        private const float LARGE_ICON_SIZE = 64f;

        private static bool _multiSelection;

        //---------------------------------------------------------------------
        // Ctors
        //---------------------------------------------------------------------

        static RainbowFoldersBrowserIcons()
        {
            EditorApplication.projectWindowItemOnGUI += ReplaceFolderIcon;
            EditorApplication.projectWindowItemOnGUI += DrawEditIcon;
            EditorApplication.projectWindowItemOnGUI += ShowWelcomeWindow;
        }

        //---------------------------------------------------------------------
        // Delegates
        //---------------------------------------------------------------------

        private static void ReplaceFolderIcon(string guid, Rect rect)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            if (!AssetDatabase.IsValidFolder(path)) return;

            var isSmall = IsIconSmall(ref rect);

            var setting = RainbowFoldersSettings.Instance;
            if (setting == null) return;
            var texture = RainbowFoldersSettings.Instance.GetFolderIcon(path, isSmall);
            if (texture == null) return;

            DrawCustomIcon(ref rect, texture, isSmall);
        }

        private static void DrawEditIcon(string guid, Rect rect)
        {
            if (!Event.current.alt)
            {
                _multiSelection = false;
                return;
            }

            var isSmall = IsIconSmall(ref rect);
            var isMouseOver = rect.Contains(Event.current.mousePosition);
            _multiSelection = (IsSelected(guid)) ? isMouseOver || _multiSelection : !isMouseOver && _multiSelection;

            // if mouse is not over current folder icon or selected group
            if (!isMouseOver && (!IsSelected(guid) || !_multiSelection)) return;

            var path = AssetDatabase.GUIDToAssetPath(guid);
            if (!AssetDatabase.IsValidFolder(path)) return;

            var editIcon = RainbowFoldersEditorUtility.GetEditFolderIcon(isSmall);
            DrawCustomIcon(ref rect, editIcon, isSmall);

            if (GUI.Button(rect, GUIContent.none, GUIStyle.none))
            {
                var window = RainbowFoldersPopup.GetDraggableWindow();
                var position = GUIUtility.GUIToScreenPoint(rect.position + new Vector2(0, rect.height + 2));

                if (_multiSelection)
                {
                    var paths = Selection.assetGUIDs.Select<string, string>(AssetDatabase.GUIDToAssetPath).Where(AssetDatabase.IsValidFolder).ToList();
                    var index = paths.IndexOf(path);

                    window.ShowWithParams(position, paths, index);
                }
                else
                {
                    window.ShowWithParams(position, new List<string> {path}, 0);
                }
            }

            EditorApplication.RepaintProjectWindow();
        }

        private static void ShowWelcomeWindow(string guid, Rect rect)
        {
            if (EditorPrefs.GetBool(RainbowFoldersWelcome.PREF_KEY))
            {
                // ReSharper disable once DelegateSubtraction
                EditorApplication.projectWindowItemOnGUI -= ShowWelcomeWindow;
                return;
            }

            RainbowFoldersWelcome.ShowWindow();
            EditorPrefs.SetBool(RainbowFoldersWelcome.PREF_KEY, true);

        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static void DrawCustomIcon(ref Rect rect, Texture texture, bool isSmall)
        {
            if (rect.width > LARGE_ICON_SIZE)
            {
                // center the icon if it is zoomed
                var offset = (rect.width - LARGE_ICON_SIZE) / 2f;
                var position = new Rect(rect.x + offset, rect.y + offset, LARGE_ICON_SIZE, LARGE_ICON_SIZE);
                GUI.DrawTexture(position, texture);
            }
            else
            {
                #if UNITY_5_5_OR_NEWER
                    // unity shifted small icons a bit in 5.5
                    if (isSmall) rect = new Rect(rect.x + 3, rect.y, rect.width, rect.height);
                #endif

                GUI.DrawTexture(rect, texture);
            }
        }

        private static bool IsIconSmall(ref Rect rect)
        {
            var isSmall = rect.width > rect.height;

            if (isSmall)
                rect.width = rect.height;
            else
                rect.height = rect.width;

            return isSmall;
        }

        private static bool IsSelected(string guid)
        {
            return Selection.assetGUIDs.Contains(guid);
        }
    }
}
