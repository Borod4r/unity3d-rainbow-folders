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


using System.Diagnostics.CodeAnalysis;
using Borodar.RainbowFolders.Editor.Settings;
using UnityEditor;
using System.Linq;

namespace Borodar.RainbowFolders.Editor
{
    [InitializeOnLoad]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public static class RainbowFoldersProjectContextMenu
    {
        private const string MENU_BASE = "Assets/Rainbow Folders/";
        private const string MENU_COLORIZE = MENU_BASE + "Colorize/";
        private const string MENU_TAG = MENU_BASE + "Tag/";
        private const string MENU_TYPE = MENU_BASE + "Folder Type/";

        // Default
        private const string ITEM_DEFAULT = MENU_BASE + "Revert to Default";

        // Colors
        private const string COLOR_RED = MENU_COLORIZE + "Red";
        private const string COLOR_VERMILION = MENU_COLORIZE + "Vermilion";
        private const string COLOR_ORANGE = MENU_COLORIZE + "Orange";
        private const string COLOR_YELLOW_ORANGE = MENU_COLORIZE + "Yellow-Orange";
        private const string COLOR_YELLOW = MENU_COLORIZE + "Yellow";
        private const string COLOR_LIME = MENU_COLORIZE + "Lime";
        private const string COLOR_GREEN = MENU_COLORIZE + "Green";
        private const string COLOR_BONDI_BLUE = MENU_COLORIZE + "Bondi Blue";
        private const string COLOR_BLUE = MENU_COLORIZE + "Blue";
        private const string COLOR_INDIGO = MENU_COLORIZE + "Indigo";
        private const string COLOR_VIOLET = MENU_COLORIZE + "Violet";
        private const string COLOR_MAGENTA = MENU_COLORIZE + "Magenta";

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

        // Type
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

        //---------------------------------------------------------------------
        // Menu Items
        //---------------------------------------------------------------------

        // Default

        [MenuItem(ITEM_DEFAULT, false, 2000)]
        private static void Default() { RevertToDefault(); }

        // Colors

        [MenuItem(COLOR_RED)]
        private static void Red() { Colorize(FolderColors.Red);}
        [MenuItem(COLOR_VERMILION)]
        private static void Vermilion() { Colorize(FolderColors.Vermilion); }
        [MenuItem(COLOR_ORANGE)]
        private static void Orange() { Colorize(FolderColors.Orange); }
        [MenuItem(COLOR_YELLOW_ORANGE)]
        private static void YellowOrange() { Colorize(FolderColors.YellowOrange); }
        [MenuItem(COLOR_YELLOW)]
        private static void Yellow() { Colorize(FolderColors.Yellow); }
        [MenuItem(COLOR_LIME)]
        private static void Lime() { Colorize(FolderColors.Lime); }
        [MenuItem(COLOR_GREEN)]
        private static void Green() { Colorize(FolderColors.Green); }
        [MenuItem(COLOR_BONDI_BLUE)]
        private static void BondiBlue() { Colorize(FolderColors.BondiBlue); }
        [MenuItem(COLOR_BLUE)]
        private static void Blue() { Colorize(FolderColors.Blue); }
        [MenuItem(COLOR_INDIGO)]
        private static void Indigo() { Colorize(FolderColors.Indigo); }
        [MenuItem(COLOR_VIOLET)]
        private static void Violet() { Colorize(FolderColors.Violet); }
        [MenuItem(COLOR_MAGENTA)]
        private static void Magenta() { Colorize(FolderColors.Magenta); }

        // Tags

        [MenuItem(TAG_RED)]
        private static void TagRed() { Tag(FolderTags.Red);}
        [MenuItem(TAG_VERMILION)]
        private static void TagVermilion() { Tag(FolderTags.Vermilion);}
        [MenuItem(TAG_ORANGE)]
        private static void TagOrange() { Tag(FolderTags.Orange);}
        [MenuItem(TAG_YELLOW_ORANGE)]
        private static void TagYellowOrange() { Tag(FolderTags.YellowOrange);}
        [MenuItem(TAG_YELLOW)]
        private static void TagYellow() { Tag(FolderTags.Yellow);}
        [MenuItem(TAG_LIME)]
        private static void TagLime() { Tag(FolderTags.Lime);}
        [MenuItem(TAG_GREEN)]
        private static void TagGreen() { Tag(FolderTags.Green);}
        [MenuItem(TAG_CYAN)]
        private static void TagCyan() { Tag(FolderTags.Cyan);}
        [MenuItem(TAG_BLUE)]
        private static void TagBlue() { Tag(FolderTags.Blue);}
        [MenuItem(TAG_DARK_BLUE)]
        private static void TagDarkBlue() { Tag(FolderTags.DarkBlue);}
        [MenuItem(TAG_VIOLET)]
        private static void TagViolet() { Tag(FolderTags.Violet);}
        [MenuItem(TAG_MAGENTA)]
        private static void TagMagenta() { Tag(FolderTags.Magenta);}

        // Type

        [MenuItem(TYPE_PREFABS)]
        private static void TypePrefabs() { AssingType(FolderTypes.Prefabs); }
        [MenuItem(TYPE_SCENES)]
        private static void TypeScenes() { AssingType(FolderTypes.Scenes); }
        [MenuItem(TYPE_SCRIPTS)]
        private static void TypeScripts() { AssingType(FolderTypes.Scripts); }
        [MenuItem(TYPE_EXTENSIONS)]
        private static void TypeExtensions() { AssingType(FolderTypes.Extensions); }
        [MenuItem(TYPE_PLUGINS)]
        private static void TypePlugins() { AssingType(FolderTypes.Plugins); }
        [MenuItem(TYPE_TEXTURES)]
        private static void TypeTextures() { AssingType(FolderTypes.Textures); }
        [MenuItem(TYPE_MATERIALS)]
        private static void TypeMaterials() { AssingType(FolderTypes.Materials); }
        [MenuItem(TYPE_AUDIO)]
        private static void TypeAudio() { AssingType(FolderTypes.Audio); }
        [MenuItem(TYPE_BRACKETS)]
        private static void TypeBrackets() { AssingType(FolderTypes.Brackets); }
        [MenuItem(TYPE_FONTS)]
        private static void TypeFonts() { AssingType(FolderTypes.Fonts); }
        [MenuItem(TYPE_EDITOR)]
        private static void TypeEditor() { AssingType(FolderTypes.Editor); }
        [MenuItem(TYPE_RESOURCES)]
        private static void TypeResources() { AssingType(FolderTypes.Resources); }
        [MenuItem(TYPE_SHADERS)]
        private static void TypeShaders() { AssingType(FolderTypes.Shaders); }
        [MenuItem(TYPE_TERRAINS)]
        private static void TypeTerrains() { AssingType(FolderTypes.Terrains); }
        [MenuItem(TYPE_MESHES)]
        private static void TypeMeshes() { AssingType(FolderTypes.Meshes); }
        [MenuItem(TYPE_RAINBOW)]
        private static void TypeRainbow() { AssingType(FolderTypes.Rainbow); }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public static void RevertToDefault()
        {
            RevertSelectedFoldersToDefault();
        }

        public static void Tag(FolderTags tag)
        {
            var icons = FolderTagsStorage.Instance.GetIconsByTag(tag);
            ChangeSelectedFoldersIcons(icons);
        }

        public static void Colorize(FolderColors color)
        {
            var icons = FolderColorsStorage.Instance.GetIconsByColor(color);
            ChangeSelectedFoldersIcons(icons);
        }

        public static void AssingType(FolderTypes type)
        {
            var icons = FolderTypesStorage.Instance.GetIconsByType(type);
            ChangeSelectedFoldersIcons(icons);
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

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