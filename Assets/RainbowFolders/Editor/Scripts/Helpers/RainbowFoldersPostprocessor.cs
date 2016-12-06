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

using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Editor
{
    public class RainbowFoldersPostprocessor : AssetPostprocessor
    {
        private const string PREF_KEY = "RainbowFolders.IsWelcomeShown";

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (EditorPrefs.GetBool(PREF_KEY)) return;

            var position = CalcWindowPosition();
            RainbowFoldersWelcome.ShowWindow(position);
            EditorPrefs.SetBool(PREF_KEY, true);
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static Vector2 CalcWindowPosition()
        {
            return GetProjectWindow().position.position + new Vector2(10f, 50f);
        }

        private static EditorWindow GetProjectWindow()
        {
            return GetWindowByName("UnityEditor.ProjectWindow") ?? GetWindowByName("UnityEditor.ObjectBrowser") ?? GetWindowByName("UnityEditor.ProjectBrowser");
        }

        private static EditorWindow GetWindowByName(string pName)
        {
            UnityEngine.Object[] objectList = Resources.FindObjectsOfTypeAll(typeof(EditorWindow));

            foreach (UnityEngine.Object obj in objectList)
            {
                if (obj.GetType().ToString() == pName)
                    return ((EditorWindow)obj);
            }

            return (null);
        }
    }
}