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

using System.Diagnostics.CodeAnalysis;
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

        private static Texture2D _editIconSmall;
        private static Texture2D _editIconLarge;

        //---------------------------------------------------------------------
        // Ctors
        //---------------------------------------------------------------------

        static RainbowFoldersBrowserIcons()
        {
            EditorApplication.projectWindowItemOnGUI += ReplaceFolderIcon;
            EditorApplication.projectWindowItemOnGUI += DrawEditIcon;
        }

        //---------------------------------------------------------------------
        // Delegates
        //---------------------------------------------------------------------

        private static void ReplaceFolderIcon(string guid, Rect rect)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            if (!AssetDatabase.IsValidFolder(path)) return;

            var isSmall = IsIconSmall(ref rect);

            var texture = RainbowFoldersSettings.Instance.GetFolderIcon(path, isSmall);
            if (texture == null) return;

            DrawCustomIcon(ref rect, texture, isSmall);
        }

        private static void DrawEditIcon(string guid, Rect rect)
        {
            if (!Event.current.alt) return;

            var isSmall = IsIconSmall(ref rect);

            var isMouseOver = rect.Contains(Event.current.mousePosition);
            if (!isMouseOver) return;

            var path = AssetDatabase.GUIDToAssetPath(guid);
            if (!AssetDatabase.IsValidFolder(path)) return;

            var editIcon = (isSmall) ? GetEditIconSmall() : GetEditIconLarge(); ;
            DrawCustomIcon(ref rect, editIcon, isSmall);

            if (GUI.Button(rect, GUIContent.none, GUIStyle.none))
            {
                //PopupWindow.Show(rect, new RainbowFoldersPopupWindow(path));
                var position = GUIUtility.GUIToScreenPoint(rect.position + new Vector2(0, rect.height + 2));
                var size = new Vector2(100f, 100f); // TODO
                DraggablePopupWindow.Show<DraggablePopupWindow>(new Rect(position, size));
            }

            EditorApplication.RepaintProjectWindow();
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

        [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
        private static Texture2D GetEditIconSmall()
        {
            if (_editIconSmall == null)
                _editIconSmall = EditorGUIUtility.Load("RainbowFolders/Textures/edit_icon_16.png") as Texture2D;

            return _editIconSmall;
        }

        [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
        private static Texture2D GetEditIconLarge()
        {
            if (_editIconLarge == null)
                _editIconLarge = EditorGUIUtility.Load("RainbowFolders/Textures/edit_icon_64.png") as Texture2D;

            return _editIconLarge;
        }
    }
}
