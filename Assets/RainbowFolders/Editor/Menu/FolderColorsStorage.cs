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
    public class FolderColorsStorage : ScriptableObject
    {
        public const string FOLDER_COLOR_STORAGET_ASSET_NAME = "RainbowColorFoldersIconsStorage";

        public List<RainbowColorFolder> ColorFolderIcons;

        #region instance
        private static FolderColorsStorage instance;

        public static FolderColorsStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    string assetNameWithExtension = string.Join(".", new []
                    {
                        FOLDER_COLOR_STORAGET_ASSET_NAME,
                        RainbowFoldersSettings.SETTINGS_ASSET_EXTENSION
                    });
                    string settingsPath = Path.Combine(RainbowFoldersSettings.SETTINGS_FOLDER, assetNameWithExtension);

                    if ((instance = EditorGUIUtility.Load(settingsPath) as FolderColorsStorage) == null)
                    {
                        instance = CreateInstance<FolderColorsStorage>();

                        if (!Directory.Exists(Path.Combine(Application.dataPath, RainbowFoldersSettings.SETTINGS_PATH)))
                        {
                            AssetDatabase.CreateFolder("Assets", RainbowFoldersSettings.SETTINGS_PATH);
                        }

                        RainbowFoldersEditorUtility.CreateAsset<RainbowFoldersSettings>(FOLDER_COLOR_STORAGET_ASSET_NAME, 
                            Path.Combine("Assets", RainbowFoldersSettings.SETTINGS_PATH));
                    }
                }
                return instance;
            }
        }
        #endregion

        public RainbowColorFolder GetFolderByColor(FolderColors color)
        {
            return ColorFolderIcons.Single(x => x.Color == color);
        }
    }
}
