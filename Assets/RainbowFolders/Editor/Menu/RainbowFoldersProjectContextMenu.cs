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
using Borodar.RainbowFolders.Editor.Settings;
using UnityEditor;
using System.Linq;

namespace Borodar.RainbowFolders.Editor
{
    [InitializeOnLoad]
    public static class RainbowFoldersProjectContextMenu
    {
        private const string COLORIZE_MENU = "Assets/Rainbow Folders/Colorize/";
        private const string TAG_MENU = "Assets/Rainbow Folders/Tag/";

        // Colors
        private const string DEFAULT = COLORIZE_MENU + "Revert to Default";
        private const string RED = COLORIZE_MENU + "Red";
        private const string VERMILION = COLORIZE_MENU + "Vermilion";
        private const string ORANGE = COLORIZE_MENU + "Orange";
        private const string YELLOW_ORANGE = COLORIZE_MENU + "Yellow-Orange";
        private const string YELLOW = COLORIZE_MENU + "Yellow";
        private const string LIME = COLORIZE_MENU + "Lime";
        private const string GREEN = COLORIZE_MENU + "Green";
        private const string BONDI_BLUE = COLORIZE_MENU + "Bondi Blue";
        private const string BLUE = COLORIZE_MENU + "Blue";
        private const string INDIGO = COLORIZE_MENU + "Indigo";
        private const string VIOLET = COLORIZE_MENU + "Violet";
        private const string MAGENTA = COLORIZE_MENU + "Magenta";

        // Tags
        private const string TAG_DEFAULT = TAG_MENU + "Revert to Default";
        private const string TAG_RED = TAG_MENU + "Red";

        private const string WARNING_MSG =
            "Can only colorize folders. Please right click on the folder in the Project window";

        #region colorize_context_menu
        [MenuItem(DEFAULT, false, 2000)] static void Default() { Colorize(FolderColors.Default); }
        [MenuItem(RED)] static void Red() { Colorize(FolderColors.Red);}
        [MenuItem(VERMILION)] static void Vermilion() { Colorize(FolderColors.Vermilion); }
        [MenuItem(ORANGE)] static void Orange() { Colorize(FolderColors.Orange); }
        [MenuItem(YELLOW_ORANGE)] static void YellowOrange() { Colorize(FolderColors.YellowOrange); }
        [MenuItem(YELLOW)] static void Yellow() { Colorize(FolderColors.Yellow); }
        [MenuItem(LIME)] static void Lime() { Colorize(FolderColors.Lime); }
        [MenuItem(GREEN)] static void Green() { Colorize(FolderColors.Green); }
        [MenuItem(BONDI_BLUE)] static void BondiBlue() { Colorize(FolderColors.BondiBlue); }
        [MenuItem(BLUE)] static void Blue() { Colorize(FolderColors.Blue); }
        [MenuItem(INDIGO)] static void Indigo() { Colorize(FolderColors.Indigo); }
        [MenuItem(VIOLET)] static void Violet() { Colorize(FolderColors.Violet); }
        [MenuItem(MAGENTA)] static void Magenta() { Colorize(FolderColors.Magenta); }
        #endregion

        [MenuItem(TAG_RED)] static void TagRed() { Tag(FolderTags.Red);}

        public static void Tag(FolderTags tag)
        {
            if (tag == FolderTags.None)
            {
                RevertSelectedFoldersToDefault();
                return;
            }

            var icons = FolderTagsStorage.Instance.GetIconsByTag(tag);
            ChangeSelectedFoldersIcons(icons);

        }

        public static void Colorize(FolderColors color)
        {
            if (color == FolderColors.Default)
            {
                RevertSelectedFoldersToDefault();
                return;
            }

            var icons = FolderColorsStorage.Instance.GetIconsByColor(color);
            ChangeSelectedFoldersIcons(icons);
        }

        private static void ChangeSelectedFoldersIcons(FolderIconPair icons)
        {
            Selection.assetGUIDs.ToList().ForEach(
                assetGuid =>
                {
                    var assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
                    if (AssetDatabase.IsValidFolder(assetPath))
                    {
                        var folder = AssetDatabase.LoadAssetAtPath<DefaultAsset>(assetPath);
                        var path = AssetDatabase.GetAssetPath(folder);
                        RainbowFoldersSettings.Instance.ChangeFolderIconsByPath(path, icons);
                    }
                    else
                    {
                        // Can't colorize other assets
                    }
                }
            );
        }

        private static void RevertSelectedFoldersToDefault()
        {
            Selection.assetGUIDs.ToList().ForEach(
                assetGuid =>
                {
                    var assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
                    if (AssetDatabase.IsValidFolder(assetPath))
                    {
                        RainbowFoldersSettings.Instance.RemoveAllByPath(assetPath);
                    }
                }
            );
        }
    }
}