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
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Editor
{
    [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
    public static class RainbowFoldersEditorUtility
    {
        public static readonly Color32 BG_COLOR_FREE = new Color32(194, 194, 194, 255);
        public static readonly Color32 BG_COLOR_PRO = new Color32(56, 56, 56, 255);

        private const string LOAD_ASSET_ERROR_MSG = "Could not load {0}\n" +
                                                    "Did you move the \"Rainbow Folders\" around in your project? " +
                                                    "Go to \"Preferences -> Rainbow Folders\" and update the location of the asset.";

        private static Texture2D _defaultFolderIcon;
        private static Texture2D _editIconSmall;
        private static Texture2D _editIconLarge;
        private static Texture2D _settingsIcon;
        private static Texture2D _deleteIcon;
        private static Texture2D _presetsIcon;
        private static Texture2D _assetLogo;

        private static Texture2D _collabBackgroundSmallFree;
        private static Texture2D _collabBackgroundSmallPro;
        private static Texture2D _collabBackgroundLargeFree;
        private static Texture2D _collabBackgroundLargePro;

        //---------------------------------------------------------------------
        // Assets
        //---------------------------------------------------------------------

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

        public static T LoadFromAsset<T>(string relativePath) where T : UnityEngine.Object
        {
            var assetPath = Path.Combine(RainbowFoldersPreferences.HomeFolder, relativePath);
            var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);            
            if (!asset) Debug.LogError(string.Format(LOAD_ASSET_ERROR_MSG, assetPath));
            return asset;
        }

        //---------------------------------------------------------------------
        // Textures
        //---------------------------------------------------------------------

        public static Texture2D GetDefaultFolderIcon()
        {
            if (_defaultFolderIcon == null)
                _defaultFolderIcon = EditorGUIUtility.FindTexture("Folder Icon");

            return _defaultFolderIcon;
        }

        public static Texture2D GetEditFolderIcon(bool isSmall)
        {
            return (isSmall) ? GetEditIconSmall() : GetEditIconLarge();
        }

        public static Texture2D GetSettingsButtonIcon()
        {
            return GetTexture(ref _settingsIcon, "icon_settings_16.png");
        }

        public static Texture2D GetDeleteButtonIcon()
        {
            return GetTexture(ref _deleteIcon, "icon_delete_16.png");
        }

        public static Texture2D GetPresetsButtonIcon()
        {
            return GetTexture(ref _presetsIcon, "icon_presets_16.png");
        }

        public static Texture2D GetAssetLogo()
        {
            return GetTexture(ref _assetLogo, "rainbow_logo_64.png");
        }

        public static Texture2D GetCollabBackground(bool isSmall,bool isPro)
        {
            return isSmall
                ? isPro
                    ? GetTexture(ref _collabBackgroundSmallPro, "collab_bg_pro_16.png")
                    : GetTexture(ref _collabBackgroundSmallFree, "collab_bg_free_16.png")
                : isPro
                    ? GetTexture(ref _collabBackgroundLargePro, "collab_bg_pro_64.png")
                    : GetTexture(ref _collabBackgroundLargeFree, "collab_bg_free_64.png");
        }

        //---------------------------------------------------------------------
        // Windows
        //---------------------------------------------------------------------

        public static EditorWindow GetProjectWindow()
        {
            return GetWindowByName("UnityEditor.ProjectWindow")
                ?? GetWindowByName("UnityEditor.ObjectBrowser")
                ?? GetWindowByName("UnityEditor.ProjectBrowser");
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static EditorWindow GetWindowByName(string pName)
        {
            var objectList = Resources.FindObjectsOfTypeAll(typeof(EditorWindow));
            return (from obj in objectList where obj.GetType().ToString() == pName select ((EditorWindow)obj)).FirstOrDefault();
        }

        private static Texture2D GetEditIconSmall()
        {
            return GetTexture(ref _editIconSmall, "icon_edit_16.png");
        }

        private static Texture2D GetEditIconLarge()
        {
            return GetTexture(ref _editIconLarge, "icon_edit_64.png");
        }

        private static Texture2D GetTexture(ref Texture2D texture, string fileName)
        {
            if (texture == null)
                texture = LoadFromAsset<Texture2D>("Editor/Textures/" + fileName);

            return texture;
        }

    }
}