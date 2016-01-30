using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Borodar.RainbowFolders.Editor
{
    [InitializeOnLoad]
    public class FolderColorsStorage : ScriptableObject
    {
        public const string RESOURCE_NAME = "Internal/RainbowColorFoldersIconsStorage";

        public List<RainbowColorFolder> ColorFolderIcons;

        private static FolderColorsStorage instance;

        static FolderColorsStorage()
        {
            LoadFromResources();
            if (instance != null) return;
            RainbowFoldersEditorUtility.CreateAsset<FolderColorsStorage>(RESOURCE_NAME, "Assets/Resources/Internal");
            LoadFromResources();
        }

        private static void LoadFromResources()
        {
            instance = Resources.Load<FolderColorsStorage>(RESOURCE_NAME);
        }

        public static FolderColorsStorage GetInstance()
        {
            if (instance == null)
            {
                throw new NullReferenceException("Storage of colorful folder icons was not initialized correctly");
            }

            return instance;
        }

        public RainbowColorFolder GetFolderByColor(FolderColors color)
        {
            return ColorFolderIcons.Single(x => x.Color == color);
        }
    }
}
