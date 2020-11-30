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

using System.Linq;
using Borodar.RainbowFolders.Editor.Settings;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Editor
{
    public static class RainbowFoldersContextMenu
    {
        private const string MENU_BASE = "Assets/Rainbow Folders/";
        
        // Items
        private const string ITEM_CUSTOM = MENU_BASE + "Apply Custom";
        private const string ITEM_DEFAULT = MENU_BASE + "Revert to Default";
        private const string ITEM_SETTINGS = MENU_BASE + "Settings";
        
        // Sub-menus        
        private const string MENU_COLOR = MENU_BASE + "Color/";
        private const string MENU_TAG = MENU_BASE + "Tag/";
        private const string MENU_TYPE = MENU_BASE + "Type/";        
        private const string MENU_PLATFORM = MENU_BASE + "Platform/";        

        // Colors
        private const string COLOR_RED = MENU_COLOR + "Red";
        private const string COLOR_VERMILION = MENU_COLOR + "Vermilion";
        private const string COLOR_ORANGE = MENU_COLOR + "Orange";
        private const string COLOR_YELLOW_ORANGE = MENU_COLOR + "Yellow-Orange";
        private const string COLOR_YELLOW = MENU_COLOR + "Yellow";
        private const string COLOR_LIME = MENU_COLOR + "Lime";
        private const string COLOR_GREEN = MENU_COLOR + "Green";
        private const string COLOR_BONDI_BLUE = MENU_COLOR + "Bondi Blue";
        private const string COLOR_BLUE = MENU_COLOR + "Blue";
        private const string COLOR_INDIGO = MENU_COLOR + "Indigo";
        private const string COLOR_VIOLET = MENU_COLOR + "Violet";
        private const string COLOR_MAGENTA = MENU_COLOR + "Magenta";

        // Tags
        private const string TAG_RED = MENU_TAG + "Red";
        private const string TAG_VERMILION = MENU_TAG + "Vermilion";
        private const string TAG_ORANGE = MENU_TAG + "Orange";
        private const string TAG_YELLOW_ORANGE = MENU_TAG + "Yellow-Orange";
        private const string TAG_YELLOW = MENU_TAG + "Yellow";
        private const string TAG_LIME = MENU_TAG + "Lime";
        private const string TAG_GREEN = MENU_TAG + "Green";
        private const string TAG_CYAN = MENU_TAG + "Cyan";
        private const string TAG_BLUE = MENU_TAG + "Blue";
        private const string TAG_DARK_BLUE = MENU_TAG + "Dark Blue";
        private const string TAG_VIOLET = MENU_TAG + "Violet";
        private const string TAG_MAGENTA = MENU_TAG + "Magenta";

        // Types
        private const string TYPE_PREFABS = MENU_TYPE + "Prefabs";
        private const string TYPE_SCENES = MENU_TYPE + "Scenes";
        private const string TYPE_SCRIPTS = MENU_TYPE + "Scripts";
        private const string TYPE_EXTENSIONS = MENU_TYPE + "Extensions";
        private const string TYPE_PLUGINS = MENU_TYPE + "Plugins";
        private const string TYPE_TEXTURES = MENU_TYPE + "Textures";
        private const string TYPE_MATERIALS = MENU_TYPE + "Materials";
        private const string TYPE_AUDIO = MENU_TYPE + "Audio";
        private const string TYPE_BRACKETS = MENU_TYPE + "Brackets";
        private const string TYPE_FONTS = MENU_TYPE + "Fonts";
        private const string TYPE_EDITOR = MENU_TYPE + "Editor";
        private const string TYPE_RESOURCES = MENU_TYPE + "Resources";
        private const string TYPE_SHADERS = MENU_TYPE + "Shaders";
        private const string TYPE_TERRAINS = MENU_TYPE + "Terrains";
        private const string TYPE_MESHES = MENU_TYPE + "Meshes";
        private const string TYPE_RAINBOW = MENU_TYPE + "Rainbow";

        // Platforms

        private const string PLATFORM_ANDROID = MENU_PLATFORM + "Android";
        private const string PLATFORM_IOS = MENU_PLATFORM + "iOS";
        private const string PLATFORM_MAC = MENU_PLATFORM + "Mac";
        private const string PLATFORM_WEBGL = MENU_PLATFORM + "WebGL";
        private const string PLATFORM_WINDOWS = MENU_PLATFORM + "Windows";

        //---------------------------------------------------------------------
        // Menu Items
        //---------------------------------------------------------------------

        [MenuItem(ITEM_CUSTOM, false, 0)]
        public static void ApplyCustom()
        {
            var window = RainbowFoldersPopup.GetDraggableWindow();
            var position = RainbowFoldersEditorUtility.GetProjectWindow().position.position + new Vector2(10f, 30f);
            var paths = Selection.assetGUIDs.Select<string, string>(AssetDatabase.GUIDToAssetPath).Where(AssetDatabase.IsValidFolder).ToList();
            window.ShowWithParams(position, paths.ToList(), 0);
        }

        [MenuItem(ITEM_DEFAULT, false, 0)]
        public static void RevertToDefault()
        {
            RevertSelectedFoldersToDefault();
        }

        [MenuItem(ITEM_SETTINGS, false, 2000)]
        public static void OpenSettings()
        {
            Selection.activeObject = RainbowFoldersSettings.Instance;
        }

        [MenuItem(ITEM_CUSTOM, true)]
        [MenuItem(ITEM_DEFAULT, true)]
        public static bool IsValidFolder()
        {
            var hasValidFolder = false;

            foreach (var guid in Selection.assetGUIDs)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                hasValidFolder |= AssetDatabase.IsValidFolder(path);
            }

            return hasValidFolder;
        }

        // Colors

        [MenuItem(COLOR_RED)]
        public static void Red() { Colorize(FolderColorName.Red); }
        [MenuItem(COLOR_VERMILION)]
        public static void Vermilion() { Colorize(FolderColorName.Vermilion); }
        [MenuItem(COLOR_ORANGE)]
        public static void Orange() { Colorize(FolderColorName.Orange); }
        [MenuItem(COLOR_YELLOW_ORANGE)]
        public static void YellowOrange() { Colorize(FolderColorName.YellowOrange); }
        [MenuItem(COLOR_YELLOW)]
        public static void Yellow() { Colorize(FolderColorName.Yellow); }
        [MenuItem(COLOR_LIME)]
        public static void Lime() { Colorize(FolderColorName.Lime); }
        [MenuItem(COLOR_GREEN)]
        public static void Green() { Colorize(FolderColorName.Green); }
        [MenuItem(COLOR_BONDI_BLUE)]
        public static void BondiBlue() { Colorize(FolderColorName.BondiBlue); }
        [MenuItem(COLOR_BLUE)]
        public static void Blue() { Colorize(FolderColorName.Blue); }
        [MenuItem(COLOR_INDIGO)]
        public static void Indigo() { Colorize(FolderColorName.Indigo); }
        [MenuItem(COLOR_VIOLET)]
        public static void Violet() { Colorize(FolderColorName.Violet); }
        [MenuItem(COLOR_MAGENTA)]
        public static void Magenta() { Colorize(FolderColorName.Magenta); }

        // Tags

        [MenuItem(TAG_RED)]
        public static void TagRed() { AssignTag(FolderTagName.Red); }
        [MenuItem(TAG_VERMILION)]
        public static void TagVermilion() { AssignTag(FolderTagName.Vermilion); }
        [MenuItem(TAG_ORANGE)]
        public static void TagOrange() { AssignTag(FolderTagName.Orange); }
        [MenuItem(TAG_YELLOW_ORANGE)]
        public static void TagYellowOrange() { AssignTag(FolderTagName.YellowOrange); }
        [MenuItem(TAG_YELLOW)]
        public static void TagYellow() { AssignTag(FolderTagName.Yellow); }
        [MenuItem(TAG_LIME)]
        public static void TagLime() { AssignTag(FolderTagName.Lime); }
        [MenuItem(TAG_GREEN)]
        public static void TagGreen() { AssignTag(FolderTagName.Green); }
        [MenuItem(TAG_CYAN)]
        public static void TagCyan() { AssignTag(FolderTagName.Cyan); }
        [MenuItem(TAG_BLUE)]
        public static void TagBlue() { AssignTag(FolderTagName.Blue); }
        [MenuItem(TAG_DARK_BLUE)]
        public static void TagDarkBlue() { AssignTag(FolderTagName.DarkBlue); }
        [MenuItem(TAG_VIOLET)]
        public static void TagViolet() { AssignTag(FolderTagName.Violet); }
        [MenuItem(TAG_MAGENTA)]
        public static void TagMagenta() { AssignTag(FolderTagName.Magenta); }

        // Types

        [MenuItem(TYPE_AUDIO)]
        public static void TypeAudio() { AssingType(FolderTypeName.Audio); }
        [MenuItem(TYPE_BRACKETS)]
        public static void TypeBrackets() { AssingType(FolderTypeName.Brackets); }
        [MenuItem(TYPE_EDITOR)]
        public static void TypeEditor() { AssingType(FolderTypeName.Editor); }
        [MenuItem(TYPE_EXTENSIONS)]
        public static void TypeExtensions() { AssingType(FolderTypeName.Extensions); }
        [MenuItem(TYPE_FONTS)]
        public static void TypeFonts() { AssingType(FolderTypeName.Fonts); }
        [MenuItem(TYPE_MATERIALS)]
        public static void TypeMaterials() { AssingType(FolderTypeName.Materials); }
        [MenuItem(TYPE_MESHES)]
        public static void TypeMeshes() { AssingType(FolderTypeName.Meshes); }
        [MenuItem(TYPE_PLUGINS)]
        public static void TypePlugins() { AssingType(FolderTypeName.Plugins); }
        [MenuItem(TYPE_PREFABS)]
        public static void TypePrefabs() { AssingType(FolderTypeName.Prefabs); }
        [MenuItem(TYPE_RAINBOW)]
        public static void TypeRainbow() { AssingType(FolderTypeName.Rainbow); }
        [MenuItem(TYPE_RESOURCES)]
        public static void TypeResources() { AssingType(FolderTypeName.Resources); }
        [MenuItem(TYPE_SCENES)]
        public static void TypeScenes() { AssingType(FolderTypeName.Scenes); }
        [MenuItem(TYPE_SCRIPTS)]
        public static void TypeScripts() { AssingType(FolderTypeName.Scripts); }
        [MenuItem(TYPE_SHADERS)]
        public static void TypeShaders() { AssingType(FolderTypeName.Shaders); }
        [MenuItem(TYPE_TERRAINS)]
        public static void TypeTerrains() { AssingType(FolderTypeName.Terrains); }
        [MenuItem(TYPE_TEXTURES)]
        public static void TypeTextures() { AssingType(FolderTypeName.Textures); }

        // Platforms
        [MenuItem(PLATFORM_ANDROID)]
        public static void PlatformAndroid() { AssingPlatform(FolderPlatformName.Android); }
        [MenuItem(PLATFORM_IOS)]
        public static void PlatformiOS() { AssingPlatform(FolderPlatformName.iOS); }
        [MenuItem(PLATFORM_MAC)]
        public static void PlatformMac() { AssingPlatform(FolderPlatformName.Mac); }
        [MenuItem(PLATFORM_WEBGL)]
        public static void PlatformWebGL() { AssingPlatform(FolderPlatformName.WebGL); }
        [MenuItem(PLATFORM_WINDOWS)]
        public static void PlatformWindows() { AssingPlatform(FolderPlatformName.Windows); }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static void Colorize(FolderColorName color)
        {
            var icons = FolderColorsStorage.Instance.GetIconsByColor(color);
            ChangeSelectedFoldersIcons(icons);
        }

        private static void AssignTag(FolderTagName tag)
        {
            var icons = FolderTagsStorage.Instance.GetIconsByTag(tag);
            ChangeSelectedFoldersIcons(icons);
        }

        private static void AssingType(FolderTypeName type)
        {
            var icons = FolderTypesStorage.Instance.GetIconsByType(type);
            ChangeSelectedFoldersIcons(icons);
        }

        private static void AssingPlatform(FolderPlatformName platform)
        {
            var icons = FolderPlatformsStorage.Instance.GetIconsByType(platform);
            ChangeSelectedFoldersIcons(icons);
        }

        private static void ChangeSelectedFoldersIcons(FolderIconPair icons)
        {
            Selection.assetGUIDs.ToList().ForEach(
                assetGuid =>
                {
                    var assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
                    if (!AssetDatabase.IsValidFolder(assetPath)) return;

                    var folder = AssetDatabase.LoadAssetAtPath<DefaultAsset>(assetPath);
                    var path = AssetDatabase.GetAssetPath(folder);
                    RainbowFoldersSettings.Instance.ChangeFolderIconsByPath(path, icons);
                }
            );
        }

        private static void RevertSelectedFoldersToDefault()
        {
            Selection.assetGUIDs.ToList().ForEach(
                assetGuid =>
                {
                    var assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
                    if (AssetDatabase.IsValidFolder(assetPath))
                    {
                        RainbowFoldersSettings.Instance.RemoveAllByPath(assetPath);
                    }
                }
            );
        }
    }
}