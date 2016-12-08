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
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Editor
{
    public class RainbowFoldersPreferences
    {
        private const string HOME_FOLDER_PREF_KEY = "Borodar.RainbowFolders.HomeFolder.";
        private const string HOME_FOLDER_DEFAULT = "Assets/RainbowFolders";
        private const string HOME_FOLDER_HINT = "Change this setting to the new location of the \"Rainbow Folders\" if you move the folder around in your project.";

        public static EditorPrefsString HomeFolder = new EditorPrefsString(HOME_FOLDER_PREF_KEY + ProjectName, "Folder Location", HOME_FOLDER_DEFAULT);

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        [PreferenceItem("Rainbow Folders")]
        public static void EditorPreferences()
        {
            EditorGUILayout.HelpBox(HOME_FOLDER_HINT, MessageType.Info);
            EditorGUILayout.Separator();
            HomeFolder.Draw();
            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField("Version " + AssetInfo.VERSION, EditorStyles.centeredGreyMiniLabel);
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static string ProjectName
        {
            get
            {
                var s = Application.dataPath.Split('/');
                var p = s[s.Length - 2];
                return p;
            }
        }

        //---------------------------------------------------------------------
        // Nested
        //---------------------------------------------------------------------

        public abstract class EditorPrefsItem<T>
        {
            public string Key;
            public string Label;
            public T DefaultValue;

            protected EditorPrefsItem(string key, string label, T defaultValue)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException("key");
                }

                Key = key;
                Label = label;
                DefaultValue = defaultValue;
            }

            public abstract T Value { get; set; }
            public abstract void Draw();

            public static implicit operator T(EditorPrefsItem<T> s)
            {
                return s.Value;
            }
        }

        public class EditorPrefsString : EditorPrefsItem<string>
        {
            public EditorPrefsString(string key, string label, string defaultValue)
                : base(key, label, defaultValue)
            {
            }

            public override string Value
            {
                get { return EditorPrefs.GetString(Key, DefaultValue); }
                set { EditorPrefs.SetString(Key, value); }
            }

            public override void Draw()
            {
                EditorGUIUtility.labelWidth = 100f;
                Value = EditorGUILayout.TextField(Label, Value);
            }
        }
    }
}