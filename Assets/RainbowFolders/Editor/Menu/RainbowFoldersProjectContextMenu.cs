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

namespace Borodar.RainbowFolders.Editor
{
    [InitializeOnLoad]
    public static class RainbowFoldersProjectContextMenu
    {
        private const string COLORIZE_MENU = "Assets/Rainbow Folders/Colorize/";

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

        private const string WARNING_MSG =
            "Can only colorize folders. Please right click on the folder in the Project window";

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

        public static void Colorize(FolderColors color)
        {
            WarnAboutTwoColumnLayout();

            var selectedObj = Selection.activeObject;
            if (selectedObj == null)
            {
                Debug.LogWarning("Cannot apply color from the left column of the project view." +
                                 "Please right click the folder in the right column if you are using two-column layout");
                return;
            }

            if (!(selectedObj is DefaultAsset))
            {
                Debug.LogWarning(WARNING_MSG);
                return;
            }

            var path = AssetDatabase.GetAssetPath(selectedObj);
            if (!AssetDatabase.IsValidFolder(path))
            {
                Debug.LogWarning(WARNING_MSG);
                return;
            }

            var settings = RainbowFoldersSettings.Load();

            if (color != FolderColors.Default)
            {
                settings.ColorizeFolderByPath(path, FolderColorsStorage.GetInstance().GetFolderByColor(color));
            }
            else
            {
                settings.RemoveAllByPath(path);
            }
        }

        private static void WarnAboutTwoColumnLayout()
        {
            if (RainbowFoldersEditorUtility.IsLastSelectedProjectViewInTwoColumnLayout())
            {
                Debug.LogWarning("Please remember to perform colorizing on the folder in the right column of the project view");
            }
        }
    }
}