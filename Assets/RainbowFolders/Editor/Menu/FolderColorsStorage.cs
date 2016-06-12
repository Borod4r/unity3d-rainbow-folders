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
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using Borodar.RainbowFolders.Editor.Settings;
using System.IO;

namespace Borodar.RainbowFolders.Editor
{
    [InitializeOnLoad]
    public class FolderColorsStorage : ScriptableObject
    {
        public const string RESOURCE_NAME = "RainbowColorFoldersIconsStorage";

        private static readonly string RESOURCE_PATH = Path.Combine(RainbowFoldersSettings.SETTINGS_FOLDER, "Internal");

        public List<RainbowColorFolder> ColorFolderIcons;

        private static FolderColorsStorage instance;

        static FolderColorsStorage()
        {
            LoadFromResources();
            if (instance != null) return;
//            RainbowFoldersEditorUtility.CreateAsset<FolderColorsStorage>(RESOURCE_NAME, "Assets/Resources/Internal");
            LoadFromResources();
        }

        private static void LoadFromResources()
        {
            string assetNameWithExtension = string.Join (".", new [] 
            {
                RESOURCE_NAME,
                RainbowFoldersSettings.SETTINGS_ASSET_EXTENSION
            });
            instance = EditorGUIUtility.Load(Path.Combine(RESOURCE_PATH, assetNameWithExtension)) as FolderColorsStorage;
        }

        public static FolderColorsStorage GetInstance()
        {
            if (instance == null)
            {
                LoadFromResources();
            }
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
