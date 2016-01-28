# Unity3D Rainbow Folders

Have you ever thought about highlighting often used project folders? This simple but colorful asset allows you to do that!

With "Rainbow Folders" you can set custom icon for any folder in unity project browser.

##### Unity Free Look
![Browser window example](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/RainbowFolders/preview_rainbow_folders.png)
##### Unity Pro Look
![Browser window example PRO](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/RainbowFolders/preview_rainbow_folders_pro.png)

## Configuring folder icons

From the main menu select **Edit -> Rainbow Folders Settings**, then take a look at the Inspector.

There is reorderable list with few predefined "folder" items. You can modify existing items, remove them using "-" button or add new ones by clicking "+" button below.

![Rainbow folders inspector](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/RainbowFolders/rainbow_folders_inspector.png)


You can assign a custom icon to the folder using:
* Folder **Name** - icon will be applied to all folders with the same name
* or folder **Path** - icon will be applied to a single folder. The path format: `Assets/SomeFolder/YourFolder`

Then you need to scpecify actually icons:
* **Small Icon** - your custom icon for the left panel of the project browser (16x16 px)
* **Large Icon**  - your custom icon for the right panel of the project browser (64x64 px)

![Rainbow folders icons size](https://raw.githubusercontent.com/PhannGor/phanngor.github.io/master/RainbowFolders/rainbow_folders_icons_size.png)

Your changes will be applied next time when the project browser will retrieve the focus.
