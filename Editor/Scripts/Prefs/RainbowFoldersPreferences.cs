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
        private const string HOME_FOLDER_DEFAULT = "Assets/Plugins/RainbowFolders";
        private const string HOME_FOLDER_HINT = "Change this setting to the new location of the \"Rainbow Folders\" if you move the folder around in your project.";

        private const string MOD_KEY_PREF_KEY = "Borodar.RainbowFolders.EditMod.";
        private const EventModifiers MOD_KEY_DEFAULT = EventModifiers.Alt;
        private const string MOD_KEY_HINT = "Modifier key that is used to show configuration dialogue when clicking on a folder icon.";

        private static readonly EditorPrefsString HOME_FOLDER_PREF;
        private static readonly EditorPrefsModifierKey MODIFIER_KEY_PREF ;

        public static string HomeFolder;
        public static EventModifiers ModifierKey;

        static RainbowFoldersPreferences()
        {
            var homeLabel = new GUIContent("Folder Location", HOME_FOLDER_HINT);
            HOME_FOLDER_PREF = new EditorPrefsString(HOME_FOLDER_PREF_KEY + ProjectName, homeLabel, HOME_FOLDER_DEFAULT);
            HomeFolder = HOME_FOLDER_PREF.Value;

            var modifierLabel = new GUIContent("Modifier Key", MOD_KEY_HINT);
            MODIFIER_KEY_PREF = new EditorPrefsModifierKey(MOD_KEY_PREF_KEY + ProjectName, modifierLabel, MOD_KEY_DEFAULT);
            ModifierKey = MODIFIER_KEY_PREF.Value;
        }

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        [PreferenceItem("Rainbow Folders")]
        public static void EditorPreferences()
        {
            EditorGUILayout.Separator();
            HOME_FOLDER_PREF.Draw();
            HomeFolder = HOME_FOLDER_PREF.Value;

            EditorGUILayout.Separator();
            MODIFIER_KEY_PREF.Draw();
            ModifierKey = MODIFIER_KEY_PREF.Value;

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
            public GUIContent Label;
            public T DefaultValue;

            protected EditorPrefsItem(string key, GUIContent label, T defaultValue)
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
            public EditorPrefsString(string key, GUIContent label, string defaultValue)
                : base(key, label, defaultValue) { }

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

        private class EditorPrefsModifierKey : EditorPrefsItem<EventModifiers> {

            public EditorPrefsModifierKey(string key, GUIContent label, EventModifiers defaultValue)
                : base( key, label, defaultValue ) { }

            public override EventModifiers Value {
                get
                {
                    var index = EditorPrefs.GetInt(Key, (int) DefaultValue);
                    return (Enum.IsDefined(typeof(EventModifiers), index)) ? (EventModifiers) index : DefaultValue;
                }
                set
                {
                    EditorPrefs.SetInt(Key, (int) value);
                }
            }

            public override void Draw() {
                Value = (EventModifiers) EditorGUILayout.EnumPopup(Label, Value);
            }
        }
    }
}