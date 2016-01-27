using System;
using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Borodar.RainbowFolders.Editor
{
    [InitializeOnLoad]
    public static class RainbowFoldersProjectContextMenu
    {
        private const string COLORIZE_MENU = "Assets/Rainbow Folders/Colorize/";

        private const string COLORIZE_RED = COLORIZE_MENU + "Red";
        private const string COLORIZE_VERMILION = COLORIZE_MENU + "Vermilion";

        [MenuItem(COLORIZE_RED)]
        public static void ContextMenuColorizeRed() { ColorizeSelectedFolder();}
        [MenuItem(COLORIZE_VERMILION)]
        public static void ContextMenuColorizeVermilion() { ColorizeSelectedFolder(); }

        public static void ColorizeSelectedFolder()
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
            Debug.Log(asset.name + "   " + path);

            if (AssetDatabase.IsValidFolder(path))
            {
                Debug.Log("Colorizing " + path);
                // TODO Colorize logic goes here
            }
            else
            {
                Debug.LogWarning("Can only colorize folders");
            }
        }
    }
}