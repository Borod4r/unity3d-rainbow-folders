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
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using Borodar.RainbowFolders.Editor.Settings;
using System.IO;

namespace Borodar.RainbowFolders.Editor
{
    public class FolderTagsStorage : ScriptableObject
    {
        public const string FOLDER_TAGS_STORAGE_ASSET_NAME = "RainbowTagsIconsStorage";

        public List<RainbowTaggedFolder> ColorFolderTags;

        #region instance
        private static FolderTagsStorage instance;

        public static FolderTagsStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    var colorStorageAssetPath = GetColorStorageAssetPath();
                    if ((instance = EditorGUIUtility.Load(colorStorageAssetPath) as FolderTagsStorage) == null)
                    {
                        if (!Directory.Exists(Path.Combine(Application.dataPath, RainbowFoldersSettings.SETTINGS_PATH)))
                        {
                            AssetDatabase.CreateFolder("Assets", RainbowFoldersSettings.SETTINGS_PATH);
                        }

                        RainbowFoldersEditorUtility.CreateAsset<FolderTagsStorage>(FOLDER_TAGS_STORAGE_ASSET_NAME, 
                            Path.Combine("Assets", RainbowFoldersSettings.SETTINGS_PATH));
                        instance = EditorGUIUtility.Load(colorStorageAssetPath) as FolderTagsStorage;
                    }
                }
                return instance;
            }
        }

        // Path to load from 'Editor Default Resources' folder.
        private static string GetColorStorageAssetPath()
        {
            string assetNameWithExtension = string.Join(".", new []
                {
                    FOLDER_TAGS_STORAGE_ASSET_NAME,
                    RainbowFoldersSettings.SETTINGS_ASSET_EXTENSION
                });
            string settingsPath = Path.Combine(RainbowFoldersSettings.SETTINGS_FOLDER, assetNameWithExtension);
            return settingsPath;
        }
        #endregion

        public FolderIconPair GetIconsByTag(FolderTags tag)
        {
            var taggedFolder = ColorFolderTags.Single(x => x.Tag == tag);
            return new FolderIconPair { SmallIcon = taggedFolder.SmallIcon, LargeIcon = taggedFolder.LargeIcon };
        }
    }
}
