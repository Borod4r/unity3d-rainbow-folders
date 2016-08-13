using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using Borodar.RainbowFolders.Editor.Settings;
using System.IO;

namespace Borodar.RainbowFolders.Editor
{
    public class FolderTypesStorage : ScriptableObject
    {
        public const string FOLDER_TYPE_STORAGE_ASSET_NAME = "RainbowTypeFoldersIconsStorage";

        public List<RainbowTypeFolder> TypeFolderIcons;

        private static FolderTypesStorage instance;

        public static FolderTypesStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    var typeStorageAssetPath = GetTypeStorageAssetPath();
                    if ((instance = EditorGUIUtility.Load(typeStorageAssetPath) as FolderTypesStorage) == null)
                    {
                        if (!Directory.Exists(Path.Combine(Application.dataPath, RainbowFoldersSettings.SETTINGS_PATH)))
                        {
                            AssetDatabase.CreateFolder("Assets", RainbowFoldersSettings.SETTINGS_PATH);
                        }

                        RainbowFoldersEditorUtility.CreateAsset<FolderColorsStorage>(FOLDER_TYPE_STORAGE_ASSET_NAME,
                            Path.Combine("Assets", RainbowFoldersSettings.SETTINGS_PATH));
                        instance = EditorGUIUtility.Load(typeStorageAssetPath) as FolderTypesStorage;
                    }
                }
                return instance;
            }
        }

        private static string GetTypeStorageAssetPath()
        {
            string assetNameWithExtension = string.Join(".", new[]
                {
                    FOLDER_TYPE_STORAGE_ASSET_NAME,
                    RainbowFoldersSettings.SETTINGS_ASSET_EXTENSION
                });
            string settingsPath = Path.Combine(RainbowFoldersSettings.SETTINGS_FOLDER, assetNameWithExtension);
            return settingsPath;
        }

        public FolderIconPair GetIconsByType(FolderTypes type)
        {
            var colorFolder = TypeFolderIcons.Single(x => x.Type == type);
            return new FolderIconPair { SmallIcon = colorFolder.SmallIcon, LargeIcon = colorFolder.LargeIcon };
        }
    }
}
