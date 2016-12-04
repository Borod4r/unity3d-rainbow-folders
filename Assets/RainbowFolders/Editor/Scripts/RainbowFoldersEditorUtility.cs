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

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Editor
{
    [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
    public static class RainbowFoldersEditorUtility
    {
        private static Texture2D _editIconSmall;
        private static Texture2D _editIconLarge;
        private static Texture2D _settingsIcon;
        private static Texture2D _deleteIcon;

        /// <summary>
        /// Creates .asset file of the specified <see cref="UnityEngine.ScriptableObject"/>
        /// </summary>
        public static void CreateAsset<T>(string baseName, string forcedPath = "") where T : ScriptableObject
        {
            if (baseName.Contains("/"))
                throw new ArgumentException("Base name should not contain slashes");

            var asset = ScriptableObject.CreateInstance<T>();

            string path;
            if (!string.IsNullOrEmpty(forcedPath))
            {
                path = forcedPath;
                Directory.CreateDirectory(forcedPath);
            }
            else
            {
                path = AssetDatabase.GetAssetPath(Selection.activeObject);

                if (string.IsNullOrEmpty(path))
                {
                    path = "Assets";
                }
                else if (Path.GetExtension(path) != string.Empty)
                {
                    path = path.Replace(Path.GetFileName(path), string.Empty);
                }
            }

            var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + baseName + ".asset");

            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        public static Texture2D GetDefaultFolderIcon()
        {
            return EditorGUIUtility.FindTexture("Folder Icon");
        }

        public static Texture2D GetEditFolderIcon(bool isSmall)
        {
            return (isSmall) ? GetEditIconSmall() : GetEditIconLarge();
        }

        public static Texture2D GetSettingsButtonIcon()
        {
            if (_settingsIcon == null)
                _settingsIcon = EditorGUIUtility.Load("RainbowFolders/Textures/icon_settings_16.png") as Texture2D;

            return _settingsIcon;
        }

        public static Texture2D GetDeleteButtonIcon()
        {
            if (_deleteIcon == null)
                _deleteIcon = EditorGUIUtility.Load("RainbowFolders/Textures/icon_delete_16.png") as Texture2D;

            return _deleteIcon;
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static Texture2D GetEditIconSmall()
        {
            if (_editIconSmall == null)
                _editIconSmall = EditorGUIUtility.Load("RainbowFolders/Textures/icon_edit_16.png") as Texture2D;

            return _editIconSmall;
        }

        private static Texture2D GetEditIconLarge()
        {
            if (_editIconLarge == null)
                _editIconLarge = EditorGUIUtility.Load("RainbowFolders/Textures/icon_edit_64.png") as Texture2D;

            return _editIconLarge;
        }

    }
}