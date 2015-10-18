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
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowItems.Editor
{
    /* 
    * This script allows you to set custom icons for folders in project browser.
    * Recommended icon sizes - small: 16x16 px, large: 64x64 px;
    */

    [InitializeOnLoad]
    public class CustomBrowserIcons
    {
        private const string ICONS_FOLDER_PATH = "Assets/RainbowItems/Editor/Sprites/";

        static CustomBrowserIcons()
        {
            EditorApplication.projectWindowItemOnGUI += ReplaceFolderIcon;
        }

        static void ReplaceFolderIcon(string guid, Rect rect)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);

            if (!AssetDatabase.IsValidFolder(path)) return;

            string smallIconName, largeIconName;
            switch (Path.GetFileName(path))
            {
                case "Scripts":
                    smallIconName = "scripts_icon_16.png";
                    largeIconName = "scripts_icon_64.png";
                    break;
                case "Scenes":
                    smallIconName = "scenes_icon_16.png";
                    largeIconName = "scenes_icon_64.png";
                    break;
                default:
                    return;
            }

            string spritePath;
            if (rect.width > rect.height)
            {
                rect.width = rect.height;
                spritePath = ICONS_FOLDER_PATH + smallIconName;
            }
            else
            {
                rect.height = rect.width;
                spritePath = ICONS_FOLDER_PATH + largeIconName;
            }


            var sprite = AssetDatabase.LoadAssetAtPath(spritePath, typeof(Sprite)) as Sprite;
            CustomEditorUtility.DrawTextureGUI(rect, sprite);
        }

    }

}
