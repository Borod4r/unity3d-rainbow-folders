using UnityEngine;
using System.Collections.Generic;

namespace Borodar.RainbowFolders.Editor
{
    public class FolderColorsContainer : ScriptableObject
    {
        public const string RESOURCE_NAME = "RainbowColorFoldersIconsStorage";

        public List<RainbowColorFolder> ColorFolderIcons;

        public static FolderColorsContainer Load()
        {
            var colorIcons = Resources.Load<FolderColorsContainer>(RESOURCE_NAME);
            if (colorIcons == null)
            {
                RainbowFoldersEditorUtility.CreateAsset<FolderColorsContainer>(RESOURCE_NAME, "Assets/Resources/Internal");
                colorIcons = Resources.Load<FolderColorsContainer>(RESOURCE_NAME);
            }
            return colorIcons;
        }
    }
}
