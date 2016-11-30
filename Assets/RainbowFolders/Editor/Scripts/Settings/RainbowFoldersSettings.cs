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
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using KeyType = Borodar.RainbowFolders.Editor.Settings.RainbowFolder.KeyType;

namespace Borodar.RainbowFolders.Editor.Settings
{
    public class RainbowFoldersSettings : ScriptableObject
    {
        public const string SETTINGS_ASSET_EXTENSION = "asset";
        public const string SETTINGS_ASSET_NAME = "RainbowFoldersSettings";
        public const string SETTINGS_FOLDER = "RainbowFolders";
        public const string SETTINGS_PATH = "Editor Default Resources/" + SETTINGS_FOLDER;

        public List<RainbowFolder> Folders;

        //---------------------------------------------------------------------
        // Instance
        //---------------------------------------------------------------------

        private static RainbowFoldersSettings _instance;

        public static RainbowFoldersSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    var assetNameWithExtension = string.Join (".", new [] { SETTINGS_ASSET_NAME, SETTINGS_ASSET_EXTENSION });
                    var settingsPath = Path.Combine(SETTINGS_FOLDER, assetNameWithExtension);

                    if ((_instance = EditorGUIUtility.Load(settingsPath) as RainbowFoldersSettings) == null)
                    {
                        if (!Directory.Exists(Path.Combine(Application.dataPath, SETTINGS_PATH)))
                        {
                            AssetDatabase.CreateFolder("Assets", SETTINGS_PATH);
                        }

                        RainbowFoldersEditorUtility.CreateAsset<RainbowFoldersSettings>(SETTINGS_ASSET_NAME, Path.Combine("Assets", SETTINGS_PATH));
                        _instance = EditorGUIUtility.Load(settingsPath) as RainbowFoldersSettings;
                    }
                }
                return _instance;
            }
        }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public RainbowFolder GetFolder(string folderPath)
        {
            if (IsNullOrEmpty(Folders)) return null;

            foreach (var folder in Folders)
            {
                switch (folder.Type)
                {
                    case KeyType.Name:
                        var folderName = Path.GetFileName(folderPath);
                        if (folder.Key.Equals(folderName)) return folder;
                        break;
                    case KeyType.Path:
                        if (folder.Key.Equals(folderPath)) return folder;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return null;
        }

        public Texture2D GetFolderIcon(string folderPath, bool small = true)
        {
            var folder = GetFolder(folderPath);
            if (folder == null) return null;

            return small ? folder.SmallIcon : folder.LargeIcon;
        }

        public void ChangeFolderIcons(RainbowFolder value)
        {
            Undo.RecordObject(this, "Modify Rainbow Folder Settings");

            var folder = Folders.SingleOrDefault(x => x.Type == value.Type && x.Key == value.Key);
            if (folder == null)
            {
                AddFolder(new RainbowFolder(value.Type, value.Key, value.SmallIcon, value.LargeIcon));
            }
            else
            {
                folder.SmallIcon = value.SmallIcon;
                folder.LargeIcon = value.LargeIcon;
            }

            EditorUtility.SetDirty(this);
        }

        public void ChangeFolderIconsByPath(string path, FolderIconPair icons)
        {
            ChangeFolderIcons(new RainbowFolder(KeyType.Path, path, icons.SmallIcon, icons.LargeIcon));
        }

        public void AddFolder(RainbowFolder folder)
        {
            Folders.Add(folder);
        }

        public void RemoveAll(RainbowFolder match)
        {
            Folders.RemoveAll(x => x.Type == match.Type && x.Key == match.Key);
        }

        public void RemoveAllByPath(string path)
        {
            Folders.RemoveAll(x => x.Key == path);
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static bool IsNullOrEmpty(ICollection collection)
        {
            return collection == null || (collection.Count == 0);
        }
    }
}