using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using Borodar.RainbowFolders.Editor.Settings;
using UnityEditor;

namespace Borodar.RainbowFolders.Editor
{
    [InitializeOnLoad]
    public static class RainbowFoldersProjectContextMenu
    {
        private const string COLORIZE_MENU = "Assets/Rainbow Folders/Colorize/";

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
            FolderColorsContainer.Load();
            var selectedObj = Selection.activeObject;
            if (selectedObj == null)
            {
                Debug.LogWarning("Cannot apply color from the left column of the project view." +
                                 "Please right click the folder in the right column if you are using two-column layout");
                return;
            }

            DefaultAsset asset;
            try
            {
                asset = (DefaultAsset) Selection.activeObject;
            }
            catch (InvalidCastException)
            {
                Debug.LogWarning("Can only colorize folders");
                return;
            }

            var path = AssetDatabase.GetAssetPath(asset);
            if (!AssetDatabase.IsValidFolder(path))
            {
                Debug.LogWarning("Can only colorize folders");
                return;
            }

            Debug.Log("Colorizing " + path);
            var iconsForFolder = FolderColorsContainer.Load().GetFolderByColor(color);
            var settings = RainbowFoldersSettings.Load();

            var folder = settings.Folders.SingleOrDefault(x => x.Name == asset.name);
            if (folder == null)
            {
                // add new
                settings.Folders.Add(new RainbowFolder
                {
                    Name = asset.name,
                    SmallIcon = iconsForFolder.SmallIcon,
                    LargeIcon = iconsForFolder.LargeIcon
                });
            }
            else
            {
                // modify existing
                folder.SmallIcon = iconsForFolder.SmallIcon;
                folder.LargeIcon = iconsForFolder.LargeIcon;
            }
        }
    }
}