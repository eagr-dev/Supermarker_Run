=== COMMIT: 11ee0d6 | Tue Sep 24 14:51:21 2024 -0600 | Initial commit ===
 .gitignore | 72 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 README.md  |  1 +
 2 files changed, 73 insertions(+)

=== COMMIT: ae77389 | Tue Sep 24 15:07:20 2024 -0600 | Inicio ===
 .gitignore                                         |  14 +-
 Supermarkert Run/.vsconfig                         |   6 +
 Supermarkert Run/Assets/Scenes.meta                |   8 +
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 267 +++++++
 .../Assets/Scenes/SampleScene.unity.meta           |   7 +
 Supermarkert Run/Assets/Scripts.meta               |   8 +
 Supermarkert Run/Assets/Scripts/Jugador.meta       |   8 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  18 +
 .../Assets/Scripts/Jugador/Player.cs.meta          |  11 +
 Supermarkert Run/Packages/manifest.json            |  41 ++
 Supermarkert Run/Packages/packages-lock.json       | 382 +++++++++++
 .../ProjectSettings/AudioManager.asset             |  19 +
 .../ProjectSettings/ClusterInputManager.asset      |   6 +
 .../ProjectSettings/DynamicsManager.asset          |  34 +
 .../ProjectSettings/EditorBuildSettings.asset      |   8 +
 .../ProjectSettings/EditorSettings.asset           |  30 +
 .../ProjectSettings/GraphicsSettings.asset         |  63 ++
 .../ProjectSettings/InputManager.asset             | 295 ++++++++
 .../ProjectSettings/MemorySettings.asset           |  35 +
 .../ProjectSettings/NavMeshAreas.asset             |  91 +++
 .../ProjectSettings/PackageManagerSettings.asset   |  35 +
 .../com.unity.testtools.codecoverage/Settings.json |   5 +
 .../ProjectSettings/Physics2DSettings.asset        |  56 ++
 .../ProjectSettings/PresetManager.asset            |   7 +
 .../ProjectSettings/ProjectSettings.asset          | 763 +++++++++++++++++++++
 .../ProjectSettings/ProjectVersion.txt             |   2 +
 .../ProjectSettings/QualitySettings.asset          | 232 +++++++
 Supermarkert Run/ProjectSettings/TagManager.asset  |  43 ++
 Supermarkert Run/ProjectSettings/TimeManager.asset |   9 +
 .../ProjectSettings/UnityConnectSettings.asset     |  36 +
 Supermarkert Run/ProjectSettings/VFXManager.asset  |  12 +
 .../ProjectSettings/VersionControlSettings.asset   |   8 +
 Supermarkert Run/ProjectSettings/XRSettings.asset  |  10 +
 33 files changed, 2562 insertions(+), 7 deletions(-)

=== COMMIT: 2e1c50e | Tue Sep 24 19:32:00 2024 -0600 | Creacion Player, Estante ===
 Supermarkert Run/Assets/Joystick Pack.meta         |    8 +
 .../Assets/Joystick Pack/Documentaion.pdf          |  Bin 0 -> 181873 bytes
 .../Assets/Joystick Pack/Documentaion.pdf.meta     |    7 +
 .../Assets/Joystick Pack/Examples.meta             |    9 +
 .../Joystick Pack/Examples/Example Scene.unity     | 4336 ++++++++++++++++++++
 .../Examples/Example Scene.unity.meta              |    7 +
 .../Assets/Joystick Pack/Examples/Ground.mat       |   77 +
 .../Assets/Joystick Pack/Examples/Ground.mat.meta  |    8 +
 .../Examples/JoystickPlayerExample.cs              |   16 +
 .../Examples/JoystickPlayerExample.cs.meta         |   11 +
 .../Examples/JoystickSetterExample.cs              |   66 +
 .../Examples/JoystickSetterExample.cs.meta         |   11 +
 .../Assets/Joystick Pack/Examples/Player.mat       |   77 +
 .../Assets/Joystick Pack/Examples/Player.mat.meta  |    8 +
 Supermarkert Run/Assets/Joystick Pack/Prefabs.meta |    9 +
 .../Joystick Pack/Prefabs/Dynamic Joystick.prefab  |  247 ++
 .../Prefabs/Dynamic Joystick.prefab.meta           |    7 +
 .../Joystick Pack/Prefabs/Fixed Joystick.prefab    |  168 +
 .../Prefabs/Fixed Joystick.prefab.meta             |    7 +
 .../Joystick Pack/Prefabs/Floating Joystick.prefab |  246 ++
 .../Prefabs/Floating Joystick.prefab.meta          |    7 +
 .../Joystick Pack/Prefabs/Variable Joystick.prefab |  248 ++
 .../Prefabs/Variable Joystick.prefab.meta          |    7 +
 Supermarkert Run/Assets/Joystick Pack/Scripts.meta |    9 +
 .../Assets/Joystick Pack/Scripts/Base.meta         |    9 +
 .../Assets/Joystick Pack/Scripts/Base/Joystick.cs  |  150 +
 .../Joystick Pack/Scripts/Base/Joystick.cs.meta    |   11 +
 .../Assets/Joystick Pack/Scripts/Editor.meta       |    8 +
 .../Scripts/Editor/DynamicJoystickEditor.cs        |   35 +
 .../Scripts/Editor/DynamicJoystickEditor.cs.meta   |   11 +
 .../Scripts/Editor/FloatingJoystickEditor.cs       |   21 +
 .../Scripts/Editor/FloatingJoystickEditor.cs.meta  |   11 +
 .../Joystick Pack/Scripts/Editor/JoystickEditor.cs |   64 +
 .../Scripts/Editor/JoystickEditor.cs.meta          |   11 +
 .../Scripts/Editor/VariableJoystickEditor.cs       |   37 +
 .../Scripts/Editor/VariableJoystickEditor.cs.meta  |   11 +
 .../Assets/Joystick Pack/Scripts/Joysticks.meta    |    9 +
 .../Scripts/Joysticks/DynamicJoystick.cs           |   41 +
 .../Scripts/Joysticks/DynamicJoystick.cs.meta      |   11 +
 .../Scripts/Joysticks/FixedJoystick.cs             |    8 +
 .../Scripts/Joysticks/FixedJoystick.cs.meta        |   11 +
 .../Scripts/Joysticks/FloatingJoystick.cs          |   26 +
 .../Scripts/Joysticks/FloatingJoystick.cs.meta     |   11 +
 .../Scripts/Joysticks/VariableJoystick.cs          |   63 +
 .../Scripts/Joysticks/VariableJoystick.cs.meta     |   11 +
 Supermarkert Run/Assets/Joystick Pack/Sprites.meta |    9 +
 .../Sprites/All Axis Backgrounds.meta              |    8 +
 .../All Axis Backgrounds/AllAxis_Outline.png       |  Bin 0 -> 10076 bytes
 .../All Axis Backgrounds/AllAxis_Outline.png.meta  |  166 +
 .../AllAxis_Outline_Arrows.png                     |  Bin 0 -> 11326 bytes
 .../AllAxis_Outline_Arrows.png.meta                |  166 +
 .../Sprites/All Axis Backgrounds/AllAxis_Plain.png |  Bin 0 -> 6774 bytes
 .../All Axis Backgrounds/AllAxis_Plain.png.meta    |  166 +
 .../All Axis Backgrounds/AllAxis_Plain_Arrows.png  |  Bin 0 -> 8488 bytes
 .../AllAxis_Plain_Arrows.png.meta                  |  166 +
 .../All Axis Backgrounds/AllAxis_Ridged.png        |  Bin 0 -> 23051 bytes
 .../All Axis Backgrounds/AllAxis_Ridged.png.meta   |  166 +
 .../All Axis Backgrounds/AllAxis_Ridged_Arrows.png |  Bin 0 -> 24356 bytes
 .../AllAxis_Ridged_Arrows.png.meta                 |  166 +
 .../Assets/Joystick Pack/Sprites/Handles.meta      |    8 +
 .../Sprites/Handles/Handle_Outline.png             |  Bin 0 -> 4763 bytes
 .../Sprites/Handles/Handle_Outline.png.meta        |  166 +
 .../Sprites/Handles/Handle_Outline_Arrows.png      |  Bin 0 -> 5447 bytes
 .../Sprites/Handles/Handle_Outline_Arrows.png.meta |  166 +
 .../Joystick Pack/Sprites/Handles/Handle_Plain.png |  Bin 0 -> 3178 bytes
 .../Sprites/Handles/Handle_Plain.png.meta          |  166 +
 .../Sprites/Handles/Handle_Plain_Arrows.png        |  Bin 0 -> 4187 bytes
 .../Sprites/Handles/Handle_Plain_Arrows.png.meta   |  166 +
 .../Sprites/Handles/Handle_Ridged.png              |  Bin 0 -> 8878 bytes
 .../Sprites/Handles/Handle_Ridged.png.meta         |  166 +
 .../Sprites/Handles/Handle_Ridged_Arrows.png       |  Bin 0 -> 10048 bytes
 .../Sprites/Handles/Handle_Ridged_Arrows.png.meta  |  166 +
 .../Sprites/Horizontal Backgrounds.meta            |    8 +
 .../Horizontal Backgrounds/Horizontal_Outline.png  |  Bin 0 -> 5496 bytes
 .../Horizontal_Outline.png.meta                    |  166 +
 .../Horizontal_Outline_Arrows.png                  |  Bin 0 -> 6131 bytes
 .../Horizontal_Outline_Arrows.png.meta             |  166 +
 .../Horizontal Backgrounds/Horizontal_Plain.png    |  Bin 0 -> 3939 bytes
 .../Horizontal_Plain.png.meta                      |  166 +
 .../Horizontal_Plain_Arrows.png                    |  Bin 0 -> 4801 bytes
 .../Horizontal_Plain_Arrows.png.meta               |  166 +
 .../Horizontal Backgrounds/Horizontal_Ridged.png   |  Bin 0 -> 10634 bytes
 .../Horizontal_Ridged.png.meta                     |  166 +
 .../Horizontal_Ridged_Arrows.png                   |  Bin 0 -> 11243 bytes
 .../Horizontal_Ridged_Arrows.png.meta              |  166 +
 .../Sprites/Vertical Backgrounds.meta              |    8 +
 .../Vertical Backgrounds/Vertical_Outline.png      |  Bin 0 -> 5367 bytes
 .../Vertical Backgrounds/Vertical_Outline.png.meta |  166 +
 .../Vertical_Outline_Arrows.png                    |  Bin 0 -> 5851 bytes
 .../Vertical_Outline_Arrows.png.meta               |  166 +
 .../Vertical Backgrounds/Vertical_Plain.png        |  Bin 0 -> 3792 bytes
 .../Vertical Backgrounds/Vertical_Plain.png.meta   |  166 +
 .../Vertical Backgrounds/Vertical_Plain_Arrows.png |  Bin 0 -> 4697 bytes
 .../Vertical_Plain_Arrows.png.meta                 |  166 +
 .../Vertical Backgrounds/Vertical_Ridged.png       |  Bin 0 -> 12445 bytes
 .../Vertical Backgrounds/Vertical_Ridged.png.meta  |  166 +
 .../Vertical_Ridged_Arrows.png                     |  Bin 0 -> 13111 bytes
 .../Vertical_Ridged_Arrows.png.meta                |  166 +
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 1112 ++++-
 .../Assets/Scripts/Car Supermarkert.meta           |    8 +
 .../Assets/Scripts/Car Supermarkert/Car.cs         |   18 +
 .../Assets/Scripts/Car Supermarkert/Car.cs.meta    |   11 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   42 +-
 Supermarkert Run/Assets/Scripts/estantes.meta      |    8 +
 .../Assets/Scripts/estantes/Estante.cs             |   15 +
 .../Assets/Scripts/estantes/Estante.cs.meta        |   11 +
 .../ProjectSettings/SceneTemplateSettings.json     |  121 +
 Supermarkert Run/ProjectSettings/TagManager.asset  |    3 +-
 108 files changed, 11515 insertions(+), 25 deletions(-)

=== COMMIT: 7d76cb5 | Wed Sep 25 10:13:31 2024 -0600 | Creacion de misiones, agregar assets(joystick, TMP_Pro ===
 Supermarkert Run/Assets/Scenes/SampleScene.unity   |  290 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   68 +
 .../Assets/Scripts/Jugador/Mision.cs.meta          |   11 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   12 +-
 .../Assets/Scripts/estantes/Estante.cs             |    2 +-
 Supermarkert Run/Assets/TextMesh Pro.meta          |    8 +
 .../Assets/TextMesh Pro/Documentation.meta         |    8 +
 .../Documentation/TextMesh Pro User Guide 2016.pdf |  Bin 0 -> 694398 bytes
 .../TextMesh Pro User Guide 2016.pdf.meta          |    7 +
 Supermarkert Run/Assets/TextMesh Pro/Fonts.meta    |    8 +
 .../TextMesh Pro/Fonts/LiberationSans - OFL.txt    |   46 +
 .../Fonts/LiberationSans - OFL.txt.meta            |    8 +
 .../Assets/TextMesh Pro/Fonts/LiberationSans.ttf   |  Bin 0 -> 350200 bytes
 .../TextMesh Pro/Fonts/LiberationSans.ttf.meta     |   19 +
 .../Assets/TextMesh Pro/Resources.meta             |    8 +
 .../TextMesh Pro/Resources/Fonts & Materials.meta  |    9 +
 .../LiberationSans SDF - Drop Shadow.mat           |  106 +
 .../LiberationSans SDF - Drop Shadow.mat.meta      |    8 +
 .../LiberationSans SDF - Fallback.asset            |  343 +
 .../LiberationSans SDF - Fallback.asset.meta       |    8 +
 .../LiberationSans SDF - Outline.mat               |  104 +
 .../LiberationSans SDF - Outline.mat.meta          |    8 +
 .../Fonts & Materials/LiberationSans SDF.asset     | 7821 ++++++++++++++++++++
 .../LiberationSans SDF.asset.meta                  |    8 +
 .../LineBreaking Following Characters.txt          |    1 +
 .../LineBreaking Following Characters.txt.meta     |    8 +
 .../Resources/LineBreaking Leading Characters.txt  |    1 +
 .../LineBreaking Leading Characters.txt.meta       |    8 +
 .../TextMesh Pro/Resources/Sprite Assets.meta      |    9 +
 .../Resources/Sprite Assets/EmojiOne.asset         |  659 ++
 .../Resources/Sprite Assets/EmojiOne.asset.meta    |    8 +
 .../TextMesh Pro/Resources/Style Sheets.meta       |    9 +
 .../Style Sheets/Default Style Sheet.asset         |   68 +
 .../Style Sheets/Default Style Sheet.asset.meta    |    8 +
 .../TextMesh Pro/Resources/TMP Settings.asset      |   46 +
 .../TextMesh Pro/Resources/TMP Settings.asset.meta |    8 +
 Supermarkert Run/Assets/TextMesh Pro/Shaders.meta  |    8 +
 .../Shaders/TMP_Bitmap-Custom-Atlas.shader         |  143 +
 .../Shaders/TMP_Bitmap-Custom-Atlas.shader.meta    |    9 +
 .../TextMesh Pro/Shaders/TMP_Bitmap-Mobile.shader  |  145 +
 .../Shaders/TMP_Bitmap-Mobile.shader.meta          |    9 +
 .../Assets/TextMesh Pro/Shaders/TMP_Bitmap.shader  |  143 +
 .../TextMesh Pro/Shaders/TMP_Bitmap.shader.meta    |    9 +
 .../TextMesh Pro/Shaders/TMP_SDF Overlay.shader    |  317 +
 .../Shaders/TMP_SDF Overlay.shader.meta            |    9 +
 .../Assets/TextMesh Pro/Shaders/TMP_SDF SSD.shader |  310 +
 .../TextMesh Pro/Shaders/TMP_SDF SSD.shader.meta   |    9 +
 .../Shaders/TMP_SDF-Mobile Masking.shader          |  247 +
 .../Shaders/TMP_SDF-Mobile Masking.shader.meta     |    9 +
 .../Shaders/TMP_SDF-Mobile Overlay.shader          |  240 +
 .../Shaders/TMP_SDF-Mobile Overlay.shader.meta     |    9 +
 .../TextMesh Pro/Shaders/TMP_SDF-Mobile SSD.shader |  106 +
 .../Shaders/TMP_SDF-Mobile SSD.shader.meta         |    9 +
 .../TextMesh Pro/Shaders/TMP_SDF-Mobile.shader     |  240 +
 .../Shaders/TMP_SDF-Mobile.shader.meta             |    9 +
 .../Shaders/TMP_SDF-Surface-Mobile.shader          |  138 +
 .../Shaders/TMP_SDF-Surface-Mobile.shader.meta     |    9 +
 .../TextMesh Pro/Shaders/TMP_SDF-Surface.shader    |  158 +
 .../Shaders/TMP_SDF-Surface.shader.meta            |    9 +
 .../Assets/TextMesh Pro/Shaders/TMP_SDF.shader     |  317 +
 .../TextMesh Pro/Shaders/TMP_SDF.shader.meta       |    9 +
 .../Assets/TextMesh Pro/Shaders/TMP_Sprite.shader  |  116 +
 .../TextMesh Pro/Shaders/TMP_Sprite.shader.meta    |    9 +
 .../Assets/TextMesh Pro/Shaders/TMPro.cginc        |   84 +
 .../Assets/TextMesh Pro/Shaders/TMPro.cginc.meta   |    9 +
 .../Assets/TextMesh Pro/Shaders/TMPro_Mobile.cginc |  157 +
 .../TextMesh Pro/Shaders/TMPro_Mobile.cginc.meta   |    9 +
 .../TextMesh Pro/Shaders/TMPro_Properties.cginc    |   85 +
 .../Shaders/TMPro_Properties.cginc.meta            |    9 +
 .../TextMesh Pro/Shaders/TMPro_Surface.cginc       |  101 +
 .../TextMesh Pro/Shaders/TMPro_Surface.cginc.meta  |    9 +
 Supermarkert Run/Assets/TextMesh Pro/Sprites.meta  |    8 +
 .../TextMesh Pro/Sprites/EmojiOne Attribution.txt  |    3 +
 .../Sprites/EmojiOne Attribution.txt.meta          |    7 +
 .../Assets/TextMesh Pro/Sprites/EmojiOne.json      |  156 +
 .../Assets/TextMesh Pro/Sprites/EmojiOne.json.meta |    8 +
 .../Assets/TextMesh Pro/Sprites/EmojiOne.png       |  Bin 0 -> 112319 bytes
 .../Assets/TextMesh Pro/Sprites/EmojiOne.png.meta  |  431 ++
 78 files changed, 13558 insertions(+), 6 deletions(-)

=== COMMIT: 5758df7 | Wed Sep 25 13:19:32 2024 -0600 | Creacion Aleatoria de estantes y areas ===
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 1426 ++++++++++++++++++--
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   39 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    5 +-
 Supermarkert Run/Assets/Scripts/estantes/Area.cs   |   47 +
 .../Assets/Scripts/estantes/Area.cs.meta           |   11 +
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |   60 +
 .../Assets/Scripts/estantes/Areas.cs.meta          |   11 +
 .../Assets/Scripts/estantes/Estante.cs             |   14 +-
 .../ProjectSettings/EditorSettings.asset           |   29 +-
 .../ProjectSettings/TimelineSettings.asset         |   16 +
 10 files changed, 1515 insertions(+), 143 deletions(-)

=== COMMIT: 84163f6 | Wed Sep 25 13:43:36 2024 -0600 | Pruebas de areas ===
 Supermarkert Run/Assets/Scenes/SampleScene.unity  | 8464 ++++++++++++++++++---
 Supermarkert Run/Assets/Scripts/estantes/Area.cs  |   11 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs |    1 -
 3 files changed, 7455 insertions(+), 1021 deletions(-)

=== COMMIT: 052b18b | Wed Sep 25 16:55:54 2024 -0600 | Arreglo de bug de repeticion ===
 Supermarkert Run/Assets/Scripts/estantes/Area.cs  | 54 ++++++++++++----------
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs | 55 ++++++++++++-----------
 2 files changed, 60 insertions(+), 49 deletions(-)

=== COMMIT: 89d7187 | Thu Sep 26 13:03:57 2024 -0600 | Termino caracteristicas Carrito ===
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 25 +++++++++++++----
 .../Assets/Scripts/Car Supermarkert/Car.cs         | 22 +++++++--------
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |  9 +++++++
 .../Car Supermarkert/Get_Content_Car.cs.meta       | 11 ++++++++
 .../Assets/Scripts/Car Supermarkert/Liviano.asset  | 21 +++++++++++++++
 .../Scripts/Car Supermarkert/Liviano.asset.meta    |  8 ++++++
 .../Assets/Scripts/Car Supermarkert/Pesado.asset   | 22 +++++++++++++++
 .../Scripts/Car Supermarkert/Pesado.asset.meta     |  8 ++++++
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |  1 -
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  | 31 +++++++++++++++++++---
 10 files changed, 138 insertions(+), 20 deletions(-)

=== COMMIT: 20009ce | Thu Sep 26 15:13:54 2024 -0600 | Poder hacer varias versiones y varias skins ===
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 352 ++++++++++++++++++++-
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |  14 +-
 .../Assets/Scripts/Car Supermarkert/Liviano.asset  |   2 +-
 .../Assets/Scripts/Car Supermarkert/Mediano.asset  |  21 ++
 .../Scripts/Car Supermarkert/Mediano.asset.meta    |   8 +
 .../Assets/Scripts/Car Supermarkert/Pesado.asset   |   4 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  38 ++-
 .../Assets/Scripts/Jugador/Seleccion_Carrito.cs    |  37 +++
 .../Scripts/Jugador/Seleccion_Carrito.cs.meta      |  11 +
 Supermarkert Run/Assets/textures.meta              |   8 +
 Supermarkert Run/Assets/textures/Carritos.meta     |   8 +
 .../Assets/textures/Carritos/Grande.meta           |   8 +
 .../Assets/textures/Carritos/Mediano.meta          |   8 +
 .../Assets/textures/Carritos/Pequenio.meta         |   8 +
 .../Assets/textures/Carritos/Pequenio/chica.mat    |  83 +++++
 .../textures/Carritos/Pequenio/chica.mat.meta      |   8 +
 .../Assets/textures/Carritos/Pequenio/reja.png     | Bin 0 -> 26868 bytes
 .../textures/Carritos/Pequenio/reja.png.meta       | 127 ++++++++
 .../Assets/textures/Carritos/Pequenio/reja2.jpg    | Bin 0 -> 27139 bytes
 .../textures/Carritos/Pequenio/reja2.jpg.meta      | 127 ++++++++
 Supermarkert Run/Assets/textures/Estantes.meta     |   8 +
 Supermarkert Run/Assets/textures/Objetos.meta      |   8 +
 Supermarkert Run/Assets/textures/Supermercado.meta |   8 +
 23 files changed, 877 insertions(+), 19 deletions(-)

=== COMMIT: 15ccd2d | Thu Sep 26 18:15:33 2024 -0600 | Creacion y termino de power ups ===
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 93 +++++++++++++++++++++-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  | 44 +++++++++-
 Supermarkert Run/Assets/Scripts/PowerUp.meta       |  8 ++
 .../Assets/Scripts/PowerUp/Interfaz_PowerUp.cs     | 13 +++
 .../Scripts/PowerUp/Interfaz_PowerUp.cs.meta       | 11 +++
 .../Assets/Scripts/PowerUp/Proteccion.cs           | 23 ++++++
 .../Assets/Scripts/PowerUp/Proteccion.cs.meta      | 11 +++
 .../Assets/Scripts/PowerUp/Repartir_power.cs       | 31 ++++++++
 .../Assets/Scripts/PowerUp/Repartir_power.cs.meta  | 11 +++
 .../Assets/Scripts/PowerUp/Velocidad.cs            | 28 +++++++
 .../Assets/Scripts/PowerUp/Velocidad.cs.meta       | 11 +++
 .../Assets/Scripts/PowerUp/Vida_extra.cs           | 30 +++++++
 .../Assets/Scripts/PowerUp/Vida_extra.cs.meta      | 11 +++
 Supermarkert Run/ProjectSettings/TagManager.asset  |  1 +
 14 files changed, 323 insertions(+), 3 deletions(-)

=== COMMIT: 1e2c16e | Mon Sep 30 11:16:30 2024 -0600 | Creacion de tiempo y Nivel ===
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 209 +++++++++++++++++++++
 .../Assets/Scripts/Car Supermarkert/Car.cs         |   2 +
 Supermarkert Run/Assets/Scripts/Juego.meta         |   8 +
 Supermarkert Run/Assets/Scripts/Juego/Escenas.meta |   8 +
 .../Assets/Scripts/Juego/Gameplay.meta             |   8 +
 .../Assets/Scripts/Juego/Gameplay/Nivel.cs         |   9 +
 .../Assets/Scripts/Juego/Gameplay/Nivel.cs.meta    |  11 ++
 .../Assets/Scripts/Juego/Gameplay/Tiempo.cs        |  47 +++++
 .../Assets/Scripts/Juego/Gameplay/Tiempo.cs.meta   |  11 ++
 Supermarkert Run/Assets/Scripts/Jugador/DINERO.cs  |  26 +++
 .../Assets/Scripts/Jugador/DINERO.cs.meta          |  11 ++
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   6 +-
 12 files changed, 354 insertions(+), 2 deletions(-)

=== COMMIT: 6c49f53 | Mon Sep 30 13:48:36 2024 -0600 | Caja ===
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 1363 +++++++++++++++++---
 Supermarkert Run/Assets/Scripts/Caja.meta          |    8 +
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |   17 +
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs.meta  |   11 +
 .../Assets/Scripts/Juego/Gameplay/Nivel.cs         |    1 -
 .../Assets/Scripts/Juego/Gameplay/Tiempo.cs        |   40 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   15 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   10 +-
 Supermarkert Run/Assets/Scripts/estantes/Area.cs   |    2 +-
 .../Assets/Scripts/estantes/Estante.cs             |    2 +-
 Supermarkert Run/ProjectSettings/TagManager.asset  |    1 +
 11 files changed, 1295 insertions(+), 175 deletions(-)

=== COMMIT: 6136739 | Mon Sep 30 14:55:12 2024 -0600 | Inicio de Menu principal ===
 .../Assets/Scenes/Menu_principal.unity             | 3361 ++++++++++++++++++++
 .../Assets/Scenes/Menu_principal.unity.meta        |    7 +
 Supermarkert Run/Assets/Scenes/SampleScene.unity   |  760 ++++-
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |    5 +-
 .../Scripts/Juego/{Escenas.meta => Menu.meta}      |    2 +-
 .../Assets/Scripts/Juego/Menu/PowerUP.meta         |    8 +
 .../Assets/Scripts/Juego/Menu/PowerUP/Slider.cs    |   12 +
 .../Scripts/Juego/Menu/PowerUP/Slider.cs.meta      |   11 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   32 +-
 .../ProjectSettings/EditorBuildSettings.asset      |    8 +-
 .../ProjectSettings/QualitySettings.asset          |  122 +-
 11 files changed, 4297 insertions(+), 31 deletions(-)

=== COMMIT: ade479e | Mon Sep 30 18:40:15 2024 -0600 | Menu de inicio arreglar bugs ===
 Supermarkert Run/Assets/Objetos.meta               |    8 +
 Supermarkert Run/Assets/Objetos/Jugador.prefab     |  531 +++++
 .../Assets/Objetos/Jugador.prefab.meta             |    7 +
 Supermarkert Run/Assets/Objetos/Power.prefab       |   92 +
 Supermarkert Run/Assets/Objetos/Power.prefab.meta  |    7 +
 Supermarkert Run/Assets/Objetos/carrito.obj        |  782 ++++++++
 Supermarkert Run/Assets/Objetos/carrito.obj.meta   |  109 +
 Supermarkert Run/Assets/Objetos/personajeDemo.obj  | 2112 ++++++++++++++++++++
 .../Assets/Objetos/personajeDemo.obj.meta          |  109 +
 .../Assets/Scenes/Menu_principal.unity             | 1517 +++++++++++++-
 Supermarkert Run/Assets/Scenes/SampleScene.unity   |  857 ++------
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |   20 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |   49 +
 .../Assets/Scripts/Juego/Menu/Seleccion.cs.meta    |   11 +
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   21 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   33 +-
 .../Assets/Scripts/Jugador/Seleccion_Carrito.cs    |   41 +-
 17 files changed, 5482 insertions(+), 824 deletions(-)

=== COMMIT: 33c172a | Tue Oct 1 14:36:37 2024 -0600 | Arreglo de bugs del menu->Juego ===
 .../Assets/Scenes/Menu_principal.unity             | 802 ++++++++++++++-------
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 168 ++++-
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |  17 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |  15 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  14 +-
 .../Assets/Scripts/Jugador/Seleccion_Carrito.cs    |  35 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |  53 ++
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs.meta |  11 +
 .../Assets/Scripts/PowerUp/Repartir_power.cs       |  14 +
 9 files changed, 788 insertions(+), 341 deletions(-)

=== COMMIT: fda4c6a | Thu Oct 3 20:28:33 2024 -0600 | Arreglo bug de power, inicio de menu power ===
 .../Assets/Scenes/Menu_principal.unity             | 849 +++++++++++++++++----
 Supermarkert Run/Assets/Scenes/SampleScene.unity   |  58 --
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |  44 ++
 .../{Slider.cs.meta => Seleccion_PU.cs.meta}       |   2 +-
 .../Assets/Scripts/Juego/Menu/PowerUP/Slider.cs    |  12 -
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  12 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   3 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |  13 +-
 .../Assets/Scripts/PowerUp/Interfaz_PowerUp.cs     |   2 +
 .../Assets/Scripts/PowerUp/Proteccion.cs           |   8 +
 .../Assets/Scripts/PowerUp/Repartir_power.cs       |   8 +-
 .../Assets/Scripts/PowerUp/Velocidad.cs            |   8 +
 .../Assets/Scripts/PowerUp/Vida_extra.cs           |  12 +-
 13 files changed, 818 insertions(+), 213 deletions(-)

=== COMMIT: 0789171 | Thu Oct 3 21:14:26 2024 -0600 | Termino menu power up y toma de power up ===
 .../Assets/Scenes/Menu_principal.unity             | 283 ++++++++++++++++-
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |  13 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   6 +-
 .../Assets/Scripts/PowerUp/Interfaz_PowerUp.cs     |   3 +-
 .../Assets/Scripts/PowerUp/Proteccion.cs           |   4 +-
 .../Assets/Scripts/PowerUp/Repartir_power.cs       |   4 +-
 .../Assets/Scripts/PowerUp/Velocidad.cs            |   4 +-
 .../Assets/Scripts/PowerUp/Vida_extra.cs           |   4 +-
 .../LiberationSans SDF - Fallback.asset            | 338 ++++++++++++++++++++-
 9 files changed, 626 insertions(+), 33 deletions(-)

=== COMMIT: 8458955 | Fri Oct 4 15:10:04 2024 -0600 | Sistema de skins creado ===
 .../Assets/Scenes/Menu_principal.unity             | 5629 ++++++++++++++------
 Supermarkert Run/Assets/Scenes/SampleScene.unity   |   55 +
 .../Assets/Scripts/Car Supermarkert/Car.cs         |    2 +-
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |   16 +-
 .../Assets/Scripts/Car Supermarkert/Liviano.meta   |    8 +
 .../Car Supermarkert/{ => Liviano}/Liviano.asset   |    2 +
 .../{ => Liviano}/Liviano.asset.meta               |    0
 .../Car Supermarkert/Liviano/Liviano2.asset        |   23 +
 .../Car Supermarkert/Liviano/Liviano2.asset.meta   |    8 +
 .../Assets/Scripts/Car Supermarkert/Mediano.meta   |    8 +
 .../Car Supermarkert/{ => Mediano}/Mediano.asset   |    6 +-
 .../{ => Mediano}/Mediano.asset.meta               |    0
 .../Car Supermarkert/Mediano/Mediano2.asset        |   23 +
 .../Car Supermarkert/Mediano/Mediano2.asset.meta   |    8 +
 .../Assets/Scripts/Car Supermarkert/Pesado.meta    |    8 +
 .../Car Supermarkert/{ => Pesado}/Pesado.asset     |    2 +
 .../{ => Pesado}/Pesado.asset.meta                 |    0
 .../Scripts/Car Supermarkert/Pesado/Pesado2.asset  |   24 +
 .../Car Supermarkert/Pesado/Pesado2.asset.meta     |    8 +
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |    6 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |   71 +-
 21 files changed, 4188 insertions(+), 1719 deletions(-)

=== COMMIT: 7dc0210 | Fri Oct 4 18:46:28 2024 -0600 | Arreglo de unos bugs, Resbalon ===
 Supermarkert Run/Assets/Objetos/Ganar.prefab       |  371 ++++
 Supermarkert Run/Assets/Objetos/Ganar.prefab.meta  |    7 +
 Supermarkert Run/Assets/Objetos/Muerte.prefab      |  371 ++++
 Supermarkert Run/Assets/Objetos/Muerte.prefab.meta |    7 +
 Supermarkert Run/Assets/Objetos/UI.prefab          |  700 +++++++
 Supermarkert Run/Assets/Objetos/UI.prefab.meta     |    7 +
 Supermarkert Run/Assets/Objetos/estanteria.obj     | 1541 ++++++++++++++++
 .../Assets/Objetos/estanteria.obj.meta             |  109 ++
 .../Assets/Scenes/Menu_principal.unity             |   45 +
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 1911 +++++---------------
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |    3 +-
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs      |   35 +
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs.meta |   11 +
 .../Juego/Gameplay/Pase_Conexion_Menu_Gameplay.cs  |   29 +
 .../Gameplay/Pase_Conexion_Menu_Gameplay.cs.meta   |   11 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   49 +-
 .../Assets/Scripts/Jugador/Seleccion_Carrito.cs    |    3 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |   19 +-
 Supermarkert Run/ProjectSettings/TagManager.asset  |    1 +
 19 files changed, 3746 insertions(+), 1484 deletions(-)

=== COMMIT: 26a67aa | Mon Oct 7 15:31:22 2024 -0600 | Nav mesh, optimizaciones ===
 .../Assets/Scenes/Menu_principal.unity             |  18 +-
 Supermarkert Run/Assets/Scenes/SampleScene.meta    |   8 +
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 838 ++++++++++++++++++++-
 .../SampleScene/NavMesh-NavMesh Surface.asset      | Bin 0 -> 49812 bytes
 .../SampleScene/NavMesh-NavMesh Surface.asset.meta |   8 +
 Supermarkert Run/Assets/Scripts/AI.meta            |   8 +
 Supermarkert Run/Assets/Scripts/AI/IA.cs           |  38 +
 Supermarkert Run/Assets/Scripts/AI/IA.cs.meta      |  11 +
 .../Assets/Scripts/AI/Seleccion_Carrito_Ai.cs      |  17 +
 .../Assets/Scripts/AI/Seleccion_Carrito_Ai.cs.meta |  11 +
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |  10 +-
 .../Juego/Gameplay/Pase_Conexion_Menu_Gameplay.cs  |  36 +-
 .../Assets/Scripts/Jugador/Seleccion_Carrito.cs    |  15 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |  10 +-
 Supermarkert Run/Packages/manifest.json            |   1 +
 Supermarkert Run/Packages/packages-lock.json       |   9 +
 .../ProjectSettings/NavMeshAreas.asset             |   8 +-
 17 files changed, 994 insertions(+), 52 deletions(-)

=== COMMIT: d1da7ce | Mon Oct 7 16:32:14 2024 -0600 | Correccion de bugs -cambio de carro al jugar,-skins ===
 Supermarkert Run/Assets/Scenes/Menu_principal.unity    |   3 +++
 Supermarkert Run/Assets/Scenes/SampleScene.unity       |  11 +++++++++++
 .../Assets/Scripts/Car Supermarkert/Get_Content_Car.cs |   6 +++---
 .../Assets/Scripts/Juego/Menu/Seleccion.cs             |   1 +
 .../Assets/Scripts/Jugador/Seleccion_Menu_Carrito.cs   |  14 ++++++++++++--
 .../Temp/FSTimeGet-618be530a7bff924caa14caf208e6a0d    |   0
 Supermarkert Run/Temp/UnityLockfile                    |   0
 Supermarkert Run/Temp/__Backupscenes/0.backup          | Bin 0 -> 143116 bytes
 Supermarkert Run/Temp/workerlic                        | Bin 0 -> 1014 bytes
 9 files changed, 30 insertions(+), 5 deletions(-)

=== COMMIT: 45eedcd | Mon Oct 7 20:20:45 2024 -0600 | Arreglo de bugs-Caja,-Tiempo-intentar arreglar bug de los estantes ===
 .../Assets/Scenes/Menu_principal.unity             | 561 ++++++++++++++-
 Supermarkert Run/Assets/Scenes/SampleScene.unity   | 783 ++++++++++++++++++++-
 .../Assets/Scripts/AI/Seleccion_Carrito_Ai.cs      |   7 +-
 .../Assets/Scripts/Car Supermarkert/Car.cs         |   1 +
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |   2 +
 .../Scripts/Car Supermarkert/Liviano/Liviano.asset |   2 +-
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs      |   1 +
 .../Juego/Gameplay/Pase_Conexion_Menu_Gameplay.cs  |   7 +
 .../Assets/Scripts/Juego/Gameplay/Tiempo.cs        |   3 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |  42 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   3 +-
 .../Assets/Scripts/Jugador/Seleccion_Carrito.cs    |   2 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |  59 ++
 Supermarkert Run/Assets/Scripts/estantes/Area.cs   |   2 +-
 .../FSTimeGet-618be530a7bff924caa14caf208e6a0d     |   0
 Supermarkert Run/Temp/UnityLockfile                |   0
 Supermarkert Run/Temp/__Backupscenes/0.backup      | Bin 143116 -> 0 bytes
 Supermarkert Run/Temp/workerlic                    | Bin 1014 -> 0 bytes
 18 files changed, 1456 insertions(+), 19 deletions(-)

=== COMMIT: 7514f73 | Tue Oct 8 11:49:22 2024 -0600 | Arreglo de bug,-estantes no tomando sus objetos.-compra ===
 Supermarkert Run/Assets/Scenes/Menu_principal.unity     |  2 ++
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs            |  1 -
 .../Scripts/Car Supermarkert/Liviano/Liviano.asset      |  3 ++-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs       |  6 +++---
 .../Assets/Scripts/Jugador/Seleccion_Menu_Carrito.cs    | 17 +++++++++++++++--
 Supermarkert Run/Assets/Scripts/estantes/Area.cs        |  5 ++---
 Supermarkert Run/Assets/Scripts/estantes/Estante.cs     |  6 ++++--
 7 files changed, 28 insertions(+), 12 deletions(-)

=== COMMIT: 0d61f39 | Tue Oct 8 15:41:41 2024 -0600 | Arreglo de bugs de compra, sistema de mapa, y requisitos de vehiculos, optmizar la obtencion de dinero ===
 Supermarkert Run/Assets/Objetos/Jugador.prefab     |   34 +-
 .../Assets/Scenes/Menu_principal.unity             | 5239 +++++++++++++-------
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |    3 +-
 .../Assets/Scripts/Car Supermarkert/Car.cs         |   15 +-
 .../Scripts/Car Supermarkert/Liviano/Liviano.asset |    6 +-
 .../Car Supermarkert/Liviano/Liviano2.asset        |    5 +-
 .../Scripts/Car Supermarkert/Mediano/Mediano.asset |    5 +-
 .../Car Supermarkert/Mediano/Mediano2.asset        |    5 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado.asset   |    5 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado2.asset  |    5 +-
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs      |   21 +-
 Supermarkert Run/Assets/Scripts/Juego/Mapa.meta    |    8 +
 Supermarkert Run/Assets/Scripts/Juego/Mapa/Mapa.cs |   16 +
 .../Assets/Scripts/Juego/Mapa/Mapa.cs.meta         |   11 +
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |   21 +
 .../Scripts/Juego/Mapa/Mapa_Grande.asset.meta      |    8 +
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |   21 +
 .../Scripts/Juego/Mapa/Mapa_Mediano.asset.meta     |    8 +
 .../Scripts/Juego/Mapa/Mapa_peque\303\261o.asset"  |   21 +
 .../Juego/Mapa/Mapa_peque\303\261o.asset.meta"     |    8 +
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |   91 +
 .../Scripts/Juego/Mapa/Seleccion_Mapa.cs.meta      |   11 +
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |    3 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    3 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |   14 +-
 25 files changed, 3859 insertions(+), 1728 deletions(-)

=== COMMIT: 30bfda4 | Tue Oct 8 17:34:39 2024 -0600 | Sistema de guardado ===
 .../Assets/Scenes/Menu_principal.unity             | 200 ++++++++++++++++++++-
 Supermarkert Run/Assets/Scenes/SampleScene.unity   |   3 +-
 .../Assets/Scripts/Juego/Gameplay/Contenido.cs     |  10 ++
 .../Scripts/Juego/Gameplay/Contenido.cs.meta       |  11 ++
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |  55 ++++++
 .../Juego/Gameplay/Sistema_Guardado.cs.meta        |  11 ++
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |   2 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |   7 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   1 +
 Supermarkert Run/Assets/datos.json                 |   1 +
 Supermarkert Run/Assets/datos.json.meta            |   7 +
 11 files changed, 305 insertions(+), 3 deletions(-)

=== COMMIT: 53755e7 | Wed Oct 9 13:21:52 2024 -0600 | creacion de mapa pequeño ===
 Supermarkert Run/Assets/Objetos/Fila.prefab        | 1876 ++++++
 Supermarkert Run/Assets/Objetos/Fila.prefab.meta   |    7 +
 .../Assets/Scenes/Mapa peque\303\261o.meta"        |    8 +
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 6186 ++++++++++++++++++++
 .../Assets/Scenes/Mapa peque\303\261o.unity.meta"  |    7 +
 .../NavMesh-NavMesh Surface.asset"                 |  Bin 0 -> 14984 bytes
 .../NavMesh-NavMesh Surface.asset.meta"            |    8 +
 .../SampleScene/NavMesh-NavMesh Surface.asset      |  Bin 49812 -> 50776 bytes
 8 files changed, 8092 insertions(+)

=== COMMIT: 24f1b18 | Thu Oct 10 13:23:42 2024 -0600 | Agregar sonido, y obstaculos ===
 .../Assets/Objetos/Fila2 Variant.prefab            |  255 +++
 .../Assets/Objetos/Fila2 Variant.prefab.meta       |    7 +
 .../Assets/Objetos/Fila3 Variant.prefab            |  399 ++++
 .../Assets/Objetos/Fila3 Variant.prefab.meta       |    7 +
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 1953 +++++++++-----------
 Supermarkert Run/Assets/Scenes/SampleScene.unity   |  293 ++-
 Supermarkert Run/Assets/Scripts/AI/IA.cs           |   20 +-
 .../Assets/Scripts/AI/Seleccion_Carrito_Ai.cs      |    1 -
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |    9 +-
 Supermarkert Run/Assets/Scripts/Juego/Mapa/Mapa.cs |    1 +
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |   39 +
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs.meta   |   11 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    2 +-
 Supermarkert Run/Assets/Sonidos.meta               |    8 +
 ...WhatsApp-Audio-2024-10-09-at-8 (mp3cut.net).wav |  Bin 0 -> 5497018 bytes
 ...App-Audio-2024-10-09-at-8 (mp3cut.net).wav.meta |   23 +
 .../WhatsApp-Audio-2024-10-09-at-8.47.38-PM.wav    |  Bin 0 -> 16338042 bytes
 ...hatsApp-Audio-2024-10-09-at-8.47.38-PM.wav.meta |   23 +
 .../WhatsApp-Audio-2024-10-09-at-8.47.53-PM.wav    |  Bin 0 -> 5960822 bytes
 ...hatsApp-Audio-2024-10-09-at-8.47.53-PM.wav.meta |   23 +
 .../WhatsApp-Audio-2024-10-09-at-8.48.03-PM.wav    |  Bin 0 -> 772244 bytes
 ...hatsApp-Audio-2024-10-09-at-8.48.03-PM.wav.meta |   23 +
 22 files changed, 1973 insertions(+), 1124 deletions(-)

=== COMMIT: ac18447 | Thu Oct 10 14:00:43 2024 -0600 | Creacion de mapa Mediano ===
 Supermarkert Run/Assets/Scenes/Mapa mediano.meta   |    8 +
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 7273 ++++++++++++++++++++
 .../Assets/Scenes/Mapa mediano.unity.meta          |    7 +
 .../Mapa mediano/NavMesh-NavMesh Surface.asset     |  Bin 0 -> 36416 bytes
 .../NavMesh-NavMesh Surface.asset.meta             |    8 +
 Supermarkert Run/Assets/Scenes/SampleScene.unity   |   82 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |    6 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    2 +-
 8 files changed, 7326 insertions(+), 60 deletions(-)

=== COMMIT: 7acc04f | Thu Oct 10 15:18:32 2024 -0600 | Creacion de mapa grande ===
 Supermarkert Run/Assets/Scenes/Mapa grande.meta    |     8 +
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 13807 +++++++++++++++++++
 .../Assets/Scenes/Mapa grande.unity.meta           |     7 +
 .../Mapa grande/NavMesh-NavMesh Surface.asset      |   Bin 0 -> 83780 bytes
 .../Mapa grande/NavMesh-NavMesh Surface.asset.meta |     8 +
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |     4 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |    10 +-
 .../ProjectSettings/EditorBuildSettings.asset      |     9 +
 8 files changed, 13846 insertions(+), 7 deletions(-)

=== COMMIT: ea835a7 | Mon Oct 14 14:23:27 2024 -0600 | Personalizacion ===
 .../Assets/Scenes/Menu_principal.unity             | 8474 +++++++++++++++-----
 .../Assets/Scripts/Car Supermarkert/Car.cs         |    5 +
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |    1 -
 .../Scripts/Car Supermarkert/Liviano/Liviano.asset |    6 +-
 .../Liviano/Liviano_Personalzado.asset             |   30 +
 .../Liviano/Liviano_Personalzado.asset.meta        |    8 +
 .../Car Supermarkert/Mediano/Mediano2.asset        |    6 +-
 .../Mediano/Mediano_personalizado.asset            |   30 +
 .../Mediano/Mediano_personalizado.asset.meta       |    8 +
 .../Scripts/Car Supermarkert/Personalizacion.cs    |   84 +
 .../Car Supermarkert/Personalizacion.cs.meta       |   11 +
 .../Scripts/Car Supermarkert/Pesado/Pesado.asset   |    6 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado2.asset  |    6 +-
 .../Pesado/Pesado_personalizado.asset              |   30 +
 .../Pesado/Pesado_personalizado.asset.meta         |    8 +
 .../Assets/Scripts/Juego/Gameplay/Contenido.cs     |    3 +
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   16 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |   16 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |   30 +-
 Supermarkert Run/Assets/datos.json                 |    2 +-
 20 files changed, 6570 insertions(+), 2210 deletions(-)

=== COMMIT: d8c33f3 | Mon Oct 14 15:37:06 2024 -0600 | Arreglar bugs de la eleccion de textura ===
 Supermarkert Run/Assets/Scripts/AI/IA.cs              |  3 ++-
 .../Scripts/Car Supermarkert/Liviano/Liviano2.asset   |  6 +++++-
 .../Liviano/Liviano_Personalzado.asset                | 10 +++++-----
 .../Mediano/Mediano_personalizado.asset               |  2 +-
 .../Scripts/Car Supermarkert/Personalizacion.cs       | 16 +++++++---------
 .../Pesado/Pesado_personalizado.asset                 |  2 +-
 .../Assets/Scripts/Juego/Gameplay/Sistema_Guardado.cs | 11 +++++++----
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs           |  3 ++-
 .../Assets/Scripts/Jugador/Seleccion_Menu_Carrito.cs  | 19 +++++++++++++++----
 Supermarkert Run/Assets/datos.json                    |  2 +-
 .../Assets/textures/Carritos/Pequenio/chica.mat       |  2 +-
 11 files changed, 47 insertions(+), 29 deletions(-)

=== COMMIT: 627a357 | Tue Oct 15 17:56:28 2024 -0600 | Colocar objetos en los estantes dependiendo su aleatoridad, correccion de bug de evitar personalizacion sin pagar saliendo del juego ===
 .../Assets/Objetos/CajaDeLecheOJugo.obj            |   93 +
 .../Assets/Objetos/CajaDeLecheOJugo.obj.meta       |  109 +
 Supermarkert Run/Assets/Objetos/Fila.prefab        | 4044 ++++++++++++++++----
 .../Assets/Objetos/Fila2 Variant.prefab            |   32 +
 .../Assets/Objetos/Fila3 Variant.prefab            |   40 +
 Supermarkert Run/Assets/Objetos/PepelHigienico.obj | 2297 +++++++++++
 .../Assets/Objetos/PepelHigienico.obj.meta         |  109 +
 Supermarkert Run/Assets/Objetos/caja.obj           |  348 ++
 Supermarkert Run/Assets/Objetos/caja.obj.meta      |  109 +
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |  528 +++
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  204 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |   88 +
 .../Assets/Scenes/Menu_principal.unity             |    2 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |    1 -
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |    6 +
 Supermarkert Run/Assets/Scripts/estantes/Area.cs   |   28 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |   27 +-
 .../Assets/Scripts/estantes/Estante.cs             |   15 +-
 Supermarkert Run/Assets/datos.json                 |    2 +-
 19 files changed, 7284 insertions(+), 798 deletions(-)

=== COMMIT: a634c2a | Sat Oct 19 16:44:06 2024 -0600 | Agregare font y personalizar un poco el menu solucionar unos problemas del mapa pequeño hacer estatico mapa pequeño ===
 Supermarkert Run/Assets/Font.meta                  |    8 +
 Supermarkert Run/Assets/Font/ARCO SDF.asset        | 2698 +++++++
 Supermarkert Run/Assets/Font/ARCO SDF.asset.meta   |    8 +
 Supermarkert Run/Assets/Font/ARCO for OSX.otf      |  Bin 0 -> 33692 bytes
 Supermarkert Run/Assets/Font/ARCO for OSX.otf.meta |   21 +
 Supermarkert Run/Assets/Font/ARCO.ttf              |  Bin 0 -> 25792 bytes
 Supermarkert Run/Assets/Font/ARCO.ttf.meta         |   21 +
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 7920 ++++++++++++++++----
 .../Assets/Scenes/Menu_principal.unity             |  358 +-
 Supermarkert Run/Assets/Scripts/AI/IA.cs           |    2 +-
 .../Assets/Scripts/AI/Seleccion_Carrito_Ai.cs      |    2 +-
 .../Liviano/Liviano_Personalzado.asset             |    2 +-
 .../Mediano/Mediano_personalizado.asset            |    2 +-
 .../Pesado/Pesado_personalizado.asset              |    2 +-
 .../Scripts/Juego/Mapa/Mapa_peque\303\261o.asset"  |    4 +
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |    2 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |    2 +-
 Supermarkert Run/Assets/datos.json                 |    2 +-
 .../textures/Carritos/Grande/PersonalizadaGra.mat  |   83 +
 .../Carritos/Grande/PersonalizadaGra.mat.meta      |    8 +
 .../textures/Carritos/Mediano/PersonalizadaMed.mat |   83 +
 .../Carritos/Mediano/PersonalizadaMed.mat.meta     |    8 +
 .../textures/Carritos/Pequenio/Personalizada.mat   |   83 +
 .../Carritos/Pequenio/Personalizada.mat.meta       |    8 +
 Supermarkert Run/Assets/textures/Menu.meta         |    8 +
 Supermarkert Run/Assets/textures/Menu/Carrito.png  |  Bin 0 -> 7656 bytes
 .../Assets/textures/Menu/Carrito.png.meta          |  127 +
 Supermarkert Run/Assets/textures/Menu/Salida.png   |  Bin 0 -> 38762 bytes
 .../Assets/textures/Menu/Salida.png.meta           |  127 +
 Supermarkert Run/Assets/textures/Menu/Salida2.png  |  Bin 0 -> 11534 bytes
 .../Assets/textures/Menu/Salida2.png.meta          |  127 +
 31 files changed, 10020 insertions(+), 1696 deletions(-)

=== COMMIT: 7ec0e4c | Sat Oct 19 20:48:57 2024 -0600 | Hacer estatico mapa mediano y grande agregar mas IA a estos mapas ===
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 45774 ++++++++++++++++---
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 22620 +++++++--
 .../Car Supermarkert/Liviano/Liviano2.asset        |     2 +-
 .../Car Supermarkert/Mediano/Mediano2.asset        |     2 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado2.asset  |     2 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |     8 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |     4 +-
 Supermarkert Run/Assets/datos.json                 |     2 +-
 .../textures/Carritos/Pequenio/Principal.mat       |    83 +
 .../textures/Carritos/Pequenio/Principal.mat.meta  |     8 +
 10 files changed, 57306 insertions(+), 11199 deletions(-)

=== COMMIT: 4dea56c | Sat Oct 19 21:42:55 2024 -0600 | Paredes y soluciones de sombras en los mapas y menu principal ===
 Supermarkert Run/Assets/Objetos/Fila.prefab        |  20 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 333 +++++++++++++++++++-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 333 +++++++++++++++++++-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 343 ++++++++++++++++++++-
 .../Assets/Scenes/Menu_principal.unity             | 335 +++++++++++++++++++-
 Supermarkert Run/Assets/datos.json                 |   2 +-
 Supermarkert Run/Assets/textures/Menu/Pared.mat    |  83 +++++
 .../Assets/textures/Menu/Pared.mat.meta            |   8 +
 .../Assets/textures/Supermercado/Estante.mat       |  83 +++++
 .../Assets/textures/Supermercado/Estante.mat.meta  |   8 +
 .../Assets/textures/Supermercado/Pared.mat         |  83 +++++
 .../Assets/textures/Supermercado/Pared.mat.meta    |   8 +
 .../Assets/textures/Supermercado/Suelo.jfif        | Bin 0 -> 817733 bytes
 .../Assets/textures/Supermercado/Suelo.jfif.meta   |   7 +
 .../Assets/textures/Supermercado/Suelo.mat         |  83 +++++
 .../Assets/textures/Supermercado/Suelo.mat.meta    |   8 +
 .../Assets/textures/Supermercado/Suelo.png         | Bin 0 -> 5362470 bytes
 .../Assets/textures/Supermercado/Suelo.png.meta    | 127 ++++++++
 18 files changed, 1823 insertions(+), 41 deletions(-)

=== COMMIT: 9606fb1 | Wed Oct 23 11:54:42 2024 -0600 | Arreglo de bug, salida de personalizacion, y otros que no recuerdo xd ===
 Supermarkert Run/Assets/Objetos/checkout.glb       | Bin 0 -> 4588524 bytes
 Supermarkert Run/Assets/Objetos/checkout.glb.meta  |   7 +
 Supermarkert Run/Assets/Objetos/source.meta        |   8 +
 .../Objetos/source/Hyper-casual Charcter.fbx       | Bin 0 -> 780400 bytes
 .../Objetos/source/Hyper-casual Charcter.fbx.meta  | 109 ++++++
 .../Assets/Scenes/Menu_principal.unity             | 369 ++++++++++++++++++++-
 .../Liviano/Liviano_Personalzado.asset             |   8 +-
 .../Scripts/Car Supermarkert/Personalizacion.cs    |  22 +-
 .../Juego/Gameplay/Contenido_Personalizado.cs      |   9 +
 .../Juego/Gameplay/Contenido_Personalizado.cs.meta |  11 +
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |  34 ++
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |   9 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |  13 +-
 Supermarkert Run/Assets/datos.json                 |   2 +-
 Supermarkert Run/Assets/personalizado.json         |   1 +
 Supermarkert Run/Assets/personalizado.json.meta    |   7 +
 .../textures/Carritos/Grande/PersonalizadaGra.mat  |   2 +-
 .../textures/Carritos/Mediano/PersonalizadaMed.mat |   2 +-
 .../textures/Carritos/Pequenio/Personalizada.mat   |   2 +-
 19 files changed, 588 insertions(+), 27 deletions(-)

=== COMMIT: 08cb420 | Wed Oct 23 15:41:14 2024 -0600 | Agregar animacion a jugador, colocar cajeros y cajas de cobro, optimizaciones ===
 .../Assets/Objetos/{source.meta => Jugador.meta}   |     2 +-
 .../Assets/Objetos/Jugador/Jugador.meta            |     8 +
 .../Jugador/Jugador/Animacion_Player.controller    |   161 +
 .../Jugador/Animacion_Player.controller.meta       |     8 +
 .../Jugador}/Hyper-casual Charcter.fbx             |   Bin
 .../Jugador}/Hyper-casual Charcter.fbx.meta        |    16 +-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   699 +
 .../Objetos/Jugador/Jugador/Jugador.prefab.meta    |     7 +
 .../Jugador/hyper-casual-charcter@Walking.fbx      |   Bin 0 -> 555728 bytes
 .../Jugador/hyper-casual-charcter@Walking.fbx.meta |   889 ++
 .../Assets/Objetos/{ => Jugador}/carrito.obj       |     0
 .../Assets/Objetos/{ => Jugador}/carrito.obj.meta  |     0
 Supermarkert Run/Assets/Objetos/Mapa.meta          |     8 +
 Supermarkert Run/Assets/Objetos/Mapa/Caja.meta     |     8 +
 .../Objetos/Mapa/Caja/ImageToStl.com_checkout.obj  | 12685 +++++++++++++++++++
 .../Mapa/Caja/ImageToStl.com_checkout.obj.meta     |   109 +
 Supermarkert Run/Assets/Objetos/Mapa/Caja/Skin.mat |    83 +
 .../Assets/Objetos/Mapa/Caja/Skin.mat.meta         |     8 +
 .../Assets/Objetos/Mapa/Caja/checkout.mtl          |    50 +
 .../Caja/checkout.mtl.meta}                        |     2 +-
 .../Objetos/Mapa/Caja/misc_tex_baseColor.jpg       |   Bin 0 -> 269909 bytes
 .../Objetos/Mapa/Caja/misc_tex_baseColor.jpg.meta  |   127 +
 .../Mapa/Caja/misc_tex_metallicRoughness.png       |   Bin 0 -> 1744671 bytes
 .../Mapa/Caja/misc_tex_metallicRoughness.png.meta  |   127 +
 .../Assets/Objetos/Mapa/Caja/misc_tex_normal.jpg   |   Bin 0 -> 248254 bytes
 .../Objetos/Mapa/Caja/misc_tex_normal.jpg.meta     |   127 +
 .../Assets/Objetos/Mapa/Caja/mostrador.prefab      |  1100 ++
 .../Assets/Objetos/Mapa/Caja/mostrador.prefab.meta |     7 +
 .../Assets/Objetos/Mapa/Caja/readme.txt            |     3 +
 .../Assets/Objetos/Mapa/Caja/readme.txt.meta       |     7 +
 .../Mapa/Caja/skin_body_metallicRoughness.png      |   Bin 0 -> 1756460 bytes
 .../Mapa/Caja/skin_body_metallicRoughness.png.meta |   127 +
 .../Assets/Objetos/Mapa/Caja/skin_body_normal.jpg  |   Bin 0 -> 317266 bytes
 .../Objetos/Mapa/Caja/skin_body_normal.jpg.meta    |   127 +
 .../Assets/Objetos/{ => Mapa}/Fila.prefab          |     0
 .../Assets/Objetos/{ => Mapa}/Fila.prefab.meta     |     0
 .../Assets/Objetos/{ => Mapa}/Fila2 Variant.prefab |     0
 .../Objetos/{ => Mapa}/Fila2 Variant.prefab.meta   |     0
 .../Assets/Objetos/{ => Mapa}/Fila3 Variant.prefab |     0
 .../Objetos/{ => Mapa}/Fila3 Variant.prefab.meta   |     0
 Supermarkert Run/Assets/Objetos/Mapa/Puerta.meta   |     8 +
 .../Mapa/Puerta/Automatic Breakout Doors.fbx       |   Bin 0 -> 130944 bytes
 .../Mapa/Puerta/Automatic Breakout Doors.fbx.meta  |   109 +
 .../Assets/Objetos/{ => Mapa}/estanteria.obj       |     0
 .../Assets/Objetos/{ => Mapa}/estanteria.obj.meta  |     0
 .../Assets/Objetos/Objetos_Colocados.meta          |     8 +
 .../Assets/Objetos/Objetos_Colocados/Caja.mat      |    83 +
 .../Assets/Objetos/Objetos_Colocados/Caja.mat.meta |     8 +
 .../{ => Objetos_Colocados}/CajaDeLecheOJugo.obj   |     0
 .../CajaDeLecheOJugo.obj.meta                      |     7 +-
 .../Objetos/Objetos_Colocados/Caja_Leche.mat       |    83 +
 .../Objetos/Objetos_Colocados/Caja_Leche.mat.meta  |     8 +
 .../{ => Objetos_Colocados}/PepelHigienico.obj     |     0
 .../PepelHigienico.obj.meta                        |     0
 .../Objetos/{ => Objetos_Colocados}/caja.obj       |     0
 .../Objetos/{ => Objetos_Colocados}/caja.obj.meta  |     7 +-
 Supermarkert Run/Assets/Objetos/checkout.glb       |   Bin 4588524 -> 0 bytes
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |  5044 +++++++-
 .../Mapa grande/NavMesh-NavMesh Surface.asset      |   Bin 83780 -> 85212 bytes
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  5222 ++++++--
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  1252 +-
 .../NavMesh-NavMesh Surface.asset"                 |   Bin 14984 -> 15288 bytes
 .../Assets/Scenes/Menu_principal.unity             |   703 +-
 .../Scripts/Car Supermarkert/Personalizacion.cs    |     1 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |     4 +
 Supermarkert Run/Assets/datos.json                 |     2 +-
 .../ProjectSettings/ProjectSettings.asset          |     3 +-
 67 files changed, 27270 insertions(+), 1777 deletions(-)

=== COMMIT: a761135 | Tue Oct 29 13:38:10 2024 -0600 | agregar modelo enemigo, animacion, mas creacion personalizada de cantidad de estos, arreglar bug de creacion demas de este ===
 Supermarkert Run/Assets/Objetos/Enemigo.meta       |    8 +
 .../Assets/Objetos/Enemigo/enemigo.prefab          |  713 ++
 .../Assets/Objetos/Enemigo/enemigo.prefab.meta     |    7 +
 .../Assets/Objetos/Enemigo/plano_seguir.prefab     |  108 +
 .../Objetos/Enemigo/plano_seguir.prefab.meta       |    7 +
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 6994 ++++----------------
 Supermarkert Run/Assets/Scripts/AI/IA.cs           |    7 +
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |   40 +-
 Supermarkert Run/Assets/datos.json                 |    2 +-
 9 files changed, 2314 insertions(+), 5572 deletions(-)

=== COMMIT: 866bfc8 | Tue Oct 29 18:13:33 2024 -0600 | Agregar mas enemigos a los nuevos mapas, y modificar distancia de sonido de los enemigos ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          |    18 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 43929 +++++--------------
 .../Mapa grande/NavMesh-NavMesh Surface.asset      |   Bin 85212 -> 86420 bytes
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 26582 +++--------
 Supermarkert Run/Assets/Scripts/AI/IA.cs           |    11 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |     6 -
 Supermarkert Run/Packages/manifest.json            |     1 +
 Supermarkert Run/Packages/packages-lock.json       |    26 +
 8 files changed, 17018 insertions(+), 53555 deletions(-)

=== COMMIT: ca5a0af | Tue Oct 29 20:13:31 2024 -0600 | Instalacion de animacion riggid, hacer animacion al jugador, hacer un pequeño sistema de animacionm dependiendo el carro, cambiar, Player.Repetir a Player.Perder ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          |   56 +
 .../Jugador/Jugador/Animacion_Player.controller    |    2 +-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  | 1473 +++++++++++++++++++-
 Supermarkert Run/Assets/Objetos/Muerte.prefab      |    4 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |   12 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |   15 +
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  381 +----
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    2 +-
 .../Assets/Scripts/Jugador/Seleccion_Carrito.cs    |    7 +
 9 files changed, 1549 insertions(+), 403 deletions(-)

=== COMMIT: 78a015a | Wed Oct 30 11:37:19 2024 -0600 | Animacion de enemigo agarrar el carrito ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          | 1345 +++++++++++++++++++-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |    2 +-
 .../Assets/Scripts/AI/Seleccion_Carrito_Ai.cs      |    3 +
 3 files changed, 1337 insertions(+), 13 deletions(-)

=== COMMIT: df9d943 | Wed Oct 30 16:43:20 2024 -0600 | Canvas modificable entre resoluciones, y modificacion de tipo de letra, hacer prefab de UI de juego, UI de muerte, UI de victoria ===
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     |  639 +++++
 .../{UI.prefab.meta => Ganar 1.prefab.meta}        |    2 +-
 Supermarkert Run/Assets/Objetos/Ganar.prefab       |  371 ---
 .../Objetos/{Muerte.prefab => Muerte 1.prefab}     |  270 +-
 .../{Ganar.prefab.meta => Muerte 1.prefab.meta}    |    2 +-
 .../Assets/Objetos/{UI.prefab => UI 1.prefab}      |  767 +++--
 .../{Muerte.prefab.meta => UI 1.prefab.meta}       |    2 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 3025 +++-----------------
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 2744 ++++--------------
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 2682 ++++-------------
 .../Assets/Scenes/Menu_principal.unity             |  850 +++---
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |    5 +
 12 files changed, 3257 insertions(+), 8102 deletions(-)

=== COMMIT: 021aaa5 | Wed Oct 30 19:30:10 2024 -0600 | Intento de hacer animacion de powerup, crear powerup de manos rapidas, arreglar bug de carrito sin material, colocar fondo a las puertas del supermercado ===
 Supermarkert Run/Assets/Objetos/Ganar.prefab       | 371 +++++++++++++++++++
 Supermarkert Run/Assets/Objetos/Ganar.prefab.meta  |   7 +
 .../Assets/Objetos/Mapa/Puerta_Automatica.prefab   | 233 ++++++++++++
 .../Objetos/Mapa/Puerta_Automatica.prefab.meta     |   7 +
 Supermarkert Run/Assets/Objetos/Power.prefab       |  25 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 180 ++++-----
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 410 +++++++--------------
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 172 +++------
 .../Assets/Scenes/Menu_principal.unity             | 141 ++++++-
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |   2 +-
 .../Car Supermarkert/Liviano/Liviano2.asset        |   2 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |   2 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  15 +-
 .../Assets/Scripts/PowerUp/Manos_Rapidas.cs        |  27 ++
 .../Assets/Scripts/PowerUp/Manos_Rapidas.cs.meta   |  11 +
 .../Assets/Scripts/PowerUp/Proteccion.cs           |   2 +-
 .../Assets/Scripts/PowerUp/Repartir_power.cs       |   5 +-
 .../Assets/Scripts/PowerUp/Velocidad.cs            |   2 +-
 .../Assets/Scripts/PowerUp/Vida_extra.cs           |   2 +-
 .../Assets/textures/Supermercado/Vidrio.mat        |  83 +++++
 .../Assets/textures/Supermercado/Vidrio.mat.meta   |   8 +
 .../textures/Supermercado/estacionamiento.PNG      | Bin 0 -> 438025 bytes
 .../textures/Supermercado/estacionamiento.PNG.meta | 127 +++++++
 23 files changed, 1301 insertions(+), 533 deletions(-)

=== COMMIT: 907876d | Mon Nov 4 19:51:38 2024 -0600 | Arreglar bug colores de objetos, optimizaciones agregar oclusion culling modificar distancia renderizado, otros modificar inclinacion de camara de 35 a 45 grados ===
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |   12 +-
 .../Scenes/Mapa grande/OcclusionCullingData.asset  | 1130 ++++++++++++++++++++
 .../Mapa grande/OcclusionCullingData.asset.meta    |    8 +
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |   12 +-
 .../Scenes/Mapa mediano/OcclusionCullingData.asset |  504 +++++++++
 .../Mapa mediano/OcclusionCullingData.asset.meta   |    8 +
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |   18 +-
 .../OcclusionCullingData.asset"                    |  236 ++++
 .../OcclusionCullingData.asset.meta"               |    8 +
 .../Assets/Scenes/Menu_principal.unity             |    4 +
 .../Assets/Scripts/estantes/Estante.cs             |    6 +-
 11 files changed, 1924 insertions(+), 22 deletions(-)

=== COMMIT: 185ba2d | Thu Nov 7 11:17:33 2024 -0600 | Eliminar sombras de objetos de estantes, acomodarlos de manera correcta, cambiar todo a ingles en tema de UI ===
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     |   2 +-
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   | 120 ++++++++++----------
 Supermarkert Run/Assets/Objetos/Muerte 1.prefab    |   2 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |  10 +-
 .../Assets/Scenes/Menu_principal.unity             | 122 ++++++++-------------
 .../Scripts/Car Supermarkert/Liviano/Liviano.asset |   6 +-
 .../Car Supermarkert/Liviano/Liviano2.asset        |   8 +-
 .../Liviano/Liviano_Personalzado.asset             |   4 +-
 .../Scripts/Car Supermarkert/Mediano/Mediano.asset |  10 +-
 .../Car Supermarkert/Mediano/Mediano2.asset        |   6 +-
 .../Mediano/Mediano_personalizado.asset            |   4 +-
 .../Scripts/Car Supermarkert/Personalizacion.cs    |  10 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado.asset   |   8 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado2.asset  |   8 +-
 .../Pesado/Pesado_personalizado.asset              |   4 +-
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |   6 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   8 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |  18 +--
 .../Assets/Scripts/PowerUp/Manos_Rapidas.cs        |   4 +-
 .../Assets/Scripts/PowerUp/Proteccion.cs           |   4 +-
 .../Assets/Scripts/PowerUp/Velocidad.cs            |   4 +-
 .../Assets/Scripts/PowerUp/Vida_extra.cs           |   4 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |  16 +--
 23 files changed, 177 insertions(+), 211 deletions(-)

=== COMMIT: 6d57ce9 | Thu Nov 7 15:57:25 2024 -0600 | Arreglar bug de misiones hechas ahora se actualiza correctamente, hacer ligthmaping a mapa pequeño ===
 Supermarkert Run/Assets/Objetos/Luces.meta         |    8 +
 .../Objetos/Luces/New Lighting Settings.lighting   |   66 +
 .../Luces/New Lighting Settings.lighting.meta      |    8 +
 .../Mapa/Caja/ImageToStl.com_checkout.obj.meta     |    2 +-
 .../Assets/Objetos/Mapa/Caja/mostrador.prefab      |   74 +-
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |  130 +-
 .../Mapa/Puerta/Automatic Breakout Doors.fbx.meta  |    4 +-
 .../Assets/Objetos/Mapa/estanteria.obj.meta        |    2 +-
 .../Objetos_Colocados/CajaDeLecheOJugo.obj.meta    |    2 +-
 .../Objetos_Colocados/PepelHigienico.obj.meta      |    2 +-
 .../Assets/Objetos/Objetos_Colocados/caja.obj.meta |    2 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 2300 ++++++++++++++++++--
 .../Scenes/Mapa peque\303\261o/LightingData.asset" |  Bin 0 -> 29160 bytes
 .../Mapa peque\303\261o/LightingData.asset.meta"   |    8 +
 .../Mapa peque\303\261o/Lightmap-0_comp_dir.png"   |  Bin 0 -> 126412 bytes
 .../Lightmap-0_comp_dir.png.meta"                  |  127 ++
 .../Mapa peque\303\261o/Lightmap-0_comp_light.exr" |  Bin 0 -> 459832 bytes
 .../Lightmap-0_comp_light.exr.meta"                |  127 ++
 .../Mapa peque\303\261o/Lightmap-10_comp_dir.png"  |  Bin 0 -> 33026 bytes
 .../Lightmap-10_comp_dir.png.meta"                 |  127 ++
 .../Lightmap-10_comp_light.exr"                    |  Bin 0 -> 165301 bytes
 .../Lightmap-10_comp_light.exr.meta"               |  127 ++
 .../Mapa peque\303\261o/Lightmap-11_comp_dir.png"  |  Bin 0 -> 33856 bytes
 .../Lightmap-11_comp_dir.png.meta"                 |  127 ++
 .../Lightmap-11_comp_light.exr"                    |  Bin 0 -> 167015 bytes
 .../Lightmap-11_comp_light.exr.meta"               |  127 ++
 .../Mapa peque\303\261o/Lightmap-12_comp_dir.png"  |  Bin 0 -> 33866 bytes
 .../Lightmap-12_comp_dir.png.meta"                 |  127 ++
 .../Lightmap-12_comp_light.exr"                    |  Bin 0 -> 168032 bytes
 .../Lightmap-12_comp_light.exr.meta"               |  127 ++
 .../Mapa peque\303\261o/Lightmap-13_comp_dir.png"  |  Bin 0 -> 33902 bytes
 .../Lightmap-13_comp_dir.png.meta"                 |  127 ++
 .../Lightmap-13_comp_light.exr"                    |  Bin 0 -> 167470 bytes
 .../Lightmap-13_comp_light.exr.meta"               |  127 ++
 .../Mapa peque\303\261o/Lightmap-14_comp_dir.png"  |  Bin 0 -> 33265 bytes
 .../Lightmap-14_comp_dir.png.meta"                 |  127 ++
 .../Lightmap-14_comp_light.exr"                    |  Bin 0 -> 167067 bytes
 .../Lightmap-14_comp_light.exr.meta"               |  127 ++
 .../Mapa peque\303\261o/Lightmap-15_comp_dir.png"  |  Bin 0 -> 32278 bytes
 .../Lightmap-15_comp_dir.png.meta"                 |  127 ++
 .../Lightmap-15_comp_light.exr"                    |  Bin 0 -> 165618 bytes
 .../Lightmap-15_comp_light.exr.meta"               |  127 ++
 .../Mapa peque\303\261o/Lightmap-16_comp_dir.png"  |  Bin 0 -> 32741 bytes
 .../Lightmap-16_comp_dir.png.meta"                 |  127 ++
 .../Lightmap-16_comp_light.exr"                    |  Bin 0 -> 165452 bytes
 .../Lightmap-16_comp_light.exr.meta"               |  127 ++
 .../Mapa peque\303\261o/Lightmap-17_comp_dir.png"  |  Bin 0 -> 33473 bytes
 .../Lightmap-17_comp_dir.png.meta"                 |  127 ++
 .../Lightmap-17_comp_light.exr"                    |  Bin 0 -> 167486 bytes
 .../Lightmap-17_comp_light.exr.meta"               |  127 ++
 .../Mapa peque\303\261o/Lightmap-18_comp_dir.png"  |  Bin 0 -> 33394 bytes
 .../Lightmap-18_comp_dir.png.meta"                 |  127 ++
 .../Lightmap-18_comp_light.exr"                    |  Bin 0 -> 166700 bytes
 .../Lightmap-18_comp_light.exr.meta"               |  127 ++
 .../Mapa peque\303\261o/Lightmap-19_comp_dir.png"  |  Bin 0 -> 29053 bytes
 .../Lightmap-19_comp_dir.png.meta"                 |  127 ++
 .../Lightmap-19_comp_light.exr"                    |  Bin 0 -> 121298 bytes
 .../Lightmap-19_comp_light.exr.meta"               |  127 ++
 .../Mapa peque\303\261o/Lightmap-1_comp_dir.png"   |  Bin 0 -> 129773 bytes
 .../Lightmap-1_comp_dir.png.meta"                  |  127 ++
 .../Mapa peque\303\261o/Lightmap-1_comp_light.exr" |  Bin 0 -> 643978 bytes
 .../Lightmap-1_comp_light.exr.meta"                |  127 ++
 .../Mapa peque\303\261o/Lightmap-2_comp_dir.png"   |  Bin 0 -> 129556 bytes
 .../Lightmap-2_comp_dir.png.meta"                  |  127 ++
 .../Mapa peque\303\261o/Lightmap-2_comp_light.exr" |  Bin 0 -> 646105 bytes
 .../Lightmap-2_comp_light.exr.meta"                |  127 ++
 .../Mapa peque\303\261o/Lightmap-3_comp_dir.png"   |  Bin 0 -> 132110 bytes
 .../Lightmap-3_comp_dir.png.meta"                  |  127 ++
 .../Mapa peque\303\261o/Lightmap-3_comp_light.exr" |  Bin 0 -> 647415 bytes
 .../Lightmap-3_comp_light.exr.meta"                |  127 ++
 .../Mapa peque\303\261o/Lightmap-4_comp_dir.png"   |  Bin 0 -> 127124 bytes
 .../Lightmap-4_comp_dir.png.meta"                  |  127 ++
 .../Mapa peque\303\261o/Lightmap-4_comp_light.exr" |  Bin 0 -> 640442 bytes
 .../Lightmap-4_comp_light.exr.meta"                |  127 ++
 .../Mapa peque\303\261o/Lightmap-5_comp_dir.png"   |  Bin 0 -> 64920 bytes
 .../Lightmap-5_comp_dir.png.meta"                  |  127 ++
 .../Mapa peque\303\261o/Lightmap-5_comp_light.exr" |  Bin 0 -> 286704 bytes
 .../Lightmap-5_comp_light.exr.meta"                |  127 ++
 .../Mapa peque\303\261o/Lightmap-6_comp_dir.png"   |  Bin 0 -> 33469 bytes
 .../Lightmap-6_comp_dir.png.meta"                  |  127 ++
 .../Mapa peque\303\261o/Lightmap-6_comp_light.exr" |  Bin 0 -> 164281 bytes
 .../Lightmap-6_comp_light.exr.meta"                |  127 ++
 .../Mapa peque\303\261o/Lightmap-7_comp_dir.png"   |  Bin 0 -> 33326 bytes
 .../Lightmap-7_comp_dir.png.meta"                  |  127 ++
 .../Mapa peque\303\261o/Lightmap-7_comp_light.exr" |  Bin 0 -> 166960 bytes
 .../Lightmap-7_comp_light.exr.meta"                |  127 ++
 .../Mapa peque\303\261o/Lightmap-8_comp_dir.png"   |  Bin 0 -> 32567 bytes
 .../Lightmap-8_comp_dir.png.meta"                  |  127 ++
 .../Mapa peque\303\261o/Lightmap-8_comp_light.exr" |  Bin 0 -> 165458 bytes
 .../Lightmap-8_comp_light.exr.meta"                |  127 ++
 .../Mapa peque\303\261o/Lightmap-9_comp_dir.png"   |  Bin 0 -> 33638 bytes
 .../Lightmap-9_comp_dir.png.meta"                  |  127 ++
 .../Mapa peque\303\261o/Lightmap-9_comp_light.exr" |  Bin 0 -> 166061 bytes
 .../Lightmap-9_comp_light.exr.meta"                |  127 ++
 .../Assets/Scenes/Menu_principal.unity             |  292 +++
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |    1 +
 .../BurstAotSettings_StandaloneWindows.json        |   18 +
 .../ProjectSettings/CommonBurstAotSettings.json    |    6 +
 .../ProjectSettings/ProjectSettings.asset          |    2 +-
 .../ProjectSettings/QualitySettings.asset          |    2 +-
 100 files changed, 7724 insertions(+), 285 deletions(-)

=== COMMIT: 2b92f02 | Thu Nov 7 20:52:34 2024 -0600 | Reduccion de luces en el mapa pequeño eh eliminacion de sombras de ciertos objetos, reduccion de este ante calidad y distancia ===
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 1380 +++++---------------
 .../Scenes/Mapa peque\303\261o/LightingData.asset" |  Bin 29160 -> 28800 bytes
 .../Mapa peque\303\261o/Lightmap-0_comp_dir.png"   |  Bin 126412 -> 114364 bytes
 .../Mapa peque\303\261o/Lightmap-0_comp_light.exr" |  Bin 459832 -> 435279 bytes
 .../Mapa peque\303\261o/Lightmap-10_comp_dir.png"  |  Bin 33026 -> 0 bytes
 .../Lightmap-10_comp_dir.png.meta"                 |  127 --
 .../Lightmap-10_comp_light.exr"                    |  Bin 165301 -> 0 bytes
 .../Lightmap-10_comp_light.exr.meta"               |  127 --
 .../Mapa peque\303\261o/Lightmap-11_comp_dir.png"  |  Bin 33856 -> 0 bytes
 .../Lightmap-11_comp_dir.png.meta"                 |  127 --
 .../Lightmap-11_comp_light.exr"                    |  Bin 167015 -> 0 bytes
 .../Lightmap-11_comp_light.exr.meta"               |  127 --
 .../Mapa peque\303\261o/Lightmap-12_comp_dir.png"  |  Bin 33866 -> 0 bytes
 .../Lightmap-12_comp_dir.png.meta"                 |  127 --
 .../Lightmap-12_comp_light.exr"                    |  Bin 168032 -> 0 bytes
 .../Lightmap-12_comp_light.exr.meta"               |  127 --
 .../Mapa peque\303\261o/Lightmap-13_comp_dir.png"  |  Bin 33902 -> 0 bytes
 .../Lightmap-13_comp_dir.png.meta"                 |  127 --
 .../Lightmap-13_comp_light.exr"                    |  Bin 167470 -> 0 bytes
 .../Lightmap-13_comp_light.exr.meta"               |  127 --
 .../Mapa peque\303\261o/Lightmap-14_comp_dir.png"  |  Bin 33265 -> 0 bytes
 .../Lightmap-14_comp_dir.png.meta"                 |  127 --
 .../Lightmap-14_comp_light.exr"                    |  Bin 167067 -> 0 bytes
 .../Lightmap-14_comp_light.exr.meta"               |  127 --
 .../Mapa peque\303\261o/Lightmap-15_comp_dir.png"  |  Bin 32278 -> 0 bytes
 .../Lightmap-15_comp_dir.png.meta"                 |  127 --
 .../Lightmap-15_comp_light.exr"                    |  Bin 165618 -> 0 bytes
 .../Lightmap-15_comp_light.exr.meta"               |  127 --
 .../Mapa peque\303\261o/Lightmap-16_comp_dir.png"  |  Bin 32741 -> 0 bytes
 .../Lightmap-16_comp_dir.png.meta"                 |  127 --
 .../Lightmap-16_comp_light.exr"                    |  Bin 165452 -> 0 bytes
 .../Lightmap-16_comp_light.exr.meta"               |  127 --
 .../Mapa peque\303\261o/Lightmap-17_comp_dir.png"  |  Bin 33473 -> 0 bytes
 .../Lightmap-17_comp_dir.png.meta"                 |  127 --
 .../Lightmap-17_comp_light.exr"                    |  Bin 167486 -> 0 bytes
 .../Lightmap-17_comp_light.exr.meta"               |  127 --
 .../Mapa peque\303\261o/Lightmap-18_comp_dir.png"  |  Bin 33394 -> 0 bytes
 .../Lightmap-18_comp_dir.png.meta"                 |  127 --
 .../Lightmap-18_comp_light.exr"                    |  Bin 166700 -> 0 bytes
 .../Lightmap-18_comp_light.exr.meta"               |  127 --
 .../Mapa peque\303\261o/Lightmap-19_comp_dir.png"  |  Bin 29053 -> 0 bytes
 .../Lightmap-19_comp_dir.png.meta"                 |  127 --
 .../Lightmap-19_comp_light.exr"                    |  Bin 121298 -> 0 bytes
 .../Lightmap-19_comp_light.exr.meta"               |  127 --
 .../Mapa peque\303\261o/Lightmap-1_comp_dir.png"   |  Bin 129773 -> 48941 bytes
 .../Mapa peque\303\261o/Lightmap-1_comp_light.exr" |  Bin 643978 -> 358096 bytes
 .../Mapa peque\303\261o/Lightmap-2_comp_dir.png"   |  Bin 129556 -> 50372 bytes
 .../Mapa peque\303\261o/Lightmap-2_comp_light.exr" |  Bin 646105 -> 358959 bytes
 .../Mapa peque\303\261o/Lightmap-3_comp_dir.png"   |  Bin 132110 -> 50990 bytes
 .../Mapa peque\303\261o/Lightmap-3_comp_light.exr" |  Bin 647415 -> 362850 bytes
 .../Mapa peque\303\261o/Lightmap-4_comp_dir.png"   |  Bin 127124 -> 49691 bytes
 .../Mapa peque\303\261o/Lightmap-4_comp_light.exr" |  Bin 640442 -> 359056 bytes
 .../Mapa peque\303\261o/Lightmap-5_comp_dir.png"   |  Bin 64920 -> 35690 bytes
 .../Mapa peque\303\261o/Lightmap-5_comp_light.exr" |  Bin 286704 -> 223681 bytes
 .../Mapa peque\303\261o/Lightmap-6_comp_dir.png"   |  Bin 33469 -> 0 bytes
 .../Lightmap-6_comp_dir.png.meta"                  |  127 --
 .../Mapa peque\303\261o/Lightmap-6_comp_light.exr" |  Bin 164281 -> 0 bytes
 .../Lightmap-6_comp_light.exr.meta"                |  127 --
 .../Mapa peque\303\261o/Lightmap-7_comp_dir.png"   |  Bin 33326 -> 0 bytes
 .../Lightmap-7_comp_dir.png.meta"                  |  127 --
 .../Mapa peque\303\261o/Lightmap-7_comp_light.exr" |  Bin 166960 -> 0 bytes
 .../Lightmap-7_comp_light.exr.meta"                |  127 --
 .../Mapa peque\303\261o/Lightmap-8_comp_dir.png"   |  Bin 32567 -> 0 bytes
 .../Lightmap-8_comp_dir.png.meta"                  |  127 --
 .../Mapa peque\303\261o/Lightmap-8_comp_light.exr" |  Bin 165458 -> 0 bytes
 .../Lightmap-8_comp_light.exr.meta"                |  127 --
 .../Mapa peque\303\261o/Lightmap-9_comp_dir.png"   |  Bin 33638 -> 0 bytes
 .../Lightmap-9_comp_dir.png.meta"                  |  127 --
 .../Mapa peque\303\261o/Lightmap-9_comp_light.exr" |  Bin 166061 -> 0 bytes
 .../Lightmap-9_comp_light.exr.meta"                |  127 --
 .../OcclusionCullingData.asset"                    |  242 ++--
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |    1 +
 .../ProjectSettings/QualitySettings.asset          |    6 +-
 73 files changed, 404 insertions(+), 4781 deletions(-)

=== COMMIT: 2871d97 | Mon Nov 11 13:24:06 2024 -0600 | Optimizaciones: -Hacer ligthmap en mapa pequeño, agregar sol a mapa pequeño, agregar sombras falsas a jugador y enemigo ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          |  440 ++++-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |  374 +++++
 .../Objetos/Luces/New Lighting Settings.lighting   |    6 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 1697 +++++++++++---------
 .../Scenes/Mapa peque\303\261o/LightingData.asset" |  Bin 28800 -> 27344 bytes
 .../Mapa peque\303\261o/Lightmap-0_comp_dir.png"   |  Bin 114364 -> 107062 bytes
 .../Lightmap-0_comp_dir.png.meta"                  |    2 +-
 .../Mapa peque\303\261o/Lightmap-0_comp_light.exr" |  Bin 435279 -> 414139 bytes
 .../Lightmap-0_comp_light.exr.meta"                |    2 +-
 .../Mapa peque\303\261o/Lightmap-1_comp_dir.png"   |  Bin 48941 -> 55755 bytes
 .../Lightmap-1_comp_dir.png.meta"                  |    2 +-
 .../Mapa peque\303\261o/Lightmap-1_comp_light.exr" |  Bin 358096 -> 312029 bytes
 .../Lightmap-1_comp_light.exr.meta"                |    2 +-
 .../Mapa peque\303\261o/Lightmap-2_comp_dir.png"   |  Bin 50372 -> 56464 bytes
 .../Lightmap-2_comp_dir.png.meta"                  |    2 +-
 .../Mapa peque\303\261o/Lightmap-2_comp_light.exr" |  Bin 358959 -> 303451 bytes
 .../Lightmap-2_comp_light.exr.meta"                |    2 +-
 .../Mapa peque\303\261o/Lightmap-3_comp_dir.png"   |  Bin 50990 -> 56961 bytes
 .../Lightmap-3_comp_dir.png.meta"                  |    2 +-
 .../Mapa peque\303\261o/Lightmap-3_comp_light.exr" |  Bin 362850 -> 302737 bytes
 .../Lightmap-3_comp_light.exr.meta"                |    2 +-
 .../Mapa peque\303\261o/Lightmap-4_comp_dir.png"   |  Bin 49691 -> 54981 bytes
 .../Lightmap-4_comp_dir.png.meta"                  |    2 +-
 .../Mapa peque\303\261o/Lightmap-4_comp_light.exr" |  Bin 359056 -> 301704 bytes
 .../Lightmap-4_comp_light.exr.meta"                |    2 +-
 .../Mapa peque\303\261o/Lightmap-5_comp_dir.png"   |  Bin 35690 -> 13729 bytes
 .../Lightmap-5_comp_dir.png.meta"                  |    2 +-
 .../Mapa peque\303\261o/Lightmap-5_comp_light.exr" |  Bin 223681 -> 76467 bytes
 .../Lightmap-5_comp_light.exr.meta"                |    2 +-
 .../Assets/textures/Supermercado/Estante.mat       |    2 +-
 .../Assets/textures/Supermercado/Suelo.mat         |   11 +-
 .../ProjectSettings/QualitySettings.asset          |    2 +-
 32 files changed, 1775 insertions(+), 781 deletions(-)

=== COMMIT: a6ea041 | Mon Nov 11 15:16:02 2024 -0600 | Optimizaciones: hacer ligthmaping a mapa mediano ===
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 2030 +++++++++++++++++++-
 .../Assets/Scenes/Mapa mediano/LightingData.asset  |  Bin 0 -> 39880 bytes
 .../Scenes/Mapa mediano/LightingData.asset.meta    |    8 +
 .../Scenes/Mapa mediano/Lightmap-0_comp_dir.png    |  Bin 0 -> 195192 bytes
 .../Mapa mediano/Lightmap-0_comp_dir.png.meta      |  127 ++
 .../Scenes/Mapa mediano/Lightmap-0_comp_light.exr  |  Bin 0 -> 577593 bytes
 .../Mapa mediano/Lightmap-0_comp_light.exr.meta    |  127 ++
 .../Scenes/Mapa mediano/Lightmap-10_comp_dir.png   |  Bin 0 -> 55102 bytes
 .../Mapa mediano/Lightmap-10_comp_dir.png.meta     |  127 ++
 .../Scenes/Mapa mediano/Lightmap-10_comp_light.exr |  Bin 0 -> 315199 bytes
 .../Mapa mediano/Lightmap-10_comp_light.exr.meta   |  127 ++
 .../Scenes/Mapa mediano/Lightmap-11_comp_dir.png   |  Bin 0 -> 55439 bytes
 .../Mapa mediano/Lightmap-11_comp_dir.png.meta     |  127 ++
 .../Scenes/Mapa mediano/Lightmap-11_comp_light.exr |  Bin 0 -> 320263 bytes
 .../Mapa mediano/Lightmap-11_comp_light.exr.meta   |  127 ++
 .../Scenes/Mapa mediano/Lightmap-12_comp_dir.png   |  Bin 0 -> 57029 bytes
 .../Mapa mediano/Lightmap-12_comp_dir.png.meta     |  127 ++
 .../Scenes/Mapa mediano/Lightmap-12_comp_light.exr |  Bin 0 -> 317895 bytes
 .../Mapa mediano/Lightmap-12_comp_light.exr.meta   |  127 ++
 .../Scenes/Mapa mediano/Lightmap-13_comp_dir.png   |  Bin 0 -> 53069 bytes
 .../Mapa mediano/Lightmap-13_comp_dir.png.meta     |  127 ++
 .../Scenes/Mapa mediano/Lightmap-13_comp_light.exr |  Bin 0 -> 205075 bytes
 .../Mapa mediano/Lightmap-13_comp_light.exr.meta   |  127 ++
 .../Scenes/Mapa mediano/Lightmap-1_comp_dir.png    |  Bin 0 -> 165338 bytes
 .../Mapa mediano/Lightmap-1_comp_dir.png.meta      |  127 ++
 .../Scenes/Mapa mediano/Lightmap-1_comp_light.exr  |  Bin 0 -> 540132 bytes
 .../Mapa mediano/Lightmap-1_comp_light.exr.meta    |  127 ++
 .../Scenes/Mapa mediano/Lightmap-2_comp_dir.png    |  Bin 0 -> 181520 bytes
 .../Mapa mediano/Lightmap-2_comp_dir.png.meta      |  127 ++
 .../Scenes/Mapa mediano/Lightmap-2_comp_light.exr  |  Bin 0 -> 530009 bytes
 .../Mapa mediano/Lightmap-2_comp_light.exr.meta    |  127 ++
 .../Scenes/Mapa mediano/Lightmap-3_comp_dir.png    |  Bin 0 -> 140183 bytes
 .../Mapa mediano/Lightmap-3_comp_dir.png.meta      |  127 ++
 .../Scenes/Mapa mediano/Lightmap-3_comp_light.exr  |  Bin 0 -> 502527 bytes
 .../Mapa mediano/Lightmap-3_comp_light.exr.meta    |  127 ++
 .../Scenes/Mapa mediano/Lightmap-4_comp_dir.png    |  Bin 0 -> 159230 bytes
 .../Mapa mediano/Lightmap-4_comp_dir.png.meta      |  127 ++
 .../Scenes/Mapa mediano/Lightmap-4_comp_light.exr  |  Bin 0 -> 566973 bytes
 .../Mapa mediano/Lightmap-4_comp_light.exr.meta    |  127 ++
 .../Scenes/Mapa mediano/Lightmap-5_comp_dir.png    |  Bin 0 -> 61607 bytes
 .../Mapa mediano/Lightmap-5_comp_dir.png.meta      |  127 ++
 .../Scenes/Mapa mediano/Lightmap-5_comp_light.exr  |  Bin 0 -> 327912 bytes
 .../Mapa mediano/Lightmap-5_comp_light.exr.meta    |  127 ++
 .../Scenes/Mapa mediano/Lightmap-6_comp_dir.png    |  Bin 0 -> 57245 bytes
 .../Mapa mediano/Lightmap-6_comp_dir.png.meta      |  127 ++
 .../Scenes/Mapa mediano/Lightmap-6_comp_light.exr  |  Bin 0 -> 321681 bytes
 .../Mapa mediano/Lightmap-6_comp_light.exr.meta    |  127 ++
 .../Scenes/Mapa mediano/Lightmap-7_comp_dir.png    |  Bin 0 -> 58385 bytes
 .../Mapa mediano/Lightmap-7_comp_dir.png.meta      |  127 ++
 .../Scenes/Mapa mediano/Lightmap-7_comp_light.exr  |  Bin 0 -> 313594 bytes
 .../Mapa mediano/Lightmap-7_comp_light.exr.meta    |  127 ++
 .../Scenes/Mapa mediano/Lightmap-8_comp_dir.png    |  Bin 0 -> 56239 bytes
 .../Mapa mediano/Lightmap-8_comp_dir.png.meta      |  127 ++
 .../Scenes/Mapa mediano/Lightmap-8_comp_light.exr  |  Bin 0 -> 318394 bytes
 .../Mapa mediano/Lightmap-8_comp_light.exr.meta    |  127 ++
 .../Scenes/Mapa mediano/Lightmap-9_comp_dir.png    |  Bin 0 -> 59769 bytes
 .../Mapa mediano/Lightmap-9_comp_dir.png.meta      |  127 ++
 .../Scenes/Mapa mediano/Lightmap-9_comp_light.exr  |  Bin 0 -> 320796 bytes
 .../Mapa mediano/Lightmap-9_comp_light.exr.meta    |  127 ++
 .../Assets/textures/Supermercado/Suelo.mat         |    2 +-
 60 files changed, 5546 insertions(+), 50 deletions(-)

=== COMMIT: 03fce4b | Tue Nov 12 14:43:26 2024 -0600 | Optimizaciones: Hacer ligthmap en mapa grande, y menu, apagar luces o bajar la intensidad del sol en los mapas,crear sombras falsas en jugador y carritos, . Arreglar bugs: de Power Up mostrar parte se hundia ahora ya no. Agregar o Midificar: fotos a los mapas a la hora de seleccionar, power up vista. ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          |  252 +-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   84 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 5405 +++++++++++++++++++-
 .../Assets/Scenes/Mapa grande/LightingData.asset   |  Bin 0 -> 72376 bytes
 .../Scenes/Mapa grande/LightingData.asset.meta     |    8 +
 .../Scenes/Mapa grande/Lightmap-0_comp_dir.png     |  Bin 0 -> 153845 bytes
 .../Mapa grande/Lightmap-0_comp_dir.png.meta       |  127 +
 .../Scenes/Mapa grande/Lightmap-0_comp_light.exr   |  Bin 0 -> 570010 bytes
 .../Mapa grande/Lightmap-0_comp_light.exr.meta     |  127 +
 .../Scenes/Mapa grande/Lightmap-10_comp_dir.png    |  Bin 0 -> 52929 bytes
 .../Mapa grande/Lightmap-10_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-10_comp_light.exr  |  Bin 0 -> 307865 bytes
 .../Mapa grande/Lightmap-10_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-11_comp_dir.png    |  Bin 0 -> 52269 bytes
 .../Mapa grande/Lightmap-11_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-11_comp_light.exr  |  Bin 0 -> 304257 bytes
 .../Mapa grande/Lightmap-11_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-12_comp_dir.png    |  Bin 0 -> 52588 bytes
 .../Mapa grande/Lightmap-12_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-12_comp_light.exr  |  Bin 0 -> 311745 bytes
 .../Mapa grande/Lightmap-12_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-13_comp_dir.png    |  Bin 0 -> 51885 bytes
 .../Mapa grande/Lightmap-13_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-13_comp_light.exr  |  Bin 0 -> 306317 bytes
 .../Mapa grande/Lightmap-13_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-14_comp_dir.png    |  Bin 0 -> 52617 bytes
 .../Mapa grande/Lightmap-14_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-14_comp_light.exr  |  Bin 0 -> 305884 bytes
 .../Mapa grande/Lightmap-14_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-15_comp_dir.png    |  Bin 0 -> 53220 bytes
 .../Mapa grande/Lightmap-15_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-15_comp_light.exr  |  Bin 0 -> 302020 bytes
 .../Mapa grande/Lightmap-15_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-16_comp_dir.png    |  Bin 0 -> 51713 bytes
 .../Mapa grande/Lightmap-16_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-16_comp_light.exr  |  Bin 0 -> 309987 bytes
 .../Mapa grande/Lightmap-16_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-17_comp_dir.png    |  Bin 0 -> 54196 bytes
 .../Mapa grande/Lightmap-17_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-17_comp_light.exr  |  Bin 0 -> 304778 bytes
 .../Mapa grande/Lightmap-17_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-18_comp_dir.png    |  Bin 0 -> 55190 bytes
 .../Mapa grande/Lightmap-18_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-18_comp_light.exr  |  Bin 0 -> 303235 bytes
 .../Mapa grande/Lightmap-18_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-19_comp_dir.png    |  Bin 0 -> 54055 bytes
 .../Mapa grande/Lightmap-19_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-19_comp_light.exr  |  Bin 0 -> 309614 bytes
 .../Mapa grande/Lightmap-19_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-1_comp_dir.png     |  Bin 0 -> 161722 bytes
 .../Mapa grande/Lightmap-1_comp_dir.png.meta       |  127 +
 .../Scenes/Mapa grande/Lightmap-1_comp_light.exr   |  Bin 0 -> 575926 bytes
 .../Mapa grande/Lightmap-1_comp_light.exr.meta     |  127 +
 .../Scenes/Mapa grande/Lightmap-20_comp_dir.png    |  Bin 0 -> 52422 bytes
 .../Mapa grande/Lightmap-20_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-20_comp_light.exr  |  Bin 0 -> 306032 bytes
 .../Mapa grande/Lightmap-20_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-21_comp_dir.png    |  Bin 0 -> 52504 bytes
 .../Mapa grande/Lightmap-21_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-21_comp_light.exr  |  Bin 0 -> 307279 bytes
 .../Mapa grande/Lightmap-21_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-22_comp_dir.png    |  Bin 0 -> 54631 bytes
 .../Mapa grande/Lightmap-22_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-22_comp_light.exr  |  Bin 0 -> 312606 bytes
 .../Mapa grande/Lightmap-22_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-23_comp_dir.png    |  Bin 0 -> 52552 bytes
 .../Mapa grande/Lightmap-23_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-23_comp_light.exr  |  Bin 0 -> 308436 bytes
 .../Mapa grande/Lightmap-23_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-24_comp_dir.png    |  Bin 0 -> 52932 bytes
 .../Mapa grande/Lightmap-24_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-24_comp_light.exr  |  Bin 0 -> 307458 bytes
 .../Mapa grande/Lightmap-24_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-25_comp_dir.png    |  Bin 0 -> 53294 bytes
 .../Mapa grande/Lightmap-25_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-25_comp_light.exr  |  Bin 0 -> 306389 bytes
 .../Mapa grande/Lightmap-25_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-26_comp_dir.png    |  Bin 0 -> 54828 bytes
 .../Mapa grande/Lightmap-26_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-26_comp_light.exr  |  Bin 0 -> 309438 bytes
 .../Mapa grande/Lightmap-26_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-27_comp_dir.png    |  Bin 0 -> 53453 bytes
 .../Mapa grande/Lightmap-27_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-27_comp_light.exr  |  Bin 0 -> 305770 bytes
 .../Mapa grande/Lightmap-27_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-28_comp_dir.png    |  Bin 0 -> 20729 bytes
 .../Mapa grande/Lightmap-28_comp_dir.png.meta      |  127 +
 .../Scenes/Mapa grande/Lightmap-28_comp_light.exr  |  Bin 0 -> 178268 bytes
 .../Mapa grande/Lightmap-28_comp_light.exr.meta    |  127 +
 .../Scenes/Mapa grande/Lightmap-2_comp_dir.png     |  Bin 0 -> 126439 bytes
 .../Mapa grande/Lightmap-2_comp_dir.png.meta       |  127 +
 .../Scenes/Mapa grande/Lightmap-2_comp_light.exr   |  Bin 0 -> 492190 bytes
 .../Mapa grande/Lightmap-2_comp_light.exr.meta     |  127 +
 .../Scenes/Mapa grande/Lightmap-3_comp_dir.png     |  Bin 0 -> 53777 bytes
 .../Mapa grande/Lightmap-3_comp_dir.png.meta       |  127 +
 .../Scenes/Mapa grande/Lightmap-3_comp_light.exr   |  Bin 0 -> 310758 bytes
 .../Mapa grande/Lightmap-3_comp_light.exr.meta     |  127 +
 .../Scenes/Mapa grande/Lightmap-4_comp_dir.png     |  Bin 0 -> 53160 bytes
 .../Mapa grande/Lightmap-4_comp_dir.png.meta       |  127 +
 .../Scenes/Mapa grande/Lightmap-4_comp_light.exr   |  Bin 0 -> 306957 bytes
 .../Mapa grande/Lightmap-4_comp_light.exr.meta     |  127 +
 .../Scenes/Mapa grande/Lightmap-5_comp_dir.png     |  Bin 0 -> 54104 bytes
 .../Mapa grande/Lightmap-5_comp_dir.png.meta       |  127 +
 .../Scenes/Mapa grande/Lightmap-5_comp_light.exr   |  Bin 0 -> 303749 bytes
 .../Mapa grande/Lightmap-5_comp_light.exr.meta     |  127 +
 .../Scenes/Mapa grande/Lightmap-6_comp_dir.png     |  Bin 0 -> 53307 bytes
 .../Mapa grande/Lightmap-6_comp_dir.png.meta       |  127 +
 .../Scenes/Mapa grande/Lightmap-6_comp_light.exr   |  Bin 0 -> 303200 bytes
 .../Mapa grande/Lightmap-6_comp_light.exr.meta     |  127 +
 .../Scenes/Mapa grande/Lightmap-7_comp_dir.png     |  Bin 0 -> 51905 bytes
 .../Mapa grande/Lightmap-7_comp_dir.png.meta       |  127 +
 .../Scenes/Mapa grande/Lightmap-7_comp_light.exr   |  Bin 0 -> 307770 bytes
 .../Mapa grande/Lightmap-7_comp_light.exr.meta     |  127 +
 .../Scenes/Mapa grande/Lightmap-8_comp_dir.png     |  Bin 0 -> 52116 bytes
 .../Mapa grande/Lightmap-8_comp_dir.png.meta       |  127 +
 .../Scenes/Mapa grande/Lightmap-8_comp_light.exr   |  Bin 0 -> 305685 bytes
 .../Mapa grande/Lightmap-8_comp_light.exr.meta     |  127 +
 .../Scenes/Mapa grande/Lightmap-9_comp_dir.png     |  Bin 0 -> 54430 bytes
 .../Mapa grande/Lightmap-9_comp_dir.png.meta       |  127 +
 .../Scenes/Mapa grande/Lightmap-9_comp_light.exr   |  Bin 0 -> 307360 bytes
 .../Mapa grande/Lightmap-9_comp_light.exr.meta     |  127 +
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |   14 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |    8 +-
 Supermarkert Run/Assets/Scenes/Menu_principal.meta |    8 +
 .../Assets/Scenes/Menu_principal.unity             |   86 +-
 .../Scenes/Menu_principal/LightingData.asset       |  Bin 0 -> 18928 bytes
 .../Scenes/Menu_principal/LightingData.asset.meta  |    8 +
 .../Scenes/Menu_principal/Lightmap-0_comp_dir.png  |  Bin 0 -> 45665 bytes
 .../Menu_principal/Lightmap-0_comp_dir.png.meta    |  127 +
 .../Menu_principal/Lightmap-0_comp_light.exr       |  Bin 0 -> 183514 bytes
 .../Menu_principal/Lightmap-0_comp_light.exr.meta  |  127 +
 .../Scenes/Menu_principal/Lightmap-1_comp_dir.png  |  Bin 0 -> 36875 bytes
 .../Menu_principal/Lightmap-1_comp_dir.png.meta    |  127 +
 .../Menu_principal/Lightmap-1_comp_light.exr       |  Bin 0 -> 197544 bytes
 .../Menu_principal/Lightmap-1_comp_light.exr.meta  |  127 +
 .../Scenes/Menu_principal/Lightmap-2_comp_dir.png  |  Bin 0 -> 38854 bytes
 .../Menu_principal/Lightmap-2_comp_dir.png.meta    |  127 +
 .../Menu_principal/Lightmap-2_comp_light.exr       |  Bin 0 -> 209049 bytes
 .../Menu_principal/Lightmap-2_comp_light.exr.meta  |  127 +
 .../Scenes/Menu_principal/ReflectionProbe-0.exr    |  Bin 0 -> 136700 bytes
 .../Menu_principal/ReflectionProbe-0.exr.meta      |  127 +
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |    2 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |    2 +-
 .../Scripts/Juego/Mapa/Mapa_peque\303\261o.asset"  |    2 +-
 .../Assets/Scripts/PowerUp/Manos_Rapidas.cs        |    6 +
 .../Assets/Scripts/PowerUp/Proteccion.cs           |    6 +
 .../Assets/Scripts/PowerUp/Velocidad.cs            |    6 +
 .../Assets/Scripts/PowerUp/Vida_extra.cs           |    7 +
 .../Assets/textures/Jugador_Enemigo.meta           |    8 +
 .../Assets/textures/Jugador_Enemigo/Sombra.mat     |   83 +
 .../textures/Jugador_Enemigo/Sombra.mat.meta       |    8 +
 Supermarkert Run/Assets/textures/Mapas.meta        |    8 +
 Supermarkert Run/Assets/textures/Mapas/Grande.meta |    8 +
 .../Assets/textures/Mapas/Grande/Captura2.PNG      |  Bin 0 -> 1123567 bytes
 .../Assets/textures/Mapas/Grande/Captura2.PNG.meta |  127 +
 .../Assets/textures/Mapas/Grande/Grande.PNG        |  Bin 0 -> 948486 bytes
 .../Assets/textures/Mapas/Grande/Grande.PNG.meta   |  127 +
 .../Assets/textures/Mapas/Mediano.meta             |    8 +
 .../Assets/textures/Mapas/Mediano/Captura1.PNG     |  Bin 0 -> 755399 bytes
 .../textures/Mapas/Mediano/Captura1.PNG.meta       |  127 +
 .../Assets/textures/Mapas/Mediano/Captura2.PNG     |  Bin 0 -> 966939 bytes
 .../textures/Mapas/Mediano/Captura2.PNG.meta       |  127 +
 .../Assets/textures/Mapas/Peque\303\261o.meta"     |    8 +
 .../Peque\303\261o/MapaPeque\303\261oVista.PNG"    |  Bin 0 -> 516355 bytes
 .../MapaPeque\303\261oVista.PNG.meta"              |  127 +
 .../Peque\303\261o/MapaPeque\303\261oVista2.PNG"   |  Bin 0 -> 820945 bytes
 .../MapaPeque\303\261oVista2.PNG.meta"             |  127 +
 Supermarkert Run/Assets/textures/PowerUp.meta      |    8 +
 .../Assets/textures/PowerUp/ExtraLife.jpg          |  Bin 0 -> 31750 bytes
 .../Assets/textures/PowerUp/ExtraLife.jpg.meta     |  127 +
 .../Assets/textures/PowerUp/ExtraLife.mat          |   83 +
 .../Assets/textures/PowerUp/ExtraLife.mat.meta     |    8 +
 .../Assets/textures/PowerUp/Manos Rapidas.jpg      |  Bin 0 -> 40710 bytes
 .../Assets/textures/PowerUp/Manos Rapidas.jpg.meta |  127 +
 .../Assets/textures/PowerUp/Manos Rapidas.mat      |   83 +
 .../Assets/textures/PowerUp/Manos Rapidas.mat.meta |    8 +
 .../Assets/textures/PowerUp/Protetion.jpg          |  Bin 0 -> 32985 bytes
 .../Assets/textures/PowerUp/Protetion.jpg.meta     |  127 +
 .../Assets/textures/PowerUp/Protetion.mat          |   83 +
 .../Assets/textures/PowerUp/Protetion.mat.meta     |    8 +
 Supermarkert Run/Assets/textures/PowerUp/Speed.PNG |  Bin 0 -> 16417 bytes
 .../Assets/textures/PowerUp/Speed.PNG.meta         |  127 +
 Supermarkert Run/Assets/textures/PowerUp/Speed.mat |   83 +
 .../Assets/textures/PowerUp/Speed.mat.meta         |    8 +
 .../Assets/textures/Supermercado/Estante.mat       |    2 +-
 185 files changed, 15468 insertions(+), 466 deletions(-)

=== COMMIT: 8208ab0 | Tue Nov 12 18:36:12 2024 -0600 | Modificaciones: hacer que los objetos cercanos se vuelvan invisibles. Arreglar bugs: El bug de materia de un scriptable object ===
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 15 ++++
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 15 ++++
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 15 ++++
 .../Scripts/Jugador/Camara_Objetos_Desaparecer.cs  | 51 +++++++++++++
 .../Jugador/Camara_Objetos_Desaparecer.cs.meta     | 11 +++
 Supermarkert Run/Assets/datos.json                 |  2 +-
 .../textures/Supermercado/Estante_Oculto.mat       | 85 ++++++++++++++++++++++
 .../textures/Supermercado/Estante_Oculto.mat.meta  |  8 ++
 8 files changed, 201 insertions(+), 1 deletion(-)

=== COMMIT: 5ed221f | Tue Nov 12 21:21:28 2024 -0600 | Modificaciones y agregos: Sistema de graficos sencilla ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          |  118 +-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   50 +-
 .../Assets/Scenes/Menu_principal.unity             | 2973 ++++++++++++++++++--
 .../Assets/Scripts/Juego/Configuraciones.meta      |    8 +
 .../Scripts/Juego/Configuraciones/Calidad.cs       |   33 +
 .../Scripts/Juego/Configuraciones/Calidad.cs.meta  |   11 +
 .../Scripts/Juego/Configuraciones/Sombras.cs       |   17 +
 .../Scripts/Juego/Configuraciones/Sombras.cs.meta  |   11 +
 .../Assets/Scripts/Juego/Gameplay/Contenido.cs     |    2 +
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |    9 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |    8 +
 Supermarkert Run/Assets/datos.json                 |    2 +-
 .../ProjectSettings/QualitySettings.asset          |   77 +-
 13 files changed, 2907 insertions(+), 412 deletions(-)

=== COMMIT: 09b5591 | Thu Nov 14 20:57:07 2024 -0600 | Arreglo de bugs: de sombras en pocas resoluciones, y de material carrito. Modificaciones: Mapas mediano y grande ya con precio ===
 .../Scripts/Juego/Configuraciones/Calidad.cs       | 15 +++-
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |  2 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |  2 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  2 +-
 Supermarkert Run/Assets/datos.json                 |  2 +-
 .../ProjectSettings/ProjectSettings.asset          | 95 +++++++++++++++++++++-
 6 files changed, 111 insertions(+), 7 deletions(-)

=== COMMIT: 52b52dc | Sat Nov 16 14:55:26 2024 -0600 | Cambios: Cambiar a android, Agregar luces dinamicas o estaticas, agregar sombras a los carritos, seleccion de luces dinamicas o estaticas ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          | 274 ++++++-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  | 266 +++++++
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |   6 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |   8 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  32 +-
 .../Assets/Scenes/Menu_principal.unity             | 821 ++++++++++++++++++++-
 .../Scripts/Juego/Configuraciones/Calidad.cs       |  34 +-
 .../Juego/Gameplay/Pase_Conexion_Menu_Gameplay.cs  |   1 +
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |  11 +
 .../ProjectSettings/ProjectSettings.asset          |   2 +-
 10 files changed, 1393 insertions(+), 62 deletions(-)

=== COMMIT: f6a675a | Wed Nov 20 20:03:00 2024 -0600 | Bugs:Arreglar bugs esteticos del menu principal, Modificaciones: Agregar distancia y flecha para marcar objetivo ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          |  72 +++++
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     | 135 +++++++++
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   2 +
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |  48 ++--
 Supermarkert Run/Assets/Objetos/Muerte 1.prefab    | 135 +++++++++
 Supermarkert Run/Assets/Objetos/UI 1.prefab        | 285 +++++++++++++++++--
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |  32 +++
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  32 +++
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  32 +++
 .../Assets/Scenes/Menu_principal.unity             | 120 ++++----
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   1 +
 .../Scripts/Jugador/Camara_Objetos_Desaparecer.cs  |   4 +
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  | 181 +++++++++++-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   1 +
 .../LiberationSans SDF - Fallback.asset            | 311 +--------------------
 .../textures/Jugador_Enemigo/Flecha_Guia.png       | Bin 0 -> 4578 bytes
 .../textures/Jugador_Enemigo/Flecha_Guia.png.meta  | 140 ++++++++++
 .../textures/Supermercado/Estante_Oculto.mat       |   2 +-
 .../ProjectSettings/BurstAotSettings_Android.json  |  17 ++
 .../ProjectSettings/ProjectSettings.asset          |   4 +-
 20 files changed, 1150 insertions(+), 404 deletions(-)

=== COMMIT: 0e2e43f | Thu Nov 21 18:17:47 2024 -0600 | Arreglar bugs, modificaciones: de detectar las cajas, y mejorar los power up en tema de legibilidad, modificar objetos ===
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |     2 +-
 .../Assets/Objetos/Jugador/Jugador/Pivote.prefab   |   140 +
 .../Objetos/Jugador/Jugador/Pivote.prefab.meta     |     7 +
 .../Assets/Objetos/Mapa/Caja/mostrador.prefab      |    12 +-
 .../Assets/Objetos/Objetos_Colocados/Escoba.meta   |     8 +
 .../Escoba/ImageToStl.com_escoba_low_semana10.zip  |   Bin 0 -> 26091 bytes
 .../ImageToStl.com_escoba_low_semana10.zip.meta    |     7 +
 .../Objetos/Objetos_Colocados/Escoba/escoba.obj    |  3304 +
 .../Objetos_Colocados/Escoba/escoba.obj.meta       |   109 +
 .../Escoba/escoba_low_semana10.mtl                 |    42 +
 .../Escoba/escoba_low_semana10.mtl.meta            |     7 +
 .../Objetos/Objetos_Colocados/Escoba/readme.txt    |     3 +
 .../Objetos_Colocados/Escoba/readme.txt.meta       |     7 +
 .../Objetos/Objetos_Colocados/Hamburguesa.meta     |     8 +
 .../Objetos_Colocados/Hamburguesa/burger.mtl       |    82 +
 .../Objetos_Colocados/Hamburguesa/burger.mtl.meta  |     7 +
 .../Objetos_Colocados/Hamburguesa/hamburguesa.obj  | 76500 +++++++++++++++++++
 .../Hamburguesa/hamburguesa.obj.meta               |   109 +
 .../Objetos_Colocados/Hamburguesa/readme.txt       |     3 +
 .../Objetos_Colocados/Hamburguesa/readme.txt.meta  |     7 +
 .../Assets/Objetos/Objetos_Colocados/Libro.meta    |     8 +
 .../Objetos_Colocados/Libro/book_low_poly.mtl      |    52 +
 .../Objetos_Colocados/Libro/book_low_poly.mtl.meta |     7 +
 .../Objetos_Colocados/Libro/libro - copia.obj      |  1015 +
 .../Objetos_Colocados/Libro/libro - copia.obj.meta |   129 +
 .../Objetos/Objetos_Colocados/Libro/libro.obj      |  1015 +
 .../Objetos/Objetos_Colocados/Libro/libro.obj.meta |   109 +
 .../Objetos_Colocados/Libro/mat0 - copia.mat       |    84 +
 .../Objetos_Colocados/Libro/mat0 - copia.mat.meta  |     8 +
 .../Objetos/Objetos_Colocados/Libro/mat0.mat       |    83 +
 .../Objetos/Objetos_Colocados/Libro/mat0.mat.meta  |     8 +
 .../Objetos_Colocados/Libro/mat1 - copia.mat       |    83 +
 .../Objetos_Colocados/Libro/mat1 - copia.mat.meta  |     8 +
 .../Objetos/Objetos_Colocados/Libro/mat1.mat       |    83 +
 .../Objetos/Objetos_Colocados/Libro/mat1.mat.meta  |     8 +
 .../Objetos_Colocados/Libro/mat2 - copia.mat       |    83 +
 .../Objetos_Colocados/Libro/mat2 - copia.mat.meta  |     8 +
 .../Objetos/Objetos_Colocados/Libro/mat2.mat       |    83 +
 .../Objetos/Objetos_Colocados/Libro/mat2.mat.meta  |     8 +
 .../Objetos_Colocados/Libro/mat3 - copia.mat       |    83 +
 .../Objetos_Colocados/Libro/mat3 - copia.mat.meta  |     8 +
 .../Objetos/Objetos_Colocados/Libro/mat3.mat       |    83 +
 .../Objetos/Objetos_Colocados/Libro/mat3.mat.meta  |     8 +
 .../Objetos/Objetos_Colocados/Libro/readme.txt     |     3 +
 .../Objetos_Colocados/Libro/readme.txt.meta        |     7 +
 .../Assets/Objetos/Objetos_Colocados/Manzana.meta  |     8 +
 .../Manzana/Gradient_baseColor.png                 |   Bin 0 -> 9813 bytes
 .../Manzana/Gradient_baseColor.png.meta            |   140 +
 .../Objetos/Objetos_Colocados/Manzana/manzana.obj  |  1448 +
 .../Objetos_Colocados/Manzana/manzana.obj.meta     |   109 +
 .../Manzana/red_apple_low_poly.glb                 |   Bin 0 -> 33144 bytes
 .../Manzana/red_apple_low_poly.glb.meta            |     7 +
 .../Manzana/red_apple_low_poly.mtl                 |    23 +
 .../Manzana/red_apple_low_poly.mtl.meta            |     7 +
 .../Objetos/Objetos_Colocados/Microondas.meta      |     8 +
 .../Objetos_Colocados/Microondas/Materials.meta    |     8 +
 .../Microondas/Materials/Microondas.mat            |    83 +
 .../Microondas/Materials/Microondas.mat.meta       |     8 +
 .../Microondas/Materials/RGB_texture_baseColor.mat |    83 +
 .../Materials/RGB_texture_baseColor.mat.meta       |     8 +
 .../Microondas/RGB_texture_baseColor 1.png         |   Bin 0 -> 3363 bytes
 .../Microondas/RGB_texture_baseColor 1.png.meta    |   140 +
 .../Microondas/RGB_texture_baseColor 2.png         |   Bin 0 -> 3403 bytes
 .../Microondas/RGB_texture_baseColor 2.png.meta    |   140 +
 .../Microondas/RGB_texture_baseColor.png           |   Bin 0 -> 281739 bytes
 .../Microondas/RGB_texture_baseColor.png.meta      |   140 +
 .../Microondas/RGB_texture_baseColor2.png          |   Bin 0 -> 5125 bytes
 .../Microondas/RGB_texture_baseColor2.png.meta     |   140 +
 .../Objetos_Colocados/Microondas/microondas.obj    |   209 +
 .../Microondas/microondas.obj.meta                 |   114 +
 .../Microondas/microwave_low_poly.mtl              |    23 +
 .../Microondas/microwave_low_poly.mtl.meta         |     7 +
 .../Objetos_Colocados/Microondas/readme.txt        |     3 +
 .../Objetos_Colocados/Microondas/readme.txt.meta   |     7 +
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |   112 -
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |   790 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |   326 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |   190 +-
 .../Assets/Scenes/Menu_principal.unity             |   154 +-
 .../Scripts/Car Supermarkert/Liviano/Liviano.asset |     2 +-
 .../Car Supermarkert/Liviano/Liviano2.asset        |     2 +-
 .../Scripts/Car Supermarkert/Mediano/Mediano.asset |     2 +-
 .../Car Supermarkert/Mediano/Mediano2.asset        |     2 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |     2 +
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |    21 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    84 +-
 .../Assets/Scripts/PowerUp/Interfaz_PowerUp.cs     |     9 +-
 .../Assets/Scripts/PowerUp/Manos_Rapidas.cs        |    11 +-
 .../Assets/Scripts/PowerUp/Proteccion.cs           |    14 +-
 .../Assets/Scripts/PowerUp/Repartir_power.cs       |    14 +-
 .../Assets/Scripts/PowerUp/Velocidad.cs            |    15 +-
 .../Assets/Scripts/PowerUp/Vida_extra.cs           |    13 +-
 .../Assets/Scripts/estantes/Estante.cs             |     7 +
 Supermarkert Run/Assets/datos.json                 |     2 +-
 .../Assets/textures/Jugador_Enemigo/Flecha.mat     |    85 +
 .../textures/Jugador_Enemigo/Flecha.mat.meta       |     8 +
 96 files changed, 87394 insertions(+), 772 deletions(-)

=== COMMIT: 6467882 | Thu Nov 21 18:47:50 2024 -0600 | Modificaciones: solucion de libros mal spawneados, pequeño acomodo en el UI ===
 .../Objetos_Colocados/Libro/libro - copia.obj.meta |   2 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        | 155 ++-------------------
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  33 ++---
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |   2 +
 .../Car Supermarkert/Liviano/Liviano2.asset        |   2 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   3 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   4 +-
 .../Assets/Scripts/estantes/Estante.cs             |   1 +
 Supermarkert Run/Assets/datos.json                 |   2 +-
 9 files changed, 33 insertions(+), 171 deletions(-)

=== COMMIT: fb6948e | Mon Nov 25 20:50:53 2024 -0600 | Modificaciones, Bugs: Colliders ajustados evitar salir del mapa, nuevas mecanicas al dejar objetos o tocar un charco, detener el vehiculo despues de un tiempo o en el momento, evitar duplicar dinero al perder, arreglar bug de Power Up no volverse nulo, Modificar tamaños de UI en el player, Eliminar flecha ===
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   | 267 ++-------------------
 .../Assets/Objetos/Mapa/Fila2 Variant.prefab       |   8 +
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |  16 ++
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |  44 ++--
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 119 ++++-----
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 155 ++++++------
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 119 +++++----
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |  33 ++-
 .../Car Supermarkert/Liviano/Liviano2.asset        |   2 +-
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs      |   4 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   3 +-
 Supermarkert Run/Assets/Scripts/Jugador/DINERO.cs  |   4 +
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  | 192 +--------------
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  63 +++--
 .../Assets/Scripts/PowerUp/Repartir_power.cs       |   5 +-
 15 files changed, 335 insertions(+), 699 deletions(-)

=== COMMIT: efd78f9 | Tue Nov 26 11:38:27 2024 -0600 | Modificar colliders bugueados de los mapas, y solucionar bug de guardado de no guardar o cargar ===
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |  18 +--
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 164 ++++++++++++++++++++-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 133 ++++++++++++++++-
 .../Assets/Scenes/Menu_principal.unity             |   1 +
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |  27 +++-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |   2 +-
 Supermarkert Run/Assets/datos.json                 |   2 +-
 7 files changed, 329 insertions(+), 18 deletions(-)

=== COMMIT: b1aa224 | Tue Nov 26 15:09:39 2024 -0600 | Solucion de bugs y Modificaciones: a la hora de guardar ya no hay error y guarda de manera correcta, dinero para inicios de la beta, eliminar los textos de ubicacion de archivo y cantidad de skins, agregar reinicio cuando se inicie por primera vez ===
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  87 +++----
 .../Assets/Scenes/Menu_principal.unity             | 273 +++++++++++----------
 .../Scripts/Car Supermarkert/Liviano/Liviano.asset |   2 +-
 .../Car Supermarkert/Liviano/Liviano2.asset        |   2 +-
 .../Scripts/Car Supermarkert/Mediano/Mediano.asset |   2 +-
 .../Car Supermarkert/Mediano/Mediano2.asset        |   2 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado.asset   |   2 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado2.asset  |   2 +-
 .../Pesado/Pesado_personalizado.asset              |   2 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |  14 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   1 -
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  11 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |   2 +
 Supermarkert Run/Assets/datos.json                 |   2 +-
 14 files changed, 191 insertions(+), 213 deletions(-)

=== COMMIT: fbd1e8e | Tue Nov 26 16:10:01 2024 -0600 | Solucion de error al iniciar por primera vez ===
 Supermarkert Run/Assets/Scenes/Menu_principal.unity                | 2 +-
 Supermarkert Run/Assets/Scripts/Juego/Gameplay/Sistema_Guardado.cs | 2 +-
 Supermarkert Run/Assets/datos.json                                 | 2 +-
 Supermarkert Run/Assets/personalizado.json                         | 2 +-
 .../Assets/textures/Carritos/Grande/PersonalizadaGra.mat           | 2 +-
 .../Assets/textures/Carritos/Mediano/PersonalizadaMed.mat          | 2 +-
 .../Assets/textures/Carritos/Pequenio/Personalizada.mat            | 2 +-
 Supermarkert Run/Assets/textures/datos.json                        | 1 +
 Supermarkert Run/Assets/textures/datos.json.meta                   | 7 +++++++
 Supermarkert Run/Assets/textures/personalizado.json                | 1 +
 Supermarkert Run/Assets/textures/personalizado.json.meta           | 7 +++++++
 11 files changed, 23 insertions(+), 7 deletions(-)

=== COMMIT: 42c0ff5 | Tue Nov 26 17:07:30 2024 -0600 | Sistema de guardado de mapas ===
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     | 38 ++++++++++++++++++----
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |  1 +
 Supermarkert Run/Assets/datos.json                 |  2 +-
 Supermarkert Run/Assets/mapa.txt                   |  0
 Supermarkert Run/Assets/mapa.txt.meta              |  7 ++++
 5 files changed, 41 insertions(+), 7 deletions(-)

=== COMMIT: 7f1bb30 | Wed Nov 27 17:50:48 2024 -0600 | Modificaciones: Bajar luz al sol de mapa grande y hacer sistema para detectar filas y ocultarlas ===
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |  2 +-
 .../Scripts/Jugador/Camara_Objetos_Desaparecer.cs  | 61 ++++++++++++++++++----
 Supermarkert Run/Assets/datos.json                 |  2 +-
 Supermarkert Run/Assets/mapa.txt                   |  1 +
 4 files changed, 55 insertions(+), 11 deletions(-)

=== COMMIT: b9e8961 | Thu Nov 28 13:49:06 2024 -0600 | Modificaciones: Menos luz en el mapa grande, tamaño hamburguesa, hacer ya charco de agua con modelos.Arreglo de bugs: Arreglar bug con el codigo de fila en ocultar liga ===
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |  183 +
 .../Assets/Objetos/Mapa/Charco_Agua.prefab.meta    |    7 +
 .../Assets/Objetos/Mapa/Signal_Water.meta          |    8 +
 .../Assets/Objetos/Mapa/Signal_Water/Signal.obj    | 3316 ++++++++++++++
 .../Objetos/Mapa/Signal_Water/Signal.obj.meta      |  109 +
 .../Mapa/Signal_Water/lambert1_baseColor.jpg       |  Bin 0 -> 426249 bytes
 .../Mapa/Signal_Water/lambert1_baseColor.jpg.meta  |  140 +
 .../Signal_Water/lambert1_metallicRoughness.png    |  Bin 0 -> 165266 bytes
 .../lambert1_metallicRoughness.png.meta            |  140 +
 .../Objetos/Mapa/Signal_Water/lambert1_normal.png  |  Bin 0 -> 558046 bytes
 .../Mapa/Signal_Water/lambert1_normal.png.meta     |  140 +
 .../Assets/Objetos/Mapa/Signal_Water/readme.txt    |    3 +
 .../Objetos/Mapa/Signal_Water/readme.txt.meta      |    7 +
 .../Objetos/Mapa/Signal_Water/wet_floor_sign.mtl   |   26 +
 .../Mapa/Signal_Water/wet_floor_sign.mtl.meta      |    7 +
 .../Assets/Objetos/Mapa/Water_floor.meta           |    8 +
 .../Assets/Objetos/Mapa/Water_floor/Water.obj      | 4504 ++++++++++++++++++++
 .../Assets/Objetos/Mapa/Water_floor/Water.obj.meta |  109 +
 .../low_poly_model_for_water_puddles.mtl           |   22 +
 .../low_poly_model_for_water_puddles.mtl.meta      |    7 +
 .../Assets/Objetos/Mapa/Water_floor/readme.txt     |    3 +
 .../Objetos/Mapa/Water_floor/readme.txt.meta       |    7 +
 .../Hamburguesa/hamburguesa.obj.meta               |    4 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |    6 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |    2 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |   10 +-
 .../Assets/Scenes/Menu_principal.unity             |    1 +
 .../Scripts/Jugador/Camara_Objetos_Desaparecer.cs  |    1 +
 Supermarkert Run/Assets/datos.json                 |    2 +-
 Supermarkert Run/Assets/mapa.txt                   |    2 +-
 30 files changed, 8765 insertions(+), 9 deletions(-)

=== COMMIT: 0791f79 | Thu Nov 28 14:07:20 2024 -0600 | Arreglo de altura supuestamente ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          |   4 +-
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |   2 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 106 ---------------------
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 106 ---------------------
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 106 ---------------------
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |   2 +-
 Supermarkert Run/Assets/datos.json                 |   2 +-
 7 files changed, 5 insertions(+), 323 deletions(-)

=== COMMIT: 1589cdb | Mon Dec 9 15:38:52 2024 -0600 | Modificaciones: Agregar lenguaje español e portugues en las misiones ===
 "Supermarkert Run/Assets/Espa\303\261ol.json"      |    1 +
 "Supermarkert Run/Assets/Espa\303\261ol.json.meta" |    7 +
 Supermarkert Run/Assets/Ingles.json                |    1 +
 Supermarkert Run/Assets/Ingles.json.meta           |    7 +
 Supermarkert Run/Assets/Portugues.json             |    1 +
 Supermarkert Run/Assets/Portugues.json.meta        |    7 +
 .../Assets/Scenes/Menu_principal.unity             | 1581 ++++++++++++++++++--
 .../Scripts/Juego/Configuraciones/Calidad.cs       |    7 +
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |    8 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |  116 +-
 .../Assets/Scripts/estantes/Contenido_misiones.cs  |   16 +
 .../Scripts/estantes/Contenido_misiones.cs.meta    |   11 +
 Supermarkert Run/Assets/datos.json                 |    2 +-
 Supermarkert Run/Assets/mapa.txt                   |    2 +-
 14 files changed, 1638 insertions(+), 129 deletions(-)

=== COMMIT: 7ea41cf | Tue Dec 10 16:26:17 2024 -0600 | Agregar: el ingles, español, portugues en otras secciones del menu principal ===
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 36 ++++++++
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 36 ++++++++
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 36 ++++++++
 .../Assets/Scenes/Menu_principal.unity             | 47 +++++++++--
 .../Scripts/Juego/Configuraciones/Calidad.cs       | 17 +++-
 .../Assets/Scripts/Juego/Configuraciones/Idioma.cs | 97 ++++++++++++++++++++++
 .../Scripts/Juego/Configuraciones/Idioma.cs.meta   | 11 +++
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |  6 --
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    | 10 +--
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |  2 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      | 15 ++--
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |  6 --
 Supermarkert Run/Assets/datos.json                 |  2 +-
 13 files changed, 287 insertions(+), 34 deletions(-)

=== COMMIT: 73b4216 | Wed Dec 11 18:02:23 2024 -0600 | Arreglar bug de nivel no avanza, fila1 prefab fallaba un estante sin collision agregamos collision. Agregar imagen a UI para cuando dejas cosas, Visualizacion de dinero ganado. ===
 Supermarkert Run/Assets/Font/ARCO SDF.asset        |   2 +-
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     | 137 ++++++-
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |  27 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |  76 ++++
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |  24 ++
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  24 ++
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  55 ++-
 .../Assets/Scenes/Menu_principal.unity             | 454 +++++++++++++--------
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |  14 +-
 .../Scripts/Juego/Configuraciones/Calidad.cs       |   5 +-
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs      |   2 +-
 .../Assets/Scripts/Juego/Gameplay/Nivel.cs         |   4 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   7 +-
 .../Assets/Scripts/Juego/Gameplay/Tiempo.cs        |   6 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   6 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  28 +-
 Supermarkert Run/Assets/datos.json                 |   2 +-
 17 files changed, 667 insertions(+), 206 deletions(-)

=== COMMIT: 9241ca2 | Thu Dec 12 15:49:01 2024 -0600 | Agregar: nuevo modelo carrito, imagenes para UI.Modificar: UI de menu principal y juego.Arreglar: Bug de seleccion de carrito en el player. ===
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |     10 +-
 Supermarkert Run/Assets/Objetos/Shopping.meta      |      8 +
 Supermarkert Run/Assets/Objetos/Shopping.zip       |    Bin 0 -> 2102182 bytes
 Supermarkert Run/Assets/Objetos/Shopping.zip.meta  |      7 +
 ...1.123c67bbc848-b9e3-4edb-aab4-7c4475e3d08c.meta |      8 +
 .../18534_Shopping_Cart_v1.obj                     | 215085 ++++++++++++++++++
 .../18534_Shopping_Cart_v1.obj.meta                |    109 +
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |    256 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |      8 +
 .../Assets/Scenes/Menu_principal.unity             |   2343 +-
 .../Scripts/Car Supermarkert/Mediano/Mediano.asset |      2 +-
 .../Car Supermarkert/Mediano/Mediano2.asset        |      2 +-
 .../Scripts/Car Supermarkert/Personalizacion.cs    |     10 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado.asset   |      2 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado2.asset  |      2 +-
 .../Assets/Scripts/Juego/Configuraciones/Idioma.cs |      4 +-
 .../Juego/Gameplay/Pase_Conexion_Menu_Gameplay.cs  |      1 +
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |      4 +-
 .../Assets/Scripts/Juego/Gameplay/Tiempo.cs        |      4 +-
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |      6 +
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |      1 -
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |     32 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |     22 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |     10 +-
 Supermarkert Run/Assets/datos.json                 |      2 +-
 Supermarkert Run/Assets/textures/Menu/Carga.png    |    Bin 0 -> 70358 bytes
 .../Assets/textures/Menu/Carga.png.meta            |    140 +
 Supermarkert Run/Assets/textures/Menu/Choque.png   |    Bin 0 -> 35867 bytes
 .../Assets/textures/Menu/Choque.png.meta           |    140 +
 .../Assets/textures/Menu/Comprar_Aceptar.png       |    Bin 0 -> 22284 bytes
 .../Assets/textures/Menu/Comprar_Aceptar.png.meta  |    140 +
 .../Assets/textures/Menu/Configuracion.png         |    Bin 0 -> 122491 bytes
 .../Assets/textures/Menu/Configuracion.png.meta    |    140 +
 Supermarkert Run/Assets/textures/Menu/Mapa.png     |    Bin 0 -> 21168 bytes
 .../Assets/textures/Menu/Mapa.png.meta             |    140 +
 Supermarkert Run/Assets/textures/Menu/Mision.png   |    Bin 0 -> 126578 bytes
 .../Assets/textures/Menu/Mision.png.meta           |    140 +
 .../Assets/textures/Menu/Personalizacion.png       |    Bin 0 -> 40108 bytes
 .../Assets/textures/Menu/Personalizacion.png.meta  |    140 +
 Supermarkert Run/Assets/textures/Menu/Peso 1.png   |    Bin 0 -> 18567 bytes
 .../Assets/textures/Menu/Peso 1.png.meta           |    140 +
 Supermarkert Run/Assets/textures/Menu/Peso.png     |    Bin 0 -> 18567 bytes
 .../Assets/textures/Menu/Peso.png.meta             |    140 +
 .../Assets/textures/Menu/Requisitos 1.png          |    Bin 0 -> 27851 bytes
 .../Assets/textures/Menu/Requisitos 1.png.meta     |    140 +
 .../Assets/textures/Menu/Requisitos.png            |    Bin 0 -> 27851 bytes
 .../Assets/textures/Menu/Requisitos.png.meta       |    140 +
 Supermarkert Run/Assets/textures/Menu/Speed.PNG    |    Bin 0 -> 16417 bytes
 .../Assets/textures/Menu/Speed.PNG.meta            |    140 +
 Supermarkert Run/Assets/textures/Menu/Tiempo 1.png |    Bin 0 -> 5981 bytes
 .../Assets/textures/Menu/Tiempo 1.png.meta         |    140 +
 Supermarkert Run/Assets/textures/Menu/Tiempo.png   |    Bin 0 -> 5981 bytes
 .../Assets/textures/Menu/Tiempo.png.meta           |    140 +
 .../Assets/textures/PowerUp/proteccion2 1.png      |    Bin 0 -> 290332 bytes
 .../Assets/textures/PowerUp/proteccion2 1.png.meta |    140 +
 .../Assets/textures/PowerUp/proteccion2.png        |    Bin 0 -> 290332 bytes
 .../Assets/textures/PowerUp/proteccion2.png.meta   |    140 +
 .../Assets/textures/PowerUp/vidaextra2 1.png       |    Bin 0 -> 157100 bytes
 .../Assets/textures/PowerUp/vidaextra2 1.png.meta  |    140 +
 .../Assets/textures/PowerUp/vidaextra2.png         |    Bin 0 -> 157100 bytes
 .../Assets/textures/PowerUp/vidaextra2.png.meta    |    140 +
 61 files changed, 220268 insertions(+), 190 deletions(-)

=== COMMIT: 651c179 | Thu Dec 12 21:06:07 2024 -0600 | Agregar: Mas textos a los idiomas ===
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |  20 +-
 .../Assets/Scenes/Menu_principal.unity             | 370 ++++++---------------
 .../Scripts/Juego/Configuraciones/Calidad.cs       |  19 ++
 Supermarkert Run/Assets/datos.json                 |   2 +-
 4 files changed, 139 insertions(+), 272 deletions(-)

=== COMMIT: 46f49cc | Sat Dec 14 15:54:50 2024 -0600 | Agrandar UI ===
 Supermarkert Run/Assets/Objetos/UI 1.prefab | 24 ++++++++++++------------
 1 file changed, 12 insertions(+), 12 deletions(-)

=== COMMIT: aa0b3c8 | Tue Dec 17 17:17:42 2024 -0600 | Modificar: Texturas a unas iluminadas.Arreglar bugs: el de sistema de guardado de mapa ===
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     |    4 +-
 Supermarkert Run/Assets/Objetos/Muerte 1.prefab    |  236 ++++-
 .../Assets/Objetos/Objetos_Colocados/Caja.mat      |   16 +-
 .../Objetos/Objetos_Colocados/Caja_Leche.mat       |   26 +-
 .../mat3 - copia.mat.meta => Escoba/Material.meta} |    6 +-
 .../Escoba/Material/mat0 - copia.mat               |   84 ++
 .../Material}/mat0 - copia.mat.meta                |    2 +-
 .../{Libro => Escoba/Material}/mat0.mat            |    4 +-
 .../{Libro => Escoba/Material}/mat0.mat.meta       |    2 +-
 .../{Libro => Escoba/Material}/mat1.mat            |    4 +-
 .../{Libro => Escoba/Material}/mat1.mat.meta       |    2 +-
 .../Objetos_Colocados/Escoba/Material/mat2.mat     |   83 ++
 .../{Libro => Escoba/Material}/mat2.mat.meta       |    2 +-
 .../Objetos_Colocados/Escoba/escoba.obj.meta       |   17 +-
 .../Objetos_Colocados/Hamburguesa/Materiales.meta  |    8 +
 .../Materiales/mat0.mat}                           |    4 +-
 .../Hamburguesa/Materiales/mat0.mat.meta           |    8 +
 .../Hamburguesa/Materiales/mat1.mat                |   83 ++
 .../Hamburguesa/Materiales/mat1.mat.meta           |    8 +
 .../{Libro => Hamburguesa/Materiales}/mat2.mat     |    4 +-
 .../Hamburguesa/Materiales/mat2.mat.meta           |    8 +
 .../{Libro => Hamburguesa/Materiales}/mat3.mat     |    4 +-
 .../Materiales}/mat3.mat.meta                      |    2 +-
 .../Hamburguesa/Materiales/mat4.mat                |   83 ++
 .../Hamburguesa/Materiales/mat4.mat.meta           |    8 +
 .../Hamburguesa/Materiales/mat5.mat                |   83 ++
 .../Hamburguesa/Materiales/mat5.mat.meta           |    8 +
 .../Materiales/mat6.mat}                           |    4 +-
 .../Hamburguesa/Materiales/mat6.mat.meta           |    8 +
 .../Hamburguesa/Materiales/materiacop.mat          |   84 ++
 .../Materiales/materiacop.mat.meta}                |    2 +-
 .../Hamburguesa/hamburguesa.obj.meta               |   37 +-
 .../Objetos/Objetos_Colocados/Libro/Material.meta  |    8 +
 .../Libro/Material/mat0 - copia.mat                |   84 ++
 .../mat0 - copia.mat.meta}                         |    2 +-
 .../Objetos_Colocados/Libro/Material/mat0.mat      |   83 ++
 .../Objetos_Colocados/Libro/Material/mat0.mat.meta |    8 +
 .../Objetos_Colocados/Libro/Material/mat1.mat      |   83 ++
 .../Objetos_Colocados/Libro/Material/mat1.mat.meta |    8 +
 .../Objetos_Colocados/Libro/Material/mat2.mat      |   83 ++
 .../Objetos_Colocados/Libro/Material/mat2.mat.meta |    8 +
 .../Objetos_Colocados/Libro/Material/mat3.mat      |   83 ++
 .../Objetos_Colocados/Libro/Material/mat3.mat.meta |    8 +
 .../Objetos_Colocados/Libro/libro - copia.obj      | 1015 --------------------
 .../Objetos_Colocados/Libro/libro - copia.obj.meta |  129 ---
 .../Objetos/Objetos_Colocados/Libro/libro.obj.meta |   22 +-
 .../Objetos_Colocados/Libro/mat0 - copia.mat       |   84 --
 .../Objetos_Colocados/Manzana/Materials.meta       |    8 +
 .../Manzana/Materials/Gradient_baseColor.mat       |   84 ++
 .../Manzana/Materials/Gradient_baseColor.mat.meta  |    8 +
 .../Microondas/Materials/Microondas.mat            |   11 +-
 .../Microondas/Materials/RGB_texture_baseColor.mat |    7 +-
 .../Objetos_Colocados/PepelHigienico.obj.meta      |    7 +-
 .../Assets/Objetos/Objetos_Colocados/rollo.mat     |   84 ++
 .../Objetos/Objetos_Colocados/rollo.mat.meta       |    8 +
 .../{18534_Shopping_Cart_v1.obj => Carrito.obj}    |    0
 ..._Shopping_Cart_v1.obj.meta => Carrito.obj.meta} |    4 +-
 .../carro.mat}                                     |    4 +-
 .../carro.mat.meta                                 |    8 +
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |    4 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |    2 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |    2 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |    4 +-
 .../Assets/Scenes/Menu_principal.unity             |    2 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |    2 +-
 .../Assets/Scripts/Juego/Gameplay/Tiempo.cs        |    8 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |    2 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |    2 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    1 +
 Supermarkert Run/Assets/datos.json                 |    2 +-
 Supermarkert Run/Assets/mapa.txt                   |    3 +-
 Supermarkert Run/Assets/textures/Menu/tiempo2.png  |  Bin 0 -> 37535 bytes
 .../Assets/textures/Menu/tiempo2.png.meta          |  140 +++
 .../Assets/textures/Supermercado/Suelo2.mat        |   83 ++
 .../Assets/textures/Supermercado/Suelo2.mat.meta   |    8 +
 75 files changed, 1836 insertions(+), 1304 deletions(-)

=== COMMIT: 8ebf482 | Sat Dec 28 22:22:34 2024 -0600 | Modificar: carrito supermercado a jugador, enemigo y menu. Agregar: pequeña animacion a la seleccion de carritos ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          | 1664 +++++++------------
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  | 1686 +++++++-------------
 .../Assets/Objetos/Objetos_Colocados/Caja.mat      |    2 +-
 .../Objetos/Objetos_Colocados/Caja_Leche.mat       |    2 +-
 .../Manzana/Materials/Gradient_baseColor.mat       |    2 +-
 .../Microondas/Materials/Microondas.mat            |    2 +-
 .../Carrito_Peq.prefab                             |  152 ++
 .../Carrito_Peq.prefab.meta                        |    7 +
 .../Carrito_gra.prefab                             |  129 ++
 .../Carrito_gra.prefab.meta                        |    7 +
 .../Carrito_med.prefab                             |  129 ++
 .../Carrito_med.prefab.meta                        |    7 +
 .../Assets/Scenes/Menu_principal.unity             | 1114 +++++++------
 .../Car Supermarkert/Liviano/Liviano2.asset        |    2 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   21 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   45 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |    9 +
 Supermarkert Run/Assets/datos.json                 |    2 +-
 Supermarkert Run/Assets/mapa.txt                   |    3 +-
 19 files changed, 2289 insertions(+), 2696 deletions(-)

=== COMMIT: 6a48b47 | Tue Dec 31 18:26:13 2024 -0600 | Arreglar bugs:de colision no traspasar(prueba), seleccion de skin de carro. ===
 .../Assets/Scenes/Menu_principal.unity             |  4 +-
 .../Car Supermarkert/Liviano/Liviano2.asset        |  4 +-
 .../Car Supermarkert/Mediano/Mediano2.asset        |  2 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado2.asset  |  2 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  | 27 +++++++------
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      | 45 +++++++++++++---------
 Supermarkert Run/Assets/datos.json                 |  2 +-
 Supermarkert Run/Assets/personalizado.json         |  2 +-
 .../textures/Carritos/Grande/PersonalizadaGra.mat  |  2 +-
 .../textures/Carritos/Mediano/PersonalizadaMed.mat |  2 +-
 .../textures/Carritos/Pequenio/Personalizada.mat   |  2 +-
 11 files changed, 52 insertions(+), 42 deletions(-)

=== COMMIT: 50eda63 | Wed Jan 1 21:06:27 2025 -0600 | Particula de caminar al jugador ===
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  | 4838 ++++++++++++++++++++
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  121 +-
 Supermarkert Run/Assets/datos.json                 |    2 +-
 3 files changed, 4922 insertions(+), 39 deletions(-)

=== COMMIT: a652119 | Fri Jan 3 23:07:22 2025 -0600 | Arreglar bugs: de chocar y no detenerse.Agregar:particulas de agua al pasar un charco, texturas nuevas, particulas a vehiculos, agregar tag a enemigos.Modificar:Particulas al caminar, el UI, la colision de los enemigos y jugador. ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          |    34 +-
 Supermarkert Run/Assets/Objetos/Jugador.prefab     |   517 -
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  | 15509 ++++++++++++++++++-
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |  4847 +++++-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |    26 +-
 .../Suelo.jfif.meta => Scripts/Charco.meta}        |     3 +-
 Supermarkert Run/Assets/Scripts/Charco/Charco.cs   |    22 +
 .../Assets/Scripts/Charco/Charco.cs.meta           |    11 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    39 +-
 Supermarkert Run/Assets/datos.json                 |     2 +-
 .../Assets/textures/Supermercado/Gota_Agua.mat     |    83 +
 .../Supermercado/Gota_Agua.mat.meta}               |     5 +-
 .../Supermercado/Nubes-removebg-preview.png        |   Bin 0 -> 35422 bytes
 .../Supermercado/Nubes-removebg-preview.png.meta   |   140 +
 .../Assets/textures/Supermercado/Piso_Romper.mat   |    83 +
 .../textures/Supermercado/Piso_Romper.mat.meta     |     8 +
 .../Assets/textures/Supermercado/Suelo.jfif        |   Bin 817733 -> 0 bytes
 .../Assets/textures/Supermercado/gota_agua.png     |   Bin 0 -> 22567 bytes
 .../textures/Supermercado/gota_agua.png.meta       |   140 +
 .../Assets/textures/Supermercado/gota_agua2.png    |   Bin 0 -> 14964 bytes
 .../textures/Supermercado/gota_agua2.png.meta      |   140 +
 .../Supermercado/roca3-removebg-preview.png        |   Bin 0 -> 31285 bytes
 .../Supermercado/roca3-removebg-preview.png.meta   |   140 +
 Supermarkert Run/ProjectSettings/TagManager.asset  |     1 +
 24 files changed, 20713 insertions(+), 1037 deletions(-)

=== COMMIT: 61280b4 | Sat Jan 4 19:21:07 2025 -0600 | Agregar:Sonidos y partculas al chocar, resbalar, obtener cosas.Modificar:Particula de ganar a UI ===
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     | 14495 +++++++++++++++++-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  | 15117 ++++++++++++++++++-
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |    98 +
 Supermarkert Run/Assets/Objetos/UI_Camera.prefab   |    94 +
 .../Assets/Objetos/UI_Camera.prefab.meta           |     7 +
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |    67 +
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |    67 +
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |    71 +
 Supermarkert Run/Assets/Scripts/Charco/Charco.cs   |     2 +
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |     5 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    60 +-
 Supermarkert Run/Assets/Sonidos/crash-7075.wav     |   Bin 0 -> 59982 bytes
 .../Assets/Sonidos/crash-7075.wav.meta             |    23 +
 .../Assets/Sonidos/object-fall-soft-275694.wav     |   Bin 0 -> 373326 bytes
 .../Sonidos/object-fall-soft-275694.wav.meta       |    23 +
 .../Sonidos/water-splash-199583 (mp3cut.net).wav   |   Bin 0 -> 140862 bytes
 .../water-splash-199583 (mp3cut.net).wav.meta      |    23 +
 .../Assets/Sonidos/water-splash-199583.wav         |   Bin 0 -> 539214 bytes
 .../Assets/Sonidos/water-splash-199583.wav.meta    |    23 +
 Supermarkert Run/Assets/datos.json                 |     2 +-
 .../Assets/textures/Jugador_Enemigo/!.3.png        |   Bin 0 -> 1167 bytes
 .../Assets/textures/Jugador_Enemigo/!.3.png.meta   |   140 +
 .../Jugador_Enemigo/1-removebg-preview (1).png     |   Bin 0 -> 23153 bytes
 .../1-removebg-preview (1).png.meta                |   140 +
 .../Assets/textures/Jugador_Enemigo/1.2.png        |   Bin 0 -> 2946 bytes
 .../Assets/textures/Jugador_Enemigo/1.2.png.meta   |   140 +
 .../textures/Jugador_Enemigo/Exclamacion.mat       |    83 +
 .../textures/Jugador_Enemigo/Exclamacion.mat.meta  |     8 +
 .../Assets/textures/Jugador_Enemigo/Punto.mat      |    83 +
 .../Assets/textures/Jugador_Enemigo/Punto.mat.meta |     8 +
 .../Assets/textures/Jugador_Enemigo/choque.mat     |    83 +
 .../textures/Jugador_Enemigo/choque.mat.meta       |     8 +
 .../choque_animacion-removebg-preview.png          |   Bin 0 -> 110556 bytes
 .../choque_animacion-removebg-preview.png.meta     |   140 +
 .../signo_exclamacion-removebg-preview.png         |   Bin 0 -> 69833 bytes
 .../signo_exclamacion-removebg-preview.png.meta    |   140 +
 36 files changed, 30929 insertions(+), 221 deletions(-)

=== COMMIT: c7f22f5 | Sat Jan 4 22:33:09 2025 -0600 | Modificar:Particulas a la UI de ganar,modificar la funcion de mostrar ganar,imagen de dejar cosas. ===
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     |   6 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |   2 +-
 Supermarkert Run/Assets/Objetos/UI_Camera.prefab   |   9 --
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |   3 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |   3 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |   3 +-
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |   9 ++
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   2 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   8 +-
 Supermarkert Run/Assets/datos.json                 |   2 +-
 .../textures/PowerUp/Manos Rapidas - copia.jpg     | Bin 0 -> 40710 bytes
 .../PowerUp/Manos Rapidas - copia.jpg.meta         | 140 +++++++++++++++++++++
 12 files changed, 164 insertions(+), 23 deletions(-)

=== COMMIT: 5b5b68c | Sun Jan 5 21:45:22 2025 -0600 | Agregar:Nuevo modelo de jugo.Modificar:Scripts que usan particulas para ocultar las que no se usan constantemente,modificar el objeto de jugo en las areas, cambiar charco a estatico ===
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     |  12 +-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |  23 +-
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |  22 +-
 .../Assets/Objetos/Objetos_Colocados/cajaJugo.obj  | 458 +++++++++++++++++++++
 .../Objetos/Objetos_Colocados/cajaJugo.obj.meta    | 114 +++++
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 120 +++---
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  40 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  20 +-
 Supermarkert Run/Assets/Scripts/Charco/Charco.cs   |   7 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |  10 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  27 +-
 .../Assets/Scripts/PowerUp/Manos_Rapidas.cs        |   2 +-
 12 files changed, 733 insertions(+), 122 deletions(-)

=== COMMIT: 36fa3d7 | Sat Jan 11 18:57:15 2025 -0600 | Agregar: Animacion a los botones y al iniciar el juego, bake ===
 Supermarkert Run/Assets/Animaciones.meta           |    8 +
 Supermarkert Run/Assets/Animaciones/UI.meta        |    8 +
 .../Assets/Animaciones/UI/Animacion.controller     |  905 ++++++++
 .../Animaciones/UI/Animacion.controller.meta       |    8 +
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |    2 +-
 .../Assets/Scenes/Menu_principal.unity             | 2453 +++++++++++++++++++-
 .../Menu_principal/NavMesh-NavMesh Surface.asset   |  Bin 0 -> 9004 bytes
 .../NavMesh-NavMesh Surface.asset.meta             |    8 +
 .../Assets/Scripts/Juego/Menu/Animacion_Carga.cs   |   57 +
 .../Scripts/Juego/Menu/Animacion_Carga.cs.meta     |   11 +
 .../Assets/Scripts/Juego/Menu/NPC_Menu.cs          |   31 +
 .../Assets/Scripts/Juego/Menu/NPC_Menu.cs.meta     |   11 +
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |   13 +-
 .../Assets/textures/Jugador_Enemigo/Personaje.mat  |   83 +
 .../textures/Jugador_Enemigo/Personaje.mat.meta    |    8 +
 .../Assets/textures/Supermercado/Banqueta.mat      |   83 +
 .../Assets/textures/Supermercado/Banqueta.mat.meta |    8 +
 .../Assets/textures/Supermercado/Materials.meta    |    8 +
 .../textures/Supermercado/Materials/Suelo.mat      |   83 +
 .../textures/Supermercado/Materials/Suelo.mat.meta |    8 +
 .../ProjectSettings/NavMeshAreas.asset             |    2 +-
 Supermarkert Run/debug.log                         |    3 +
 22 files changed, 3743 insertions(+), 58 deletions(-)

=== COMMIT: 792ce1d | Sun Jan 12 21:10:58 2025 -0600 | Modificar: Animaciones de menu y al entrar al mapa.Agregar: Animacion de puertas a las puertas del menu e animacion, sonido a la animacion de entrada al mapa. ===
 Supermarkert Run/Assets/Animaciones/Menu.meta      |     8 +
 .../Assets/Scenes/Menu_principal.unity             | 10484 ++++++++++++++-----
 .../Menu_principal/NavMesh-NavMesh Surface.asset   |   Bin 9004 -> 11664 bytes
 .../Assets/Scripts/Juego/Menu/Animacion_Carga.cs   |    54 +-
 .../Assets/Scripts/Juego/Menu/Animacion_Puerta.cs  |    68 +
 .../Scripts/Juego/Menu/Animacion_Puerta.cs.meta    |    11 +
 .../Assets/Scripts/Juego/Menu/NPC_Menu.cs          |    29 +-
 Supermarkert Run/Assets/datos.json                 |     2 +-
 8 files changed, 7969 insertions(+), 2687 deletions(-)

=== COMMIT: 3c613ff | Sun Jan 12 21:54:22 2025 -0600 | Modificar:Bakeo de luces de menu,sky de menu.Agregar:fondo al menu ===
 .../Objetos/Luces/New Lighting Settings.lighting   |   2 +-
 .../Assets/Scenes/Menu_principal.unity             | 181 +++++++++++++++++++--
 .../Scenes/Menu_principal/LightingData.asset       | Bin 18928 -> 19240 bytes
 .../Scenes/Menu_principal/Lightmap-0_comp_dir.png  | Bin 45665 -> 50118 bytes
 .../Menu_principal/Lightmap-0_comp_dir.png.meta    |  15 +-
 .../Menu_principal/Lightmap-0_comp_light.exr       | Bin 183514 -> 238586 bytes
 .../Menu_principal/Lightmap-0_comp_light.exr.meta  |  15 +-
 .../Scenes/Menu_principal/Lightmap-1_comp_dir.png  | Bin 36875 -> 53991 bytes
 .../Menu_principal/Lightmap-1_comp_dir.png.meta    |  15 +-
 .../Menu_principal/Lightmap-1_comp_light.exr       | Bin 197544 -> 257363 bytes
 .../Menu_principal/Lightmap-1_comp_light.exr.meta  |  15 +-
 .../Scenes/Menu_principal/Lightmap-2_comp_dir.png  | Bin 38854 -> 71294 bytes
 .../Menu_principal/Lightmap-2_comp_dir.png.meta    |  15 +-
 .../Menu_principal/Lightmap-2_comp_light.exr       | Bin 209049 -> 321150 bytes
 .../Menu_principal/Lightmap-2_comp_light.exr.meta  |  15 +-
 .../Scenes/Menu_principal/Lightmap-3_comp_dir.png  | Bin 0 -> 38461 bytes
 .../Menu_principal/Lightmap-3_comp_dir.png.meta    | 140 ++++++++++++++++
 .../Menu_principal/Lightmap-3_comp_light.exr       | Bin 0 -> 205251 bytes
 .../Menu_principal/Lightmap-3_comp_light.exr.meta  | 140 ++++++++++++++++
 .../Scenes/Menu_principal/ReflectionProbe-0.exr    | Bin 136700 -> 110406 bytes
 .../Menu_principal/ReflectionProbe-0.exr.meta      |  13 ++
 Supermarkert Run/Assets/datos.json                 |   2 +-
 .../textures/Menu/Ciudad__1_-removebg-preview.png  | Bin 0 -> 311404 bytes
 .../Menu/Ciudad__1_-removebg-preview.png.meta      | 140 ++++++++++++++++
 Supermarkert Run/Assets/textures/Menu/Fondo.mat    | 109 +++++++++++++
 .../Assets/textures/Menu/Fondo.mat.meta            |   8 +
 Supermarkert Run/Assets/textures/Menu/Sky.mat      |  91 +++++++++++
 Supermarkert Run/Assets/textures/Menu/Sky.mat.meta |   8 +
 28 files changed, 905 insertions(+), 19 deletions(-)

=== COMMIT: 1d00de0 | Wed Jan 15 12:07:37 2025 -0600 | Agregar:carros para menu.Modificar texturas de varias cosas del menu ===
 Supermarkert Run/Assets/Objetos/Carrito1.meta      |     8 +
 .../Objetos/Carrito1/BodyGlass_baseColor.png       |   Bin 0 -> 34681 bytes
 .../Objetos/Carrito1/BodyGlass_baseColor.png.meta  |   140 +
 .../Objetos/Carrito1/BodyGlossy_baseColor.png      |   Bin 0 -> 886 bytes
 .../Objetos/Carrito1/BodyGlossy_baseColor.png.meta |   140 +
 .../Assets/Objetos/Carrito1/Carro1.obj             | 48269 +++++++++++++++++++
 .../Assets/Objetos/Carrito1/Carro1.obj.meta        |   129 +
 .../Assets/Objetos/Carrito1/Materials 2.meta       |     8 +
 .../Assets/Objetos/Carrito1/Materials 2/mat0.mat   |    83 +
 .../Objetos/Carrito1/Materials 2/mat0.mat.meta     |     8 +
 .../Assets/Objetos/Carrito1/Materials 2/mat1.mat   |    83 +
 .../Objetos/Carrito1/Materials 2/mat1.mat.meta     |     8 +
 .../Assets/Objetos/Carrito1/Materials 2/mat2.mat   |    83 +
 .../Objetos/Carrito1/Materials 2/mat2.mat.meta     |     8 +
 .../Assets/Objetos/Carrito1/Materials 2/mat3.mat   |    83 +
 .../Objetos/Carrito1/Materials 2/mat3.mat.meta     |     8 +
 .../Assets/Objetos/Carrito1/Materials.meta         |     8 +
 .../Assets/Objetos/Carrito1/Materials/mat0.mat     |    83 +
 .../Objetos/Carrito1/Materials/mat0.mat.meta       |     8 +
 .../Assets/Objetos/Carrito1/Materials/mat1.mat     |    83 +
 .../Objetos/Carrito1/Materials/mat1.mat.meta       |     8 +
 .../Assets/Objetos/Carrito1/Materials/mat2.mat     |    83 +
 .../Objetos/Carrito1/Materials/mat2.mat.meta       |     8 +
 .../Assets/Objetos/Carrito1/Materials/mat3.mat     |    83 +
 .../Objetos/Carrito1/Materials/mat3.mat.meta       |     8 +
 .../Carrito1/low-poly_cartoon_style_car_01.mtl     |    56 +
 .../low-poly_cartoon_style_car_01.mtl.meta         |     7 +
 .../Assets/Objetos/Carrito1/readme.txt             |     3 +
 .../Assets/Objetos/Carrito1/readme.txt.meta        |     7 +
 Supermarkert Run/Assets/Objetos/Carrito2.meta      |     8 +
 .../Objetos/Carrito2/BodyGlass_baseColor.png       |   Bin 0 -> 119506 bytes
 .../Objetos/Carrito2/BodyGlass_baseColor.png.meta  |   140 +
 .../Objetos/Carrito2/BodyGlossy_baseColor.png      |   Bin 0 -> 891 bytes
 .../Objetos/Carrito2/BodyGlossy_baseColor.png.meta |   140 +
 .../Assets/Objetos/Carrito2/Carro2.obj             | 40126 +++++++++++++++
 .../Assets/Objetos/Carrito2/Carro2.obj.meta        |   129 +
 .../Assets/Objetos/Carrito2/Materials.meta         |     8 +
 .../Assets/Objetos/Carrito2/Materials/mat0.mat     |    83 +
 .../Objetos/Carrito2/Materials/mat0.mat.meta       |     8 +
 .../Assets/Objetos/Carrito2/Materials/mat1.mat     |    83 +
 .../Objetos/Carrito2/Materials/mat1.mat.meta       |     8 +
 .../Assets/Objetos/Carrito2/Materials/mat2.mat     |    83 +
 .../Objetos/Carrito2/Materials/mat2.mat.meta       |     8 +
 .../Assets/Objetos/Carrito2/Materials/mat3.mat     |    83 +
 .../Objetos/Carrito2/Materials/mat3.mat.meta       |     8 +
 .../Assets/Objetos/Carrito2/Materials2.meta        |     8 +
 .../Assets/Objetos/Carrito2/Materials2/mat0.mat    |    83 +
 .../Objetos/Carrito2/Materials2/mat0.mat.meta      |     8 +
 .../Assets/Objetos/Carrito2/Materials2/mat1.mat    |    83 +
 .../Objetos/Carrito2/Materials2/mat1.mat.meta      |     8 +
 .../Assets/Objetos/Carrito2/Materials2/mat2.mat    |    83 +
 .../Objetos/Carrito2/Materials2/mat2.mat.meta      |     8 +
 .../Assets/Objetos/Carrito2/Materials2/mat3.mat    |    83 +
 .../Objetos/Carrito2/Materials2/mat3.mat.meta      |     8 +
 .../Carrito2/low-poly_cartoon_style_car_03.mtl     |    56 +
 .../low-poly_cartoon_style_car_03.mtl.meta         |     7 +
 .../Assets/Objetos/Carrito2/readme.txt             |     3 +
 .../Assets/Objetos/Carrito2/readme.txt.meta        |     7 +
 ...mageToStl.com_low-poly_cartoon_style_car_01.zip |   Bin 0 -> 426034 bytes
 ...oStl.com_low-poly_cartoon_style_car_01.zip.meta |     7 +
 ...mageToStl.com_low-poly_cartoon_style_car_03.zip |   Bin 0 -> 433946 bytes
 ...oStl.com_low-poly_cartoon_style_car_03.zip.meta |     7 +
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |    26 +-
 .../Objetos/Mapa/Signal_Water/Signal.obj.meta      |     7 +-
 .../Assets/Objetos/Mapa/Signal_Water/mat0.mat      |    83 +
 .../Assets/Objetos/Mapa/Signal_Water/mat0.mat.meta |     8 +
 .../Assets/Objetos/Mapa/Signal_Water/mat02.mat     |    83 +
 .../Objetos/Mapa/Signal_Water/mat02.mat.meta       |     8 +
 .../Assets/Objetos/Mapa/Water_floor/Azul agua.jpg  |   Bin 0 -> 21367 bytes
 .../Objetos/Mapa/Water_floor/Azul agua.jpg.meta    |   140 +
 .../Assets/Objetos/Mapa/Water_floor/Water.obj.meta |     7 +-
 .../Assets/Objetos/Mapa/Water_floor/mat0.mat       |    83 +
 .../Assets/Objetos/Mapa/Water_floor/mat0.mat.meta  |     8 +
 .../Assets/Objetos/Mapa/Water_floor/mat02.mat      |    83 +
 .../Assets/Objetos/Mapa/Water_floor/mat02.mat.meta |     8 +
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |     2 +-
 .../Assets/Scenes/Menu_principal.unity             |   324 +-
 .../Assets/Scripts/Juego/Menu/Carrito.cs           |    27 +
 .../Assets/Scripts/Juego/Menu/Carrito.cs.meta      |    11 +
 Supermarkert Run/Assets/datos.json                 |     2 +-
 Supermarkert Run/Assets/textures/Menu/Fondo.mat    |    19 +-
 .../Assets/textures/Supermercado/Banqueta.mat      |     8 +-
 .../Assets/textures/Supermercado/Pared.mat         |    10 +-
 83 files changed, 91777 insertions(+), 47 deletions(-)

=== COMMIT: e775742 | Wed Jan 15 13:09:29 2025 -0600 | Modificar:texturas de otros objetos de los mapas ===
 .../Assets/Animaciones/UI/Animacion.controller     | 25 +++++++++-----
 .../Escoba/Material/mat0 - copia.mat               |  6 ++--
 .../Hamburguesa/Materiales/materiacop.mat          |  6 ++--
 .../Libro/Material/mat0 - copia.mat                |  8 ++---
 .../Manzana/Materials/Gradient_baseColor.mat       |  6 ++--
 .../Microondas/Materials/Microondas.mat            |  6 ++--
 .../Assets/Scenes/Menu_principal.unity             | 38 +++++++++++-----------
 Supermarkert Run/Assets/datos.json                 |  2 +-
 8 files changed, 53 insertions(+), 44 deletions(-)

=== COMMIT: 5cdb72a | Wed Jan 22 12:51:13 2025 -0600 | Agregar:Sonido al menu principal, click de presionar botones.Modificar:Skin de powerUP ===
 .../Assets/Scenes/Menu_principal.unity             | 264 +++++++++++++++++++++
 .../Scripts/Juego/Configuraciones/Calidad.cs       |   5 +
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |   5 +-
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |   2 +
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  10 +
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |  12 +-
 Supermarkert Run/Assets/Sonidos/Sonido_Menu.wav    | Bin 0 -> 6299762 bytes
 .../Assets/Sonidos/Sonido_Menu.wav.meta            |  23 ++
 .../Assets/Sonidos/mouse-click-117076.wav          | Bin 0 -> 248910 bytes
 .../Assets/Sonidos/mouse-click-117076.wav.meta     |  23 ++
 Supermarkert Run/Assets/datos.json                 |   2 +-
 .../Assets/textures/PowerUp/ExtraLife.mat          |   4 +-
 .../textures/PowerUp/Manos Rapidas - copia.jpg     | Bin 40710 -> 0 bytes
 .../Assets/textures/PowerUp/Manos Rapidas.mat      |   4 +-
 Supermarkert Run/Assets/textures/PowerUp/PNG.meta  |   8 +
 .../PNG/ExtraLife_-_copia-removebg-preview 1.png   | Bin 0 -> 72427 bytes
 .../ExtraLife_-_copia-removebg-preview 1.png.meta} |   2 +-
 .../PNG/ExtraLife_-_copia-removebg-preview.png     | Bin 0 -> 72427 bytes
 .../ExtraLife_-_copia-removebg-preview.png.meta}   |   2 +-
 .../Manos_Rapidas_-_copia-removebg-preview 1.png   | Bin 0 -> 65593 bytes
 ...nos_Rapidas_-_copia-removebg-preview 1.png.meta | 140 +++++++++++
 .../PNG/Manos_Rapidas_-_copia-removebg-preview.png | Bin 0 -> 65593 bytes
 ...Manos_Rapidas_-_copia-removebg-preview.png.meta | 140 +++++++++++
 .../PNG/Protetion_-_copia-removebg-preview 1.png   | Bin 0 -> 149999 bytes
 .../Protetion_-_copia-removebg-preview 1.png.meta  | 140 +++++++++++
 .../PNG/Protetion_-_copia-removebg-preview.png     | Bin 0 -> 149999 bytes
 .../Protetion_-_copia-removebg-preview.png.meta    | 140 +++++++++++
 .../PowerUp/PNG/Speed_-_copia-removebg-preview.png | Bin 0 -> 28013 bytes
 .../PNG/Speed_-_copia-removebg-preview.png.meta    | 140 +++++++++++
 .../textures/PowerUp/{ => PNG}/proteccion2.png     | Bin
 .../PowerUp/{ => PNG}/proteccion2.png.meta         |   0
 .../Assets/textures/PowerUp/Protetion.mat          |   4 +-
 Supermarkert Run/Assets/textures/PowerUp/Speed.mat |   4 +-
 .../Assets/textures/PowerUp/proteccion2 1.png      | Bin 290332 -> 0 bytes
 34 files changed, 1061 insertions(+), 13 deletions(-)

=== COMMIT: e00404a | Fri Jan 24 11:46:08 2025 -0600 | Modificar:El sistema de sombras ===
 .../Assets/Objetos/Enemigo/enemigo.prefab          |  25 ++
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |  25 ++
 .../Assets/Scenes/Menu_principal.unity             | 349 ++++++++++++++++++++-
 .../Scripts/Juego/Configuraciones/Calidad.cs       |  14 +-
 .../Scripts/Juego/Configuraciones/Sombras.cs       |  22 +-
 Supermarkert Run/Assets/datos.json                 |   2 +-
 .../Assets/textures/Jugador_Enemigo/Personaje.mat  |  16 +-
 7 files changed, 433 insertions(+), 20 deletions(-)

=== COMMIT: e93c2b0 | Sat Jan 25 20:53:23 2025 -0600 | Animacion de personaje al presionar ciertos botones ===
 .../Assets/Animaciones/Menu/Menu.controller        | 142 ++++
 .../Assets/Animaciones/Menu/Menu.controller.meta   |   8 +
 .../Jugador/Jugador/Hyper-casual Charcter.fbx.meta | 786 ++++++++++++++++++++-
 .../Assets/Scenes/Menu_principal.unity             | 139 +++-
 .../Assets/Scripts/Juego/Menu/Animacion_NPC.cs     |  51 ++
 .../Scripts/Juego/Menu/Animacion_NPC.cs.meta       |  11 +
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  19 +-
 Supermarkert Run/Assets/datos.json                 |   2 +-
 8 files changed, 1147 insertions(+), 11 deletions(-)

=== COMMIT: daddcba | Sun Jan 26 18:14:59 2025 -0600 | Agregar:Animacion a carrito a ir a ciertas opciones ===
 .../Assets/Scenes/Menu_principal.unity             | 199 ++++++++++++++++++++-
 .../Assets/Scripts/Juego/Menu/Animacion_Carrito.cs |  33 ++++
 .../Scripts/Juego/Menu/Animacion_Carrito.cs.meta   |  11 ++
 .../Assets/Scripts/Juego/Menu/Animacion_NPC.cs     |  15 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  38 +++-
 Supermarkert Run/Assets/datos.json                 |   2 +-
 6 files changed, 280 insertions(+), 18 deletions(-)

=== COMMIT: d1be6bc | Tue Jan 28 12:51:21 2025 -0600 | Agregar: una mini animacion al entrar a jugar.Arreglar:Bug de carrito al entrar a seccion de carro ===
 .../Assets/Animaciones/Menu/Panel.controller       | 101 ++++
 .../Assets/Animaciones/Menu/Panel.controller.meta  |   8 +
 .../Animaciones/Menu/Panel_Animacion_Jugar.anim    | 158 ++++++
 .../Menu/Panel_Animacion_Jugar.anim.meta           |   8 +
 .../Assets/Scenes/Menu_principal.unity             | 543 ++++++++++++++++++++-
 .../Assets/Scripts/Juego/Menu/Animacion_Carga.cs   |   2 -
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  31 +-
 Supermarkert Run/Assets/datos.json                 |   2 +-
 8 files changed, 841 insertions(+), 12 deletions(-)

=== COMMIT: 8911113 | Sat Feb 1 17:24:22 2025 -0600 | Modificar:bakeo de luces en menu principal,panel a otra posicion, codigo para ejecutar las animaciones de play.Agregar:Pausa ===
 .../Animaciones/Menu/Panel_Animacion_Jugar.anim    |   10 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        | 1146 +++++++-
 Supermarkert Run/Assets/SUPERMARKER.meta           |    8 +
 .../Assets/SUPERMARKER/Espa\303\261ol.json"        |    0
 .../Assets/SUPERMARKER/Espa\303\261ol.json.meta"   |    0
 .../Assets/{ => SUPERMARKER}/Ingles.json           |    0
 .../Assets/{ => SUPERMARKER}/Ingles.json.meta      |    0
 .../Assets/{ => SUPERMARKER}/Portugues.json        |    0
 .../Assets/{ => SUPERMARKER}/Portugues.json.meta   |    0
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |    1 +
 .../Assets/SUPERMARKER/datos.json.meta             |    7 +
 Supermarkert Run/Assets/{ => SUPERMARKER}/mapa.txt |    0
 .../Assets/{ => SUPERMARKER}/mapa.txt.meta         |    0
 .../Assets/SUPERMARKER/personalizado.json          |    1 +
 .../Assets/SUPERMARKER/personalizado.json.meta     |    7 +
 .../Assets/Scenes/Menu_principal.unity             | 3068 +++++++++++++++++++-
 .../Scenes/Menu_principal/LightingData.asset       |  Bin 19240 -> 23160 bytes
 .../Scenes/Menu_principal/Lightmap-0_comp_dir.png  |  Bin 50118 -> 4724 bytes
 .../Menu_principal/Lightmap-0_comp_light.exr       |  Bin 238586 -> 154468 bytes
 .../Scenes/Menu_principal/Lightmap-1_comp_dir.png  |  Bin 53991 -> 26487 bytes
 .../Menu_principal/Lightmap-1_comp_light.exr       |  Bin 257363 -> 135313 bytes
 .../Scenes/Menu_principal/Lightmap-2_comp_dir.png  |  Bin 71294 -> 77398 bytes
 .../Menu_principal/Lightmap-2_comp_light.exr       |  Bin 321150 -> 321258 bytes
 .../Scenes/Menu_principal/Lightmap-3_comp_dir.png  |  Bin 38461 -> 88432 bytes
 .../Menu_principal/Lightmap-3_comp_light.exr       |  Bin 205251 -> 466546 bytes
 .../Scenes/Menu_principal/Lightmap-4_comp_dir.png  |  Bin 0 -> 73980 bytes
 .../Menu_principal/Lightmap-4_comp_dir.png.meta    |  140 +
 .../Menu_principal/Lightmap-4_comp_light.exr       |  Bin 0 -> 389531 bytes
 .../Menu_principal/Lightmap-4_comp_light.exr.meta  |  140 +
 .../Scenes/Menu_principal/Lightmap-5_comp_dir.png  |  Bin 0 -> 56677 bytes
 .../Menu_principal/Lightmap-5_comp_dir.png.meta    |  140 +
 .../Menu_principal/Lightmap-5_comp_light.exr       |  Bin 0 -> 247202 bytes
 .../Menu_principal/Lightmap-5_comp_light.exr.meta  |  140 +
 .../Scenes/Menu_principal/Lightmap-6_comp_dir.png  |  Bin 0 -> 68219 bytes
 .../Menu_principal/Lightmap-6_comp_dir.png.meta    |  140 +
 .../Menu_principal/Lightmap-6_comp_light.exr       |  Bin 0 -> 306539 bytes
 .../Menu_principal/Lightmap-6_comp_light.exr.meta  |  140 +
 .../Scenes/Menu_principal/Lightmap-7_comp_dir.png  |  Bin 0 -> 29042 bytes
 .../Menu_principal/Lightmap-7_comp_dir.png.meta    |  140 +
 .../Menu_principal/Lightmap-7_comp_light.exr       |  Bin 0 -> 133125 bytes
 .../Menu_principal/Lightmap-7_comp_light.exr.meta  |  140 +
 .../Assets/Scripts/Juego/Gameplay/Pausa.cs         |   25 +
 .../Assets/Scripts/Juego/Gameplay/Pausa.cs.meta    |   11 +
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |    7 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |    4 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |    4 +-
 Supermarkert Run/Assets/datos.json                 |    2 +-
 .../textures/Carritos/Grande/PersonalizadaGra.mat  |    2 +-
 .../textures/Carritos/Mediano/PersonalizadaMed.mat |    2 +-
 .../textures/Carritos/Pequenio/Personalizada.mat   |    2 +-
 50 files changed, 5319 insertions(+), 108 deletions(-)

=== COMMIT: d6bef21 | Sat Feb 1 17:37:54 2025 -0600 | Modificar:codigo en lectura para misiones.Primera version beta ===
 Supermarkert Run/Assets/SUPERMARKER/datos.json    | 2 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs | 2 +-
 2 files changed, 2 insertions(+), 2 deletions(-)

=== COMMIT: e396618 | Sat Feb 1 19:25:18 2025 -0600 | Modificar: codigo de power ups arreglar bug.Agregar:log a jugar para detectar carrito ===
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |   2 +-
 Supermarkert Run/Assets/SUPERMARKER/log_player.txt |   3 +
 .../{mapa.txt.meta => log_player.txt.meta}         |   2 +-
 Supermarkert Run/Assets/SUPERMARKER/mapa.txt       |   1 -
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |   2 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  10 ++
 .../Assets/textures/Menu/Supermarker_foto.png      | Bin 0 -> 475393 bytes
 .../Assets/textures/Menu/Supermarker_foto.png.meta | 140 +++++++++++++++++++++
 .../ProjectSettings/ProjectSettings.asset          |  11 +-
 9 files changed, 165 insertions(+), 6 deletions(-)

=== COMMIT: 7fe033f | Sun Feb 2 15:45:44 2025 -0600 | Modificar:modo de carga de escena para arreglar bug de carro,y crear archivos antes de entrar a jugar.Eliminar: texto de carrito para arreglar bug. ===
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab   |  2 ++
 Supermarkert Run/Assets/SUPERMARKER/datos.json      |  2 +-
 Supermarkert Run/Assets/SUPERMARKER/log_player.txt  |  3 ---
 .../Assets/SUPERMARKER/log_player.txt.meta          |  7 -------
 .../Assets/Scenes/Mapa peque\303\261o.unity"        | 15 +++++++++++++++
 .../Assets/Scripts/Juego/Menu/Animacion_Carga.cs    | 10 ++++++++--
 .../Assets/Scripts/Juego/Menu/Seleccion.cs          | 21 +++++++++++++++++----
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs   |  3 ++-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs   | 11 +----------
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs   |  3 +++
 10 files changed, 49 insertions(+), 28 deletions(-)

=== COMMIT: fb029ba | Sun Feb 2 17:05:35 2025 -0600 | Modificar posicion y texturas de la UI del juego ===
 Supermarkert Run/Assets/Objetos/UI 1.prefab        | 741 ++++++++++++---------
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |   2 +-
 Supermarkert Run/Assets/textures/UI_GAME.meta      |   8 +
 Supermarkert Run/Assets/textures/UI_GAME/cart.png  | Bin 0 -> 1567 bytes
 .../Assets/textures/UI_GAME/cart.png.meta          | 140 ++++
 Supermarkert Run/Assets/textures/UI_GAME/clock.png | Bin 0 -> 1623 bytes
 .../Assets/textures/UI_GAME/clock.png.meta         | 140 ++++
 Supermarkert Run/Assets/textures/UI_GAME/exit.png  | Bin 0 -> 3615 bytes
 .../Assets/textures/UI_GAME/exit.png.meta          | 140 ++++
 Supermarkert Run/Assets/textures/UI_GAME/list.png  | Bin 0 -> 713 bytes
 .../Assets/textures/UI_GAME/list.png.meta          | 140 ++++
 Supermarkert Run/Assets/textures/UI_GAME/money.png | Bin 0 -> 987 bytes
 .../Assets/textures/UI_GAME/money.png.meta         | 140 ++++
 Supermarkert Run/Assets/textures/UI_GAME/nut.png   | Bin 0 -> 20223 bytes
 .../Assets/textures/UI_GAME/nut.png.meta           | 140 ++++
 Supermarkert Run/Assets/textures/UI_GAME/pause.png | Bin 0 -> 6095 bytes
 .../Assets/textures/UI_GAME/pause.png.meta         | 140 ++++
 Supermarkert Run/Assets/textures/UI_GAME/play.png  | Bin 0 -> 572 bytes
 .../Assets/textures/UI_GAME/play.png.meta          | 140 ++++
 .../Assets/textures/UI_GAME/thunder.png            | Bin 0 -> 54921 bytes
 .../Assets/textures/UI_GAME/thunder.png.meta       | 140 ++++
 21 files changed, 1695 insertions(+), 316 deletions(-)

=== COMMIT: 715593a | Tue Feb 4 12:30:46 2025 -0600 | Arregla: el bug de jugador lento, supongo que otros bugs, bug de efectos ===
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |  2 +-
 Supermarkert Run/Assets/SUPERMARKER/player_log.txt |  3 ++
 .../Assets/SUPERMARKER/player_log.txt.meta         |  7 +++
 .../Assets/SUPERMARKER/player_log_2.txt            |  4 ++
 .../Assets/SUPERMARKER/player_log_2.txt.meta       |  7 +++
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 23 +++++++-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |  4 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  | 63 ++++++++++++++++------
 .../Assets/Scripts/PowerUp/Velocidad.cs            |  2 +-
 9 files changed, 93 insertions(+), 22 deletions(-)

=== COMMIT: 166892a | Wed Feb 5 22:46:41 2025 -0600 | Arreglar:bug de quedar carro detenido.Modificar:la UI ===
 Supermarkert Run/Assets/Objetos/UI 1.prefab        | 364 ++++-----------
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |   2 +-
 .../Assets/Scenes/Menu_principal.unity             | 500 ++++++++++++++-------
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  13 +-
 4 files changed, 421 insertions(+), 458 deletions(-)

=== COMMIT: 4c6fb01 | Thu Feb 6 12:18:38 2025 -0600 | Modificar:la UI de menu principal, animaciones ===
 .../Assets/Animaciones/UI/Animacion.controller     |   35 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |  400 ++--
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |    2 +-
 .../Assets/Scenes/Menu_principal.unity             | 2464 ++++++++++++++++++--
 .../Scenes/Menu_principal/LightingData.asset       |  Bin 23160 -> 23744 bytes
 .../Scenes/Menu_principal/Lightmap-0_comp_dir.png  |  Bin 4724 -> 4747 bytes
 .../Menu_principal/Lightmap-0_comp_light.exr       |  Bin 154468 -> 154483 bytes
 .../Scenes/Menu_principal/Lightmap-10_comp_dir.png |  Bin 0 -> 36177 bytes
 .../Menu_principal/Lightmap-10_comp_dir.png.meta   |  140 ++
 .../Menu_principal/Lightmap-10_comp_light.exr      |  Bin 0 -> 174492 bytes
 .../Menu_principal/Lightmap-10_comp_light.exr.meta |  140 ++
 .../Scenes/Menu_principal/Lightmap-1_comp_dir.png  |  Bin 26487 -> 28008 bytes
 .../Menu_principal/Lightmap-1_comp_light.exr       |  Bin 135313 -> 136026 bytes
 .../Scenes/Menu_principal/Lightmap-2_comp_dir.png  |  Bin 77398 -> 80831 bytes
 .../Menu_principal/Lightmap-2_comp_light.exr       |  Bin 321258 -> 352126 bytes
 .../Scenes/Menu_principal/Lightmap-3_comp_dir.png  |  Bin 88432 -> 85674 bytes
 .../Menu_principal/Lightmap-3_comp_light.exr       |  Bin 466546 -> 319761 bytes
 .../Scenes/Menu_principal/Lightmap-4_comp_dir.png  |  Bin 73980 -> 89431 bytes
 .../Menu_principal/Lightmap-4_comp_light.exr       |  Bin 389531 -> 470412 bytes
 .../Scenes/Menu_principal/Lightmap-5_comp_dir.png  |  Bin 56677 -> 79121 bytes
 .../Menu_principal/Lightmap-5_comp_light.exr       |  Bin 247202 -> 434101 bytes
 .../Scenes/Menu_principal/Lightmap-6_comp_dir.png  |  Bin 68219 -> 59663 bytes
 .../Menu_principal/Lightmap-6_comp_light.exr       |  Bin 306539 -> 262631 bytes
 .../Scenes/Menu_principal/Lightmap-7_comp_dir.png  |  Bin 29042 -> 70913 bytes
 .../Menu_principal/Lightmap-7_comp_light.exr       |  Bin 133125 -> 321174 bytes
 .../Scenes/Menu_principal/Lightmap-8_comp_dir.png  |  Bin 0 -> 53912 bytes
 .../Menu_principal/Lightmap-8_comp_dir.png.meta    |  140 ++
 .../Menu_principal/Lightmap-8_comp_light.exr       |  Bin 0 -> 217269 bytes
 .../Menu_principal/Lightmap-8_comp_light.exr.meta  |  140 ++
 .../Scenes/Menu_principal/Lightmap-9_comp_dir.png  |  Bin 0 -> 71936 bytes
 .../Menu_principal/Lightmap-9_comp_dir.png.meta    |  140 ++
 .../Menu_principal/Lightmap-9_comp_light.exr       |  Bin 0 -> 349850 bytes
 .../Menu_principal/Lightmap-9_comp_light.exr.meta  |  140 ++
 .../Assets/Scripts/Juego/Gameplay/Pausa.cs         |    4 +
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |    8 +-
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |    1 -
 36 files changed, 3276 insertions(+), 478 deletions(-)

=== COMMIT: d85a7ea | Sat Feb 8 18:53:08 2025 -0600 | Arreglar bug de caja, modificar la UI, arreglar bug de dinero y reinicio ===
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |  76 ++++
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |   2 +-
 .../Assets/SUPERMARKER/personalizado.json          |   2 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |  21 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  21 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  28 +-
 .../Assets/Scenes/Menu_principal.unity             | 479 +++++++++++++++++++--
 .../Liviano/Liviano_Personalzado.asset             |   8 +-
 .../Scripts/Car Supermarkert/Personalizacion.cs    |  20 +
 .../Assets/Scripts/Juego/Gameplay/Pausa.cs         |   7 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |  17 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  52 ++-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  31 +-
 .../Assets/Scripts/PowerUp/Repartir_power.cs       |   1 -
 .../textures/Carritos/Grande/PersonalizadaGra.mat  |   2 +-
 .../textures/Carritos/Mediano/PersonalizadaMed.mat |   2 +-
 .../textures/Carritos/Pequenio/Personalizada.mat   |   2 +-
 Supermarkert Run/Assets/textures/UI_GAME/x.png     | Bin 0 -> 9522 bytes
 .../Assets/textures/UI_GAME/x.png.meta             | 140 ++++++
 19 files changed, 756 insertions(+), 155 deletions(-)

=== COMMIT: 08196c8 | Wed Feb 12 12:06:05 2025 -0600 | Agregar:Sistema de reinicio,y un loading en la carga ===
 Supermarkert Run/Assets/Objetos/Muerte 1.prefab    | 356 +++++----
 Supermarkert Run/Assets/Objetos/UI 1.prefab        | 237 +++++-
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |   2 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |  28 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  26 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  28 +-
 .../Assets/Scenes/Menu_principal.unity             | 820 ++++++++++++++++++++-
 .../Assets/Scripts/Juego/Gameplay/Pausa.cs         |  12 +-
 .../Assets/Scripts/Juego/Menu/Animacion_Carrito.cs |  13 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  26 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  23 +-
 .../textures/UI_GAME/retorno-removebg-preview.png  | Bin 0 -> 33631 bytes
 .../UI_GAME/retorno-removebg-preview.png.meta      | 140 ++++
 13 files changed, 1512 insertions(+), 199 deletions(-)

=== COMMIT: e190e8a | Sat Feb 15 12:46:40 2025 -0600 | Modificar:El codigo para desaparecer los estantes y la forma en la que se desaparecen ===
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |   8 +-
 .../Assets/Objetos/Mapa/Fila2 Variant.prefab       |  16 ++
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |  60 ++++++
 .../Assets/Objetos/Objetos_Colocados/Caja.mat      |  14 +-
 .../Objetos/Objetos_Colocados/Caja_Leche.mat       |  12 +-
 .../Escoba/Material/mat0 - copia.mat               |  18 +-
 .../Hamburguesa/Materiales/materiacop.mat          |  18 +-
 .../Libro/Material/mat0 - copia.mat                |  18 +-
 .../Manzana/Materials/Gradient_baseColor.mat       |  18 +-
 .../Microondas/Materials/Microondas.mat            |  18 +-
 .../Microondas/Materials/RGB_texture_baseColor.mat |  12 +-
 .../Assets/Objetos/Objetos_Colocados/rollo.mat     |  12 +-
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |   2 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 205 +++++++++++++++++++--
 .../Scripts/Jugador/Camara_Objetos_Desaparecer.cs  |  96 +++++-----
 15 files changed, 391 insertions(+), 136 deletions(-)

=== COMMIT: e169359 | Mon Dec 1 23:18:50 2025 -0600 | Hice tantas cosas como arreglar bugs, modificar la UI, modificar las mecanicas de ver las misiones, agregue el carrito magico, refactorice ciertas cosas como carro y estantes, ademas de eliminar temporalmente personalizacion para arreglar sus bugs dismiuir la velocidad de los carros, se decia ir muy rapido, necesito solucionar los bugs de no parar cuando terminas de resbalar y de que el personaje ya no avanza aunque es algo mas raro, tambien ahora el sistema de spawn de objetos es por ciertos spawn y no de manera aleatoria evitando asi las sobre posicion de los objetos, ya no mueres al chocar si no te elimina objetos, se modificaron los costos de los mapas costando mas y dando menos ===
 Supermarkert Run/Assets/Editor.meta                |    8 +
 .../Assets/Editor/SpawnPointLaserEditor.cs         |   21 +
 .../Assets/Editor/SpawnPointLaserEditor.cs.meta    |   11 +
 .../Assets/Objetos/Enemigo/enemigo.prefab          |    4 +-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   23 +-
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |    2 +-
 .../Carrito_Peq.prefab                             |    2 +-
 .../Carrito_aleatorio.prefab                       |  568 +++++
 .../Carrito_aleatorio.prefab.meta                  |    7 +
 .../Carrito_gra.prefab                             |    2 +-
 .../Carrito_med.prefab                             |    2 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        | 2578 ++++++++++++++++----
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |    2 +-
 .../Assets/SUPERMARKER/personalizado.json          |    2 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |  296 ++-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  280 ++-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  358 ++-
 .../Assets/Scenes/Menu_principal.unity             |  152 +-
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |   36 +-
 .../Scripts/Car Supermarkert/Liviano/Liviano.asset |    2 +-
 .../Car Supermarkert/Liviano/Liviano2.asset        |    4 +-
 .../Scripts/Car Supermarkert/Mediano/Mediano.asset |    4 +-
 .../Car Supermarkert/Mediano/Mediano2.asset        |    2 +-
 .../Scripts/Car Supermarkert/Personalizacion.cs    |    2 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado.asset   |    4 +-
 .../Scripts/Juego/Configuraciones/Calidad.cs       |    3 +-
 .../Assets/Scripts/Juego/Configuraciones/Idioma.cs |    2 -
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs      |    2 +-
 .../Assets/Scripts/Juego/Gameplay/Pausa.cs         |   18 +
 Supermarkert Run/Assets/Scripts/Juego/Mapa/Mapa.cs |    3 +
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |   10 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |   10 +-
 .../Scripts/Juego/Mapa/Mapa_peque\303\261o.asset"  |    8 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |  102 +-
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |   27 +-
 .../Assets/Scripts/Juego/Mapa/SpawMapa1.asset      |   33 +
 .../Assets/Scripts/Juego/Mapa/SpawMapa1.asset.meta |    8 +
 .../Assets/Scripts/Juego/Mapa/SpawnMapa2.asset     |   57 +
 .../Scripts/Juego/Mapa/SpawnMapa2.asset.meta       |    8 +
 .../Assets/Scripts/Juego/Mapa/SpawnMapa3.asset     |  109 +
 .../Scripts/Juego/Mapa/SpawnMapa3.asset.meta       |    8 +
 .../Assets/Scripts/Juego/Mapa/SpawnPointLaser.cs   |  127 +
 .../Scripts/Juego/Mapa/SpawnPointLaser.cs.meta     |   11 +
 .../Assets/Scripts/Juego/Mapa/SpawnPointsData.cs   |   26 +
 .../Scripts/Juego/Mapa/SpawnPointsData.cs.meta     |   11 +
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |   11 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |  215 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   67 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |    5 +-
 .../Assets/Scripts/estantes/Estante.cs             |    4 +-
 .../Assets/Scripts/estantes/IGuardarObjetos.cs     |    8 +
 .../Scripts/estantes/IGuardarObjetos.cs.meta       |   11 +
 .../Assets/Scripts/estantes/Objeto_random_carro.cs |   24 +
 .../Scripts/estantes/Objeto_random_carro.cs.meta   |   11 +
 .../textures/Carritos/Grande/PersonalizadaGra.mat  |    2 +-
 .../textures/Carritos/Mediano/PersonalizadaMed.mat |    2 +-
 .../textures/Carritos/Pequenio/Personalizada.mat   |    2 +-
 Supermarkert Run/Assets/textures/UI_GAME/papel.png |  Bin 0 -> 20805 bytes
 .../Assets/textures/UI_GAME/papel.png.meta         |  140 ++
 Supermarkert Run/ProjectSettings/TagManager.asset  |    1 +
 60 files changed, 4761 insertions(+), 697 deletions(-)

=== COMMIT: 27f20cf | Tue Dec 2 11:51:51 2025 -0600 | Eliminar el power up de vida, agregar skins y sistema de traduccion en los power up ===
 Supermarkert Run/Assets/Objetos/Power.prefab       |  19 +--
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |   2 +-
 .../Assets/Scenes/Menu_principal.unity             | 143 ++-------------------
 .../Scripts/Car Supermarkert/Liviano/Liviano.asset |   2 +-
 .../Car Supermarkert/Liviano/Liviano2.asset        |   2 +-
 .../Car Supermarkert/Liviano/Liviano3.asset        |  30 +++++
 .../Car Supermarkert/Liviano/Liviano3.asset.meta   |   8 ++
 .../Car Supermarkert/Liviano/Liviano4.asset        |  30 +++++
 .../Car Supermarkert/Liviano/Liviano4.asset.meta   |   8 ++
 .../Car Supermarkert/Liviano/Liviano5.asset        |  30 +++++
 .../Car Supermarkert/Liviano/Liviano5.asset.meta   |   8 ++
 .../Scripts/Car Supermarkert/Mediano/Mediano.asset |   2 +-
 .../Car Supermarkert/Mediano/Mediano3.asset        |  30 +++++
 .../Car Supermarkert/Mediano/Mediano3.asset.meta   |   8 ++
 .../Car Supermarkert/Mediano/Mediano4.asset        |  30 +++++
 .../Car Supermarkert/Mediano/Mediano4.asset.meta   |   8 ++
 .../Car Supermarkert/Mediano/Mediano5.asset        |  30 +++++
 .../Car Supermarkert/Mediano/Mediano5.asset.meta   |   8 ++
 .../Scripts/Car Supermarkert/Pesado/Pesado.asset   |   2 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado3.asset  |  31 +++++
 .../Car Supermarkert/Pesado/Pesado3.asset.meta     |   8 ++
 .../Scripts/Car Supermarkert/Pesado/Pesado4.asset  |  31 +++++
 .../Car Supermarkert/Pesado/Pesado4.asset.meta     |   8 ++
 .../Scripts/Car Supermarkert/Pesado/Pesado5.asset  |  31 +++++
 .../Car Supermarkert/Pesado/Pesado5.asset.meta     |   8 ++
 .../Assets/Scripts/Juego/Configuraciones/Idioma.cs |  15 ++-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |   2 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  60 ++++++---
 .../Assets/Scripts/PowerUp/Interfaz_PowerUp.cs     |   2 +
 .../Assets/Scripts/PowerUp/Manos_Rapidas.cs        |  22 +++-
 .../Assets/Scripts/PowerUp/Proteccion.cs           |  24 +++-
 .../Assets/Scripts/PowerUp/Repartir_power.cs       |   5 +-
 .../Assets/Scripts/PowerUp/Velocidad.cs            |  22 +++-
 .../Assets/Scripts/PowerUp/Vida_extra.cs           |  46 -------
 .../Assets/Scripts/PowerUp/Vida_extra.cs.meta      |  11 --
 .../Assets/textures/Carritos/Pequenio/diamante.mat |  83 ++++++++++++
 .../textures/Carritos/Pequenio/diamante.mat.meta   |   8 ++
 .../Assets/textures/Carritos/Pequenio/diamante.png | Bin 0 -> 444029 bytes
 .../textures/Carritos/Pequenio/diamante.png.meta   | 140 ++++++++++++++++++++
 .../Assets/textures/Carritos/Pequenio/oro.mat      |  83 ++++++++++++
 .../Assets/textures/Carritos/Pequenio/oro.mat.meta |   8 ++
 .../Assets/textures/Carritos/Pequenio/oro.png      | Bin 0 -> 53185 bytes
 .../Assets/textures/Carritos/Pequenio/oro.png.meta | 140 ++++++++++++++++++++
 .../Assets/textures/Carritos/Pequenio/plata.mat    |  89 +++++++++++++
 .../textures/Carritos/Pequenio/plata.mat.meta      |   8 ++
 .../Assets/textures/Carritos/Pequenio/plata.png    | Bin 0 -> 43986 bytes
 .../textures/Carritos/Pequenio/plata.png.meta      | 140 ++++++++++++++++++++
 47 files changed, 1182 insertions(+), 243 deletions(-)

=== COMMIT: 5027cdd | Mon Dec 8 19:07:04 2025 -0600 | Nuevo acomodo en los mapas, mostrador para jugador y enemigos, objeto volador(al chocar el jugador el ultimo objeto que tomo sale volando y se puede recuperar) nuevo ligthmap de mapa pequeño(faltan los demas mapas) nuevo navmesh y occlusion culling en los tres mapas, agregar outline a los objetos nuevos simbolos y una nueva estanteria, modificar codigo para agregar nuevas mecanicas, al chocar con poca o nula velocidad no retroceder, nuevo font, se elimino Camara_Objetos_Ocultar.cs ya que el outline lo sustituye, nueva manera de renderizar objetos(ahora se copian 100% no de uno en uno), modificar nombre de los json de linea a la area que pertenece, nuevo objeto carrito magico(obtiene un objeto aleatorio puede ayudar o no), la IA ahora va a la caja de paga ===
 Supermarkert Run/Assets/Font/kalam.meta            |     8 +
 Supermarkert Run/Assets/Font/kalam/Kalam-Bold.ttf  |   Bin 0 -> 521360 bytes
 .../Assets/Font/kalam/Kalam-Bold.ttf.meta          |    21 +
 .../Assets/Font/kalam/Kalam-Light SDF.asset        |  2834 ++++
 .../Assets/Font/kalam/Kalam-Light SDF.asset.meta   |     8 +
 Supermarkert Run/Assets/Font/kalam/Kalam-Light.ttf |   Bin 0 -> 418376 bytes
 .../Assets/Font/kalam/Kalam-Light.ttf.meta         |    21 +
 .../Assets/Font/kalam/Kalam-Regular.ttf            |   Bin 0 -> 437356 bytes
 .../Assets/Font/kalam/Kalam-Regular.ttf.meta       |    21 +
 Supermarkert Run/Assets/Font/kalam/OFL.txt         |    91 +
 Supermarkert Run/Assets/Font/kalam/OFL.txt.meta    |     7 +
 .../Assets/Objetos/Enemigo/enemigo.prefab          |    36 +-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   228 +-
 .../Objetos/Luces/New Lighting Settings.lighting   |     2 +-
 .../Assets/Objetos/Mapa/Caja/Materials.meta        |     8 +
 .../Mapa/Caja/Materials/Simbolo_Dejar_Objetos.mat  |    85 +
 .../Caja/Materials/Simbolo_Dejar_Objetos.mat.meta  |     8 +
 .../Objetos/Mapa/Caja/Simbolo_Dejar_Objetos.png    |   Bin 0 -> 444338 bytes
 .../Mapa/Caja/Simbolo_Dejar_Objetos.png.meta       |   140 +
 .../Assets/Objetos/Mapa/Caja/mostrador.prefab      |  1102 +-
 .../Objetos/Mapa/Caja/mostrador_no_player.prefab   |  1774 +++
 .../Mapa/Caja/mostrador_no_player.prefab.meta      |     7 +
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |    18 +-
 .../Assets/Objetos/Mapa/Estanteria (1).obj         |  1006 ++
 .../Assets/Objetos/Mapa/Estanteria (1).obj.meta    |   109 +
 .../Assets/Objetos/Mapa/Estanteria 1.obj           |   963 ++
 .../Assets/Objetos/Mapa/Estanteria 1.obj.meta      |   109 +
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |  9952 +++++++++++--
 .../Assets/Objetos/Mapa/Fila2 Variant.prefab       |   116 +-
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |   114 +-
 .../Assets/Objetos/Mapa/Puerta_Automatica.prefab   |     4 +-
 .../Objetos/Objetos_Colocados/Libro/libro.prefab   |    67 +
 .../Objetos_Colocados/Libro/libro.prefab.meta      |     7 +
 .../Microondas/Materials/RGB_texture_baseColor.mat |    11 +-
 .../Microondas/microondas.obj.meta                 |     2 +-
 .../Carrito_aleatorio.prefab                       |    14 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |   256 +-
 .../Assets/SUPERMARKER/Espa\303\261ol.json"        |     2 +-
 Supermarkert Run/Assets/SUPERMARKER/Ingles.json    |     2 +-
 Supermarkert Run/Assets/SUPERMARKER/Portugues.json |     2 +-
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |     2 +-
 Supermarkert Run/Assets/SUPERMARKER/mapa.txt       |     2 +
 Supermarkert Run/Assets/SUPERMARKER/mapa.txt.meta  |     7 +
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 14730 ++++++++-----------
 .../Mapa grande/NavMesh-NavMesh Surface.asset      |   Bin 86420 -> 102408 bytes
 .../Scenes/Mapa grande/OcclusionCullingData.asset  |  1330 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  3607 +----
 .../Mapa mediano/NavMesh-NavMesh Surface.asset     |   Bin 36416 -> 42112 bytes
 .../Scenes/Mapa mediano/OcclusionCullingData.asset |   438 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  7111 +++------
 .../Scenes/Mapa peque\303\261o/LightingData.asset" |   Bin 27344 -> 34176 bytes
 .../Mapa peque\303\261o/Lightmap-0_comp_dir.png"   |   Bin 107062 -> 2680 bytes
 .../Lightmap-0_comp_dir.png.meta"                  |    15 +-
 .../Mapa peque\303\261o/Lightmap-0_comp_light.exr" |   Bin 414139 -> 24628 bytes
 .../Lightmap-0_comp_light.exr.meta"                |    15 +-
 .../Mapa peque\303\261o/Lightmap-10_comp_dir.png"  |   Bin 0 -> 2754 bytes
 .../Lightmap-10_comp_dir.png.meta"                 |   140 +
 .../Lightmap-10_comp_light.exr"                    |   Bin 0 -> 24794 bytes
 .../Lightmap-10_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-11_comp_dir.png"  |   Bin 0 -> 2127 bytes
 .../Lightmap-11_comp_dir.png.meta"                 |   140 +
 .../Lightmap-11_comp_light.exr"                    |   Bin 0 -> 21822 bytes
 .../Lightmap-11_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-12_comp_dir.png"  |   Bin 0 -> 2171 bytes
 .../Lightmap-12_comp_dir.png.meta"                 |   140 +
 .../Lightmap-12_comp_light.exr"                    |   Bin 0 -> 21661 bytes
 .../Lightmap-12_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-13_comp_dir.png"  |   Bin 0 -> 2297 bytes
 .../Lightmap-13_comp_dir.png.meta"                 |   140 +
 .../Lightmap-13_comp_light.exr"                    |   Bin 0 -> 20951 bytes
 .../Lightmap-13_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-14_comp_dir.png"  |   Bin 0 -> 2164 bytes
 .../Lightmap-14_comp_dir.png.meta"                 |   140 +
 .../Lightmap-14_comp_light.exr"                    |   Bin 0 -> 22587 bytes
 .../Lightmap-14_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-15_comp_dir.png"  |   Bin 0 -> 2221 bytes
 .../Lightmap-15_comp_dir.png.meta"                 |   140 +
 .../Lightmap-15_comp_light.exr"                    |   Bin 0 -> 21394 bytes
 .../Lightmap-15_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-16_comp_dir.png"  |   Bin 0 -> 1919 bytes
 .../Lightmap-16_comp_dir.png.meta"                 |   140 +
 .../Lightmap-16_comp_light.exr"                    |   Bin 0 -> 21879 bytes
 .../Lightmap-16_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-17_comp_dir.png"  |   Bin 0 -> 2563 bytes
 .../Lightmap-17_comp_dir.png.meta"                 |   140 +
 .../Lightmap-17_comp_light.exr"                    |   Bin 0 -> 21609 bytes
 .../Lightmap-17_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-18_comp_dir.png"  |   Bin 0 -> 2348 bytes
 .../Lightmap-18_comp_dir.png.meta"                 |   140 +
 .../Lightmap-18_comp_light.exr"                    |   Bin 0 -> 22032 bytes
 .../Lightmap-18_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-19_comp_dir.png"  |   Bin 0 -> 1959 bytes
 .../Lightmap-19_comp_dir.png.meta"                 |   140 +
 .../Lightmap-19_comp_light.exr"                    |   Bin 0 -> 22140 bytes
 .../Lightmap-19_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-1_comp_dir.png"   |   Bin 55755 -> 1987 bytes
 .../Lightmap-1_comp_dir.png.meta"                  |    15 +-
 .../Mapa peque\303\261o/Lightmap-1_comp_light.exr" |   Bin 312029 -> 22034 bytes
 .../Lightmap-1_comp_light.exr.meta"                |    15 +-
 .../Mapa peque\303\261o/Lightmap-20_comp_dir.png"  |   Bin 0 -> 2571 bytes
 .../Lightmap-20_comp_dir.png.meta"                 |   140 +
 .../Lightmap-20_comp_light.exr"                    |   Bin 0 -> 22600 bytes
 .../Lightmap-20_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-21_comp_dir.png"  |   Bin 0 -> 2461 bytes
 .../Lightmap-21_comp_dir.png.meta"                 |   140 +
 .../Lightmap-21_comp_light.exr"                    |   Bin 0 -> 21919 bytes
 .../Lightmap-21_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-22_comp_dir.png"  |   Bin 0 -> 2860 bytes
 .../Lightmap-22_comp_dir.png.meta"                 |   140 +
 .../Lightmap-22_comp_light.exr"                    |   Bin 0 -> 23714 bytes
 .../Lightmap-22_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-23_comp_dir.png"  |   Bin 0 -> 2316 bytes
 .../Lightmap-23_comp_dir.png.meta"                 |   140 +
 .../Lightmap-23_comp_light.exr"                    |   Bin 0 -> 21756 bytes
 .../Lightmap-23_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-24_comp_dir.png"  |   Bin 0 -> 2124 bytes
 .../Lightmap-24_comp_dir.png.meta"                 |   140 +
 .../Lightmap-24_comp_light.exr"                    |   Bin 0 -> 22277 bytes
 .../Lightmap-24_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-25_comp_dir.png"  |   Bin 0 -> 1998 bytes
 .../Lightmap-25_comp_dir.png.meta"                 |   140 +
 .../Lightmap-25_comp_light.exr"                    |   Bin 0 -> 22033 bytes
 .../Lightmap-25_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-26_comp_dir.png"  |   Bin 0 -> 2333 bytes
 .../Lightmap-26_comp_dir.png.meta"                 |   140 +
 .../Lightmap-26_comp_light.exr"                    |   Bin 0 -> 22239 bytes
 .../Lightmap-26_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-27_comp_dir.png"  |   Bin 0 -> 2083 bytes
 .../Lightmap-27_comp_dir.png.meta"                 |   140 +
 .../Lightmap-27_comp_light.exr"                    |   Bin 0 -> 22915 bytes
 .../Lightmap-27_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-28_comp_dir.png"  |   Bin 0 -> 1905 bytes
 .../Lightmap-28_comp_dir.png.meta"                 |   140 +
 .../Lightmap-28_comp_light.exr"                    |   Bin 0 -> 21877 bytes
 .../Lightmap-28_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-29_comp_dir.png"  |   Bin 0 -> 2077 bytes
 .../Lightmap-29_comp_dir.png.meta"                 |   140 +
 .../Lightmap-29_comp_light.exr"                    |   Bin 0 -> 21212 bytes
 .../Lightmap-29_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-2_comp_dir.png"   |   Bin 56464 -> 1902 bytes
 .../Lightmap-2_comp_dir.png.meta"                  |    15 +-
 .../Mapa peque\303\261o/Lightmap-2_comp_light.exr" |   Bin 303451 -> 22466 bytes
 .../Lightmap-2_comp_light.exr.meta"                |    15 +-
 .../Mapa peque\303\261o/Lightmap-30_comp_dir.png"  |   Bin 0 -> 2577 bytes
 .../Lightmap-30_comp_dir.png.meta"                 |   140 +
 .../Lightmap-30_comp_light.exr"                    |   Bin 0 -> 22832 bytes
 .../Lightmap-30_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-31_comp_dir.png"  |   Bin 0 -> 2061 bytes
 .../Lightmap-31_comp_dir.png.meta"                 |   140 +
 .../Lightmap-31_comp_light.exr"                    |   Bin 0 -> 20859 bytes
 .../Lightmap-31_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-32_comp_dir.png"  |   Bin 0 -> 2296 bytes
 .../Lightmap-32_comp_dir.png.meta"                 |   140 +
 .../Lightmap-32_comp_light.exr"                    |   Bin 0 -> 21411 bytes
 .../Lightmap-32_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-33_comp_dir.png"  |   Bin 0 -> 2644 bytes
 .../Lightmap-33_comp_dir.png.meta"                 |   140 +
 .../Lightmap-33_comp_light.exr"                    |   Bin 0 -> 21870 bytes
 .../Lightmap-33_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-34_comp_dir.png"  |   Bin 0 -> 2195 bytes
 .../Lightmap-34_comp_dir.png.meta"                 |   140 +
 .../Lightmap-34_comp_light.exr"                    |   Bin 0 -> 21522 bytes
 .../Lightmap-34_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-35_comp_dir.png"  |   Bin 0 -> 2074 bytes
 .../Lightmap-35_comp_dir.png.meta"                 |   140 +
 .../Lightmap-35_comp_light.exr"                    |   Bin 0 -> 21498 bytes
 .../Lightmap-35_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-36_comp_dir.png"  |   Bin 0 -> 2290 bytes
 .../Lightmap-36_comp_dir.png.meta"                 |   140 +
 .../Lightmap-36_comp_light.exr"                    |   Bin 0 -> 22098 bytes
 .../Lightmap-36_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-37_comp_dir.png"  |   Bin 0 -> 2506 bytes
 .../Lightmap-37_comp_dir.png.meta"                 |   140 +
 .../Lightmap-37_comp_light.exr"                    |   Bin 0 -> 22623 bytes
 .../Lightmap-37_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-38_comp_dir.png"  |   Bin 0 -> 2155 bytes
 .../Lightmap-38_comp_dir.png.meta"                 |   140 +
 .../Lightmap-38_comp_light.exr"                    |   Bin 0 -> 23105 bytes
 .../Lightmap-38_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-39_comp_dir.png"  |   Bin 0 -> 2450 bytes
 .../Lightmap-39_comp_dir.png.meta"                 |   140 +
 .../Lightmap-39_comp_light.exr"                    |   Bin 0 -> 22745 bytes
 .../Lightmap-39_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-3_comp_dir.png"   |   Bin 56961 -> 2138 bytes
 .../Lightmap-3_comp_dir.png.meta"                  |    15 +-
 .../Mapa peque\303\261o/Lightmap-3_comp_light.exr" |   Bin 302737 -> 21829 bytes
 .../Lightmap-3_comp_light.exr.meta"                |    15 +-
 .../Mapa peque\303\261o/Lightmap-40_comp_dir.png"  |   Bin 0 -> 2566 bytes
 .../Lightmap-40_comp_dir.png.meta"                 |   140 +
 .../Lightmap-40_comp_light.exr"                    |   Bin 0 -> 22192 bytes
 .../Lightmap-40_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-41_comp_dir.png"  |   Bin 0 -> 2054 bytes
 .../Lightmap-41_comp_dir.png.meta"                 |   140 +
 .../Lightmap-41_comp_light.exr"                    |   Bin 0 -> 22140 bytes
 .../Lightmap-41_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-42_comp_dir.png"  |   Bin 0 -> 3000 bytes
 .../Lightmap-42_comp_dir.png.meta"                 |   140 +
 .../Lightmap-42_comp_light.exr"                    |   Bin 0 -> 22101 bytes
 .../Lightmap-42_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-43_comp_dir.png"  |   Bin 0 -> 2121 bytes
 .../Lightmap-43_comp_dir.png.meta"                 |   140 +
 .../Lightmap-43_comp_light.exr"                    |   Bin 0 -> 22658 bytes
 .../Lightmap-43_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-44_comp_dir.png"  |   Bin 0 -> 2256 bytes
 .../Lightmap-44_comp_dir.png.meta"                 |   140 +
 .../Lightmap-44_comp_light.exr"                    |   Bin 0 -> 21778 bytes
 .../Lightmap-44_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-45_comp_dir.png"  |   Bin 0 -> 2327 bytes
 .../Lightmap-45_comp_dir.png.meta"                 |   140 +
 .../Lightmap-45_comp_light.exr"                    |   Bin 0 -> 21447 bytes
 .../Lightmap-45_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-46_comp_dir.png"  |   Bin 0 -> 2205 bytes
 .../Lightmap-46_comp_dir.png.meta"                 |   140 +
 .../Lightmap-46_comp_light.exr"                    |   Bin 0 -> 21453 bytes
 .../Lightmap-46_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-47_comp_dir.png"  |   Bin 0 -> 2079 bytes
 .../Lightmap-47_comp_dir.png.meta"                 |   140 +
 .../Lightmap-47_comp_light.exr"                    |   Bin 0 -> 21922 bytes
 .../Lightmap-47_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-48_comp_dir.png"  |   Bin 0 -> 2119 bytes
 .../Lightmap-48_comp_dir.png.meta"                 |   140 +
 .../Lightmap-48_comp_light.exr"                    |   Bin 0 -> 20597 bytes
 .../Lightmap-48_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-49_comp_dir.png"  |   Bin 0 -> 1830 bytes
 .../Lightmap-49_comp_dir.png.meta"                 |   140 +
 .../Lightmap-49_comp_light.exr"                    |   Bin 0 -> 21192 bytes
 .../Lightmap-49_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-4_comp_dir.png"   |   Bin 54981 -> 2162 bytes
 .../Lightmap-4_comp_dir.png.meta"                  |    15 +-
 .../Mapa peque\303\261o/Lightmap-4_comp_light.exr" |   Bin 301704 -> 23146 bytes
 .../Lightmap-4_comp_light.exr.meta"                |    15 +-
 .../Mapa peque\303\261o/Lightmap-50_comp_dir.png"  |   Bin 0 -> 2057 bytes
 .../Lightmap-50_comp_dir.png.meta"                 |   140 +
 .../Lightmap-50_comp_light.exr"                    |   Bin 0 -> 22008 bytes
 .../Lightmap-50_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-51_comp_dir.png"  |   Bin 0 -> 2056 bytes
 .../Lightmap-51_comp_dir.png.meta"                 |   140 +
 .../Lightmap-51_comp_light.exr"                    |   Bin 0 -> 22075 bytes
 .../Lightmap-51_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-52_comp_dir.png"  |   Bin 0 -> 2534 bytes
 .../Lightmap-52_comp_dir.png.meta"                 |   140 +
 .../Lightmap-52_comp_light.exr"                    |   Bin 0 -> 22184 bytes
 .../Lightmap-52_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-53_comp_dir.png"  |   Bin 0 -> 2674 bytes
 .../Lightmap-53_comp_dir.png.meta"                 |   140 +
 .../Lightmap-53_comp_light.exr"                    |   Bin 0 -> 23988 bytes
 .../Lightmap-53_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-54_comp_dir.png"  |   Bin 0 -> 2510 bytes
 .../Lightmap-54_comp_dir.png.meta"                 |   140 +
 .../Lightmap-54_comp_light.exr"                    |   Bin 0 -> 21309 bytes
 .../Lightmap-54_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-55_comp_dir.png"  |   Bin 0 -> 2105 bytes
 .../Lightmap-55_comp_dir.png.meta"                 |   140 +
 .../Lightmap-55_comp_light.exr"                    |   Bin 0 -> 22269 bytes
 .../Lightmap-55_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-56_comp_dir.png"  |   Bin 0 -> 2183 bytes
 .../Lightmap-56_comp_dir.png.meta"                 |   140 +
 .../Lightmap-56_comp_light.exr"                    |   Bin 0 -> 21268 bytes
 .../Lightmap-56_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-57_comp_dir.png"  |   Bin 0 -> 2742 bytes
 .../Lightmap-57_comp_dir.png.meta"                 |   140 +
 .../Lightmap-57_comp_light.exr"                    |   Bin 0 -> 22963 bytes
 .../Lightmap-57_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-58_comp_dir.png"  |   Bin 0 -> 2588 bytes
 .../Lightmap-58_comp_dir.png.meta"                 |   140 +
 .../Lightmap-58_comp_light.exr"                    |   Bin 0 -> 22755 bytes
 .../Lightmap-58_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-59_comp_dir.png"  |   Bin 0 -> 2149 bytes
 .../Lightmap-59_comp_dir.png.meta"                 |   140 +
 .../Lightmap-59_comp_light.exr"                    |   Bin 0 -> 22336 bytes
 .../Lightmap-59_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-5_comp_dir.png"   |   Bin 13729 -> 2386 bytes
 .../Lightmap-5_comp_dir.png.meta"                  |    15 +-
 .../Mapa peque\303\261o/Lightmap-5_comp_light.exr" |   Bin 76467 -> 21417 bytes
 .../Lightmap-5_comp_light.exr.meta"                |    15 +-
 .../Mapa peque\303\261o/Lightmap-60_comp_dir.png"  |   Bin 0 -> 2265 bytes
 .../Lightmap-60_comp_dir.png.meta"                 |   140 +
 .../Lightmap-60_comp_light.exr"                    |   Bin 0 -> 22297 bytes
 .../Lightmap-60_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-61_comp_dir.png"  |   Bin 0 -> 1226 bytes
 .../Lightmap-61_comp_dir.png.meta"                 |   140 +
 .../Lightmap-61_comp_light.exr"                    |   Bin 0 -> 11070 bytes
 .../Lightmap-61_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-62_comp_dir.png"  |   Bin 0 -> 5709 bytes
 .../Lightmap-62_comp_dir.png.meta"                 |   140 +
 .../Lightmap-62_comp_light.exr"                    |   Bin 0 -> 31958 bytes
 .../Lightmap-62_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-63_comp_dir.png"  |   Bin 0 -> 2039 bytes
 .../Lightmap-63_comp_dir.png.meta"                 |   140 +
 .../Lightmap-63_comp_light.exr"                    |   Bin 0 -> 20104 bytes
 .../Lightmap-63_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-64_comp_dir.png"  |   Bin 0 -> 2463 bytes
 .../Lightmap-64_comp_dir.png.meta"                 |   140 +
 .../Lightmap-64_comp_light.exr"                    |   Bin 0 -> 22793 bytes
 .../Lightmap-64_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-65_comp_dir.png"  |   Bin 0 -> 2281 bytes
 .../Lightmap-65_comp_dir.png.meta"                 |   140 +
 .../Lightmap-65_comp_light.exr"                    |   Bin 0 -> 21834 bytes
 .../Lightmap-65_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-66_comp_dir.png"  |   Bin 0 -> 2234 bytes
 .../Lightmap-66_comp_dir.png.meta"                 |   140 +
 .../Lightmap-66_comp_light.exr"                    |   Bin 0 -> 21086 bytes
 .../Lightmap-66_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-67_comp_dir.png"  |   Bin 0 -> 2101 bytes
 .../Lightmap-67_comp_dir.png.meta"                 |   140 +
 .../Lightmap-67_comp_light.exr"                    |   Bin 0 -> 21701 bytes
 .../Lightmap-67_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-68_comp_dir.png"  |   Bin 0 -> 2278 bytes
 .../Lightmap-68_comp_dir.png.meta"                 |   140 +
 .../Lightmap-68_comp_light.exr"                    |   Bin 0 -> 21979 bytes
 .../Lightmap-68_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-69_comp_dir.png"  |   Bin 0 -> 2366 bytes
 .../Lightmap-69_comp_dir.png.meta"                 |   140 +
 .../Lightmap-69_comp_light.exr"                    |   Bin 0 -> 21718 bytes
 .../Lightmap-69_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-6_comp_dir.png"   |   Bin 0 -> 2534 bytes
 .../Lightmap-6_comp_dir.png.meta"                  |   140 +
 .../Mapa peque\303\261o/Lightmap-6_comp_light.exr" |   Bin 0 -> 22629 bytes
 .../Lightmap-6_comp_light.exr.meta"                |   140 +
 .../Mapa peque\303\261o/Lightmap-70_comp_dir.png"  |   Bin 0 -> 30064 bytes
 .../Lightmap-70_comp_dir.png.meta"                 |   140 +
 .../Lightmap-70_comp_light.exr"                    |   Bin 0 -> 81069 bytes
 .../Lightmap-70_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-71_comp_dir.png"  |   Bin 0 -> 24964 bytes
 .../Lightmap-71_comp_dir.png.meta"                 |   140 +
 .../Lightmap-71_comp_light.exr"                    |   Bin 0 -> 72217 bytes
 .../Lightmap-71_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-72_comp_dir.png"  |   Bin 0 -> 25424 bytes
 .../Lightmap-72_comp_dir.png.meta"                 |   140 +
 .../Lightmap-72_comp_light.exr"                    |   Bin 0 -> 73089 bytes
 .../Lightmap-72_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-73_comp_dir.png"  |   Bin 0 -> 5449 bytes
 .../Lightmap-73_comp_dir.png.meta"                 |   140 +
 .../Lightmap-73_comp_light.exr"                    |   Bin 0 -> 26514 bytes
 .../Lightmap-73_comp_light.exr.meta"               |   140 +
 .../Mapa peque\303\261o/Lightmap-7_comp_dir.png"   |   Bin 0 -> 1995 bytes
 .../Lightmap-7_comp_dir.png.meta"                  |   140 +
 .../Mapa peque\303\261o/Lightmap-7_comp_light.exr" |   Bin 0 -> 21928 bytes
 .../Lightmap-7_comp_light.exr.meta"                |   140 +
 .../Mapa peque\303\261o/Lightmap-8_comp_dir.png"   |   Bin 0 -> 1804 bytes
 .../Lightmap-8_comp_dir.png.meta"                  |   140 +
 .../Mapa peque\303\261o/Lightmap-8_comp_light.exr" |   Bin 0 -> 21261 bytes
 .../Lightmap-8_comp_light.exr.meta"                |   140 +
 .../Mapa peque\303\261o/Lightmap-9_comp_dir.png"   |   Bin 0 -> 3125 bytes
 .../Lightmap-9_comp_dir.png.meta"                  |   140 +
 .../Mapa peque\303\261o/Lightmap-9_comp_light.exr" |   Bin 0 -> 21570 bytes
 .../Lightmap-9_comp_light.exr.meta"                |   140 +
 .../NavMesh-NavMesh Surface.asset"                 |   Bin 15288 -> 18496 bytes
 .../OcclusionCullingData.asset"                    |   276 +-
 .../Assets/Scenes/Menu_principal.unity             |   146 +-
 Supermarkert Run/Assets/Scripts/AI/IA.cs           |    42 +-
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |     6 +-
 .../Assets/Scripts/Caja/CajaEnemigo.cs             |    21 +
 .../CajaEnemigo.cs.meta}                           |     2 +-
 .../Scripts/Juego/Mapa/Mapa_peque\303\261o.asset"  |     4 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |    23 +-
 .../Assets/Scripts/Juego/Mapa/SpawMapa1.asset      |    18 +-
 .../Scripts/Jugador/Camara_Objetos_Desaparecer.cs  |    87 -
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |    76 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    84 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |   113 +-
 .../Assets/Scripts/estantes/Contenido_misiones.cs  |    16 +-
 .../Assets/Scripts/estantes/Estante.cs             |    68 +-
 .../Assets/Scripts/estantes/Objeto_caido.cs        |    17 +
 .../Assets/Scripts/estantes/Objeto_caido.cs.meta   |    11 +
 .../Assets/Scripts/estantes/Objeto_random_carro.cs |     2 +
 Supermarkert Run/Assets/shader.meta                |     8 +
 Supermarkert Run/Assets/shader/OutlineCarro.mat    |    46 +
 .../Assets/shader/OutlineCarro.mat.meta            |     8 +
 Supermarkert Run/Assets/shader/outline.shadergraph |   902 ++
 .../Assets/shader/outline.shadergraph.meta         |    10 +
 Supermarkert Run/Assets/shader/outlineCarro1.mat   |    37 +
 .../Assets/shader/outlineCarro1.mat.meta           |     8 +
 Supermarkert Run/Assets/shader/outlineEstante.mat  |    46 +
 .../Assets/shader/outlineEstante.mat.meta          |     8 +
 Supermarkert Run/Assets/shader/outlineObjetos.mat  |    37 +
 .../Assets/shader/outlineObjetos.mat.meta          |     8 +
 .../Assets/shader/outlinePersonaje.mat             |    37 +
 .../Assets/shader/outlinePersonaje.mat.meta        |     8 +
 .../Assets/shader/outlinePersonaje2.mat            |    46 +
 .../Assets/shader/outlinePersonaje2.mat.meta       |     8 +
 .../Assets/shader/outlineSeeThroug.shader          |   179 +
 .../Assets/shader/outlineSeeThroug.shader.meta     |     9 +
 .../Assets/textures/UI_GAME/agarrar_objeto.png     |   Bin 0 -> 87336 bytes
 .../textures/UI_GAME/agarrar_objeto.png.meta       |   140 +
 Supermarkert Run/Packages/manifest.json            |     1 +
 Supermarkert Run/Packages/packages-lock.json       |    27 +
 .../ProjectSettings/InputManager.asset             |   193 +
 .../ProjectSettings/NavMeshAreas.asset             |     2 +-
 .../ProjectSettings/ShaderGraphSettings.asset      |    17 +
 Supermarkert Run/ProjectSettings/TagManager.asset  |     1 +
 391 files changed, 48032 insertions(+), 20368 deletions(-)

=== COMMIT: 5df4087 | Fri Dec 12 20:02:29 2025 -0600 | Agregar enemigo ratero mostrador propio al jugador,nueva menor tiempo a 5 minutos, agregar español, ingles, portugues a los mapas, objeto que sale volando al chocar, un pequeño retarde d elos NPC de menu principal porque al parecer e navmesh no se creaba y ocasionaba error, nuevas animaciones al chocar robar dejar objetos, agregar outline para hacer que los enemigos se vean mas de caricatura sonido de sorpresa, y ahora no se depende de los archivos de traduccion para objetos nueva foto del juego por navidad, modificar navmesh de los mapas por remodelacion el enemigo va a su caja ===
 .../Assets/Objetos/Enemigo/Ratero.prefab           |  7647 ++++++++++++++
 .../Assets/Objetos/Enemigo/Ratero.prefab.meta      |     7 +
 .../Assets/Objetos/Enemigo/enemigo.prefab          |  1940 +++-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |     2 +-
 .../Assets/Objetos/Mapa/Caja/mostrador.prefab      |   374 +-
 .../Objetos/Mapa/Caja/mostrador_no_player.prefab   |   439 +-
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |     2 +-
 .../Assets/Objetos/Mapa/Estanteria (1).obj         |  1006 --
 .../Assets/Objetos/Mapa/Estanteria (1).obj.meta    |   109 -
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   | 10054 ++-----------------
 .../Assets/Objetos/Mapa/Fila2 Variant.prefab       |   138 +-
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |    16 +
 .../Objetos/Objetos_Colocados/Libro/libro.prefab   |    10 +-
 .../Objetos_Colocados/PepelHigienico.obj.meta      |     8 +-
 .../Assets/Objetos/Objetos_Colocados/caja.obj.meta |     8 +-
 .../Objetos/Objetos_Colocados/cajaJugo.obj.meta    |     4 +-
 .../Carrito_aleatorio.prefab                       |     4 +-
 .../carro.mat                                      |     2 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |   352 +-
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |     2 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |    22 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |    36 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |   208 +-
 .../Assets/Scenes/Menu_principal.unity             |   106 +-
 .../Menu_principal/NavMesh-NavMesh Surface.asset   |   Bin 11664 -> 19688 bytes
 Supermarkert Run/Assets/Scripts/AI/EnemigoComun.cs |    24 +
 .../Assets/Scripts/AI/EnemigoComun.cs.meta         |    11 +
 .../Assets/Scripts/AI/EnemigoRatero.cs             |   351 +
 .../Assets/Scripts/AI/EnemigoRatero.cs.meta        |    11 +
 Supermarkert Run/Assets/Scripts/AI/IA.cs           |   151 +-
 .../Assets/Scripts/AI/Seleccion_Carrito_Ai.cs      |    13 +-
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |    80 +-
 .../Car Supermarkert/Liviano/Liviano2.asset        |     2 +-
 Supermarkert Run/Assets/Scripts/Enemigo.meta       |     8 +
 .../Assets/Scripts/Enemigo/BehaviorEnemy.cs        |    23 +
 .../Assets/Scripts/Enemigo/BehaviorEnemy.cs.meta   |    11 +
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs      |     2 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |     2 +-
 .../Assets/Scripts/Juego/Gameplay/Tiempo.cs        |     2 +-
 Supermarkert Run/Assets/Scripts/Juego/Mapa/Mapa.cs |    15 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |     9 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |     9 +-
 .../Scripts/Juego/Mapa/Mapa_peque\303\261o.asset"  |     9 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |    41 +-
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |    29 +-
 .../Assets/Scripts/Juego/Menu/Animacion_Carga.cs   |    40 +-
 .../Assets/Scripts/Juego/Menu/NPC_Menu.cs          |    69 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |     2 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   392 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   181 +-
 Supermarkert Run/Assets/Scripts/estantes/Area.cs   |     8 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |    79 +-
 .../Assets/Scripts/estantes/Objeto_caido.cs        |     3 +-
 Supermarkert Run/Assets/Sonidos/sorpresa.wav       |   Bin 0 -> 140810 bytes
 Supermarkert Run/Assets/Sonidos/sorpresa.wav.meta  |    23 +
 Supermarkert Run/Assets/shader/OutlineCarro.mat    |    46 -
 .../shader/{outlineObjetos.mat => XrayObjetos.mat} |     2 +-
 ...utlineObjetos.mat.meta => XrayObjetos.mat.meta} |     0
 Supermarkert Run/Assets/shader/outline.shadergraph |   902 --
 .../Assets/shader/outline.shadergraph.meta         |    10 -
 Supermarkert Run/Assets/shader/outlineCajas.mat    |    46 +
 ...tlineEstante.mat.meta => outlineCajas.mat.meta} |     2 +-
 Supermarkert Run/Assets/shader/outlineCarroE.mat   |    37 +
 ...utlineCarro.mat.meta => outlineCarroE.mat.meta} |     2 +-
 Supermarkert Run/Assets/shader/outlineEnemigo.mat  |    37 +
 .../Assets/shader/outlineEnemigo.mat.meta          |     8 +
 Supermarkert Run/Assets/shader/outlineEstante.mat  |    46 -
 Supermarkert Run/Assets/shader/outlineManzana.mat  |    46 +
 .../Assets/shader/outlineManzana.mat.meta          |     8 +
 .../Assets/textures/Jugador_Enemigo/Personaje.mat  |    15 +-
 .../Assets/textures/Jugador_Enemigo/Policia.mat    |    83 +
 .../textures/Jugador_Enemigo/Policia.mat.meta      |     8 +
 .../textures/Jugador_Enemigo/simboloPolicia.png    |   Bin 0 -> 93308 bytes
 .../Jugador_Enemigo/simboloPolicia.png.meta        |   140 +
 .../textures/Menu/Supermarker_foto_navidad.jpg     |   Bin 0 -> 53057 bytes
 .../Menu/Supermarker_foto_navidad.jpg.meta         |   140 +
 Supermarkert Run/Packages/manifest.json            |     1 -
 Supermarkert Run/Packages/packages-lock.json       |    27 -
 .../ProjectSettings/NavMeshAreas.asset             |     2 +-
 .../ProjectSettings/ProjectSettings.asset          |    11 +-
 80 files changed, 13831 insertions(+), 11884 deletions(-)

=== COMMIT: d574c05 | Fri Dec 12 21:27:29 2025 -0600 | Arreglar el bug de que no se ve el objeto en el estante y y traductor a las skins del carro ===
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |   2 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 120 ++++++++++-----------
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  40 +++----
 .../Assets/Scripts/Car Supermarkert/Car.cs         |  21 +++-
 .../Scripts/Car Supermarkert/Liviano/Liviano.asset |  14 ++-
 .../Car Supermarkert/Liviano/Liviano2.asset        |  16 ++-
 .../Car Supermarkert/Liviano/Liviano3.asset        |  14 ++-
 .../Car Supermarkert/Liviano/Liviano4.asset        |  14 ++-
 .../Car Supermarkert/Liviano/Liviano5.asset        |  14 ++-
 .../Liviano/Liviano_Personalzado.asset             |  12 ++-
 .../Scripts/Car Supermarkert/Mediano/Mediano.asset |  12 ++-
 .../Car Supermarkert/Mediano/Mediano2.asset        |  12 ++-
 .../Car Supermarkert/Mediano/Mediano3.asset        |  12 ++-
 .../Car Supermarkert/Mediano/Mediano4.asset        |  12 ++-
 .../Car Supermarkert/Mediano/Mediano5.asset        |  12 ++-
 .../Mediano/Mediano_personalizado.asset            |  12 ++-
 .../Scripts/Car Supermarkert/Pesado/Pesado.asset   |  16 ++-
 .../Scripts/Car Supermarkert/Pesado/Pesado2.asset  |  16 ++-
 .../Scripts/Car Supermarkert/Pesado/Pesado3.asset  |  16 ++-
 .../Scripts/Car Supermarkert/Pesado/Pesado4.asset  |  16 ++-
 .../Scripts/Car Supermarkert/Pesado/Pesado5.asset  |  16 ++-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |  33 +++++-
 22 files changed, 308 insertions(+), 144 deletions(-)

=== COMMIT: 3afe8ae | Wed Dec 17 20:02:20 2025 -0600 | Modifica los graficos haciendolo mas de caricatura en la mayoria de objeto, nuevas presentaciones de los powerup y mapas, nuevo objeto decorativo tuberias, agregar xray al charco de agua, ciertas modificaciones para refactorizar codigo, ahora el sistema de guardado es por playerprefs y no por archivos, ya no hay luces dinamicas ya que ocasionan bugs ===
 .../Assets/Objetos/Carrito1/Materials 2/M1.mat     |   93 +
 .../Objetos/Carrito1/Materials 2/M1.mat.meta       |    8 +
 .../Assets/Objetos/Carrito2/Materials2/mat0 1.mat  |   93 +
 .../Objetos/Carrito2/Materials2/mat0 1.mat.meta    |    8 +
 .../Assets/Objetos/Enemigo/Ratero.prefab           |    4 +
 .../Assets/Objetos/Enemigo/enemigo.prefab          |    6 +
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     |   76 +
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |    4 +-
 .../Assets/Objetos/Mapa/Caja/Skin 1.mat            |   93 +
 .../Assets/Objetos/Mapa/Caja/Skin 1.mat.meta       |    8 +
 .../Assets/Objetos/Mapa/Caja/mostrador.prefab      |   12 +-
 .../Objetos/Mapa/Caja/mostrador_no_player.prefab   |   19 +-
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |  190 +-
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |    6 +-
 Supermarkert Run/Assets/Objetos/Mapa/tuberias.obj  | 1747 ++++++
 .../Assets/Objetos/Mapa/tuberias.obj.meta          |  109 +
 Supermarkert Run/Assets/Objetos/Muerte 1.prefab    |   76 +
 .../Assets/Objetos/Objetos_Colocados/Caja_2.mat    |   93 +
 .../Objetos/Objetos_Colocados/Caja_2.mat.meta      |    8 +
 .../Objetos/Objetos_Colocados/Caja_Leche2.mat      |   95 +
 .../Objetos/Objetos_Colocados/Caja_Leche2.mat.meta |    8 +
 .../Escoba/Material/mat0 - copia 1.mat             |   95 +
 .../Escoba/Material/mat0 - copia 1.mat.meta        |    8 +
 .../Objetos_Colocados/Escoba/Material/mat1 1.mat   |   93 +
 .../Escoba/Material/mat1 1.mat.meta                |    8 +
 .../Objetos_Colocados/Escoba/Material/mat2 1.mat   |   93 +
 .../Escoba/Material/mat2 1.mat.meta                |    8 +
 .../Objetos_Colocados/Escoba/escoba.obj.meta       |    6 +-
 .../Hamburguesa/Materiales/Mat02.mat               |   93 +
 .../Hamburguesa/Materiales/Mat02.mat.meta          |    8 +
 .../Hamburguesa/Materiales/mat1 1.mat              |   93 +
 .../Hamburguesa/Materiales/mat1 1.mat.meta         |    8 +
 .../Hamburguesa/Materiales/mat2 1.mat              |   93 +
 .../Hamburguesa/Materiales/mat2 1.mat.meta         |    8 +
 .../Hamburguesa/Materiales/mat2.mat                |    4 +-
 .../Hamburguesa/Materiales/mat3.mat                |    4 +-
 .../Hamburguesa/Materiales/mat4 1.mat              |   93 +
 .../Hamburguesa/Materiales/mat4 1.mat.meta         |    8 +
 .../Hamburguesa/hamburguesa.obj.meta               |    8 +-
 .../Objetos_Colocados/Libro/Material/Mat02.mat     |   93 +
 .../Libro/Material/Mat02.mat.meta                  |    8 +
 .../Objetos_Colocados/Libro/Material/mat0.mat      |    4 +-
 .../Objetos_Colocados/Libro/Material/mat1.mat      |    4 +-
 .../Objetos_Colocados/Libro/Material/mat2 1.mat    |   93 +
 .../Libro/Material/mat2 1.mat.meta                 |    8 +
 .../Objetos_Colocados/Libro/Material/mat3 1.mat    |   96 +
 .../Libro/Material/mat3 1.mat.meta                 |    8 +
 .../Objetos_Colocados/Libro/Material/mat3.mat      |   13 +-
 .../Objetos/Objetos_Colocados/Libro/libro.prefab   |   12 +
 .../Microondas/Materials/Microndas2.mat            |   93 +
 .../Microondas/Materials/Microndas2.mat.meta       |    8 +
 .../Microondas/microondas.obj.meta                 |    2 +-
 .../Assets/Objetos/Objetos_Colocados/caja.obj.meta |    2 +-
 .../Objetos/Objetos_Colocados/cajaJugo.obj.meta    |    2 +-
 .../Carrito_Peq.prefab                             |    8 +
 .../Carrito_aleatorio.prefab                       |    4 +-
 .../Carrito_gra.prefab                             |    8 +
 .../Carrito_med.prefab                             |    8 +
 Supermarkert Run/Assets/SUPERMARKER/datos.json     |    2 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 6329 +++-----------------
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 2138 +------
 .../Assets/Scenes/Mapa peque\303\261o.unity"       | 1151 +---
 .../Assets/Scenes/Menu_principal.unity             | 3575 +++++------
 .../Menu_principal/NavMesh-NavMesh Surface.asset   |  Bin 19688 -> 33336 bytes
 Supermarkert Run/Assets/Scripts/AI/IA.cs           |    6 +-
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |    2 +-
 .../Scripts/Juego/Configuraciones/Calidad.cs       |   17 +-
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs      |    6 +-
 .../Juego/Gameplay/Pase_Conexion_Menu_Gameplay.cs  |    3 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   96 +-
 .../Assets/Scripts/Juego/Gameplay/Tiempo.cs        |   50 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |    2 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |    2 +-
 .../Scripts/Juego/Mapa/Mapa_peque\303\261o.asset"  |    2 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |    3 +-
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |   46 +-
 .../Assets/Scripts/Juego/Menu/NPC_Menu.cs          |    6 +-
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |   91 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |    2 +-
 Supermarkert Run/Assets/Scripts/Jugador/DINERO.cs  |    3 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   45 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   23 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |    2 +-
 .../Assets/Scripts/PowerUp/Interfaz_PowerUp.cs     |   14 +-
 .../Assets/Scripts/PowerUp/Manos_Rapidas.cs        |    8 +-
 .../Assets/Scripts/PowerUp/Proteccion.cs           |    4 +-
 .../Assets/Scripts/PowerUp/Velocidad.cs            |    4 +-
 Supermarkert Run/Assets/Sonidos/SonidoGameplay.wav |  Bin 0 -> 24371278 bytes
 .../Assets/Sonidos/SonidoGameplay.wav.meta         |   23 +
 Supermarkert Run/Assets/shader/celshadding.meta    |    8 +
 .../Assets/shader/celshadding/celShadding.shader   |  190 +
 .../shader/celshadding/celShadding.shader.meta     |    9 +
 .../Assets/shader/celshadding/celshadding.mat      |   45 +
 .../Assets/shader/celshadding/celshadding.mat.meta |    8 +
 .../Assets/shader/celshadding/celshaddingAgua.mat  |   45 +
 .../shader/celshadding/celshaddingAgua.mat.meta    |    8 +
 .../Assets/shader/celshadding/celshaddingNPC.mat   |   45 +
 .../shader/celshadding/celshaddingNPC.mat.meta     |    8 +
 .../shader/celshadding/celshaddingPared 1.mat      |   36 +
 .../shader/celshadding/celshaddingPared 1.mat.meta |    8 +
 .../Assets/shader/celshadding/celshaddingPared.mat |   45 +
 .../shader/celshadding/celshaddingPared.mat.meta   |    8 +
 .../Assets/shader/celshadding/celshaddingPiso.mat  |   45 +
 .../shader/celshadding/celshaddingPiso.mat.meta    |    8 +
 .../celshadding/celshaddingSe\303\261al.mat"       |   45 +
 .../celshadding/celshaddingSe\303\261al.mat.meta"  |    8 +
 Supermarkert Run/Assets/shader/outline.meta        |    8 +
 .../Assets/shader/outline/XrayAgua.mat             |   37 +
 .../Assets/shader/outline/XrayAgua.mat.meta        |    8 +
 .../Assets/shader/{ => outline}/XrayObjetos.mat    |    4 +-
 .../shader/{ => outline}/XrayObjetos.mat.meta      |    0
 .../Assets/shader/outline/XraySe\303\261al.mat"    |   37 +
 .../shader/outline/XraySe\303\261al.mat.meta"      |    8 +
 .../Assets/shader/{ => outline}/outlineCajas.mat   |    4 +-
 .../shader/{ => outline}/outlineCajas.mat.meta     |    0
 .../Assets/shader/{ => outline}/outlineCarro1.mat  |    4 +-
 .../shader/{ => outline}/outlineCarro1.mat.meta    |    0
 .../Assets/shader/{ => outline}/outlineCarroE.mat  |    4 +-
 .../shader/{ => outline}/outlineCarroE.mat.meta    |    0
 .../Assets/shader/{ => outline}/outlineEnemigo.mat |   10 +-
 .../shader/{ => outline}/outlineEnemigo.mat.meta   |    0
 .../Assets/shader/{ => outline}/outlineManzana.mat |    4 +-
 .../shader/{ => outline}/outlineManzana.mat.meta   |    0
 .../shader/{ => outline}/outlinePersonaje.mat      |    4 +-
 .../shader/{ => outline}/outlinePersonaje.mat.meta |    0
 .../shader/{ => outline}/outlinePersonaje2.mat     |    4 +-
 .../{ => outline}/outlinePersonaje2.mat.meta       |    0
 .../shader/{ => outline}/outlineSeeThroug.shader   |    0
 .../{ => outline}/outlineSeeThroug.shader.meta     |    0
 .../Assets/textures/Mapas/Grande/MapaGrande.png    |  Bin 0 -> 769724 bytes
 .../textures/Mapas/Grande/MapaGrande.png.meta      |  140 +
 .../Assets/textures/Mapas/Mediano/MapaMediano.png  |  Bin 0 -> 473420 bytes
 .../textures/Mapas/Mediano/MapaMediano.png.meta    |  140 +
 .../Mapas/Peque\303\261o/MapaPeque\303\261o.png"   |  Bin 0 -> 528350 bytes
 .../Peque\303\261o/MapaPeque\303\261o.png.meta"    |  140 +
 Supermarkert Run/Assets/textures/Menu/Boton.png    |  Bin 0 -> 7885 bytes
 .../Assets/textures/Menu/Boton.png.meta            |  140 +
 .../Assets/textures/PowerUp/Manos Rapidas.mat      |    2 +-
 .../Assets/textures/PowerUp/PUEscudo.png           |  Bin 0 -> 181195 bytes
 .../Assets/textures/PowerUp/PUEscudo.png.meta      |  140 +
 .../Assets/textures/PowerUp/PUManosRapidas.png     |  Bin 0 -> 178855 bytes
 .../textures/PowerUp/PUManosRapidas.png.meta       |  140 +
 .../Assets/textures/PowerUp/PUVelocidad.png        |  Bin 0 -> 264008 bytes
 .../Assets/textures/PowerUp/PUVelocidad.png.meta   |  140 +
 .../Assets/textures/PowerUp/Protetion.mat          |    2 +-
 Supermarkert Run/Assets/textures/PowerUp/Speed.mat |    2 +-
 .../Assets/textures/Supermercado/Estante 1.mat     |   93 +
 .../textures/Supermercado/Estante 1.mat.meta       |    8 +
 .../Assets/textures/Supermercado/Estante 2.mat     |   93 +
 .../textures/Supermercado/Estante 2.mat.meta       |    8 +
 .../Assets/textures/Supermercado/Tubo.mat          |   93 +
 .../Assets/textures/Supermercado/Tubo.mat.meta     |    8 +
 152 files changed, 8919 insertions(+), 10691 deletions(-)

=== COMMIT: 038c30d | Fri Dec 19 14:05:28 2025 -0600 | Optimizaciones, eliminando materiales innecesarios de los objetos y haciendo que otros se instancien en la GPU para evitar duplicados ===
 .../Assets/Objetos/Enemigo/Ratero.prefab           |   18 +-
 .../Assets/Objetos/Enemigo/enemigo.prefab          |   18 +-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   18 +-
 .../Escoba/Material/mat0 - copia.mat               |    2 +-
 .../Objetos_Colocados/Escoba/Material/mat0.mat     |    2 +-
 .../Objetos_Colocados/Escoba/Material/mat1.mat     |    2 +-
 .../Objetos_Colocados/Escoba/Material/mat2.mat     |    2 +-
 .../Hamburguesa/Materiales/mat0.mat                |    2 +-
 .../Hamburguesa/Materiales/mat1.mat                |    2 +-
 .../Hamburguesa/Materiales/mat4.mat                |    2 +-
 .../Hamburguesa/Materiales/mat5.mat                |    2 +-
 .../Hamburguesa/Materiales/mat6.mat                |    2 +-
 .../Hamburguesa/Materiales/materiacop.mat          |    2 +-
 .../Libro/Material/mat0 - copia.mat                |    2 +-
 .../Objetos_Colocados/Libro/Material/mat2.mat      |    2 +-
 .../CarroMenu.mat                                  |   93 ++
 .../CarroMenu.mat.meta                             |    8 +
 .../carro.mat                                      |   14 +-
 .../Assets/Scenes/Menu_principal.unity             | 1577 +++++++-------------
 .../textures/Carritos/Grande/PersonalizadaGra.mat  |    2 +-
 .../textures/Carritos/Mediano/PersonalizadaMed.mat |    2 +-
 .../textures/Carritos/Pequenio/Personalizada.mat   |    2 +-
 .../textures/Carritos/Pequenio/Principal.mat       |    2 +-
 .../Assets/textures/Carritos/Pequenio/chica.mat    |   14 +-
 .../Assets/textures/Carritos/Pequenio/diamante.mat |   14 +-
 .../Assets/textures/Carritos/Pequenio/oro.mat      |   14 +-
 .../Assets/textures/Carritos/Pequenio/plata.mat    |   14 +-
 .../Assets/textures/Menu/CarritosFondo.mat         |   86 ++
 .../Assets/textures/Menu/CarritosFondo.mat.meta    |    8 +
 .../Assets/textures/Menu/CarritosSuperFondo.png    |  Bin 0 -> 114888 bytes
 .../textures/Menu/CarritosSuperFondo.png.meta      |  140 ++
 .../Assets/textures/Menu/CarroAzul.png             |  Bin 0 -> 33769 bytes
 .../Assets/textures/Menu/CarroAzul.png.meta        |  140 ++
 .../Assets/textures/Menu/CarroDerecha.png          |  Bin 0 -> 41563 bytes
 .../Assets/textures/Menu/CarroDerecha.png.meta     |  140 ++
 .../Assets/textures/Menu/CarroNaranja.png          |  Bin 0 -> 20786 bytes
 .../Assets/textures/Menu/CarroNaranja.png.meta     |  140 ++
 .../Assets/textures/Menu/Materials.meta            |    8 +
 .../Assets/textures/Menu/Materials/CarroFondo.mat  |   94 ++
 .../textures/Menu/Materials/CarroFondo.mat.meta    |    8 +
 .../textures/Menu/Materials/CarroFondoAzul.mat     |   34 +
 .../Menu/Materials/CarroFondoAzul.mat.meta         |    8 +
 .../textures/Menu/Materials/CarroFondoNaranja.mat  |   34 +
 .../Menu/Materials/CarroFondoNaranja.mat.meta      |    8 +
 44 files changed, 1625 insertions(+), 1057 deletions(-)

=== COMMIT: e8d15a4 | Sat Jan 3 01:30:36 2026 -0600 | optimizar y compilar a SDK 36 parte 1 ===
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   80 +-
 .../Mapa/Caja/ImageToStl.com_checkout.obj.meta     |    2 +-
 .../Materiales => Mapa/Caja/Materials}/mat0.mat    |    6 +-
 .../Caja/Materials}/mat0.mat.meta                  |    2 +-
 .../mat4.mat => Mapa/Caja/Materials/mat1.mat}      |    8 +-
 .../Caja/Materials}/mat1.mat.meta                  |    2 +-
 .../Materiales => Mapa/Caja/Materials}/mat2.mat    |    8 +-
 .../Caja/Materials}/mat2.mat.meta                  |    2 +-
 .../Objetos/Mapa/Caja/mostrador_no_player.prefab   | 3236 ++++----
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   | 1268 ++--
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |   84 +
 .../Objetos/Mapa/Signal_Water/Signal.obj.meta      |    2 +-
 .../Assets/Objetos/Mapa/Water_floor/Water.obj.meta |    2 +-
 .../Assets/Objetos/Mapa/estanteria.obj.meta        |    2 +-
 .../Assets/Objetos/Mapa/tuberias.obj.meta          |    4 +-
 .../Hamburguesa/Materiales/materiacop.mat          |   86 -
 .../Libro/Material/LibroEstante.meta               |    8 +
 .../Libro/Material/{ => LibroEstante}/mat0.mat     |    0
 .../Material/LibroEstante/mat0.mat.meta}           |    2 +-
 .../Material/LibroEstante}/mat1.mat                |    4 +-
 .../Libro/Material/LibroEstante/mat1.mat.meta      |    8 +
 .../Libro/Material/{ => LibroEstante}/mat2 1.mat   |    0
 .../Material/{ => LibroEstante}/mat2 1.mat.meta    |    4 +-
 .../Libro/Material/{ => LibroEstante}/mat3 1.mat   |    0
 .../Material/{ => LibroEstante}/mat3 1.mat.meta    |    4 +-
 .../Libro/Material/Mat02.mat.meta                  |    8 -
 .../Objetos_Colocados/Libro/Material/mat0.mat.meta |    8 -
 .../Objetos/Objetos_Colocados/Libro/libro.prefab   |   10 +-
 .../Materials/Gradient_baseColor 1.mat}            |   40 +-
 .../Materials/Gradient_baseColor 1.mat.meta}       |    2 +-
 .../Objetos_Colocados/PepelHigienico.obj.meta      |    2 +-
 .../Assets/Objetos/Objetos_Colocados/caja.obj.meta |    2 +-
 .../Objetos/Objetos_Colocados/cajaJugo.obj.meta    |    2 +-
 .../Carrito_Peq.prefab                             |   36 +
 .../Carrito_aleatorio.prefab                       |   93 +-
 .../Assets/Objetos/Shopping/carrito-1.obj          | 7767 ++++++++++++++++++++
 .../Assets/Objetos/Shopping/carrito-1.obj.meta     |  109 +
 Supermarkert Run/Assets/Plugins.meta               |    8 +
 Supermarkert Run/Assets/Plugins/Android.meta       |    8 +
 .../Assets/Plugins/Android/mainTemplate.gradle     |   42 +
 .../Plugins/Android/mainTemplate.gradle.meta       |    7 +
 .../Assets/Scenes/Menu_principal.unity             | 2237 ++++--
 .../Menu_principal/NavMesh-NavMesh Surface.asset   |  Bin 33336 -> 30148 bytes
 .../Menu_principal/OcclusionCullingData.asset      |   34 +
 .../Menu_principal/OcclusionCullingData.asset.meta |    8 +
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |    2 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |   17 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |   17 +-
 Supermarkert Run/Assets/Scripts/Optimizador.meta   |    8 +
 .../Scripts/Optimizador/CombineMeshScript.cs       |   79 +
 .../Scripts/Optimizador/CombineMeshScript.cs.meta  |   11 +
 Supermarkert Run/Assets/Scripts/estantes/Area.cs   |   12 +-
 .../Assets/Scripts/estantes/Estante.cs             |    8 +-
 .../ProjectSettings/ProjectSettings.asset          |    4 +-
 .../ProjectSettings/QualitySettings.asset          |   20 +-
 55 files changed, 12419 insertions(+), 3006 deletions(-)

=== COMMIT: c3f2638 | Wed Jan 14 11:54:56 2026 -0600 | optimizar y compilar a SDK 36 parte 2 ya completada, cambio a version 6 de unity, eliminar advertencias de unity con su nueva API, nuevos modelos para mayor optimizacion, arreglar bugs de los mapas por los nuevos modelos ===
 .../.cmake/api/v1/query/client-agp/cache-v2        |       0
 .../.cmake/api/v1/query/client-agp/cmakeFiles-v1   |       0
 .../.cmake/api/v1/query/client-agp/codemodel-v2    |       0
 .../v1/reply/cache-v2-5042dd4a19b37a905837.json    |    1383 +
 .../reply/cmakeFiles-v1-0b1f71e3a873c27119a8.json  |     195 +
 .../reply/codemodel-v2-595878ad53c76946cc14.json   |      87 +
 ...tory-.-RelWithDebInfo-d0094a50bb2071803777.json |      14 +
 ...Pacing-RelWithDebInfo-7f9c8865fd027a154c90.json |      14 +
 .../v1/reply/index-2026-01-05T05-24-03-0344.json   |      92 +
 ...rapper-RelWithDebInfo-11623928582d6a19a3e6.json |     174 +
 .../RelWithDebInfo/712u3l40/arm64-v8a/.ninja_deps  |     Bin 0 -> 10908 bytes
 .../RelWithDebInfo/712u3l40/arm64-v8a/.ninja_log   |       5 +
 .../712u3l40/arm64-v8a/CMakeCache.txt              |     415 +
 .../3.22.1-g37088a8-dirty/CMakeCCompiler.cmake     |      72 +
 .../3.22.1-g37088a8-dirty/CMakeCXXCompiler.cmake   |      83 +
 .../CMakeDetermineCompilerABI_C.bin                |     Bin 0 -> 8072 bytes
 .../CMakeDetermineCompilerABI_CXX.bin              |     Bin 0 -> 8200 bytes
 .../3.22.1-g37088a8-dirty/CMakeSystem.cmake        |      15 +
 .../CompilerIdC/CMakeCCompilerId.c                 |     803 +
 .../CompilerIdC/CMakeCCompilerId.o                 |     Bin 0 -> 6032 bytes
 .../CompilerIdCXX/CMakeCXXCompilerId.cpp           |     791 +
 .../CompilerIdCXX/CMakeCXXCompilerId.o             |     Bin 0 -> 6040 bytes
 .../712u3l40/arm64-v8a/CMakeFiles/CMakeOutput.log  |     262 +
 .../arm64-v8a/CMakeFiles/TargetDirectories.txt     |       5 +
 .../arm64-v8a/CMakeFiles/cmake.check_cache         |       1 +
 .../712u3l40/arm64-v8a/CMakeFiles/rules.ninja      |      64 +
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |     Bin 0 -> 23608 bytes
 .../arm64-v8a/FramePacing/cmake_install.cmake      |      44 +
 .../arm64-v8a/additional_project_files.txt         |       1 +
 .../712u3l40/arm64-v8a/android_gradle_build.json   |      39 +
 .../arm64-v8a/android_gradle_build_mini.json       |      28 +
 .../RelWithDebInfo/712u3l40/arm64-v8a/build.ninja  |     187 +
 .../712u3l40/arm64-v8a/build_file_index.txt        |       2 +
 .../712u3l40/arm64-v8a/cmake_install.cmake         |      60 +
 .../712u3l40/arm64-v8a/compile_commands.json       |       7 +
 .../712u3l40/arm64-v8a/compile_commands.json.bin   |     Bin 0 -> 1589 bytes
 .../712u3l40/arm64-v8a/configure_fingerprint.bin   |      30 +
 .../arm64-v8a/metadata_generation_command.txt      |      21 +
 .../712u3l40/arm64-v8a/prefab_config.json          |       7 +
 .../712u3l40/arm64-v8a/symbol_folder_index.txt     |       1 +
 .../.cmake/api/v1/query/client-agp/cache-v2        |       0
 .../.cmake/api/v1/query/client-agp/cmakeFiles-v1   |       0
 .../.cmake/api/v1/query/client-agp/codemodel-v2    |       0
 .../v1/reply/cache-v2-f92a60264af9c7b5184f.json    |    1415 +
 .../reply/cmakeFiles-v1-5762303eab4422997d1c.json  |     810 +
 .../reply/codemodel-v2-24a6d537b48c8c74a587.json   |      87 +
 ...tory-.-RelWithDebInfo-d0094a50bb2071803777.json |      14 +
 ...Pacing-RelWithDebInfo-7f9c8865fd027a154c90.json |      14 +
 .../v1/reply/index-2026-01-05T05-24-08-0998.json   |      92 +
 ...rapper-RelWithDebInfo-f9b781a8c5026672caa6.json |     174 +
 .../712u3l40/armeabi-v7a/.ninja_deps               |     Bin 0 -> 10656 bytes
 .../RelWithDebInfo/712u3l40/armeabi-v7a/.ninja_log |       3 +
 .../712u3l40/armeabi-v7a/CMakeCache.txt            |     415 +
 .../3.22.1-g37088a8-dirty/CMakeCCompiler.cmake     |      72 +
 .../3.22.1-g37088a8-dirty/CMakeCXXCompiler.cmake   |      83 +
 .../CMakeDetermineCompilerABI_C.bin                |     Bin 0 -> 6176 bytes
 .../CMakeDetermineCompilerABI_CXX.bin              |     Bin 0 -> 6304 bytes
 .../3.22.1-g37088a8-dirty/CMakeSystem.cmake        |      15 +
 .../CompilerIdC/CMakeCCompilerId.c                 |     803 +
 .../CompilerIdC/CMakeCCompilerId.o                 |     Bin 0 -> 4124 bytes
 .../CompilerIdCXX/CMakeCXXCompilerId.cpp           |     791 +
 .../CompilerIdCXX/CMakeCXXCompilerId.o             |     Bin 0 -> 4160 bytes
 .../armeabi-v7a/CMakeFiles/CMakeOutput.log         |     264 +
 .../armeabi-v7a/CMakeFiles/TargetDirectories.txt   |       5 +
 .../armeabi-v7a/CMakeFiles/cmake.check_cache       |       1 +
 .../712u3l40/armeabi-v7a/CMakeFiles/rules.ninja    |      64 +
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |     Bin 0 -> 17060 bytes
 .../armeabi-v7a/FramePacing/cmake_install.cmake    |      44 +
 .../armeabi-v7a/additional_project_files.txt       |       1 +
 .../712u3l40/armeabi-v7a/android_gradle_build.json |      39 +
 .../armeabi-v7a/android_gradle_build_mini.json     |      28 +
 .../712u3l40/armeabi-v7a/build.ninja               |     190 +
 .../712u3l40/armeabi-v7a/build_file_index.txt      |       2 +
 .../712u3l40/armeabi-v7a/cmake_install.cmake       |      60 +
 .../712u3l40/armeabi-v7a/compile_commands.json     |       7 +
 .../712u3l40/armeabi-v7a/compile_commands.json.bin |     Bin 0 -> 1630 bytes
 .../712u3l40/armeabi-v7a/configure_fingerprint.bin |      30 +
 .../armeabi-v7a/metadata_generation_command.txt    |      21 +
 .../712u3l40/armeabi-v7a/prefab_config.json        |       7 +
 .../712u3l40/armeabi-v7a/symbol_folder_index.txt   |       1 +
 .../.utmp/RelWithDebInfo/712u3l40/hash_key.txt     |      28 +
 .../games-frame-pacingConfig.cmake                 |      18 +
 .../games-frame-pacingConfig.cmake                 |      18 +
 .../tools/release/arm64-v8a/compile_commands.json  |       7 +
 .../release/armeabi-v7a/compile_commands.json      |       7 +
 .../Objetos/Mapa/Caja/mostrador_no_player.prefab   |     146 +-
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |      31 +-
 .../Assets/Objetos/Mapa/Estanteria 1.obj.meta      |       9 +-
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |    4770 +-
 .../Assets/Objetos/Mapa/Fila2 Variant.prefab       |     531 -
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |     871 +-
 .../Assets/Objetos/Mapa/Puerta/Materials.meta      |       8 +
 .../Objetos/Mapa/Puerta/Materials/Material.001.mat |      84 +
 .../Mapa/Puerta/Materials/Material.001.mat.meta    |       8 +
 .../Objetos/Mapa/Puerta/Materials/Material.003.mat |      84 +
 .../Mapa/Puerta/Materials/Material.003.mat.meta    |       8 +
 .../Assets/Objetos/Mapa/Puerta/Puerta.fbx          |     Bin 0 -> 79228 bytes
 .../Assets/Objetos/Mapa/Puerta/Puerta.fbx.meta     |     120 +
 .../Objetos/Mapa/Puerta/PuertaAnimacion.prefab     |     268 +
 .../PuertaAnimacion.prefab.meta}                   |       2 +-
 .../Assets/Objetos/Objetos_Colocados/Caja.meta     |       8 +
 .../Objetos_Colocados/Caja/Estanteria5x2Caja.mtl   |      22 +
 .../Caja/Estanteria5x2Caja.mtl.meta}               |       2 +-
 .../Objetos_Colocados/Caja/Estanteria5x2Caja.obj   |   39477 +
 .../Caja/Estanteria5x2Caja.obj.meta                |     120 +
 .../Objetos_Colocados/Caja/EstanteriaCaja.mtl      |      32 +
 .../Objetos_Colocados/Caja/EstanteriaCaja.mtl.meta |       7 +
 .../Objetos_Colocados/Caja/EstanteriaCaja.obj      |   46604 +
 .../Objetos_Colocados/Caja/EstanteriaCaja.obj.meta |     120 +
 .../Objetos_Colocados/Escoba/EstanteEscoba.mtl     |      22 +
 .../Escoba/EstanteEscoba.mtl.meta                  |       7 +
 .../Objetos_Colocados/Escoba/EstanteEscoba.obj     |  300307 ++++
 .../Escoba/EstanteEscoba.obj.meta                  |     120 +
 .../Objetos_Colocados/Escoba/EstanteEscoba5x2.mtl  |      22 +
 .../Escoba/EstanteEscoba5x2.mtl.meta               |       7 +
 .../Objetos_Colocados/Escoba/EstanteEscoba5x2.obj  |  291183 ++++
 .../Escoba/EstanteEscoba5x2.obj.meta               |     120 +
 .../Objetos_Colocados/Escoba/Material/Escoba.png   |     Bin 0 -> 23753 bytes
 .../Escoba/Material/Escoba.png.meta}               |      30 +-
 .../Escoba/Material/Material.001 1.mat             |      94 +
 .../Escoba/Material/Material.001 1.mat.meta        |       8 +
 .../Escoba/Material/Material.001 2.mat             |      84 +
 .../Escoba/Material/Material.001 2.mat.meta        |       8 +
 .../Escoba/Material/Material.001.mat               |      84 +
 .../Escoba/Material/Material.001.mat.meta          |       8 +
 .../Escoba/Material/Material.019.mat               |      84 +
 .../Escoba/Material/Material.019.mat.meta          |       8 +
 .../Escoba/Material/Material.023.mat               |      84 +
 .../Escoba/Material/Material.023.mat.meta          |       8 +
 .../Hamburguesa/EstanteComida.mtl                  |      52 +
 .../Hamburguesa/EstanteComida.mtl.meta             |       7 +
 .../Hamburguesa/EstanteComida.obj                  |  852351 ++++++++++++
 .../Hamburguesa/EstanteComida.obj.meta             |     135 +
 .../Hamburguesa/EstanteComida5x2.mtl               |      52 +
 .../Hamburguesa/EstanteComida5x2.mtl.meta          |       7 +
 .../Hamburguesa/EstanteComida5x2.obj               |  632814 +++++++++
 .../Hamburguesa/EstanteComida5x2.obj.meta          |     135 +
 .../Hamburguesa/Materiales/Hamburguesa.png         |     Bin 0 -> 41672 bytes
 .../Hamburguesa/Materiales/Hamburguesa.png.meta}   |      30 +-
 .../Hamburguesa/Materiales/Material.001 1.mat      |      94 +
 .../Hamburguesa/Materiales/Material.001 1.mat.meta |       8 +
 .../Hamburguesa/Materiales/Material.001.mat        |      84 +
 .../Hamburguesa/Materiales/Material.001.mat.meta   |       8 +
 .../Objetos_Colocados/Libro/EstanteLibro.mtl       |      22 +
 .../Objetos_Colocados/Libro/EstanteLibro.mtl.meta  |       7 +
 .../Objetos_Colocados/Libro/EstanteLibro.obj       |  318171 +++++
 .../Objetos_Colocados/Libro/EstanteLibro.obj.meta  |     120 +
 .../Objetos_Colocados/Libro/EstanteLibro5x2.mtl    |      22 +
 .../Libro/EstanteLibro5x2.mtl.meta                 |       7 +
 .../Objetos_Colocados/Libro/EstanteLibro5x2.obj    |  214150 +++
 .../Libro/EstanteLibro5x2.obj.meta                 |     120 +
 .../Libro/Material/Material.001 1.mat              |      94 +
 .../Libro/Material/Material.001 1.mat.meta         |       8 +
 .../Libro/Material/Material.001.mat                |      84 +
 .../Libro/Material/Material.001.mat.meta           |       8 +
 .../Objetos_Colocados/Libro/Material/libro.png     |     Bin 0 -> 41449 bytes
 .../Libro/Material/libro.png.meta                  |     130 +
 .../Objetos_Colocados/Manzana/EstanteManzana.mtl   |      22 +
 .../Manzana/EstanteManzana.mtl.meta                |       7 +
 .../Objetos_Colocados/Manzana/EstanteManzana.obj   |  294774 ++++
 .../Manzana/EstanteManzana.obj.meta                |     120 +
 .../Manzana/EstanteManzana5x2.mtl                  |      32 +
 .../Manzana/EstanteManzana5x2.mtl.meta             |       7 +
 .../Manzana/EstanteManzana5x2.obj                  |  192351 +++
 .../Manzana/EstanteManzana5x2.obj.meta             |     125 +
 .../Manzana/Materials/Gradient_baseColor 1.mat     |       3 +-
 .../Microondas/EstanteTecnologia.mtl               |      32 +
 .../Microondas/EstanteTecnologia.mtl.meta          |       7 +
 .../Microondas/EstanteTecnologia.obj               |   58453 +
 .../Microondas/EstanteTecnologia.obj.meta          |     125 +
 .../Microondas/EstanteTecnologia5x2.mtl            |      32 +
 .../Microondas/EstanteTecnologia5x2.mtl.meta       |       7 +
 .../Microondas/EstanteTecnologia5x2.obj            |   51344 +
 .../Microondas/EstanteTecnologia5x2.obj.meta       |     125 +
 .../Microondas/RGB_texture_baseColor.png.meta      |      24 +-
 .../Microondas/microondas.obj.meta                 |      17 +-
 .../Assets/Objetos/Objetos_Colocados/cajaJugo.meta |       8 +
 .../Objetos_Colocados/cajaJugo/EstanteJugo.mtl     |      42 +
 .../cajaJugo/EstanteJugo.mtl.meta                  |       7 +
 .../Objetos_Colocados/cajaJugo/EstanteJugo.obj     |  162811 +++
 .../cajaJugo/EstanteJugo.obj.meta                  |     130 +
 .../Objetos_Colocados/cajaJugo/EstanteJugo5x2.mtl  |      42 +
 .../cajaJugo/EstanteJugo5x2.mtl.meta               |       7 +
 .../Objetos_Colocados/cajaJugo/EstanteJugo5x2.obj  |  113837 ++
 .../cajaJugo/EstanteJugo5x2.obj.meta               |     130 +
 .../Objetos_Colocados/cajaJugo/Materials.meta      |       8 +
 .../Assets/Objetos/Objetos_Colocados/rollo.meta    |       8 +
 .../Objetos_Colocados/rollo/EstanteRollo.mtl       |      22 +
 .../Objetos_Colocados/rollo/EstanteRollo.mtl.meta  |       7 +
 .../Objetos_Colocados/rollo/EstanteRollo.obj       | 1192574 ++++++++++++++++
 .../Objetos_Colocados/rollo/EstanteRollo.obj.meta  |     120 +
 .../Objetos_Colocados/rollo/EstanteRollo5x2.mtl    |      32 +
 .../rollo/EstanteRollo5x2.mtl.meta                 |       7 +
 .../Objetos_Colocados/rollo/EstanteRollo5x2.obj    | 1225794 +++++++++++++++++
 .../rollo/EstanteRollo5x2.obj.meta                 |     125 +
 .../Objetos/Objetos_Colocados/rollo/Materials.meta |       8 +
 .../rollo/Materials/Material.001 1.mat             |      84 +
 .../rollo/Materials/Material.001 1.mat.meta        |       8 +
 .../rollo/Materials/Material.001.mat               |      84 +
 .../rollo/Materials/Material.001.mat.meta          |       8 +
 .../rollo/Materials/Material.019.mat               |      84 +
 .../rollo/Materials/Material.019.mat.meta          |       8 +
 .../rollo/Materials/Material.023.mat               |      84 +
 .../rollo/Materials/Material.023.mat.meta          |       8 +
 .../Objetos_Colocados/rollo/Materials/Material.mat |      84 +
 .../rollo/Materials/Material.mat.meta              |       8 +
 .../Carrito_aleatorio.prefab                       |      14 +-
 .../Assets/Plugins/Android/mainTemplate.gradle     |      42 -
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |      78 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |     388 +-
 .../Mapa mediano/NavMesh-NavMesh Surface.asset     |     Bin 42112 -> 157640 bytes
 .../Scenes/Mapa mediano/OcclusionCullingData.asset |     454 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |     535 +-
 .../NavMesh-NavMesh Surface.asset"                 |     Bin 18496 -> 64752 bytes
 .../OcclusionCullingData.asset"                    |     242 +-
 .../Assets/Scenes/Menu_principal.unity             |    1911 +-
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |       2 +-
 .../Assets/Scripts/Car Supermarkert/Car.cs         |       4 +-
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |       2 +-
 .../Scripts/Car Supermarkert/Personalizacion.cs    |       2 +-
 .../Scripts/Juego/Configuraciones/Calidad.cs       |       4 +-
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs      |       2 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |      12 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |       4 +-
 .../Scripts/Juego/Mapa/Mapa_peque\303\261o.asset"  |       2 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |      13 +-
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |       6 +-
 .../Assets/Scripts/Juego/Mapa/SpawMapa1.asset      |      16 +-
 .../Assets/Scripts/Juego/Mapa/SpawnMapa2.asset     |      42 +-
 .../Assets/Scripts/Juego/Mapa/SpawnPointLaser.cs   |      10 +
 .../Assets/Scripts/Juego/Menu/Animacion_Carga.cs   |       4 +-
 .../Assets/Scripts/Juego/Menu/Animacion_Puerta.cs  |      14 +-
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |       2 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |      14 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |      12 +-
 .../Assets/Scripts/Jugador/Seleccion_Carrito.cs    |       2 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |      18 +-
 .../Scripts/Optimizador/CombineMeshScript.cs       |     113 +-
 .../Assets/Scripts/PowerUp/Manos_Rapidas.cs        |       2 +-
 .../Assets/Scripts/PowerUp/Proteccion.cs           |       2 +-
 .../Assets/Scripts/PowerUp/Velocidad.cs            |       2 +-
 .../LiberationSans SDF - Fallback.asset            |      38 +-
 .../Style Sheets/Default Style Sheet.asset         |      23 +-
 .../TextMesh Pro/Resources/TMP Settings.asset      |      17 +-
 .../Assets/TextMesh Pro/Shaders/SDFFunctions.hlsl  |     178 +
 .../TextMesh Pro/Shaders/SDFFunctions.hlsl.meta    |      10 +
 .../Shaders/TMP_Bitmap-Custom-Atlas.shader         |      72 +-
 .../TextMesh Pro/Shaders/TMP_Bitmap-Mobile.shader  |      52 +-
 .../Assets/TextMesh Pro/Shaders/TMP_Bitmap.shader  |      62 +-
 .../TextMesh Pro/Shaders/TMP_SDF Overlay.shader    |      83 +-
 .../Assets/TextMesh Pro/Shaders/TMP_SDF SSD.shader |      95 +-
 .../Shaders/TMP_SDF-HDRP LIT.shadergraph           |   12074 +
 .../Shaders/TMP_SDF-HDRP LIT.shadergraph.meta      |      10 +
 .../Shaders/TMP_SDF-HDRP UNLIT.shadergraph         |   11759 +
 .../Shaders/TMP_SDF-HDRP UNLIT.shadergraph.meta    |      10 +
 .../Shaders/TMP_SDF-Mobile Masking.shader          |      77 +-
 .../Shaders/TMP_SDF-Mobile Overlay.shader          |      68 +-
 .../TextMesh Pro/Shaders/TMP_SDF-Mobile SSD.shader |       6 +-
 .../Shaders/TMP_SDF-Mobile-2-Pass.shader           |     389 +
 .../Shaders/TMP_SDF-Mobile-2-Pass.shader.meta      |       9 +
 .../TextMesh Pro/Shaders/TMP_SDF-Mobile.shader     |      26 +-
 .../Shaders/TMP_SDF-Surface-Mobile.shader          |       9 +-
 .../TextMesh Pro/Shaders/TMP_SDF-Surface.shader    |      11 +-
 .../Shaders/TMP_SDF-URP Lit.shadergraph            |   11932 +
 .../Shaders/TMP_SDF-URP Lit.shadergraph.meta       |      10 +
 .../Shaders/TMP_SDF-URP Unlit.shadergraph          |   11629 +
 .../Shaders/TMP_SDF-URP Unlit.shadergraph.meta     |      10 +
 .../Assets/TextMesh Pro/Shaders/TMP_SDF.shader     |      81 +-
 .../Assets/TextMesh Pro/Shaders/TMP_Sprite.shader  |      77 +-
 .../Assets/TextMesh Pro/Shaders/TMPro.cginc.meta   |       2 +-
 .../Assets/TextMesh Pro/Shaders/TMPro_Mobile.cginc |      32 +-
 .../TextMesh Pro/Shaders/TMPro_Properties.cginc    |       5 -
 .../TextMesh Pro/Shaders/TMPro_Surface.cginc       |      10 +-
 .../Assets/textures/Menu/CarritosSuperFondo.png    |     Bin 114888 -> 0 bytes
 .../Assets/textures/Menu/CarroDerecha.png          |     Bin 41563 -> 0 bytes
 .../Assets/textures/Supermercado/Estante 1.mat     |       1 +
 .../Assets/textures/Supermercado/Estante.mat       |       3 +-
 Supermarkert Run/Packages/manifest.json            |      17 +-
 Supermarkert Run/Packages/packages-lock.json       |     103 +-
 .../ProjectSettings/MultiplayerManager.asset       |       7 +
 .../ProjectSettings/ProjectSettings.asset          |      95 +-
 .../ProjectSettings/ProjectVersion.txt             |       4 +-
 .../ProjectSettings/SceneTemplateSettings.json     |       5 +
 283 files changed, 6055418 insertions(+), 6311 deletions(-)

=== COMMIT: 31ce06c | Fri Jan 16 21:43:24 2026 -0600 | Modificar codigos para que funcionen con los nuevos modelos de optimizacion y tener menos dependencia a objetos externos ===
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |     2 +-
 .../Carrito_aleatorio.prefab                       |     4 +-
 Supermarkert Run/Assets/Resources.meta             |     8 +
 .../Assets/Resources/PepelHigienico 1.obj          |  2297 +
 .../Assets/Resources/PepelHigienico 1.obj.meta     |   114 +
 Supermarkert Run/Assets/Resources/caja.obj         |   348 +
 Supermarkert Run/Assets/Resources/caja.obj.meta    |   115 +
 Supermarkert Run/Assets/Resources/cajaJugo.obj     |   458 +
 .../Assets/Resources/cajaJugo.obj.meta             |   115 +
 Supermarkert Run/Assets/Resources/escoba 1.obj     |  3304 +
 .../Assets/Resources/escoba 1.obj.meta             |   124 +
 .../Assets/Resources/hamburguesa 1.obj             | 76500 +++++++++++++++++++
 .../Assets/Resources/hamburguesa 1.obj.meta        |   144 +
 Supermarkert Run/Assets/Resources/libro.prefab     |    83 +
 .../Assets/Resources/libro.prefab.meta             |     7 +
 Supermarkert Run/Assets/Resources/manzana 1.obj    |  1448 +
 .../Assets/Resources/manzana 1.obj.meta            |   115 +
 Supermarkert Run/Assets/Resources/microondas 1.obj |   209 +
 .../Assets/Resources/microondas 1.obj.meta         |   115 +
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |  1410 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |     2 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |    16 +-
 .../Assets/Scripts/Juego/Menu/NPC_Menu.cs          |     1 -
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |    13 +
 Supermarkert Run/Assets/Scripts/estantes/Area.cs   |    61 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |   198 +-
 .../Assets/Scripts/estantes/Estante.cs             |    72 +-
 27 files changed, 85741 insertions(+), 1542 deletions(-)

=== COMMIT: ed78f49 | Sun Mar 29 21:43:28 2026 -0600 | nuevos objetos para mayor optimizacion y nuevo sistema para aparecer objetos random en el juego ===
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |     178 +-
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |     121 +-
 .../Hamburguesa/EstanteComida.obj.meta             |       2 +-
 .../Hamburguesa/EstanteComida5x2.obj.meta          |       2 +-
 .../Hamburguesa/Materiales/Material.001 1.mat      |      10 +-
 .../Hamburguesa/Materiales/hamburguesa2.png        |     Bin 0 -> 45889 bytes
 .../Hamburguesa/Materiales/hamburguesa2.png.meta   |     130 +
 .../Manzana/EstanteManzana.obj.meta                |       2 +-
 .../Manzana/EstanteManzana5x2.obj.meta             |       2 +-
 .../Microondas/Materials/RGB_texture_baseColor.mat |       1 +
 .../cajaJugo/EstanteJugo.obj.meta                  |       2 +-
 .../cajaJugo/EstanteJugo5x2.obj.meta               |       2 +-
 .../Objetos_Colocados/rollo/EstanteRollo.fbx       |     Bin 0 -> 1577596 bytes
 ...EstanteRollo.obj.meta => EstanteRollo.fbx.meta} |      16 +-
 .../Objetos_Colocados/rollo/EstanteRollo.mtl       |      22 -
 .../Objetos_Colocados/rollo/EstanteRollo.mtl.meta  |       7 -
 .../Objetos_Colocados/rollo/EstanteRollo.obj       | 1192574 ----------------
 .../Objetos_Colocados/rollo/EstanteRollo5x2 1.fbx  |     Bin 0 -> 1560220 bytes
 ...ollo5x2.obj.meta => EstanteRollo5x2 1.fbx.meta} |      19 +-
 .../Objetos_Colocados/rollo/EstanteRollo5x2.mtl    |      32 -
 .../rollo/EstanteRollo5x2.mtl.meta                 |       7 -
 .../Objetos_Colocados/rollo/EstanteRollo5x2.obj    | 1225794 -----------------
 .../rollo/Materials/Material.001 1.mat             |      84 -
 .../rollo/Materials/Material.001 1.mat.meta        |       8 -
 .../rollo/Materials/Material.001.mat               |      84 -
 .../rollo/Materials/Material.019.mat               |      84 -
 .../rollo/Materials/Material.019.mat.meta          |       8 -
 .../rollo/Materials/Material.023.mat               |      84 -
 .../rollo/Materials/Material.mat.meta              |       8 -
 .../rollo/Materials/{Material.mat => rollo.mat}    |       6 +-
 .../{Material.001.mat.meta => rollo.mat.meta}      |       0
 .../rollo/Materials/rolloprueba.mat}               |      21 +-
 ...{Material.023.mat.meta => rolloprueba.mat.meta} |       2 +-
 .../Assets/Scenes/Menu_principal.unity             |     171 +-
 .../Assets/textures/Supermercado/Estante 1.mat     |      14 +-
 .../textures/Supermercado/Estante 1.mat.meta       |       2 +-
 .../textures/Supermercado/Estante 2.mat.meta       |       8 -
 .../Assets/textures/Supermercado/Estante.mat       |       2 +-
 Supermarkert Run/Packages/manifest.json            |      14 +-
 Supermarkert Run/Packages/packages-lock.json       |      62 +-
 .../ProjectSettings/ProjectVersion.txt             |       4 +-
 41 files changed, 436 insertions(+), 2419153 deletions(-)

=== COMMIT: 6a60733 | Wed Apr 8 21:13:57 2026 -0600 | Nuevo objetos con nuevos materiales para optimizar se agregaran a los objetos a spawnear ===
 .../.cmake/api/v1/query/client-agp/cache-v2        |     0
 .../.cmake/api/v1/query/client-agp/cmakeFiles-v1   |     0
 .../.cmake/api/v1/query/client-agp/codemodel-v2    |     0
 .../v1/reply/cache-v2-285a2e7b4626eeb5a72f.json    |  1415 +
 .../reply/cmakeFiles-v1-995979dad01113f7d7a0.json  |   810 +
 .../reply/codemodel-v2-de5d8aa3d2f87979b004.json   |    87 +
 ...tory-.-RelWithDebInfo-d0094a50bb2071803777.json |    14 +
 ...Pacing-RelWithDebInfo-7f9c8865fd027a154c90.json |    14 +
 .../v1/reply/index-2026-03-31T03-17-33-0240.json   |    92 +
 ...rapper-RelWithDebInfo-095d621a47c13f0d0adf.json |   174 +
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  |   Bin 0 -> 10656 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |     3 +
 .../3x543z5q/arm64-v8a/CMakeCache.txt              |   415 +
 .../3.22.1-g37088a8-dirty/CMakeCCompiler.cmake     |    72 +
 .../3.22.1-g37088a8-dirty/CMakeCXXCompiler.cmake   |    83 +
 .../CMakeDetermineCompilerABI_C.bin                |   Bin 0 -> 8072 bytes
 .../CMakeDetermineCompilerABI_CXX.bin              |   Bin 0 -> 8200 bytes
 .../3.22.1-g37088a8-dirty/CMakeSystem.cmake        |    15 +
 .../CompilerIdC/CMakeCCompilerId.c                 |   803 +
 .../CompilerIdC/CMakeCCompilerId.o                 |   Bin 0 -> 6032 bytes
 .../CompilerIdCXX/CMakeCXXCompilerId.cpp           |   791 +
 .../CompilerIdCXX/CMakeCXXCompilerId.o             |   Bin 0 -> 6040 bytes
 .../3x543z5q/arm64-v8a/CMakeFiles/CMakeOutput.log  |   262 +
 .../arm64-v8a/CMakeFiles/TargetDirectories.txt     |     5 +
 .../arm64-v8a/CMakeFiles/cmake.check_cache         |     1 +
 .../3x543z5q/arm64-v8a/CMakeFiles/rules.ninja      |    64 +
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |   Bin 0 -> 23608 bytes
 .../arm64-v8a/FramePacing/cmake_install.cmake      |    44 +
 .../arm64-v8a/additional_project_files.txt         |     1 +
 .../3x543z5q/arm64-v8a/android_gradle_build.json   |    39 +
 .../arm64-v8a/android_gradle_build_mini.json       |    28 +
 .../RelWithDebInfo/3x543z5q/arm64-v8a/build.ninja  |   190 +
 .../3x543z5q/arm64-v8a/build_file_index.txt        |     2 +
 .../3x543z5q/arm64-v8a/cmake_install.cmake         |    60 +
 .../3x543z5q/arm64-v8a/compile_commands.json       |     7 +
 .../3x543z5q/arm64-v8a/compile_commands.json.bin   |   Bin 0 -> 1589 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |    30 +
 .../arm64-v8a/metadata_generation_command.txt      |    21 +
 .../3x543z5q/arm64-v8a/prefab_config.json          |     7 +
 .../3x543z5q/arm64-v8a/symbol_folder_index.txt     |     1 +
 .../.cmake/api/v1/query/client-agp/cache-v2        |     0
 .../.cmake/api/v1/query/client-agp/cmakeFiles-v1   |     0
 .../.cmake/api/v1/query/client-agp/codemodel-v2    |     0
 .../v1/reply/cache-v2-256224aba193c0a05fee.json    |  1415 +
 .../reply/cmakeFiles-v1-123ecd08fae43f60fcba.json  |   810 +
 .../reply/codemodel-v2-439fb2fb3d081c3da8b2.json   |    87 +
 ...tory-.-RelWithDebInfo-d0094a50bb2071803777.json |    14 +
 ...Pacing-RelWithDebInfo-7f9c8865fd027a154c90.json |    14 +
 .../v1/reply/index-2026-03-31T03-17-37-0534.json   |    92 +
 ...rapper-RelWithDebInfo-b4480333cd5e17a978c1.json |   174 +
 .../3x543z5q/armeabi-v7a/.ninja_deps               |   Bin 0 -> 10656 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |     3 +
 .../3x543z5q/armeabi-v7a/CMakeCache.txt            |   415 +
 .../3.22.1-g37088a8-dirty/CMakeCCompiler.cmake     |    72 +
 .../3.22.1-g37088a8-dirty/CMakeCXXCompiler.cmake   |    83 +
 .../CMakeDetermineCompilerABI_C.bin                |   Bin 0 -> 6176 bytes
 .../CMakeDetermineCompilerABI_CXX.bin              |   Bin 0 -> 6304 bytes
 .../3.22.1-g37088a8-dirty/CMakeSystem.cmake        |    15 +
 .../CompilerIdC/CMakeCCompilerId.c                 |   803 +
 .../CompilerIdC/CMakeCCompilerId.o                 |   Bin 0 -> 4124 bytes
 .../CompilerIdCXX/CMakeCXXCompilerId.cpp           |   791 +
 .../CompilerIdCXX/CMakeCXXCompilerId.o             |   Bin 0 -> 4160 bytes
 .../armeabi-v7a/CMakeFiles/CMakeOutput.log         |   264 +
 .../armeabi-v7a/CMakeFiles/TargetDirectories.txt   |     5 +
 .../armeabi-v7a/CMakeFiles/cmake.check_cache       |     1 +
 .../3x543z5q/armeabi-v7a/CMakeFiles/rules.ninja    |    64 +
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |   Bin 0 -> 17060 bytes
 .../armeabi-v7a/FramePacing/cmake_install.cmake    |    44 +
 .../armeabi-v7a/additional_project_files.txt       |     1 +
 .../3x543z5q/armeabi-v7a/android_gradle_build.json |    39 +
 .../armeabi-v7a/android_gradle_build_mini.json     |    28 +
 .../3x543z5q/armeabi-v7a/build.ninja               |   190 +
 .../3x543z5q/armeabi-v7a/build_file_index.txt      |     2 +
 .../3x543z5q/armeabi-v7a/cmake_install.cmake       |    60 +
 .../3x543z5q/armeabi-v7a/compile_commands.json     |     7 +
 .../3x543z5q/armeabi-v7a/compile_commands.json.bin |   Bin 0 -> 1630 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |    30 +
 .../armeabi-v7a/metadata_generation_command.txt    |    21 +
 .../3x543z5q/armeabi-v7a/prefab_config.json        |     7 +
 .../3x543z5q/armeabi-v7a/symbol_folder_index.txt   |     1 +
 .../.utmp/RelWithDebInfo/3x543z5q/hash_key.txt     |    28 +
 .../games-frame-pacingConfig.cmake                 |    18 +
 .../games-frame-pacingConfig.cmake                 |    18 +
 .../tools/release/arm64-v8a/compile_commands.json  |     4 +-
 .../release/armeabi-v7a/compile_commands.json      |     4 +-
 .../Objetos/Mapa/Caja/mostrador_no_player.prefab   |   278 +-
 .../Objetos/Objetos_Colocados/Caja/Nuevo.meta      |     8 +
 .../Caja/Nuevo/EstanteraCaja5x2.png                |   Bin 0 -> 21328 bytes
 .../Caja/Nuevo/EstanteraCaja5x2.png.meta           |   130 +
 .../Caja/Nuevo/EstanteriaCaja.mtl                  |    12 +
 .../Caja/Nuevo/EstanteriaCaja.mtl.meta             |     7 +
 .../Caja/Nuevo/EstanteriaCaja.obj                  |  3579 ++
 .../Caja/Nuevo/EstanteriaCaja.obj.meta             |   115 +
 .../Caja/Nuevo/EstanteriaCaja.png                  |   Bin 0 -> 20516 bytes
 .../Caja/Nuevo/EstanteriaCaja.png.meta             |   130 +
 .../Caja/Nuevo/EstanteriaCaja5x2.mtl               |    12 +
 .../Caja/Nuevo/EstanteriaCaja5x2.mtl.meta          |     7 +
 .../Caja/Nuevo/EstanteriaCaja5x2.obj               |  3381 ++
 .../Caja/Nuevo/EstanteriaCaja5x2.obj.meta          |   115 +
 .../Objetos_Colocados/Caja/Nuevo/Material.meta     |     8 +
 .../Caja/Nuevo/Material/Material.001 1.mat         |    94 +
 .../Caja/Nuevo/Material/Material.001 1.mat.meta    |     8 +
 .../Caja/Nuevo/Material/Material.001.mat           |    94 +
 .../Caja/Nuevo/Material/Material.001.mat.meta      |     8 +
 .../Objetos/Objetos_Colocados/Escoba/Nuevo.meta    |     8 +
 .../Escoba/Nuevo/EstanteEscoba.mtl                 |    12 +
 .../Escoba/Nuevo/EstanteEscoba.mtl.meta            |     7 +
 .../Escoba/Nuevo/EstanteEscoba.obj                 | 16735 +++++++
 .../Escoba/Nuevo/EstanteEscoba.obj.meta            |   115 +
 .../Escoba/Nuevo/EstanteEscoba.png                 |   Bin 0 -> 81967 bytes
 .../Escoba/Nuevo/EstanteEscoba.png.meta            |   130 +
 .../Escoba/Nuevo/EstanteriaEscoba5x2.mtl           |    12 +
 .../Escoba/Nuevo/EstanteriaEscoba5x2.mtl.meta      |     7 +
 .../Escoba/Nuevo/EstanteriaEscoba5x2.obj           | 16732 +++++++
 .../Escoba/Nuevo/EstanteriaEscoba5x2.obj.meta      |   115 +
 .../Escoba/Nuevo/EstanteriaEscoba5x2.png           |   Bin 0 -> 104873 bytes
 .../Escoba/Nuevo/EstanteriaEscoba5x2.png.meta      |   130 +
 .../Objetos_Colocados/Escoba/Nuevo/Material.meta   |     8 +
 .../Escoba/Nuevo/Material/Material.001 1.mat       |    94 +
 .../Escoba/Nuevo/Material/Material.001 1.mat.meta  |     8 +
 .../Escoba/Nuevo/Material/Material.001.mat         |    94 +
 .../Escoba/Nuevo/Material/Material.001.mat.meta    |     8 +
 .../Objetos/Objetos_Colocados/Libro/Nuevo.meta     |     8 +
 .../Objetos_Colocados/Libro/Nuevo/EstanteLibro.mtl |    12 +
 .../Libro/Nuevo/EstanteLibro.mtl.meta              |     7 +
 .../Objetos_Colocados/Libro/Nuevo/EstanteLibro.obj | 33814 +++++++++++++
 .../Libro/Nuevo/EstanteLibro.obj.meta              |   115 +
 .../Objetos_Colocados/Libro/Nuevo/EstanteLibro.png |   Bin 0 -> 208712 bytes
 .../Libro/Nuevo/EstanteLibro.png.meta              |   130 +
 .../Libro/Nuevo/EstanteriaLibro5x2.mtl             |    12 +
 .../Libro/Nuevo/EstanteriaLibro5x2.mtl.meta        |     7 +
 .../Libro/Nuevo/EstanteriaLibro5x2.obj             | 18697 ++++++++
 .../Libro/Nuevo/EstanteriaLibro5x2.obj.meta        |   115 +
 .../Libro/Nuevo/EstanteriaLibros5x2.png            |   Bin 0 -> 257324 bytes
 .../Libro/Nuevo/EstanteriaLibros5x2.png.meta       |   130 +
 .../Objetos_Colocados/Libro/Nuevo/Materials.meta   |     8 +
 .../Libro/Nuevo/Materials/Material.001 1.mat       |    94 +
 .../Libro/Nuevo/Materials/Material.001 1.mat.meta  |     8 +
 .../Libro/Nuevo/Materials/Material.001.mat         |    94 +
 .../Libro/Nuevo/Materials/Material.001.mat.meta    |     8 +
 .../Objetos/Objetos_Colocados/Manzana/Nuevo.meta   |     8 +
 .../Manzana/Nuevo/EstanteriaFrutas.png             |   Bin 0 -> 425348 bytes
 .../Manzana/Nuevo/EstanteriaFrutas.png.meta        |   130 +
 .../Objetos_Colocados/Manzana/Nuevo/Material.meta  |     8 +
 .../Manzana/Nuevo/Material/Material.001.mat        |    94 +
 .../Manzana/Nuevo/Material/Material.001.mat.meta   |     8 +
 .../Manzana/Nuevo/Material/Material.008 1.mat      |    94 +
 .../Manzana/Nuevo/Material/Material.008 1.mat.meta |     8 +
 .../Manzana/Nuevo/Material/Material.008.mat        |    94 +
 .../Manzana/Nuevo/Material/Material.008.mat.meta   |     8 +
 .../Objetos_Colocados/Manzana/Nuevo/ZonaFrutas.fbx |   Bin 0 -> 1042924 bytes
 .../Manzana/Nuevo/ZonaFrutas.fbx.meta              |   115 +
 .../Manzana/Nuevo/ZonaFrutas5x2.fbx                |   Bin 0 -> 1289100 bytes
 .../Manzana/Nuevo/ZonaFrutas5x2.fbx.meta           |   120 +
 .../Objetos_Colocados/Microondas/Nuevo.meta        |     8 +
 .../Microondas/Nuevo/EstanteTecnologia.mtl         |    12 +
 .../Microondas/Nuevo/EstanteTecnologia.mtl.meta    |     7 +
 .../Microondas/Nuevo/EstanteTecnologia.obj         | 30331 ++++++++++++
 .../Microondas/Nuevo/EstanteTecnologia.obj.meta    |   115 +
 .../Microondas/Nuevo/EstanteTecnologia2x5.mtl      |    12 +
 .../Microondas/Nuevo/EstanteTecnologia2x5.mtl.meta |     7 +
 .../Microondas/Nuevo/EstanteTecnologia2x5.obj      | 38998 +++++++++++++++
 .../Microondas/Nuevo/EstanteTecnologia2x5.obj.meta |   115 +
 .../Nuevo/EstanteTecnologia2x5_texture.png         |   Bin 0 -> 38053 bytes
 .../Nuevo/EstanteTecnologia2x5_texture.png.meta    |   130 +
 .../Microondas/Nuevo/EstanteTecnologia_texture.png |   Bin 0 -> 36943 bytes
 .../Nuevo/EstanteTecnologia_texture.png.meta       |   130 +
 .../Microondas/Nuevo/Material.meta                 |     8 +
 .../Microondas/Nuevo/Material/Material.001 1.mat   |    94 +
 .../Nuevo/Material/Material.001 1.mat.meta         |     8 +
 .../Microondas/Nuevo/Material/Material.001.mat     |    94 +
 .../Nuevo/Material/Material.001.mat.meta           |     8 +
 .../Objetos/Objetos_Colocados/cajaJugo/Nuevo.meta  |     8 +
 .../cajaJugo/Nuevo/EstanteriaJugo.mtl              |    12 +
 .../cajaJugo/Nuevo/EstanteriaJugo.mtl.meta         |     7 +
 .../cajaJugo/Nuevo/EstanteriaJugo.obj              | 47485 +++++++++++++++++++
 .../cajaJugo/Nuevo/EstanteriaJugo.obj.meta         |   115 +
 .../cajaJugo/Nuevo/EstanteriaJugo.png              |   Bin 0 -> 31201 bytes
 .../cajaJugo/Nuevo/EstanteriaJugo.png.meta         |   130 +
 .../cajaJugo/Nuevo/EstanteriaJugo5x2.mtl           |    12 +
 .../cajaJugo/Nuevo/EstanteriaJugo5x2.mtl.meta      |     7 +
 .../cajaJugo/Nuevo/EstanteriaJugo5x2.obj           | 15385 ++++++
 .../cajaJugo/Nuevo/EstanteriaJugo5x2.obj.meta      |   115 +
 .../cajaJugo/Nuevo/EstanteriaJugo5x2_texture.png   |   Bin 0 -> 86085 bytes
 .../Nuevo/EstanteriaJugo5x2_texture.png.meta       |   130 +
 .../Objetos_Colocados/cajaJugo/Nuevo/Nuevo.meta    |     8 +
 .../cajaJugo/Nuevo/Nuevo/Material.001.mat          |    94 +
 .../cajaJugo/Nuevo/Nuevo/Material.001.mat.meta     |     8 +
 .../cajaJugo/Nuevo/Nuevo/defaultMat.mat            |    94 +
 .../cajaJugo/Nuevo/Nuevo/defaultMat.mat.meta       |     8 +
 .../Objetos_Colocados/rollo/NewModelRollo.meta     |     8 +
 .../rollo/NewModelRollo/EstanteRollo.mtl           |    12 +
 .../rollo/NewModelRollo/EstanteRollo.mtl.meta      |     7 +
 .../rollo/NewModelRollo/EstanteRollo.obj           | 25111 ++++++++++
 .../rollo/NewModelRollo/EstanteRollo.obj.meta      |   115 +
 .../rollo/NewModelRollo/EstanteRollo5x2.mtl        |    12 +
 .../rollo/NewModelRollo/EstanteRollo5x2.mtl.meta   |     7 +
 .../rollo/NewModelRollo/EstanteRollo5x2.obj        | 22623 +++++++++
 .../rollo/NewModelRollo/EstanteRollo5x2.obj.meta   |   115 +
 .../rollo/NewModelRollo/Materials.meta             |     8 +
 .../rollo/NewModelRollo/Materials/EstanteRollo.png |   Bin 0 -> 12738 bytes
 .../NewModelRollo/Materials/EstanteRollo.png.meta  |   130 +
 .../NewModelRollo/Materials/EstanteRollo5x2.png    |   Bin 0 -> 444039 bytes
 .../Materials/EstanteRollo5x2.png.meta             |   130 +
 .../NewModelRollo/Materials/Material.001 1.mat     |    94 +
 .../Materials/Material.001 1.mat.meta              |     8 +
 .../rollo/NewModelRollo/Materials/Material.001.mat |    94 +
 .../NewModelRollo/Materials/Material.001.mat.meta  |     8 +
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |   543 +-
 .../Scenes/Mapa grande/OcclusionCullingData.asset  |  1410 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |   195 +-
 .../Scenes/Mapa mediano/OcclusionCullingData.asset |   186 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |   107 +-
 .../OcclusionCullingData.asset"                    |   110 +-
 .../Assets/Scenes/Menu_principal.unity             |   256 +-
 .../Assets/Sonidos/SonidoGameplay.wav.meta         |    13 +-
 ...hatsApp-Audio-2024-10-09-at-8.47.38-PM.wav.meta |    13 +-
 Supermarkert Run/ProfilerCaptures.rar              |   Bin 0 -> 15326394 bytes
 .../Supermarkert Run_2026-03-30_18-09-42.bc7       |   Bin 0 -> 23560 bytes
 .../Supermarkert Run_2026-03-30_18-09-42.data      |   Bin 0 -> 97439048 bytes
 ...Supermarkert Run_2026-03-30_18-09-42.highlights |   Bin 0 -> 7028 bytes
 .../Supermarkert Run_2026-03-30_18-09-42.png       |   Bin 0 -> 17724 bytes
 222 files changed, 289948 insertions(+), 2383 deletions(-)

=== COMMIT: daf7578 | Wed May 13 13:13:59 2026 -0600 | Cambiar de build in a URP, modificar los shaders a URP configurar las camaras para que rendericen, asignar material sin bug a las paredes que se veian negras, agregar textura a los objetos que hacen la animacion de entrar al carro y cambiar rollo que estaba bug, modificar el material de unos estantes debido a que estaba muy oscuro y no daba el color que era con los estantes realmente ===
 .gitattributes                                     |     1 +
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |    26 +-
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |    26 +-
 Supermarkert Run/Assets/DefaultVolumeProfile.asset |   798 +
 .../Assets/DefaultVolumeProfile.asset.meta         |     8 +
 .../Assets/Joystick Pack/Examples/Ground.mat       |    74 +-
 .../Assets/Joystick Pack/Examples/Player.mat       |    74 +-
 .../Assets/Objetos/Carrito1/Materials 2/mat0.mat   |    67 +-
 .../Assets/Objetos/Carrito1/Materials 2/mat1.mat   |    61 +-
 .../Assets/Objetos/Carrito1/Materials 2/mat2.mat   |    61 +-
 .../Assets/Objetos/Carrito1/Materials 2/mat3.mat   |    61 +-
 .../Assets/Objetos/Carrito1/Materials/mat0.mat     |    64 +-
 .../Assets/Objetos/Carrito1/Materials/mat1.mat     |    64 +-
 .../Assets/Objetos/Carrito1/Materials/mat2.mat     |    64 +-
 .../Assets/Objetos/Carrito1/Materials/mat3.mat     |    64 +-
 .../Assets/Objetos/Carrito2/Materials/mat0.mat     |    64 +-
 .../Assets/Objetos/Carrito2/Materials/mat1.mat     |    64 +-
 .../Assets/Objetos/Carrito2/Materials/mat2.mat     |    64 +-
 .../Assets/Objetos/Carrito2/Materials/mat3.mat     |    64 +-
 .../Assets/Objetos/Carrito2/Materials2/mat0.mat    |    67 +-
 .../Assets/Objetos/Carrito2/Materials2/mat1.mat    |    61 +-
 .../Assets/Objetos/Carrito2/Materials2/mat2.mat    |    61 +-
 .../Assets/Objetos/Carrito2/Materials2/mat3.mat    |    61 +-
 .../Assets/Objetos/Enemigo/enemigo.prefab          |    63 +-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   137 +-
 .../Mapa/Caja/Materials/Simbolo_Dejar_Objetos.mat  |    63 +-
 .../Assets/Objetos/Mapa/Caja/Materials/mat0.mat    |    62 +-
 .../Assets/Objetos/Mapa/Caja/Materials/mat1.mat    |    62 +-
 .../Assets/Objetos/Mapa/Caja/Materials/mat2.mat    |    64 +-
 Supermarkert Run/Assets/Objetos/Mapa/Caja/Skin.mat |    64 +-
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |     6 +-
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |   642 +-
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |   662 +-
 .../Objetos/Mapa/Puerta/Materials/Material.001.mat |    61 +-
 .../Objetos/Mapa/Puerta/Materials/Material.003.mat |    61 +-
 .../Assets/Objetos/Mapa/Signal_Water/mat0.mat      |    64 +-
 .../Assets/Objetos/Mapa/Signal_Water/mat02.mat     |    67 +-
 .../Assets/Objetos/Mapa/Water_floor/mat0.mat       |    62 +-
 .../Assets/Objetos/Mapa/Water_floor/mat02.mat      |    69 +-
 .../Assets/Objetos/Objetos_Colocados/Caja.mat      |    64 +-
 .../Objetos/Objetos_Colocados/Caja/Prueba.meta     |     8 +
 .../Caja/Prueba/Atlas_2x1_Caja.png                 |   Bin 0 -> 72 bytes
 .../Caja/Prueba/Atlas_2x1_Caja.png.meta            |   130 +
 .../Caja/Prueba/EstanteriaCaja5x2_atlas.mtl        |    12 +
 .../Caja/Prueba/EstanteriaCaja5x2_atlas.mtl.meta   |     7 +
 .../Caja/Prueba/EstanteriaCaja5x2_atlas.obj        |  2345 ++
 .../Caja/Prueba/EstanteriaCaja5x2_atlas.obj.meta   |   120 +
 .../Caja/Prueba/EstanteriaCaja_atlas.mtl           |    12 +
 .../Caja/Prueba/EstanteriaCaja_atlas.mtl.meta      |     7 +
 .../Caja/Prueba/EstanteriaCaja_atlas.obj           |  2467 ++
 .../Caja/Prueba/EstanteriaCaja_atlas.obj.meta      |   120 +
 .../Objetos_Colocados/Caja/Prueba/defaultMat.mat   |    94 +
 .../Caja/Prueba/defaultMat.mat.meta                |     8 +
 .../Objetos/Objetos_Colocados/Caja_Leche.mat       |    68 +-
 .../Escoba/Material/Material.001 1.mat             |     2 +-
 .../Escoba/Material/Material.001 2.mat             |    63 +-
 .../Escoba/Material/Material.001.mat               |    61 +-
 .../Escoba/Material/Material.019.mat               |    61 +-
 .../Escoba/Material/Material.023.mat               |    61 +-
 .../Escoba/Material/mat0 - copia.mat               |    64 +-
 .../Objetos_Colocados/Escoba/Material/mat0.mat     |    64 +-
 .../Objetos_Colocados/Escoba/Material/mat1.mat     |    64 +-
 .../Objetos_Colocados/Escoba/Material/mat2.mat     |    64 +-
 .../Objetos/Objetos_Colocados/Escoba/Prueba.meta   |     8 +
 .../Escoba/Prueba/Atlas_2x2_Escoba.png             |   Bin 0 -> 79 bytes
 .../Escoba/Prueba/Atlas_2x2_Escoba.png.meta        |   130 +
 .../Escoba/Prueba/EstanteEscoba_atlas.obj          | 12565 ++++++
 .../Escoba/Prueba/EstanteEscoba_atlas.obj.meta     |   115 +
 .../Escoba/Prueba/EstanteriaEscoba5x2_atlas.obj    | 12562 ++++++
 .../Prueba/EstanteriaEscoba5x2_atlas.obj.meta      |   115 +
 .../Objetos_Colocados/Escoba/Prueba/defaultMat.mat |    94 +
 .../Escoba/Prueba/defaultMat.mat.meta              |     8 +
 .../Hamburguesa/EstanteComida.obj.meta             |     2 +-
 .../Hamburguesa/EstanteComida5x2.obj.meta          |     2 +-
 .../Hamburguesa/Materiales/Material.001.mat        |    63 +-
 .../Hamburguesa/Materiales/mat3.mat                |    64 +-
 .../Hamburguesa/Materiales/mat5.mat                |    62 +-
 .../Hamburguesa/Materiales/mat6.mat                |    62 +-
 .../Libro/Material/LibroEstante/mat0.mat           |    64 +-
 .../Libro/Material/LibroEstante/mat1.mat           |    66 +-
 .../Libro/Material/Material.001.mat                |    63 +-
 .../Libro/Material/mat0 - copia.mat                |    63 +-
 .../Objetos_Colocados/Libro/Material/mat1.mat      |    64 +-
 .../Objetos_Colocados/Libro/Material/mat2.mat      |    62 +-
 .../Objetos_Colocados/Libro/Material/mat3.mat      |    64 +-
 .../Objetos/Objetos_Colocados/Libro/Prueba.meta    |     8 +
 .../Libro/Prueba/Atlas_2x2_Libros.png              |   Bin 0 -> 79 bytes
 .../Libro/Prueba/Atlas_2x2_Libros.png.meta         |   130 +
 .../Libro/Prueba/EstanteLibro_atlas.mtl            |    12 +
 .../Libro/Prueba/EstanteLibro_atlas.mtl.meta       |     7 +
 .../Libro/Prueba/EstanteLibro_atlas.obj            | 32854 +++++++++++++++
 .../Libro/Prueba/EstanteLibro_atlas.obj.meta       |   120 +
 .../Libro/Prueba/EstanteriaLibro5x2_atlas.mtl      |    12 +
 .../Libro/Prueba/EstanteriaLibro5x2_atlas.mtl.meta |     7 +
 .../Libro/Prueba/EstanteriaLibro5x2_atlas.obj      | 18611 +++++++++
 .../Libro/Prueba/EstanteriaLibro5x2_atlas.obj.meta |   120 +
 .../Objetos_Colocados/Libro/Prueba/defaultMat.mat  |    94 +
 .../Libro/Prueba/defaultMat.mat.meta               |     8 +
 .../Manzana/EstanteManzana.obj.meta                |     2 +-
 .../Manzana/EstanteManzana5x2.obj.meta             |     2 +-
 .../Manzana/Materials/Gradient_baseColor 1.mat     |     6 +-
 .../Manzana/Materials/Gradient_baseColor.mat       |    63 +-
 .../Manzana/Nuevo/ZonaFrutas.fbx.meta              |     4 +-
 .../Microondas/Materials/Microndas2.mat            |     7 +-
 .../Microondas/Materials/Microondas.mat            |    63 +-
 .../Objetos_Colocados/Microondas/Prueba.meta       |     8 +
 .../Microondas/Prueba/Atlas_2x2_Tecnologia.png     |   Bin 0 -> 79 bytes
 .../Prueba/Atlas_2x2_Tecnologia.png.meta           |   130 +
 .../Prueba/EstanteTecnologia2x5_atlas.obj          | 22360 ++++++++++
 .../Prueba/EstanteTecnologia2x5_atlas.obj.meta     |   115 +
 .../Microondas/Prueba/EstanteTecnologia_atlas.obj  | 17401 ++++++++
 .../Prueba/EstanteTecnologia_atlas.obj.meta        |   115 +
 .../Microondas/Prueba/Material.meta                |     8 +
 .../Microondas/Prueba/Material/defaultMat.mat      |    94 +
 .../Microondas/Prueba/Material/defaultMat.mat.meta |     8 +
 .../cajaJugo/EstanteJugo.obj.meta                  |     2 +-
 .../cajaJugo/EstanteJugo5x2.obj.meta               |     2 +-
 .../Objetos/Objetos_Colocados/cajaJugo/Prueba.meta |     8 +
 .../cajaJugo/Prueba/Atlas_2x1_Jugo.png             |   Bin 0 -> 72 bytes
 .../cajaJugo/Prueba/Atlas_2x1_Jugo.png.meta        |   130 +
 .../cajaJugo/Prueba/EstanteriaJugo5x2_atlas.mtl    |    12 +
 .../Prueba/EstanteriaJugo5x2_atlas.mtl.meta        |     7 +
 .../cajaJugo/Prueba/EstanteriaJugo5x2_atlas.obj    | 13429 ++++++
 .../Prueba/EstanteriaJugo5x2_atlas.obj.meta        |   120 +
 .../cajaJugo/Prueba/EstanteriaJugo_atlas.mtl       |    12 +
 .../cajaJugo/Prueba/EstanteriaJugo_atlas.mtl.meta  |     7 +
 .../cajaJugo/Prueba/EstanteriaJugo_atlas.obj       | 40948 +++++++++++++++++++
 .../cajaJugo/Prueba/EstanteriaJugo_atlas.obj.meta  |   120 +
 .../cajaJugo/Prueba/defaultMat.mat                 |    94 +
 .../cajaJugo/Prueba/defaultMat.mat.meta            |     8 +
 .../Assets/Objetos/Objetos_Colocados/rollo.mat     |    63 +-
 .../rollo/Materials/rolloprueba.mat                |    12 +-
 .../Objetos/Objetos_Colocados/rollo/Prueba.meta    |     8 +
 .../rollo/Prueba/Atlas_2x1_Rollo.png               |   Bin 0 -> 72 bytes
 .../rollo/Prueba/Atlas_2x1_Rollo.png.meta          |   130 +
 .../rollo/Prueba/EstanteRollo5x2_atlas.obj         | 14727 +++++++
 .../rollo/Prueba/EstanteRollo5x2_atlas.obj.meta    |   115 +
 .../rollo/Prueba/EstanteRollo_atlas.obj            | 16407 ++++++++
 .../rollo/Prueba/EstanteRollo_atlas.obj.meta       |   115 +
 .../Objetos_Colocados/rollo/Prueba/Materials.meta  |     8 +
 .../rollo/Prueba/Materials/papel.mat               |    46 +
 .../rollo/Prueba/Materials/papel.mat.meta          |     8 +
 .../Objetos_Colocados/rollo/Prueba/defaultMat.mat  |    94 +
 .../rollo/Prueba/defaultMat.mat.meta               |     8 +
 .../Objetos_Colocados/rollo/Prueba/papel.png       |   Bin 0 -> 72 bytes
 .../Objetos_Colocados/rollo/Prueba/papel.png.meta  |   130 +
 .../Carrito_aleatorio.prefab                       |     5 +-
 .../carro.mat                                      |     3 +-
 .../Assets/Resources/PepelHigienico 1.obj          |  2975 +-
 .../Assets/Resources/PepelHigienico 1.obj.meta     |    15 +-
 .../Assets/Resources/escoba 1.obj.meta             |    12 +-
 .../Assets/Resources/hamburguesa 1.obj.meta        |    12 +-
 .../Assets/Resources/manzana 1.obj.meta            |     5 +
 .../Assets/Resources/microondas 1.obj.meta         |     5 +
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |    51 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |    51 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |    89 +-
 .../Assets/Scenes/Menu_principal.unity             |   140 +-
 Supermarkert Run/Assets/URP.asset                  |   143 +
 Supermarkert Run/Assets/URP.asset.meta             |     8 +
 Supermarkert Run/Assets/URPDefaultResources.meta   |     8 +
 .../Default_Forward_Renderer.asset                 |    56 +
 .../Default_Forward_Renderer.asset.meta            |     8 +
 .../Assets/URPDefaultResources/High.asset          |   143 +
 .../Assets/URPDefaultResources/High.asset.meta     |     8 +
 .../Assets/URPDefaultResources/Low.asset           |   143 +
 .../Assets/URPDefaultResources/Low.asset.meta      |     8 +
 .../Assets/URPDefaultResources/Medium.asset        |   143 +
 .../Assets/URPDefaultResources/Medium.asset.meta   |     8 +
 .../Assets/URPDefaultResources/Trabajo.asset       |   143 +
 .../Assets/URPDefaultResources/Trabajo.asset.meta  |     8 +
 .../Assets/URPDefaultResources/Ultra.asset         |   143 +
 .../Assets/URPDefaultResources/Ultra.asset.meta    |     8 +
 .../Assets/URPDefaultResources/Very High.asset     |   143 +
 .../URPDefaultResources/Very High.asset.meta       |     8 +
 .../Assets/URPDefaultResources/Very Low.asset      |   143 +
 .../Assets/URPDefaultResources/Very Low.asset.meta |     8 +
 Supermarkert Run/Assets/URP_Renderer.asset         |    56 +
 Supermarkert Run/Assets/URP_Renderer.asset.meta    |     8 +
 .../UniversalRenderPipelineGlobalSettings.asset    |   426 +
 ...niversalRenderPipelineGlobalSettings.asset.meta |     8 +
 .../Assets/shader/celshadding/celShadding.shader   |   278 +-
 .../shader/celshadding/celshaddingPared 1.mat      |     1 +
 .../Assets/shader/outline/outlineEnemigo.mat       |     3 +-
 .../Assets/shader/outline/outlinePersonaje.mat     |     3 +-
 .../Assets/shader/outline/outlineSeeThroug.shader  |   377 +-
 .../textures/Carritos/Grande/PersonalizadaGra.mat  |    62 +-
 .../textures/Carritos/Mediano/PersonalizadaMed.mat |    62 +-
 .../textures/Carritos/Pequenio/Personalizada.mat   |    62 +-
 .../textures/Carritos/Pequenio/Principal.mat       |    62 +-
 .../Assets/textures/Jugador_Enemigo/Flecha.mat     |    64 +-
 .../Assets/textures/Jugador_Enemigo/Policia.mat    |    62 +-
 .../Assets/textures/Jugador_Enemigo/Sombra.mat     |    62 +-
 .../Assets/textures/Menu/CarritosFondo.mat         |    64 +-
 Supermarkert Run/Assets/textures/Menu/Pared.mat    |    64 +-
 .../Assets/textures/Supermercado/Banqueta.mat      |    68 +-
 .../Assets/textures/Supermercado/Estante 1.mat     |    61 +-
 .../Assets/textures/Supermercado/Estante.mat       |    61 +-
 .../textures/Supermercado/Estante_Oculto.mat       |    64 +-
 .../textures/Supermercado/Materials/Suelo.mat      |    64 +-
 .../Assets/textures/Supermercado/Pared.mat         |    67 +-
 .../Assets/textures/Supermercado/Suelo.mat         |    66 +-
 .../Assets/textures/Supermercado/Suelo2.mat        |    62 +-
 .../Assets/textures/Supermercado/Vidrio.mat        |    62 +-
 Supermarkert Run/Packages/manifest.json            |     1 +
 Supermarkert Run/Packages/packages-lock.json       |    78 +
 .../Supermarkert Run_2026-03-30_18-09-42.data      |   Bin 97439048 -> 133 bytes
 .../ProjectSettings/GraphicsSettings.asset         |    23 +-
 .../ProjectSettings/QualitySettings.asset          |    59 +-
 .../ProjectSettings/ShaderGraphSettings.asset      |     2 +
 .../ProjectSettings/URPProjectSettings.asset       |    16 +
 211 files changed, 219652 insertions(+), 3100 deletions(-)

=== COMMIT: 4becca1 | Fri May 15 19:20:58 2026 -0600 | Primer compilacion de URP, Agregar nuevos modelos mas low polu como hamburguesa, carro aleatorio que se dio en carro aleatorio o enemigos comunes, rollo sin bugs, nuevo estante para jugo, hacer que Fila 3 prefab sea unica y no una Variante, cambiar modelo de mostrador para enemigo y jugador, agregar animacion de crecer y regresar a su tamaño de los iconos de mision y tomar objetos, el icono tomar objeto re posicionado para mayor facilidad del usuario, la UI Ganar se soluciono el bug de que no se veia y ahora se ve y su confeti, nuevos modelos resource  para consumir menos poligonos, modificacion a Enemigo comun de asignar las mallas a los carros para skin y sombras, los mapas es de UI en mapa pequeño se extendio un poco para que las nuevas cajas registradoras puedan estar bien acomodadas. ===
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |     26 +-
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |     26 +-
 .../Assets/Objetos/Enemigo/enemigo.prefab          |   2730 +-
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     |     82 +-
 Supermarkert Run/Assets/Objetos/Ganar.prefab       |      5 +-
 .../Objetos/Mapa/Caja/CajaRegistradoraEne.mtl      |     12 +
 .../Caja/CajaRegistradoraEne.mtl.meta}             |      2 +-
 .../Objetos/Mapa/Caja/CajaRegistradoraEne.obj      |   6432 +
 .../Caja/CajaRegistradoraEne.obj.meta}             |     21 +-
 .../Objetos/Mapa/Caja/CajaRegistradoraPC.obj       |    415 +
 .../Caja/CajaRegistradoraPC.obj.meta}              |     17 +-
 .../Objetos/Mapa/Caja/ImageToStl.com_checkout.obj  |  12685 -
 .../Mapa/Caja/ImageToStl.com_checkout.obj.meta     |    109 -
 .../Mapa/Caja/Materials/CajaRegistradoraEne.png    |    Bin 0 -> 133853 bytes
 .../Caja/Materials/CajaRegistradoraEne.png.meta}   |      2 +-
 .../Caja/Materials/Material.011.mat}               |     26 +-
 .../Material.011.mat.meta}                         |      2 +-
 .../Objetos/Mapa/Caja/Materials/RegistradoraPC.png |    Bin 0 -> 62667 bytes
 .../Caja/Materials/RegistradoraPC.png.meta}        |      2 +-
 .../Mapa/Caja/Materials/Simbolo_Dejar_Objetos.mat  |      6 +-
 .../Objetos/Mapa/Caja/Materials/defaultMat.mat     |    153 +
 .../Caja/Materials/defaultMat.mat.meta}            |      2 +-
 .../Assets/Objetos/Mapa/Caja/Skin 1.mat            |     93 -
 .../Assets/Objetos/Mapa/Caja/checkout.mtl          |     50 -
 .../Objetos/Mapa/Caja/misc_tex_baseColor.jpg       |    Bin 269909 -> 0 bytes
 .../Objetos/Mapa/Caja/misc_tex_baseColor.jpg.meta  |    127 -
 .../Mapa/Caja/misc_tex_metallicRoughness.png       |    Bin 1744671 -> 0 bytes
 .../Assets/Objetos/Mapa/Caja/misc_tex_normal.jpg   |    Bin 248254 -> 0 bytes
 .../Assets/Objetos/Mapa/Caja/mostrador.prefab      |   1213 +-
 .../Objetos/Mapa/Caja/mostrador_no_player.prefab   |   2444 +-
 .../Assets/Objetos/Mapa/Caja/readme.txt            |      3 -
 .../Assets/Objetos/Mapa/Caja/readme.txt.meta       |      7 -
 .../Mapa/Caja/skin_body_metallicRoughness.png      |    Bin 1756460 -> 0 bytes
 .../Mapa/Caja/skin_body_metallicRoughness.png.meta |    127 -
 .../Assets/Objetos/Mapa/Caja/skin_body_normal.jpg  |    Bin 317266 -> 0 bytes
 .../Objetos/Mapa/Caja/skin_body_normal.jpg.meta    |    127 -
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |      2 +-
 .../Assets/Objetos/Mapa/Estanteria 1.obj           |    963 -
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |   1961 +-
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |   2618 +-
 .../Assets/Objetos/Objetos_Colocados/Caja.mat      |    143 -
 .../Objetos_Colocados/Caja/Prueba/defaultMat.mat   |      2 +-
 .../Objetos/Objetos_Colocados/CajaDeLecheOJugo.obj |     93 -
 .../Objetos/Objetos_Colocados/Caja_Leche.mat       |    145 -
 .../Objetos_Colocados/Escoba/Prueba/defaultMat.mat |      2 +-
 .../Hamburguesa/EstanteComida.fbx                  |    Bin 0 -> 712844 bytes
 ...tanteComida.obj.meta => EstanteComida.fbx.meta} |     23 +-
 .../Hamburguesa/EstanteComida.mtl                  |     52 -
 .../Hamburguesa/EstanteComida.obj                  | 852351 ------------------
 ...EstanteComida5x2.mtl => EstanteComida5x2 1.mtl} |     20 +-
 .../Hamburguesa/EstanteComida5x2 1.mtl.meta}       |      2 +-
 .../Hamburguesa/EstanteComida5x2.fbx               |    Bin 0 -> 1174844 bytes
 ...omida5x2.obj.meta => EstanteComida5x2.fbx.meta} |     22 +-
 .../Hamburguesa/EstanteComida5x2.mtl.meta          |      7 -
 .../Hamburguesa/EstanteComida5x2.obj               | 632814 -------------
 .../Hamburguesa/Materiales/Hamburguesa.png         |    Bin 41672 -> 0 bytes
 .../Hamburguesa/Materiales/Mat02.mat               |     93 -
 .../Hamburguesa/Materiales/Mat02.mat.meta          |      8 -
 .../Hamburguesa/Materiales/Material.001 1.mat      |     94 -
 .../Hamburguesa/Materiales/Material.001 1.mat.meta |      8 -
 .../Materiales/{mat5.mat => Material.007.mat}      |     55 +-
 .../Materiales/Material.007.mat.meta}              |      2 +-
 .../Hamburguesa/Materiales/hamburguesa2.png        |    Bin 45889 -> 0 bytes
 .../Hamburguesa/Materiales/mat1 1.mat.meta         |      8 -
 .../Hamburguesa/Materiales/mat2 1.mat              |     93 -
 .../Hamburguesa/Materiales/mat2 1.mat.meta         |      8 -
 .../Hamburguesa/Materiales/mat3.mat.meta           |      8 -
 .../Hamburguesa/Materiales/mat4 1.mat              |     93 -
 .../Hamburguesa/Materiales/mat4 1.mat.meta         |      8 -
 .../Hamburguesa/Materiales/mat5.mat.meta           |      8 -
 .../Hamburguesa/Materiales/mat6.mat.meta           |      8 -
 .../Objetos_Colocados/Hamburguesa/burger.mtl       |     82 -
 .../Objetos_Colocados/Hamburguesa/hamburguesa.obj  |  76500 --
 .../Hamburguesa/hamburguesa.obj.meta               |    144 -
 .../Objetos_Colocados/Hamburguesa/readme.txt       |      3 -
 .../Objetos_Colocados/Hamburguesa/readme.txt.meta  |      7 -
 .../Objetos_Colocados/Libro/Prueba/defaultMat.mat  |      2 +-
 .../Manzana/Nuevo/Material/Material.001.mat        |      2 +-
 .../Manzana/Nuevo/Material/Material.008 1.mat      |      2 +-
 .../Manzana/Nuevo/Material/Material.008.mat        |      2 +-
 .../Microondas/Prueba/Material/defaultMat.mat      |      2 +-
 .../Objetos/Objetos_Colocados/PepelHigienico.obj   |   2297 -
 .../cajaJugo/Nuevo/EstanteriaJugo.obj              |  32461 +-
 .../cajaJugo/Prueba/EstanteriaJugo.mtl             |     12 +
 .../Prueba/EstanteriaJugo.mtl.meta}                |      2 +-
 .../cajaJugo/Prueba/EstanteriaJugo.obj             |  23880 +
 ...Jugo_atlas.obj.meta => EstanteriaJugo.obj.meta} |      9 +-
 .../cajaJugo/Prueba/EstanteriaJugo_atlas.obj       |  40948 -
 .../Prueba}/Material.001.mat                       |     47 +-
 .../Prueba}/Material.001.mat.meta                  |      2 +-
 .../cajaJugo/Prueba/defaultMat.mat                 |      4 +-
 .../Assets/Objetos/Objetos_Colocados/rollo.mat     |      2 +-
 .../rollo/Materials/rolloprueba.mat                |      2 +-
 .../rollo/Prueba/Materials/papel.mat               |      2 +-
 .../Objetos_Colocados/rollo/Prueba/defaultMat.mat  |      2 +-
 .../Carrito_aleatorio.prefab                       |    518 +-
 .../CarroAleatorio.mat                             |    146 +
 .../CarroAleatorio.mat.meta}                       |      2 +-
 .../CarroAleatorioBusqueda.obj                     |   9465 +
 .../CarroAleatorioBusqueda.obj.meta}               |      4 +-
 .../CarroBusqueda.png                              |    Bin 0 -> 146910 bytes
 .../CarroBusqueda.png.meta}                        |     15 +-
 .../CarroMenu.mat                                  |      3 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |    111 +-
 Supermarkert Run/Assets/Objetos/UI_Camera.prefab   |     85 -
 .../Assets/Objetos/UI_Camera.prefab.meta           |      7 -
 .../Caja/Skin.mat => Resources/Hamburguesa.mat}    |     57 +-
 .../Assets/Resources/Hamburguesa.mat.meta          |      8 +
 .../Assets/Resources/PepelHigienico 1.obj.meta     |      6 +-
 .../Assets/Resources/hamburguesa 1.obj             |  78558 +-
 .../Assets/Resources/hamburguesa 1.obj.meta        |     45 +-
 .../Assets/Resources/hamburguesa_atlas_64.png      |    Bin 0 -> 6585 bytes
 .../hamburguesa_atlas_64.png.meta}                 |     15 +-
 .../mat1 1.mat => Resources/rolloprueba 1.mat}     |     19 +-
 .../Assets/Resources/rolloprueba 1.mat.meta        |      8 +
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |     76 +-
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |     76 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |    146 +-
 .../Assets/Scenes/Menu_principal.unity             |     18 +-
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |      2 +-
 .../Assets/Scripts/Juego/Gameplay/AnimationIcon.cs |     52 +
 .../Scripts/Juego/Gameplay/AnimationIcon.cs.meta   |      2 +
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |      2 +-
 Supermarkert Run/Assets/Scripts/estantes/Area.cs   |      2 +-
 Supermarkert Run/Assets/URP.asset                  |      2 +-
 .../Assets/URPDefaultResources/High.asset          |     66 +-
 .../Assets/URPDefaultResources/Low.asset           |     66 +-
 .../Assets/URPDefaultResources/Medium.asset        |     66 +-
 .../Assets/URPDefaultResources/Trabajo.asset       |     66 +-
 .../Assets/URPDefaultResources/Ultra.asset         |     66 +-
 .../Assets/URPDefaultResources/Very High.asset     |     66 +-
 .../Assets/URPDefaultResources/Very Low.asset      |     66 +-
 .../UniversalRenderPipelineGlobalSettings.asset    |     16 +-
 .../Assets/textures/Supermercado/Estante 1.mat     |      2 +-
 .../Assets/textures/Supermercado/Estante.mat       |      2 +-
 .../textures/Supermercado/Estante_Oculto.mat       |      3 +-
 .../mat6.mat => textures/Supermercado/Pared 1.mat} |     42 +-
 .../Assets/textures/Supermercado/Pared 1.mat.meta  |      8 +
 .../Assets/textures/Supermercado/Pared.mat         |     17 +-
 .../ProjectSettings/ProjectSettings.asset          |     12 +-
 .../ProjectSettings/QualitySettings.asset          |      8 +-
 141 files changed, 50239 insertions(+), 1734859 deletions(-)

=== COMMIT: 5dca1d8 | Tue May 19 13:05:33 2026 -0600 | Se agrego un glow a las filas para mostrarle al jugador que objeto obtener, igual a la caja registradora del jugador, agregar iconos a la UI de misiones, eliminar los lightmap debido a que no eran necesarios, nuevo bake de occlusion culling en mapa pequeño por un bug y bake al navmesh en mapa pequeño, arreglar el bug de NPC para llegar a su caja registradora, arreglar el bug para el nivel de que no se guardaba el nuevo nivel, arreglar bug de agregar mas misiones si pasaba de 10 misiones, nuevo modelo de rollo porque tenia un bug ===
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |    26 +-
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |    26 +-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |    47 +-
 .../Assets/Objetos/Mapa/Caja/mostrador.prefab      |    93 +-
 .../Objetos/Mapa/Caja/mostrador_no_player.prefab   |    33 +
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |     2 +-
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |   115 +-
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |   113 +
 .../Caja/Nuevo/Material/Material.001.mat           |     2 +-
 .../Escoba/Material/Material.001 1.mat             |     2 +-
 .../Carrito_aleatorio.prefab                       |     4 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |   827 +-
 Supermarkert Run/Assets/Resources/Hamburguesa.mat  |     8 +-
 .../Assets/Resources/PepelHigienico 1.obj          |   258 +-
 Supermarkert Run/Assets/Resources/libro.prefab     |     8 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |   182 +-
 .../Assets/Scenes/Mapa grande/LightingData.asset   |   Bin 72376 -> 0 bytes
 .../Scenes/Mapa grande/Lightmap-0_comp_dir.png     |   Bin 153845 -> 0 bytes
 .../Mapa grande/Lightmap-0_comp_dir.png.meta       |   127 -
 .../Scenes/Mapa grande/Lightmap-0_comp_light.exr   |   Bin 570010 -> 0 bytes
 .../Scenes/Mapa grande/Lightmap-10_comp_dir.png    |   Bin 52929 -> 0 bytes
 .../Mapa grande/Lightmap-10_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-10_comp_light.exr  |   Bin 307865 -> 0 bytes
 .../Scenes/Mapa grande/Lightmap-11_comp_dir.png    |   Bin 52269 -> 0 bytes
 .../Mapa grande/Lightmap-11_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-11_comp_light.exr  |   Bin 304257 -> 0 bytes
 .../Scenes/Mapa grande/Lightmap-12_comp_dir.png    |   Bin 52588 -> 0 bytes
 .../Mapa grande/Lightmap-12_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-12_comp_light.exr  |   Bin 311745 -> 0 bytes
 .../Scenes/Mapa grande/Lightmap-13_comp_dir.png    |   Bin 51885 -> 0 bytes
 .../Mapa grande/Lightmap-13_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-13_comp_light.exr  |   Bin 306317 -> 0 bytes
 .../Mapa grande/Lightmap-13_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-14_comp_dir.png    |   Bin 52617 -> 0 bytes
 .../Mapa grande/Lightmap-14_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-14_comp_light.exr  |   Bin 305884 -> 0 bytes
 .../Mapa grande/Lightmap-14_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-15_comp_dir.png    |   Bin 53220 -> 0 bytes
 .../Mapa grande/Lightmap-15_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-15_comp_light.exr  |   Bin 302020 -> 0 bytes
 .../Mapa grande/Lightmap-15_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-16_comp_dir.png    |   Bin 51713 -> 0 bytes
 .../Mapa grande/Lightmap-16_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-16_comp_light.exr  |   Bin 309987 -> 0 bytes
 .../Mapa grande/Lightmap-16_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-17_comp_dir.png    |   Bin 54196 -> 0 bytes
 .../Mapa grande/Lightmap-17_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-17_comp_light.exr  |   Bin 304778 -> 0 bytes
 .../Mapa grande/Lightmap-17_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-18_comp_dir.png    |   Bin 55190 -> 0 bytes
 .../Mapa grande/Lightmap-18_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-18_comp_light.exr  |   Bin 303235 -> 0 bytes
 .../Mapa grande/Lightmap-18_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-19_comp_dir.png    |   Bin 54055 -> 0 bytes
 .../Mapa grande/Lightmap-19_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-19_comp_light.exr  |   Bin 309614 -> 0 bytes
 .../Mapa grande/Lightmap-19_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-1_comp_dir.png     |   Bin 161722 -> 0 bytes
 .../Mapa grande/Lightmap-1_comp_dir.png.meta       |   127 -
 .../Scenes/Mapa grande/Lightmap-1_comp_light.exr   |   Bin 575926 -> 0 bytes
 .../Mapa grande/Lightmap-1_comp_light.exr.meta     |   127 -
 .../Scenes/Mapa grande/Lightmap-20_comp_dir.png    |   Bin 52422 -> 0 bytes
 .../Mapa grande/Lightmap-20_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-20_comp_light.exr  |   Bin 306032 -> 0 bytes
 .../Mapa grande/Lightmap-20_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-21_comp_dir.png    |   Bin 52504 -> 0 bytes
 .../Mapa grande/Lightmap-21_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-21_comp_light.exr  |   Bin 307279 -> 0 bytes
 .../Mapa grande/Lightmap-21_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-22_comp_dir.png    |   Bin 54631 -> 0 bytes
 .../Mapa grande/Lightmap-22_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-22_comp_light.exr  |   Bin 312606 -> 0 bytes
 .../Mapa grande/Lightmap-22_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-23_comp_dir.png    |   Bin 52552 -> 0 bytes
 .../Mapa grande/Lightmap-23_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-23_comp_light.exr  |   Bin 308436 -> 0 bytes
 .../Mapa grande/Lightmap-23_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-24_comp_dir.png    |   Bin 52932 -> 0 bytes
 .../Mapa grande/Lightmap-24_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-24_comp_light.exr  |   Bin 307458 -> 0 bytes
 .../Mapa grande/Lightmap-24_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-25_comp_dir.png    |   Bin 53294 -> 0 bytes
 .../Mapa grande/Lightmap-25_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-25_comp_light.exr  |   Bin 306389 -> 0 bytes
 .../Mapa grande/Lightmap-25_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-26_comp_dir.png    |   Bin 54828 -> 0 bytes
 .../Mapa grande/Lightmap-26_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-26_comp_light.exr  |   Bin 309438 -> 0 bytes
 .../Mapa grande/Lightmap-26_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-27_comp_dir.png    |   Bin 53453 -> 0 bytes
 .../Mapa grande/Lightmap-27_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-27_comp_light.exr  |   Bin 305770 -> 0 bytes
 .../Mapa grande/Lightmap-27_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-28_comp_dir.png    |   Bin 20729 -> 0 bytes
 .../Mapa grande/Lightmap-28_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa grande/Lightmap-28_comp_light.exr  |   Bin 178268 -> 0 bytes
 .../Mapa grande/Lightmap-28_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa grande/Lightmap-2_comp_dir.png     |   Bin 126439 -> 0 bytes
 .../Mapa grande/Lightmap-2_comp_dir.png.meta       |   127 -
 .../Scenes/Mapa grande/Lightmap-2_comp_light.exr   |   Bin 492190 -> 0 bytes
 .../Mapa grande/Lightmap-2_comp_light.exr.meta     |   127 -
 .../Scenes/Mapa grande/Lightmap-3_comp_dir.png     |   Bin 53777 -> 0 bytes
 .../Mapa grande/Lightmap-3_comp_dir.png.meta       |   127 -
 .../Scenes/Mapa grande/Lightmap-3_comp_light.exr   |   Bin 310758 -> 0 bytes
 .../Mapa grande/Lightmap-3_comp_light.exr.meta     |   127 -
 .../Scenes/Mapa grande/Lightmap-4_comp_dir.png     |   Bin 53160 -> 0 bytes
 .../Mapa grande/Lightmap-4_comp_dir.png.meta       |   127 -
 .../Scenes/Mapa grande/Lightmap-4_comp_light.exr   |   Bin 306957 -> 0 bytes
 .../Mapa grande/Lightmap-4_comp_light.exr.meta     |   127 -
 .../Scenes/Mapa grande/Lightmap-5_comp_dir.png     |   Bin 54104 -> 0 bytes
 .../Mapa grande/Lightmap-5_comp_dir.png.meta       |   127 -
 .../Scenes/Mapa grande/Lightmap-5_comp_light.exr   |   Bin 303749 -> 0 bytes
 .../Mapa grande/Lightmap-5_comp_light.exr.meta     |   127 -
 .../Scenes/Mapa grande/Lightmap-6_comp_dir.png     |   Bin 53307 -> 0 bytes
 .../Mapa grande/Lightmap-6_comp_dir.png.meta       |   127 -
 .../Scenes/Mapa grande/Lightmap-6_comp_light.exr   |   Bin 303200 -> 0 bytes
 .../Mapa grande/Lightmap-6_comp_light.exr.meta     |   127 -
 .../Scenes/Mapa grande/Lightmap-7_comp_dir.png     |   Bin 51905 -> 0 bytes
 .../Mapa grande/Lightmap-7_comp_dir.png.meta       |   127 -
 .../Scenes/Mapa grande/Lightmap-7_comp_light.exr   |   Bin 307770 -> 0 bytes
 .../Mapa grande/Lightmap-7_comp_light.exr.meta     |   127 -
 .../Scenes/Mapa grande/Lightmap-8_comp_dir.png     |   Bin 52116 -> 0 bytes
 .../Mapa grande/Lightmap-8_comp_dir.png.meta       |   127 -
 .../Scenes/Mapa grande/Lightmap-8_comp_light.exr   |   Bin 305685 -> 0 bytes
 .../Mapa grande/Lightmap-8_comp_light.exr.meta     |   127 -
 .../Scenes/Mapa grande/Lightmap-9_comp_dir.png     |   Bin 54430 -> 0 bytes
 .../Mapa grande/Lightmap-9_comp_dir.png.meta       |   127 -
 .../Scenes/Mapa grande/Lightmap-9_comp_light.exr   |   Bin 307360 -> 0 bytes
 .../Mapa grande/Lightmap-9_comp_light.exr.meta     |   127 -
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |   222 +-
 .../Assets/Scenes/Mapa mediano/LightingData.asset  |   Bin 39880 -> 0 bytes
 .../Scenes/Mapa mediano/Lightmap-0_comp_dir.png    |   Bin 195192 -> 0 bytes
 .../Mapa mediano/Lightmap-0_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa mediano/Lightmap-0_comp_light.exr  |   Bin 577593 -> 0 bytes
 .../Mapa mediano/Lightmap-0_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa mediano/Lightmap-10_comp_dir.png   |   Bin 55102 -> 0 bytes
 .../Mapa mediano/Lightmap-10_comp_dir.png.meta     |   127 -
 .../Scenes/Mapa mediano/Lightmap-10_comp_light.exr |   Bin 315199 -> 0 bytes
 .../Mapa mediano/Lightmap-10_comp_light.exr.meta   |   127 -
 .../Scenes/Mapa mediano/Lightmap-11_comp_dir.png   |   Bin 55439 -> 0 bytes
 .../Mapa mediano/Lightmap-11_comp_dir.png.meta     |   127 -
 .../Scenes/Mapa mediano/Lightmap-11_comp_light.exr |   Bin 320263 -> 0 bytes
 .../Mapa mediano/Lightmap-11_comp_light.exr.meta   |   127 -
 .../Scenes/Mapa mediano/Lightmap-12_comp_dir.png   |   Bin 57029 -> 0 bytes
 .../Mapa mediano/Lightmap-12_comp_dir.png.meta     |   127 -
 .../Scenes/Mapa mediano/Lightmap-12_comp_light.exr |   Bin 317895 -> 0 bytes
 .../Mapa mediano/Lightmap-12_comp_light.exr.meta   |   127 -
 .../Scenes/Mapa mediano/Lightmap-13_comp_dir.png   |   Bin 53069 -> 0 bytes
 .../Mapa mediano/Lightmap-13_comp_dir.png.meta     |   127 -
 .../Scenes/Mapa mediano/Lightmap-13_comp_light.exr |   Bin 205075 -> 0 bytes
 .../Mapa mediano/Lightmap-13_comp_light.exr.meta   |   127 -
 .../Scenes/Mapa mediano/Lightmap-1_comp_dir.png    |   Bin 165338 -> 0 bytes
 .../Mapa mediano/Lightmap-1_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa mediano/Lightmap-1_comp_light.exr  |   Bin 540132 -> 0 bytes
 .../Mapa mediano/Lightmap-1_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa mediano/Lightmap-2_comp_dir.png    |   Bin 181520 -> 0 bytes
 .../Mapa mediano/Lightmap-2_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa mediano/Lightmap-2_comp_light.exr  |   Bin 530009 -> 0 bytes
 .../Mapa mediano/Lightmap-2_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa mediano/Lightmap-3_comp_dir.png    |   Bin 140183 -> 0 bytes
 .../Mapa mediano/Lightmap-3_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa mediano/Lightmap-3_comp_light.exr  |   Bin 502527 -> 0 bytes
 .../Mapa mediano/Lightmap-3_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa mediano/Lightmap-4_comp_dir.png    |   Bin 159230 -> 0 bytes
 .../Mapa mediano/Lightmap-4_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa mediano/Lightmap-4_comp_light.exr  |   Bin 566973 -> 0 bytes
 .../Mapa mediano/Lightmap-4_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa mediano/Lightmap-5_comp_dir.png    |   Bin 61607 -> 0 bytes
 .../Mapa mediano/Lightmap-5_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa mediano/Lightmap-5_comp_light.exr  |   Bin 327912 -> 0 bytes
 .../Mapa mediano/Lightmap-5_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa mediano/Lightmap-6_comp_dir.png    |   Bin 57245 -> 0 bytes
 .../Mapa mediano/Lightmap-6_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa mediano/Lightmap-6_comp_light.exr  |   Bin 321681 -> 0 bytes
 .../Mapa mediano/Lightmap-6_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa mediano/Lightmap-7_comp_dir.png    |   Bin 58385 -> 0 bytes
 .../Mapa mediano/Lightmap-7_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa mediano/Lightmap-7_comp_light.exr  |   Bin 313594 -> 0 bytes
 .../Mapa mediano/Lightmap-7_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa mediano/Lightmap-8_comp_dir.png    |   Bin 56239 -> 0 bytes
 .../Mapa mediano/Lightmap-8_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa mediano/Lightmap-8_comp_light.exr  |   Bin 318394 -> 0 bytes
 .../Mapa mediano/Lightmap-8_comp_light.exr.meta    |   127 -
 .../Scenes/Mapa mediano/Lightmap-9_comp_dir.png    |   Bin 59769 -> 0 bytes
 .../Mapa mediano/Lightmap-9_comp_dir.png.meta      |   127 -
 .../Scenes/Mapa mediano/Lightmap-9_comp_light.exr  |   Bin 320796 -> 0 bytes
 .../Mapa mediano/Lightmap-9_comp_light.exr.meta    |   127 -
 .../Mapa mediano/NavMesh-NavMesh Surface.asset     |   Bin 157640 -> 50976 bytes
 .../Scenes/Mapa mediano/OcclusionCullingData.asset |   160 +-
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |   194 +-
 .../Scenes/Mapa peque\303\261o/LightingData.asset" |   Bin 34176 -> 0 bytes
 .../Mapa peque\303\261o/Lightmap-0_comp_dir.png"   |   Bin 2680 -> 0 bytes
 .../Lightmap-0_comp_dir.png.meta"                  |   140 -
 .../Mapa peque\303\261o/Lightmap-0_comp_light.exr" |   Bin 24628 -> 0 bytes
 .../Lightmap-0_comp_light.exr.meta"                |   140 -
 .../Mapa peque\303\261o/Lightmap-10_comp_dir.png"  |   Bin 2754 -> 0 bytes
 .../Lightmap-10_comp_dir.png.meta"                 |   140 -
 .../Lightmap-10_comp_light.exr"                    |   Bin 24794 -> 0 bytes
 .../Lightmap-10_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-11_comp_dir.png"  |   Bin 2127 -> 0 bytes
 .../Lightmap-11_comp_dir.png.meta"                 |   140 -
 .../Lightmap-11_comp_light.exr"                    |   Bin 21822 -> 0 bytes
 .../Lightmap-11_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-12_comp_dir.png"  |   Bin 2171 -> 0 bytes
 .../Lightmap-12_comp_dir.png.meta"                 |   140 -
 .../Lightmap-12_comp_light.exr"                    |   Bin 21661 -> 0 bytes
 .../Lightmap-12_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-13_comp_dir.png"  |   Bin 2297 -> 0 bytes
 .../Lightmap-13_comp_dir.png.meta"                 |   140 -
 .../Lightmap-13_comp_light.exr"                    |   Bin 20951 -> 0 bytes
 .../Lightmap-13_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-14_comp_dir.png"  |   Bin 2164 -> 0 bytes
 .../Lightmap-14_comp_dir.png.meta"                 |   140 -
 .../Lightmap-14_comp_light.exr"                    |   Bin 22587 -> 0 bytes
 .../Lightmap-14_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-15_comp_dir.png"  |   Bin 2221 -> 0 bytes
 .../Lightmap-15_comp_dir.png.meta"                 |   140 -
 .../Lightmap-15_comp_light.exr"                    |   Bin 21394 -> 0 bytes
 .../Lightmap-15_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-16_comp_dir.png"  |   Bin 1919 -> 0 bytes
 .../Lightmap-16_comp_dir.png.meta"                 |   140 -
 .../Lightmap-16_comp_light.exr"                    |   Bin 21879 -> 0 bytes
 .../Lightmap-16_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-17_comp_dir.png"  |   Bin 2563 -> 0 bytes
 .../Lightmap-17_comp_dir.png.meta"                 |   140 -
 .../Lightmap-17_comp_light.exr"                    |   Bin 21609 -> 0 bytes
 .../Lightmap-17_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-18_comp_dir.png"  |   Bin 2348 -> 0 bytes
 .../Lightmap-18_comp_dir.png.meta"                 |   140 -
 .../Lightmap-18_comp_light.exr"                    |   Bin 22032 -> 0 bytes
 .../Lightmap-18_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-19_comp_dir.png"  |   Bin 1959 -> 0 bytes
 .../Lightmap-19_comp_dir.png.meta"                 |   140 -
 .../Lightmap-19_comp_light.exr"                    |   Bin 22140 -> 0 bytes
 .../Lightmap-19_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-1_comp_dir.png"   |   Bin 1987 -> 0 bytes
 .../Lightmap-1_comp_dir.png.meta"                  |   140 -
 .../Mapa peque\303\261o/Lightmap-1_comp_light.exr" |   Bin 22034 -> 0 bytes
 .../Lightmap-1_comp_light.exr.meta"                |   140 -
 .../Mapa peque\303\261o/Lightmap-20_comp_dir.png"  |   Bin 2571 -> 0 bytes
 .../Lightmap-20_comp_dir.png.meta"                 |   140 -
 .../Lightmap-20_comp_light.exr"                    |   Bin 22600 -> 0 bytes
 .../Lightmap-20_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-21_comp_dir.png"  |   Bin 2461 -> 0 bytes
 .../Lightmap-21_comp_dir.png.meta"                 |   140 -
 .../Lightmap-21_comp_light.exr"                    |   Bin 21919 -> 0 bytes
 .../Lightmap-21_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-22_comp_dir.png"  |   Bin 2860 -> 0 bytes
 .../Lightmap-22_comp_dir.png.meta"                 |   140 -
 .../Lightmap-22_comp_light.exr"                    |   Bin 23714 -> 0 bytes
 .../Lightmap-22_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-23_comp_dir.png"  |   Bin 2316 -> 0 bytes
 .../Lightmap-23_comp_dir.png.meta"                 |   140 -
 .../Lightmap-23_comp_light.exr"                    |   Bin 21756 -> 0 bytes
 .../Lightmap-23_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-24_comp_dir.png"  |   Bin 2124 -> 0 bytes
 .../Lightmap-24_comp_dir.png.meta"                 |   140 -
 .../Lightmap-24_comp_light.exr"                    |   Bin 22277 -> 0 bytes
 .../Lightmap-24_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-25_comp_dir.png"  |   Bin 1998 -> 0 bytes
 .../Lightmap-25_comp_dir.png.meta"                 |   140 -
 .../Lightmap-25_comp_light.exr"                    |   Bin 22033 -> 0 bytes
 .../Lightmap-25_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-26_comp_dir.png"  |   Bin 2333 -> 0 bytes
 .../Lightmap-26_comp_dir.png.meta"                 |   140 -
 .../Lightmap-26_comp_light.exr"                    |   Bin 22239 -> 0 bytes
 .../Lightmap-26_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-27_comp_dir.png"  |   Bin 2083 -> 0 bytes
 .../Lightmap-27_comp_dir.png.meta"                 |   140 -
 .../Lightmap-27_comp_light.exr"                    |   Bin 22915 -> 0 bytes
 .../Lightmap-27_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-28_comp_dir.png"  |   Bin 1905 -> 0 bytes
 .../Lightmap-28_comp_dir.png.meta"                 |   140 -
 .../Lightmap-28_comp_light.exr"                    |   Bin 21877 -> 0 bytes
 .../Lightmap-28_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-29_comp_dir.png"  |   Bin 2077 -> 0 bytes
 .../Lightmap-29_comp_dir.png.meta"                 |   140 -
 .../Lightmap-29_comp_light.exr"                    |   Bin 21212 -> 0 bytes
 .../Lightmap-29_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-2_comp_dir.png"   |   Bin 1902 -> 0 bytes
 .../Lightmap-2_comp_dir.png.meta"                  |   140 -
 .../Mapa peque\303\261o/Lightmap-2_comp_light.exr" |   Bin 22466 -> 0 bytes
 .../Lightmap-2_comp_light.exr.meta"                |   140 -
 .../Mapa peque\303\261o/Lightmap-30_comp_dir.png"  |   Bin 2577 -> 0 bytes
 .../Lightmap-30_comp_dir.png.meta"                 |   140 -
 .../Lightmap-30_comp_light.exr"                    |   Bin 22832 -> 0 bytes
 .../Lightmap-30_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-31_comp_dir.png"  |   Bin 2061 -> 0 bytes
 .../Lightmap-31_comp_dir.png.meta"                 |   140 -
 .../Lightmap-31_comp_light.exr"                    |   Bin 20859 -> 0 bytes
 .../Lightmap-31_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-32_comp_dir.png"  |   Bin 2296 -> 0 bytes
 .../Lightmap-32_comp_dir.png.meta"                 |   140 -
 .../Lightmap-32_comp_light.exr"                    |   Bin 21411 -> 0 bytes
 .../Lightmap-32_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-33_comp_dir.png"  |   Bin 2644 -> 0 bytes
 .../Lightmap-33_comp_dir.png.meta"                 |   140 -
 .../Lightmap-33_comp_light.exr"                    |   Bin 21870 -> 0 bytes
 .../Lightmap-33_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-34_comp_dir.png"  |   Bin 2195 -> 0 bytes
 .../Lightmap-34_comp_dir.png.meta"                 |   140 -
 .../Lightmap-34_comp_light.exr"                    |   Bin 21522 -> 0 bytes
 .../Lightmap-34_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-35_comp_dir.png"  |   Bin 2074 -> 0 bytes
 .../Lightmap-35_comp_dir.png.meta"                 |   140 -
 .../Lightmap-35_comp_light.exr"                    |   Bin 21498 -> 0 bytes
 .../Lightmap-35_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-36_comp_dir.png"  |   Bin 2290 -> 0 bytes
 .../Lightmap-36_comp_dir.png.meta"                 |   140 -
 .../Lightmap-36_comp_light.exr"                    |   Bin 22098 -> 0 bytes
 .../Lightmap-36_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-37_comp_dir.png"  |   Bin 2506 -> 0 bytes
 .../Lightmap-37_comp_dir.png.meta"                 |   140 -
 .../Lightmap-37_comp_light.exr"                    |   Bin 22623 -> 0 bytes
 .../Lightmap-37_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-38_comp_dir.png"  |   Bin 2155 -> 0 bytes
 .../Lightmap-38_comp_dir.png.meta"                 |   140 -
 .../Lightmap-38_comp_light.exr"                    |   Bin 23105 -> 0 bytes
 .../Lightmap-38_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-39_comp_dir.png"  |   Bin 2450 -> 0 bytes
 .../Lightmap-39_comp_dir.png.meta"                 |   140 -
 .../Lightmap-39_comp_light.exr"                    |   Bin 22745 -> 0 bytes
 .../Lightmap-39_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-3_comp_dir.png"   |   Bin 2138 -> 0 bytes
 .../Lightmap-3_comp_dir.png.meta"                  |   140 -
 .../Mapa peque\303\261o/Lightmap-3_comp_light.exr" |   Bin 21829 -> 0 bytes
 .../Lightmap-3_comp_light.exr.meta"                |   140 -
 .../Mapa peque\303\261o/Lightmap-40_comp_dir.png"  |   Bin 2566 -> 0 bytes
 .../Lightmap-40_comp_dir.png.meta"                 |   140 -
 .../Lightmap-40_comp_light.exr"                    |   Bin 22192 -> 0 bytes
 .../Lightmap-40_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-41_comp_dir.png"  |   Bin 2054 -> 0 bytes
 .../Lightmap-41_comp_dir.png.meta"                 |   140 -
 .../Lightmap-41_comp_light.exr"                    |   Bin 22140 -> 0 bytes
 .../Lightmap-41_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-42_comp_dir.png"  |   Bin 3000 -> 0 bytes
 .../Lightmap-42_comp_dir.png.meta"                 |   140 -
 .../Lightmap-42_comp_light.exr"                    |   Bin 22101 -> 0 bytes
 .../Lightmap-42_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-43_comp_dir.png"  |   Bin 2121 -> 0 bytes
 .../Lightmap-43_comp_dir.png.meta"                 |   140 -
 .../Lightmap-43_comp_light.exr"                    |   Bin 22658 -> 0 bytes
 .../Lightmap-43_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-44_comp_dir.png"  |   Bin 2256 -> 0 bytes
 .../Lightmap-44_comp_dir.png.meta"                 |   140 -
 .../Lightmap-44_comp_light.exr"                    |   Bin 21778 -> 0 bytes
 .../Lightmap-44_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-45_comp_dir.png"  |   Bin 2327 -> 0 bytes
 .../Lightmap-45_comp_dir.png.meta"                 |   140 -
 .../Lightmap-45_comp_light.exr"                    |   Bin 21447 -> 0 bytes
 .../Lightmap-45_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-46_comp_dir.png"  |   Bin 2205 -> 0 bytes
 .../Lightmap-46_comp_dir.png.meta"                 |   140 -
 .../Lightmap-46_comp_light.exr"                    |   Bin 21453 -> 0 bytes
 .../Lightmap-46_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-47_comp_dir.png"  |   Bin 2079 -> 0 bytes
 .../Lightmap-47_comp_dir.png.meta"                 |   140 -
 .../Lightmap-47_comp_light.exr"                    |   Bin 21922 -> 0 bytes
 .../Lightmap-47_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-48_comp_dir.png"  |   Bin 2119 -> 0 bytes
 .../Lightmap-48_comp_dir.png.meta"                 |   140 -
 .../Lightmap-48_comp_light.exr"                    |   Bin 20597 -> 0 bytes
 .../Lightmap-48_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-49_comp_dir.png"  |   Bin 1830 -> 0 bytes
 .../Lightmap-49_comp_dir.png.meta"                 |   140 -
 .../Lightmap-49_comp_light.exr"                    |   Bin 21192 -> 0 bytes
 .../Lightmap-49_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-4_comp_dir.png"   |   Bin 2162 -> 0 bytes
 .../Lightmap-4_comp_dir.png.meta"                  |   140 -
 .../Mapa peque\303\261o/Lightmap-4_comp_light.exr" |   Bin 23146 -> 0 bytes
 .../Lightmap-4_comp_light.exr.meta"                |   140 -
 .../Mapa peque\303\261o/Lightmap-50_comp_dir.png"  |   Bin 2057 -> 0 bytes
 .../Lightmap-50_comp_dir.png.meta"                 |   140 -
 .../Lightmap-50_comp_light.exr"                    |   Bin 22008 -> 0 bytes
 .../Lightmap-50_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-51_comp_dir.png"  |   Bin 2056 -> 0 bytes
 .../Lightmap-51_comp_dir.png.meta"                 |   140 -
 .../Lightmap-51_comp_light.exr"                    |   Bin 22075 -> 0 bytes
 .../Lightmap-51_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-52_comp_dir.png"  |   Bin 2534 -> 0 bytes
 .../Lightmap-52_comp_dir.png.meta"                 |   140 -
 .../Lightmap-52_comp_light.exr"                    |   Bin 22184 -> 0 bytes
 .../Lightmap-52_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-53_comp_dir.png"  |   Bin 2674 -> 0 bytes
 .../Lightmap-53_comp_dir.png.meta"                 |   140 -
 .../Lightmap-53_comp_light.exr"                    |   Bin 23988 -> 0 bytes
 .../Lightmap-53_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-54_comp_dir.png"  |   Bin 2510 -> 0 bytes
 .../Lightmap-54_comp_dir.png.meta"                 |   140 -
 .../Lightmap-54_comp_light.exr"                    |   Bin 21309 -> 0 bytes
 .../Lightmap-54_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-55_comp_dir.png"  |   Bin 2105 -> 0 bytes
 .../Lightmap-55_comp_dir.png.meta"                 |   140 -
 .../Lightmap-55_comp_light.exr"                    |   Bin 22269 -> 0 bytes
 .../Lightmap-55_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-56_comp_dir.png"  |   Bin 2183 -> 0 bytes
 .../Lightmap-56_comp_dir.png.meta"                 |   140 -
 .../Lightmap-56_comp_light.exr"                    |   Bin 21268 -> 0 bytes
 .../Lightmap-56_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-57_comp_dir.png"  |   Bin 2742 -> 0 bytes
 .../Lightmap-57_comp_dir.png.meta"                 |   140 -
 .../Lightmap-57_comp_light.exr"                    |   Bin 22963 -> 0 bytes
 .../Lightmap-57_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-58_comp_dir.png"  |   Bin 2588 -> 0 bytes
 .../Lightmap-58_comp_dir.png.meta"                 |   140 -
 .../Lightmap-58_comp_light.exr"                    |   Bin 22755 -> 0 bytes
 .../Lightmap-58_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-59_comp_dir.png"  |   Bin 2149 -> 0 bytes
 .../Lightmap-59_comp_dir.png.meta"                 |   140 -
 .../Lightmap-59_comp_light.exr"                    |   Bin 22336 -> 0 bytes
 .../Lightmap-59_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-5_comp_dir.png"   |   Bin 2386 -> 0 bytes
 .../Lightmap-5_comp_dir.png.meta"                  |   140 -
 .../Mapa peque\303\261o/Lightmap-5_comp_light.exr" |   Bin 21417 -> 0 bytes
 .../Lightmap-5_comp_light.exr.meta"                |   140 -
 .../Mapa peque\303\261o/Lightmap-60_comp_dir.png"  |   Bin 2265 -> 0 bytes
 .../Lightmap-60_comp_dir.png.meta"                 |   140 -
 .../Lightmap-60_comp_light.exr"                    |   Bin 22297 -> 0 bytes
 .../Lightmap-60_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-61_comp_dir.png"  |   Bin 1226 -> 0 bytes
 .../Lightmap-61_comp_dir.png.meta"                 |   140 -
 .../Lightmap-61_comp_light.exr"                    |   Bin 11070 -> 0 bytes
 .../Lightmap-61_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-62_comp_dir.png"  |   Bin 5709 -> 0 bytes
 .../Lightmap-62_comp_dir.png.meta"                 |   140 -
 .../Lightmap-62_comp_light.exr"                    |   Bin 31958 -> 0 bytes
 .../Lightmap-62_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-63_comp_dir.png"  |   Bin 2039 -> 0 bytes
 .../Lightmap-63_comp_dir.png.meta"                 |   140 -
 .../Lightmap-63_comp_light.exr"                    |   Bin 20104 -> 0 bytes
 .../Lightmap-63_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-64_comp_dir.png"  |   Bin 2463 -> 0 bytes
 .../Lightmap-64_comp_dir.png.meta"                 |   140 -
 .../Lightmap-64_comp_light.exr"                    |   Bin 22793 -> 0 bytes
 .../Lightmap-64_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-65_comp_dir.png"  |   Bin 2281 -> 0 bytes
 .../Lightmap-65_comp_dir.png.meta"                 |   140 -
 .../Lightmap-65_comp_light.exr"                    |   Bin 21834 -> 0 bytes
 .../Lightmap-65_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-66_comp_dir.png"  |   Bin 2234 -> 0 bytes
 .../Lightmap-66_comp_dir.png.meta"                 |   140 -
 .../Lightmap-66_comp_light.exr"                    |   Bin 21086 -> 0 bytes
 .../Lightmap-66_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-67_comp_dir.png"  |   Bin 2101 -> 0 bytes
 .../Lightmap-67_comp_dir.png.meta"                 |   140 -
 .../Lightmap-67_comp_light.exr"                    |   Bin 21701 -> 0 bytes
 .../Lightmap-67_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-68_comp_dir.png"  |   Bin 2278 -> 0 bytes
 .../Lightmap-68_comp_dir.png.meta"                 |   140 -
 .../Lightmap-68_comp_light.exr"                    |   Bin 21979 -> 0 bytes
 .../Lightmap-68_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-69_comp_dir.png"  |   Bin 2366 -> 0 bytes
 .../Lightmap-69_comp_dir.png.meta"                 |   140 -
 .../Lightmap-69_comp_light.exr"                    |   Bin 21718 -> 0 bytes
 .../Lightmap-69_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-6_comp_dir.png"   |   Bin 2534 -> 0 bytes
 .../Lightmap-6_comp_dir.png.meta"                  |   140 -
 .../Mapa peque\303\261o/Lightmap-6_comp_light.exr" |   Bin 22629 -> 0 bytes
 .../Lightmap-6_comp_light.exr.meta"                |   140 -
 .../Mapa peque\303\261o/Lightmap-70_comp_dir.png"  |   Bin 30064 -> 0 bytes
 .../Lightmap-70_comp_dir.png.meta"                 |   140 -
 .../Lightmap-70_comp_light.exr"                    |   Bin 81069 -> 0 bytes
 .../Lightmap-70_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-71_comp_dir.png"  |   Bin 24964 -> 0 bytes
 .../Lightmap-71_comp_dir.png.meta"                 |   140 -
 .../Lightmap-71_comp_light.exr"                    |   Bin 72217 -> 0 bytes
 .../Lightmap-71_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-72_comp_dir.png"  |   Bin 25424 -> 0 bytes
 .../Lightmap-72_comp_dir.png.meta"                 |   140 -
 .../Lightmap-72_comp_light.exr"                    |   Bin 73089 -> 0 bytes
 .../Lightmap-72_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-73_comp_dir.png"  |   Bin 5449 -> 0 bytes
 .../Lightmap-73_comp_dir.png.meta"                 |   140 -
 .../Lightmap-73_comp_light.exr"                    |   Bin 26514 -> 0 bytes
 .../Lightmap-73_comp_light.exr.meta"               |   140 -
 .../Mapa peque\303\261o/Lightmap-7_comp_dir.png"   |   Bin 1995 -> 0 bytes
 .../Lightmap-7_comp_dir.png.meta"                  |   140 -
 .../Mapa peque\303\261o/Lightmap-7_comp_light.exr" |   Bin 21928 -> 0 bytes
 .../Lightmap-7_comp_light.exr.meta"                |   140 -
 .../Mapa peque\303\261o/Lightmap-8_comp_dir.png"   |   Bin 1804 -> 0 bytes
 .../Lightmap-8_comp_dir.png.meta"                  |   140 -
 .../Mapa peque\303\261o/Lightmap-8_comp_light.exr" |   Bin 21261 -> 0 bytes
 .../Lightmap-8_comp_light.exr.meta"                |   140 -
 .../Mapa peque\303\261o/Lightmap-9_comp_dir.png"   |   Bin 3125 -> 0 bytes
 .../Lightmap-9_comp_dir.png.meta"                  |   140 -
 .../Mapa peque\303\261o/Lightmap-9_comp_light.exr" |   Bin 21570 -> 0 bytes
 .../Lightmap-9_comp_light.exr.meta"                |   140 -
 .../NavMesh-NavMesh Surface.asset"                 |   Bin 64752 -> 24740 bytes
 .../OcclusionCullingData.asset"                    |   104 +-
 .../Assets/Scenes/Menu_principal.unity             |   675 +-
 Supermarkert Run/Assets/Scripts/AI/IA.cs           |     5 +-
 .../Assets/Scripts/Caja/CajaEnemigo.cs             |     2 +
 .../Scripts/Juego/Configuraciones/Calidad.cs       |    93 +-
 .../Scripts/Juego/Configuraciones/Sombras.cs       |    14 +-
 .../Assets/Scripts/Juego/Gameplay/AnimationIcon.cs |    16 +-
 .../Assets/Scripts/Juego/Gameplay/Nivel.cs         |     2 +-
 .../Juego/Gameplay/Pase_Conexion_Menu_Gameplay.cs  |     2 -
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |    15 +-
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |    12 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   108 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |     8 +-
 Supermarkert Run/Assets/Scripts/estantes/Area.cs   |    13 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |    28 +
 Supermarkert Run/Assets/URP.asset                  |     2 +-
 .../Assets/URPDefaultResources/High.asset          |     8 +-
 .../Assets/URPDefaultResources/Low.asset           |     4 +-
 .../Assets/URPDefaultResources/Medium.asset        |     8 +-
 .../Assets/URPDefaultResources/Trabajo.asset       |     8 +-
 .../Assets/URPDefaultResources/Ultra.asset         |     8 +-
 .../Assets/URPDefaultResources/Very High.asset     |     8 +-
 .../Assets/URPDefaultResources/Very Low.asset      |    10 +-
 .../Assets/_Recovery.meta                          |     6 +-
 Supermarkert Run/Assets/_Recovery/0.unity          | 38722 +++++++++++++++++++
 Supermarkert Run/Assets/_Recovery/0.unity.meta     |     7 +
 Supermarkert Run/Assets/shader/Glow.meta           |     8 +
 .../Assets/shader/Glow/EstanteriaElegida.mat       |    66 +
 .../Glow/EstanteriaElegida.mat.meta}               |     4 +-
 .../Assets/shader/Glow/Glow.shadergraph            |  2771 ++
 .../Assets/shader/Glow/Glow.shadergraph.meta       |    18 +
 Supermarkert Run/Assets/shader/Glow/SignalCash.mat |    66 +
 .../Glow/SignalCash.mat.meta}                      |     4 +-
 .../Assets/textures/Supermercado/Suelo2.mat        |     4 +-
 .../textures/Supermercado/fondoTransparente.png    |   Bin 0 -> 2159 bytes
 .../Supermercado/fondoTransparente.png.meta}       |    41 +-
 Supermarkert Run/Assets/textures/UI_GAME/Hoja.png  |   Bin 0 -> 14511 bytes
 .../UI_GAME/Hoja.png.meta}                         |    43 +-
 Supermarkert Run/Assets/textures/UI_GAME/caja.png  |   Bin 0 -> 2208 bytes
 .../UI_GAME/caja.png.meta}                         |    45 +-
 .../Assets/textures/UI_GAME/escoba.png             |   Bin 0 -> 1746 bytes
 .../Assets/textures/UI_GAME/escoba.png.meta        |   130 +
 .../textures/UI_GAME/fondoTransparente 1.png       |   Bin 0 -> 2159 bytes
 .../UI_GAME/fondoTransparente 1.png.meta}          |    45 +-
 .../Assets/textures/UI_GAME/hamburguesa.png        |   Bin 0 -> 9331 bytes
 .../Assets/textures/UI_GAME/hamburguesa.png.meta   |   130 +
 Supermarkert Run/Assets/textures/UI_GAME/jugo.png  |   Bin 0 -> 1013 bytes
 .../Assets/textures/UI_GAME/jugo.png.meta          |   130 +
 Supermarkert Run/Assets/textures/UI_GAME/libro.png |   Bin 0 -> 3395 bytes
 .../Assets/textures/UI_GAME/libro.png.meta         |   130 +
 .../Assets/textures/UI_GAME/microndas.png          |   Bin 0 -> 991 bytes
 .../Assets/textures/UI_GAME/microndas.png.meta     |   130 +
 Supermarkert Run/Assets/textures/UI_GAME/rollo.png |   Bin 0 -> 1156 bytes
 .../Assets/textures/UI_GAME/rollo.png.meta         |   130 +
 Supermarkert Run/Packages/manifest.json            |     1 +
 Supermarkert Run/Packages/packages-lock.json       |     6 +
 .../ProjectSettings/ProjectSettings.asset          |     2 +-
 .../ProjectSettings/QualitySettings.asset          |     2 +-
 546 files changed, 44689 insertions(+), 32561 deletions(-)

=== COMMIT: d6c81ab | Tue May 19 13:40:47 2026 -0600 | build y solucionar bug de dar el nivel que no era ===
 ...72f.json => cache-v2-5a4d98a07c1007bb28c3.json} |  38 +-
 .../reply/cmakeFiles-v1-92d75d8bf59096b0b566.json  | 195 +++++
 .../reply/cmakeFiles-v1-995979dad01113f7d7a0.json  | 810 ---------------------
 ...40.json => index-2026-05-19T19-14-56-0474.json} |   8 +-
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 10656 -> 10908 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   2 +
 .../3x543z5q/arm64-v8a/CMakeCache.txt              |   4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/build.ninja  |   9 +-
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 +-
 ...fee.json => cache-v2-24eebb703a42eeb354ee.json} |  38 +-
 .../reply/cmakeFiles-v1-123ecd08fae43f60fcba.json  | 810 ---------------------
 .../reply/cmakeFiles-v1-5e9abec131dae743f9ca.json  | 195 +++++
 ...34.json => index-2026-05-19T19-14-59-0135.json} |   8 +-
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 10656 -> 10908 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   2 +
 .../3x543z5q/armeabi-v7a/CMakeCache.txt            |   4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/build.ninja               |   9 +-
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   4 +-
 .../Assets/URPDefaultResources/High.asset          |   6 +-
 .../Assets/URPDefaultResources/Low.asset           |   2 +-
 .../Assets/URPDefaultResources/Medium.asset        |   6 +-
 .../Assets/URPDefaultResources/Trabajo.asset       |   6 +-
 .../Assets/URPDefaultResources/Ultra.asset         |   6 +-
 .../Assets/URPDefaultResources/Very High.asset     |   6 +-
 27 files changed, 462 insertions(+), 1758 deletions(-)

=== COMMIT: b69ce9d | Tue May 19 22:55:03 2026 -0600 | Solucionar el bug de texto en Power Up, solucionar bug de no guardado de nivel, y eliminar comentarios que eran codigo legacy ===
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 +-
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 +-
 .../Assets/Scenes/Menu_principal.unity             | 380 ++++++++++++++++++++-
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |  36 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   8 +-
 .../Assets/Scripts/PowerUp/Manos_Rapidas.cs        |  13 -
 .../Assets/Scripts/PowerUp/Proteccion.cs           |  14 -
 .../Assets/Scripts/PowerUp/Velocidad.cs            |  14 -
 8 files changed, 423 insertions(+), 94 deletions(-)

=== COMMIT: 8a9400f | Wed May 20 20:28:26 2026 -0600 | Solucionar bug logico que daba mision que hacia mision_default + Nivel - 1, ahora es Nivel <= 10 se da mision_default, solucionar el bug de queel jugador se traspasaba los colliders y ya no se usa transform se usa el RigidBody para manejar al jugador con FixedUpdate para mayor precision en colision y el lag ===
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |    26 +-
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |    26 +-
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |     6 +-
 .../Assets/Scenes/Menu_principal.unity             |     1 +
 .../Assets/Scripts/Juego/Gameplay/Nivel.cs         |     4 -
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |     7 +-
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |     4 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |     2 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    44 +-
 Supermarkert Run/Assets/_Recovery/0 (1).unity      | 38431 +++++++++++++++++++
 Supermarkert Run/Assets/_Recovery/0 (1).unity.meta |     7 +
 11 files changed, 38510 insertions(+), 48 deletions(-)

=== COMMIT: 1e1a718 | Thu May 21 12:42:18 2026 -0600 | Nuevos Modelos ===
 Supermarkert Run/Assets/Objetos/New_Model/Escoba.blend | Bin 0 -> 121822 bytes
 Supermarkert Run/Assets/Objetos/New_Model/Escoba.fbx   | Bin 0 -> 20812 bytes
 .../Assets/Objetos/New_Model/Estante_escobas.blend     | Bin 0 -> 106318 bytes
 .../Assets/Objetos/New_Model/Estante_escobas.fbx       | Bin 0 -> 17388 bytes
 .../New_Model/Estantes_escoba_con_escobas.blend        | Bin 0 -> 115061 bytes
 .../Objetos/New_Model/Estantes_escoba_con_escobas.fbx  | Bin 0 -> 66252 bytes
 6 files changed, 0 insertions(+), 0 deletions(-)

=== COMMIT: b40db8a | Thu May 21 15:49:38 2026 -0600 | el gitignore en la carpeta real del proyecto ===
 Supermarkert Run/.gitignore           |  72 ++++++++++++++++++++++++++++++++++
 Supermarkert Run/ProfilerCaptures.rar | Bin 15326394 -> 0 bytes
 2 files changed, 72 insertions(+)

=== COMMIT: de2c317 | Thu May 21 23:08:46 2026 -0600 | Modelo de Estanteria con escobas unido en un solo objeto ===
 .../New_Model/Estantes_escoba_con_escobas.blend    | Bin 115061 -> 119373 bytes
 1 file changed, 0 insertions(+), 0 deletions(-)

=== COMMIT: 9456455 | Tue May 26 22:44:31 2026 -0600 | Agregar dependencias de google para conectar con sus servidores, hacer que los estantes se oculten si el jugador esta cercas y no se logra visualizar, solucionar bug de carro que daba skin sin haberlo seleccionado, colocar el costo de las skins y mapas del juego, nuevo modelo de escoba actualmente en desuso, aumentar el tiempo del gameplay de 5 a 10 minutos ===
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |   26 +-
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |   26 +-
 .../Assets/ExternalDependencyManager.meta          |    8 +
 .../Assets/ExternalDependencyManager/Editor.meta   |    8 +
 .../ExternalDependencyManager/Editor/1.2.182.meta  |    8 +
 .../Editor/1.2.182/Google.IOSResolver.dll          |  Bin 0 -> 74240 bytes
 .../Editor/1.2.182/Google.IOSResolver.dll.meta     |   32 +
 .../Editor/1.2.182/Google.JarResolver.dll          |  Bin 0 -> 364032 bytes
 .../Editor/1.2.182/Google.JarResolver.dll.meta     |   32 +
 .../1.2.182/Google.PackageManagerResolver.dll      |  Bin 0 -> 74240 bytes
 .../1.2.182/Google.PackageManagerResolver.dll.meta |   32 +
 .../Editor/1.2.182/Google.VersionHandlerImpl.dll   |  Bin 0 -> 119296 bytes
 .../1.2.182/Google.VersionHandlerImpl.dll.meta     |   32 +
 .../ExternalDependencyManager/Editor/CHANGELOG.md  | 1411 ++++++++++++++++++++
 .../Editor/CHANGELOG.md.meta                       |   11 +
 .../Editor/Google.VersionHandler.dll               |  Bin 0 -> 15360 bytes
 .../Editor/Google.VersionHandler.dll.meta          |   32 +
 .../ExternalDependencyManager/Editor/LICENSE       |  245 ++++
 .../ExternalDependencyManager/Editor/LICENSE.meta  |   11 +
 .../ExternalDependencyManager/Editor/README.md     |  897 +++++++++++++
 .../Editor/README.md.meta                          |   11 +
 ...dependency-manager_version-1.2.182_manifest.txt |   13 +
 ...dency-manager_version-1.2.182_manifest.txt.meta |   14 +
 Supermarkert Run/Assets/GeneratedLocalRepo.meta    |    8 +
 .../Assets/GeneratedLocalRepo/GooglePlayGames.meta |    8 +
 .../GooglePlayGames/com.google.play.games.meta     |    8 +
 .../com.google.play.games/Editor.meta              |    8 +
 .../com.google.play.games/Editor/m2repository.meta |    8 +
 .../Editor/m2repository/com.meta                   |    8 +
 .../Editor/m2repository/com/google.meta            |    8 +
 .../Editor/m2repository/com/google/games.meta      |    8 +
 .../com/google/games/gpgs-plugin-support.meta      |    8 +
 .../google/games/gpgs-plugin-support/2.1.0.meta    |    8 +
 .../2.1.0/gpgs-plugin-support-2.1.0.aar            |  Bin 0 -> 31938 bytes
 .../2.1.0/gpgs-plugin-support-2.1.0.aar.meta       |   25 +
 .../2.1.0/gpgs-plugin-support-2.1.0.pom            |   20 +
 .../2.1.0/gpgs-plugin-support-2.1.0.pom.meta       |    9 +
 Supermarkert Run/Assets/GooglePlayGames.meta       |    8 +
 .../GooglePlayGames/com.google.play.games.meta     |    8 +
 .../com.google.play.games/Editor.meta              |    9 +
 .../Editor/GPGSAndroidSetupUI.cs                   |  460 +++++++
 .../Editor/GPGSAndroidSetupUI.cs.meta              |   14 +
 .../com.google.play.games/Editor/GPGSDocsUI.cs     |   53 +
 .../Editor/GPGSDocsUI.cs.meta                      |   14 +
 .../com.google.play.games/Editor/GPGSPostBuild.cs  |   42 +
 .../Editor/GPGSPostBuild.cs.meta                   |   14 +
 .../Editor/GPGSProjectSettings.cs                  |  197 +++
 .../Editor/GPGSProjectSettings.cs.meta             |   14 +
 .../com.google.play.games/Editor/GPGSStrings.cs    |  174 +++
 .../Editor/GPGSStrings.cs.meta                     |   14 +
 .../com.google.play.games/Editor/GPGSUpgrader.cs   |   61 +
 .../Editor/GPGSUpgrader.cs.meta                    |   14 +
 .../com.google.play.games/Editor/GPGSUtil.cs       |  798 +++++++++++
 .../com.google.play.games/Editor/GPGSUtil.cs.meta  |   14 +
 .../Editor/Google.Play.Games.Editor.asmdef         |    9 +
 .../Editor/Google.Play.Games.Editor.asmdef.meta    |   10 +
 .../Editor/GooglePlayGamesPluginDependencies.xml   |   13 +
 .../GooglePlayGamesPluginDependencies.xml.meta     |    9 +
 .../Editor/GooglePlayGamesPlugin_v2.1.0.txt        |  100 ++
 .../Editor/GooglePlayGamesPlugin_v2.1.0.txt.meta   |   11 +
 .../Editor/NearbyConnectionUI.cs                   |  153 +++
 .../Editor/NearbyConnectionUI.cs.meta              |   14 +
 .../com.google.play.games/Editor/m2repository.meta |   10 +
 .../Editor/m2repository/com.meta                   |    8 +
 .../Editor/m2repository/com/google.meta            |    8 +
 .../Editor/m2repository/com/google/games.meta      |    8 +
 .../com/google/games/gpgs-plugin-support.meta      |    8 +
 .../google/games/gpgs-plugin-support/2.1.0.meta    |    8 +
 .../2.1.0/gpgs-plugin-support-2.1.0.pom            |   20 +
 .../2.1.0/gpgs-plugin-support-2.1.0.pom.md5        |    1 +
 .../2.1.0/gpgs-plugin-support-2.1.0.pom.md5.meta   |    9 +
 .../2.1.0/gpgs-plugin-support-2.1.0.pom.meta       |    9 +
 .../2.1.0/gpgs-plugin-support-2.1.0.pom.sha1       |    1 +
 .../2.1.0/gpgs-plugin-support-2.1.0.pom.sha1.meta  |    9 +
 .../2.1.0/gpgs-plugin-support-2.1.0.pom.sha256     |    1 +
 .../gpgs-plugin-support-2.1.0.pom.sha256.meta      |    9 +
 .../2.1.0/gpgs-plugin-support-2.1.0.pom.sha512     |    1 +
 .../gpgs-plugin-support-2.1.0.pom.sha512.meta      |    9 +
 .../2.1.0/gpgs-plugin-support-2.1.0.srcaar         |  Bin 0 -> 31938 bytes
 .../2.1.0/gpgs-plugin-support-2.1.0.srcaar.md5     |    1 +
 .../gpgs-plugin-support-2.1.0.srcaar.md5.meta      |    9 +
 .../2.1.0/gpgs-plugin-support-2.1.0.srcaar.meta    |    9 +
 .../2.1.0/gpgs-plugin-support-2.1.0.srcaar.sha1    |    1 +
 .../gpgs-plugin-support-2.1.0.srcaar.sha1.meta     |    9 +
 .../2.1.0/gpgs-plugin-support-2.1.0.srcaar.sha256  |    1 +
 .../gpgs-plugin-support-2.1.0.srcaar.sha256.meta   |    9 +
 .../2.1.0/gpgs-plugin-support-2.1.0.srcaar.sha512  |    1 +
 .../gpgs-plugin-support-2.1.0.srcaar.sha512.meta   |    9 +
 .../games/gpgs-plugin-support/maven-metadata.xml   |   13 +
 .../gpgs-plugin-support/maven-metadata.xml.md5     |    1 +
 .../maven-metadata.xml.md5.meta                    |    9 +
 .../gpgs-plugin-support/maven-metadata.xml.meta    |    9 +
 .../gpgs-plugin-support/maven-metadata.xml.sha1    |    1 +
 .../maven-metadata.xml.sha1.meta                   |    9 +
 .../gpgs-plugin-support/maven-metadata.xml.sha256  |    1 +
 .../maven-metadata.xml.sha256.meta                 |    9 +
 .../gpgs-plugin-support/maven-metadata.xml.sha512  |    1 +
 .../maven-metadata.xml.sha512.meta                 |    9 +
 .../Editor/template-AndroidManifest.txt            |   27 +
 .../Editor/template-AndroidManifest.txt.meta       |   10 +
 .../Editor/template-Constants.txt                  |   29 +
 .../Editor/template-Constants.txt.meta             |   10 +
 .../Editor/template-GameInfo.txt                   |   71 +
 .../Editor/template-GameInfo.txt.meta              |   10 +
 .../com.google.play.games/Proguard.meta            |    8 +
 .../com.google.play.games/Proguard/games.txt       |   20 +
 .../com.google.play.games/Proguard/games.txt.meta  |    9 +
 .../com.google.play.games/Runtime.meta             |    8 +
 .../Runtime/Google.Play.Games.asmdef               |    7 +
 .../Runtime/Google.Play.Games.asmdef.meta          |   10 +
 .../com.google.play.games/Runtime/Scripts.meta     |    8 +
 .../Runtime/Scripts/BasicApi.meta                  |    5 +
 .../Runtime/Scripts/BasicApi/Achievement.cs        |  201 +++
 .../Runtime/Scripts/BasicApi/Achievement.cs.meta   |   14 +
 .../Runtime/Scripts/BasicApi/AuthResponse.cs       |  104 ++
 .../Runtime/Scripts/BasicApi/AuthResponse.cs.meta  |   13 +
 .../Runtime/Scripts/BasicApi/AuthScope.cs          |  102 ++
 .../Runtime/Scripts/BasicApi/AuthScope.cs.meta     |   13 +
 .../Runtime/Scripts/BasicApi/CommonStatusCodes.cs  |  100 ++
 .../Scripts/BasicApi/CommonStatusCodes.cs.meta     |   14 +
 .../Runtime/Scripts/BasicApi/CommonTypes.cs        |  214 +++
 .../Runtime/Scripts/BasicApi/CommonTypes.cs.meta   |   14 +
 .../Runtime/Scripts/BasicApi/DummyClient.cs        |  495 +++++++
 .../Runtime/Scripts/BasicApi/DummyClient.cs.meta   |   14 +
 .../Runtime/Scripts/BasicApi/Events.meta           |    9 +
 .../Runtime/Scripts/BasicApi/Events/Event.cs       |   53 +
 .../Runtime/Scripts/BasicApi/Events/Event.cs.meta  |   14 +
 .../Runtime/Scripts/BasicApi/Events/IEvent.cs      |   60 +
 .../Runtime/Scripts/BasicApi/Events/IEvent.cs.meta |   14 +
 .../Scripts/BasicApi/Events/IEventsClient.cs       |   60 +
 .../Scripts/BasicApi/Events/IEventsClient.cs.meta  |   14 +
 .../Runtime/Scripts/BasicApi/IPlayGamesClient.cs   |  407 ++++++
 .../Scripts/BasicApi/IPlayGamesClient.cs.meta      |   14 +
 .../Scripts/BasicApi/LeaderboardScoreData.cs       |  174 +++
 .../Scripts/BasicApi/LeaderboardScoreData.cs.meta  |   14 +
 .../Runtime/Scripts/BasicApi/Nearby.meta           |    9 +
 .../Scripts/BasicApi/Nearby/AdvertisingResult.cs   |   67 +
 .../BasicApi/Nearby/AdvertisingResult.cs.meta      |   14 +
 .../Scripts/BasicApi/Nearby/ConnectionRequest.cs   |   61 +
 .../BasicApi/Nearby/ConnectionRequest.cs.meta      |   14 +
 .../Scripts/BasicApi/Nearby/ConnectionResponse.cs  |  174 +++
 .../BasicApi/Nearby/ConnectionResponse.cs.meta     |   14 +
 .../BasicApi/Nearby/DummyNearbyConnectionClient.cs |  176 +++
 .../Nearby/DummyNearbyConnectionClient.cs.meta     |   14 +
 .../Scripts/BasicApi/Nearby/EndpointDetails.cs     |   67 +
 .../BasicApi/Nearby/EndpointDetails.cs.meta        |   14 +
 .../BasicApi/Nearby/INearbyConnectionClient.cs     |  177 +++
 .../Nearby/INearbyConnectionClient.cs.meta         |   14 +
 .../Nearby/NearbyConnectionConfiguration.cs        |   91 ++
 .../Nearby/NearbyConnectionConfiguration.cs.meta   |   14 +
 .../Runtime/Scripts/BasicApi/Player.cs             |   39 +
 .../Runtime/Scripts/BasicApi/Player.cs.meta        |   13 +
 .../Runtime/Scripts/BasicApi/PlayerProfile.cs      |   35 +
 .../Runtime/Scripts/BasicApi/PlayerProfile.cs.meta |   13 +
 .../Runtime/Scripts/BasicApi/PlayerStats.cs        |  268 ++++
 .../Runtime/Scripts/BasicApi/PlayerStats.cs.meta   |   14 +
 .../Runtime/Scripts/BasicApi/RecallAccess.cs       |   57 +
 .../Runtime/Scripts/BasicApi/RecallAccess.cs.meta  |   13 +
 .../Runtime/Scripts/BasicApi/SavedGame.meta        |    9 +
 .../Scripts/BasicApi/SavedGame/ISavedGameClient.cs |  379 ++++++
 .../BasicApi/SavedGame/ISavedGameClient.cs.meta    |   14 +
 .../BasicApi/SavedGame/ISavedGameMetadata.cs       |   77 ++
 .../BasicApi/SavedGame/ISavedGameMetadata.cs.meta  |   14 +
 .../BasicApi/SavedGame/SavedGameMetadataUpdate.cs  |  160 +++
 .../SavedGame/SavedGameMetadataUpdate.cs.meta      |   14 +
 .../Runtime/Scripts/BasicApi/ScorePageToken.cs     |  112 ++
 .../Scripts/BasicApi/ScorePageToken.cs.meta        |   14 +
 .../Scripts/BasicApi/SignInInteractivity.cs        |   29 +
 .../Scripts/BasicApi/SignInInteractivity.cs.meta   |   14 +
 .../Runtime/Scripts/BasicApi/SignInStatus.cs       |   17 +
 .../Runtime/Scripts/BasicApi/SignInStatus.cs.meta  |   14 +
 .../Runtime/Scripts/GameInfo.cs                    |   71 +
 .../Runtime/Scripts/GameInfo.cs.meta               |   14 +
 .../Runtime/Scripts/ISocialPlatform.meta           |    5 +
 .../ISocialPlatform/PlayGamesAchievement.cs        |  371 +++++
 .../ISocialPlatform/PlayGamesAchievement.cs.meta   |   14 +
 .../ISocialPlatform/PlayGamesLeaderboard.cs        |  303 +++++
 .../ISocialPlatform/PlayGamesLeaderboard.cs.meta   |   14 +
 .../Scripts/ISocialPlatform/PlayGamesLocalUser.cs  |  227 ++++
 .../ISocialPlatform/PlayGamesLocalUser.cs.meta     |   14 +
 .../Scripts/ISocialPlatform/PlayGamesPlatform.cs   | 1404 +++++++++++++++++++
 .../ISocialPlatform/PlayGamesPlatform.cs.meta      |   14 +
 .../Scripts/ISocialPlatform/PlayGamesScore.cs      |  149 +++
 .../Scripts/ISocialPlatform/PlayGamesScore.cs.meta |   14 +
 .../ISocialPlatform/PlayGamesUserProfile.cs        |  299 +++++
 .../ISocialPlatform/PlayGamesUserProfile.cs.meta   |   14 +
 .../Runtime/Scripts/OurUtils.meta                  |    5 +
 .../Runtime/Scripts/OurUtils/Logger.cs             |   92 ++
 .../Runtime/Scripts/OurUtils/Logger.cs.meta        |   14 +
 .../Runtime/Scripts/OurUtils/Misc.cs               |  100 ++
 .../Runtime/Scripts/OurUtils/Misc.cs.meta          |   14 +
 .../Runtime/Scripts/OurUtils/NearbyHelperObject.cs |  104 ++
 .../Scripts/OurUtils/NearbyHelperObject.cs.meta    |   14 +
 .../Runtime/Scripts/OurUtils/PlatformUtils.cs      |   42 +
 .../Runtime/Scripts/OurUtils/PlatformUtils.cs.meta |   14 +
 .../Scripts/OurUtils/PlayGamesHelperObject.cs      |  222 +++
 .../Scripts/OurUtils/PlayGamesHelperObject.cs.meta |   14 +
 .../Runtime/Scripts/Platforms.meta                 |    5 +
 .../Runtime/Scripts/Platforms/Android.meta         |    9 +
 .../Scripts/Platforms/Android/AndroidClient.cs     | 1128 ++++++++++++++++
 .../Platforms/Android/AndroidClient.cs.meta        |   14 +
 .../Platforms/Android/AndroidEventsClient.cs       |  136 ++
 .../Platforms/Android/AndroidEventsClient.cs.meta  |   14 +
 .../Platforms/Android/AndroidHelperFragment.cs     |  223 ++++
 .../Android/AndroidHelperFragment.cs.meta          |   14 +
 .../Platforms/Android/AndroidJavaConverter.cs      |  165 +++
 .../Platforms/Android/AndroidJavaConverter.cs.meta |   14 +
 .../Android/AndroidNearbyConnectionClient.cs       |  443 ++++++
 .../Android/AndroidNearbyConnectionClient.cs.meta  |   14 +
 .../Platforms/Android/AndroidSavedGameClient.cs    |  526 ++++++++
 .../Android/AndroidSavedGameClient.cs.meta         |   14 +
 .../Platforms/Android/AndroidSnapshotMetadata.cs   |   90 ++
 .../Android/AndroidSnapshotMetadata.cs.meta        |   14 +
 .../Scripts/Platforms/Android/AndroidTaskUtils.cs  |  111 ++
 .../Platforms/Android/AndroidTaskUtils.cs.meta     |   14 +
 .../Platforms/NearbyConnectionClientFactory.cs     |   41 +
 .../NearbyConnectionClientFactory.cs.meta          |   14 +
 .../Scripts/Platforms/PlayGamesClientFactory.cs    |   44 +
 .../Platforms/PlayGamesClientFactory.cs.meta       |   14 +
 .../Runtime/Scripts/PluginVersion.cs               |   26 +
 .../Runtime/Scripts/PluginVersion.cs.meta          |   14 +
 .../com.google.play.games/current-build.meta       |    8 +
 .../GooglePlayGamesPlugin-2.0.0.unitypackage.meta  |    9 +
 .../com.google.play.games/package.json             |   11 +
 .../com.google.play.games/package.json.meta        |   10 +
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |  116 +-
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |  120 +-
 Supermarkert Run/Assets/Objetos/New_Model.meta     |    8 +
 .../Assets/Objetos/New_Model/Escoba.blend.meta     |  110 ++
 .../Assets/Objetos/New_Model/Escoba.fbx.meta       |  110 ++
 .../Objetos/New_Model/Estante_escobas.blend.meta   |  110 ++
 .../Objetos/New_Model/Estante_escobas.fbx.meta     |  110 ++
 .../Estantes_escoba_con_escobas.blend.meta         |  110 ++
 .../New_Model/Estantes_escoba_con_escobas.fbx.meta |  110 ++
 .../GooglePlayGamesManifest.androidlib.meta        |  143 ++
 .../AndroidManifest.xml                            |   27 +
 .../project.properties                             |    2 +
 .../Plugins/Android/gradleTemplate.properties      |    8 +
 .../Plugins/Android/gradleTemplate.properties.meta |    7 +
 .../Assets/Plugins/Android/mainTemplate.gradle     |   61 +
 .../Plugins/Android/mainTemplate.gradle.meta       |    7 +
 .../Assets/Plugins/Android/settingsTemplate.gradle |   30 +
 .../Plugins/Android/settingsTemplate.gradle.meta   |    7 +
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |   14 +
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |   14 +
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |   14 +
 .../Assets/Scenes/Menu_principal.unity             |    4 +-
 .../Car Supermarkert/Liviano/Liviano3.asset        |    2 +-
 .../Car Supermarkert/Liviano/Liviano4.asset        |    2 +-
 .../Car Supermarkert/Liviano/Liviano5.asset        |    2 +-
 .../Scripts/Car Supermarkert/Mediano/Mediano.asset |    2 +-
 .../Car Supermarkert/Mediano/Mediano3.asset        |    2 +-
 .../Car Supermarkert/Mediano/Mediano4.asset        |    2 +-
 .../Car Supermarkert/Mediano/Mediano5.asset        |    2 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado.asset   |    2 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado3.asset  |    2 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado4.asset  |    2 +-
 .../Scripts/Car Supermarkert/Pesado/Pesado5.asset  |    2 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |  146 +-
 .../Assets/Scripts/Juego/Gameplay/Tiempo.cs        |    2 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |    2 +-
 .../Assets/Scripts/Juego/Menu/Animacion_Carga.cs   |   19 -
 .../Scripts/Jugador/Camara_Objetos_Desaparecer.cs  |   52 +
 .../Jugador/Camara_Objetos_Desaparecer.cs.meta     |    2 +
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |    4 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |    4 +-
 Supermarkert Run/Assets/Scripts/estantes/Area.cs   |   10 +
 .../AndroidResolverDependencies.xml                |   26 +
 .../ProjectSettings/GooglePlayGameSettings.txt     |    9 +
 .../ProjectSettings/GvhProjectSettings.xml         |    9 +
 .../ProjectSettings/ProjectSettings.asset          |    4 +-
 Supermarkert Run/ProjectSettings/TagManager.asset  |    5 +-
 272 files changed, 18090 insertions(+), 211 deletions(-)

=== COMMIT: 09e7273 | Tue May 26 22:46:06 2026 -0600 | Merge branch 'main' of https://github.com/Gatoprogramador888/Supermarker_Run ===
=== COMMIT: ee8ab0b | Thu May 28 13:36:48 2026 -0600 | conexion total con google play games,ahora puedes guardar en privado y en la nube, nuevo pago a los mapas, eliminar la opcion de sombras(estaba en desuso), solucionar que realmente se modifique el lenguaje(anteriormente al inicio se quedaba en ingles hasta modificar se cambiaba al lenguaje que era, ahora ya si se modifica antes y ya se traslada el lenguaje) ===
 ...74.json => index-2026-05-28T19-11-15-0603.json} |     0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  |   Bin 10908 -> 11160 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |     4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |   Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |    26 +-
 ...35.json => index-2026-05-28T19-11-18-0435.json} |     0
 .../3x543z5q/armeabi-v7a/.ninja_deps               |   Bin 10908 -> 11160 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |     4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |   Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |    26 +-
 .../Editor/1.2.182/Google.IOSResolver.dll.meta     |    34 +-
 .../carro.mat                                      |     2 +-
 .../Assets/Plugins/Android/mainTemplate.gradle     |     2 +-
 .../Plugins/Android/mainTemplate.gradle.backup     |    61 +
 .../Android/mainTemplate.gradle.backup.meta}       |     2 +-
 .../Assets/Scenes/Menu_principal.unity             |   451 +-
 .../Car Supermarkert/Liviano/Liviano2.asset        |     2 +-
 .../Assets/Scripts/Juego/Configuraciones/Idioma.cs |    25 +-
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs      |     2 +-
 .../Scripts/Juego/Gameplay/GuardadoEstructura.cs   |    91 +
 .../Juego/Gameplay/GuardadoEstructura.cs.meta      |     2 +
 .../Scripts/Juego/Gameplay/SistemaGuardadoNube.cs  |   297 +
 .../Juego/Gameplay/SistemaGuardadoNube.cs.meta     |     2 +
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   128 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |     2 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |     2 +-
 .../Scripts/Juego/Mapa/Mapa_peque\303\261o.asset"  |     2 +-
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |     8 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |    94 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |     2 +-
 Supermarkert Run/Assets/_Recovery/0 (1).unity      | 38431 ------------------
 Supermarkert Run/Assets/_Recovery/0.unity          | 38722 -------------------
 Supermarkert Run/Assets/_Recovery/0.unity.meta     |     7 -
 .../Assets/textures/Menu/BajarNube.png             |   Bin 0 -> 501667 bytes
 .../Assets/textures/Menu/BajarNube.png.meta        |   130 +
 .../Assets/textures/Menu/GoogleIcon.png            |   Bin 0 -> 13491 bytes
 .../Assets/textures/Menu/GoogleIcon.png.meta       |   130 +
 .../Assets/textures/Menu/subirNube.png             |   Bin 0 -> 372567 bytes
 .../Assets/textures/Menu/subirNube.png.meta        |   130 +
 .../ProjectSettings/ProjectSettings.asset          |    14 +-
 40 files changed, 1494 insertions(+), 77341 deletions(-)

=== COMMIT: 792b449 | Thu May 28 22:37:05 2026 -0600 | fix(save-system): corregir asincronía de la UI y refactorizar serialización de carros ===
 ...03.json => index-2026-05-29T04-24-13-0441.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 11160 -> 11916 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   8 +--
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 +++----
 ...35.json => index-2026-05-29T04-24-15-0782.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 11160 -> 11916 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   8 +--
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 +++----
 .../Scripts/Juego/Configuraciones/Calidad.cs       |   5 +-
 .../Assets/Scripts/Juego/Configuraciones/Idioma.cs |  27 -------
 .../Scripts/Juego/Gameplay/GuardadoEstructura.cs   |  24 ++++++-
 .../Scripts/Juego/Gameplay/SistemaGuardadoNube.cs  |  80 +++++++++++++++------
 Supermarkert Run/Packages/manifest.json            |   1 +
 Supermarkert Run/Packages/packages-lock.json       |   7 ++
 .../ProjectSettings/ProjectSettings.asset          |   4 +-
 17 files changed, 127 insertions(+), 89 deletions(-)

=== COMMIT: 8e3c7ff | Fri May 29 16:33:23 2026 -0600 | Cambiar el google play console hacia un archivo y colocar ventana emergente en android y notificar cuando se subio o no la informacion de un jugador ===
 ...41.json => index-2026-05-29T17-51-41-0265.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 11916 -> 12924 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 ++--
 ...82.json => index-2026-05-29T17-51-44-0836.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 11916 -> 12924 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 ++--
 .../Scripts/Juego/Configuraciones/Notificacion.cs  |  25 ++++
 .../Juego/Configuraciones/Notificacion.cs.meta     |   2 +
 .../Scripts/Juego/Gameplay/GuardadoEstructura.cs   |  61 +++++----
 .../Scripts/Juego/Gameplay/SistemaGuardadoNube.cs  | 139 ++++++++-------------
 .../ProjectSettings/ProjectSettings.asset          |   4 +-
 15 files changed, 142 insertions(+), 157 deletions(-)

=== COMMIT: d20b5b8 | Sat May 30 22:59:41 2026 -0600 | feat: corregir persistencia en la nube e integrar AdMob con alertas multiidioma ===
 .../Editor/1.2.182/Google.IOSResolver.dll          |  Bin 74240 -> 0 bytes
 .../Editor/1.2.182/Google.IOSResolver.dll.meta     |   62 -
 .../Editor/{1.2.182.meta => 1.2.187.meta}          |    2 +-
 .../Editor/1.2.187/Google.IOSResolver.dll          |  Bin 0 -> 85504 bytes
 .../Editor/1.2.187/Google.IOSResolver.dll.meta     |   32 +
 .../{1.2.182 => 1.2.187}/Google.JarResolver.dll    |  Bin 364032 -> 364544 bytes
 .../Google.JarResolver.dll.meta                    |    6 +-
 .../Google.PackageManagerResolver.dll              |  Bin 74240 -> 74240 bytes
 .../Google.PackageManagerResolver.dll.meta         |    6 +-
 .../Google.VersionHandlerImpl.dll                  |  Bin 119296 -> 119296 bytes
 .../Google.VersionHandlerImpl.dll.meta             |    6 +-
 .../ExternalDependencyManager/Editor/CHANGELOG.md  |   24 +
 .../Editor/CHANGELOG.md.meta                       |    4 +-
 .../Editor/Google.VersionHandler.dll.meta          |    4 +-
 .../ExternalDependencyManager/Editor/LICENSE.meta  |    4 +-
 .../ExternalDependencyManager/Editor/README.md     |   47 +-
 .../Editor/README.md.meta                          |    4 +-
 ...dependency-manager_version-1.2.182_manifest.txt |   13 -
 ...dependency-manager_version-1.2.187_manifest.txt |   13 +
 ...ency-manager_version-1.2.187_manifest.txt.meta} |    6 +-
 Supermarkert Run/Assets/GoogleMobileAds.meta       |    8 +
 .../Assets/GoogleMobileAds/CHANGELOG.md            | 1556 ++++++++++++++++++++
 .../Assets/GoogleMobileAds/CHANGELOG.md.meta       |   81 +
 .../Assets/GoogleMobileAds/Editor.meta             |    8 +
 .../Editor/AndroidBuildPreProcessor.cs             |  259 ++++
 .../Editor/AndroidBuildPreProcessor.cs.meta        |    7 +
 .../GoogleMobileAds/Editor/BuildPreProcessor.cs    |   55 +
 .../Editor/BuildPreProcessor.cs.meta               |   17 +
 .../GoogleMobileAds/Editor/EditorLocalization.cs   |  172 +++
 .../Editor/EditorLocalization.cs.meta              |   17 +
 .../Editor/EditorLocalizationData.cs               |   11 +
 .../Editor/EditorLocalizationData.cs.meta          |   17 +
 .../GoogleMobileAds/Editor/EditorPathUtils.cs      |   57 +
 .../GoogleMobileAds/Editor/EditorPathUtils.cs.meta |   17 +
 .../Editor/GoogleMobileAds.Editor.asmdef           |   20 +
 .../Editor/GoogleMobileAds.Editor.asmdef.meta      |   12 +
 .../Editor/GoogleMobileAdsDependencies.xml         |   27 +
 .../Editor/GoogleMobileAdsDependencies.xml.meta    |   12 +
 .../Editor/GoogleMobileAdsSKAdNetworkItems.xml     |   56 +
 .../GoogleMobileAdsSKAdNetworkItems.xml.meta       |   12 +
 .../Editor/GoogleMobileAdsSettings.cs              |  158 ++
 .../Editor/GoogleMobileAdsSettings.cs.meta         |   17 +
 .../Editor/GoogleMobileAdsSettingsEditor.cs        |  235 +++
 .../Editor/GoogleMobileAdsSettingsEditor.cs.meta   |   17 +
 .../Editor/GoogleUmpDependencies.xml               |   16 +
 .../Editor/GoogleUmpDependencies.xml.meta          |   12 +
 .../GoogleMobileAds/Editor/GradleProcessor.cs      |  157 ++
 .../GoogleMobileAds/Editor/GradleProcessor.cs.meta |   17 +
 .../GoogleMobileAds/Editor/ManifestProcessor.cs    |  249 ++++
 .../Editor/ManifestProcessor.cs.meta               |   17 +
 .../GoogleMobileAds/Editor/PListProcessor.cs       |  232 +++
 .../GoogleMobileAds/Editor/PListProcessor.cs.meta  |   17 +
 .../Assets/GoogleMobileAds/Editor/Resources.meta   |    8 +
 .../Editor/Resources/PlaceholderAds.meta           |    8 +
 .../Editor/Resources/PlaceholderAds/AdImages.meta  |    8 +
 .../Resources/PlaceholderAds/AdImages/1024x768.png |  Bin 0 -> 206289 bytes
 .../PlaceholderAds/AdImages/1024x768.png.meta      |  103 ++
 .../Resources/PlaceholderAds/AdImages/300x250.png  |  Bin 0 -> 46644 bytes
 .../PlaceholderAds/AdImages/300x250.png.meta       |  103 ++
 .../Resources/PlaceholderAds/AdImages/320x100.png  |  Bin 0 -> 27345 bytes
 .../PlaceholderAds/AdImages/320x100.png.meta       |  103 ++
 .../Resources/PlaceholderAds/AdImages/320x480.png  |  Bin 0 -> 64507 bytes
 .../PlaceholderAds/AdImages/320x480.png.meta       |  103 ++
 .../Resources/PlaceholderAds/AdImages/320x50.png   |  Bin 0 -> 14916 bytes
 .../PlaceholderAds/AdImages/320x50.png.meta        |  103 ++
 .../Resources/PlaceholderAds/AdImages/468x60.png   |  Bin 0 -> 20218 bytes
 .../PlaceholderAds/AdImages/468x60.png.meta        |  103 ++
 .../Resources/PlaceholderAds/AdImages/480x320.png  |  Bin 0 -> 67392 bytes
 .../PlaceholderAds/AdImages/480x320.png.meta       |  103 ++
 .../Resources/PlaceholderAds/AdImages/728x90.png   |  Bin 0 -> 32942 bytes
 .../PlaceholderAds/AdImages/728x90.png.meta        |  103 ++
 .../Resources/PlaceholderAds/AdImages/768x1024.png |  Bin 0 -> 181896 bytes
 .../PlaceholderAds/AdImages/768x1024.png.meta      |  103 ++
 .../PlaceholderAds/AdImages/AdInspectorHome.png    |  Bin 0 -> 33310 bytes
 .../AdImages/AdInspectorHome.png.meta              |  131 ++
 .../Resources/PlaceholderAds/AdInspector.meta      |    8 +
 .../PlaceholderAds/AdInspector/768x1024.prefab     |  504 +++++++
 .../AdInspector/768x1024.prefab.meta               |   12 +
 .../Editor/Resources/PlaceholderAds/AppOpen.meta   |    8 +
 .../PlaceholderAds/AppOpen/1024x768.prefab         |  472 ++++++
 .../PlaceholderAds/AppOpen/1024x768.prefab.meta    |   12 +
 .../PlaceholderAds/AppOpen/768x1024.prefab         |  472 ++++++
 .../PlaceholderAds/AppOpen/768x1024.prefab.meta    |   12 +
 .../Editor/Resources/PlaceholderAds/Banners.meta   |    8 +
 .../PlaceholderAds/Banners/ADAPTIVE.prefab         |  292 ++++
 .../PlaceholderAds/Banners/ADAPTIVE.prefab.meta    |   13 +
 .../Resources/PlaceholderAds/Banners/BANNER.prefab |  217 +++
 .../PlaceholderAds/Banners/BANNER.prefab.meta      |   13 +
 .../Resources/PlaceholderAds/Banners/CENTER.prefab |  292 ++++
 .../PlaceholderAds/Banners/CENTER.prefab.meta      |   13 +
 .../PlaceholderAds/Banners/FULL_BANNER.prefab      |  217 +++
 .../PlaceholderAds/Banners/FULL_BANNER.prefab.meta |   13 +
 .../PlaceholderAds/Banners/LARGE_BANNER.prefab     |  217 +++
 .../Banners/LARGE_BANNER.prefab.meta               |   13 +
 .../PlaceholderAds/Banners/LEADERBOARD.prefab      |  217 +++
 .../PlaceholderAds/Banners/LEADERBOARD.prefab.meta |   13 +
 .../PlaceholderAds/Banners/MEDIUM_RECTANGLE.prefab |  217 +++
 .../Banners/MEDIUM_RECTANGLE.prefab.meta           |   13 +
 .../PlaceholderAds/Banners/SMART_BANNER.prefab     |  292 ++++
 .../Banners/SMART_BANNER.prefab.meta               |   13 +
 .../Resources/PlaceholderAds/Interstitials.meta    |    8 +
 .../PlaceholderAds/Interstitials/1024x768.prefab   |  472 ++++++
 .../Interstitials/1024x768.prefab.meta             |   13 +
 .../PlaceholderAds/Interstitials/768x1024.prefab   |  472 ++++++
 .../Interstitials/768x1024.prefab.meta             |   13 +
 .../Editor/Resources/PlaceholderAds/Rewarded.meta  |    8 +
 .../PlaceholderAds/Rewarded/1024x768.prefab        |  581 ++++++++
 .../PlaceholderAds/Rewarded/1024x768.prefab.meta   |   13 +
 .../PlaceholderAds/Rewarded/768x1024.prefab        |  547 +++++++
 .../PlaceholderAds/Rewarded/768x1024.prefab.meta   |   13 +
 .../GoogleMobileAds/Editor/Resources/Ump.meta      |    8 +
 .../Editor/Resources/Ump/ConsentForm.png           |  Bin 0 -> 239390 bytes
 .../Editor/Resources/Ump/ConsentForm.png.meta      |  135 ++
 .../Editor/Resources/Ump/ConsentForm.prefab        |  525 +++++++
 .../Editor/Resources/Ump/ConsentForm.prefab.meta   |   12 +
 .../Assets/GoogleMobileAds/Editor/Utils.cs         |  115 ++
 .../Assets/GoogleMobileAds/Editor/Utils.cs.meta    |   17 +
 .../gma_settings_editor_localization_data.json     |  100 ++
 ...gma_settings_editor_localization_data.json.meta |   12 +
 .../GoogleMobileAds/GoogleMobileAds.Android.dll    |  Bin 0 -> 112640 bytes
 .../GoogleMobileAds.Android.dll.meta               |   81 +
 .../GoogleMobileAds/GoogleMobileAds.Common.dll     |  Bin 0 -> 37376 bytes
 .../GoogleMobileAds.Common.dll.meta                |   11 +
 .../GoogleMobileAds/GoogleMobileAds.Core.dll       |  Bin 0 -> 14336 bytes
 .../GoogleMobileAds/GoogleMobileAds.Core.dll.meta  |   11 +
 .../GoogleMobileAds.Ump.Android.dll                |  Bin 0 -> 14848 bytes
 .../GoogleMobileAds.Ump.Android.dll.meta           |   81 +
 .../GoogleMobileAds/GoogleMobileAds.Ump.Unity.dll  |  Bin 0 -> 9728 bytes
 .../GoogleMobileAds.Ump.Unity.dll.meta             |   81 +
 .../Assets/GoogleMobileAds/GoogleMobileAds.Ump.dll |  Bin 0 -> 9728 bytes
 .../GoogleMobileAds/GoogleMobileAds.Ump.dll.meta   |   11 +
 .../GoogleMobileAds/GoogleMobileAds.Ump.iOS.dll    |  Bin 0 -> 11776 bytes
 .../GoogleMobileAds.Ump.iOS.dll.meta               |   81 +
 .../GoogleMobileAds/GoogleMobileAds.Unity.dll      |  Bin 0 -> 41472 bytes
 .../GoogleMobileAds/GoogleMobileAds.Unity.dll.meta |   81 +
 .../Assets/GoogleMobileAds/GoogleMobileAds.dll     |  Bin 0 -> 45568 bytes
 .../GoogleMobileAds/GoogleMobileAds.dll.meta       |   11 +
 .../Assets/GoogleMobileAds/GoogleMobileAds.iOS.dll |  Bin 0 -> 97792 bytes
 .../GoogleMobileAds/GoogleMobileAds.iOS.dll.meta   |   81 +
 .../GoogleMobileAds_version-11.2.0_manifest.txt    |   80 +
 ...oogleMobileAds_version-11.2.0_manifest.txt.meta |   10 +
 Supermarkert Run/Assets/GoogleMobileAds/LICENSE    |  202 +++
 .../Assets/GoogleMobileAds/LICENSE.meta            |   81 +
 Supermarkert Run/Assets/GoogleMobileAds/link.xml   |   18 +
 .../Assets/GoogleMobileAds/link.xml.meta           |   11 +
 .../Android/GoogleMobileAdsPlugin.androidlib.meta  |    2 +
 .../AndroidManifest.xml                            |   14 +
 .../next_gen_exclusions.gradle                     |    4 +
 .../next_gen_resolution_strategy.gradle            |    6 +
 .../packaging_options.gradle                       |    5 +
 .../project.properties                             |    2 +
 .../Plugins/Android/googlemobileads-unity.aar      |  Bin 0 -> 240379 bytes
 .../Plugins/Android/googlemobileads-unity.aar.meta |   81 +
 .../Assets/Plugins/Android/mainTemplate.gradle     |    4 +
 .../Assets/Plugins/Android/settingsTemplate.gradle |    3 +
 Supermarkert Run/Assets/Plugins/iOS.meta           |    8 +
 .../Assets/Plugins/iOS/GADUAdNetworkExtras.h       |   10 +
 .../Assets/Plugins/iOS/GADUAdNetworkExtras.h.meta  |   81 +
 .../Assets/Plugins/iOS/NativeTemplates.meta        |    8 +
 .../iOS/NativeTemplates/GADTMediumTemplateView.xib |  192 +++
 .../GADTMediumTemplateView.xib.meta                |   81 +
 .../iOS/NativeTemplates/GADTSmallTemplateView.xib  |  119 ++
 .../NativeTemplates/GADTSmallTemplateView.xib.meta |   81 +
 .../Assets/Plugins/iOS/unity-plugin-library.a      |  Bin 0 -> 3266144 bytes
 .../Assets/Plugins/iOS/unity-plugin-library.a.meta |   81 +
 .../Assets/Scenes/Menu_principal.unity             |   13 +
 .../Assets/Scripts/Juego/Anuncios.meta             |    8 +
 .../Assets/Scripts/Juego/Anuncios/Anuncios.cs      |  132 ++
 .../Assets/Scripts/Juego/Anuncios/Anuncios.cs.meta |    2 +
 .../Scripts/Juego/Configuraciones/Notificacion.cs  |   63 +-
 .../Scripts/Juego/Gameplay/SistemaGuardadoNube.cs  |   37 +-
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |   28 +-
 .../AndroidResolverDependencies.xml                |    4 +
 173 files changed, 13408 insertions(+), 110 deletions(-)

=== COMMIT: a576819 | Sun May 31 00:56:35 2026 -0600 | Agregar anuncios en modo developer y cuando sea deploy para evitar problemas con google ===
 .../.cmake/api/v1/query/client-agp/cache-v2        |    0
 .../.cmake/api/v1/query/client-agp/cmakeFiles-v1   |    0
 .../.cmake/api/v1/query/client-agp/codemodel-v2    |    0
 .../v1/reply/cache-v2-572482f0639564aedb9f.json    | 1415 ++++++++++++++++++++
 .../reply/cmakeFiles-v1-ecb46cfac28f8107f158.json  |  810 +++++++++++
 .../reply/codemodel-v2-915e7f491c06baf450cf.json   |   87 ++
 .../directory-.-Debug-d0094a50bb2071803777.json    |   14 +
 ...ory-FramePacing-Debug-7f9c8865fd027a154c90.json |   14 +
 .../v1/reply/index-2026-05-31T05-47-30-0756.json   |   92 ++
 ...t-swappywrapper-Debug-7e6b2f469a28fa4189b7.json |  174 +++
 .../.utmp/Debug/6w55202m/arm64-v8a/.ninja_deps     |  Bin 0 -> 10656 bytes
 .../.utmp/Debug/6w55202m/arm64-v8a/.ninja_log      |    3 +
 .../.utmp/Debug/6w55202m/arm64-v8a/CMakeCache.txt  |  415 ++++++
 .../3.22.1-g37088a8-dirty/CMakeCCompiler.cmake     |   72 +
 .../3.22.1-g37088a8-dirty/CMakeCXXCompiler.cmake   |   83 ++
 .../CMakeDetermineCompilerABI_C.bin                |  Bin 0 -> 8064 bytes
 .../CMakeDetermineCompilerABI_CXX.bin              |  Bin 0 -> 8184 bytes
 .../3.22.1-g37088a8-dirty/CMakeSystem.cmake        |   15 +
 .../CompilerIdC/CMakeCCompilerId.c                 |  803 +++++++++++
 .../CompilerIdC/CMakeCCompilerId.o                 |  Bin 0 -> 6016 bytes
 .../CompilerIdCXX/CMakeCXXCompilerId.cpp           |  791 +++++++++++
 .../CompilerIdCXX/CMakeCXXCompilerId.o             |  Bin 0 -> 6032 bytes
 .../6w55202m/arm64-v8a/CMakeFiles/CMakeOutput.log  |  262 ++++
 .../arm64-v8a/CMakeFiles/TargetDirectories.txt     |    5 +
 .../arm64-v8a/CMakeFiles/cmake.check_cache         |    1 +
 .../6w55202m/arm64-v8a/CMakeFiles/rules.ninja      |   64 +
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 0 -> 175472 bytes
 .../arm64-v8a/FramePacing/cmake_install.cmake      |   44 +
 .../arm64-v8a/additional_project_files.txt         |    1 +
 .../6w55202m/arm64-v8a/android_gradle_build.json   |   39 +
 .../arm64-v8a/android_gradle_build_mini.json       |   28 +
 .../.utmp/Debug/6w55202m/arm64-v8a/build.ninja     |  190 +++
 .../Debug/6w55202m/arm64-v8a/build_file_index.txt  |    2 +
 .../Debug/6w55202m/arm64-v8a/cmake_install.cmake   |   60 +
 .../Debug/6w55202m/arm64-v8a/compile_commands.json |    7 +
 .../6w55202m/arm64-v8a/compile_commands.json.bin   |  Bin 0 -> 1578 bytes
 .../6w55202m/arm64-v8a/configure_fingerprint.bin   |   28 +
 .../arm64-v8a/metadata_generation_command.txt      |   21 +
 .../Debug/6w55202m/arm64-v8a/prefab_config.json    |    7 +
 .../6w55202m/arm64-v8a/symbol_folder_index.txt     |    1 +
 .../.cmake/api/v1/query/client-agp/cache-v2        |    0
 .../.cmake/api/v1/query/client-agp/cmakeFiles-v1   |    0
 .../.cmake/api/v1/query/client-agp/codemodel-v2    |    0
 .../v1/reply/cache-v2-9295e58a097147b74831.json    | 1415 ++++++++++++++++++++
 .../reply/cmakeFiles-v1-fea5641b268aa508f036.json  |  810 +++++++++++
 .../reply/codemodel-v2-6c4ab1dab9d5ffd1a03a.json   |   87 ++
 .../directory-.-Debug-d0094a50bb2071803777.json    |   14 +
 ...ory-FramePacing-Debug-7f9c8865fd027a154c90.json |   14 +
 .../v1/reply/index-2026-05-31T05-48-37-0697.json   |   92 ++
 ...t-swappywrapper-Debug-965384d226409dd54e43.json |  174 +++
 .../.utmp/Debug/6w55202m/armeabi-v7a/.ninja_deps   |  Bin 0 -> 10656 bytes
 .../.utmp/Debug/6w55202m/armeabi-v7a/.ninja_log    |    3 +
 .../Debug/6w55202m/armeabi-v7a/CMakeCache.txt      |  415 ++++++
 .../3.22.1-g37088a8-dirty/CMakeCCompiler.cmake     |   72 +
 .../3.22.1-g37088a8-dirty/CMakeCXXCompiler.cmake   |   83 ++
 .../CMakeDetermineCompilerABI_C.bin                |  Bin 0 -> 6168 bytes
 .../CMakeDetermineCompilerABI_CXX.bin              |  Bin 0 -> 6296 bytes
 .../3.22.1-g37088a8-dirty/CMakeSystem.cmake        |   15 +
 .../CompilerIdC/CMakeCCompilerId.c                 |  803 +++++++++++
 .../CompilerIdC/CMakeCCompilerId.o                 |  Bin 0 -> 4116 bytes
 .../CompilerIdCXX/CMakeCXXCompilerId.cpp           |  791 +++++++++++
 .../CompilerIdCXX/CMakeCXXCompilerId.o             |  Bin 0 -> 4152 bytes
 .../armeabi-v7a/CMakeFiles/CMakeOutput.log         |  264 ++++
 .../armeabi-v7a/CMakeFiles/TargetDirectories.txt   |    5 +
 .../armeabi-v7a/CMakeFiles/cmake.check_cache       |    1 +
 .../6w55202m/armeabi-v7a/CMakeFiles/rules.ninja    |   64 +
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 0 -> 139156 bytes
 .../armeabi-v7a/FramePacing/cmake_install.cmake    |   44 +
 .../armeabi-v7a/additional_project_files.txt       |    1 +
 .../6w55202m/armeabi-v7a/android_gradle_build.json |   39 +
 .../armeabi-v7a/android_gradle_build_mini.json     |   28 +
 .../.utmp/Debug/6w55202m/armeabi-v7a/build.ninja   |  190 +++
 .../6w55202m/armeabi-v7a/build_file_index.txt      |    2 +
 .../Debug/6w55202m/armeabi-v7a/cmake_install.cmake |   60 +
 .../6w55202m/armeabi-v7a/compile_commands.json     |    7 +
 .../6w55202m/armeabi-v7a/compile_commands.json.bin |  Bin 0 -> 1619 bytes
 .../6w55202m/armeabi-v7a/configure_fingerprint.bin |   28 +
 .../armeabi-v7a/metadata_generation_command.txt    |   21 +
 .../Debug/6w55202m/armeabi-v7a/prefab_config.json  |    7 +
 .../6w55202m/armeabi-v7a/symbol_folder_index.txt   |    1 +
 Supermarkert Run/.utmp/Debug/6w55202m/hash_key.txt |   28 +
 .../games-frame-pacingConfig.cmake                 |   18 +
 .../games-frame-pacingConfig.cmake                 |   18 +
 ...65.json => index-2026-05-31T06-50-34-0991.json} |    0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  |  Bin 12924 -> 13176 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |    4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |   26 +-
 ...36.json => index-2026-05-31T06-50-54-0713.json} |    0
 .../3x543z5q/armeabi-v7a/.ninja_deps               |  Bin 12924 -> 13176 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |    4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |   26 +-
 .../tools/debug/arm64-v8a/compile_commands.json    |    7 +
 .../tools/debug/armeabi-v7a/compile_commands.json  |    7 +
 .../Assets/GoogleMobileAds/Resources.meta          |    8 +
 .../Resources/GoogleMobileAdsSettings.asset        |   24 +
 .../Resources/GoogleMobileAdsSettings.asset.meta   |    8 +
 .../Assets/Scripts/Juego/Anuncios/Anuncios.cs      |    5 +-
 .../ProjectSettings/ProjectSettings.asset          |    4 +-
 100 files changed, 11252 insertions(+), 33 deletions(-)

=== COMMIT: 649c508 | Sun May 31 19:16:13 2026 -0600 | Refactorizar idioma para hacerlo mas seguro, y agregar buildStructs en clases que ocupan sus clases, solucionar bug de anuncios que no permitia abrir la app ===
 ...91.json => index-2026-05-31T19-21-36-0087.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 13176 -> 13428 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 ++---
 ...13.json => index-2026-05-31T19-21-41-0802.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 13176 -> 13428 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 ++---
 .../Resources/GoogleMobileAdsSettings.asset        |   2 +-
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     |  30 ++++-
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |   2 +-
 Supermarkert Run/Assets/Objetos/Muerte 1.prefab    |  24 +++-
 .../Carrito_aleatorio.prefab                       |   4 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |  21 +++-
 .../AndroidManifest.xml                            |  20 ++--
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |  36 ------
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  36 ------
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  36 ------
 .../Assets/Scenes/Menu_principal.unity             | 129 ++++++++++++++++++++-
 .../Assets/Scripts/Car Supermarkert/Car.cs         |   4 +-
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |  10 +-
 .../Car Supermarkert/Get_Content_Car.cs.meta       |   2 +-
 .../Scripts/Car Supermarkert/Personalizacion.cs    |  28 +++--
 .../Assets/Scripts/Juego/Anuncios/Anuncios.cs      |  12 +-
 .../Scripts/Juego/Configuraciones/Calidad.cs       |  29 +----
 .../Assets/Scripts/Juego/Configuraciones/Idioma.cs | 105 +++++++----------
 .../Scripts/Juego/Gameplay/SistemaGuardadoNube.cs  |   2 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   4 +-
 .../Juego/Gameplay/Sistema_Guardado.cs.meta        |   2 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |   2 +-
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |   8 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  17 ++-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   4 +-
 .../Assets/Scripts/Jugador/Seleccion_Carrito.cs    |   9 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |  19 ++-
 .../ProjectSettings/ProjectSettings.asset          |   4 +-
 38 files changed, 358 insertions(+), 303 deletions(-)

=== COMMIT: c7dcd82 | Mon Jun 1 23:08:45 2026 -0600 | Nuevos iconos en la UI, nuevo fondo de menu, nueva pantalla de carga, agregar anuncios en el x2 de ganar para darle doble dinero si ve el anuncio ===
 ...87.json => index-2026-06-02T05-01-57-0301.json} |     0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  |   Bin 13428 -> 13680 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |     4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |   Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |    26 +-
 ...02.json => index-2026-06-02T05-02-01-0569.json} |     0
 .../3x543z5q/armeabi-v7a/.ninja_deps               |   Bin 13428 -> 13680 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |     4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |   Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |    26 +-
 Supermarkert Run/Assets/Objetos/Decoracion.meta    |     8 +
 .../Decoracion/ImagenSupermercadoDecoracion.png    |   Bin 0 -> 6050 bytes
 .../ImagenSupermercadoDecoracion.png.meta          |   130 +
 .../Objetos/Decoracion/SupermercadoDecoracion.obj  |   630 +
 .../Decoracion/SupermercadoDecoracion.obj.meta     |   115 +
 .../Assets/Objetos/Decoracion/defaultMat.mat       |   139 +
 .../Assets/Objetos/Decoracion/defaultMat.mat.meta  |     8 +
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     |    20 +-
 Supermarkert Run/Assets/Objetos/Muerte 1.prefab    |    26 +-
 .../carro.mat                                      |     2 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |    64 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |    13 -
 .../Assets/Scenes/Menu_principal.unity             | 51313 +++++++------------
 .../Menu_principal/NavMesh-NavMesh Surface.asset   |   Bin 30148 -> 18752 bytes
 .../Assets/Scripts/Juego/Configuraciones/Idioma.cs |     2 +-
 .../Assets/Scripts/Juego/Menu/Animacion_Carga.cs   |    93 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |     7 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |     3 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |    15 +
 .../Assets/shader/celshadding/celshaddingPiso.mat  |    12 +-
 Supermarkert Run/Assets/textures/NewUI.meta        |     8 +
 .../textures/NewUI/kenney_background-elements.meta |     8 +
 .../NewUI/kenney_background-elements/Donate.url    |     2 +
 .../kenney_background-elements/Donate.url.meta     |     7 +
 .../NewUI/kenney_background-elements/Facebook.url  |     2 +
 .../kenney_background-elements/Facebook.url.meta   |     7 +
 .../NewUI/kenney_background-elements/License.txt   |    22 +
 .../kenney_background-elements/License.txt.meta    |     7 +
 .../NewUI/kenney_background-elements/PNG.meta      |     8 +
 .../NewUI/kenney_background-elements/PNG/Flat.meta |     8 +
 .../kenney_background-elements/PNG/Flat/castle.png |   Bin 0 -> 2263 bytes
 .../PNG/Flat/castle.png.meta                       |   130 +
 .../PNG/Flat/castle_wall.png                       |   Bin 0 -> 1911 bytes
 .../PNG/Flat/castle_wall.png.meta                  |   130 +
 .../kenney_background-elements/PNG/Flat/cloud1.png |   Bin 0 -> 1529 bytes
 .../PNG/Flat/cloud1.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/cloud2.png |   Bin 0 -> 1541 bytes
 .../PNG/Flat/cloud2.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/cloud3.png |   Bin 0 -> 1410 bytes
 .../PNG/Flat/cloud3.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/cloud4.png |   Bin 0 -> 1658 bytes
 .../PNG/Flat/cloud4.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/cloud5.png |   Bin 0 -> 1837 bytes
 .../PNG/Flat/cloud5.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/cloud6.png |   Bin 0 -> 1951 bytes
 .../PNG/Flat/cloud6.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/cloud7.png |   Bin 0 -> 1520 bytes
 .../PNG/Flat/cloud7.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/cloud8.png |   Bin 0 -> 1431 bytes
 .../PNG/Flat/cloud8.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/cloud9.png |   Bin 0 -> 1466 bytes
 .../PNG/Flat/cloud9.png.meta                       |   130 +
 .../PNG/Flat/clouds1.png                           |   Bin 0 -> 4661 bytes
 .../PNG/Flat/clouds1.png.meta                      |   130 +
 .../PNG/Flat/clouds2.png                           |   Bin 0 -> 4771 bytes
 .../PNG/Flat/clouds2.png.meta                      |   130 +
 .../kenney_background-elements/PNG/Flat/fence.png  |   Bin 0 -> 1252 bytes
 .../PNG/Flat/fence.png.meta                        |   130 +
 .../PNG/Flat/fence_piece.png                       |   Bin 0 -> 961 bytes
 .../PNG/Flat/fence_piece.png.meta                  |   130 +
 .../kenney_background-elements/PNG/Flat/grass1.png |   Bin 0 -> 408 bytes
 .../PNG/Flat/grass1.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/grass2.png |   Bin 0 -> 480 bytes
 .../PNG/Flat/grass2.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/hills1.png |   Bin 0 -> 2577 bytes
 .../PNG/Flat/hills1.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/hills2.png |   Bin 0 -> 2582 bytes
 .../PNG/Flat/hills2.png.meta                       |   130 +
 .../PNG/Flat/house_front_short.png                 |   Bin 0 -> 617 bytes
 .../PNG/Flat/house_front_short.png.meta            |   130 +
 .../PNG/Flat/house_front_tall.png                  |   Bin 0 -> 699 bytes
 .../PNG/Flat/house_front_tall.png.meta             |   130 +
 .../PNG/Flat/house_side_short.png                  |   Bin 0 -> 605 bytes
 .../PNG/Flat/house_side_short.png.meta             |   130 +
 .../PNG/Flat/house_side_tall.png                   |   Bin 0 -> 731 bytes
 .../PNG/Flat/house_side_tall.png.meta              |   130 +
 .../PNG/Flat/mountain1.png                         |   Bin 0 -> 2434 bytes
 .../PNG/Flat/mountain1.png.meta                    |   130 +
 .../PNG/Flat/mountain2.png                         |   Bin 0 -> 1969 bytes
 .../PNG/Flat/mountain2.png.meta                    |   130 +
 .../PNG/Flat/mountain3.png                         |   Bin 0 -> 3031 bytes
 .../PNG/Flat/mountain3.png.meta                    |   130 +
 .../PNG/Flat/piramid.png                           |   Bin 0 -> 1475 bytes
 .../PNG/Flat/piramid.png.meta                      |   130 +
 .../PNG/Flat/pointy_mountains.png                  |   Bin 0 -> 3691 bytes
 .../PNG/Flat/pointy_mountains.png.meta             |   130 +
 .../kenney_background-elements/PNG/Flat/sky.png    |   Bin 0 -> 5762 bytes
 .../PNG/Flat/sky.png.meta                          |   130 +
 .../kenney_background-elements/PNG/Flat/temple.png |   Bin 0 -> 1039 bytes
 .../PNG/Flat/temple.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tower.png  |   Bin 0 -> 1145 bytes
 .../PNG/Flat/tower.png.meta                        |   130 +
 .../kenney_background-elements/PNG/Flat/tree01.png |   Bin 0 -> 2018 bytes
 .../PNG/Flat/tree01.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree02.png |   Bin 0 -> 1717 bytes
 .../PNG/Flat/tree02.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree03.png |   Bin 0 -> 844 bytes
 .../PNG/Flat/tree03.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree04.png |   Bin 0 -> 1732 bytes
 .../PNG/Flat/tree04.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree05.png |   Bin 0 -> 968 bytes
 .../PNG/Flat/tree05.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree06.png |   Bin 0 -> 738 bytes
 .../PNG/Flat/tree06.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree07.png |   Bin 0 -> 1917 bytes
 .../PNG/Flat/tree07.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree08.png |   Bin 0 -> 970 bytes
 .../PNG/Flat/tree08.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree09.png |   Bin 0 -> 922 bytes
 .../PNG/Flat/tree09.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree10.png |   Bin 0 -> 946 bytes
 .../PNG/Flat/tree10.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree11.png |   Bin 0 -> 2176 bytes
 .../PNG/Flat/tree11.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree12.png |   Bin 0 -> 1749 bytes
 .../PNG/Flat/tree12.png.meta                       |   130 +
 .../kenney_background-elements/PNG/Flat/tree13.png |   Bin 0 -> 1789 bytes
 .../PNG/Flat/tree13.png.meta                       |   130 +
 .../NewUI/kenney_background-elements/PNG/Thumbs.db |   Bin 0 -> 57344 bytes
 .../kenney_background-elements/PNG/Thumbs.db.meta  |     7 +
 .../PNG/castle_beige.png                           |   Bin 0 -> 4190 bytes
 .../PNG/castle_beige.png.meta                      |   130 +
 .../kenney_background-elements/PNG/castle_grey.png |   Bin 0 -> 4182 bytes
 .../PNG/castle_grey.png.meta                       |   130 +
 .../kenney_background-elements/PNG/castle_wall.png |   Bin 0 -> 3189 bytes
 .../PNG/castle_wall.png.meta                       |   130 +
 .../kenney_background-elements/PNG/cloud1.png      |   Bin 0 -> 2137 bytes
 .../kenney_background-elements/PNG/cloud1.png.meta |   130 +
 .../kenney_background-elements/PNG/cloud2.png      |   Bin 0 -> 2177 bytes
 .../kenney_background-elements/PNG/cloud2.png.meta |   130 +
 .../kenney_background-elements/PNG/cloud3.png      |   Bin 0 -> 1969 bytes
 .../kenney_background-elements/PNG/cloud3.png.meta |   130 +
 .../kenney_background-elements/PNG/cloud4.png      |   Bin 0 -> 2345 bytes
 .../kenney_background-elements/PNG/cloud4.png.meta |   130 +
 .../kenney_background-elements/PNG/cloud5.png      |   Bin 0 -> 2542 bytes
 .../kenney_background-elements/PNG/cloud5.png.meta |   130 +
 .../kenney_background-elements/PNG/cloud6.png      |   Bin 0 -> 2704 bytes
 .../kenney_background-elements/PNG/cloud6.png.meta |   130 +
 .../kenney_background-elements/PNG/cloud7.png      |   Bin 0 -> 2140 bytes
 .../kenney_background-elements/PNG/cloud7.png.meta |   130 +
 .../kenney_background-elements/PNG/cloud8.png      |   Bin 0 -> 2122 bytes
 .../kenney_background-elements/PNG/cloud8.png.meta |   130 +
 .../kenney_background-elements/PNG/cloud9.png      |   Bin 0 -> 1971 bytes
 .../kenney_background-elements/PNG/cloud9.png.meta |   130 +
 .../NewUI/kenney_background-elements/PNG/fence.png |   Bin 0 -> 1535 bytes
 .../kenney_background-elements/PNG/fence.png.meta  |   130 +
 .../kenney_background-elements/PNG/fence_piece.png |   Bin 0 -> 1191 bytes
 .../PNG/fence_piece.png.meta                       |   130 +
 .../kenney_background-elements/PNG/grass1.png      |   Bin 0 -> 412 bytes
 .../kenney_background-elements/PNG/grass1.png.meta |   130 +
 .../kenney_background-elements/PNG/grass2.png      |   Bin 0 -> 413 bytes
 .../kenney_background-elements/PNG/grass2.png.meta |   130 +
 .../kenney_background-elements/PNG/grass3.png      |   Bin 0 -> 488 bytes
 .../kenney_background-elements/PNG/grass3.png.meta |   130 +
 .../kenney_background-elements/PNG/grass4.png      |   Bin 0 -> 492 bytes
 .../kenney_background-elements/PNG/grass4.png.meta |   130 +
 .../kenney_background-elements/PNG/grass5.png      |   Bin 0 -> 409 bytes
 .../kenney_background-elements/PNG/grass5.png.meta |   130 +
 .../kenney_background-elements/PNG/grass6.png      |   Bin 0 -> 484 bytes
 .../kenney_background-elements/PNG/grass6.png.meta |   130 +
 .../PNG/house_beige_front.png                      |   Bin 0 -> 792 bytes
 .../PNG/house_beige_front.png.meta                 |   130 +
 .../PNG/house_beige_side.png                       |   Bin 0 -> 1019 bytes
 .../PNG/house_beige_side.png.meta                  |   130 +
 .../PNG/house_grey_front.png                       |   Bin 0 -> 925 bytes
 .../PNG/house_grey_front.png.meta                  |   130 +
 .../PNG/house_grey_side.png                        |   Bin 0 -> 1172 bytes
 .../PNG/house_grey_side.png.meta                   |   130 +
 .../kenney_background-elements/PNG/moon_full.png   |   Bin 0 -> 1195 bytes
 .../PNG/moon_full.png.meta                         |   130 +
 .../kenney_background-elements/PNG/moon_half.png   |   Bin 0 -> 1147 bytes
 .../PNG/moon_half.png.meta                         |   130 +
 .../kenney_background-elements/PNG/piramid.png     |   Bin 0 -> 2179 bytes
 .../PNG/piramid.png.meta                           |   130 +
 .../NewUI/kenney_background-elements/PNG/sun.png   |   Bin 0 -> 1255 bytes
 .../kenney_background-elements/PNG/sun.png.meta    |   130 +
 .../kenney_background-elements/PNG/temple.png      |   Bin 0 -> 2779 bytes
 .../kenney_background-elements/PNG/temple.png.meta |   130 +
 .../kenney_background-elements/PNG/tower_beige.png |   Bin 0 -> 1497 bytes
 .../PNG/tower_beige.png.meta                       |   130 +
 .../kenney_background-elements/PNG/tower_grey.png  |   Bin 0 -> 1477 bytes
 .../PNG/tower_grey.png.meta                        |   130 +
 .../kenney_background-elements/PNG/tree01.png      |   Bin 0 -> 2615 bytes
 .../kenney_background-elements/PNG/tree01.png.meta |   130 +
 .../kenney_background-elements/PNG/tree02.png      |   Bin 0 -> 2592 bytes
 .../kenney_background-elements/PNG/tree02.png.meta |   130 +
 .../kenney_background-elements/PNG/tree03.png      |   Bin 0 -> 2594 bytes
 .../kenney_background-elements/PNG/tree03.png.meta |   130 +
 .../kenney_background-elements/PNG/tree04.png      |   Bin 0 -> 3048 bytes
 .../kenney_background-elements/PNG/tree04.png.meta |   130 +
 .../kenney_background-elements/PNG/tree05.png      |   Bin 0 -> 2509 bytes
 .../kenney_background-elements/PNG/tree05.png.meta |   130 +
 .../kenney_background-elements/PNG/tree06.png      |   Bin 0 -> 3287 bytes
 .../kenney_background-elements/PNG/tree06.png.meta |   130 +
 .../kenney_background-elements/PNG/tree07.png      |   Bin 0 -> 2568 bytes
 .../kenney_background-elements/PNG/tree07.png.meta |   130 +
 .../kenney_background-elements/PNG/tree08.png      |   Bin 0 -> 947 bytes
 .../kenney_background-elements/PNG/tree08.png.meta |   130 +
 .../kenney_background-elements/PNG/tree09.png      |   Bin 0 -> 947 bytes
 .../kenney_background-elements/PNG/tree09.png.meta |   130 +
 .../kenney_background-elements/PNG/tree10.png      |   Bin 0 -> 2225 bytes
 .../kenney_background-elements/PNG/tree10.png.meta |   130 +
 .../kenney_background-elements/PNG/tree11.png      |   Bin 0 -> 2226 bytes
 .../kenney_background-elements/PNG/tree11.png.meta |   130 +
 .../kenney_background-elements/PNG/tree12.png      |   Bin 0 -> 2656 bytes
 .../kenney_background-elements/PNG/tree12.png.meta |   130 +
 .../kenney_background-elements/PNG/tree13.png      |   Bin 0 -> 1102 bytes
 .../kenney_background-elements/PNG/tree13.png.meta |   130 +
 .../kenney_background-elements/PNG/tree14.png      |   Bin 0 -> 1100 bytes
 .../kenney_background-elements/PNG/tree14.png.meta |   130 +
 .../kenney_background-elements/PNG/tree15.png      |   Bin 0 -> 1133 bytes
 .../kenney_background-elements/PNG/tree15.png.meta |   130 +
 .../kenney_background-elements/PNG/tree16.png      |   Bin 0 -> 967 bytes
 .../kenney_background-elements/PNG/tree16.png.meta |   130 +
 .../kenney_background-elements/PNG/tree17.png      |   Bin 0 -> 739 bytes
 .../kenney_background-elements/PNG/tree17.png.meta |   130 +
 .../kenney_background-elements/PNG/tree18.png      |   Bin 0 -> 1133 bytes
 .../kenney_background-elements/PNG/tree18.png.meta |   130 +
 .../kenney_background-elements/PNG/tree19.png      |   Bin 0 -> 861 bytes
 .../kenney_background-elements/PNG/tree19.png.meta |   130 +
 .../kenney_background-elements/PNG/tree20.png      |   Bin 0 -> 2589 bytes
 .../kenney_background-elements/PNG/tree20.png.meta |   130 +
 .../kenney_background-elements/PNG/tree21.png      |   Bin 0 -> 2595 bytes
 .../kenney_background-elements/PNG/tree21.png.meta |   130 +
 .../kenney_background-elements/PNG/tree22.png      |   Bin 0 -> 3057 bytes
 .../kenney_background-elements/PNG/tree22.png.meta |   130 +
 .../kenney_background-elements/PNG/tree23.png      |   Bin 0 -> 1388 bytes
 .../kenney_background-elements/PNG/tree23.png.meta |   130 +
 .../kenney_background-elements/PNG/tree24.png      |   Bin 0 -> 1406 bytes
 .../kenney_background-elements/PNG/tree24.png.meta |   130 +
 .../kenney_background-elements/PNG/tree25.png      |   Bin 0 -> 1352 bytes
 .../kenney_background-elements/PNG/tree25.png.meta |   130 +
 .../kenney_background-elements/PNG/tree26.png      |   Bin 0 -> 1368 bytes
 .../kenney_background-elements/PNG/tree26.png.meta |   130 +
 .../kenney_background-elements/PNG/tree27.png      |   Bin 0 -> 1361 bytes
 .../kenney_background-elements/PNG/tree27.png.meta |   130 +
 .../kenney_background-elements/PNG/tree28.png      |   Bin 0 -> 1378 bytes
 .../kenney_background-elements/PNG/tree28.png.meta |   130 +
 .../kenney_background-elements/PNG/tree29.png      |   Bin 0 -> 2219 bytes
 .../kenney_background-elements/PNG/tree29.png.meta |   130 +
 .../kenney_background-elements/PNG/tree30.png      |   Bin 0 -> 2196 bytes
 .../kenney_background-elements/PNG/tree30.png.meta |   130 +
 .../kenney_background-elements/PNG/tree31.png      |   Bin 0 -> 2679 bytes
 .../kenney_background-elements/PNG/tree31.png.meta |   130 +
 .../kenney_background-elements/PNG/tree32.png      |   Bin 0 -> 2762 bytes
 .../kenney_background-elements/PNG/tree32.png.meta |   130 +
 .../kenney_background-elements/PNG/tree33.png      |   Bin 0 -> 3650 bytes
 .../kenney_background-elements/PNG/tree33.png.meta |   130 +
 .../kenney_background-elements/PNG/tree34.png      |   Bin 0 -> 2575 bytes
 .../kenney_background-elements/PNG/tree34.png.meta |   130 +
 .../kenney_background-elements/PNG/tree35.png      |   Bin 0 -> 3391 bytes
 .../kenney_background-elements/PNG/tree35.png.meta |   130 +
 .../NewUI/kenney_background-elements/Preview.png   |   Bin 0 -> 100153 bytes
 .../kenney_background-elements/Preview.png.meta    |   130 +
 .../NewUI/kenney_background-elements/Sample.png    |   Bin 0 -> 64496 bytes
 .../kenney_background-elements/Sample.png.meta     |   130 +
 .../NewUI/kenney_background-elements/Samples.meta  |     8 +
 .../kenney_background-elements/Samples/Thumbs.db   |   Bin 0 -> 72192 bytes
 .../Samples/Thumbs.db.meta                         |     7 +
 .../Samples/colored_castle.png                     |   Bin 0 -> 23487 bytes
 .../Samples/colored_castle.png.meta                |   130 +
 .../Samples/colored_desert.png                     |   Bin 0 -> 16550 bytes
 .../Samples/colored_desert.png.meta                |   130 +
 .../Samples/colored_forest.png                     |   Bin 0 -> 17700 bytes
 .../Samples/colored_forest.png.meta                |   130 +
 .../Samples/colored_talltrees.png                  |   Bin 0 -> 15392 bytes
 .../Samples/colored_talltrees.png.meta             |   130 +
 .../Samples/uncolored_castle.png                   |   Bin 0 -> 19044 bytes
 .../Samples/uncolored_castle.png.meta              |   130 +
 .../Samples/uncolored_desert.png                   |   Bin 0 -> 15462 bytes
 .../Samples/uncolored_desert.png.meta              |   130 +
 .../Samples/uncolored_forest.png                   |   Bin 0 -> 14670 bytes
 .../Samples/uncolored_forest.png.meta              |   130 +
 .../Samples/uncolored_hills.png                    |   Bin 0 -> 11459 bytes
 .../Samples/uncolored_hills.png.meta               |   130 +
 .../Samples/uncolored_peaks.png                    |   Bin 0 -> 14235 bytes
 .../Samples/uncolored_peaks.png.meta               |   130 +
 .../Samples/uncolored_piramids.png                 |   Bin 0 -> 12749 bytes
 .../Samples/uncolored_piramids.png.meta            |   130 +
 .../Samples/uncolored_plain.png                    |   Bin 0 -> 10234 bytes
 .../Samples/uncolored_plain.png.meta               |   130 +
 .../Samples/uncolored_talltrees.png                |   Bin 0 -> 14963 bytes
 .../Samples/uncolored_talltrees.png.meta           |   130 +
 .../kenney_background-elements/Spritesheet.meta    |     8 +
 .../Spritesheet/bgElements_spritesheet.png         |   Bin 0 -> 267699 bytes
 .../Spritesheet/bgElements_spritesheet.png.meta    |   130 +
 .../Spritesheet/bgElements_spritesheet.xml         |   111 +
 .../Spritesheet/bgElements_spritesheet.xml.meta    |     7 +
 .../NewUI/kenney_background-elements/Vector.meta   |     8 +
 .../Vector/bgElements_elements.ai                  |   Bin 0 -> 115932 bytes
 .../Vector/bgElements_elements.ai.meta             |     7 +
 .../Vector/bgElements_elements.svg                 |  2596 +
 .../Vector/bgElements_elements.svg.meta            |    53 +
 .../Vector/bgElements_samples.ai                   |   Bin 0 -> 100707 bytes
 .../Vector/bgElements_samples.ai.meta              |     7 +
 .../Vector/bgElements_samples.svg                  |  1176 +
 .../Vector/bgElements_samples.svg.meta             |    53 +
 .../Assets/textures/NewUI/kenney_game-icons.meta   |     8 +
 .../textures/NewUI/kenney_game-icons/PNG.meta      |     8 +
 .../NewUI/kenney_game-icons/PNG/Black.meta         |     8 +
 .../NewUI/kenney_game-icons/PNG/Black/1x.meta      |     8 +
 .../kenney_game-icons/PNG/Black/1x/arrowDown.png   |   Bin 0 -> 1145 bytes
 .../PNG/Black/1x/arrowDown.png.meta                |   130 +
 .../kenney_game-icons/PNG/Black/1x/arrowLeft.png   |   Bin 0 -> 1134 bytes
 .../PNG/Black/1x/arrowLeft.png.meta                |   130 +
 .../kenney_game-icons/PNG/Black/1x/arrowRight.png  |   Bin 0 -> 1135 bytes
 .../PNG/Black/1x/arrowRight.png.meta               |   130 +
 .../kenney_game-icons/PNG/Black/1x/arrowUp.png     |   Bin 0 -> 1146 bytes
 .../PNG/Black/1x/arrowUp.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/audioOff.png    |   Bin 0 -> 1135 bytes
 .../PNG/Black/1x/audioOff.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/audioOn.png     |   Bin 0 -> 1252 bytes
 .../PNG/Black/1x/audioOn.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/backward.png    |   Bin 0 -> 1148 bytes
 .../PNG/Black/1x/backward.png.meta                 |   130 +
 .../PNG/Black/1x/barsHorizontal.png                |   Bin 0 -> 1071 bytes
 .../PNG/Black/1x/barsHorizontal.png.meta           |   130 +
 .../PNG/Black/1x/barsVertical.png                  |   Bin 0 -> 1067 bytes
 .../PNG/Black/1x/barsVertical.png.meta             |   130 +
 .../kenney_game-icons/PNG/Black/1x/basket.png      |   Bin 0 -> 1244 bytes
 .../kenney_game-icons/PNG/Black/1x/basket.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/button1.png     |   Bin 0 -> 1317 bytes
 .../PNG/Black/1x/button1.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/button2.png     |   Bin 0 -> 1369 bytes
 .../PNG/Black/1x/button2.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/button3.png     |   Bin 0 -> 1380 bytes
 .../PNG/Black/1x/button3.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/buttonA.png     |   Bin 0 -> 1405 bytes
 .../PNG/Black/1x/buttonA.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/buttonB.png     |   Bin 0 -> 1378 bytes
 .../PNG/Black/1x/buttonB.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/buttonL.png     |   Bin 0 -> 1079 bytes
 .../PNG/Black/1x/buttonL.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/buttonL1.png    |   Bin 0 -> 1142 bytes
 .../PNG/Black/1x/buttonL1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/buttonL2.png    |   Bin 0 -> 1201 bytes
 .../PNG/Black/1x/buttonL2.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/buttonR.png     |   Bin 0 -> 1167 bytes
 .../PNG/Black/1x/buttonR.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/buttonR1.png    |   Bin 0 -> 1201 bytes
 .../PNG/Black/1x/buttonR1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/buttonR2.png    |   Bin 0 -> 1230 bytes
 .../PNG/Black/1x/buttonR2.png.meta                 |   130 +
 .../PNG/Black/1x/buttonSelect.png                  |   Bin 0 -> 1247 bytes
 .../PNG/Black/1x/buttonSelect.png.meta             |   130 +
 .../kenney_game-icons/PNG/Black/1x/buttonStart.png |   Bin 0 -> 1266 bytes
 .../PNG/Black/1x/buttonStart.png.meta              |   130 +
 .../kenney_game-icons/PNG/Black/1x/buttonX.png     |   Bin 0 -> 1375 bytes
 .../PNG/Black/1x/buttonX.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/buttonY.png     |   Bin 0 -> 1383 bytes
 .../PNG/Black/1x/buttonY.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/cart.png  |   Bin 0 -> 1229 bytes
 .../kenney_game-icons/PNG/Black/1x/cart.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/1x/checkmark.png   |   Bin 0 -> 1255 bytes
 .../PNG/Black/1x/checkmark.png.meta                |   130 +
 .../kenney_game-icons/PNG/Black/1x/contrast.png    |   Bin 0 -> 1328 bytes
 .../PNG/Black/1x/contrast.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/cross.png |   Bin 0 -> 1239 bytes
 .../kenney_game-icons/PNG/Black/1x/cross.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/door.png  |   Bin 0 -> 1207 bytes
 .../kenney_game-icons/PNG/Black/1x/door.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/down.png  |   Bin 0 -> 1139 bytes
 .../kenney_game-icons/PNG/Black/1x/down.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/1x/downLeft.png    |   Bin 0 -> 1204 bytes
 .../PNG/Black/1x/downLeft.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/downRight.png   |   Bin 0 -> 1208 bytes
 .../PNG/Black/1x/downRight.png.meta                |   130 +
 .../kenney_game-icons/PNG/Black/1x/exclamation.png |   Bin 0 -> 1131 bytes
 .../PNG/Black/1x/exclamation.png.meta              |   130 +
 .../kenney_game-icons/PNG/Black/1x/exitLeft.png    |   Bin 0 -> 1184 bytes
 .../PNG/Black/1x/exitLeft.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/exitRight.png   |   Bin 0 -> 1186 bytes
 .../PNG/Black/1x/exitRight.png.meta                |   130 +
 .../kenney_game-icons/PNG/Black/1x/export.png      |   Bin 0 -> 1152 bytes
 .../kenney_game-icons/PNG/Black/1x/export.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/fastForward.png |   Bin 0 -> 1202 bytes
 .../PNG/Black/1x/fastForward.png.meta              |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/film.png  |   Bin 0 -> 1101 bytes
 .../kenney_game-icons/PNG/Black/1x/film.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/1x/forward.png     |   Bin 0 -> 1153 bytes
 .../PNG/Black/1x/forward.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/gamepad.png     |   Bin 0 -> 1158 bytes
 .../PNG/Black/1x/gamepad.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/gamepad1.png    |   Bin 0 -> 1416 bytes
 .../PNG/Black/1x/gamepad1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/gamepad2.png    |   Bin 0 -> 1431 bytes
 .../PNG/Black/1x/gamepad2.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/gamepad3.png    |   Bin 0 -> 1422 bytes
 .../PNG/Black/1x/gamepad3.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/gamepad4.png    |   Bin 0 -> 1430 bytes
 .../PNG/Black/1x/gamepad4.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/gear.png  |   Bin 0 -> 1512 bytes
 .../kenney_game-icons/PNG/Black/1x/gear.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/home.png  |   Bin 0 -> 1143 bytes
 .../kenney_game-icons/PNG/Black/1x/home.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/1x/import.png      |   Bin 0 -> 1144 bytes
 .../kenney_game-icons/PNG/Black/1x/import.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/information.png |   Bin 0 -> 1163 bytes
 .../PNG/Black/1x/information.png.meta              |   130 +
 .../kenney_game-icons/PNG/Black/1x/joystick.png    |   Bin 0 -> 1134 bytes
 .../PNG/Black/1x/joystick.png.meta                 |   130 +
 .../PNG/Black/1x/joystickLeft.png                  |   Bin 0 -> 1275 bytes
 .../PNG/Black/1x/joystickLeft.png.meta             |   130 +
 .../PNG/Black/1x/joystickRight.png                 |   Bin 0 -> 1264 bytes
 .../PNG/Black/1x/joystickRight.png.meta            |   130 +
 .../kenney_game-icons/PNG/Black/1x/joystickUp.png  |   Bin 0 -> 1191 bytes
 .../PNG/Black/1x/joystickUp.png.meta               |   130 +
 .../kenney_game-icons/PNG/Black/1x/larger.png      |   Bin 0 -> 1162 bytes
 .../kenney_game-icons/PNG/Black/1x/larger.png.meta |   130 +
 .../PNG/Black/1x/leaderboardsComplex.png           |   Bin 0 -> 1229 bytes
 .../PNG/Black/1x/leaderboardsComplex.png.meta      |   130 +
 .../PNG/Black/1x/leaderboardsSimple.png            |   Bin 0 -> 1040 bytes
 .../PNG/Black/1x/leaderboardsSimple.png.meta       |   130 +
 .../kenney_game-icons/PNG/Black/1x/locked.png      |   Bin 0 -> 1103 bytes
 .../kenney_game-icons/PNG/Black/1x/locked.png.meta |   130 +
 .../PNG/Black/1x/massiveMultiplayer.png            |   Bin 0 -> 1438 bytes
 .../PNG/Black/1x/massiveMultiplayer.png.meta       |   130 +
 .../kenney_game-icons/PNG/Black/1x/medal1.png      |   Bin 0 -> 1335 bytes
 .../kenney_game-icons/PNG/Black/1x/medal1.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/medal2.png      |   Bin 0 -> 1422 bytes
 .../kenney_game-icons/PNG/Black/1x/medal2.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/menuGrid.png    |   Bin 0 -> 1090 bytes
 .../PNG/Black/1x/menuGrid.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/menuList.png    |   Bin 0 -> 1099 bytes
 .../PNG/Black/1x/menuList.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/minus.png |   Bin 0 -> 1049 bytes
 .../kenney_game-icons/PNG/Black/1x/minus.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/mouse.png |   Bin 0 -> 1292 bytes
 .../kenney_game-icons/PNG/Black/1x/mouse.png.meta  |   130 +
 .../kenney_game-icons/PNG/Black/1x/multiplayer.png |   Bin 0 -> 1330 bytes
 .../PNG/Black/1x/multiplayer.png.meta              |   130 +
 .../kenney_game-icons/PNG/Black/1x/musicOff.png    |   Bin 0 -> 1241 bytes
 .../PNG/Black/1x/musicOff.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/musicOn.png     |   Bin 0 -> 1242 bytes
 .../PNG/Black/1x/musicOn.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/next.png  |   Bin 0 -> 1167 bytes
 .../kenney_game-icons/PNG/Black/1x/next.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/open.png  |   Bin 0 -> 1147 bytes
 .../kenney_game-icons/PNG/Black/1x/open.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/pause.png |   Bin 0 -> 1058 bytes
 .../kenney_game-icons/PNG/Black/1x/pause.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/phone.png |   Bin 0 -> 1096 bytes
 .../kenney_game-icons/PNG/Black/1x/phone.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/plus.png  |   Bin 0 -> 1099 bytes
 .../kenney_game-icons/PNG/Black/1x/plus.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/power.png |   Bin 0 -> 1388 bytes
 .../kenney_game-icons/PNG/Black/1x/power.png.meta  |   130 +
 .../kenney_game-icons/PNG/Black/1x/previous.png    |   Bin 0 -> 1165 bytes
 .../PNG/Black/1x/previous.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/question.png    |   Bin 0 -> 1313 bytes
 .../PNG/Black/1x/question.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/1x/return.png      |   Bin 0 -> 1334 bytes
 .../kenney_game-icons/PNG/Black/1x/return.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/rewind.png      |   Bin 0 -> 1196 bytes
 .../kenney_game-icons/PNG/Black/1x/rewind.png.meta |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/save.png  |   Bin 0 -> 1073 bytes
 .../kenney_game-icons/PNG/Black/1x/save.png.meta   |   130 +
 .../PNG/Black/1x/scrollHorizontal.png              |   Bin 0 -> 1242 bytes
 .../PNG/Black/1x/scrollHorizontal.png.meta         |   130 +
 .../PNG/Black/1x/scrollVertical.png                |   Bin 0 -> 1207 bytes
 .../PNG/Black/1x/scrollVertical.png.meta           |   130 +
 .../kenney_game-icons/PNG/Black/1x/share1.png      |   Bin 0 -> 1212 bytes
 .../kenney_game-icons/PNG/Black/1x/share1.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/share2.png      |   Bin 0 -> 1375 bytes
 .../kenney_game-icons/PNG/Black/1x/share2.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/signal1.png     |   Bin 0 -> 1052 bytes
 .../PNG/Black/1x/signal1.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/signal2.png     |   Bin 0 -> 1086 bytes
 .../PNG/Black/1x/signal2.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/signal3.png     |   Bin 0 -> 1091 bytes
 .../PNG/Black/1x/signal3.png.meta                  |   130 +
 .../PNG/Black/1x/singleplayer.png                  |   Bin 0 -> 1310 bytes
 .../PNG/Black/1x/singleplayer.png.meta             |   130 +
 .../kenney_game-icons/PNG/Black/1x/smaller.png     |   Bin 0 -> 1164 bytes
 .../PNG/Black/1x/smaller.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/star.png  |   Bin 0 -> 1309 bytes
 .../kenney_game-icons/PNG/Black/1x/star.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/stop.png  |   Bin 0 -> 1048 bytes
 .../kenney_game-icons/PNG/Black/1x/stop.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/1x/tablet.png      |   Bin 0 -> 1093 bytes
 .../kenney_game-icons/PNG/Black/1x/tablet.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/target.png      |   Bin 0 -> 1428 bytes
 .../kenney_game-icons/PNG/Black/1x/target.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/trashcan.png    |   Bin 0 -> 1104 bytes
 .../PNG/Black/1x/trashcan.png.meta                 |   130 +
 .../PNG/Black/1x/trashcanOpen.png                  |   Bin 0 -> 1223 bytes
 .../PNG/Black/1x/trashcanOpen.png.meta             |   130 +
 .../kenney_game-icons/PNG/Black/1x/trophy.png      |   Bin 0 -> 1144 bytes
 .../kenney_game-icons/PNG/Black/1x/trophy.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/unlocked.png    |   Bin 0 -> 1107 bytes
 .../PNG/Black/1x/unlocked.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/up.png    |   Bin 0 -> 1131 bytes
 .../kenney_game-icons/PNG/Black/1x/up.png.meta     |   130 +
 .../kenney_game-icons/PNG/Black/1x/upLeft.png      |   Bin 0 -> 1169 bytes
 .../kenney_game-icons/PNG/Black/1x/upLeft.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/upRight.png     |   Bin 0 -> 1194 bytes
 .../PNG/Black/1x/upRight.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/video.png |   Bin 0 -> 1254 bytes
 .../kenney_game-icons/PNG/Black/1x/video.png.meta  |   130 +
 .../kenney_game-icons/PNG/Black/1x/warning.png     |   Bin 0 -> 1332 bytes
 .../PNG/Black/1x/warning.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/1x/wrench.png      |   Bin 0 -> 1312 bytes
 .../kenney_game-icons/PNG/Black/1x/wrench.png.meta |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/1x/zoom.png  |   Bin 0 -> 1355 bytes
 .../kenney_game-icons/PNG/Black/1x/zoom.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/1x/zoomDefault.png |   Bin 0 -> 1364 bytes
 .../PNG/Black/1x/zoomDefault.png.meta              |   130 +
 .../kenney_game-icons/PNG/Black/1x/zoomIn.png      |   Bin 0 -> 1371 bytes
 .../kenney_game-icons/PNG/Black/1x/zoomIn.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/1x/zoomOut.png     |   Bin 0 -> 1365 bytes
 .../PNG/Black/1x/zoomOut.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x.meta      |     8 +
 .../kenney_game-icons/PNG/Black/2x/arrowDown.png   |   Bin 0 -> 1418 bytes
 .../PNG/Black/2x/arrowDown.png.meta                |   130 +
 .../kenney_game-icons/PNG/Black/2x/arrowLeft.png   |   Bin 0 -> 1338 bytes
 .../PNG/Black/2x/arrowLeft.png.meta                |   130 +
 .../kenney_game-icons/PNG/Black/2x/arrowRight.png  |   Bin 0 -> 1332 bytes
 .../PNG/Black/2x/arrowRight.png.meta               |   130 +
 .../kenney_game-icons/PNG/Black/2x/arrowUp.png     |   Bin 0 -> 1354 bytes
 .../PNG/Black/2x/arrowUp.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/audioOff.png    |   Bin 0 -> 1358 bytes
 .../PNG/Black/2x/audioOff.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/audioOn.png     |   Bin 0 -> 1664 bytes
 .../PNG/Black/2x/audioOn.png.meta                  |   130 +
 .../PNG/Black/2x/barsHorizontal.png                |   Bin 0 -> 1291 bytes
 .../PNG/Black/2x/barsHorizontal.png.meta           |   130 +
 .../PNG/Black/2x/barsVertical.png                  |   Bin 0 -> 1214 bytes
 .../PNG/Black/2x/barsVertical.png.meta             |   130 +
 .../kenney_game-icons/PNG/Black/2x/button1.png     |   Bin 0 -> 1716 bytes
 .../PNG/Black/2x/button1.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/button2.png     |   Bin 0 -> 1935 bytes
 .../PNG/Black/2x/button2.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/button3.png     |   Bin 0 -> 1925 bytes
 .../PNG/Black/2x/button3.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/buttonA.png     |   Bin 0 -> 1970 bytes
 .../PNG/Black/2x/buttonA.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/buttonB.png     |   Bin 0 -> 1930 bytes
 .../PNG/Black/2x/buttonB.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/buttonL.png     |   Bin 0 -> 1223 bytes
 .../PNG/Black/2x/buttonL.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/buttonL1.png    |   Bin 0 -> 1259 bytes
 .../PNG/Black/2x/buttonL1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/buttonL2.png    |   Bin 0 -> 1440 bytes
 .../PNG/Black/2x/buttonL2.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/buttonR.png     |   Bin 0 -> 1406 bytes
 .../PNG/Black/2x/buttonR.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/buttonR1.png    |   Bin 0 -> 1407 bytes
 .../PNG/Black/2x/buttonR1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/buttonR2.png    |   Bin 0 -> 1528 bytes
 .../PNG/Black/2x/buttonR2.png.meta                 |   130 +
 .../PNG/Black/2x/buttonSelect.png                  |   Bin 0 -> 1687 bytes
 .../PNG/Black/2x/buttonSelect.png.meta             |   130 +
 .../kenney_game-icons/PNG/Black/2x/buttonStart.png |   Bin 0 -> 1641 bytes
 .../PNG/Black/2x/buttonStart.png.meta              |   130 +
 .../kenney_game-icons/PNG/Black/2x/buttonX.png     |   Bin 0 -> 1943 bytes
 .../PNG/Black/2x/buttonX.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/buttonY.png     |   Bin 0 -> 1920 bytes
 .../PNG/Black/2x/buttonY.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/checkmark.png   |   Bin 0 -> 1704 bytes
 .../PNG/Black/2x/checkmark.png.meta                |   130 +
 .../kenney_game-icons/PNG/Black/2x/contrast.png    |   Bin 0 -> 1818 bytes
 .../PNG/Black/2x/contrast.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/cross.png |   Bin 0 -> 1551 bytes
 .../kenney_game-icons/PNG/Black/2x/cross.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/down.png  |   Bin 0 -> 1388 bytes
 .../kenney_game-icons/PNG/Black/2x/down.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/2x/downLeft.png    |   Bin 0 -> 1474 bytes
 .../PNG/Black/2x/downLeft.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/downRight.png   |   Bin 0 -> 1492 bytes
 .../PNG/Black/2x/downRight.png.meta                |   130 +
 .../kenney_game-icons/PNG/Black/2x/exclamation.png |   Bin 0 -> 1359 bytes
 .../PNG/Black/2x/exclamation.png.meta              |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/exit.png  |   Bin 0 -> 1424 bytes
 .../kenney_game-icons/PNG/Black/2x/exit.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/2x/exitLeft.png    |   Bin 0 -> 1392 bytes
 .../PNG/Black/2x/exitLeft.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/exitRight.png   |   Bin 0 -> 1374 bytes
 .../PNG/Black/2x/exitRight.png.meta                |   130 +
 .../kenney_game-icons/PNG/Black/2x/export.png      |   Bin 0 -> 1355 bytes
 .../kenney_game-icons/PNG/Black/2x/export.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/2x/fastForward.png |   Bin 0 -> 1503 bytes
 .../PNG/Black/2x/fastForward.png.meta              |   130 +
 .../kenney_game-icons/PNG/Black/2x/gamepad.png     |   Bin 0 -> 1378 bytes
 .../PNG/Black/2x/gamepad.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/gamepad1.png    |   Bin 0 -> 1943 bytes
 .../PNG/Black/2x/gamepad1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/gamepad2.png    |   Bin 0 -> 2032 bytes
 .../PNG/Black/2x/gamepad2.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/gamepad3.png    |   Bin 0 -> 2018 bytes
 .../PNG/Black/2x/gamepad3.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/gamepad4.png    |   Bin 0 -> 1975 bytes
 .../PNG/Black/2x/gamepad4.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/gear.png  |   Bin 0 -> 2180 bytes
 .../kenney_game-icons/PNG/Black/2x/gear.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/home.png  |   Bin 0 -> 1363 bytes
 .../kenney_game-icons/PNG/Black/2x/home.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/2x/import.png      |   Bin 0 -> 1340 bytes
 .../kenney_game-icons/PNG/Black/2x/import.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/2x/information.png |   Bin 0 -> 1516 bytes
 .../PNG/Black/2x/information.png.meta              |   130 +
 .../kenney_game-icons/PNG/Black/2x/joystick.png    |   Bin 0 -> 1396 bytes
 .../PNG/Black/2x/joystick.png.meta                 |   130 +
 .../PNG/Black/2x/joystickLeft.png                  |   Bin 0 -> 1668 bytes
 .../PNG/Black/2x/joystickLeft.png.meta             |   130 +
 .../PNG/Black/2x/joystickRight.png                 |   Bin 0 -> 1598 bytes
 .../PNG/Black/2x/joystickRight.png.meta            |   130 +
 .../kenney_game-icons/PNG/Black/2x/joystickUp.png  |   Bin 0 -> 1506 bytes
 .../PNG/Black/2x/joystickUp.png.meta               |   130 +
 .../kenney_game-icons/PNG/Black/2x/larger.png      |   Bin 0 -> 1529 bytes
 .../kenney_game-icons/PNG/Black/2x/larger.png.meta |   130 +
 .../PNG/Black/2x/leaderboardsComplex.png           |   Bin 0 -> 1554 bytes
 .../PNG/Black/2x/leaderboardsComplex.png.meta      |   130 +
 .../PNG/Black/2x/leaderboardsSimple.png            |   Bin 0 -> 1139 bytes
 .../PNG/Black/2x/leaderboardsSimple.png.meta       |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/left.png  |   Bin 0 -> 1300 bytes
 .../kenney_game-icons/PNG/Black/2x/left.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/2x/locked.png      |   Bin 0 -> 1317 bytes
 .../kenney_game-icons/PNG/Black/2x/locked.png.meta |   130 +
 .../PNG/Black/2x/massiveMultiplayer.png            |   Bin 0 -> 2054 bytes
 .../PNG/Black/2x/massiveMultiplayer.png.meta       |   130 +
 .../kenney_game-icons/PNG/Black/2x/medal1.png      |   Bin 0 -> 1737 bytes
 .../kenney_game-icons/PNG/Black/2x/medal1.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/2x/medal2.png      |   Bin 0 -> 1980 bytes
 .../kenney_game-icons/PNG/Black/2x/medal2.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/2x/menuGrid.png    |   Bin 0 -> 1310 bytes
 .../PNG/Black/2x/menuGrid.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/menuList.png    |   Bin 0 -> 1302 bytes
 .../PNG/Black/2x/menuList.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/minus.png |   Bin 0 -> 1199 bytes
 .../kenney_game-icons/PNG/Black/2x/minus.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/mouse.png |   Bin 0 -> 1737 bytes
 .../kenney_game-icons/PNG/Black/2x/mouse.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/movie.png |   Bin 0 -> 1276 bytes
 .../kenney_game-icons/PNG/Black/2x/movie.png.meta  |   130 +
 .../kenney_game-icons/PNG/Black/2x/multiplayer.png |   Bin 0 -> 1792 bytes
 .../PNG/Black/2x/multiplayer.png.meta              |   130 +
 .../kenney_game-icons/PNG/Black/2x/musicOff.png    |   Bin 0 -> 1705 bytes
 .../PNG/Black/2x/musicOff.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/musicOn.png     |   Bin 0 -> 1616 bytes
 .../PNG/Black/2x/musicOn.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/next.png  |   Bin 0 -> 1355 bytes
 .../kenney_game-icons/PNG/Black/2x/next.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/open.png  |   Bin 0 -> 1328 bytes
 .../kenney_game-icons/PNG/Black/2x/open.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/pause.png |   Bin 0 -> 1254 bytes
 .../kenney_game-icons/PNG/Black/2x/pause.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/phone.png |   Bin 0 -> 1297 bytes
 .../kenney_game-icons/PNG/Black/2x/phone.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/plus.png  |   Bin 0 -> 1296 bytes
 .../kenney_game-icons/PNG/Black/2x/plus.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/power.png |   Bin 0 -> 1938 bytes
 .../kenney_game-icons/PNG/Black/2x/power.png.meta  |   130 +
 .../kenney_game-icons/PNG/Black/2x/previous.png    |   Bin 0 -> 1351 bytes
 .../PNG/Black/2x/previous.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/question.png    |   Bin 0 -> 1711 bytes
 .../PNG/Black/2x/question.png.meta                 |   130 +
 .../kenney_game-icons/PNG/Black/2x/return.png      |   Bin 0 -> 1819 bytes
 .../kenney_game-icons/PNG/Black/2x/return.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/2x/rewind.png      |   Bin 0 -> 1514 bytes
 .../kenney_game-icons/PNG/Black/2x/rewind.png.meta |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/right.png |   Bin 0 -> 1366 bytes
 .../kenney_game-icons/PNG/Black/2x/right.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/save.png  |   Bin 0 -> 1202 bytes
 .../kenney_game-icons/PNG/Black/2x/save.png.meta   |   130 +
 .../PNG/Black/2x/scrollHorizontal.png              |   Bin 0 -> 1531 bytes
 .../PNG/Black/2x/scrollHorizontal.png.meta         |   130 +
 .../PNG/Black/2x/scrollVertical.png                |   Bin 0 -> 1477 bytes
 .../PNG/Black/2x/scrollVertical.png.meta           |   130 +
 .../kenney_game-icons/PNG/Black/2x/share1.png      |   Bin 0 -> 1490 bytes
 .../kenney_game-icons/PNG/Black/2x/share1.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/2x/share2.png      |   Bin 0 -> 1919 bytes
 .../kenney_game-icons/PNG/Black/2x/share2.png.meta |   130 +
 .../PNG/Black/2x/shoppingBasket.png                |   Bin 0 -> 1690 bytes
 .../PNG/Black/2x/shoppingBasket.png.meta           |   130 +
 .../PNG/Black/2x/shoppingCart.png                  |   Bin 0 -> 1587 bytes
 .../PNG/Black/2x/shoppingCart.png.meta             |   130 +
 .../kenney_game-icons/PNG/Black/2x/siganl1.png     |   Bin 0 -> 1186 bytes
 .../PNG/Black/2x/siganl1.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/signal2.png     |   Bin 0 -> 1265 bytes
 .../PNG/Black/2x/signal2.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/signal3.png     |   Bin 0 -> 1289 bytes
 .../PNG/Black/2x/signal3.png.meta                  |   130 +
 .../PNG/Black/2x/singleplayer.png                  |   Bin 0 -> 1703 bytes
 .../PNG/Black/2x/singleplayer.png.meta             |   130 +
 .../kenney_game-icons/PNG/Black/2x/smaller.png     |   Bin 0 -> 1452 bytes
 .../PNG/Black/2x/smaller.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/star.png  |   Bin 0 -> 1701 bytes
 .../kenney_game-icons/PNG/Black/2x/star.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/stop.png  |   Bin 0 -> 1198 bytes
 .../kenney_game-icons/PNG/Black/2x/stop.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/2x/tablet.png      |   Bin 0 -> 1307 bytes
 .../kenney_game-icons/PNG/Black/2x/tablet.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/2x/target.png      |   Bin 0 -> 2043 bytes
 .../kenney_game-icons/PNG/Black/2x/target.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/2x/trashcan.png    |   Bin 0 -> 1283 bytes
 .../PNG/Black/2x/trashcan.png.meta                 |   130 +
 .../PNG/Black/2x/trashcanOpen.png                  |   Bin 0 -> 1562 bytes
 .../PNG/Black/2x/trashcanOpen.png.meta             |   130 +
 .../kenney_game-icons/PNG/Black/2x/trophy.png      |   Bin 0 -> 1346 bytes
 .../kenney_game-icons/PNG/Black/2x/trophy.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/2x/unlocked.png    |   Bin 0 -> 1316 bytes
 .../PNG/Black/2x/unlocked.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/up.png    |   Bin 0 -> 1342 bytes
 .../kenney_game-icons/PNG/Black/2x/up.png.meta     |   130 +
 .../kenney_game-icons/PNG/Black/2x/upLeft.png      |   Bin 0 -> 1448 bytes
 .../kenney_game-icons/PNG/Black/2x/upLeft.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/2x/upRight.png     |   Bin 0 -> 1453 bytes
 .../PNG/Black/2x/upRight.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/video.png |   Bin 0 -> 1512 bytes
 .../kenney_game-icons/PNG/Black/2x/video.png.meta  |   130 +
 .../kenney_game-icons/PNG/Black/2x/warning.png     |   Bin 0 -> 1819 bytes
 .../PNG/Black/2x/warning.png.meta                  |   130 +
 .../kenney_game-icons/PNG/Black/2x/wrench.png      |   Bin 0 -> 1741 bytes
 .../kenney_game-icons/PNG/Black/2x/wrench.png.meta |   130 +
 .../NewUI/kenney_game-icons/PNG/Black/2x/zoom.png  |   Bin 0 -> 1812 bytes
 .../kenney_game-icons/PNG/Black/2x/zoom.png.meta   |   130 +
 .../kenney_game-icons/PNG/Black/2x/zoomDefault.png |   Bin 0 -> 1898 bytes
 .../PNG/Black/2x/zoomDefault.png.meta              |   130 +
 .../kenney_game-icons/PNG/Black/2x/zoomIn.png      |   Bin 0 -> 1908 bytes
 .../kenney_game-icons/PNG/Black/2x/zoomIn.png.meta |   130 +
 .../kenney_game-icons/PNG/Black/2x/zoomOut.png     |   Bin 0 -> 1824 bytes
 .../PNG/Black/2x/zoomOut.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/White.meta         |     8 +
 .../NewUI/kenney_game-icons/PNG/White/1x.meta      |     8 +
 .../kenney_game-icons/PNG/White/1x/arrowDown.png   |   Bin 0 -> 15114 bytes
 .../PNG/White/1x/arrowDown.png.meta                |   130 +
 .../kenney_game-icons/PNG/White/1x/arrowLeft.png   |   Bin 0 -> 15123 bytes
 .../PNG/White/1x/arrowLeft.png.meta                |   130 +
 .../kenney_game-icons/PNG/White/1x/arrowRight.png  |   Bin 0 -> 15114 bytes
 .../PNG/White/1x/arrowRight.png.meta               |   130 +
 .../kenney_game-icons/PNG/White/1x/arrowUp.png     |   Bin 0 -> 15072 bytes
 .../PNG/White/1x/arrowUp.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/audioOff.png    |   Bin 0 -> 15096 bytes
 .../PNG/White/1x/audioOff.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/audioOn.png     |   Bin 0 -> 15232 bytes
 .../PNG/White/1x/audioOn.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/backward.png    |   Bin 0 -> 15112 bytes
 .../PNG/White/1x/backward.png.meta                 |   130 +
 .../PNG/White/1x/barsHorizontal.png                |   Bin 0 -> 15024 bytes
 .../PNG/White/1x/barsHorizontal.png.meta           |   130 +
 .../PNG/White/1x/barsVertical.png                  |   Bin 0 -> 15020 bytes
 .../PNG/White/1x/barsVertical.png.meta             |   130 +
 .../kenney_game-icons/PNG/White/1x/basket.png      |   Bin 0 -> 15216 bytes
 .../kenney_game-icons/PNG/White/1x/basket.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/button1.png     |   Bin 0 -> 15309 bytes
 .../PNG/White/1x/button1.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/button2.png     |   Bin 0 -> 15381 bytes
 .../PNG/White/1x/button2.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/button3.png     |   Bin 0 -> 15376 bytes
 .../PNG/White/1x/button3.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/buttonA.png     |   Bin 0 -> 15393 bytes
 .../PNG/White/1x/buttonA.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/buttonB.png     |   Bin 0 -> 15381 bytes
 .../PNG/White/1x/buttonB.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/buttonL.png     |   Bin 0 -> 15044 bytes
 .../PNG/White/1x/buttonL.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/buttonL1.png    |   Bin 0 -> 15099 bytes
 .../PNG/White/1x/buttonL1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/buttonL2.png    |   Bin 0 -> 15171 bytes
 .../PNG/White/1x/buttonL2.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/buttonR.png     |   Bin 0 -> 15134 bytes
 .../PNG/White/1x/buttonR.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/buttonR1.png    |   Bin 0 -> 15162 bytes
 .../PNG/White/1x/buttonR1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/buttonR2.png    |   Bin 0 -> 15217 bytes
 .../PNG/White/1x/buttonR2.png.meta                 |   130 +
 .../PNG/White/1x/buttonSelect.png                  |   Bin 0 -> 15204 bytes
 .../PNG/White/1x/buttonSelect.png.meta             |   130 +
 .../kenney_game-icons/PNG/White/1x/buttonStart.png |   Bin 0 -> 15208 bytes
 .../PNG/White/1x/buttonStart.png.meta              |   130 +
 .../kenney_game-icons/PNG/White/1x/buttonX.png     |   Bin 0 -> 15390 bytes
 .../PNG/White/1x/buttonX.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/buttonY.png     |   Bin 0 -> 15396 bytes
 .../PNG/White/1x/buttonY.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/cart.png  |   Bin 0 -> 15190 bytes
 .../kenney_game-icons/PNG/White/1x/cart.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/1x/checkmark.png   |   Bin 0 -> 15290 bytes
 .../PNG/White/1x/checkmark.png.meta                |   130 +
 .../kenney_game-icons/PNG/White/1x/contrast.png    |   Bin 0 -> 15332 bytes
 .../PNG/White/1x/contrast.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/cross.png |   Bin 0 -> 15195 bytes
 .../kenney_game-icons/PNG/White/1x/cross.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/door.png  |   Bin 0 -> 15149 bytes
 .../kenney_game-icons/PNG/White/1x/door.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/down.png  |   Bin 0 -> 15101 bytes
 .../kenney_game-icons/PNG/White/1x/down.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/1x/downLeft.png    |   Bin 0 -> 15164 bytes
 .../PNG/White/1x/downLeft.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/downRight.png   |   Bin 0 -> 15191 bytes
 .../PNG/White/1x/downRight.png.meta                |   130 +
 .../kenney_game-icons/PNG/White/1x/exclamation.png |   Bin 0 -> 15087 bytes
 .../PNG/White/1x/exclamation.png.meta              |   130 +
 .../kenney_game-icons/PNG/White/1x/exitLeft.png    |   Bin 0 -> 15142 bytes
 .../PNG/White/1x/exitLeft.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/exitRight.png   |   Bin 0 -> 15127 bytes
 .../PNG/White/1x/exitRight.png.meta                |   130 +
 .../kenney_game-icons/PNG/White/1x/export.png      |   Bin 0 -> 15091 bytes
 .../kenney_game-icons/PNG/White/1x/export.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/fastForward.png |   Bin 0 -> 15165 bytes
 .../PNG/White/1x/fastForward.png.meta              |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/film.png  |   Bin 0 -> 15062 bytes
 .../kenney_game-icons/PNG/White/1x/film.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/1x/forward.png     |   Bin 0 -> 15117 bytes
 .../PNG/White/1x/forward.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/gamepad.png     |   Bin 0 -> 15118 bytes
 .../PNG/White/1x/gamepad.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/gamepad1.png    |   Bin 0 -> 15394 bytes
 .../PNG/White/1x/gamepad1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/gamepad2.png    |   Bin 0 -> 15414 bytes
 .../PNG/White/1x/gamepad2.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/gamepad3.png    |   Bin 0 -> 15409 bytes
 .../PNG/White/1x/gamepad3.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/gamepad4.png    |   Bin 0 -> 15410 bytes
 .../PNG/White/1x/gamepad4.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/gear.png  |   Bin 0 -> 15475 bytes
 .../kenney_game-icons/PNG/White/1x/gear.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/home.png  |   Bin 0 -> 15069 bytes
 .../kenney_game-icons/PNG/White/1x/home.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/1x/import.png      |   Bin 0 -> 15090 bytes
 .../kenney_game-icons/PNG/White/1x/import.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/information.png |   Bin 0 -> 15121 bytes
 .../PNG/White/1x/information.png.meta              |   130 +
 .../kenney_game-icons/PNG/White/1x/joystick.png    |   Bin 0 -> 15098 bytes
 .../PNG/White/1x/joystick.png.meta                 |   130 +
 .../PNG/White/1x/joystickLeft.png                  |   Bin 0 -> 15239 bytes
 .../PNG/White/1x/joystickLeft.png.meta             |   130 +
 .../PNG/White/1x/joystickRight.png                 |   Bin 0 -> 15215 bytes
 .../PNG/White/1x/joystickRight.png.meta            |   130 +
 .../kenney_game-icons/PNG/White/1x/joystickUp.png  |   Bin 0 -> 15141 bytes
 .../PNG/White/1x/joystickUp.png.meta               |   130 +
 .../kenney_game-icons/PNG/White/1x/larger.png      |   Bin 0 -> 15118 bytes
 .../kenney_game-icons/PNG/White/1x/larger.png.meta |   130 +
 .../PNG/White/1x/leaderboardsComplex.png           |   Bin 0 -> 15191 bytes
 .../PNG/White/1x/leaderboardsComplex.png.meta      |   130 +
 .../PNG/White/1x/leaderboardsSimple.png            |   Bin 0 -> 14998 bytes
 .../PNG/White/1x/leaderboardsSimple.png.meta       |   130 +
 .../kenney_game-icons/PNG/White/1x/locked.png      |   Bin 0 -> 15064 bytes
 .../kenney_game-icons/PNG/White/1x/locked.png.meta |   130 +
 .../PNG/White/1x/massiveMultiplayer.png            |   Bin 0 -> 15409 bytes
 .../PNG/White/1x/massiveMultiplayer.png.meta       |   130 +
 .../kenney_game-icons/PNG/White/1x/medal1.png      |   Bin 0 -> 15281 bytes
 .../kenney_game-icons/PNG/White/1x/medal1.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/medal2.png      |   Bin 0 -> 15374 bytes
 .../kenney_game-icons/PNG/White/1x/medal2.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/menuGrid.png    |   Bin 0 -> 15022 bytes
 .../PNG/White/1x/menuGrid.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/menuList.png    |   Bin 0 -> 15036 bytes
 .../PNG/White/1x/menuList.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/minus.png |   Bin 0 -> 15015 bytes
 .../kenney_game-icons/PNG/White/1x/minus.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/mouse.png |   Bin 0 -> 15266 bytes
 .../kenney_game-icons/PNG/White/1x/mouse.png.meta  |   130 +
 .../kenney_game-icons/PNG/White/1x/multiplayer.png |   Bin 0 -> 15290 bytes
 .../PNG/White/1x/multiplayer.png.meta              |   130 +
 .../kenney_game-icons/PNG/White/1x/musicOff.png    |   Bin 0 -> 15263 bytes
 .../PNG/White/1x/musicOff.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/musicOn.png     |   Bin 0 -> 15197 bytes
 .../PNG/White/1x/musicOn.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/next.png  |   Bin 0 -> 15142 bytes
 .../kenney_game-icons/PNG/White/1x/next.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/open.png  |   Bin 0 -> 15121 bytes
 .../kenney_game-icons/PNG/White/1x/open.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/pause.png |   Bin 0 -> 15015 bytes
 .../kenney_game-icons/PNG/White/1x/pause.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/phone.png |   Bin 0 -> 15047 bytes
 .../kenney_game-icons/PNG/White/1x/phone.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/plus.png  |   Bin 0 -> 15059 bytes
 .../kenney_game-icons/PNG/White/1x/plus.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/power.png |   Bin 0 -> 15372 bytes
 .../kenney_game-icons/PNG/White/1x/power.png.meta  |   130 +
 .../kenney_game-icons/PNG/White/1x/previous.png    |   Bin 0 -> 15125 bytes
 .../PNG/White/1x/previous.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/question.png    |   Bin 0 -> 15265 bytes
 .../PNG/White/1x/question.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/1x/return.png      |   Bin 0 -> 15313 bytes
 .../kenney_game-icons/PNG/White/1x/return.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/rewind.png      |   Bin 0 -> 15153 bytes
 .../kenney_game-icons/PNG/White/1x/rewind.png.meta |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/save.png  |   Bin 0 -> 15040 bytes
 .../kenney_game-icons/PNG/White/1x/save.png.meta   |   130 +
 .../PNG/White/1x/scrollHorizontal.png              |   Bin 0 -> 15153 bytes
 .../PNG/White/1x/scrollHorizontal.png.meta         |   130 +
 .../PNG/White/1x/scrollVertical.png                |   Bin 0 -> 15136 bytes
 .../PNG/White/1x/scrollVertical.png.meta           |   130 +
 .../kenney_game-icons/PNG/White/1x/share1.png      |   Bin 0 -> 15174 bytes
 .../kenney_game-icons/PNG/White/1x/share1.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/share2.png      |   Bin 0 -> 15350 bytes
 .../kenney_game-icons/PNG/White/1x/share2.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/signal1.png     |   Bin 0 -> 15014 bytes
 .../PNG/White/1x/signal1.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/signal2.png     |   Bin 0 -> 15038 bytes
 .../PNG/White/1x/signal2.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/signal3.png     |   Bin 0 -> 15052 bytes
 .../PNG/White/1x/signal3.png.meta                  |   130 +
 .../PNG/White/1x/singleplayer.png                  |   Bin 0 -> 15259 bytes
 .../PNG/White/1x/singleplayer.png.meta             |   130 +
 .../kenney_game-icons/PNG/White/1x/smaller.png     |   Bin 0 -> 15126 bytes
 .../PNG/White/1x/smaller.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/star.png  |   Bin 0 -> 15265 bytes
 .../kenney_game-icons/PNG/White/1x/star.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/stop.png  |   Bin 0 -> 15014 bytes
 .../kenney_game-icons/PNG/White/1x/stop.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/1x/tablet.png      |   Bin 0 -> 15051 bytes
 .../kenney_game-icons/PNG/White/1x/tablet.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/target.png      |   Bin 0 -> 15427 bytes
 .../kenney_game-icons/PNG/White/1x/target.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/trashcan.png    |   Bin 0 -> 15046 bytes
 .../PNG/White/1x/trashcan.png.meta                 |   130 +
 .../PNG/White/1x/trashcanOpen.png                  |   Bin 0 -> 15167 bytes
 .../PNG/White/1x/trashcanOpen.png.meta             |   130 +
 .../kenney_game-icons/PNG/White/1x/trophy.png      |   Bin 0 -> 15094 bytes
 .../kenney_game-icons/PNG/White/1x/trophy.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/unlocked.png    |   Bin 0 -> 15075 bytes
 .../PNG/White/1x/unlocked.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/up.png    |   Bin 0 -> 15058 bytes
 .../kenney_game-icons/PNG/White/1x/up.png.meta     |   130 +
 .../kenney_game-icons/PNG/White/1x/upLeft.png      |   Bin 0 -> 15130 bytes
 .../kenney_game-icons/PNG/White/1x/upLeft.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/upRight.png     |   Bin 0 -> 15168 bytes
 .../PNG/White/1x/upRight.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/video.png |   Bin 0 -> 15174 bytes
 .../kenney_game-icons/PNG/White/1x/video.png.meta  |   130 +
 .../kenney_game-icons/PNG/White/1x/warning.png     |   Bin 0 -> 15315 bytes
 .../PNG/White/1x/warning.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/1x/wrench.png      |   Bin 0 -> 15327 bytes
 .../kenney_game-icons/PNG/White/1x/wrench.png.meta |   130 +
 .../NewUI/kenney_game-icons/PNG/White/1x/zoom.png  |   Bin 0 -> 15329 bytes
 .../kenney_game-icons/PNG/White/1x/zoom.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/1x/zoomDefault.png |   Bin 0 -> 15343 bytes
 .../PNG/White/1x/zoomDefault.png.meta              |   130 +
 .../kenney_game-icons/PNG/White/1x/zoomIn.png      |   Bin 0 -> 15343 bytes
 .../kenney_game-icons/PNG/White/1x/zoomIn.png.meta |   130 +
 .../kenney_game-icons/PNG/White/1x/zoomOut.png     |   Bin 0 -> 15339 bytes
 .../PNG/White/1x/zoomOut.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x.meta      |     8 +
 .../kenney_game-icons/PNG/White/2x/arrowDown.png   |   Bin 0 -> 15328 bytes
 .../PNG/White/2x/arrowDown.png.meta                |   130 +
 .../kenney_game-icons/PNG/White/2x/arrowLeft.png   |   Bin 0 -> 15286 bytes
 .../PNG/White/2x/arrowLeft.png.meta                |   130 +
 .../kenney_game-icons/PNG/White/2x/arrowRight.png  |   Bin 0 -> 15282 bytes
 .../PNG/White/2x/arrowRight.png.meta               |   130 +
 .../kenney_game-icons/PNG/White/2x/arrowUp.png     |   Bin 0 -> 15229 bytes
 .../PNG/White/2x/arrowUp.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/audioOff.png    |   Bin 0 -> 15311 bytes
 .../PNG/White/2x/audioOff.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/audioOn.png     |   Bin 0 -> 15628 bytes
 .../PNG/White/2x/audioOn.png.meta                  |   130 +
 .../PNG/White/2x/barsHorizontal.png                |   Bin 0 -> 15220 bytes
 .../PNG/White/2x/barsHorizontal.png.meta           |   130 +
 .../PNG/White/2x/barsVertical.png                  |   Bin 0 -> 15163 bytes
 .../PNG/White/2x/barsVertical.png.meta             |   130 +
 .../kenney_game-icons/PNG/White/2x/button1.png     |   Bin 0 -> 15718 bytes
 .../PNG/White/2x/button1.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/button2.png     |   Bin 0 -> 15921 bytes
 .../PNG/White/2x/button2.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/button3.png     |   Bin 0 -> 15948 bytes
 .../PNG/White/2x/button3.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/buttonA.png     |   Bin 0 -> 15943 bytes
 .../PNG/White/2x/buttonA.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/buttonB.png     |   Bin 0 -> 15907 bytes
 .../PNG/White/2x/buttonB.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/buttonL.png     |   Bin 0 -> 15183 bytes
 .../PNG/White/2x/buttonL.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/buttonL1.png    |   Bin 0 -> 15222 bytes
 .../PNG/White/2x/buttonL1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/buttonL2.png    |   Bin 0 -> 15389 bytes
 .../PNG/White/2x/buttonL2.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/buttonR.png     |   Bin 0 -> 15366 bytes
 .../PNG/White/2x/buttonR.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/buttonR1.png    |   Bin 0 -> 15362 bytes
 .../PNG/White/2x/buttonR1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/buttonR2.png    |   Bin 0 -> 15512 bytes
 .../PNG/White/2x/buttonR2.png.meta                 |   130 +
 .../PNG/White/2x/buttonSelect.png                  |   Bin 0 -> 15634 bytes
 .../PNG/White/2x/buttonSelect.png.meta             |   130 +
 .../kenney_game-icons/PNG/White/2x/buttonStart.png |   Bin 0 -> 15604 bytes
 .../PNG/White/2x/buttonStart.png.meta              |   130 +
 .../kenney_game-icons/PNG/White/2x/buttonX.png     |   Bin 0 -> 15991 bytes
 .../PNG/White/2x/buttonX.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/buttonY.png     |   Bin 0 -> 15929 bytes
 .../PNG/White/2x/buttonY.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/checkmark.png   |   Bin 0 -> 15751 bytes
 .../PNG/White/2x/checkmark.png.meta                |   130 +
 .../kenney_game-icons/PNG/White/2x/contrast.png    |   Bin 0 -> 15870 bytes
 .../PNG/White/2x/contrast.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/cross.png |   Bin 0 -> 15480 bytes
 .../kenney_game-icons/PNG/White/2x/cross.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/down.png  |   Bin 0 -> 15313 bytes
 .../kenney_game-icons/PNG/White/2x/down.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/2x/downLeft.png    |   Bin 0 -> 15412 bytes
 .../PNG/White/2x/downLeft.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/downRight.png   |   Bin 0 -> 15441 bytes
 .../PNG/White/2x/downRight.png.meta                |   130 +
 .../kenney_game-icons/PNG/White/2x/exclamation.png |   Bin 0 -> 15304 bytes
 .../PNG/White/2x/exclamation.png.meta              |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/exit.png  |   Bin 0 -> 15378 bytes
 .../kenney_game-icons/PNG/White/2x/exit.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/2x/exitLeft.png    |   Bin 0 -> 15338 bytes
 .../PNG/White/2x/exitLeft.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/exitRight.png   |   Bin 0 -> 15305 bytes
 .../PNG/White/2x/exitRight.png.meta                |   130 +
 .../kenney_game-icons/PNG/White/2x/export.png      |   Bin 0 -> 15268 bytes
 .../kenney_game-icons/PNG/White/2x/export.png.meta |   130 +
 .../kenney_game-icons/PNG/White/2x/fastForward.png |   Bin 0 -> 15352 bytes
 .../PNG/White/2x/fastForward.png.meta              |   130 +
 .../kenney_game-icons/PNG/White/2x/gamepad.png     |   Bin 0 -> 15325 bytes
 .../PNG/White/2x/gamepad.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/gamepad1.png    |   Bin 0 -> 16017 bytes
 .../PNG/White/2x/gamepad1.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/gamepad2.png    |   Bin 0 -> 16071 bytes
 .../PNG/White/2x/gamepad2.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/gamepad3.png    |   Bin 0 -> 16055 bytes
 .../PNG/White/2x/gamepad3.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/gamepad4.png    |   Bin 0 -> 16028 bytes
 .../PNG/White/2x/gamepad4.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/gear.png  |   Bin 0 -> 16228 bytes
 .../kenney_game-icons/PNG/White/2x/gear.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/home.png  |   Bin 0 -> 15222 bytes
 .../kenney_game-icons/PNG/White/2x/home.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/2x/import.png      |   Bin 0 -> 15285 bytes
 .../kenney_game-icons/PNG/White/2x/import.png.meta |   130 +
 .../kenney_game-icons/PNG/White/2x/information.png |   Bin 0 -> 15443 bytes
 .../PNG/White/2x/information.png.meta              |   130 +
 .../kenney_game-icons/PNG/White/2x/joystick.png    |   Bin 0 -> 15327 bytes
 .../PNG/White/2x/joystick.png.meta                 |   130 +
 .../PNG/White/2x/joystickLeft.png                  |   Bin 0 -> 15550 bytes
 .../PNG/White/2x/joystickLeft.png.meta             |   130 +
 .../PNG/White/2x/joystickRight.png                 |   Bin 0 -> 15513 bytes
 .../PNG/White/2x/joystickRight.png.meta            |   130 +
 .../kenney_game-icons/PNG/White/2x/joystickUp.png  |   Bin 0 -> 15453 bytes
 .../PNG/White/2x/joystickUp.png.meta               |   130 +
 .../kenney_game-icons/PNG/White/2x/larger.png      |   Bin 0 -> 15389 bytes
 .../kenney_game-icons/PNG/White/2x/larger.png.meta |   130 +
 .../PNG/White/2x/leaderboardsComplex.png           |   Bin 0 -> 15495 bytes
 .../PNG/White/2x/leaderboardsComplex.png.meta      |   130 +
 .../PNG/White/2x/leaderboardsSimple.png            |   Bin 0 -> 15098 bytes
 .../PNG/White/2x/leaderboardsSimple.png.meta       |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/left.png  |   Bin 0 -> 15319 bytes
 .../kenney_game-icons/PNG/White/2x/left.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/2x/locked.png      |   Bin 0 -> 15262 bytes
 .../kenney_game-icons/PNG/White/2x/locked.png.meta |   130 +
 .../PNG/White/2x/massiveMultiplayer.png            |   Bin 0 -> 16113 bytes
 .../PNG/White/2x/massiveMultiplayer.png.meta       |   130 +
 .../kenney_game-icons/PNG/White/2x/medal1.png      |   Bin 0 -> 15731 bytes
 .../kenney_game-icons/PNG/White/2x/medal1.png.meta |   130 +
 .../kenney_game-icons/PNG/White/2x/medal2.png      |   Bin 0 -> 15953 bytes
 .../kenney_game-icons/PNG/White/2x/medal2.png.meta |   130 +
 .../kenney_game-icons/PNG/White/2x/menuGrid.png    |   Bin 0 -> 15242 bytes
 .../PNG/White/2x/menuGrid.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/menuList.png    |   Bin 0 -> 15278 bytes
 .../PNG/White/2x/menuList.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/minus.png |   Bin 0 -> 15146 bytes
 .../kenney_game-icons/PNG/White/2x/minus.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/mouse.png |   Bin 0 -> 15695 bytes
 .../kenney_game-icons/PNG/White/2x/mouse.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/movie.png |   Bin 0 -> 15211 bytes
 .../kenney_game-icons/PNG/White/2x/movie.png.meta  |   130 +
 .../kenney_game-icons/PNG/White/2x/multiplayer.png |   Bin 0 -> 15819 bytes
 .../PNG/White/2x/multiplayer.png.meta              |   130 +
 .../kenney_game-icons/PNG/White/2x/musicOff.png    |   Bin 0 -> 15721 bytes
 .../PNG/White/2x/musicOff.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/musicOn.png     |   Bin 0 -> 15537 bytes
 .../PNG/White/2x/musicOn.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/next.png  |   Bin 0 -> 15389 bytes
 .../kenney_game-icons/PNG/White/2x/next.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/open.png  |   Bin 0 -> 15316 bytes
 .../kenney_game-icons/PNG/White/2x/open.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/pause.png |   Bin 0 -> 15197 bytes
 .../kenney_game-icons/PNG/White/2x/pause.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/phone.png |   Bin 0 -> 15246 bytes
 .../kenney_game-icons/PNG/White/2x/phone.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/plus.png  |   Bin 0 -> 15215 bytes
 .../kenney_game-icons/PNG/White/2x/plus.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/power.png |   Bin 0 -> 16006 bytes
 .../kenney_game-icons/PNG/White/2x/power.png.meta  |   130 +
 .../kenney_game-icons/PNG/White/2x/previous.png    |   Bin 0 -> 15366 bytes
 .../PNG/White/2x/previous.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/question.png    |   Bin 0 -> 15636 bytes
 .../PNG/White/2x/question.png.meta                 |   130 +
 .../kenney_game-icons/PNG/White/2x/return.png      |   Bin 0 -> 15821 bytes
 .../kenney_game-icons/PNG/White/2x/return.png.meta |   130 +
 .../kenney_game-icons/PNG/White/2x/rewind.png      |   Bin 0 -> 15329 bytes
 .../kenney_game-icons/PNG/White/2x/rewind.png.meta |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/right.png |   Bin 0 -> 15312 bytes
 .../kenney_game-icons/PNG/White/2x/right.png.meta  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/save.png  |   Bin 0 -> 15155 bytes
 .../kenney_game-icons/PNG/White/2x/save.png.meta   |   130 +
 .../PNG/White/2x/scrollHorizontal.png              |   Bin 0 -> 15408 bytes
 .../PNG/White/2x/scrollHorizontal.png.meta         |   130 +
 .../PNG/White/2x/scrollVertical.png                |   Bin 0 -> 15393 bytes
 .../PNG/White/2x/scrollVertical.png.meta           |   130 +
 .../kenney_game-icons/PNG/White/2x/share1.png      |   Bin 0 -> 15440 bytes
 .../kenney_game-icons/PNG/White/2x/share1.png.meta |   130 +
 .../kenney_game-icons/PNG/White/2x/share2.png      |   Bin 0 -> 15913 bytes
 .../kenney_game-icons/PNG/White/2x/share2.png.meta |   130 +
 .../PNG/White/2x/shoppingBasket.png                |   Bin 0 -> 15579 bytes
 .../PNG/White/2x/shoppingBasket.png.meta           |   130 +
 .../PNG/White/2x/shoppingCart.png                  |   Bin 0 -> 15518 bytes
 .../PNG/White/2x/shoppingCart.png.meta             |   130 +
 .../kenney_game-icons/PNG/White/2x/siganl1.png     |   Bin 0 -> 15150 bytes
 .../PNG/White/2x/siganl1.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/signal2.png     |   Bin 0 -> 15191 bytes
 .../PNG/White/2x/signal2.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/signal3.png     |   Bin 0 -> 15211 bytes
 .../PNG/White/2x/signal3.png.meta                  |   130 +
 .../PNG/White/2x/singleplayer.png                  |   Bin 0 -> 15663 bytes
 .../PNG/White/2x/singleplayer.png.meta             |   130 +
 .../kenney_game-icons/PNG/White/2x/smaller.png     |   Bin 0 -> 15374 bytes
 .../PNG/White/2x/smaller.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/star.png  |   Bin 0 -> 15648 bytes
 .../kenney_game-icons/PNG/White/2x/star.png.meta   |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/stop.png  |   Bin 0 -> 15146 bytes
 .../kenney_game-icons/PNG/White/2x/stop.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/2x/tablet.png      |   Bin 0 -> 15248 bytes
 .../kenney_game-icons/PNG/White/2x/tablet.png.meta |   130 +
 .../kenney_game-icons/PNG/White/2x/target.png      |   Bin 0 -> 16104 bytes
 .../kenney_game-icons/PNG/White/2x/target.png.meta |   130 +
 .../kenney_game-icons/PNG/White/2x/trashcan.png    |   Bin 0 -> 15231 bytes
 .../PNG/White/2x/trashcan.png.meta                 |   130 +
 .../PNG/White/2x/trashcanOpen.png                  |   Bin 0 -> 15470 bytes
 .../PNG/White/2x/trashcanOpen.png.meta             |   130 +
 .../kenney_game-icons/PNG/White/2x/trophy.png      |   Bin 0 -> 15290 bytes
 .../kenney_game-icons/PNG/White/2x/trophy.png.meta |   130 +
 .../kenney_game-icons/PNG/White/2x/unlocked.png    |   Bin 0 -> 15264 bytes
 .../PNG/White/2x/unlocked.png.meta                 |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/up.png    |   Bin 0 -> 15204 bytes
 .../kenney_game-icons/PNG/White/2x/up.png.meta     |   130 +
 .../kenney_game-icons/PNG/White/2x/upLeft.png      |   Bin 0 -> 15406 bytes
 .../kenney_game-icons/PNG/White/2x/upLeft.png.meta |   130 +
 .../kenney_game-icons/PNG/White/2x/upRight.png     |   Bin 0 -> 15407 bytes
 .../PNG/White/2x/upRight.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/video.png |   Bin 0 -> 15421 bytes
 .../kenney_game-icons/PNG/White/2x/video.png.meta  |   130 +
 .../kenney_game-icons/PNG/White/2x/warning.png     |   Bin 0 -> 15751 bytes
 .../PNG/White/2x/warning.png.meta                  |   130 +
 .../kenney_game-icons/PNG/White/2x/wrench.png      |   Bin 0 -> 15771 bytes
 .../kenney_game-icons/PNG/White/2x/wrench.png.meta |   130 +
 .../NewUI/kenney_game-icons/PNG/White/2x/zoom.png  |   Bin 0 -> 15871 bytes
 .../kenney_game-icons/PNG/White/2x/zoom.png.meta   |   130 +
 .../kenney_game-icons/PNG/White/2x/zoomDefault.png |   Bin 0 -> 15922 bytes
 .../PNG/White/2x/zoomDefault.png.meta              |   130 +
 .../kenney_game-icons/PNG/White/2x/zoomIn.png      |   Bin 0 -> 15939 bytes
 .../kenney_game-icons/PNG/White/2x/zoomIn.png.meta |   130 +
 .../kenney_game-icons/PNG/White/2x/zoomOut.png     |   Bin 0 -> 15908 bytes
 .../PNG/White/2x/zoomOut.png.meta                  |   130 +
 .../NewUI/kenney_game-icons/Spritesheet.meta       |     8 +
 .../Spritesheet/sheet_black1x.png                  |   Bin 0 -> 22798 bytes
 .../Spritesheet/sheet_black1x.png.meta             |   130 +
 .../Spritesheet/sheet_black1x.xml                  |   107 +
 .../Spritesheet/sheet_black1x.xml.meta             |     7 +
 .../Spritesheet/sheet_black2x.png                  |   Bin 0 -> 52634 bytes
 .../Spritesheet/sheet_black2x.png.meta             |   130 +
 .../Spritesheet/sheet_black2x.xml                  |   107 +
 .../Spritesheet/sheet_black2x.xml.meta             |     7 +
 .../Spritesheet/sheet_white1x.png                  |   Bin 0 -> 25080 bytes
 .../Spritesheet/sheet_white1x.png.meta             |   130 +
 .../Spritesheet/sheet_white1x.xml                  |   107 +
 .../Spritesheet/sheet_white1x.xml.meta             |     7 +
 .../Spritesheet/sheet_white2x.png                  |   Bin 0 -> 58358 bytes
 .../Spritesheet/sheet_white2x.png.meta             |   130 +
 .../Spritesheet/sheet_white2x.xml                  |   107 +
 .../Spritesheet/sheet_white2x.xml.meta             |     7 +
 .../textures/NewUI/kenney_game-icons/Vector.meta   |     8 +
 .../kenney_game-icons/Vector/vector_blackIcons.ai  |   720 +
 .../Vector/vector_blackIcons.ai.meta               |     7 +
 .../kenney_game-icons/Vector/vector_blackIcons.svg |     6 +
 .../Vector/vector_blackIcons.svg.meta              |    53 +
 .../kenney_game-icons/Vector/vector_whiteIcons.ai  |   Bin 0 -> 70364 bytes
 .../Vector/vector_whiteIcons.ai.meta               |     7 +
 .../kenney_game-icons/Vector/vector_whiteIcons.svg |     6 +
 .../Vector/vector_whiteIcons.svg.meta              |    53 +
 .../textures/NewUI/kenney_game-icons/license.txt   |    14 +
 .../NewUI/kenney_game-icons/license.txt.meta       |     7 +
 .../textures/NewUI/kenney_game-icons/preview.png   |   Bin 0 -> 40984 bytes
 .../NewUI/kenney_game-icons/preview.png.meta       |   130 +
 .../Assets/textures/NewUI/kenney_ui-pack.meta      |     8 +
 .../Assets/textures/NewUI/kenney_ui-pack/Font.meta |     8 +
 .../kenney_ui-pack/Font/Kenney Future Narrow.ttf   |   Bin 0 -> 34180 bytes
 .../Font/Kenney Future Narrow.ttf.meta             |    21 +
 .../NewUI/kenney_ui-pack/Font/Kenney Future.ttf    |   Bin 0 -> 34160 bytes
 .../kenney_ui-pack/Font/Kenney Future.ttf.meta     |    21 +
 .../textures/NewUI/kenney_ui-pack/License.txt      |    22 +
 .../textures/NewUI/kenney_ui-pack/License.txt.meta |     7 +
 .../Assets/textures/NewUI/kenney_ui-pack/PNG.meta  |     8 +
 .../textures/NewUI/kenney_ui-pack/PNG/Blue.meta    |     8 +
 .../NewUI/kenney_ui-pack/PNG/Blue/Default.meta     |     8 +
 .../PNG/Blue/Default/arrow_basic_e.png             |   Bin 0 -> 422 bytes
 .../PNG/Blue/Default/arrow_basic_e.png.meta        |   130 +
 .../PNG/Blue/Default/arrow_basic_e_small.png       |   Bin 0 -> 378 bytes
 .../PNG/Blue/Default/arrow_basic_e_small.png.meta  |   130 +
 .../PNG/Blue/Default/arrow_basic_n.png             |   Bin 0 -> 391 bytes
 .../PNG/Blue/Default/arrow_basic_n.png.meta        |   130 +
 .../PNG/Blue/Default/arrow_basic_n_small.png       |   Bin 0 -> 302 bytes
 .../PNG/Blue/Default/arrow_basic_n_small.png.meta  |   130 +
 .../PNG/Blue/Default/arrow_basic_s.png             |   Bin 0 -> 414 bytes
 .../PNG/Blue/Default/arrow_basic_s.png.meta        |   130 +
 .../PNG/Blue/Default/arrow_basic_s_small.png       |   Bin 0 -> 332 bytes
 .../PNG/Blue/Default/arrow_basic_s_small.png.meta  |   130 +
 .../PNG/Blue/Default/arrow_basic_w.png             |   Bin 0 -> 402 bytes
 .../PNG/Blue/Default/arrow_basic_w.png.meta        |   130 +
 .../PNG/Blue/Default/arrow_basic_w_small.png       |   Bin 0 -> 399 bytes
 .../PNG/Blue/Default/arrow_basic_w_small.png.meta  |   130 +
 .../PNG/Blue/Default/arrow_decorative_e.png        |   Bin 0 -> 566 bytes
 .../PNG/Blue/Default/arrow_decorative_e.png.meta   |   130 +
 .../PNG/Blue/Default/arrow_decorative_e_small.png  |   Bin 0 -> 459 bytes
 .../Blue/Default/arrow_decorative_e_small.png.meta |   130 +
 .../PNG/Blue/Default/arrow_decorative_n.png        |   Bin 0 -> 511 bytes
 .../PNG/Blue/Default/arrow_decorative_n.png.meta   |   130 +
 .../PNG/Blue/Default/arrow_decorative_n_small.png  |   Bin 0 -> 405 bytes
 .../Blue/Default/arrow_decorative_n_small.png.meta |   130 +
 .../PNG/Blue/Default/arrow_decorative_s.png        |   Bin 0 -> 530 bytes
 .../PNG/Blue/Default/arrow_decorative_s.png.meta   |   130 +
 .../PNG/Blue/Default/arrow_decorative_s_small.png  |   Bin 0 -> 424 bytes
 .../Blue/Default/arrow_decorative_s_small.png.meta |   130 +
 .../PNG/Blue/Default/arrow_decorative_w.png        |   Bin 0 -> 562 bytes
 .../PNG/Blue/Default/arrow_decorative_w.png.meta   |   130 +
 .../PNG/Blue/Default/arrow_decorative_w_small.png  |   Bin 0 -> 484 bytes
 .../Blue/Default/arrow_decorative_w_small.png.meta |   130 +
 .../PNG/Blue/Default/button_rectangle_border.png   |   Bin 0 -> 338 bytes
 .../Blue/Default/button_rectangle_border.png.meta  |   130 +
 .../Blue/Default/button_rectangle_depth_border.png |   Bin 0 -> 411 bytes
 .../Default/button_rectangle_depth_border.png.meta |   130 +
 .../Blue/Default/button_rectangle_depth_flat.png   |   Bin 0 -> 383 bytes
 .../Default/button_rectangle_depth_flat.png.meta   |   130 +
 .../Blue/Default/button_rectangle_depth_gloss.png  |   Bin 0 -> 373 bytes
 .../Default/button_rectangle_depth_gloss.png.meta  |   130 +
 .../Default/button_rectangle_depth_gradient.png    |   Bin 0 -> 582 bytes
 .../button_rectangle_depth_gradient.png.meta       |   130 +
 .../Blue/Default/button_rectangle_depth_line.png   |   Bin 0 -> 411 bytes
 .../Default/button_rectangle_depth_line.png.meta   |   130 +
 .../PNG/Blue/Default/button_rectangle_flat.png     |   Bin 0 -> 315 bytes
 .../Blue/Default/button_rectangle_flat.png.meta    |   130 +
 .../PNG/Blue/Default/button_rectangle_gloss.png    |   Bin 0 -> 306 bytes
 .../Blue/Default/button_rectangle_gloss.png.meta   |   130 +
 .../PNG/Blue/Default/button_rectangle_gradient.png |   Bin 0 -> 528 bytes
 .../Default/button_rectangle_gradient.png.meta     |   130 +
 .../PNG/Blue/Default/button_rectangle_line.png     |   Bin 0 -> 338 bytes
 .../Blue/Default/button_rectangle_line.png.meta    |   130 +
 .../PNG/Blue/Default/button_round_border.png       |   Bin 0 -> 1483 bytes
 .../PNG/Blue/Default/button_round_border.png.meta  |   130 +
 .../PNG/Blue/Default/button_round_depth_border.png |   Bin 0 -> 1788 bytes
 .../Default/button_round_depth_border.png.meta     |   130 +
 .../PNG/Blue/Default/button_round_depth_flat.png   |   Bin 0 -> 1301 bytes
 .../Blue/Default/button_round_depth_flat.png.meta  |   130 +
 .../PNG/Blue/Default/button_round_depth_gloss.png  |   Bin 0 -> 1210 bytes
 .../Blue/Default/button_round_depth_gloss.png.meta |   130 +
 .../Blue/Default/button_round_depth_gradient.png   |   Bin 0 -> 1571 bytes
 .../Default/button_round_depth_gradient.png.meta   |   130 +
 .../PNG/Blue/Default/button_round_depth_line.png   |   Bin 0 -> 1690 bytes
 .../Blue/Default/button_round_depth_line.png.meta  |   130 +
 .../PNG/Blue/Default/button_round_flat.png         |   Bin 0 -> 1023 bytes
 .../PNG/Blue/Default/button_round_flat.png.meta    |   130 +
 .../PNG/Blue/Default/button_round_gloss.png        |   Bin 0 -> 958 bytes
 .../PNG/Blue/Default/button_round_gloss.png.meta   |   130 +
 .../PNG/Blue/Default/button_round_gradient.png     |   Bin 0 -> 1294 bytes
 .../Blue/Default/button_round_gradient.png.meta    |   130 +
 .../PNG/Blue/Default/button_round_line.png         |   Bin 0 -> 1413 bytes
 .../PNG/Blue/Default/button_round_line.png.meta    |   130 +
 .../PNG/Blue/Default/button_square_border.png      |   Bin 0 -> 306 bytes
 .../PNG/Blue/Default/button_square_border.png.meta |   130 +
 .../Blue/Default/button_square_depth_border.png    |   Bin 0 -> 375 bytes
 .../Default/button_square_depth_border.png.meta    |   130 +
 .../PNG/Blue/Default/button_square_depth_flat.png  |   Bin 0 -> 355 bytes
 .../Blue/Default/button_square_depth_flat.png.meta |   130 +
 .../PNG/Blue/Default/button_square_depth_gloss.png |   Bin 0 -> 337 bytes
 .../Default/button_square_depth_gloss.png.meta     |   130 +
 .../Blue/Default/button_square_depth_gradient.png  |   Bin 0 -> 575 bytes
 .../Default/button_square_depth_gradient.png.meta  |   130 +
 .../PNG/Blue/Default/button_square_depth_line.png  |   Bin 0 -> 374 bytes
 .../Blue/Default/button_square_depth_line.png.meta |   130 +
 .../PNG/Blue/Default/button_square_flat.png        |   Bin 0 -> 286 bytes
 .../PNG/Blue/Default/button_square_flat.png.meta   |   130 +
 .../PNG/Blue/Default/button_square_gloss.png       |   Bin 0 -> 268 bytes
 .../PNG/Blue/Default/button_square_gloss.png.meta  |   130 +
 .../PNG/Blue/Default/button_square_gradient.png    |   Bin 0 -> 516 bytes
 .../Blue/Default/button_square_gradient.png.meta   |   130 +
 .../PNG/Blue/Default/button_square_line.png        |   Bin 0 -> 304 bytes
 .../PNG/Blue/Default/button_square_line.png.meta   |   130 +
 .../PNG/Blue/Default/check_round_color.png         |   Bin 0 -> 579 bytes
 .../PNG/Blue/Default/check_round_color.png.meta    |   130 +
 .../PNG/Blue/Default/check_round_grey.png          |   Bin 0 -> 579 bytes
 .../PNG/Blue/Default/check_round_grey.png.meta     |   130 +
 .../PNG/Blue/Default/check_round_grey_circle.png   |   Bin 0 -> 774 bytes
 .../Blue/Default/check_round_grey_circle.png.meta  |   130 +
 .../PNG/Blue/Default/check_round_round_circle.png  |   Bin 0 -> 767 bytes
 .../Blue/Default/check_round_round_circle.png.meta |   130 +
 .../PNG/Blue/Default/check_square_color.png        |   Bin 0 -> 280 bytes
 .../PNG/Blue/Default/check_square_color.png.meta   |   130 +
 .../Blue/Default/check_square_color_checkmark.png  |   Bin 0 -> 555 bytes
 .../Default/check_square_color_checkmark.png.meta  |   130 +
 .../PNG/Blue/Default/check_square_color_cross.png  |   Bin 0 -> 533 bytes
 .../Blue/Default/check_square_color_cross.png.meta |   130 +
 .../PNG/Blue/Default/check_square_color_square.png |   Bin 0 -> 319 bytes
 .../Default/check_square_color_square.png.meta     |   130 +
 .../PNG/Blue/Default/check_square_grey.png         |   Bin 0 -> 280 bytes
 .../PNG/Blue/Default/check_square_grey.png.meta    |   130 +
 .../Blue/Default/check_square_grey_checkmark.png   |   Bin 0 -> 559 bytes
 .../Default/check_square_grey_checkmark.png.meta   |   130 +
 .../PNG/Blue/Default/check_square_grey_cross.png   |   Bin 0 -> 539 bytes
 .../Blue/Default/check_square_grey_cross.png.meta  |   130 +
 .../PNG/Blue/Default/check_square_grey_square.png  |   Bin 0 -> 321 bytes
 .../Blue/Default/check_square_grey_square.png.meta |   130 +
 .../PNG/Blue/Default/icon_checkmark.png            |   Bin 0 -> 377 bytes
 .../PNG/Blue/Default/icon_checkmark.png.meta       |   130 +
 .../PNG/Blue/Default/icon_circle.png               |   Bin 0 -> 312 bytes
 .../PNG/Blue/Default/icon_circle.png.meta          |   130 +
 .../kenney_ui-pack/PNG/Blue/Default/icon_cross.png |   Bin 0 -> 350 bytes
 .../PNG/Blue/Default/icon_cross.png.meta           |   130 +
 .../PNG/Blue/Default/icon_outline_checkmark.png    |   Bin 0 -> 377 bytes
 .../Blue/Default/icon_outline_checkmark.png.meta   |   130 +
 .../PNG/Blue/Default/icon_outline_circle.png       |   Bin 0 -> 312 bytes
 .../PNG/Blue/Default/icon_outline_circle.png.meta  |   130 +
 .../PNG/Blue/Default/icon_outline_cross.png        |   Bin 0 -> 352 bytes
 .../PNG/Blue/Default/icon_outline_cross.png.meta   |   130 +
 .../PNG/Blue/Default/icon_outline_square.png       |   Bin 0 -> 135 bytes
 .../PNG/Blue/Default/icon_outline_square.png.meta  |   130 +
 .../PNG/Blue/Default/icon_square.png               |   Bin 0 -> 142 bytes
 .../PNG/Blue/Default/icon_square.png.meta          |   130 +
 .../PNG/Blue/Default/slide_hangle.png              |   Bin 0 -> 295 bytes
 .../PNG/Blue/Default/slide_hangle.png.meta         |   130 +
 .../PNG/Blue/Default/slide_horizontal_color.png    |   Bin 0 -> 383 bytes
 .../Blue/Default/slide_horizontal_color.png.meta   |   130 +
 .../Default/slide_horizontal_color_section.png     |   Bin 0 -> 320 bytes
 .../slide_horizontal_color_section.png.meta        |   130 +
 .../slide_horizontal_color_section_wide.png        |   Bin 0 -> 336 bytes
 .../slide_horizontal_color_section_wide.png.meta   |   130 +
 .../PNG/Blue/Default/slide_horizontal_grey.png     |   Bin 0 -> 383 bytes
 .../Blue/Default/slide_horizontal_grey.png.meta    |   130 +
 .../Blue/Default/slide_horizontal_grey_section.png |   Bin 0 -> 321 bytes
 .../Default/slide_horizontal_grey_section.png.meta |   130 +
 .../Default/slide_horizontal_grey_section_wide.png |   Bin 0 -> 336 bytes
 .../slide_horizontal_grey_section_wide.png.meta    |   130 +
 .../PNG/Blue/Default/slide_vertical_color.png      |   Bin 0 -> 379 bytes
 .../PNG/Blue/Default/slide_vertical_color.png.meta |   130 +
 .../Blue/Default/slide_vertical_color_section.png  |   Bin 0 -> 308 bytes
 .../Default/slide_vertical_color_section.png.meta  |   130 +
 .../Default/slide_vertical_color_section_wide.png  |   Bin 0 -> 316 bytes
 .../slide_vertical_color_section_wide.png.meta     |   130 +
 .../PNG/Blue/Default/slide_vertical_grey.png       |   Bin 0 -> 379 bytes
 .../PNG/Blue/Default/slide_vertical_grey.png.meta  |   130 +
 .../Blue/Default/slide_vertical_grey_section.png   |   Bin 0 -> 308 bytes
 .../Default/slide_vertical_grey_section.png.meta   |   130 +
 .../Default/slide_vertical_grey_section_wide.png   |   Bin 0 -> 316 bytes
 .../slide_vertical_grey_section_wide.png.meta      |   130 +
 .../NewUI/kenney_ui-pack/PNG/Blue/Default/star.png |   Bin 0 -> 1507 bytes
 .../kenney_ui-pack/PNG/Blue/Default/star.png.meta  |   130 +
 .../PNG/Blue/Default/star_outline.png              |   Bin 0 -> 955 bytes
 .../PNG/Blue/Default/star_outline.png.meta         |   130 +
 .../PNG/Blue/Default/star_outline_depth.png        |   Bin 0 -> 1168 bytes
 .../PNG/Blue/Default/star_outline_depth.png.meta   |   130 +
 .../NewUI/kenney_ui-pack/PNG/Blue/Double.meta      |     8 +
 .../PNG/Blue/Double/arrow_basic_e.png              |   Bin 0 -> 637 bytes
 .../PNG/Blue/Double/arrow_basic_e.png.meta         |   130 +
 .../PNG/Blue/Double/arrow_basic_e_small.png        |   Bin 0 -> 523 bytes
 .../PNG/Blue/Double/arrow_basic_e_small.png.meta   |   130 +
 .../PNG/Blue/Double/arrow_basic_n.png              |   Bin 0 -> 622 bytes
 .../PNG/Blue/Double/arrow_basic_n.png.meta         |   130 +
 .../PNG/Blue/Double/arrow_basic_n_small.png        |   Bin 0 -> 471 bytes
 .../PNG/Blue/Double/arrow_basic_n_small.png.meta   |   130 +
 .../PNG/Blue/Double/arrow_basic_s.png              |   Bin 0 -> 694 bytes
 .../PNG/Blue/Double/arrow_basic_s.png.meta         |   130 +
 .../PNG/Blue/Double/arrow_basic_s_small.png        |   Bin 0 -> 533 bytes
 .../PNG/Blue/Double/arrow_basic_s_small.png.meta   |   130 +
 .../PNG/Blue/Double/arrow_basic_w.png              |   Bin 0 -> 639 bytes
 .../PNG/Blue/Double/arrow_basic_w.png.meta         |   130 +
 .../PNG/Blue/Double/arrow_basic_w_small.png        |   Bin 0 -> 549 bytes
 .../PNG/Blue/Double/arrow_basic_w_small.png.meta   |   130 +
 .../PNG/Blue/Double/arrow_decorative_e.png         |   Bin 0 -> 859 bytes
 .../PNG/Blue/Double/arrow_decorative_e.png.meta    |   130 +
 .../PNG/Blue/Double/arrow_decorative_e_small.png   |   Bin 0 -> 697 bytes
 .../Blue/Double/arrow_decorative_e_small.png.meta  |   130 +
 .../PNG/Blue/Double/arrow_decorative_n.png         |   Bin 0 -> 880 bytes
 .../PNG/Blue/Double/arrow_decorative_n.png.meta    |   130 +
 .../PNG/Blue/Double/arrow_decorative_n_small.png   |   Bin 0 -> 649 bytes
 .../Blue/Double/arrow_decorative_n_small.png.meta  |   130 +
 .../PNG/Blue/Double/arrow_decorative_s.png         |   Bin 0 -> 951 bytes
 .../PNG/Blue/Double/arrow_decorative_s.png.meta    |   130 +
 .../PNG/Blue/Double/arrow_decorative_s_small.png   |   Bin 0 -> 684 bytes
 .../Blue/Double/arrow_decorative_s_small.png.meta  |   130 +
 .../PNG/Blue/Double/arrow_decorative_w.png         |   Bin 0 -> 902 bytes
 .../PNG/Blue/Double/arrow_decorative_w.png.meta    |   130 +
 .../PNG/Blue/Double/arrow_decorative_w_small.png   |   Bin 0 -> 721 bytes
 .../Blue/Double/arrow_decorative_w_small.png.meta  |   130 +
 .../PNG/Blue/Double/button_rectangle_border.png    |   Bin 0 -> 692 bytes
 .../Blue/Double/button_rectangle_border.png.meta   |   130 +
 .../Blue/Double/button_rectangle_depth_border.png  |   Bin 0 -> 819 bytes
 .../Double/button_rectangle_depth_border.png.meta  |   130 +
 .../Blue/Double/button_rectangle_depth_flat.png    |   Bin 0 -> 785 bytes
 .../Double/button_rectangle_depth_flat.png.meta    |   130 +
 .../Blue/Double/button_rectangle_depth_gloss.png   |   Bin 0 -> 748 bytes
 .../Double/button_rectangle_depth_gloss.png.meta   |   130 +
 .../Double/button_rectangle_depth_gradient.png     |   Bin 0 -> 1080 bytes
 .../button_rectangle_depth_gradient.png.meta       |   130 +
 .../Blue/Double/button_rectangle_depth_line.png    |   Bin 0 -> 817 bytes
 .../Double/button_rectangle_depth_line.png.meta    |   130 +
 .../PNG/Blue/Double/button_rectangle_flat.png      |   Bin 0 -> 661 bytes
 .../PNG/Blue/Double/button_rectangle_flat.png.meta |   130 +
 .../PNG/Blue/Double/button_rectangle_gloss.png     |   Bin 0 -> 623 bytes
 .../Blue/Double/button_rectangle_gloss.png.meta    |   130 +
 .../PNG/Blue/Double/button_rectangle_gradient.png  |   Bin 0 -> 969 bytes
 .../Blue/Double/button_rectangle_gradient.png.meta |   130 +
 .../PNG/Blue/Double/button_rectangle_line.png      |   Bin 0 -> 688 bytes
 .../PNG/Blue/Double/button_rectangle_line.png.meta |   130 +
 .../PNG/Blue/Double/button_round_border.png        |   Bin 0 -> 2789 bytes
 .../PNG/Blue/Double/button_round_border.png.meta   |   130 +
 .../PNG/Blue/Double/button_round_depth_border.png  |   Bin 0 -> 3359 bytes
 .../Blue/Double/button_round_depth_border.png.meta |   130 +
 .../PNG/Blue/Double/button_round_depth_flat.png    |   Bin 0 -> 2476 bytes
 .../Blue/Double/button_round_depth_flat.png.meta   |   130 +
 .../PNG/Blue/Double/button_round_depth_gloss.png   |   Bin 0 -> 2263 bytes
 .../Blue/Double/button_round_depth_gloss.png.meta  |   130 +
 .../Blue/Double/button_round_depth_gradient.png    |   Bin 0 -> 2809 bytes
 .../Double/button_round_depth_gradient.png.meta    |   130 +
 .../PNG/Blue/Double/button_round_depth_line.png    |   Bin 0 -> 3231 bytes
 .../Blue/Double/button_round_depth_line.png.meta   |   130 +
 .../PNG/Blue/Double/button_round_flat.png          |   Bin 0 -> 1863 bytes
 .../PNG/Blue/Double/button_round_flat.png.meta     |   130 +
 .../PNG/Blue/Double/button_round_gloss.png         |   Bin 0 -> 1735 bytes
 .../PNG/Blue/Double/button_round_gloss.png.meta    |   130 +
 .../PNG/Blue/Double/button_round_gradient.png      |   Bin 0 -> 2318 bytes
 .../PNG/Blue/Double/button_round_gradient.png.meta |   130 +
 .../PNG/Blue/Double/button_round_line.png          |   Bin 0 -> 2669 bytes
 .../PNG/Blue/Double/button_round_line.png.meta     |   130 +
 .../PNG/Blue/Double/button_square_border.png       |   Bin 0 -> 544 bytes
 .../PNG/Blue/Double/button_square_border.png.meta  |   130 +
 .../PNG/Blue/Double/button_square_depth_border.png |   Bin 0 -> 686 bytes
 .../Double/button_square_depth_border.png.meta     |   130 +
 .../PNG/Blue/Double/button_square_depth_flat.png   |   Bin 0 -> 652 bytes
 .../Blue/Double/button_square_depth_flat.png.meta  |   130 +
 .../PNG/Blue/Double/button_square_depth_gloss.png  |   Bin 0 -> 630 bytes
 .../Blue/Double/button_square_depth_gloss.png.meta |   130 +
 .../Blue/Double/button_square_depth_gradient.png   |   Bin 0 -> 956 bytes
 .../Double/button_square_depth_gradient.png.meta   |   130 +
 .../PNG/Blue/Double/button_square_depth_line.png   |   Bin 0 -> 684 bytes
 .../Blue/Double/button_square_depth_line.png.meta  |   130 +
 .../PNG/Blue/Double/button_square_flat.png         |   Bin 0 -> 524 bytes
 .../PNG/Blue/Double/button_square_flat.png.meta    |   130 +
 .../PNG/Blue/Double/button_square_gloss.png        |   Bin 0 -> 503 bytes
 .../PNG/Blue/Double/button_square_gloss.png.meta   |   130 +
 .../PNG/Blue/Double/button_square_gradient.png     |   Bin 0 -> 824 bytes
 .../Blue/Double/button_square_gradient.png.meta    |   130 +
 .../PNG/Blue/Double/button_square_line.png         |   Bin 0 -> 541 bytes
 .../PNG/Blue/Double/button_square_line.png.meta    |   130 +
 .../PNG/Blue/Double/check_round_color.png          |   Bin 0 -> 1040 bytes
 .../PNG/Blue/Double/check_round_color.png.meta     |   130 +
 .../PNG/Blue/Double/check_round_grey.png           |   Bin 0 -> 1041 bytes
 .../PNG/Blue/Double/check_round_grey.png.meta      |   130 +
 .../PNG/Blue/Double/check_round_grey_circle.png    |   Bin 0 -> 1387 bytes
 .../Blue/Double/check_round_grey_circle.png.meta   |   130 +
 .../PNG/Blue/Double/check_round_round_circle.png   |   Bin 0 -> 1378 bytes
 .../Blue/Double/check_round_round_circle.png.meta  |   130 +
 .../PNG/Blue/Double/check_square_color.png         |   Bin 0 -> 466 bytes
 .../PNG/Blue/Double/check_square_color.png.meta    |   130 +
 .../Blue/Double/check_square_color_checkmark.png   |   Bin 0 -> 950 bytes
 .../Double/check_square_color_checkmark.png.meta   |   130 +
 .../PNG/Blue/Double/check_square_color_cross.png   |   Bin 0 -> 901 bytes
 .../Blue/Double/check_square_color_cross.png.meta  |   130 +
 .../PNG/Blue/Double/check_square_color_square.png  |   Bin 0 -> 535 bytes
 .../Blue/Double/check_square_color_square.png.meta |   130 +
 .../PNG/Blue/Double/check_square_grey.png          |   Bin 0 -> 466 bytes
 .../PNG/Blue/Double/check_square_grey.png.meta     |   130 +
 .../Blue/Double/check_square_grey_checkmark.png    |   Bin 0 -> 958 bytes
 .../Double/check_square_grey_checkmark.png.meta    |   130 +
 .../PNG/Blue/Double/check_square_grey_cross.png    |   Bin 0 -> 909 bytes
 .../Blue/Double/check_square_grey_cross.png.meta   |   130 +
 .../PNG/Blue/Double/check_square_grey_square.png   |   Bin 0 -> 539 bytes
 .../Blue/Double/check_square_grey_square.png.meta  |   130 +
 .../PNG/Blue/Double/icon_checkmark.png             |   Bin 0 -> 583 bytes
 .../PNG/Blue/Double/icon_checkmark.png.meta        |   130 +
 .../kenney_ui-pack/PNG/Blue/Double/icon_circle.png |   Bin 0 -> 466 bytes
 .../PNG/Blue/Double/icon_circle.png.meta           |   130 +
 .../kenney_ui-pack/PNG/Blue/Double/icon_cross.png  |   Bin 0 -> 516 bytes
 .../PNG/Blue/Double/icon_cross.png.meta            |   130 +
 .../PNG/Blue/Double/icon_outline_checkmark.png     |   Bin 0 -> 585 bytes
 .../Blue/Double/icon_outline_checkmark.png.meta    |   130 +
 .../PNG/Blue/Double/icon_outline_circle.png        |   Bin 0 -> 465 bytes
 .../PNG/Blue/Double/icon_outline_circle.png.meta   |   130 +
 .../PNG/Blue/Double/icon_outline_cross.png         |   Bin 0 -> 516 bytes
 .../PNG/Blue/Double/icon_outline_cross.png.meta    |   130 +
 .../PNG/Blue/Double/icon_outline_square.png        |   Bin 0 -> 183 bytes
 .../PNG/Blue/Double/icon_outline_square.png.meta   |   130 +
 .../kenney_ui-pack/PNG/Blue/Double/icon_square.png |   Bin 0 -> 183 bytes
 .../PNG/Blue/Double/icon_square.png.meta           |   130 +
 .../PNG/Blue/Double/slide_hangle.png               |   Bin 0 -> 440 bytes
 .../PNG/Blue/Double/slide_hangle.png.meta          |   130 +
 .../PNG/Blue/Double/slide_horizontal_color.png     |   Bin 0 -> 614 bytes
 .../Blue/Double/slide_horizontal_color.png.meta    |   130 +
 .../Blue/Double/slide_horizontal_color_section.png |   Bin 0 -> 432 bytes
 .../Double/slide_horizontal_color_section.png.meta |   130 +
 .../Double/slide_horizontal_color_section_wide.png |   Bin 0 -> 439 bytes
 .../slide_horizontal_color_section_wide.png.meta   |   130 +
 .../PNG/Blue/Double/slide_horizontal_grey.png      |   Bin 0 -> 614 bytes
 .../PNG/Blue/Double/slide_horizontal_grey.png.meta |   130 +
 .../Blue/Double/slide_horizontal_grey_section.png  |   Bin 0 -> 430 bytes
 .../Double/slide_horizontal_grey_section.png.meta  |   130 +
 .../Double/slide_horizontal_grey_section_wide.png  |   Bin 0 -> 439 bytes
 .../slide_horizontal_grey_section_wide.png.meta    |   130 +
 .../PNG/Blue/Double/slide_vertical_color.png       |   Bin 0 -> 611 bytes
 .../PNG/Blue/Double/slide_vertical_color.png.meta  |   130 +
 .../Blue/Double/slide_vertical_color_section.png   |   Bin 0 -> 461 bytes
 .../Double/slide_vertical_color_section.png.meta   |   130 +
 .../Double/slide_vertical_color_section_wide.png   |   Bin 0 -> 474 bytes
 .../slide_vertical_color_section_wide.png.meta     |   130 +
 .../PNG/Blue/Double/slide_vertical_grey.png        |   Bin 0 -> 611 bytes
 .../PNG/Blue/Double/slide_vertical_grey.png.meta   |   130 +
 .../Blue/Double/slide_vertical_grey_section.png    |   Bin 0 -> 461 bytes
 .../Double/slide_vertical_grey_section.png.meta    |   130 +
 .../Double/slide_vertical_grey_section_wide.png    |   Bin 0 -> 473 bytes
 .../slide_vertical_grey_section_wide.png.meta      |   130 +
 .../NewUI/kenney_ui-pack/PNG/Blue/Double/star.png  |   Bin 0 -> 2861 bytes
 .../kenney_ui-pack/PNG/Blue/Double/star.png.meta   |   130 +
 .../PNG/Blue/Double/star_outline.png               |   Bin 0 -> 1800 bytes
 .../PNG/Blue/Double/star_outline.png.meta          |   130 +
 .../PNG/Blue/Double/star_outline_depth.png         |   Bin 0 -> 2141 bytes
 .../PNG/Blue/Double/star_outline_depth.png.meta    |   130 +
 .../textures/NewUI/kenney_ui-pack/PNG/Extra.meta   |     8 +
 .../NewUI/kenney_ui-pack/PNG/Extra/Default.meta    |     8 +
 .../Extra/Default/button_rectangle_depth_line.png  |   Bin 0 -> 399 bytes
 .../Default/button_rectangle_depth_line.png.meta   |   130 +
 .../PNG/Extra/Default/button_rectangle_line.png    |   Bin 0 -> 327 bytes
 .../Extra/Default/button_rectangle_line.png.meta   |   130 +
 .../PNG/Extra/Default/button_round_depth_line.png  |   Bin 0 -> 1462 bytes
 .../Extra/Default/button_round_depth_line.png.meta |   130 +
 .../PNG/Extra/Default/button_round_line.png        |   Bin 0 -> 1176 bytes
 .../PNG/Extra/Default/button_round_line.png.meta   |   130 +
 .../PNG/Extra/Default/button_square_depth_line.png |   Bin 0 -> 362 bytes
 .../Default/button_square_depth_line.png.meta      |   130 +
 .../PNG/Extra/Default/button_square_line.png       |   Bin 0 -> 292 bytes
 .../PNG/Extra/Default/button_square_line.png.meta  |   130 +
 .../kenney_ui-pack/PNG/Extra/Default/divider.png   |   Bin 0 -> 89 bytes
 .../PNG/Extra/Default/divider.png.meta             |   130 +
 .../PNG/Extra/Default/divider_edges.png            |   Bin 0 -> 121 bytes
 .../PNG/Extra/Default/divider_edges.png.meta       |   130 +
 .../PNG/Extra/Default/icon_arrow_down_dark.png     |   Bin 0 -> 237 bytes
 .../Extra/Default/icon_arrow_down_dark.png.meta    |   130 +
 .../PNG/Extra/Default/icon_arrow_down_light.png    |   Bin 0 -> 251 bytes
 .../Extra/Default/icon_arrow_down_light.png.meta   |   130 +
 .../PNG/Extra/Default/icon_arrow_down_outline.png  |   Bin 0 -> 357 bytes
 .../Extra/Default/icon_arrow_down_outline.png.meta |   130 +
 .../PNG/Extra/Default/icon_arrow_up_dark.png       |   Bin 0 -> 243 bytes
 .../PNG/Extra/Default/icon_arrow_up_dark.png.meta  |   130 +
 .../PNG/Extra/Default/icon_arrow_up_light.png      |   Bin 0 -> 276 bytes
 .../PNG/Extra/Default/icon_arrow_up_light.png.meta |   130 +
 .../PNG/Extra/Default/icon_arrow_up_outline.png    |   Bin 0 -> 358 bytes
 .../Extra/Default/icon_arrow_up_outline.png.meta   |   130 +
 .../PNG/Extra/Default/icon_play_dark.png           |   Bin 0 -> 323 bytes
 .../PNG/Extra/Default/icon_play_dark.png.meta      |   130 +
 .../PNG/Extra/Default/icon_play_light.png          |   Bin 0 -> 323 bytes
 .../PNG/Extra/Default/icon_play_light.png.meta     |   130 +
 .../PNG/Extra/Default/icon_play_outline.png        |   Bin 0 -> 489 bytes
 .../PNG/Extra/Default/icon_play_outline.png.meta   |   130 +
 .../PNG/Extra/Default/icon_repeat_dark.png         |   Bin 0 -> 435 bytes
 .../PNG/Extra/Default/icon_repeat_dark.png.meta    |   130 +
 .../PNG/Extra/Default/icon_repeat_light.png        |   Bin 0 -> 435 bytes
 .../PNG/Extra/Default/icon_repeat_light.png.meta   |   130 +
 .../PNG/Extra/Default/icon_repeat_outline.png      |   Bin 0 -> 694 bytes
 .../PNG/Extra/Default/icon_repeat_outline.png.meta |   130 +
 .../PNG/Extra/Default/input_outline_rectangle.png  |   Bin 0 -> 344 bytes
 .../Extra/Default/input_outline_rectangle.png.meta |   130 +
 .../PNG/Extra/Default/input_outline_square.png     |   Bin 0 -> 316 bytes
 .../Extra/Default/input_outline_square.png.meta    |   130 +
 .../PNG/Extra/Default/input_rectangle.png          |   Bin 0 -> 355 bytes
 .../PNG/Extra/Default/input_rectangle.png.meta     |   130 +
 .../PNG/Extra/Default/input_square.png             |   Bin 0 -> 319 bytes
 .../PNG/Extra/Default/input_square.png.meta        |   130 +
 .../NewUI/kenney_ui-pack/PNG/Extra/Double.meta     |     8 +
 .../Extra/Double/button_rectangle_depth_line.png   |   Bin 0 -> 791 bytes
 .../Double/button_rectangle_depth_line.png.meta    |   130 +
 .../PNG/Extra/Double/button_rectangle_line.png     |   Bin 0 -> 670 bytes
 .../Extra/Double/button_rectangle_line.png.meta    |   130 +
 .../PNG/Extra/Double/button_round_depth_line.png   |   Bin 0 -> 2793 bytes
 .../Extra/Double/button_round_depth_line.png.meta  |   130 +
 .../PNG/Extra/Double/button_round_line.png         |   Bin 0 -> 2208 bytes
 .../PNG/Extra/Double/button_round_line.png.meta    |   130 +
 .../PNG/Extra/Double/button_square_depth_line.png  |   Bin 0 -> 661 bytes
 .../Extra/Double/button_square_depth_line.png.meta |   130 +
 .../PNG/Extra/Double/button_square_line.png        |   Bin 0 -> 533 bytes
 .../PNG/Extra/Double/button_square_line.png.meta   |   130 +
 .../kenney_ui-pack/PNG/Extra/Double/divider.png    |   Bin 0 -> 108 bytes
 .../PNG/Extra/Double/divider.png.meta              |   130 +
 .../PNG/Extra/Double/divider_edges.png             |   Bin 0 -> 163 bytes
 .../PNG/Extra/Double/divider_edges.png.meta        |   130 +
 .../PNG/Extra/Double/icon_arrow_down_dark.png      |   Bin 0 -> 399 bytes
 .../PNG/Extra/Double/icon_arrow_down_dark.png.meta |   130 +
 .../PNG/Extra/Double/icon_arrow_down_light.png     |   Bin 0 -> 399 bytes
 .../Extra/Double/icon_arrow_down_light.png.meta    |   130 +
 .../PNG/Extra/Double/icon_arrow_down_outline.png   |   Bin 0 -> 592 bytes
 .../Extra/Double/icon_arrow_down_outline.png.meta  |   130 +
 .../PNG/Extra/Double/icon_arrow_up_dark.png        |   Bin 0 -> 404 bytes
 .../PNG/Extra/Double/icon_arrow_up_dark.png.meta   |   130 +
 .../PNG/Extra/Double/icon_arrow_up_light.png       |   Bin 0 -> 404 bytes
 .../PNG/Extra/Double/icon_arrow_up_light.png.meta  |   130 +
 .../PNG/Extra/Double/icon_arrow_up_outline.png     |   Bin 0 -> 561 bytes
 .../Extra/Double/icon_arrow_up_outline.png.meta    |   130 +
 .../PNG/Extra/Double/icon_play_dark.png            |   Bin 0 -> 489 bytes
 .../PNG/Extra/Double/icon_play_dark.png.meta       |   130 +
 .../PNG/Extra/Double/icon_play_light.png           |   Bin 0 -> 489 bytes
 .../PNG/Extra/Double/icon_play_light.png.meta      |   130 +
 .../PNG/Extra/Double/icon_play_outline.png         |   Bin 0 -> 832 bytes
 .../PNG/Extra/Double/icon_play_outline.png.meta    |   130 +
 .../PNG/Extra/Double/icon_repeat_dark.png          |   Bin 0 -> 733 bytes
 .../PNG/Extra/Double/icon_repeat_dark.png.meta     |   130 +
 .../PNG/Extra/Double/icon_repeat_light.png         |   Bin 0 -> 733 bytes
 .../PNG/Extra/Double/icon_repeat_light.png.meta    |   130 +
 .../PNG/Extra/Double/icon_repeat_outline.png       |   Bin 0 -> 1286 bytes
 .../PNG/Extra/Double/icon_repeat_outline.png.meta  |   130 +
 .../PNG/Extra/Double/input_outline_rectangle.png   |   Bin 0 -> 645 bytes
 .../Extra/Double/input_outline_rectangle.png.meta  |   130 +
 .../PNG/Extra/Double/input_outline_square.png      |   Bin 0 -> 528 bytes
 .../PNG/Extra/Double/input_outline_square.png.meta |   130 +
 .../PNG/Extra/Double/input_rectangle.png           |   Bin 0 -> 680 bytes
 .../PNG/Extra/Double/input_rectangle.png.meta      |   130 +
 .../PNG/Extra/Double/input_square.png              |   Bin 0 -> 563 bytes
 .../PNG/Extra/Double/input_square.png.meta         |   130 +
 .../textures/NewUI/kenney_ui-pack/PNG/Green.meta   |     8 +
 .../NewUI/kenney_ui-pack/PNG/Green/Default.meta    |     8 +
 .../PNG/Green/Default/arrow_basic_e.png            |   Bin 0 -> 422 bytes
 .../PNG/Green/Default/arrow_basic_e.png.meta       |   130 +
 .../PNG/Green/Default/arrow_basic_e_small.png      |   Bin 0 -> 378 bytes
 .../PNG/Green/Default/arrow_basic_e_small.png.meta |   130 +
 .../PNG/Green/Default/arrow_basic_n.png            |   Bin 0 -> 391 bytes
 .../PNG/Green/Default/arrow_basic_n.png.meta       |   130 +
 .../PNG/Green/Default/arrow_basic_n_small.png      |   Bin 0 -> 302 bytes
 .../PNG/Green/Default/arrow_basic_n_small.png.meta |   130 +
 .../PNG/Green/Default/arrow_basic_s.png            |   Bin 0 -> 414 bytes
 .../PNG/Green/Default/arrow_basic_s.png.meta       |   130 +
 .../PNG/Green/Default/arrow_basic_s_small.png      |   Bin 0 -> 332 bytes
 .../PNG/Green/Default/arrow_basic_s_small.png.meta |   130 +
 .../PNG/Green/Default/arrow_basic_w.png            |   Bin 0 -> 402 bytes
 .../PNG/Green/Default/arrow_basic_w.png.meta       |   130 +
 .../PNG/Green/Default/arrow_basic_w_small.png      |   Bin 0 -> 399 bytes
 .../PNG/Green/Default/arrow_basic_w_small.png.meta |   130 +
 .../PNG/Green/Default/arrow_decorative_e.png       |   Bin 0 -> 566 bytes
 .../PNG/Green/Default/arrow_decorative_e.png.meta  |   130 +
 .../PNG/Green/Default/arrow_decorative_e_small.png |   Bin 0 -> 459 bytes
 .../Default/arrow_decorative_e_small.png.meta      |   130 +
 .../PNG/Green/Default/arrow_decorative_n.png       |   Bin 0 -> 511 bytes
 .../PNG/Green/Default/arrow_decorative_n.png.meta  |   130 +
 .../PNG/Green/Default/arrow_decorative_n_small.png |   Bin 0 -> 405 bytes
 .../Default/arrow_decorative_n_small.png.meta      |   130 +
 .../PNG/Green/Default/arrow_decorative_s.png       |   Bin 0 -> 530 bytes
 .../PNG/Green/Default/arrow_decorative_s.png.meta  |   130 +
 .../PNG/Green/Default/arrow_decorative_s_small.png |   Bin 0 -> 424 bytes
 .../Default/arrow_decorative_s_small.png.meta      |   130 +
 .../PNG/Green/Default/arrow_decorative_w.png       |   Bin 0 -> 562 bytes
 .../PNG/Green/Default/arrow_decorative_w.png.meta  |   130 +
 .../PNG/Green/Default/arrow_decorative_w_small.png |   Bin 0 -> 484 bytes
 .../Default/arrow_decorative_w_small.png.meta      |   130 +
 .../PNG/Green/Default/button_rectangle_border.png  |   Bin 0 -> 338 bytes
 .../Green/Default/button_rectangle_border.png.meta |   130 +
 .../Default/button_rectangle_depth_border.png      |   Bin 0 -> 411 bytes
 .../Default/button_rectangle_depth_border.png.meta |   130 +
 .../Green/Default/button_rectangle_depth_flat.png  |   Bin 0 -> 383 bytes
 .../Default/button_rectangle_depth_flat.png.meta   |   130 +
 .../Green/Default/button_rectangle_depth_gloss.png |   Bin 0 -> 373 bytes
 .../Default/button_rectangle_depth_gloss.png.meta  |   130 +
 .../Default/button_rectangle_depth_gradient.png    |   Bin 0 -> 570 bytes
 .../button_rectangle_depth_gradient.png.meta       |   130 +
 .../Green/Default/button_rectangle_depth_line.png  |   Bin 0 -> 411 bytes
 .../Default/button_rectangle_depth_line.png.meta   |   130 +
 .../PNG/Green/Default/button_rectangle_flat.png    |   Bin 0 -> 314 bytes
 .../Green/Default/button_rectangle_flat.png.meta   |   130 +
 .../PNG/Green/Default/button_rectangle_gloss.png   |   Bin 0 -> 306 bytes
 .../Green/Default/button_rectangle_gloss.png.meta  |   130 +
 .../Green/Default/button_rectangle_gradient.png    |   Bin 0 -> 514 bytes
 .../Default/button_rectangle_gradient.png.meta     |   130 +
 .../PNG/Green/Default/button_rectangle_line.png    |   Bin 0 -> 338 bytes
 .../Green/Default/button_rectangle_line.png.meta   |   130 +
 .../PNG/Green/Default/button_round_border.png      |   Bin 0 -> 1487 bytes
 .../PNG/Green/Default/button_round_border.png.meta |   130 +
 .../Green/Default/button_round_depth_border.png    |   Bin 0 -> 1793 bytes
 .../Default/button_round_depth_border.png.meta     |   130 +
 .../PNG/Green/Default/button_round_depth_flat.png  |   Bin 0 -> 1301 bytes
 .../Green/Default/button_round_depth_flat.png.meta |   130 +
 .../PNG/Green/Default/button_round_depth_gloss.png |   Bin 0 -> 1209 bytes
 .../Default/button_round_depth_gloss.png.meta      |   130 +
 .../Green/Default/button_round_depth_gradient.png  |   Bin 0 -> 1438 bytes
 .../Default/button_round_depth_gradient.png.meta   |   130 +
 .../PNG/Green/Default/button_round_depth_line.png  |   Bin 0 -> 1690 bytes
 .../Green/Default/button_round_depth_line.png.meta |   130 +
 .../PNG/Green/Default/button_round_flat.png        |   Bin 0 -> 1023 bytes
 .../PNG/Green/Default/button_round_flat.png.meta   |   130 +
 .../PNG/Green/Default/button_round_gloss.png       |   Bin 0 -> 958 bytes
 .../PNG/Green/Default/button_round_gloss.png.meta  |   130 +
 .../PNG/Green/Default/button_round_gradient.png    |   Bin 0 -> 1165 bytes
 .../Green/Default/button_round_gradient.png.meta   |   130 +
 .../PNG/Green/Default/button_round_line.png        |   Bin 0 -> 1413 bytes
 .../PNG/Green/Default/button_round_line.png.meta   |   130 +
 .../PNG/Green/Default/button_square_border.png     |   Bin 0 -> 306 bytes
 .../Green/Default/button_square_border.png.meta    |   130 +
 .../Green/Default/button_square_depth_border.png   |   Bin 0 -> 375 bytes
 .../Default/button_square_depth_border.png.meta    |   130 +
 .../PNG/Green/Default/button_square_depth_flat.png |   Bin 0 -> 355 bytes
 .../Default/button_square_depth_flat.png.meta      |   130 +
 .../Green/Default/button_square_depth_gloss.png    |   Bin 0 -> 337 bytes
 .../Default/button_square_depth_gloss.png.meta     |   130 +
 .../Green/Default/button_square_depth_gradient.png |   Bin 0 -> 544 bytes
 .../Default/button_square_depth_gradient.png.meta  |   130 +
 .../PNG/Green/Default/button_square_depth_line.png |   Bin 0 -> 374 bytes
 .../Default/button_square_depth_line.png.meta      |   130 +
 .../PNG/Green/Default/button_square_flat.png       |   Bin 0 -> 286 bytes
 .../PNG/Green/Default/button_square_flat.png.meta  |   130 +
 .../PNG/Green/Default/button_square_gloss.png      |   Bin 0 -> 268 bytes
 .../PNG/Green/Default/button_square_gloss.png.meta |   130 +
 .../PNG/Green/Default/button_square_gradient.png   |   Bin 0 -> 488 bytes
 .../Green/Default/button_square_gradient.png.meta  |   130 +
 .../PNG/Green/Default/button_square_line.png       |   Bin 0 -> 304 bytes
 .../PNG/Green/Default/button_square_line.png.meta  |   130 +
 .../PNG/Green/Default/check_round_color.png        |   Bin 0 -> 579 bytes
 .../PNG/Green/Default/check_round_color.png.meta   |   130 +
 .../PNG/Green/Default/check_round_grey.png         |   Bin 0 -> 579 bytes
 .../PNG/Green/Default/check_round_grey.png.meta    |   130 +
 .../PNG/Green/Default/check_round_grey_circle.png  |   Bin 0 -> 774 bytes
 .../Green/Default/check_round_grey_circle.png.meta |   130 +
 .../PNG/Green/Default/check_round_round_circle.png |   Bin 0 -> 772 bytes
 .../Default/check_round_round_circle.png.meta      |   130 +
 .../PNG/Green/Default/check_square_color.png       |   Bin 0 -> 280 bytes
 .../PNG/Green/Default/check_square_color.png.meta  |   130 +
 .../Green/Default/check_square_color_checkmark.png |   Bin 0 -> 555 bytes
 .../Default/check_square_color_checkmark.png.meta  |   130 +
 .../PNG/Green/Default/check_square_color_cross.png |   Bin 0 -> 533 bytes
 .../Default/check_square_color_cross.png.meta      |   130 +
 .../Green/Default/check_square_color_square.png    |   Bin 0 -> 319 bytes
 .../Default/check_square_color_square.png.meta     |   130 +
 .../PNG/Green/Default/check_square_grey.png        |   Bin 0 -> 280 bytes
 .../PNG/Green/Default/check_square_grey.png.meta   |   130 +
 .../Green/Default/check_square_grey_checkmark.png  |   Bin 0 -> 559 bytes
 .../Default/check_square_grey_checkmark.png.meta   |   130 +
 .../PNG/Green/Default/check_square_grey_cross.png  |   Bin 0 -> 539 bytes
 .../Green/Default/check_square_grey_cross.png.meta |   130 +
 .../PNG/Green/Default/check_square_grey_square.png |   Bin 0 -> 321 bytes
 .../Default/check_square_grey_square.png.meta      |   130 +
 .../PNG/Green/Default/icon_checkmark.png           |   Bin 0 -> 377 bytes
 .../PNG/Green/Default/icon_checkmark.png.meta      |   130 +
 .../PNG/Green/Default/icon_circle.png              |   Bin 0 -> 312 bytes
 .../PNG/Green/Default/icon_circle.png.meta         |   130 +
 .../PNG/Green/Default/icon_cross.png               |   Bin 0 -> 350 bytes
 .../PNG/Green/Default/icon_cross.png.meta          |   130 +
 .../PNG/Green/Default/icon_outline_checkmark.png   |   Bin 0 -> 377 bytes
 .../Green/Default/icon_outline_checkmark.png.meta  |   130 +
 .../PNG/Green/Default/icon_outline_circle.png      |   Bin 0 -> 312 bytes
 .../PNG/Green/Default/icon_outline_circle.png.meta |   130 +
 .../PNG/Green/Default/icon_outline_cross.png       |   Bin 0 -> 351 bytes
 .../PNG/Green/Default/icon_outline_cross.png.meta  |   130 +
 .../PNG/Green/Default/icon_outline_square.png      |   Bin 0 -> 135 bytes
 .../PNG/Green/Default/icon_outline_square.png.meta |   130 +
 .../PNG/Green/Default/icon_square.png              |   Bin 0 -> 137 bytes
 .../PNG/Green/Default/icon_square.png.meta         |   130 +
 .../PNG/Green/Default/slide_hangle.png             |   Bin 0 -> 295 bytes
 .../PNG/Green/Default/slide_hangle.png.meta        |   130 +
 .../PNG/Green/Default/slide_horizontal_color.png   |   Bin 0 -> 383 bytes
 .../Green/Default/slide_horizontal_color.png.meta  |   130 +
 .../Default/slide_horizontal_color_section.png     |   Bin 0 -> 321 bytes
 .../slide_horizontal_color_section.png.meta        |   130 +
 .../slide_horizontal_color_section_wide.png        |   Bin 0 -> 336 bytes
 .../slide_horizontal_color_section_wide.png.meta   |   130 +
 .../PNG/Green/Default/slide_horizontal_grey.png    |   Bin 0 -> 383 bytes
 .../Green/Default/slide_horizontal_grey.png.meta   |   130 +
 .../Default/slide_horizontal_grey_section.png      |   Bin 0 -> 321 bytes
 .../Default/slide_horizontal_grey_section.png.meta |   130 +
 .../Default/slide_horizontal_grey_section_wide.png |   Bin 0 -> 336 bytes
 .../slide_horizontal_grey_section_wide.png.meta    |   130 +
 .../PNG/Green/Default/slide_vertical_color.png     |   Bin 0 -> 379 bytes
 .../Green/Default/slide_vertical_color.png.meta    |   130 +
 .../Green/Default/slide_vertical_color_section.png |   Bin 0 -> 308 bytes
 .../Default/slide_vertical_color_section.png.meta  |   130 +
 .../Default/slide_vertical_color_section_wide.png  |   Bin 0 -> 316 bytes
 .../slide_vertical_color_section_wide.png.meta     |   130 +
 .../PNG/Green/Default/slide_vertical_grey.png      |   Bin 0 -> 379 bytes
 .../PNG/Green/Default/slide_vertical_grey.png.meta |   130 +
 .../Green/Default/slide_vertical_grey_section.png  |   Bin 0 -> 308 bytes
 .../Default/slide_vertical_grey_section.png.meta   |   130 +
 .../Default/slide_vertical_grey_section_wide.png   |   Bin 0 -> 316 bytes
 .../slide_vertical_grey_section_wide.png.meta      |   130 +
 .../kenney_ui-pack/PNG/Green/Default/star.png      |   Bin 0 -> 1523 bytes
 .../kenney_ui-pack/PNG/Green/Default/star.png.meta |   130 +
 .../PNG/Green/Default/star_outline.png             |   Bin 0 -> 955 bytes
 .../PNG/Green/Default/star_outline.png.meta        |   130 +
 .../PNG/Green/Default/star_outline_depth.png       |   Bin 0 -> 1168 bytes
 .../PNG/Green/Default/star_outline_depth.png.meta  |   130 +
 .../NewUI/kenney_ui-pack/PNG/Green/Double.meta     |     8 +
 .../PNG/Green/Double/arrow_basic_e.png             |   Bin 0 -> 637 bytes
 .../PNG/Green/Double/arrow_basic_e.png.meta        |   130 +
 .../PNG/Green/Double/arrow_basic_e_small.png       |   Bin 0 -> 523 bytes
 .../PNG/Green/Double/arrow_basic_e_small.png.meta  |   130 +
 .../PNG/Green/Double/arrow_basic_n.png             |   Bin 0 -> 623 bytes
 .../PNG/Green/Double/arrow_basic_n.png.meta        |   130 +
 .../PNG/Green/Double/arrow_basic_n_small.png       |   Bin 0 -> 472 bytes
 .../PNG/Green/Double/arrow_basic_n_small.png.meta  |   130 +
 .../PNG/Green/Double/arrow_basic_s.png             |   Bin 0 -> 694 bytes
 .../PNG/Green/Double/arrow_basic_s.png.meta        |   130 +
 .../PNG/Green/Double/arrow_basic_s_small.png       |   Bin 0 -> 533 bytes
 .../PNG/Green/Double/arrow_basic_s_small.png.meta  |   130 +
 .../PNG/Green/Double/arrow_basic_w.png             |   Bin 0 -> 639 bytes
 .../PNG/Green/Double/arrow_basic_w.png.meta        |   130 +
 .../PNG/Green/Double/arrow_basic_w_small.png       |   Bin 0 -> 550 bytes
 .../PNG/Green/Double/arrow_basic_w_small.png.meta  |   130 +
 .../PNG/Green/Double/arrow_decorative_e.png        |   Bin 0 -> 860 bytes
 .../PNG/Green/Double/arrow_decorative_e.png.meta   |   130 +
 .../PNG/Green/Double/arrow_decorative_e_small.png  |   Bin 0 -> 697 bytes
 .../Green/Double/arrow_decorative_e_small.png.meta |   130 +
 .../PNG/Green/Double/arrow_decorative_n.png        |   Bin 0 -> 880 bytes
 .../PNG/Green/Double/arrow_decorative_n.png.meta   |   130 +
 .../PNG/Green/Double/arrow_decorative_n_small.png  |   Bin 0 -> 649 bytes
 .../Green/Double/arrow_decorative_n_small.png.meta |   130 +
 .../PNG/Green/Double/arrow_decorative_s.png        |   Bin 0 -> 951 bytes
 .../PNG/Green/Double/arrow_decorative_s.png.meta   |   130 +
 .../PNG/Green/Double/arrow_decorative_s_small.png  |   Bin 0 -> 684 bytes
 .../Green/Double/arrow_decorative_s_small.png.meta |   130 +
 .../PNG/Green/Double/arrow_decorative_w.png        |   Bin 0 -> 901 bytes
 .../PNG/Green/Double/arrow_decorative_w.png.meta   |   130 +
 .../PNG/Green/Double/arrow_decorative_w_small.png  |   Bin 0 -> 721 bytes
 .../Green/Double/arrow_decorative_w_small.png.meta |   130 +
 .../PNG/Green/Double/button_rectangle_border.png   |   Bin 0 -> 693 bytes
 .../Green/Double/button_rectangle_border.png.meta  |   130 +
 .../Green/Double/button_rectangle_depth_border.png |   Bin 0 -> 821 bytes
 .../Double/button_rectangle_depth_border.png.meta  |   130 +
 .../Green/Double/button_rectangle_depth_flat.png   |   Bin 0 -> 785 bytes
 .../Double/button_rectangle_depth_flat.png.meta    |   130 +
 .../Green/Double/button_rectangle_depth_gloss.png  |   Bin 0 -> 748 bytes
 .../Double/button_rectangle_depth_gloss.png.meta   |   130 +
 .../Double/button_rectangle_depth_gradient.png     |   Bin 0 -> 1056 bytes
 .../button_rectangle_depth_gradient.png.meta       |   130 +
 .../Green/Double/button_rectangle_depth_line.png   |   Bin 0 -> 817 bytes
 .../Double/button_rectangle_depth_line.png.meta    |   130 +
 .../PNG/Green/Double/button_rectangle_flat.png     |   Bin 0 -> 660 bytes
 .../Green/Double/button_rectangle_flat.png.meta    |   130 +
 .../PNG/Green/Double/button_rectangle_gloss.png    |   Bin 0 -> 623 bytes
 .../Green/Double/button_rectangle_gloss.png.meta   |   130 +
 .../PNG/Green/Double/button_rectangle_gradient.png |   Bin 0 -> 959 bytes
 .../Double/button_rectangle_gradient.png.meta      |   130 +
 .../PNG/Green/Double/button_rectangle_line.png     |   Bin 0 -> 688 bytes
 .../Green/Double/button_rectangle_line.png.meta    |   130 +
 .../PNG/Green/Double/button_round_border.png       |   Bin 0 -> 2794 bytes
 .../PNG/Green/Double/button_round_border.png.meta  |   130 +
 .../PNG/Green/Double/button_round_depth_border.png |   Bin 0 -> 3367 bytes
 .../Double/button_round_depth_border.png.meta      |   130 +
 .../PNG/Green/Double/button_round_depth_flat.png   |   Bin 0 -> 2476 bytes
 .../Green/Double/button_round_depth_flat.png.meta  |   130 +
 .../PNG/Green/Double/button_round_depth_gloss.png  |   Bin 0 -> 2263 bytes
 .../Green/Double/button_round_depth_gloss.png.meta |   130 +
 .../Green/Double/button_round_depth_gradient.png   |   Bin 0 -> 2661 bytes
 .../Double/button_round_depth_gradient.png.meta    |   130 +
 .../PNG/Green/Double/button_round_depth_line.png   |   Bin 0 -> 3231 bytes
 .../Green/Double/button_round_depth_line.png.meta  |   130 +
 .../PNG/Green/Double/button_round_flat.png         |   Bin 0 -> 1863 bytes
 .../PNG/Green/Double/button_round_flat.png.meta    |   130 +
 .../PNG/Green/Double/button_round_gloss.png        |   Bin 0 -> 1735 bytes
 .../PNG/Green/Double/button_round_gloss.png.meta   |   130 +
 .../PNG/Green/Double/button_round_gradient.png     |   Bin 0 -> 2149 bytes
 .../Green/Double/button_round_gradient.png.meta    |   130 +
 .../PNG/Green/Double/button_round_line.png         |   Bin 0 -> 2669 bytes
 .../PNG/Green/Double/button_round_line.png.meta    |   130 +
 .../PNG/Green/Double/button_square_border.png      |   Bin 0 -> 544 bytes
 .../PNG/Green/Double/button_square_border.png.meta |   130 +
 .../Green/Double/button_square_depth_border.png    |   Bin 0 -> 685 bytes
 .../Double/button_square_depth_border.png.meta     |   130 +
 .../PNG/Green/Double/button_square_depth_flat.png  |   Bin 0 -> 652 bytes
 .../Green/Double/button_square_depth_flat.png.meta |   130 +
 .../PNG/Green/Double/button_square_depth_gloss.png |   Bin 0 -> 630 bytes
 .../Double/button_square_depth_gloss.png.meta      |   130 +
 .../Green/Double/button_square_depth_gradient.png  |   Bin 0 -> 926 bytes
 .../Double/button_square_depth_gradient.png.meta   |   130 +
 .../PNG/Green/Double/button_square_depth_line.png  |   Bin 0 -> 684 bytes
 .../Green/Double/button_square_depth_line.png.meta |   130 +
 .../PNG/Green/Double/button_square_flat.png        |   Bin 0 -> 523 bytes
 .../PNG/Green/Double/button_square_flat.png.meta   |   130 +
 .../PNG/Green/Double/button_square_gloss.png       |   Bin 0 -> 502 bytes
 .../PNG/Green/Double/button_square_gloss.png.meta  |   130 +
 .../PNG/Green/Double/button_square_gradient.png    |   Bin 0 -> 814 bytes
 .../Green/Double/button_square_gradient.png.meta   |   130 +
 .../PNG/Green/Double/button_square_line.png        |   Bin 0 -> 541 bytes
 .../PNG/Green/Double/button_square_line.png.meta   |   130 +
 .../PNG/Green/Double/check_round_color.png         |   Bin 0 -> 1040 bytes
 .../PNG/Green/Double/check_round_color.png.meta    |   130 +
 .../PNG/Green/Double/check_round_grey.png          |   Bin 0 -> 1041 bytes
 .../PNG/Green/Double/check_round_grey.png.meta     |   130 +
 .../PNG/Green/Double/check_round_grey_circle.png   |   Bin 0 -> 1386 bytes
 .../Green/Double/check_round_grey_circle.png.meta  |   130 +
 .../PNG/Green/Double/check_round_round_circle.png  |   Bin 0 -> 1382 bytes
 .../Green/Double/check_round_round_circle.png.meta |   130 +
 .../PNG/Green/Double/check_square_color.png        |   Bin 0 -> 466 bytes
 .../PNG/Green/Double/check_square_color.png.meta   |   130 +
 .../Green/Double/check_square_color_checkmark.png  |   Bin 0 -> 955 bytes
 .../Double/check_square_color_checkmark.png.meta   |   130 +
 .../PNG/Green/Double/check_square_color_cross.png  |   Bin 0 -> 907 bytes
 .../Green/Double/check_square_color_cross.png.meta |   130 +
 .../PNG/Green/Double/check_square_color_square.png |   Bin 0 -> 536 bytes
 .../Double/check_square_color_square.png.meta      |   130 +
 .../PNG/Green/Double/check_square_grey.png         |   Bin 0 -> 466 bytes
 .../PNG/Green/Double/check_square_grey.png.meta    |   130 +
 .../Green/Double/check_square_grey_checkmark.png   |   Bin 0 -> 958 bytes
 .../Double/check_square_grey_checkmark.png.meta    |   130 +
 .../PNG/Green/Double/check_square_grey_cross.png   |   Bin 0 -> 908 bytes
 .../Green/Double/check_square_grey_cross.png.meta  |   130 +
 .../PNG/Green/Double/check_square_grey_square.png  |   Bin 0 -> 538 bytes
 .../Green/Double/check_square_grey_square.png.meta |   130 +
 .../PNG/Green/Double/icon_checkmark.png            |   Bin 0 -> 585 bytes
 .../PNG/Green/Double/icon_checkmark.png.meta       |   130 +
 .../PNG/Green/Double/icon_circle.png               |   Bin 0 -> 465 bytes
 .../PNG/Green/Double/icon_circle.png.meta          |   130 +
 .../kenney_ui-pack/PNG/Green/Double/icon_cross.png |   Bin 0 -> 516 bytes
 .../PNG/Green/Double/icon_cross.png.meta           |   130 +
 .../PNG/Green/Double/icon_outline_checkmark.png    |   Bin 0 -> 585 bytes
 .../Green/Double/icon_outline_checkmark.png.meta   |   130 +
 .../PNG/Green/Double/icon_outline_circle.png       |   Bin 0 -> 466 bytes
 .../PNG/Green/Double/icon_outline_circle.png.meta  |   130 +
 .../PNG/Green/Double/icon_outline_cross.png        |   Bin 0 -> 516 bytes
 .../PNG/Green/Double/icon_outline_cross.png.meta   |   130 +
 .../PNG/Green/Double/icon_outline_square.png       |   Bin 0 -> 183 bytes
 .../PNG/Green/Double/icon_outline_square.png.meta  |   130 +
 .../PNG/Green/Double/icon_square.png               |   Bin 0 -> 183 bytes
 .../PNG/Green/Double/icon_square.png.meta          |   130 +
 .../PNG/Green/Double/slide_hangle.png              |   Bin 0 -> 440 bytes
 .../PNG/Green/Double/slide_hangle.png.meta         |   130 +
 .../PNG/Green/Double/slide_horizontal_color.png    |   Bin 0 -> 614 bytes
 .../Green/Double/slide_horizontal_color.png.meta   |   130 +
 .../Double/slide_horizontal_color_section.png      |   Bin 0 -> 431 bytes
 .../Double/slide_horizontal_color_section.png.meta |   130 +
 .../Double/slide_horizontal_color_section_wide.png |   Bin 0 -> 439 bytes
 .../slide_horizontal_color_section_wide.png.meta   |   130 +
 .../PNG/Green/Double/slide_horizontal_grey.png     |   Bin 0 -> 614 bytes
 .../Green/Double/slide_horizontal_grey.png.meta    |   130 +
 .../Green/Double/slide_horizontal_grey_section.png |   Bin 0 -> 430 bytes
 .../Double/slide_horizontal_grey_section.png.meta  |   130 +
 .../Double/slide_horizontal_grey_section_wide.png  |   Bin 0 -> 439 bytes
 .../slide_horizontal_grey_section_wide.png.meta    |   130 +
 .../PNG/Green/Double/slide_vertical_color.png      |   Bin 0 -> 611 bytes
 .../PNG/Green/Double/slide_vertical_color.png.meta |   130 +
 .../Green/Double/slide_vertical_color_section.png  |   Bin 0 -> 461 bytes
 .../Double/slide_vertical_color_section.png.meta   |   130 +
 .../Double/slide_vertical_color_section_wide.png   |   Bin 0 -> 474 bytes
 .../slide_vertical_color_section_wide.png.meta     |   130 +
 .../PNG/Green/Double/slide_vertical_grey.png       |   Bin 0 -> 611 bytes
 .../PNG/Green/Double/slide_vertical_grey.png.meta  |   130 +
 .../Green/Double/slide_vertical_grey_section.png   |   Bin 0 -> 461 bytes
 .../Double/slide_vertical_grey_section.png.meta    |   130 +
 .../Double/slide_vertical_grey_section_wide.png    |   Bin 0 -> 473 bytes
 .../slide_vertical_grey_section_wide.png.meta      |   130 +
 .../NewUI/kenney_ui-pack/PNG/Green/Double/star.png |   Bin 0 -> 2855 bytes
 .../kenney_ui-pack/PNG/Green/Double/star.png.meta  |   130 +
 .../PNG/Green/Double/star_outline.png              |   Bin 0 -> 1800 bytes
 .../PNG/Green/Double/star_outline.png.meta         |   130 +
 .../PNG/Green/Double/star_outline_depth.png        |   Bin 0 -> 2141 bytes
 .../PNG/Green/Double/star_outline_depth.png.meta   |   130 +
 .../textures/NewUI/kenney_ui-pack/PNG/Grey.meta    |     8 +
 .../NewUI/kenney_ui-pack/PNG/Grey/Default.meta     |     8 +
 .../PNG/Grey/Default/arrow_basic_e.png             |   Bin 0 -> 422 bytes
 .../PNG/Grey/Default/arrow_basic_e.png.meta        |   130 +
 .../PNG/Grey/Default/arrow_basic_e_small.png       |   Bin 0 -> 378 bytes
 .../PNG/Grey/Default/arrow_basic_e_small.png.meta  |   130 +
 .../PNG/Grey/Default/arrow_basic_n.png             |   Bin 0 -> 388 bytes
 .../PNG/Grey/Default/arrow_basic_n.png.meta        |   130 +
 .../PNG/Grey/Default/arrow_basic_n_small.png       |   Bin 0 -> 302 bytes
 .../PNG/Grey/Default/arrow_basic_n_small.png.meta  |   130 +
 .../PNG/Grey/Default/arrow_basic_s.png             |   Bin 0 -> 411 bytes
 .../PNG/Grey/Default/arrow_basic_s.png.meta        |   130 +
 .../PNG/Grey/Default/arrow_basic_s_small.png       |   Bin 0 -> 332 bytes
 .../PNG/Grey/Default/arrow_basic_s_small.png.meta  |   130 +
 .../PNG/Grey/Default/arrow_basic_w.png             |   Bin 0 -> 402 bytes
 .../PNG/Grey/Default/arrow_basic_w.png.meta        |   130 +
 .../PNG/Grey/Default/arrow_basic_w_small.png       |   Bin 0 -> 399 bytes
 .../PNG/Grey/Default/arrow_basic_w_small.png.meta  |   130 +
 .../PNG/Grey/Default/arrow_decorative_e.png        |   Bin 0 -> 563 bytes
 .../PNG/Grey/Default/arrow_decorative_e.png.meta   |   130 +
 .../PNG/Grey/Default/arrow_decorative_e_small.png  |   Bin 0 -> 455 bytes
 .../Grey/Default/arrow_decorative_e_small.png.meta |   130 +
 .../PNG/Grey/Default/arrow_decorative_n.png        |   Bin 0 -> 511 bytes
 .../PNG/Grey/Default/arrow_decorative_n.png.meta   |   130 +
 .../PNG/Grey/Default/arrow_decorative_n_small.png  |   Bin 0 -> 402 bytes
 .../Grey/Default/arrow_decorative_n_small.png.meta |   130 +
 .../PNG/Grey/Default/arrow_decorative_s.png        |   Bin 0 -> 530 bytes
 .../PNG/Grey/Default/arrow_decorative_s.png.meta   |   130 +
 .../PNG/Grey/Default/arrow_decorative_s_small.png  |   Bin 0 -> 424 bytes
 .../Grey/Default/arrow_decorative_s_small.png.meta |   130 +
 .../PNG/Grey/Default/arrow_decorative_w.png        |   Bin 0 -> 559 bytes
 .../PNG/Grey/Default/arrow_decorative_w.png.meta   |   130 +
 .../PNG/Grey/Default/arrow_decorative_w_small.png  |   Bin 0 -> 479 bytes
 .../Grey/Default/arrow_decorative_w_small.png.meta |   130 +
 .../PNG/Grey/Default/button_rectangle_border.png   |   Bin 0 -> 335 bytes
 .../Grey/Default/button_rectangle_border.png.meta  |   130 +
 .../Grey/Default/button_rectangle_depth_border.png |   Bin 0 -> 408 bytes
 .../Default/button_rectangle_depth_border.png.meta |   130 +
 .../Grey/Default/button_rectangle_depth_flat.png   |   Bin 0 -> 383 bytes
 .../Default/button_rectangle_depth_flat.png.meta   |   130 +
 .../Grey/Default/button_rectangle_depth_gloss.png  |   Bin 0 -> 373 bytes
 .../Default/button_rectangle_depth_gloss.png.meta  |   130 +
 .../Default/button_rectangle_depth_gradient.png    |   Bin 0 -> 623 bytes
 .../button_rectangle_depth_gradient.png.meta       |   130 +
 .../Grey/Default/button_rectangle_depth_line.png   |   Bin 0 -> 409 bytes
 .../Default/button_rectangle_depth_line.png.meta   |   130 +
 .../PNG/Grey/Default/button_rectangle_flat.png     |   Bin 0 -> 315 bytes
 .../Grey/Default/button_rectangle_flat.png.meta    |   130 +
 .../PNG/Grey/Default/button_rectangle_gloss.png    |   Bin 0 -> 306 bytes
 .../Grey/Default/button_rectangle_gloss.png.meta   |   130 +
 .../PNG/Grey/Default/button_rectangle_gradient.png |   Bin 0 -> 574 bytes
 .../Default/button_rectangle_gradient.png.meta     |   130 +
 .../PNG/Grey/Default/button_rectangle_line.png     |   Bin 0 -> 335 bytes
 .../Grey/Default/button_rectangle_line.png.meta    |   130 +
 .../PNG/Grey/Default/button_round_border.png       |   Bin 0 -> 1280 bytes
 .../PNG/Grey/Default/button_round_border.png.meta  |   130 +
 .../PNG/Grey/Default/button_round_depth_border.png |   Bin 0 -> 1580 bytes
 .../Default/button_round_depth_border.png.meta     |   130 +
 .../PNG/Grey/Default/button_round_depth_flat.png   |   Bin 0 -> 1295 bytes
 .../Grey/Default/button_round_depth_flat.png.meta  |   130 +
 .../PNG/Grey/Default/button_round_depth_gloss.png  |   Bin 0 -> 1206 bytes
 .../Grey/Default/button_round_depth_gloss.png.meta |   130 +
 .../Grey/Default/button_round_depth_gradient.png   |   Bin 0 -> 1516 bytes
 .../Default/button_round_depth_gradient.png.meta   |   130 +
 .../PNG/Grey/Default/button_round_depth_line.png   |   Bin 0 -> 1681 bytes
 .../Grey/Default/button_round_depth_line.png.meta  |   130 +
 .../PNG/Grey/Default/button_round_flat.png         |   Bin 0 -> 1018 bytes
 .../PNG/Grey/Default/button_round_flat.png.meta    |   130 +
 .../PNG/Grey/Default/button_round_gloss.png        |   Bin 0 -> 953 bytes
 .../PNG/Grey/Default/button_round_gloss.png.meta   |   130 +
 .../PNG/Grey/Default/button_round_gradient.png     |   Bin 0 -> 1229 bytes
 .../Grey/Default/button_round_gradient.png.meta    |   130 +
 .../PNG/Grey/Default/button_round_line.png         |   Bin 0 -> 1401 bytes
 .../PNG/Grey/Default/button_round_line.png.meta    |   130 +
 .../PNG/Grey/Default/button_square_border.png      |   Bin 0 -> 302 bytes
 .../PNG/Grey/Default/button_square_border.png.meta |   130 +
 .../Grey/Default/button_square_depth_border.png    |   Bin 0 -> 373 bytes
 .../Default/button_square_depth_border.png.meta    |   130 +
 .../PNG/Grey/Default/button_square_depth_flat.png  |   Bin 0 -> 355 bytes
 .../Grey/Default/button_square_depth_flat.png.meta |   130 +
 .../PNG/Grey/Default/button_square_depth_gloss.png |   Bin 0 -> 337 bytes
 .../Default/button_square_depth_gloss.png.meta     |   130 +
 .../Grey/Default/button_square_depth_gradient.png  |   Bin 0 -> 596 bytes
 .../Default/button_square_depth_gradient.png.meta  |   130 +
 .../PNG/Grey/Default/button_square_depth_line.png  |   Bin 0 -> 372 bytes
 .../Grey/Default/button_square_depth_line.png.meta |   130 +
 .../PNG/Grey/Default/button_square_flat.png        |   Bin 0 -> 286 bytes
 .../PNG/Grey/Default/button_square_flat.png.meta   |   130 +
 .../PNG/Grey/Default/button_square_gloss.png       |   Bin 0 -> 268 bytes
 .../PNG/Grey/Default/button_square_gloss.png.meta  |   130 +
 .../PNG/Grey/Default/button_square_gradient.png    |   Bin 0 -> 536 bytes
 .../Grey/Default/button_square_gradient.png.meta   |   130 +
 .../PNG/Grey/Default/button_square_line.png        |   Bin 0 -> 302 bytes
 .../PNG/Grey/Default/button_square_line.png.meta   |   130 +
 .../PNG/Grey/Default/check_round_color.png         |   Bin 0 -> 573 bytes
 .../PNG/Grey/Default/check_round_color.png.meta    |   130 +
 .../PNG/Grey/Default/check_round_grey.png          |   Bin 0 -> 579 bytes
 .../PNG/Grey/Default/check_round_grey.png.meta     |   130 +
 .../PNG/Grey/Default/check_round_grey_circle.png   |   Bin 0 -> 771 bytes
 .../Grey/Default/check_round_grey_circle.png.meta  |   130 +
 .../PNG/Grey/Default/check_round_round_circle.png  |   Bin 0 -> 672 bytes
 .../Grey/Default/check_round_round_circle.png.meta |   130 +
 .../PNG/Grey/Default/check_square_color.png        |   Bin 0 -> 280 bytes
 .../PNG/Grey/Default/check_square_color.png.meta   |   130 +
 .../Grey/Default/check_square_color_checkmark.png  |   Bin 0 -> 518 bytes
 .../Default/check_square_color_checkmark.png.meta  |   130 +
 .../PNG/Grey/Default/check_square_color_cross.png  |   Bin 0 -> 511 bytes
 .../Grey/Default/check_square_color_cross.png.meta |   130 +
 .../PNG/Grey/Default/check_square_color_square.png |   Bin 0 -> 316 bytes
 .../Default/check_square_color_square.png.meta     |   130 +
 .../PNG/Grey/Default/check_square_grey.png         |   Bin 0 -> 280 bytes
 .../PNG/Grey/Default/check_square_grey.png.meta    |   130 +
 .../Grey/Default/check_square_grey_checkmark.png   |   Bin 0 -> 556 bytes
 .../Default/check_square_grey_checkmark.png.meta   |   130 +
 .../PNG/Grey/Default/check_square_grey_cross.png   |   Bin 0 -> 533 bytes
 .../Grey/Default/check_square_grey_cross.png.meta  |   130 +
 .../PNG/Grey/Default/check_square_grey_square.png  |   Bin 0 -> 319 bytes
 .../Grey/Default/check_square_grey_square.png.meta |   130 +
 .../PNG/Grey/Default/icon_checkmark.png            |   Bin 0 -> 377 bytes
 .../PNG/Grey/Default/icon_checkmark.png.meta       |   130 +
 .../PNG/Grey/Default/icon_circle.png               |   Bin 0 -> 313 bytes
 .../PNG/Grey/Default/icon_circle.png.meta          |   130 +
 .../kenney_ui-pack/PNG/Grey/Default/icon_cross.png |   Bin 0 -> 350 bytes
 .../PNG/Grey/Default/icon_cross.png.meta           |   130 +
 .../PNG/Grey/Default/icon_outline_checkmark.png    |   Bin 0 -> 377 bytes
 .../Grey/Default/icon_outline_checkmark.png.meta   |   130 +
 .../PNG/Grey/Default/icon_outline_circle.png       |   Bin 0 -> 313 bytes
 .../PNG/Grey/Default/icon_outline_circle.png.meta  |   130 +
 .../PNG/Grey/Default/icon_outline_cross.png        |   Bin 0 -> 350 bytes
 .../PNG/Grey/Default/icon_outline_cross.png.meta   |   130 +
 .../PNG/Grey/Default/icon_outline_square.png       |   Bin 0 -> 135 bytes
 .../PNG/Grey/Default/icon_outline_square.png.meta  |   130 +
 .../PNG/Grey/Default/icon_square.png               |   Bin 0 -> 142 bytes
 .../PNG/Grey/Default/icon_square.png.meta          |   130 +
 .../PNG/Grey/Default/slide_hangle.png              |   Bin 0 -> 295 bytes
 .../PNG/Grey/Default/slide_hangle.png.meta         |   130 +
 .../PNG/Grey/Default/slide_horizontal_color.png    |   Bin 0 -> 383 bytes
 .../Grey/Default/slide_horizontal_color.png.meta   |   130 +
 .../Default/slide_horizontal_color_section.png     |   Bin 0 -> 321 bytes
 .../slide_horizontal_color_section.png.meta        |   130 +
 .../slide_horizontal_color_section_wide.png        |   Bin 0 -> 336 bytes
 .../slide_horizontal_color_section_wide.png.meta   |   130 +
 .../PNG/Grey/Default/slide_horizontal_grey.png     |   Bin 0 -> 383 bytes
 .../Grey/Default/slide_horizontal_grey.png.meta    |   130 +
 .../Grey/Default/slide_horizontal_grey_section.png |   Bin 0 -> 321 bytes
 .../Default/slide_horizontal_grey_section.png.meta |   130 +
 .../Default/slide_horizontal_grey_section_wide.png |   Bin 0 -> 336 bytes
 .../slide_horizontal_grey_section_wide.png.meta    |   130 +
 .../PNG/Grey/Default/slide_vertical_color.png      |   Bin 0 -> 379 bytes
 .../PNG/Grey/Default/slide_vertical_color.png.meta |   130 +
 .../Grey/Default/slide_vertical_color_section.png  |   Bin 0 -> 308 bytes
 .../Default/slide_vertical_color_section.png.meta  |   130 +
 .../Default/slide_vertical_color_section_wide.png  |   Bin 0 -> 316 bytes
 .../slide_vertical_color_section_wide.png.meta     |   130 +
 .../PNG/Grey/Default/slide_vertical_grey.png       |   Bin 0 -> 379 bytes
 .../PNG/Grey/Default/slide_vertical_grey.png.meta  |   130 +
 .../Grey/Default/slide_vertical_grey_section.png   |   Bin 0 -> 308 bytes
 .../Default/slide_vertical_grey_section.png.meta   |   130 +
 .../Default/slide_vertical_grey_section_wide.png   |   Bin 0 -> 316 bytes
 .../slide_vertical_grey_section_wide.png.meta      |   130 +
 .../NewUI/kenney_ui-pack/PNG/Grey/Default/star.png |   Bin 0 -> 1566 bytes
 .../kenney_ui-pack/PNG/Grey/Default/star.png.meta  |   130 +
 .../PNG/Grey/Default/star_outline.png              |   Bin 0 -> 955 bytes
 .../PNG/Grey/Default/star_outline.png.meta         |   130 +
 .../PNG/Grey/Default/star_outline_depth.png        |   Bin 0 -> 1168 bytes
 .../PNG/Grey/Default/star_outline_depth.png.meta   |   130 +
 .../NewUI/kenney_ui-pack/PNG/Grey/Double.meta      |     8 +
 .../PNG/Grey/Double/arrow_basic_e.png              |   Bin 0 -> 637 bytes
 .../PNG/Grey/Double/arrow_basic_e.png.meta         |   130 +
 .../PNG/Grey/Double/arrow_basic_e_small.png        |   Bin 0 -> 523 bytes
 .../PNG/Grey/Double/arrow_basic_e_small.png.meta   |   130 +
 .../PNG/Grey/Double/arrow_basic_n.png              |   Bin 0 -> 622 bytes
 .../PNG/Grey/Double/arrow_basic_n.png.meta         |   130 +
 .../PNG/Grey/Double/arrow_basic_n_small.png        |   Bin 0 -> 471 bytes
 .../PNG/Grey/Double/arrow_basic_n_small.png.meta   |   130 +
 .../PNG/Grey/Double/arrow_basic_s.png              |   Bin 0 -> 694 bytes
 .../PNG/Grey/Double/arrow_basic_s.png.meta         |   130 +
 .../PNG/Grey/Double/arrow_basic_s_small.png        |   Bin 0 -> 533 bytes
 .../PNG/Grey/Double/arrow_basic_s_small.png.meta   |   130 +
 .../PNG/Grey/Double/arrow_basic_w.png              |   Bin 0 -> 635 bytes
 .../PNG/Grey/Double/arrow_basic_w.png.meta         |   130 +
 .../PNG/Grey/Double/arrow_basic_w_small.png        |   Bin 0 -> 549 bytes
 .../PNG/Grey/Double/arrow_basic_w_small.png.meta   |   130 +
 .../PNG/Grey/Double/arrow_decorative_e.png         |   Bin 0 -> 854 bytes
 .../PNG/Grey/Double/arrow_decorative_e.png.meta    |   130 +
 .../PNG/Grey/Double/arrow_decorative_e_small.png   |   Bin 0 -> 693 bytes
 .../Grey/Double/arrow_decorative_e_small.png.meta  |   130 +
 .../PNG/Grey/Double/arrow_decorative_n.png         |   Bin 0 -> 876 bytes
 .../PNG/Grey/Double/arrow_decorative_n.png.meta    |   130 +
 .../PNG/Grey/Double/arrow_decorative_n_small.png   |   Bin 0 -> 649 bytes
 .../Grey/Double/arrow_decorative_n_small.png.meta  |   130 +
 .../PNG/Grey/Double/arrow_decorative_s.png         |   Bin 0 -> 948 bytes
 .../PNG/Grey/Double/arrow_decorative_s.png.meta    |   130 +
 .../PNG/Grey/Double/arrow_decorative_s_small.png   |   Bin 0 -> 684 bytes
 .../Grey/Double/arrow_decorative_s_small.png.meta  |   130 +
 .../PNG/Grey/Double/arrow_decorative_w.png         |   Bin 0 -> 897 bytes
 .../PNG/Grey/Double/arrow_decorative_w.png.meta    |   130 +
 .../PNG/Grey/Double/arrow_decorative_w_small.png   |   Bin 0 -> 718 bytes
 .../Grey/Double/arrow_decorative_w_small.png.meta  |   130 +
 .../PNG/Grey/Double/button_rectangle_border.png    |   Bin 0 -> 691 bytes
 .../Grey/Double/button_rectangle_border.png.meta   |   130 +
 .../Grey/Double/button_rectangle_depth_border.png  |   Bin 0 -> 818 bytes
 .../Double/button_rectangle_depth_border.png.meta  |   130 +
 .../Grey/Double/button_rectangle_depth_flat.png    |   Bin 0 -> 786 bytes
 .../Double/button_rectangle_depth_flat.png.meta    |   130 +
 .../Grey/Double/button_rectangle_depth_gloss.png   |   Bin 0 -> 748 bytes
 .../Double/button_rectangle_depth_gloss.png.meta   |   130 +
 .../Double/button_rectangle_depth_gradient.png     |   Bin 0 -> 1131 bytes
 .../button_rectangle_depth_gradient.png.meta       |   130 +
 .../Grey/Double/button_rectangle_depth_line.png    |   Bin 0 -> 818 bytes
 .../Double/button_rectangle_depth_line.png.meta    |   130 +
 .../PNG/Grey/Double/button_rectangle_flat.png      |   Bin 0 -> 660 bytes
 .../PNG/Grey/Double/button_rectangle_flat.png.meta |   130 +
 .../PNG/Grey/Double/button_rectangle_gloss.png     |   Bin 0 -> 625 bytes
 .../Grey/Double/button_rectangle_gloss.png.meta    |   130 +
 .../PNG/Grey/Double/button_rectangle_gradient.png  |   Bin 0 -> 1046 bytes
 .../Grey/Double/button_rectangle_gradient.png.meta |   130 +
 .../PNG/Grey/Double/button_rectangle_line.png      |   Bin 0 -> 690 bytes
 .../PNG/Grey/Double/button_rectangle_line.png.meta |   130 +
 .../PNG/Grey/Double/button_round_border.png        |   Bin 0 -> 2488 bytes
 .../PNG/Grey/Double/button_round_border.png.meta   |   130 +
 .../PNG/Grey/Double/button_round_depth_border.png  |   Bin 0 -> 3052 bytes
 .../Grey/Double/button_round_depth_border.png.meta |   130 +
 .../PNG/Grey/Double/button_round_depth_flat.png    |   Bin 0 -> 2470 bytes
 .../Grey/Double/button_round_depth_flat.png.meta   |   130 +
 .../PNG/Grey/Double/button_round_depth_gloss.png   |   Bin 0 -> 2258 bytes
 .../Grey/Double/button_round_depth_gloss.png.meta  |   130 +
 .../Grey/Double/button_round_depth_gradient.png    |   Bin 0 -> 2754 bytes
 .../Double/button_round_depth_gradient.png.meta    |   130 +
 .../PNG/Grey/Double/button_round_depth_line.png    |   Bin 0 -> 3224 bytes
 .../Grey/Double/button_round_depth_line.png.meta   |   130 +
 .../PNG/Grey/Double/button_round_flat.png          |   Bin 0 -> 1857 bytes
 .../PNG/Grey/Double/button_round_flat.png.meta     |   130 +
 .../PNG/Grey/Double/button_round_gloss.png         |   Bin 0 -> 1728 bytes
 .../PNG/Grey/Double/button_round_gloss.png.meta    |   130 +
 .../PNG/Grey/Double/button_round_gradient.png      |   Bin 0 -> 2238 bytes
 .../PNG/Grey/Double/button_round_gradient.png.meta |   130 +
 .../PNG/Grey/Double/button_round_line.png          |   Bin 0 -> 2663 bytes
 .../PNG/Grey/Double/button_round_line.png.meta     |   130 +
 .../PNG/Grey/Double/button_square_border.png       |   Bin 0 -> 542 bytes
 .../PNG/Grey/Double/button_square_border.png.meta  |   130 +
 .../PNG/Grey/Double/button_square_depth_border.png |   Bin 0 -> 679 bytes
 .../Double/button_square_depth_border.png.meta     |   130 +
 .../PNG/Grey/Double/button_square_depth_flat.png   |   Bin 0 -> 652 bytes
 .../Grey/Double/button_square_depth_flat.png.meta  |   130 +
 .../PNG/Grey/Double/button_square_depth_gloss.png  |   Bin 0 -> 629 bytes
 .../Grey/Double/button_square_depth_gloss.png.meta |   130 +
 .../Grey/Double/button_square_depth_gradient.png   |   Bin 0 -> 1017 bytes
 .../Double/button_square_depth_gradient.png.meta   |   130 +
 .../PNG/Grey/Double/button_square_depth_line.png   |   Bin 0 -> 682 bytes
 .../Grey/Double/button_square_depth_line.png.meta  |   130 +
 .../PNG/Grey/Double/button_square_flat.png         |   Bin 0 -> 524 bytes
 .../PNG/Grey/Double/button_square_flat.png.meta    |   130 +
 .../PNG/Grey/Double/button_square_gloss.png        |   Bin 0 -> 503 bytes
 .../PNG/Grey/Double/button_square_gloss.png.meta   |   130 +
 .../PNG/Grey/Double/button_square_gradient.png     |   Bin 0 -> 921 bytes
 .../Grey/Double/button_square_gradient.png.meta    |   130 +
 .../PNG/Grey/Double/button_square_line.png         |   Bin 0 -> 540 bytes
 .../PNG/Grey/Double/button_square_line.png.meta    |   130 +
 .../PNG/Grey/Double/check_round_color.png          |   Bin 0 -> 1034 bytes
 .../PNG/Grey/Double/check_round_color.png.meta     |   130 +
 .../PNG/Grey/Double/check_round_grey.png           |   Bin 0 -> 1041 bytes
 .../PNG/Grey/Double/check_round_grey.png.meta      |   130 +
 .../PNG/Grey/Double/check_round_grey_circle.png    |   Bin 0 -> 1382 bytes
 .../Grey/Double/check_round_grey_circle.png.meta   |   130 +
 .../PNG/Grey/Double/check_round_round_circle.png   |   Bin 0 -> 1213 bytes
 .../Grey/Double/check_round_round_circle.png.meta  |   130 +
 .../PNG/Grey/Double/check_square_color.png         |   Bin 0 -> 466 bytes
 .../PNG/Grey/Double/check_square_color.png.meta    |   130 +
 .../Grey/Double/check_square_color_checkmark.png   |   Bin 0 -> 890 bytes
 .../Double/check_square_color_checkmark.png.meta   |   130 +
 .../PNG/Grey/Double/check_square_color_cross.png   |   Bin 0 -> 841 bytes
 .../Grey/Double/check_square_color_cross.png.meta  |   130 +
 .../PNG/Grey/Double/check_square_color_square.png  |   Bin 0 -> 532 bytes
 .../Grey/Double/check_square_color_square.png.meta |   130 +
 .../PNG/Grey/Double/check_square_grey.png          |   Bin 0 -> 466 bytes
 .../PNG/Grey/Double/check_square_grey.png.meta     |   130 +
 .../Grey/Double/check_square_grey_checkmark.png    |   Bin 0 -> 955 bytes
 .../Double/check_square_grey_checkmark.png.meta    |   130 +
 .../PNG/Grey/Double/check_square_grey_cross.png    |   Bin 0 -> 907 bytes
 .../Grey/Double/check_square_grey_cross.png.meta   |   130 +
 .../PNG/Grey/Double/check_square_grey_square.png   |   Bin 0 -> 536 bytes
 .../Grey/Double/check_square_grey_square.png.meta  |   130 +
 .../PNG/Grey/Double/icon_checkmark.png             |   Bin 0 -> 585 bytes
 .../PNG/Grey/Double/icon_checkmark.png.meta        |   130 +
 .../kenney_ui-pack/PNG/Grey/Double/icon_circle.png |   Bin 0 -> 466 bytes
 .../PNG/Grey/Double/icon_circle.png.meta           |   130 +
 .../kenney_ui-pack/PNG/Grey/Double/icon_cross.png  |   Bin 0 -> 516 bytes
 .../PNG/Grey/Double/icon_cross.png.meta            |   130 +
 .../PNG/Grey/Double/icon_outline_checkmark.png     |   Bin 0 -> 584 bytes
 .../Grey/Double/icon_outline_checkmark.png.meta    |   130 +
 .../PNG/Grey/Double/icon_outline_circle.png        |   Bin 0 -> 466 bytes
 .../PNG/Grey/Double/icon_outline_circle.png.meta   |   130 +
 .../PNG/Grey/Double/icon_outline_cross.png         |   Bin 0 -> 516 bytes
 .../PNG/Grey/Double/icon_outline_cross.png.meta    |   130 +
 .../PNG/Grey/Double/icon_outline_square.png        |   Bin 0 -> 183 bytes
 .../PNG/Grey/Double/icon_outline_square.png.meta   |   130 +
 .../kenney_ui-pack/PNG/Grey/Double/icon_square.png |   Bin 0 -> 183 bytes
 .../PNG/Grey/Double/icon_square.png.meta           |   130 +
 .../PNG/Grey/Double/slide_hangle.png               |   Bin 0 -> 441 bytes
 .../PNG/Grey/Double/slide_hangle.png.meta          |   130 +
 .../PNG/Grey/Double/slide_horizontal_color.png     |   Bin 0 -> 614 bytes
 .../Grey/Double/slide_horizontal_color.png.meta    |   130 +
 .../Grey/Double/slide_horizontal_color_section.png |   Bin 0 -> 430 bytes
 .../Double/slide_horizontal_color_section.png.meta |   130 +
 .../Double/slide_horizontal_color_section_wide.png |   Bin 0 -> 439 bytes
 .../slide_horizontal_color_section_wide.png.meta   |   130 +
 .../PNG/Grey/Double/slide_horizontal_grey.png      |   Bin 0 -> 614 bytes
 .../PNG/Grey/Double/slide_horizontal_grey.png.meta |   130 +
 .../Grey/Double/slide_horizontal_grey_section.png  |   Bin 0 -> 430 bytes
 .../Double/slide_horizontal_grey_section.png.meta  |   130 +
 .../Double/slide_horizontal_grey_section_wide.png  |   Bin 0 -> 439 bytes
 .../slide_horizontal_grey_section_wide.png.meta    |   130 +
 .../PNG/Grey/Double/slide_vertical_color.png       |   Bin 0 -> 611 bytes
 .../PNG/Grey/Double/slide_vertical_color.png.meta  |   130 +
 .../Grey/Double/slide_vertical_color_section.png   |   Bin 0 -> 461 bytes
 .../Double/slide_vertical_color_section.png.meta   |   130 +
 .../Double/slide_vertical_color_section_wide.png   |   Bin 0 -> 474 bytes
 .../slide_vertical_color_section_wide.png.meta     |   130 +
 .../PNG/Grey/Double/slide_vertical_grey.png        |   Bin 0 -> 611 bytes
 .../PNG/Grey/Double/slide_vertical_grey.png.meta   |   130 +
 .../Grey/Double/slide_vertical_grey_section.png    |   Bin 0 -> 461 bytes
 .../Double/slide_vertical_grey_section.png.meta    |   130 +
 .../Double/slide_vertical_grey_section_wide.png    |   Bin 0 -> 473 bytes
 .../slide_vertical_grey_section_wide.png.meta      |   130 +
 .../NewUI/kenney_ui-pack/PNG/Grey/Double/star.png  |   Bin 0 -> 2871 bytes
 .../kenney_ui-pack/PNG/Grey/Double/star.png.meta   |   130 +
 .../PNG/Grey/Double/star_outline.png               |   Bin 0 -> 1800 bytes
 .../PNG/Grey/Double/star_outline.png.meta          |   130 +
 .../PNG/Grey/Double/star_outline_depth.png         |   Bin 0 -> 2141 bytes
 .../PNG/Grey/Double/star_outline_depth.png.meta    |   130 +
 .../textures/NewUI/kenney_ui-pack/PNG/Red.meta     |     8 +
 .../NewUI/kenney_ui-pack/PNG/Red/Default.meta      |     8 +
 .../PNG/Red/Default/arrow_basic_e.png              |   Bin 0 -> 422 bytes
 .../PNG/Red/Default/arrow_basic_e.png.meta         |   130 +
 .../PNG/Red/Default/arrow_basic_e_small.png        |   Bin 0 -> 378 bytes
 .../PNG/Red/Default/arrow_basic_e_small.png.meta   |   130 +
 .../PNG/Red/Default/arrow_basic_n.png              |   Bin 0 -> 391 bytes
 .../PNG/Red/Default/arrow_basic_n.png.meta         |   130 +
 .../PNG/Red/Default/arrow_basic_n_small.png        |   Bin 0 -> 302 bytes
 .../PNG/Red/Default/arrow_basic_n_small.png.meta   |   130 +
 .../PNG/Red/Default/arrow_basic_s.png              |   Bin 0 -> 414 bytes
 .../PNG/Red/Default/arrow_basic_s.png.meta         |   130 +
 .../PNG/Red/Default/arrow_basic_s_small.png        |   Bin 0 -> 332 bytes
 .../PNG/Red/Default/arrow_basic_s_small.png.meta   |   130 +
 .../PNG/Red/Default/arrow_basic_w.png              |   Bin 0 -> 402 bytes
 .../PNG/Red/Default/arrow_basic_w.png.meta         |   130 +
 .../PNG/Red/Default/arrow_basic_w_small.png        |   Bin 0 -> 399 bytes
 .../PNG/Red/Default/arrow_basic_w_small.png.meta   |   130 +
 .../PNG/Red/Default/arrow_decorative_e.png         |   Bin 0 -> 566 bytes
 .../PNG/Red/Default/arrow_decorative_e.png.meta    |   130 +
 .../PNG/Red/Default/arrow_decorative_e_small.png   |   Bin 0 -> 459 bytes
 .../Red/Default/arrow_decorative_e_small.png.meta  |   130 +
 .../PNG/Red/Default/arrow_decorative_n.png         |   Bin 0 -> 511 bytes
 .../PNG/Red/Default/arrow_decorative_n.png.meta    |   130 +
 .../PNG/Red/Default/arrow_decorative_n_small.png   |   Bin 0 -> 405 bytes
 .../Red/Default/arrow_decorative_n_small.png.meta  |   130 +
 .../PNG/Red/Default/arrow_decorative_s.png         |   Bin 0 -> 530 bytes
 .../PNG/Red/Default/arrow_decorative_s.png.meta    |   130 +
 .../PNG/Red/Default/arrow_decorative_s_small.png   |   Bin 0 -> 424 bytes
 .../Red/Default/arrow_decorative_s_small.png.meta  |   130 +
 .../PNG/Red/Default/arrow_decorative_w.png         |   Bin 0 -> 562 bytes
 .../PNG/Red/Default/arrow_decorative_w.png.meta    |   130 +
 .../PNG/Red/Default/arrow_decorative_w_small.png   |   Bin 0 -> 484 bytes
 .../Red/Default/arrow_decorative_w_small.png.meta  |   130 +
 .../PNG/Red/Default/button_rectangle_border.png    |   Bin 0 -> 338 bytes
 .../Red/Default/button_rectangle_border.png.meta   |   130 +
 .../Red/Default/button_rectangle_depth_border.png  |   Bin 0 -> 411 bytes
 .../Default/button_rectangle_depth_border.png.meta |   130 +
 .../Red/Default/button_rectangle_depth_flat.png    |   Bin 0 -> 384 bytes
 .../Default/button_rectangle_depth_flat.png.meta   |   130 +
 .../Red/Default/button_rectangle_depth_gloss.png   |   Bin 0 -> 373 bytes
 .../Default/button_rectangle_depth_gloss.png.meta  |   130 +
 .../Default/button_rectangle_depth_gradient.png    |   Bin 0 -> 642 bytes
 .../button_rectangle_depth_gradient.png.meta       |   130 +
 .../Red/Default/button_rectangle_depth_line.png    |   Bin 0 -> 411 bytes
 .../Default/button_rectangle_depth_line.png.meta   |   130 +
 .../PNG/Red/Default/button_rectangle_flat.png      |   Bin 0 -> 315 bytes
 .../PNG/Red/Default/button_rectangle_flat.png.meta |   130 +
 .../PNG/Red/Default/button_rectangle_gloss.png     |   Bin 0 -> 306 bytes
 .../Red/Default/button_rectangle_gloss.png.meta    |   130 +
 .../PNG/Red/Default/button_rectangle_gradient.png  |   Bin 0 -> 590 bytes
 .../Red/Default/button_rectangle_gradient.png.meta |   130 +
 .../PNG/Red/Default/button_rectangle_line.png      |   Bin 0 -> 338 bytes
 .../PNG/Red/Default/button_rectangle_line.png.meta |   130 +
 .../PNG/Red/Default/button_round_border.png        |   Bin 0 -> 1487 bytes
 .../PNG/Red/Default/button_round_border.png.meta   |   130 +
 .../PNG/Red/Default/button_round_depth_border.png  |   Bin 0 -> 1793 bytes
 .../Red/Default/button_round_depth_border.png.meta |   130 +
 .../PNG/Red/Default/button_round_depth_flat.png    |   Bin 0 -> 1301 bytes
 .../Red/Default/button_round_depth_flat.png.meta   |   130 +
 .../PNG/Red/Default/button_round_depth_gloss.png   |   Bin 0 -> 1210 bytes
 .../Red/Default/button_round_depth_gloss.png.meta  |   130 +
 .../Red/Default/button_round_depth_gradient.png    |   Bin 0 -> 1571 bytes
 .../Default/button_round_depth_gradient.png.meta   |   130 +
 .../PNG/Red/Default/button_round_depth_line.png    |   Bin 0 -> 1690 bytes
 .../Red/Default/button_round_depth_line.png.meta   |   130 +
 .../PNG/Red/Default/button_round_flat.png          |   Bin 0 -> 1023 bytes
 .../PNG/Red/Default/button_round_flat.png.meta     |   130 +
 .../PNG/Red/Default/button_round_gloss.png         |   Bin 0 -> 958 bytes
 .../PNG/Red/Default/button_round_gloss.png.meta    |   130 +
 .../PNG/Red/Default/button_round_gradient.png      |   Bin 0 -> 1268 bytes
 .../PNG/Red/Default/button_round_gradient.png.meta |   130 +
 .../PNG/Red/Default/button_round_line.png          |   Bin 0 -> 1413 bytes
 .../PNG/Red/Default/button_round_line.png.meta     |   130 +
 .../PNG/Red/Default/button_square_border.png       |   Bin 0 -> 306 bytes
 .../PNG/Red/Default/button_square_border.png.meta  |   130 +
 .../PNG/Red/Default/button_square_depth_border.png |   Bin 0 -> 375 bytes
 .../Default/button_square_depth_border.png.meta    |   130 +
 .../PNG/Red/Default/button_square_depth_flat.png   |   Bin 0 -> 355 bytes
 .../Red/Default/button_square_depth_flat.png.meta  |   130 +
 .../PNG/Red/Default/button_square_depth_gloss.png  |   Bin 0 -> 337 bytes
 .../Red/Default/button_square_depth_gloss.png.meta |   130 +
 .../Red/Default/button_square_depth_gradient.png   |   Bin 0 -> 615 bytes
 .../Default/button_square_depth_gradient.png.meta  |   130 +
 .../PNG/Red/Default/button_square_depth_line.png   |   Bin 0 -> 374 bytes
 .../Red/Default/button_square_depth_line.png.meta  |   130 +
 .../PNG/Red/Default/button_square_flat.png         |   Bin 0 -> 286 bytes
 .../PNG/Red/Default/button_square_flat.png.meta    |   130 +
 .../PNG/Red/Default/button_square_gloss.png        |   Bin 0 -> 268 bytes
 .../PNG/Red/Default/button_square_gloss.png.meta   |   130 +
 .../PNG/Red/Default/button_square_gradient.png     |   Bin 0 -> 512 bytes
 .../Red/Default/button_square_gradient.png.meta    |   130 +
 .../PNG/Red/Default/button_square_line.png         |   Bin 0 -> 304 bytes
 .../PNG/Red/Default/button_square_line.png.meta    |   130 +
 .../PNG/Red/Default/check_round_color.png          |   Bin 0 -> 579 bytes
 .../PNG/Red/Default/check_round_color.png.meta     |   130 +
 .../PNG/Red/Default/check_round_grey.png           |   Bin 0 -> 579 bytes
 .../PNG/Red/Default/check_round_grey.png.meta      |   130 +
 .../PNG/Red/Default/check_round_grey_circle.png    |   Bin 0 -> 774 bytes
 .../Red/Default/check_round_grey_circle.png.meta   |   130 +
 .../PNG/Red/Default/check_round_round_circle.png   |   Bin 0 -> 771 bytes
 .../Red/Default/check_round_round_circle.png.meta  |   130 +
 .../PNG/Red/Default/check_square_color.png         |   Bin 0 -> 280 bytes
 .../PNG/Red/Default/check_square_color.png.meta    |   130 +
 .../Red/Default/check_square_color_checkmark.png   |   Bin 0 -> 556 bytes
 .../Default/check_square_color_checkmark.png.meta  |   130 +
 .../PNG/Red/Default/check_square_color_cross.png   |   Bin 0 -> 534 bytes
 .../Red/Default/check_square_color_cross.png.meta  |   130 +
 .../PNG/Red/Default/check_square_color_square.png  |   Bin 0 -> 319 bytes
 .../Red/Default/check_square_color_square.png.meta |   130 +
 .../PNG/Red/Default/check_square_grey.png          |   Bin 0 -> 280 bytes
 .../PNG/Red/Default/check_square_grey.png.meta     |   130 +
 .../Red/Default/check_square_grey_checkmark.png    |   Bin 0 -> 559 bytes
 .../Default/check_square_grey_checkmark.png.meta   |   130 +
 .../PNG/Red/Default/check_square_grey_cross.png    |   Bin 0 -> 539 bytes
 .../Red/Default/check_square_grey_cross.png.meta   |   130 +
 .../PNG/Red/Default/check_square_grey_square.png   |   Bin 0 -> 321 bytes
 .../Red/Default/check_square_grey_square.png.meta  |   130 +
 .../PNG/Red/Default/icon_checkmark.png             |   Bin 0 -> 377 bytes
 .../PNG/Red/Default/icon_checkmark.png.meta        |   130 +
 .../kenney_ui-pack/PNG/Red/Default/icon_circle.png |   Bin 0 -> 313 bytes
 .../PNG/Red/Default/icon_circle.png.meta           |   130 +
 .../kenney_ui-pack/PNG/Red/Default/icon_cross.png  |   Bin 0 -> 350 bytes
 .../PNG/Red/Default/icon_cross.png.meta            |   130 +
 .../PNG/Red/Default/icon_outline_checkmark.png     |   Bin 0 -> 377 bytes
 .../Red/Default/icon_outline_checkmark.png.meta    |   130 +
 .../PNG/Red/Default/icon_outline_circle.png        |   Bin 0 -> 313 bytes
 .../PNG/Red/Default/icon_outline_circle.png.meta   |   130 +
 .../PNG/Red/Default/icon_outline_cross.png         |   Bin 0 -> 352 bytes
 .../PNG/Red/Default/icon_outline_cross.png.meta    |   130 +
 .../PNG/Red/Default/icon_outline_square.png        |   Bin 0 -> 132 bytes
 .../PNG/Red/Default/icon_outline_square.png.meta   |   130 +
 .../kenney_ui-pack/PNG/Red/Default/icon_square.png |   Bin 0 -> 137 bytes
 .../PNG/Red/Default/icon_square.png.meta           |   130 +
 .../PNG/Red/Default/slide_hangle.png               |   Bin 0 -> 297 bytes
 .../PNG/Red/Default/slide_hangle.png.meta          |   130 +
 .../PNG/Red/Default/slide_horizontal_color.png     |   Bin 0 -> 383 bytes
 .../Red/Default/slide_horizontal_color.png.meta    |   130 +
 .../Red/Default/slide_horizontal_color_section.png |   Bin 0 -> 321 bytes
 .../slide_horizontal_color_section.png.meta        |   130 +
 .../slide_horizontal_color_section_wide.png        |   Bin 0 -> 336 bytes
 .../slide_horizontal_color_section_wide.png.meta   |   130 +
 .../PNG/Red/Default/slide_horizontal_grey.png      |   Bin 0 -> 383 bytes
 .../PNG/Red/Default/slide_horizontal_grey.png.meta |   130 +
 .../Red/Default/slide_horizontal_grey_section.png  |   Bin 0 -> 321 bytes
 .../Default/slide_horizontal_grey_section.png.meta |   130 +
 .../Default/slide_horizontal_grey_section_wide.png |   Bin 0 -> 336 bytes
 .../slide_horizontal_grey_section_wide.png.meta    |   130 +
 .../PNG/Red/Default/slide_vertical_color.png       |   Bin 0 -> 379 bytes
 .../PNG/Red/Default/slide_vertical_color.png.meta  |   130 +
 .../Red/Default/slide_vertical_color_section.png   |   Bin 0 -> 308 bytes
 .../Default/slide_vertical_color_section.png.meta  |   130 +
 .../Default/slide_vertical_color_section_wide.png  |   Bin 0 -> 316 bytes
 .../slide_vertical_color_section_wide.png.meta     |   130 +
 .../PNG/Red/Default/slide_vertical_grey.png        |   Bin 0 -> 379 bytes
 .../PNG/Red/Default/slide_vertical_grey.png.meta   |   130 +
 .../Red/Default/slide_vertical_grey_section.png    |   Bin 0 -> 308 bytes
 .../Default/slide_vertical_grey_section.png.meta   |   130 +
 .../Default/slide_vertical_grey_section_wide.png   |   Bin 0 -> 316 bytes
 .../slide_vertical_grey_section_wide.png.meta      |   130 +
 .../NewUI/kenney_ui-pack/PNG/Red/Default/star.png  |   Bin 0 -> 1555 bytes
 .../kenney_ui-pack/PNG/Red/Default/star.png.meta   |   130 +
 .../PNG/Red/Default/star_outline.png               |   Bin 0 -> 955 bytes
 .../PNG/Red/Default/star_outline.png.meta          |   130 +
 .../PNG/Red/Default/star_outline_depth.png         |   Bin 0 -> 1168 bytes
 .../PNG/Red/Default/star_outline_depth.png.meta    |   130 +
 .../NewUI/kenney_ui-pack/PNG/Red/Double.meta       |     8 +
 .../PNG/Red/Double/arrow_basic_e.png               |   Bin 0 -> 637 bytes
 .../PNG/Red/Double/arrow_basic_e.png.meta          |   130 +
 .../PNG/Red/Double/arrow_basic_e_small.png         |   Bin 0 -> 522 bytes
 .../PNG/Red/Double/arrow_basic_e_small.png.meta    |   130 +
 .../PNG/Red/Double/arrow_basic_n.png               |   Bin 0 -> 622 bytes
 .../PNG/Red/Double/arrow_basic_n.png.meta          |   130 +
 .../PNG/Red/Double/arrow_basic_n_small.png         |   Bin 0 -> 472 bytes
 .../PNG/Red/Double/arrow_basic_n_small.png.meta    |   130 +
 .../PNG/Red/Double/arrow_basic_s.png               |   Bin 0 -> 694 bytes
 .../PNG/Red/Double/arrow_basic_s.png.meta          |   130 +
 .../PNG/Red/Double/arrow_basic_s_small.png         |   Bin 0 -> 533 bytes
 .../PNG/Red/Double/arrow_basic_s_small.png.meta    |   130 +
 .../PNG/Red/Double/arrow_basic_w.png               |   Bin 0 -> 639 bytes
 .../PNG/Red/Double/arrow_basic_w.png.meta          |   130 +
 .../PNG/Red/Double/arrow_basic_w_small.png         |   Bin 0 -> 550 bytes
 .../PNG/Red/Double/arrow_basic_w_small.png.meta    |   130 +
 .../PNG/Red/Double/arrow_decorative_e.png          |   Bin 0 -> 858 bytes
 .../PNG/Red/Double/arrow_decorative_e.png.meta     |   130 +
 .../PNG/Red/Double/arrow_decorative_e_small.png    |   Bin 0 -> 697 bytes
 .../Red/Double/arrow_decorative_e_small.png.meta   |   130 +
 .../PNG/Red/Double/arrow_decorative_n.png          |   Bin 0 -> 880 bytes
 .../PNG/Red/Double/arrow_decorative_n.png.meta     |   130 +
 .../PNG/Red/Double/arrow_decorative_n_small.png    |   Bin 0 -> 649 bytes
 .../Red/Double/arrow_decorative_n_small.png.meta   |   130 +
 .../PNG/Red/Double/arrow_decorative_s.png          |   Bin 0 -> 951 bytes
 .../PNG/Red/Double/arrow_decorative_s.png.meta     |   130 +
 .../PNG/Red/Double/arrow_decorative_s_small.png    |   Bin 0 -> 684 bytes
 .../Red/Double/arrow_decorative_s_small.png.meta   |   130 +
 .../PNG/Red/Double/arrow_decorative_w.png          |   Bin 0 -> 901 bytes
 .../PNG/Red/Double/arrow_decorative_w.png.meta     |   130 +
 .../PNG/Red/Double/arrow_decorative_w_small.png    |   Bin 0 -> 721 bytes
 .../Red/Double/arrow_decorative_w_small.png.meta   |   130 +
 .../PNG/Red/Double/button_rectangle_border.png     |   Bin 0 -> 693 bytes
 .../Red/Double/button_rectangle_border.png.meta    |   130 +
 .../Red/Double/button_rectangle_depth_border.png   |   Bin 0 -> 821 bytes
 .../Double/button_rectangle_depth_border.png.meta  |   130 +
 .../PNG/Red/Double/button_rectangle_depth_flat.png |   Bin 0 -> 785 bytes
 .../Double/button_rectangle_depth_flat.png.meta    |   130 +
 .../Red/Double/button_rectangle_depth_gloss.png    |   Bin 0 -> 747 bytes
 .../Double/button_rectangle_depth_gloss.png.meta   |   130 +
 .../Red/Double/button_rectangle_depth_gradient.png |   Bin 0 -> 1137 bytes
 .../button_rectangle_depth_gradient.png.meta       |   130 +
 .../PNG/Red/Double/button_rectangle_depth_line.png |   Bin 0 -> 817 bytes
 .../Double/button_rectangle_depth_line.png.meta    |   130 +
 .../PNG/Red/Double/button_rectangle_flat.png       |   Bin 0 -> 660 bytes
 .../PNG/Red/Double/button_rectangle_flat.png.meta  |   130 +
 .../PNG/Red/Double/button_rectangle_gloss.png      |   Bin 0 -> 623 bytes
 .../PNG/Red/Double/button_rectangle_gloss.png.meta |   130 +
 .../PNG/Red/Double/button_rectangle_gradient.png   |   Bin 0 -> 1037 bytes
 .../Red/Double/button_rectangle_gradient.png.meta  |   130 +
 .../PNG/Red/Double/button_rectangle_line.png       |   Bin 0 -> 688 bytes
 .../PNG/Red/Double/button_rectangle_line.png.meta  |   130 +
 .../PNG/Red/Double/button_round_border.png         |   Bin 0 -> 2794 bytes
 .../PNG/Red/Double/button_round_border.png.meta    |   130 +
 .../PNG/Red/Double/button_round_depth_border.png   |   Bin 0 -> 3366 bytes
 .../Red/Double/button_round_depth_border.png.meta  |   130 +
 .../PNG/Red/Double/button_round_depth_flat.png     |   Bin 0 -> 2476 bytes
 .../Red/Double/button_round_depth_flat.png.meta    |   130 +
 .../PNG/Red/Double/button_round_depth_gloss.png    |   Bin 0 -> 2264 bytes
 .../Red/Double/button_round_depth_gloss.png.meta   |   130 +
 .../PNG/Red/Double/button_round_depth_gradient.png |   Bin 0 -> 2842 bytes
 .../Double/button_round_depth_gradient.png.meta    |   130 +
 .../PNG/Red/Double/button_round_depth_line.png     |   Bin 0 -> 3231 bytes
 .../Red/Double/button_round_depth_line.png.meta    |   130 +
 .../PNG/Red/Double/button_round_flat.png           |   Bin 0 -> 1863 bytes
 .../PNG/Red/Double/button_round_flat.png.meta      |   130 +
 .../PNG/Red/Double/button_round_gloss.png          |   Bin 0 -> 1734 bytes
 .../PNG/Red/Double/button_round_gloss.png.meta     |   130 +
 .../PNG/Red/Double/button_round_gradient.png       |   Bin 0 -> 2355 bytes
 .../PNG/Red/Double/button_round_gradient.png.meta  |   130 +
 .../PNG/Red/Double/button_round_line.png           |   Bin 0 -> 2669 bytes
 .../PNG/Red/Double/button_round_line.png.meta      |   130 +
 .../PNG/Red/Double/button_square_border.png        |   Bin 0 -> 544 bytes
 .../PNG/Red/Double/button_square_border.png.meta   |   130 +
 .../PNG/Red/Double/button_square_depth_border.png  |   Bin 0 -> 685 bytes
 .../Red/Double/button_square_depth_border.png.meta |   130 +
 .../PNG/Red/Double/button_square_depth_flat.png    |   Bin 0 -> 652 bytes
 .../Red/Double/button_square_depth_flat.png.meta   |   130 +
 .../PNG/Red/Double/button_square_depth_gloss.png   |   Bin 0 -> 629 bytes
 .../Red/Double/button_square_depth_gloss.png.meta  |   130 +
 .../Red/Double/button_square_depth_gradient.png    |   Bin 0 -> 1021 bytes
 .../Double/button_square_depth_gradient.png.meta   |   130 +
 .../PNG/Red/Double/button_square_depth_line.png    |   Bin 0 -> 684 bytes
 .../Red/Double/button_square_depth_line.png.meta   |   130 +
 .../PNG/Red/Double/button_square_flat.png          |   Bin 0 -> 523 bytes
 .../PNG/Red/Double/button_square_flat.png.meta     |   130 +
 .../PNG/Red/Double/button_square_gloss.png         |   Bin 0 -> 502 bytes
 .../PNG/Red/Double/button_square_gloss.png.meta    |   130 +
 .../PNG/Red/Double/button_square_gradient.png      |   Bin 0 -> 914 bytes
 .../PNG/Red/Double/button_square_gradient.png.meta |   130 +
 .../PNG/Red/Double/button_square_line.png          |   Bin 0 -> 542 bytes
 .../PNG/Red/Double/button_square_line.png.meta     |   130 +
 .../PNG/Red/Double/check_round_color.png           |   Bin 0 -> 1041 bytes
 .../PNG/Red/Double/check_round_color.png.meta      |   130 +
 .../PNG/Red/Double/check_round_grey.png            |   Bin 0 -> 1041 bytes
 .../PNG/Red/Double/check_round_grey.png.meta       |   130 +
 .../PNG/Red/Double/check_round_grey_circle.png     |   Bin 0 -> 1387 bytes
 .../Red/Double/check_round_grey_circle.png.meta    |   130 +
 .../PNG/Red/Double/check_round_round_circle.png    |   Bin 0 -> 1383 bytes
 .../Red/Double/check_round_round_circle.png.meta   |   130 +
 .../PNG/Red/Double/check_square_color.png          |   Bin 0 -> 466 bytes
 .../PNG/Red/Double/check_square_color.png.meta     |   130 +
 .../Red/Double/check_square_color_checkmark.png    |   Bin 0 -> 955 bytes
 .../Double/check_square_color_checkmark.png.meta   |   130 +
 .../PNG/Red/Double/check_square_color_cross.png    |   Bin 0 -> 908 bytes
 .../Red/Double/check_square_color_cross.png.meta   |   130 +
 .../PNG/Red/Double/check_square_color_square.png   |   Bin 0 -> 535 bytes
 .../Red/Double/check_square_color_square.png.meta  |   130 +
 .../PNG/Red/Double/check_square_grey.png           |   Bin 0 -> 466 bytes
 .../PNG/Red/Double/check_square_grey.png.meta      |   130 +
 .../PNG/Red/Double/check_square_grey_checkmark.png |   Bin 0 -> 959 bytes
 .../Double/check_square_grey_checkmark.png.meta    |   130 +
 .../PNG/Red/Double/check_square_grey_cross.png     |   Bin 0 -> 909 bytes
 .../Red/Double/check_square_grey_cross.png.meta    |   130 +
 .../PNG/Red/Double/check_square_grey_square.png    |   Bin 0 -> 538 bytes
 .../Red/Double/check_square_grey_square.png.meta   |   130 +
 .../PNG/Red/Double/icon_checkmark.png              |   Bin 0 -> 584 bytes
 .../PNG/Red/Double/icon_checkmark.png.meta         |   130 +
 .../kenney_ui-pack/PNG/Red/Double/icon_circle.png  |   Bin 0 -> 466 bytes
 .../PNG/Red/Double/icon_circle.png.meta            |   130 +
 .../kenney_ui-pack/PNG/Red/Double/icon_cross.png   |   Bin 0 -> 516 bytes
 .../PNG/Red/Double/icon_cross.png.meta             |   130 +
 .../PNG/Red/Double/icon_outline_checkmark.png      |   Bin 0 -> 585 bytes
 .../PNG/Red/Double/icon_outline_checkmark.png.meta |   130 +
 .../PNG/Red/Double/icon_outline_circle.png         |   Bin 0 -> 466 bytes
 .../PNG/Red/Double/icon_outline_circle.png.meta    |   130 +
 .../PNG/Red/Double/icon_outline_cross.png          |   Bin 0 -> 516 bytes
 .../PNG/Red/Double/icon_outline_cross.png.meta     |   130 +
 .../PNG/Red/Double/icon_outline_square.png         |   Bin 0 -> 183 bytes
 .../PNG/Red/Double/icon_outline_square.png.meta    |   130 +
 .../kenney_ui-pack/PNG/Red/Double/icon_square.png  |   Bin 0 -> 183 bytes
 .../PNG/Red/Double/icon_square.png.meta            |   130 +
 .../kenney_ui-pack/PNG/Red/Double/slide_hangle.png |   Bin 0 -> 440 bytes
 .../PNG/Red/Double/slide_hangle.png.meta           |   130 +
 .../PNG/Red/Double/slide_horizontal_color.png      |   Bin 0 -> 614 bytes
 .../PNG/Red/Double/slide_horizontal_color.png.meta |   130 +
 .../Red/Double/slide_horizontal_color_section.png  |   Bin 0 -> 432 bytes
 .../Double/slide_horizontal_color_section.png.meta |   130 +
 .../Double/slide_horizontal_color_section_wide.png |   Bin 0 -> 439 bytes
 .../slide_horizontal_color_section_wide.png.meta   |   130 +
 .../PNG/Red/Double/slide_horizontal_grey.png       |   Bin 0 -> 614 bytes
 .../PNG/Red/Double/slide_horizontal_grey.png.meta  |   130 +
 .../Red/Double/slide_horizontal_grey_section.png   |   Bin 0 -> 430 bytes
 .../Double/slide_horizontal_grey_section.png.meta  |   130 +
 .../Double/slide_horizontal_grey_section_wide.png  |   Bin 0 -> 439 bytes
 .../slide_horizontal_grey_section_wide.png.meta    |   130 +
 .../PNG/Red/Double/slide_vertical_color.png        |   Bin 0 -> 611 bytes
 .../PNG/Red/Double/slide_vertical_color.png.meta   |   130 +
 .../Red/Double/slide_vertical_color_section.png    |   Bin 0 -> 461 bytes
 .../Double/slide_vertical_color_section.png.meta   |   130 +
 .../Double/slide_vertical_color_section_wide.png   |   Bin 0 -> 473 bytes
 .../slide_vertical_color_section_wide.png.meta     |   130 +
 .../PNG/Red/Double/slide_vertical_grey.png         |   Bin 0 -> 611 bytes
 .../PNG/Red/Double/slide_vertical_grey.png.meta    |   130 +
 .../PNG/Red/Double/slide_vertical_grey_section.png |   Bin 0 -> 461 bytes
 .../Double/slide_vertical_grey_section.png.meta    |   130 +
 .../Double/slide_vertical_grey_section_wide.png    |   Bin 0 -> 473 bytes
 .../slide_vertical_grey_section_wide.png.meta      |   130 +
 .../NewUI/kenney_ui-pack/PNG/Red/Double/star.png   |   Bin 0 -> 2860 bytes
 .../kenney_ui-pack/PNG/Red/Double/star.png.meta    |   130 +
 .../kenney_ui-pack/PNG/Red/Double/star_outline.png |   Bin 0 -> 1800 bytes
 .../PNG/Red/Double/star_outline.png.meta           |   130 +
 .../PNG/Red/Double/star_outline_depth.png          |   Bin 0 -> 2141 bytes
 .../PNG/Red/Double/star_outline_depth.png.meta     |   130 +
 .../textures/NewUI/kenney_ui-pack/PNG/Yellow.meta  |     8 +
 .../NewUI/kenney_ui-pack/PNG/Yellow/Default.meta   |     8 +
 .../PNG/Yellow/Default/arrow_basic_e.png           |   Bin 0 -> 422 bytes
 .../PNG/Yellow/Default/arrow_basic_e.png.meta      |   130 +
 .../PNG/Yellow/Default/arrow_basic_e_small.png     |   Bin 0 -> 378 bytes
 .../Yellow/Default/arrow_basic_e_small.png.meta    |   130 +
 .../PNG/Yellow/Default/arrow_basic_n.png           |   Bin 0 -> 391 bytes
 .../PNG/Yellow/Default/arrow_basic_n.png.meta      |   130 +
 .../PNG/Yellow/Default/arrow_basic_n_small.png     |   Bin 0 -> 302 bytes
 .../Yellow/Default/arrow_basic_n_small.png.meta    |   130 +
 .../PNG/Yellow/Default/arrow_basic_s.png           |   Bin 0 -> 414 bytes
 .../PNG/Yellow/Default/arrow_basic_s.png.meta      |   130 +
 .../PNG/Yellow/Default/arrow_basic_s_small.png     |   Bin 0 -> 332 bytes
 .../Yellow/Default/arrow_basic_s_small.png.meta    |   130 +
 .../PNG/Yellow/Default/arrow_basic_w.png           |   Bin 0 -> 402 bytes
 .../PNG/Yellow/Default/arrow_basic_w.png.meta      |   130 +
 .../PNG/Yellow/Default/arrow_basic_w_small.png     |   Bin 0 -> 399 bytes
 .../Yellow/Default/arrow_basic_w_small.png.meta    |   130 +
 .../PNG/Yellow/Default/arrow_decorative_e.png      |   Bin 0 -> 566 bytes
 .../PNG/Yellow/Default/arrow_decorative_e.png.meta |   130 +
 .../Yellow/Default/arrow_decorative_e_small.png    |   Bin 0 -> 459 bytes
 .../Default/arrow_decorative_e_small.png.meta      |   130 +
 .../PNG/Yellow/Default/arrow_decorative_n.png      |   Bin 0 -> 511 bytes
 .../PNG/Yellow/Default/arrow_decorative_n.png.meta |   130 +
 .../Yellow/Default/arrow_decorative_n_small.png    |   Bin 0 -> 404 bytes
 .../Default/arrow_decorative_n_small.png.meta      |   130 +
 .../PNG/Yellow/Default/arrow_decorative_s.png      |   Bin 0 -> 530 bytes
 .../PNG/Yellow/Default/arrow_decorative_s.png.meta |   130 +
 .../Yellow/Default/arrow_decorative_s_small.png    |   Bin 0 -> 424 bytes
 .../Default/arrow_decorative_s_small.png.meta      |   130 +
 .../PNG/Yellow/Default/arrow_decorative_w.png      |   Bin 0 -> 562 bytes
 .../PNG/Yellow/Default/arrow_decorative_w.png.meta |   130 +
 .../Yellow/Default/arrow_decorative_w_small.png    |   Bin 0 -> 483 bytes
 .../Default/arrow_decorative_w_small.png.meta      |   130 +
 .../PNG/Yellow/Default/button_rectangle_border.png |   Bin 0 -> 338 bytes
 .../Default/button_rectangle_border.png.meta       |   130 +
 .../Default/button_rectangle_depth_border.png      |   Bin 0 -> 412 bytes
 .../Default/button_rectangle_depth_border.png.meta |   130 +
 .../Yellow/Default/button_rectangle_depth_flat.png |   Bin 0 -> 383 bytes
 .../Default/button_rectangle_depth_flat.png.meta   |   130 +
 .../Default/button_rectangle_depth_gloss.png       |   Bin 0 -> 373 bytes
 .../Default/button_rectangle_depth_gloss.png.meta  |   130 +
 .../Default/button_rectangle_depth_gradient.png    |   Bin 0 -> 642 bytes
 .../button_rectangle_depth_gradient.png.meta       |   130 +
 .../Yellow/Default/button_rectangle_depth_line.png |   Bin 0 -> 411 bytes
 .../Default/button_rectangle_depth_line.png.meta   |   130 +
 .../PNG/Yellow/Default/button_rectangle_flat.png   |   Bin 0 -> 315 bytes
 .../Yellow/Default/button_rectangle_flat.png.meta  |   130 +
 .../PNG/Yellow/Default/button_rectangle_gloss.png  |   Bin 0 -> 306 bytes
 .../Yellow/Default/button_rectangle_gloss.png.meta |   130 +
 .../Yellow/Default/button_rectangle_gradient.png   |   Bin 0 -> 590 bytes
 .../Default/button_rectangle_gradient.png.meta     |   130 +
 .../PNG/Yellow/Default/button_rectangle_line.png   |   Bin 0 -> 338 bytes
 .../Yellow/Default/button_rectangle_line.png.meta  |   130 +
 .../PNG/Yellow/Default/button_round_border.png     |   Bin 0 -> 1488 bytes
 .../Yellow/Default/button_round_border.png.meta    |   130 +
 .../Yellow/Default/button_round_depth_border.png   |   Bin 0 -> 1791 bytes
 .../Default/button_round_depth_border.png.meta     |   130 +
 .../PNG/Yellow/Default/button_round_depth_flat.png |   Bin 0 -> 1300 bytes
 .../Default/button_round_depth_flat.png.meta       |   130 +
 .../Yellow/Default/button_round_depth_gloss.png    |   Bin 0 -> 1209 bytes
 .../Default/button_round_depth_gloss.png.meta      |   130 +
 .../Yellow/Default/button_round_depth_gradient.png |   Bin 0 -> 1646 bytes
 .../Default/button_round_depth_gradient.png.meta   |   130 +
 .../PNG/Yellow/Default/button_round_depth_line.png |   Bin 0 -> 1690 bytes
 .../Default/button_round_depth_line.png.meta       |   130 +
 .../PNG/Yellow/Default/button_round_flat.png       |   Bin 0 -> 1023 bytes
 .../PNG/Yellow/Default/button_round_flat.png.meta  |   130 +
 .../PNG/Yellow/Default/button_round_gloss.png      |   Bin 0 -> 958 bytes
 .../PNG/Yellow/Default/button_round_gloss.png.meta |   130 +
 .../PNG/Yellow/Default/button_round_gradient.png   |   Bin 0 -> 1354 bytes
 .../Yellow/Default/button_round_gradient.png.meta  |   130 +
 .../PNG/Yellow/Default/button_round_line.png       |   Bin 0 -> 1413 bytes
 .../PNG/Yellow/Default/button_round_line.png.meta  |   130 +
 .../PNG/Yellow/Default/button_square_border.png    |   Bin 0 -> 306 bytes
 .../Yellow/Default/button_square_border.png.meta   |   130 +
 .../Yellow/Default/button_square_depth_border.png  |   Bin 0 -> 375 bytes
 .../Default/button_square_depth_border.png.meta    |   130 +
 .../Yellow/Default/button_square_depth_flat.png    |   Bin 0 -> 355 bytes
 .../Default/button_square_depth_flat.png.meta      |   130 +
 .../Yellow/Default/button_square_depth_gloss.png   |   Bin 0 -> 337 bytes
 .../Default/button_square_depth_gloss.png.meta     |   130 +
 .../Default/button_square_depth_gradient.png       |   Bin 0 -> 615 bytes
 .../Default/button_square_depth_gradient.png.meta  |   130 +
 .../Yellow/Default/button_square_depth_line.png    |   Bin 0 -> 374 bytes
 .../Default/button_square_depth_line.png.meta      |   130 +
 .../PNG/Yellow/Default/button_square_flat.png      |   Bin 0 -> 286 bytes
 .../PNG/Yellow/Default/button_square_flat.png.meta |   130 +
 .../PNG/Yellow/Default/button_square_gloss.png     |   Bin 0 -> 268 bytes
 .../Yellow/Default/button_square_gloss.png.meta    |   130 +
 .../PNG/Yellow/Default/button_square_gradient.png  |   Bin 0 -> 532 bytes
 .../Yellow/Default/button_square_gradient.png.meta |   130 +
 .../PNG/Yellow/Default/button_square_line.png      |   Bin 0 -> 304 bytes
 .../PNG/Yellow/Default/button_square_line.png.meta |   130 +
 .../PNG/Yellow/Default/check_round_color.png       |   Bin 0 -> 579 bytes
 .../PNG/Yellow/Default/check_round_color.png.meta  |   130 +
 .../PNG/Yellow/Default/check_round_grey.png        |   Bin 0 -> 579 bytes
 .../PNG/Yellow/Default/check_round_grey.png.meta   |   130 +
 .../PNG/Yellow/Default/check_round_grey_circle.png |   Bin 0 -> 774 bytes
 .../Default/check_round_grey_circle.png.meta       |   130 +
 .../Yellow/Default/check_round_round_circle.png    |   Bin 0 -> 743 bytes
 .../Default/check_round_round_circle.png.meta      |   130 +
 .../PNG/Yellow/Default/check_square_color.png      |   Bin 0 -> 280 bytes
 .../PNG/Yellow/Default/check_square_color.png.meta |   130 +
 .../Default/check_square_color_checkmark.png       |   Bin 0 -> 498 bytes
 .../Default/check_square_color_checkmark.png.meta  |   130 +
 .../Yellow/Default/check_square_color_cross.png    |   Bin 0 -> 501 bytes
 .../Default/check_square_color_cross.png.meta      |   130 +
 .../Yellow/Default/check_square_color_square.png   |   Bin 0 -> 318 bytes
 .../Default/check_square_color_square.png.meta     |   130 +
 .../PNG/Yellow/Default/check_square_grey.png       |   Bin 0 -> 280 bytes
 .../PNG/Yellow/Default/check_square_grey.png.meta  |   130 +
 .../Yellow/Default/check_square_grey_checkmark.png |   Bin 0 -> 559 bytes
 .../Default/check_square_grey_checkmark.png.meta   |   130 +
 .../PNG/Yellow/Default/check_square_grey_cross.png |   Bin 0 -> 539 bytes
 .../Default/check_square_grey_cross.png.meta       |   130 +
 .../Yellow/Default/check_square_grey_square.png    |   Bin 0 -> 321 bytes
 .../Default/check_square_grey_square.png.meta      |   130 +
 .../PNG/Yellow/Default/icon_checkmark.png          |   Bin 0 -> 377 bytes
 .../PNG/Yellow/Default/icon_checkmark.png.meta     |   130 +
 .../PNG/Yellow/Default/icon_circle.png             |   Bin 0 -> 313 bytes
 .../PNG/Yellow/Default/icon_circle.png.meta        |   130 +
 .../PNG/Yellow/Default/icon_cross.png              |   Bin 0 -> 350 bytes
 .../PNG/Yellow/Default/icon_cross.png.meta         |   130 +
 .../PNG/Yellow/Default/icon_outline_checkmark.png  |   Bin 0 -> 377 bytes
 .../Yellow/Default/icon_outline_checkmark.png.meta |   130 +
 .../PNG/Yellow/Default/icon_outline_circle.png     |   Bin 0 -> 312 bytes
 .../Yellow/Default/icon_outline_circle.png.meta    |   130 +
 .../PNG/Yellow/Default/icon_outline_cross.png      |   Bin 0 -> 351 bytes
 .../PNG/Yellow/Default/icon_outline_cross.png.meta |   130 +
 .../PNG/Yellow/Default/icon_outline_square.png     |   Bin 0 -> 128 bytes
 .../Yellow/Default/icon_outline_square.png.meta    |   130 +
 .../PNG/Yellow/Default/icon_square.png             |   Bin 0 -> 130 bytes
 .../PNG/Yellow/Default/icon_square.png.meta        |   130 +
 .../PNG/Yellow/Default/slide_hangle.png            |   Bin 0 -> 297 bytes
 .../PNG/Yellow/Default/slide_hangle.png.meta       |   130 +
 .../PNG/Yellow/Default/slide_horizontal_color.png  |   Bin 0 -> 382 bytes
 .../Yellow/Default/slide_horizontal_color.png.meta |   130 +
 .../Default/slide_horizontal_color_section.png     |   Bin 0 -> 321 bytes
 .../slide_horizontal_color_section.png.meta        |   130 +
 .../slide_horizontal_color_section_wide.png        |   Bin 0 -> 336 bytes
 .../slide_horizontal_color_section_wide.png.meta   |   130 +
 .../PNG/Yellow/Default/slide_horizontal_grey.png   |   Bin 0 -> 383 bytes
 .../Yellow/Default/slide_horizontal_grey.png.meta  |   130 +
 .../Default/slide_horizontal_grey_section.png      |   Bin 0 -> 321 bytes
 .../Default/slide_horizontal_grey_section.png.meta |   130 +
 .../Default/slide_horizontal_grey_section_wide.png |   Bin 0 -> 336 bytes
 .../slide_horizontal_grey_section_wide.png.meta    |   130 +
 .../PNG/Yellow/Default/slide_vertical_color.png    |   Bin 0 -> 379 bytes
 .../Yellow/Default/slide_vertical_color.png.meta   |   130 +
 .../Default/slide_vertical_color_section.png       |   Bin 0 -> 308 bytes
 .../Default/slide_vertical_color_section.png.meta  |   130 +
 .../Default/slide_vertical_color_section_wide.png  |   Bin 0 -> 316 bytes
 .../slide_vertical_color_section_wide.png.meta     |   130 +
 .../PNG/Yellow/Default/slide_vertical_grey.png     |   Bin 0 -> 379 bytes
 .../Yellow/Default/slide_vertical_grey.png.meta    |   130 +
 .../Yellow/Default/slide_vertical_grey_section.png |   Bin 0 -> 308 bytes
 .../Default/slide_vertical_grey_section.png.meta   |   130 +
 .../Default/slide_vertical_grey_section_wide.png   |   Bin 0 -> 316 bytes
 .../slide_vertical_grey_section_wide.png.meta      |   130 +
 .../kenney_ui-pack/PNG/Yellow/Default/star.png     |   Bin 0 -> 1593 bytes
 .../PNG/Yellow/Default/star.png.meta               |   130 +
 .../PNG/Yellow/Default/star_outline.png            |   Bin 0 -> 955 bytes
 .../PNG/Yellow/Default/star_outline.png.meta       |   130 +
 .../PNG/Yellow/Default/star_outline_depth.png      |   Bin 0 -> 1168 bytes
 .../PNG/Yellow/Default/star_outline_depth.png.meta |   130 +
 .../NewUI/kenney_ui-pack/PNG/Yellow/Double.meta    |     8 +
 .../PNG/Yellow/Double/arrow_basic_e.png            |   Bin 0 -> 638 bytes
 .../PNG/Yellow/Double/arrow_basic_e.png.meta       |   130 +
 .../PNG/Yellow/Double/arrow_basic_e_small.png      |   Bin 0 -> 523 bytes
 .../PNG/Yellow/Double/arrow_basic_e_small.png.meta |   130 +
 .../PNG/Yellow/Double/arrow_basic_n.png            |   Bin 0 -> 622 bytes
 .../PNG/Yellow/Double/arrow_basic_n.png.meta       |   130 +
 .../PNG/Yellow/Double/arrow_basic_n_small.png      |   Bin 0 -> 472 bytes
 .../PNG/Yellow/Double/arrow_basic_n_small.png.meta |   130 +
 .../PNG/Yellow/Double/arrow_basic_s.png            |   Bin 0 -> 694 bytes
 .../PNG/Yellow/Double/arrow_basic_s.png.meta       |   130 +
 .../PNG/Yellow/Double/arrow_basic_s_small.png      |   Bin 0 -> 533 bytes
 .../PNG/Yellow/Double/arrow_basic_s_small.png.meta |   130 +
 .../PNG/Yellow/Double/arrow_basic_w.png            |   Bin 0 -> 639 bytes
 .../PNG/Yellow/Double/arrow_basic_w.png.meta       |   130 +
 .../PNG/Yellow/Double/arrow_basic_w_small.png      |   Bin 0 -> 550 bytes
 .../PNG/Yellow/Double/arrow_basic_w_small.png.meta |   130 +
 .../PNG/Yellow/Double/arrow_decorative_e.png       |   Bin 0 -> 860 bytes
 .../PNG/Yellow/Double/arrow_decorative_e.png.meta  |   130 +
 .../PNG/Yellow/Double/arrow_decorative_e_small.png |   Bin 0 -> 697 bytes
 .../Double/arrow_decorative_e_small.png.meta       |   130 +
 .../PNG/Yellow/Double/arrow_decorative_n.png       |   Bin 0 -> 880 bytes
 .../PNG/Yellow/Double/arrow_decorative_n.png.meta  |   130 +
 .../PNG/Yellow/Double/arrow_decorative_n_small.png |   Bin 0 -> 649 bytes
 .../Double/arrow_decorative_n_small.png.meta       |   130 +
 .../PNG/Yellow/Double/arrow_decorative_s.png       |   Bin 0 -> 951 bytes
 .../PNG/Yellow/Double/arrow_decorative_s.png.meta  |   130 +
 .../PNG/Yellow/Double/arrow_decorative_s_small.png |   Bin 0 -> 684 bytes
 .../Double/arrow_decorative_s_small.png.meta       |   130 +
 .../PNG/Yellow/Double/arrow_decorative_w.png       |   Bin 0 -> 901 bytes
 .../PNG/Yellow/Double/arrow_decorative_w.png.meta  |   130 +
 .../PNG/Yellow/Double/arrow_decorative_w_small.png |   Bin 0 -> 721 bytes
 .../Double/arrow_decorative_w_small.png.meta       |   130 +
 .../PNG/Yellow/Double/button_rectangle_border.png  |   Bin 0 -> 693 bytes
 .../Yellow/Double/button_rectangle_border.png.meta |   130 +
 .../Double/button_rectangle_depth_border.png       |   Bin 0 -> 820 bytes
 .../Double/button_rectangle_depth_border.png.meta  |   130 +
 .../Yellow/Double/button_rectangle_depth_flat.png  |   Bin 0 -> 784 bytes
 .../Double/button_rectangle_depth_flat.png.meta    |   130 +
 .../Yellow/Double/button_rectangle_depth_gloss.png |   Bin 0 -> 748 bytes
 .../Double/button_rectangle_depth_gloss.png.meta   |   130 +
 .../Double/button_rectangle_depth_gradient.png     |   Bin 0 -> 1300 bytes
 .../button_rectangle_depth_gradient.png.meta       |   130 +
 .../Yellow/Double/button_rectangle_depth_line.png  |   Bin 0 -> 817 bytes
 .../Double/button_rectangle_depth_line.png.meta    |   130 +
 .../PNG/Yellow/Double/button_rectangle_flat.png    |   Bin 0 -> 660 bytes
 .../Yellow/Double/button_rectangle_flat.png.meta   |   130 +
 .../PNG/Yellow/Double/button_rectangle_gloss.png   |   Bin 0 -> 623 bytes
 .../Yellow/Double/button_rectangle_gloss.png.meta  |   130 +
 .../Yellow/Double/button_rectangle_gradient.png    |   Bin 0 -> 1221 bytes
 .../Double/button_rectangle_gradient.png.meta      |   130 +
 .../PNG/Yellow/Double/button_rectangle_line.png    |   Bin 0 -> 689 bytes
 .../Yellow/Double/button_rectangle_line.png.meta   |   130 +
 .../PNG/Yellow/Double/button_round_border.png      |   Bin 0 -> 2794 bytes
 .../PNG/Yellow/Double/button_round_border.png.meta |   130 +
 .../Yellow/Double/button_round_depth_border.png    |   Bin 0 -> 3366 bytes
 .../Double/button_round_depth_border.png.meta      |   130 +
 .../PNG/Yellow/Double/button_round_depth_flat.png  |   Bin 0 -> 2476 bytes
 .../Yellow/Double/button_round_depth_flat.png.meta |   130 +
 .../PNG/Yellow/Double/button_round_depth_gloss.png |   Bin 0 -> 2263 bytes
 .../Double/button_round_depth_gloss.png.meta       |   130 +
 .../Yellow/Double/button_round_depth_gradient.png  |   Bin 0 -> 3044 bytes
 .../Double/button_round_depth_gradient.png.meta    |   130 +
 .../PNG/Yellow/Double/button_round_depth_line.png  |   Bin 0 -> 3231 bytes
 .../Yellow/Double/button_round_depth_line.png.meta |   130 +
 .../PNG/Yellow/Double/button_round_flat.png        |   Bin 0 -> 1863 bytes
 .../PNG/Yellow/Double/button_round_flat.png.meta   |   130 +
 .../PNG/Yellow/Double/button_round_gloss.png       |   Bin 0 -> 1734 bytes
 .../PNG/Yellow/Double/button_round_gloss.png.meta  |   130 +
 .../PNG/Yellow/Double/button_round_gradient.png    |   Bin 0 -> 2551 bytes
 .../Yellow/Double/button_round_gradient.png.meta   |   130 +
 .../PNG/Yellow/Double/button_round_line.png        |   Bin 0 -> 2669 bytes
 .../PNG/Yellow/Double/button_round_line.png.meta   |   130 +
 .../PNG/Yellow/Double/button_square_border.png     |   Bin 0 -> 544 bytes
 .../Yellow/Double/button_square_border.png.meta    |   130 +
 .../Yellow/Double/button_square_depth_border.png   |   Bin 0 -> 685 bytes
 .../Double/button_square_depth_border.png.meta     |   130 +
 .../PNG/Yellow/Double/button_square_depth_flat.png |   Bin 0 -> 652 bytes
 .../Double/button_square_depth_flat.png.meta       |   130 +
 .../Yellow/Double/button_square_depth_gloss.png    |   Bin 0 -> 630 bytes
 .../Double/button_square_depth_gloss.png.meta      |   130 +
 .../Yellow/Double/button_square_depth_gradient.png |   Bin 0 -> 1196 bytes
 .../Double/button_square_depth_gradient.png.meta   |   130 +
 .../PNG/Yellow/Double/button_square_depth_line.png |   Bin 0 -> 683 bytes
 .../Double/button_square_depth_line.png.meta       |   130 +
 .../PNG/Yellow/Double/button_square_flat.png       |   Bin 0 -> 523 bytes
 .../PNG/Yellow/Double/button_square_flat.png.meta  |   130 +
 .../PNG/Yellow/Double/button_square_gloss.png      |   Bin 0 -> 502 bytes
 .../PNG/Yellow/Double/button_square_gloss.png.meta |   130 +
 .../PNG/Yellow/Double/button_square_gradient.png   |   Bin 0 -> 1111 bytes
 .../Yellow/Double/button_square_gradient.png.meta  |   130 +
 .../PNG/Yellow/Double/button_square_line.png       |   Bin 0 -> 542 bytes
 .../PNG/Yellow/Double/button_square_line.png.meta  |   130 +
 .../PNG/Yellow/Double/check_round_color.png        |   Bin 0 -> 1040 bytes
 .../PNG/Yellow/Double/check_round_color.png.meta   |   130 +
 .../PNG/Yellow/Double/check_round_grey.png         |   Bin 0 -> 1041 bytes
 .../PNG/Yellow/Double/check_round_grey.png.meta    |   130 +
 .../PNG/Yellow/Double/check_round_grey_circle.png  |   Bin 0 -> 1387 bytes
 .../Yellow/Double/check_round_grey_circle.png.meta |   130 +
 .../PNG/Yellow/Double/check_round_round_circle.png |   Bin 0 -> 1316 bytes
 .../Double/check_round_round_circle.png.meta       |   130 +
 .../PNG/Yellow/Double/check_square_color.png       |   Bin 0 -> 465 bytes
 .../PNG/Yellow/Double/check_square_color.png.meta  |   130 +
 .../Yellow/Double/check_square_color_checkmark.png |   Bin 0 -> 871 bytes
 .../Double/check_square_color_checkmark.png.meta   |   130 +
 .../PNG/Yellow/Double/check_square_color_cross.png |   Bin 0 -> 849 bytes
 .../Double/check_square_color_cross.png.meta       |   130 +
 .../Yellow/Double/check_square_color_square.png    |   Bin 0 -> 535 bytes
 .../Double/check_square_color_square.png.meta      |   130 +
 .../PNG/Yellow/Double/check_square_grey.png        |   Bin 0 -> 466 bytes
 .../PNG/Yellow/Double/check_square_grey.png.meta   |   130 +
 .../Yellow/Double/check_square_grey_checkmark.png  |   Bin 0 -> 958 bytes
 .../Double/check_square_grey_checkmark.png.meta    |   130 +
 .../PNG/Yellow/Double/check_square_grey_cross.png  |   Bin 0 -> 908 bytes
 .../Yellow/Double/check_square_grey_cross.png.meta |   130 +
 .../PNG/Yellow/Double/check_square_grey_square.png |   Bin 0 -> 539 bytes
 .../Double/check_square_grey_square.png.meta       |   130 +
 .../PNG/Yellow/Double/icon_checkmark.png           |   Bin 0 -> 585 bytes
 .../PNG/Yellow/Double/icon_checkmark.png.meta      |   130 +
 .../PNG/Yellow/Double/icon_circle.png              |   Bin 0 -> 466 bytes
 .../PNG/Yellow/Double/icon_circle.png.meta         |   130 +
 .../PNG/Yellow/Double/icon_cross.png               |   Bin 0 -> 516 bytes
 .../PNG/Yellow/Double/icon_cross.png.meta          |   130 +
 .../PNG/Yellow/Double/icon_outline_checkmark.png   |   Bin 0 -> 583 bytes
 .../Yellow/Double/icon_outline_checkmark.png.meta  |   130 +
 .../PNG/Yellow/Double/icon_outline_circle.png      |   Bin 0 -> 466 bytes
 .../PNG/Yellow/Double/icon_outline_circle.png.meta |   130 +
 .../PNG/Yellow/Double/icon_outline_cross.png       |   Bin 0 -> 516 bytes
 .../PNG/Yellow/Double/icon_outline_cross.png.meta  |   130 +
 .../PNG/Yellow/Double/icon_outline_square.png      |   Bin 0 -> 183 bytes
 .../PNG/Yellow/Double/icon_outline_square.png.meta |   130 +
 .../PNG/Yellow/Double/icon_square.png              |   Bin 0 -> 183 bytes
 .../PNG/Yellow/Double/icon_square.png.meta         |   130 +
 .../PNG/Yellow/Double/slide_hangle.png             |   Bin 0 -> 440 bytes
 .../PNG/Yellow/Double/slide_hangle.png.meta        |   130 +
 .../PNG/Yellow/Double/slide_horizontal_color.png   |   Bin 0 -> 614 bytes
 .../Yellow/Double/slide_horizontal_color.png.meta  |   130 +
 .../Double/slide_horizontal_color_section.png      |   Bin 0 -> 432 bytes
 .../Double/slide_horizontal_color_section.png.meta |   130 +
 .../Double/slide_horizontal_color_section_wide.png |   Bin 0 -> 439 bytes
 .../slide_horizontal_color_section_wide.png.meta   |   130 +
 .../PNG/Yellow/Double/slide_horizontal_grey.png    |   Bin 0 -> 614 bytes
 .../Yellow/Double/slide_horizontal_grey.png.meta   |   130 +
 .../Double/slide_horizontal_grey_section.png       |   Bin 0 -> 430 bytes
 .../Double/slide_horizontal_grey_section.png.meta  |   130 +
 .../Double/slide_horizontal_grey_section_wide.png  |   Bin 0 -> 439 bytes
 .../slide_horizontal_grey_section_wide.png.meta    |   130 +
 .../PNG/Yellow/Double/slide_vertical_color.png     |   Bin 0 -> 611 bytes
 .../Yellow/Double/slide_vertical_color.png.meta    |   130 +
 .../Yellow/Double/slide_vertical_color_section.png |   Bin 0 -> 460 bytes
 .../Double/slide_vertical_color_section.png.meta   |   130 +
 .../Double/slide_vertical_color_section_wide.png   |   Bin 0 -> 474 bytes
 .../slide_vertical_color_section_wide.png.meta     |   130 +
 .../PNG/Yellow/Double/slide_vertical_grey.png      |   Bin 0 -> 611 bytes
 .../PNG/Yellow/Double/slide_vertical_grey.png.meta |   130 +
 .../Yellow/Double/slide_vertical_grey_section.png  |   Bin 0 -> 461 bytes
 .../Double/slide_vertical_grey_section.png.meta    |   130 +
 .../Double/slide_vertical_grey_section_wide.png    |   Bin 0 -> 473 bytes
 .../slide_vertical_grey_section_wide.png.meta      |   130 +
 .../kenney_ui-pack/PNG/Yellow/Double/star.png      |   Bin 0 -> 2900 bytes
 .../kenney_ui-pack/PNG/Yellow/Double/star.png.meta |   130 +
 .../PNG/Yellow/Double/star_outline.png             |   Bin 0 -> 1800 bytes
 .../PNG/Yellow/Double/star_outline.png.meta        |   130 +
 .../PNG/Yellow/Double/star_outline_depth.png       |   Bin 0 -> 2141 bytes
 .../PNG/Yellow/Double/star_outline_depth.png.meta  |   130 +
 .../textures/NewUI/kenney_ui-pack/Preview.png      |   Bin 0 -> 28908 bytes
 .../textures/NewUI/kenney_ui-pack/Preview.png.meta |   130 +
 .../textures/NewUI/kenney_ui-pack/Sample.png       |   Bin 0 -> 30629 bytes
 .../textures/NewUI/kenney_ui-pack/Sample.png.meta  |   130 +
 .../textures/NewUI/kenney_ui-pack/Sounds.meta      |     8 +
 .../NewUI/kenney_ui-pack/Sounds/click-a.ogg        |   Bin 0 -> 10945 bytes
 .../NewUI/kenney_ui-pack/Sounds/click-a.ogg.meta   |    23 +
 .../NewUI/kenney_ui-pack/Sounds/click-b.ogg        |   Bin 0 -> 6157 bytes
 .../NewUI/kenney_ui-pack/Sounds/click-b.ogg.meta   |    23 +
 .../NewUI/kenney_ui-pack/Sounds/switch-a.ogg       |   Bin 0 -> 9433 bytes
 .../NewUI/kenney_ui-pack/Sounds/switch-a.ogg.meta  |    23 +
 .../NewUI/kenney_ui-pack/Sounds/switch-b.ogg       |   Bin 0 -> 10138 bytes
 .../NewUI/kenney_ui-pack/Sounds/switch-b.ogg.meta  |    23 +
 .../textures/NewUI/kenney_ui-pack/Sounds/tap-a.ogg |   Bin 0 -> 7043 bytes
 .../NewUI/kenney_ui-pack/Sounds/tap-a.ogg.meta     |    23 +
 .../textures/NewUI/kenney_ui-pack/Sounds/tap-b.ogg |   Bin 0 -> 6119 bytes
 .../NewUI/kenney_ui-pack/Sounds/tap-b.ogg.meta     |    23 +
 .../textures/NewUI/kenney_ui-pack/Vector.meta      |     8 +
 .../textures/NewUI/kenney_ui-pack/Vector/Blue.meta |     8 +
 .../kenney_ui-pack/Vector/Blue/arrow_basic_e.svg   |     8 +
 .../Vector/Blue/arrow_basic_e.svg.meta             |    53 +
 .../Vector/Blue/arrow_basic_e_small.svg            |     8 +
 .../Vector/Blue/arrow_basic_e_small.svg.meta       |    53 +
 .../kenney_ui-pack/Vector/Blue/arrow_basic_n.svg   |     8 +
 .../Vector/Blue/arrow_basic_n.svg.meta             |    53 +
 .../Vector/Blue/arrow_basic_n_small.svg            |     8 +
 .../Vector/Blue/arrow_basic_n_small.svg.meta       |    53 +
 .../kenney_ui-pack/Vector/Blue/arrow_basic_s.svg   |     8 +
 .../Vector/Blue/arrow_basic_s.svg.meta             |    53 +
 .../Vector/Blue/arrow_basic_s_small.svg            |     8 +
 .../Vector/Blue/arrow_basic_s_small.svg.meta       |    53 +
 .../kenney_ui-pack/Vector/Blue/arrow_basic_w.svg   |     8 +
 .../Vector/Blue/arrow_basic_w.svg.meta             |    53 +
 .../Vector/Blue/arrow_basic_w_small.svg            |     8 +
 .../Vector/Blue/arrow_basic_w_small.svg.meta       |    53 +
 .../Vector/Blue/arrow_decorative_e.svg             |     8 +
 .../Vector/Blue/arrow_decorative_e.svg.meta        |    53 +
 .../Vector/Blue/arrow_decorative_e_small.svg       |     8 +
 .../Vector/Blue/arrow_decorative_e_small.svg.meta  |    53 +
 .../Vector/Blue/arrow_decorative_n.svg             |     8 +
 .../Vector/Blue/arrow_decorative_n.svg.meta        |    53 +
 .../Vector/Blue/arrow_decorative_n_small.svg       |     8 +
 .../Vector/Blue/arrow_decorative_n_small.svg.meta  |    53 +
 .../Vector/Blue/arrow_decorative_s.svg             |     8 +
 .../Vector/Blue/arrow_decorative_s.svg.meta        |    53 +
 .../Vector/Blue/arrow_decorative_s_small.svg       |     8 +
 .../Vector/Blue/arrow_decorative_s_small.svg.meta  |    53 +
 .../Vector/Blue/arrow_decorative_w.svg             |     8 +
 .../Vector/Blue/arrow_decorative_w.svg.meta        |    53 +
 .../Vector/Blue/arrow_decorative_w_small.svg       |     8 +
 .../Vector/Blue/arrow_decorative_w_small.svg.meta  |    53 +
 .../Vector/Blue/button_rectangle_border.svg        |    10 +
 .../Vector/Blue/button_rectangle_border.svg.meta   |    53 +
 .../Vector/Blue/button_rectangle_depth_border.svg  |    12 +
 .../Blue/button_rectangle_depth_border.svg.meta    |    53 +
 .../Vector/Blue/button_rectangle_depth_flat.svg    |     9 +
 .../Blue/button_rectangle_depth_flat.svg.meta      |    53 +
 .../Vector/Blue/button_rectangle_depth_gloss.svg   |     9 +
 .../Blue/button_rectangle_depth_gloss.svg.meta     |    53 +
 .../Blue/button_rectangle_depth_gradient.svg       |    14 +
 .../Blue/button_rectangle_depth_gradient.svg.meta  |    53 +
 .../Vector/Blue/button_rectangle_depth_line.svg    |    11 +
 .../Blue/button_rectangle_depth_line.svg.meta      |    53 +
 .../Vector/Blue/button_rectangle_flat.svg          |     8 +
 .../Vector/Blue/button_rectangle_flat.svg.meta     |    53 +
 .../Vector/Blue/button_rectangle_gloss.svg         |     8 +
 .../Vector/Blue/button_rectangle_gloss.svg.meta    |    53 +
 .../Vector/Blue/button_rectangle_gradient.svg      |    13 +
 .../Vector/Blue/button_rectangle_gradient.svg.meta |    53 +
 .../Vector/Blue/button_rectangle_line.svg          |     9 +
 .../Vector/Blue/button_rectangle_line.svg.meta     |    53 +
 .../Vector/Blue/button_round_border.svg            |    10 +
 .../Vector/Blue/button_round_border.svg.meta       |    53 +
 .../Vector/Blue/button_round_depth_border.svg      |    11 +
 .../Vector/Blue/button_round_depth_border.svg.meta |    53 +
 .../Vector/Blue/button_round_depth_flat.svg        |     9 +
 .../Vector/Blue/button_round_depth_flat.svg.meta   |    53 +
 .../Vector/Blue/button_round_depth_gloss.svg       |     9 +
 .../Vector/Blue/button_round_depth_gloss.svg.meta  |    53 +
 .../Vector/Blue/button_round_depth_gradient.svg    |    14 +
 .../Blue/button_round_depth_gradient.svg.meta      |    53 +
 .../Vector/Blue/button_round_depth_line.svg        |    10 +
 .../Vector/Blue/button_round_depth_line.svg.meta   |    53 +
 .../Vector/Blue/button_round_flat.svg              |     8 +
 .../Vector/Blue/button_round_flat.svg.meta         |    53 +
 .../Vector/Blue/button_round_gloss.svg             |     8 +
 .../Vector/Blue/button_round_gloss.svg.meta        |    53 +
 .../Vector/Blue/button_round_gradient.svg          |    13 +
 .../Vector/Blue/button_round_gradient.svg.meta     |    53 +
 .../Vector/Blue/button_round_line.svg              |     9 +
 .../Vector/Blue/button_round_line.svg.meta         |    53 +
 .../Vector/Blue/button_square_border.svg           |    10 +
 .../Vector/Blue/button_square_border.svg.meta      |    53 +
 .../Vector/Blue/button_square_depth_border.svg     |    12 +
 .../Blue/button_square_depth_border.svg.meta       |    53 +
 .../Vector/Blue/button_square_depth_flat.svg       |    10 +
 .../Vector/Blue/button_square_depth_flat.svg.meta  |    53 +
 .../Vector/Blue/button_square_depth_gloss.svg      |     9 +
 .../Vector/Blue/button_square_depth_gloss.svg.meta |    53 +
 .../Vector/Blue/button_square_depth_gradient.svg   |    14 +
 .../Blue/button_square_depth_gradient.svg.meta     |    53 +
 .../Vector/Blue/button_square_depth_line.svg       |    11 +
 .../Vector/Blue/button_square_depth_line.svg.meta  |    53 +
 .../Vector/Blue/button_square_flat.svg             |     8 +
 .../Vector/Blue/button_square_flat.svg.meta        |    53 +
 .../Vector/Blue/button_square_gloss.svg            |     9 +
 .../Vector/Blue/button_square_gloss.svg.meta       |    53 +
 .../Vector/Blue/button_square_gradient.svg         |    14 +
 .../Vector/Blue/button_square_gradient.svg.meta    |    53 +
 .../Vector/Blue/button_square_line.svg             |     9 +
 .../Vector/Blue/button_square_line.svg.meta        |    53 +
 .../Vector/Blue/check_round_color.svg              |     8 +
 .../Vector/Blue/check_round_color.svg.meta         |    53 +
 .../Vector/Blue/check_round_grey.svg               |     8 +
 .../Vector/Blue/check_round_grey.svg.meta          |    53 +
 .../Vector/Blue/check_round_grey_circle.svg        |    10 +
 .../Vector/Blue/check_round_grey_circle.svg.meta   |    53 +
 .../Vector/Blue/check_round_round_circle.svg       |    10 +
 .../Vector/Blue/check_round_round_circle.svg.meta  |    53 +
 .../Vector/Blue/check_square_color.svg             |     8 +
 .../Vector/Blue/check_square_color.svg.meta        |    53 +
 .../Vector/Blue/check_square_color_checkmark.svg   |    10 +
 .../Blue/check_square_color_checkmark.svg.meta     |    53 +
 .../Vector/Blue/check_square_color_cross.svg       |    10 +
 .../Vector/Blue/check_square_color_cross.svg.meta  |    53 +
 .../Vector/Blue/check_square_color_square.svg      |    10 +
 .../Vector/Blue/check_square_color_square.svg.meta |    53 +
 .../Vector/Blue/check_square_grey.svg              |     8 +
 .../Vector/Blue/check_square_grey.svg.meta         |    53 +
 .../Vector/Blue/check_square_grey_checkmark.svg    |    10 +
 .../Blue/check_square_grey_checkmark.svg.meta      |    53 +
 .../Vector/Blue/check_square_grey_cross.svg        |    10 +
 .../Vector/Blue/check_square_grey_cross.svg.meta   |    53 +
 .../Vector/Blue/check_square_grey_square.svg       |    10 +
 .../Vector/Blue/check_square_grey_square.svg.meta  |    53 +
 .../kenney_ui-pack/Vector/Blue/icon_checkmark.svg  |     7 +
 .../Vector/Blue/icon_checkmark.svg.meta            |    53 +
 .../kenney_ui-pack/Vector/Blue/icon_circle.svg     |     7 +
 .../Vector/Blue/icon_circle.svg.meta               |    53 +
 .../kenney_ui-pack/Vector/Blue/icon_cross.svg      |     7 +
 .../kenney_ui-pack/Vector/Blue/icon_cross.svg.meta |    53 +
 .../Vector/Blue/icon_outline_checkmark.svg         |     7 +
 .../Vector/Blue/icon_outline_checkmark.svg.meta    |    53 +
 .../Vector/Blue/icon_outline_circle.svg            |     7 +
 .../Vector/Blue/icon_outline_circle.svg.meta       |    53 +
 .../Vector/Blue/icon_outline_cross.svg             |     7 +
 .../Vector/Blue/icon_outline_cross.svg.meta        |    53 +
 .../Vector/Blue/icon_outline_square.svg            |     7 +
 .../Vector/Blue/icon_outline_square.svg.meta       |    53 +
 .../kenney_ui-pack/Vector/Blue/icon_square.svg     |     7 +
 .../Vector/Blue/icon_square.svg.meta               |    53 +
 .../kenney_ui-pack/Vector/Blue/slide_hangle.svg    |     8 +
 .../Vector/Blue/slide_hangle.svg.meta              |    53 +
 .../Vector/Blue/slide_horizontal_color.svg         |     7 +
 .../Vector/Blue/slide_horizontal_color.svg.meta    |    53 +
 .../Vector/Blue/slide_horizontal_color_section.svg |     7 +
 .../Blue/slide_horizontal_color_section.svg.meta   |    53 +
 .../Blue/slide_horizontal_color_section_wide.svg   |     7 +
 .../slide_horizontal_color_section_wide.svg.meta   |    53 +
 .../Vector/Blue/slide_horizontal_grey.svg          |     7 +
 .../Vector/Blue/slide_horizontal_grey.svg.meta     |    53 +
 .../Vector/Blue/slide_horizontal_grey_section.svg  |     7 +
 .../Blue/slide_horizontal_grey_section.svg.meta    |    53 +
 .../Blue/slide_horizontal_grey_section_wide.svg    |     7 +
 .../slide_horizontal_grey_section_wide.svg.meta    |    53 +
 .../Vector/Blue/slide_vertical_color.svg           |     7 +
 .../Vector/Blue/slide_vertical_color.svg.meta      |    53 +
 .../Vector/Blue/slide_vertical_color_section.svg   |     7 +
 .../Blue/slide_vertical_color_section.svg.meta     |    53 +
 .../Blue/slide_vertical_color_section_wide.svg     |     7 +
 .../slide_vertical_color_section_wide.svg.meta     |    53 +
 .../Vector/Blue/slide_vertical_grey.svg            |     7 +
 .../Vector/Blue/slide_vertical_grey.svg.meta       |    53 +
 .../Vector/Blue/slide_vertical_grey_section.svg    |     7 +
 .../Blue/slide_vertical_grey_section.svg.meta      |    53 +
 .../Blue/slide_vertical_grey_section_wide.svg      |     7 +
 .../Blue/slide_vertical_grey_section_wide.svg.meta |    53 +
 .../NewUI/kenney_ui-pack/Vector/Blue/star.svg      |    18 +
 .../NewUI/kenney_ui-pack/Vector/Blue/star.svg.meta |    53 +
 .../kenney_ui-pack/Vector/Blue/star_outline.svg    |     7 +
 .../Vector/Blue/star_outline.svg.meta              |    53 +
 .../Vector/Blue/star_outline_depth.svg             |    12 +
 .../Vector/Blue/star_outline_depth.svg.meta        |    53 +
 .../NewUI/kenney_ui-pack/Vector/Extra.meta         |     8 +
 .../Vector/Extra/button_rectangle_depth_line.svg   |    10 +
 .../Extra/button_rectangle_depth_line.svg.meta     |    53 +
 .../Vector/Extra/button_rectangle_line.svg         |     8 +
 .../Vector/Extra/button_rectangle_line.svg.meta    |    53 +
 .../Vector/Extra/button_round_depth_line.svg       |     9 +
 .../Vector/Extra/button_round_depth_line.svg.meta  |    53 +
 .../Vector/Extra/button_round_line.svg             |     8 +
 .../Vector/Extra/button_round_line.svg.meta        |    53 +
 .../Vector/Extra/button_square_depth_line.svg      |    10 +
 .../Vector/Extra/button_square_depth_line.svg.meta |    53 +
 .../Vector/Extra/button_square_line.svg            |     8 +
 .../Vector/Extra/button_square_line.svg.meta       |    53 +
 .../NewUI/kenney_ui-pack/Vector/Extra/divider.svg  |     7 +
 .../kenney_ui-pack/Vector/Extra/divider.svg.meta   |    53 +
 .../kenney_ui-pack/Vector/Extra/divider_edges.svg  |     7 +
 .../Vector/Extra/divider_edges.svg.meta            |    53 +
 .../Vector/Extra/icon_arrow_down_dark.svg          |     6 +
 .../Vector/Extra/icon_arrow_down_dark.svg.meta     |    53 +
 .../Vector/Extra/icon_arrow_down_light.svg         |     6 +
 .../Vector/Extra/icon_arrow_down_light.svg.meta    |    53 +
 .../Vector/Extra/icon_arrow_down_outline.svg       |     7 +
 .../Vector/Extra/icon_arrow_down_outline.svg.meta  |    53 +
 .../Vector/Extra/icon_arrow_up_dark.svg            |     6 +
 .../Vector/Extra/icon_arrow_up_dark.svg.meta       |    53 +
 .../Vector/Extra/icon_arrow_up_light.svg           |     6 +
 .../Vector/Extra/icon_arrow_up_light.svg.meta      |    53 +
 .../Vector/Extra/icon_arrow_up_outline.svg         |     7 +
 .../Vector/Extra/icon_arrow_up_outline.svg.meta    |    53 +
 .../kenney_ui-pack/Vector/Extra/icon_play_dark.svg |     6 +
 .../Vector/Extra/icon_play_dark.svg.meta           |    53 +
 .../Vector/Extra/icon_play_light.svg               |     6 +
 .../Vector/Extra/icon_play_light.svg.meta          |    53 +
 .../Vector/Extra/icon_play_outline.svg             |     7 +
 .../Vector/Extra/icon_play_outline.svg.meta        |    53 +
 .../Vector/Extra/icon_repeat_dark.svg              |     6 +
 .../Vector/Extra/icon_repeat_dark.svg.meta         |    53 +
 .../Vector/Extra/icon_repeat_light.svg             |     6 +
 .../Vector/Extra/icon_repeat_light.svg.meta        |    53 +
 .../Vector/Extra/icon_repeat_outline.svg           |     7 +
 .../Vector/Extra/icon_repeat_outline.svg.meta      |    53 +
 .../Vector/Extra/input_outline_rectangle.svg       |     8 +
 .../Vector/Extra/input_outline_rectangle.svg.meta  |    53 +
 .../Vector/Extra/input_outline_square.svg          |     8 +
 .../Vector/Extra/input_outline_square.svg.meta     |    53 +
 .../Vector/Extra/input_rectangle.svg               |     8 +
 .../Vector/Extra/input_rectangle.svg.meta          |    53 +
 .../kenney_ui-pack/Vector/Extra/input_square.svg   |     8 +
 .../Vector/Extra/input_square.svg.meta             |    53 +
 .../NewUI/kenney_ui-pack/Vector/Green.meta         |     8 +
 .../kenney_ui-pack/Vector/Green/arrow_basic_e.svg  |     8 +
 .../Vector/Green/arrow_basic_e.svg.meta            |    53 +
 .../Vector/Green/arrow_basic_e_small.svg           |     8 +
 .../Vector/Green/arrow_basic_e_small.svg.meta      |    53 +
 .../kenney_ui-pack/Vector/Green/arrow_basic_n.svg  |     8 +
 .../Vector/Green/arrow_basic_n.svg.meta            |    53 +
 .../Vector/Green/arrow_basic_n_small.svg           |     8 +
 .../Vector/Green/arrow_basic_n_small.svg.meta      |    53 +
 .../kenney_ui-pack/Vector/Green/arrow_basic_s.svg  |     8 +
 .../Vector/Green/arrow_basic_s.svg.meta            |    53 +
 .../Vector/Green/arrow_basic_s_small.svg           |     8 +
 .../Vector/Green/arrow_basic_s_small.svg.meta      |    53 +
 .../kenney_ui-pack/Vector/Green/arrow_basic_w.svg  |     8 +
 .../Vector/Green/arrow_basic_w.svg.meta            |    53 +
 .../Vector/Green/arrow_basic_w_small.svg           |     8 +
 .../Vector/Green/arrow_basic_w_small.svg.meta      |    53 +
 .../Vector/Green/arrow_decorative_e.svg            |     8 +
 .../Vector/Green/arrow_decorative_e.svg.meta       |    53 +
 .../Vector/Green/arrow_decorative_e_small.svg      |     8 +
 .../Vector/Green/arrow_decorative_e_small.svg.meta |    53 +
 .../Vector/Green/arrow_decorative_n.svg            |     8 +
 .../Vector/Green/arrow_decorative_n.svg.meta       |    53 +
 .../Vector/Green/arrow_decorative_n_small.svg      |     8 +
 .../Vector/Green/arrow_decorative_n_small.svg.meta |    53 +
 .../Vector/Green/arrow_decorative_s.svg            |     8 +
 .../Vector/Green/arrow_decorative_s.svg.meta       |    53 +
 .../Vector/Green/arrow_decorative_s_small.svg      |     8 +
 .../Vector/Green/arrow_decorative_s_small.svg.meta |    53 +
 .../Vector/Green/arrow_decorative_w.svg            |     8 +
 .../Vector/Green/arrow_decorative_w.svg.meta       |    53 +
 .../Vector/Green/arrow_decorative_w_small.svg      |     8 +
 .../Vector/Green/arrow_decorative_w_small.svg.meta |    53 +
 .../Vector/Green/button_rectangle_border.svg       |    10 +
 .../Vector/Green/button_rectangle_border.svg.meta  |    53 +
 .../Vector/Green/button_rectangle_depth_border.svg |    12 +
 .../Green/button_rectangle_depth_border.svg.meta   |    53 +
 .../Vector/Green/button_rectangle_depth_flat.svg   |     9 +
 .../Green/button_rectangle_depth_flat.svg.meta     |    53 +
 .../Vector/Green/button_rectangle_depth_gloss.svg  |     9 +
 .../Green/button_rectangle_depth_gloss.svg.meta    |    53 +
 .../Green/button_rectangle_depth_gradient.svg      |    14 +
 .../Green/button_rectangle_depth_gradient.svg.meta |    53 +
 .../Vector/Green/button_rectangle_depth_line.svg   |    11 +
 .../Green/button_rectangle_depth_line.svg.meta     |    53 +
 .../Vector/Green/button_rectangle_flat.svg         |     8 +
 .../Vector/Green/button_rectangle_flat.svg.meta    |    53 +
 .../Vector/Green/button_rectangle_gloss.svg        |     8 +
 .../Vector/Green/button_rectangle_gloss.svg.meta   |    53 +
 .../Vector/Green/button_rectangle_gradient.svg     |    13 +
 .../Green/button_rectangle_gradient.svg.meta       |    53 +
 .../Vector/Green/button_rectangle_line.svg         |     9 +
 .../Vector/Green/button_rectangle_line.svg.meta    |    53 +
 .../Vector/Green/button_round_border.svg           |    10 +
 .../Vector/Green/button_round_border.svg.meta      |    53 +
 .../Vector/Green/button_round_depth_border.svg     |    11 +
 .../Green/button_round_depth_border.svg.meta       |    53 +
 .../Vector/Green/button_round_depth_flat.svg       |     9 +
 .../Vector/Green/button_round_depth_flat.svg.meta  |    53 +
 .../Vector/Green/button_round_depth_gloss.svg      |     9 +
 .../Vector/Green/button_round_depth_gloss.svg.meta |    53 +
 .../Vector/Green/button_round_depth_gradient.svg   |    14 +
 .../Green/button_round_depth_gradient.svg.meta     |    53 +
 .../Vector/Green/button_round_depth_line.svg       |    10 +
 .../Vector/Green/button_round_depth_line.svg.meta  |    53 +
 .../Vector/Green/button_round_flat.svg             |     8 +
 .../Vector/Green/button_round_flat.svg.meta        |    53 +
 .../Vector/Green/button_round_gloss.svg            |     8 +
 .../Vector/Green/button_round_gloss.svg.meta       |    53 +
 .../Vector/Green/button_round_gradient.svg         |    13 +
 .../Vector/Green/button_round_gradient.svg.meta    |    53 +
 .../Vector/Green/button_round_line.svg             |     9 +
 .../Vector/Green/button_round_line.svg.meta        |    53 +
 .../Vector/Green/button_square_border.svg          |    10 +
 .../Vector/Green/button_square_border.svg.meta     |    53 +
 .../Vector/Green/button_square_depth_border.svg    |    12 +
 .../Green/button_square_depth_border.svg.meta      |    53 +
 .../Vector/Green/button_square_depth_flat.svg      |    10 +
 .../Vector/Green/button_square_depth_flat.svg.meta |    53 +
 .../Vector/Green/button_square_depth_gloss.svg     |     9 +
 .../Green/button_square_depth_gloss.svg.meta       |    53 +
 .../Vector/Green/button_square_depth_gradient.svg  |    14 +
 .../Green/button_square_depth_gradient.svg.meta    |    53 +
 .../Vector/Green/button_square_depth_line.svg      |    11 +
 .../Vector/Green/button_square_depth_line.svg.meta |    53 +
 .../Vector/Green/button_square_flat.svg            |     8 +
 .../Vector/Green/button_square_flat.svg.meta       |    53 +
 .../Vector/Green/button_square_gloss.svg           |     9 +
 .../Vector/Green/button_square_gloss.svg.meta      |    53 +
 .../Vector/Green/button_square_gradient.svg        |    14 +
 .../Vector/Green/button_square_gradient.svg.meta   |    53 +
 .../Vector/Green/button_square_line.svg            |     9 +
 .../Vector/Green/button_square_line.svg.meta       |    53 +
 .../Vector/Green/check_round_color.svg             |     8 +
 .../Vector/Green/check_round_color.svg.meta        |    53 +
 .../Vector/Green/check_round_grey.svg              |     8 +
 .../Vector/Green/check_round_grey.svg.meta         |    53 +
 .../Vector/Green/check_round_grey_circle.svg       |    10 +
 .../Vector/Green/check_round_grey_circle.svg.meta  |    53 +
 .../Vector/Green/check_round_round_circle.svg      |    10 +
 .../Vector/Green/check_round_round_circle.svg.meta |    53 +
 .../Vector/Green/check_square_color.svg            |     8 +
 .../Vector/Green/check_square_color.svg.meta       |    53 +
 .../Vector/Green/check_square_color_checkmark.svg  |    10 +
 .../Green/check_square_color_checkmark.svg.meta    |    53 +
 .../Vector/Green/check_square_color_cross.svg      |    10 +
 .../Vector/Green/check_square_color_cross.svg.meta |    53 +
 .../Vector/Green/check_square_color_square.svg     |    10 +
 .../Green/check_square_color_square.svg.meta       |    53 +
 .../Vector/Green/check_square_grey.svg             |     8 +
 .../Vector/Green/check_square_grey.svg.meta        |    53 +
 .../Vector/Green/check_square_grey_checkmark.svg   |    10 +
 .../Green/check_square_grey_checkmark.svg.meta     |    53 +
 .../Vector/Green/check_square_grey_cross.svg       |    10 +
 .../Vector/Green/check_square_grey_cross.svg.meta  |    53 +
 .../Vector/Green/check_square_grey_square.svg      |    10 +
 .../Vector/Green/check_square_grey_square.svg.meta |    53 +
 .../kenney_ui-pack/Vector/Green/icon_checkmark.svg |     7 +
 .../Vector/Green/icon_checkmark.svg.meta           |    53 +
 .../kenney_ui-pack/Vector/Green/icon_circle.svg    |     7 +
 .../Vector/Green/icon_circle.svg.meta              |    53 +
 .../kenney_ui-pack/Vector/Green/icon_cross.svg     |     7 +
 .../Vector/Green/icon_cross.svg.meta               |    53 +
 .../Vector/Green/icon_outline_checkmark.svg        |     7 +
 .../Vector/Green/icon_outline_checkmark.svg.meta   |    53 +
 .../Vector/Green/icon_outline_circle.svg           |     7 +
 .../Vector/Green/icon_outline_circle.svg.meta      |    53 +
 .../Vector/Green/icon_outline_cross.svg            |     7 +
 .../Vector/Green/icon_outline_cross.svg.meta       |    53 +
 .../Vector/Green/icon_outline_square.svg           |     7 +
 .../Vector/Green/icon_outline_square.svg.meta      |    53 +
 .../kenney_ui-pack/Vector/Green/icon_square.svg    |     7 +
 .../Vector/Green/icon_square.svg.meta              |    53 +
 .../kenney_ui-pack/Vector/Green/slide_hangle.svg   |     8 +
 .../Vector/Green/slide_hangle.svg.meta             |    53 +
 .../Vector/Green/slide_horizontal_color.svg        |     7 +
 .../Vector/Green/slide_horizontal_color.svg.meta   |    53 +
 .../Green/slide_horizontal_color_section.svg       |     7 +
 .../Green/slide_horizontal_color_section.svg.meta  |    53 +
 .../Green/slide_horizontal_color_section_wide.svg  |     7 +
 .../slide_horizontal_color_section_wide.svg.meta   |    53 +
 .../Vector/Green/slide_horizontal_grey.svg         |     7 +
 .../Vector/Green/slide_horizontal_grey.svg.meta    |    53 +
 .../Vector/Green/slide_horizontal_grey_section.svg |     7 +
 .../Green/slide_horizontal_grey_section.svg.meta   |    53 +
 .../Green/slide_horizontal_grey_section_wide.svg   |     7 +
 .../slide_horizontal_grey_section_wide.svg.meta    |    53 +
 .../Vector/Green/slide_vertical_color.svg          |     7 +
 .../Vector/Green/slide_vertical_color.svg.meta     |    53 +
 .../Vector/Green/slide_vertical_color_section.svg  |     7 +
 .../Green/slide_vertical_color_section.svg.meta    |    53 +
 .../Green/slide_vertical_color_section_wide.svg    |     7 +
 .../slide_vertical_color_section_wide.svg.meta     |    53 +
 .../Vector/Green/slide_vertical_grey.svg           |     7 +
 .../Vector/Green/slide_vertical_grey.svg.meta      |    53 +
 .../Vector/Green/slide_vertical_grey_section.svg   |     7 +
 .../Green/slide_vertical_grey_section.svg.meta     |    53 +
 .../Green/slide_vertical_grey_section_wide.svg     |     7 +
 .../slide_vertical_grey_section_wide.svg.meta      |    53 +
 .../NewUI/kenney_ui-pack/Vector/Green/star.svg     |    18 +
 .../kenney_ui-pack/Vector/Green/star.svg.meta      |    53 +
 .../kenney_ui-pack/Vector/Green/star_outline.svg   |     7 +
 .../Vector/Green/star_outline.svg.meta             |    53 +
 .../Vector/Green/star_outline_depth.svg            |    12 +
 .../Vector/Green/star_outline_depth.svg.meta       |    53 +
 .../textures/NewUI/kenney_ui-pack/Vector/Grey.meta |     8 +
 .../kenney_ui-pack/Vector/Grey/arrow_basic_e.svg   |     8 +
 .../Vector/Grey/arrow_basic_e.svg.meta             |    53 +
 .../Vector/Grey/arrow_basic_e_small.svg            |     8 +
 .../Vector/Grey/arrow_basic_e_small.svg.meta       |    53 +
 .../kenney_ui-pack/Vector/Grey/arrow_basic_n.svg   |     8 +
 .../Vector/Grey/arrow_basic_n.svg.meta             |    53 +
 .../Vector/Grey/arrow_basic_n_small.svg            |     8 +
 .../Vector/Grey/arrow_basic_n_small.svg.meta       |    53 +
 .../kenney_ui-pack/Vector/Grey/arrow_basic_s.svg   |     8 +
 .../Vector/Grey/arrow_basic_s.svg.meta             |    53 +
 .../Vector/Grey/arrow_basic_s_small.svg            |     8 +
 .../Vector/Grey/arrow_basic_s_small.svg.meta       |    53 +
 .../kenney_ui-pack/Vector/Grey/arrow_basic_w.svg   |     8 +
 .../Vector/Grey/arrow_basic_w.svg.meta             |    53 +
 .../Vector/Grey/arrow_basic_w_small.svg            |     8 +
 .../Vector/Grey/arrow_basic_w_small.svg.meta       |    53 +
 .../Vector/Grey/arrow_decorative_e.svg             |     8 +
 .../Vector/Grey/arrow_decorative_e.svg.meta        |    53 +
 .../Vector/Grey/arrow_decorative_e_small.svg       |     8 +
 .../Vector/Grey/arrow_decorative_e_small.svg.meta  |    53 +
 .../Vector/Grey/arrow_decorative_n.svg             |     8 +
 .../Vector/Grey/arrow_decorative_n.svg.meta        |    53 +
 .../Vector/Grey/arrow_decorative_n_small.svg       |     8 +
 .../Vector/Grey/arrow_decorative_n_small.svg.meta  |    53 +
 .../Vector/Grey/arrow_decorative_s.svg             |     8 +
 .../Vector/Grey/arrow_decorative_s.svg.meta        |    53 +
 .../Vector/Grey/arrow_decorative_s_small.svg       |     8 +
 .../Vector/Grey/arrow_decorative_s_small.svg.meta  |    53 +
 .../Vector/Grey/arrow_decorative_w.svg             |     8 +
 .../Vector/Grey/arrow_decorative_w.svg.meta        |    53 +
 .../Vector/Grey/arrow_decorative_w_small.svg       |     8 +
 .../Vector/Grey/arrow_decorative_w_small.svg.meta  |    53 +
 .../Vector/Grey/button_rectangle_border.svg        |     8 +
 .../Vector/Grey/button_rectangle_border.svg.meta   |    53 +
 .../Vector/Grey/button_rectangle_depth_border.svg  |    10 +
 .../Grey/button_rectangle_depth_border.svg.meta    |    53 +
 .../Vector/Grey/button_rectangle_depth_flat.svg    |     9 +
 .../Grey/button_rectangle_depth_flat.svg.meta      |    53 +
 .../Vector/Grey/button_rectangle_depth_gloss.svg   |     9 +
 .../Grey/button_rectangle_depth_gloss.svg.meta     |    53 +
 .../Grey/button_rectangle_depth_gradient.svg       |    14 +
 .../Grey/button_rectangle_depth_gradient.svg.meta  |    53 +
 .../Vector/Grey/button_rectangle_depth_line.svg    |    10 +
 .../Grey/button_rectangle_depth_line.svg.meta      |    53 +
 .../Vector/Grey/button_rectangle_flat.svg          |     8 +
 .../Vector/Grey/button_rectangle_flat.svg.meta     |    53 +
 .../Vector/Grey/button_rectangle_gloss.svg         |     8 +
 .../Vector/Grey/button_rectangle_gloss.svg.meta    |    53 +
 .../Vector/Grey/button_rectangle_gradient.svg      |    13 +
 .../Vector/Grey/button_rectangle_gradient.svg.meta |    53 +
 .../Vector/Grey/button_rectangle_line.svg          |     8 +
 .../Vector/Grey/button_rectangle_line.svg.meta     |    53 +
 .../Vector/Grey/button_round_border.svg            |     8 +
 .../Vector/Grey/button_round_border.svg.meta       |    53 +
 .../Vector/Grey/button_round_depth_border.svg      |     9 +
 .../Vector/Grey/button_round_depth_border.svg.meta |    53 +
 .../Vector/Grey/button_round_depth_flat.svg        |     9 +
 .../Vector/Grey/button_round_depth_flat.svg.meta   |    53 +
 .../Vector/Grey/button_round_depth_gloss.svg       |     9 +
 .../Vector/Grey/button_round_depth_gloss.svg.meta  |    53 +
 .../Vector/Grey/button_round_depth_gradient.svg    |    14 +
 .../Grey/button_round_depth_gradient.svg.meta      |    53 +
 .../Vector/Grey/button_round_depth_line.svg        |     9 +
 .../Vector/Grey/button_round_depth_line.svg.meta   |    53 +
 .../Vector/Grey/button_round_flat.svg              |     8 +
 .../Vector/Grey/button_round_flat.svg.meta         |    53 +
 .../Vector/Grey/button_round_gloss.svg             |     8 +
 .../Vector/Grey/button_round_gloss.svg.meta        |    53 +
 .../Vector/Grey/button_round_gradient.svg          |    13 +
 .../Vector/Grey/button_round_gradient.svg.meta     |    53 +
 .../Vector/Grey/button_round_line.svg              |     8 +
 .../Vector/Grey/button_round_line.svg.meta         |    53 +
 .../Vector/Grey/button_square_border.svg           |     8 +
 .../Vector/Grey/button_square_border.svg.meta      |    53 +
 .../Vector/Grey/button_square_depth_border.svg     |    10 +
 .../Grey/button_square_depth_border.svg.meta       |    53 +
 .../Vector/Grey/button_square_depth_flat.svg       |    10 +
 .../Vector/Grey/button_square_depth_flat.svg.meta  |    53 +
 .../Vector/Grey/button_square_depth_gloss.svg      |     9 +
 .../Vector/Grey/button_square_depth_gloss.svg.meta |    53 +
 .../Vector/Grey/button_square_depth_gradient.svg   |    14 +
 .../Grey/button_square_depth_gradient.svg.meta     |    53 +
 .../Vector/Grey/button_square_depth_line.svg       |    10 +
 .../Vector/Grey/button_square_depth_line.svg.meta  |    53 +
 .../Vector/Grey/button_square_flat.svg             |     8 +
 .../Vector/Grey/button_square_flat.svg.meta        |    53 +
 .../Vector/Grey/button_square_gloss.svg            |     9 +
 .../Vector/Grey/button_square_gloss.svg.meta       |    53 +
 .../Vector/Grey/button_square_gradient.svg         |    14 +
 .../Vector/Grey/button_square_gradient.svg.meta    |    53 +
 .../Vector/Grey/button_square_line.svg             |     8 +
 .../Vector/Grey/button_square_line.svg.meta        |    53 +
 .../Vector/Grey/check_round_color.svg              |     8 +
 .../Vector/Grey/check_round_color.svg.meta         |    53 +
 .../Vector/Grey/check_round_grey.svg               |     8 +
 .../Vector/Grey/check_round_grey.svg.meta          |    53 +
 .../Vector/Grey/check_round_grey_circle.svg        |    10 +
 .../Vector/Grey/check_round_grey_circle.svg.meta   |    53 +
 .../Vector/Grey/check_round_round_circle.svg       |    10 +
 .../Vector/Grey/check_round_round_circle.svg.meta  |    53 +
 .../Vector/Grey/check_square_color.svg             |     8 +
 .../Vector/Grey/check_square_color.svg.meta        |    53 +
 .../Vector/Grey/check_square_color_checkmark.svg   |    10 +
 .../Grey/check_square_color_checkmark.svg.meta     |    53 +
 .../Vector/Grey/check_square_color_cross.svg       |    10 +
 .../Vector/Grey/check_square_color_cross.svg.meta  |    53 +
 .../Vector/Grey/check_square_color_square.svg      |    10 +
 .../Vector/Grey/check_square_color_square.svg.meta |    53 +
 .../Vector/Grey/check_square_grey.svg              |     8 +
 .../Vector/Grey/check_square_grey.svg.meta         |    53 +
 .../Vector/Grey/check_square_grey_checkmark.svg    |    10 +
 .../Grey/check_square_grey_checkmark.svg.meta      |    53 +
 .../Vector/Grey/check_square_grey_cross.svg        |    10 +
 .../Vector/Grey/check_square_grey_cross.svg.meta   |    53 +
 .../Vector/Grey/check_square_grey_square.svg       |    10 +
 .../Vector/Grey/check_square_grey_square.svg.meta  |    53 +
 .../kenney_ui-pack/Vector/Grey/icon_checkmark.svg  |     7 +
 .../Vector/Grey/icon_checkmark.svg.meta            |    53 +
 .../kenney_ui-pack/Vector/Grey/icon_circle.svg     |     7 +
 .../Vector/Grey/icon_circle.svg.meta               |    53 +
 .../kenney_ui-pack/Vector/Grey/icon_cross.svg      |     7 +
 .../kenney_ui-pack/Vector/Grey/icon_cross.svg.meta |    53 +
 .../Vector/Grey/icon_outline_checkmark.svg         |     7 +
 .../Vector/Grey/icon_outline_checkmark.svg.meta    |    53 +
 .../Vector/Grey/icon_outline_circle.svg            |     7 +
 .../Vector/Grey/icon_outline_circle.svg.meta       |    53 +
 .../Vector/Grey/icon_outline_cross.svg             |     7 +
 .../Vector/Grey/icon_outline_cross.svg.meta        |    53 +
 .../Vector/Grey/icon_outline_square.svg            |     7 +
 .../Vector/Grey/icon_outline_square.svg.meta       |    53 +
 .../kenney_ui-pack/Vector/Grey/icon_square.svg     |     7 +
 .../Vector/Grey/icon_square.svg.meta               |    53 +
 .../kenney_ui-pack/Vector/Grey/slide_hangle.svg    |     8 +
 .../Vector/Grey/slide_hangle.svg.meta              |    53 +
 .../Vector/Grey/slide_horizontal_color.svg         |     7 +
 .../Vector/Grey/slide_horizontal_color.svg.meta    |    53 +
 .../Vector/Grey/slide_horizontal_color_section.svg |     7 +
 .../Grey/slide_horizontal_color_section.svg.meta   |    53 +
 .../Grey/slide_horizontal_color_section_wide.svg   |     7 +
 .../slide_horizontal_color_section_wide.svg.meta   |    53 +
 .../Vector/Grey/slide_horizontal_grey.svg          |     7 +
 .../Vector/Grey/slide_horizontal_grey.svg.meta     |    53 +
 .../Vector/Grey/slide_horizontal_grey_section.svg  |     7 +
 .../Grey/slide_horizontal_grey_section.svg.meta    |    53 +
 .../Grey/slide_horizontal_grey_section_wide.svg    |     7 +
 .../slide_horizontal_grey_section_wide.svg.meta    |    53 +
 .../Vector/Grey/slide_vertical_color.svg           |     7 +
 .../Vector/Grey/slide_vertical_color.svg.meta      |    53 +
 .../Vector/Grey/slide_vertical_color_section.svg   |     7 +
 .../Grey/slide_vertical_color_section.svg.meta     |    53 +
 .../Grey/slide_vertical_color_section_wide.svg     |     7 +
 .../slide_vertical_color_section_wide.svg.meta     |    53 +
 .../Vector/Grey/slide_vertical_grey.svg            |     7 +
 .../Vector/Grey/slide_vertical_grey.svg.meta       |    53 +
 .../Vector/Grey/slide_vertical_grey_section.svg    |     7 +
 .../Grey/slide_vertical_grey_section.svg.meta      |    53 +
 .../Grey/slide_vertical_grey_section_wide.svg      |     7 +
 .../Grey/slide_vertical_grey_section_wide.svg.meta |    53 +
 .../NewUI/kenney_ui-pack/Vector/Grey/star.svg      |    18 +
 .../NewUI/kenney_ui-pack/Vector/Grey/star.svg.meta |    53 +
 .../kenney_ui-pack/Vector/Grey/star_outline.svg    |     7 +
 .../Vector/Grey/star_outline.svg.meta              |    53 +
 .../Vector/Grey/star_outline_depth.svg             |    12 +
 .../Vector/Grey/star_outline_depth.svg.meta        |    53 +
 .../textures/NewUI/kenney_ui-pack/Vector/Red.meta  |     8 +
 .../kenney_ui-pack/Vector/Red/arrow_basic_e.svg    |     8 +
 .../Vector/Red/arrow_basic_e.svg.meta              |    53 +
 .../Vector/Red/arrow_basic_e_small.svg             |     8 +
 .../Vector/Red/arrow_basic_e_small.svg.meta        |    53 +
 .../kenney_ui-pack/Vector/Red/arrow_basic_n.svg    |     8 +
 .../Vector/Red/arrow_basic_n.svg.meta              |    53 +
 .../Vector/Red/arrow_basic_n_small.svg             |     8 +
 .../Vector/Red/arrow_basic_n_small.svg.meta        |    53 +
 .../kenney_ui-pack/Vector/Red/arrow_basic_s.svg    |     8 +
 .../Vector/Red/arrow_basic_s.svg.meta              |    53 +
 .../Vector/Red/arrow_basic_s_small.svg             |     8 +
 .../Vector/Red/arrow_basic_s_small.svg.meta        |    53 +
 .../kenney_ui-pack/Vector/Red/arrow_basic_w.svg    |     8 +
 .../Vector/Red/arrow_basic_w.svg.meta              |    53 +
 .../Vector/Red/arrow_basic_w_small.svg             |     8 +
 .../Vector/Red/arrow_basic_w_small.svg.meta        |    53 +
 .../Vector/Red/arrow_decorative_e.svg              |     8 +
 .../Vector/Red/arrow_decorative_e.svg.meta         |    53 +
 .../Vector/Red/arrow_decorative_e_small.svg        |     8 +
 .../Vector/Red/arrow_decorative_e_small.svg.meta   |    53 +
 .../Vector/Red/arrow_decorative_n.svg              |     8 +
 .../Vector/Red/arrow_decorative_n.svg.meta         |    53 +
 .../Vector/Red/arrow_decorative_n_small.svg        |     8 +
 .../Vector/Red/arrow_decorative_n_small.svg.meta   |    53 +
 .../Vector/Red/arrow_decorative_s.svg              |     8 +
 .../Vector/Red/arrow_decorative_s.svg.meta         |    53 +
 .../Vector/Red/arrow_decorative_s_small.svg        |     8 +
 .../Vector/Red/arrow_decorative_s_small.svg.meta   |    53 +
 .../Vector/Red/arrow_decorative_w.svg              |     8 +
 .../Vector/Red/arrow_decorative_w.svg.meta         |    53 +
 .../Vector/Red/arrow_decorative_w_small.svg        |     8 +
 .../Vector/Red/arrow_decorative_w_small.svg.meta   |    53 +
 .../Vector/Red/button_rectangle_border.svg         |    10 +
 .../Vector/Red/button_rectangle_border.svg.meta    |    53 +
 .../Vector/Red/button_rectangle_depth_border.svg   |    12 +
 .../Red/button_rectangle_depth_border.svg.meta     |    53 +
 .../Vector/Red/button_rectangle_depth_flat.svg     |     9 +
 .../Red/button_rectangle_depth_flat.svg.meta       |    53 +
 .../Vector/Red/button_rectangle_depth_gloss.svg    |     9 +
 .../Red/button_rectangle_depth_gloss.svg.meta      |    53 +
 .../Vector/Red/button_rectangle_depth_gradient.svg |    14 +
 .../Red/button_rectangle_depth_gradient.svg.meta   |    53 +
 .../Vector/Red/button_rectangle_depth_line.svg     |    11 +
 .../Red/button_rectangle_depth_line.svg.meta       |    53 +
 .../Vector/Red/button_rectangle_flat.svg           |     8 +
 .../Vector/Red/button_rectangle_flat.svg.meta      |    53 +
 .../Vector/Red/button_rectangle_gloss.svg          |     8 +
 .../Vector/Red/button_rectangle_gloss.svg.meta     |    53 +
 .../Vector/Red/button_rectangle_gradient.svg       |    13 +
 .../Vector/Red/button_rectangle_gradient.svg.meta  |    53 +
 .../Vector/Red/button_rectangle_line.svg           |     9 +
 .../Vector/Red/button_rectangle_line.svg.meta      |    53 +
 .../Vector/Red/button_round_border.svg             |    10 +
 .../Vector/Red/button_round_border.svg.meta        |    53 +
 .../Vector/Red/button_round_depth_border.svg       |    11 +
 .../Vector/Red/button_round_depth_border.svg.meta  |    53 +
 .../Vector/Red/button_round_depth_flat.svg         |     9 +
 .../Vector/Red/button_round_depth_flat.svg.meta    |    53 +
 .../Vector/Red/button_round_depth_gloss.svg        |     9 +
 .../Vector/Red/button_round_depth_gloss.svg.meta   |    53 +
 .../Vector/Red/button_round_depth_gradient.svg     |    14 +
 .../Red/button_round_depth_gradient.svg.meta       |    53 +
 .../Vector/Red/button_round_depth_line.svg         |    10 +
 .../Vector/Red/button_round_depth_line.svg.meta    |    53 +
 .../Vector/Red/button_round_flat.svg               |     8 +
 .../Vector/Red/button_round_flat.svg.meta          |    53 +
 .../Vector/Red/button_round_gloss.svg              |     8 +
 .../Vector/Red/button_round_gloss.svg.meta         |    53 +
 .../Vector/Red/button_round_gradient.svg           |    13 +
 .../Vector/Red/button_round_gradient.svg.meta      |    53 +
 .../Vector/Red/button_round_line.svg               |     9 +
 .../Vector/Red/button_round_line.svg.meta          |    53 +
 .../Vector/Red/button_square_border.svg            |    10 +
 .../Vector/Red/button_square_border.svg.meta       |    53 +
 .../Vector/Red/button_square_depth_border.svg      |    12 +
 .../Vector/Red/button_square_depth_border.svg.meta |    53 +
 .../Vector/Red/button_square_depth_flat.svg        |    10 +
 .../Vector/Red/button_square_depth_flat.svg.meta   |    53 +
 .../Vector/Red/button_square_depth_gloss.svg       |     9 +
 .../Vector/Red/button_square_depth_gloss.svg.meta  |    53 +
 .../Vector/Red/button_square_depth_gradient.svg    |    14 +
 .../Red/button_square_depth_gradient.svg.meta      |    53 +
 .../Vector/Red/button_square_depth_line.svg        |    11 +
 .../Vector/Red/button_square_depth_line.svg.meta   |    53 +
 .../Vector/Red/button_square_flat.svg              |     8 +
 .../Vector/Red/button_square_flat.svg.meta         |    53 +
 .../Vector/Red/button_square_gloss.svg             |     9 +
 .../Vector/Red/button_square_gloss.svg.meta        |    53 +
 .../Vector/Red/button_square_gradient.svg          |    14 +
 .../Vector/Red/button_square_gradient.svg.meta     |    53 +
 .../Vector/Red/button_square_line.svg              |     9 +
 .../Vector/Red/button_square_line.svg.meta         |    53 +
 .../Vector/Red/check_round_color.svg               |     8 +
 .../Vector/Red/check_round_color.svg.meta          |    53 +
 .../kenney_ui-pack/Vector/Red/check_round_grey.svg |     8 +
 .../Vector/Red/check_round_grey.svg.meta           |    53 +
 .../Vector/Red/check_round_grey_circle.svg         |    10 +
 .../Vector/Red/check_round_grey_circle.svg.meta    |    53 +
 .../Vector/Red/check_round_round_circle.svg        |    10 +
 .../Vector/Red/check_round_round_circle.svg.meta   |    53 +
 .../Vector/Red/check_square_color.svg              |     8 +
 .../Vector/Red/check_square_color.svg.meta         |    53 +
 .../Vector/Red/check_square_color_checkmark.svg    |    10 +
 .../Red/check_square_color_checkmark.svg.meta      |    53 +
 .../Vector/Red/check_square_color_cross.svg        |    10 +
 .../Vector/Red/check_square_color_cross.svg.meta   |    53 +
 .../Vector/Red/check_square_color_square.svg       |    10 +
 .../Vector/Red/check_square_color_square.svg.meta  |    53 +
 .../Vector/Red/check_square_grey.svg               |     8 +
 .../Vector/Red/check_square_grey.svg.meta          |    53 +
 .../Vector/Red/check_square_grey_checkmark.svg     |    10 +
 .../Red/check_square_grey_checkmark.svg.meta       |    53 +
 .../Vector/Red/check_square_grey_cross.svg         |    10 +
 .../Vector/Red/check_square_grey_cross.svg.meta    |    53 +
 .../Vector/Red/check_square_grey_square.svg        |    10 +
 .../Vector/Red/check_square_grey_square.svg.meta   |    53 +
 .../kenney_ui-pack/Vector/Red/icon_checkmark.svg   |     7 +
 .../Vector/Red/icon_checkmark.svg.meta             |    53 +
 .../kenney_ui-pack/Vector/Red/icon_circle.svg      |     7 +
 .../kenney_ui-pack/Vector/Red/icon_circle.svg.meta |    53 +
 .../NewUI/kenney_ui-pack/Vector/Red/icon_cross.svg |     7 +
 .../kenney_ui-pack/Vector/Red/icon_cross.svg.meta  |    53 +
 .../Vector/Red/icon_outline_checkmark.svg          |     7 +
 .../Vector/Red/icon_outline_checkmark.svg.meta     |    53 +
 .../Vector/Red/icon_outline_circle.svg             |     7 +
 .../Vector/Red/icon_outline_circle.svg.meta        |    53 +
 .../Vector/Red/icon_outline_cross.svg              |     7 +
 .../Vector/Red/icon_outline_cross.svg.meta         |    53 +
 .../Vector/Red/icon_outline_square.svg             |     7 +
 .../Vector/Red/icon_outline_square.svg.meta        |    53 +
 .../kenney_ui-pack/Vector/Red/icon_square.svg      |     7 +
 .../kenney_ui-pack/Vector/Red/icon_square.svg.meta |    53 +
 .../kenney_ui-pack/Vector/Red/slide_hangle.svg     |     8 +
 .../Vector/Red/slide_hangle.svg.meta               |    53 +
 .../Vector/Red/slide_horizontal_color.svg          |     7 +
 .../Vector/Red/slide_horizontal_color.svg.meta     |    53 +
 .../Vector/Red/slide_horizontal_color_section.svg  |     7 +
 .../Red/slide_horizontal_color_section.svg.meta    |    53 +
 .../Red/slide_horizontal_color_section_wide.svg    |     7 +
 .../slide_horizontal_color_section_wide.svg.meta   |    53 +
 .../Vector/Red/slide_horizontal_grey.svg           |     7 +
 .../Vector/Red/slide_horizontal_grey.svg.meta      |    53 +
 .../Vector/Red/slide_horizontal_grey_section.svg   |     7 +
 .../Red/slide_horizontal_grey_section.svg.meta     |    53 +
 .../Red/slide_horizontal_grey_section_wide.svg     |     7 +
 .../slide_horizontal_grey_section_wide.svg.meta    |    53 +
 .../Vector/Red/slide_vertical_color.svg            |     7 +
 .../Vector/Red/slide_vertical_color.svg.meta       |    53 +
 .../Vector/Red/slide_vertical_color_section.svg    |     7 +
 .../Red/slide_vertical_color_section.svg.meta      |    53 +
 .../Red/slide_vertical_color_section_wide.svg      |     7 +
 .../Red/slide_vertical_color_section_wide.svg.meta |    53 +
 .../Vector/Red/slide_vertical_grey.svg             |     7 +
 .../Vector/Red/slide_vertical_grey.svg.meta        |    53 +
 .../Vector/Red/slide_vertical_grey_section.svg     |     7 +
 .../Red/slide_vertical_grey_section.svg.meta       |    53 +
 .../Red/slide_vertical_grey_section_wide.svg       |     7 +
 .../Red/slide_vertical_grey_section_wide.svg.meta  |    53 +
 .../NewUI/kenney_ui-pack/Vector/Red/star.svg       |    18 +
 .../NewUI/kenney_ui-pack/Vector/Red/star.svg.meta  |    53 +
 .../kenney_ui-pack/Vector/Red/star_outline.svg     |     7 +
 .../Vector/Red/star_outline.svg.meta               |    53 +
 .../Vector/Red/star_outline_depth.svg              |    12 +
 .../Vector/Red/star_outline_depth.svg.meta         |    53 +
 .../NewUI/kenney_ui-pack/Vector/Yellow.meta        |     8 +
 .../kenney_ui-pack/Vector/Yellow/arrow_basic_e.svg |     8 +
 .../Vector/Yellow/arrow_basic_e.svg.meta           |    53 +
 .../Vector/Yellow/arrow_basic_e_small.svg          |     8 +
 .../Vector/Yellow/arrow_basic_e_small.svg.meta     |    53 +
 .../kenney_ui-pack/Vector/Yellow/arrow_basic_n.svg |     8 +
 .../Vector/Yellow/arrow_basic_n.svg.meta           |    53 +
 .../Vector/Yellow/arrow_basic_n_small.svg          |     8 +
 .../Vector/Yellow/arrow_basic_n_small.svg.meta     |    53 +
 .../kenney_ui-pack/Vector/Yellow/arrow_basic_s.svg |     8 +
 .../Vector/Yellow/arrow_basic_s.svg.meta           |    53 +
 .../Vector/Yellow/arrow_basic_s_small.svg          |     8 +
 .../Vector/Yellow/arrow_basic_s_small.svg.meta     |    53 +
 .../kenney_ui-pack/Vector/Yellow/arrow_basic_w.svg |     8 +
 .../Vector/Yellow/arrow_basic_w.svg.meta           |    53 +
 .../Vector/Yellow/arrow_basic_w_small.svg          |     8 +
 .../Vector/Yellow/arrow_basic_w_small.svg.meta     |    53 +
 .../Vector/Yellow/arrow_decorative_e.svg           |     8 +
 .../Vector/Yellow/arrow_decorative_e.svg.meta      |    53 +
 .../Vector/Yellow/arrow_decorative_e_small.svg     |     8 +
 .../Yellow/arrow_decorative_e_small.svg.meta       |    53 +
 .../Vector/Yellow/arrow_decorative_n.svg           |     8 +
 .../Vector/Yellow/arrow_decorative_n.svg.meta      |    53 +
 .../Vector/Yellow/arrow_decorative_n_small.svg     |     8 +
 .../Yellow/arrow_decorative_n_small.svg.meta       |    53 +
 .../Vector/Yellow/arrow_decorative_s.svg           |     8 +
 .../Vector/Yellow/arrow_decorative_s.svg.meta      |    53 +
 .../Vector/Yellow/arrow_decorative_s_small.svg     |     8 +
 .../Yellow/arrow_decorative_s_small.svg.meta       |    53 +
 .../Vector/Yellow/arrow_decorative_w.svg           |     8 +
 .../Vector/Yellow/arrow_decorative_w.svg.meta      |    53 +
 .../Vector/Yellow/arrow_decorative_w_small.svg     |     8 +
 .../Yellow/arrow_decorative_w_small.svg.meta       |    53 +
 .../Vector/Yellow/button_rectangle_border.svg      |    10 +
 .../Vector/Yellow/button_rectangle_border.svg.meta |    53 +
 .../Yellow/button_rectangle_depth_border.svg       |    12 +
 .../Yellow/button_rectangle_depth_border.svg.meta  |    53 +
 .../Vector/Yellow/button_rectangle_depth_flat.svg  |     9 +
 .../Yellow/button_rectangle_depth_flat.svg.meta    |    53 +
 .../Vector/Yellow/button_rectangle_depth_gloss.svg |     9 +
 .../Yellow/button_rectangle_depth_gloss.svg.meta   |    53 +
 .../Yellow/button_rectangle_depth_gradient.svg     |    14 +
 .../button_rectangle_depth_gradient.svg.meta       |    53 +
 .../Vector/Yellow/button_rectangle_depth_line.svg  |    11 +
 .../Yellow/button_rectangle_depth_line.svg.meta    |    53 +
 .../Vector/Yellow/button_rectangle_flat.svg        |     8 +
 .../Vector/Yellow/button_rectangle_flat.svg.meta   |    53 +
 .../Vector/Yellow/button_rectangle_gloss.svg       |     8 +
 .../Vector/Yellow/button_rectangle_gloss.svg.meta  |    53 +
 .../Vector/Yellow/button_rectangle_gradient.svg    |    13 +
 .../Yellow/button_rectangle_gradient.svg.meta      |    53 +
 .../Vector/Yellow/button_rectangle_line.svg        |     9 +
 .../Vector/Yellow/button_rectangle_line.svg.meta   |    53 +
 .../Vector/Yellow/button_round_border.svg          |    10 +
 .../Vector/Yellow/button_round_border.svg.meta     |    53 +
 .../Vector/Yellow/button_round_depth_border.svg    |    11 +
 .../Yellow/button_round_depth_border.svg.meta      |    53 +
 .../Vector/Yellow/button_round_depth_flat.svg      |     9 +
 .../Vector/Yellow/button_round_depth_flat.svg.meta |    53 +
 .../Vector/Yellow/button_round_depth_gloss.svg     |     9 +
 .../Yellow/button_round_depth_gloss.svg.meta       |    53 +
 .../Vector/Yellow/button_round_depth_gradient.svg  |    14 +
 .../Yellow/button_round_depth_gradient.svg.meta    |    53 +
 .../Vector/Yellow/button_round_depth_line.svg      |    10 +
 .../Vector/Yellow/button_round_depth_line.svg.meta |    53 +
 .../Vector/Yellow/button_round_flat.svg            |     8 +
 .../Vector/Yellow/button_round_flat.svg.meta       |    53 +
 .../Vector/Yellow/button_round_gloss.svg           |     8 +
 .../Vector/Yellow/button_round_gloss.svg.meta      |    53 +
 .../Vector/Yellow/button_round_gradient.svg        |    13 +
 .../Vector/Yellow/button_round_gradient.svg.meta   |    53 +
 .../Vector/Yellow/button_round_line.svg            |    10 +
 .../Vector/Yellow/button_round_line.svg.meta       |    53 +
 .../Vector/Yellow/button_square_border.svg         |    10 +
 .../Vector/Yellow/button_square_border.svg.meta    |    53 +
 .../Vector/Yellow/button_square_depth_border.svg   |    12 +
 .../Yellow/button_square_depth_border.svg.meta     |    53 +
 .../Vector/Yellow/button_square_depth_flat.svg     |    10 +
 .../Yellow/button_square_depth_flat.svg.meta       |    53 +
 .../Vector/Yellow/button_square_depth_gloss.svg    |     9 +
 .../Yellow/button_square_depth_gloss.svg.meta      |    53 +
 .../Vector/Yellow/button_square_depth_gradient.svg |    14 +
 .../Yellow/button_square_depth_gradient.svg.meta   |    53 +
 .../Vector/Yellow/button_square_depth_line.svg     |    11 +
 .../Yellow/button_square_depth_line.svg.meta       |    53 +
 .../Vector/Yellow/button_square_flat.svg           |     8 +
 .../Vector/Yellow/button_square_flat.svg.meta      |    53 +
 .../Vector/Yellow/button_square_gloss.svg          |     9 +
 .../Vector/Yellow/button_square_gloss.svg.meta     |    53 +
 .../Vector/Yellow/button_square_gradient.svg       |    14 +
 .../Vector/Yellow/button_square_gradient.svg.meta  |    53 +
 .../Vector/Yellow/button_square_line.svg           |     9 +
 .../Vector/Yellow/button_square_line.svg.meta      |    53 +
 .../Vector/Yellow/check_round_color.svg            |     8 +
 .../Vector/Yellow/check_round_color.svg.meta       |    53 +
 .../Vector/Yellow/check_round_grey.svg             |     8 +
 .../Vector/Yellow/check_round_grey.svg.meta        |    53 +
 .../Vector/Yellow/check_round_grey_circle.svg      |    10 +
 .../Vector/Yellow/check_round_grey_circle.svg.meta |    53 +
 .../Vector/Yellow/check_round_round_circle.svg     |    10 +
 .../Yellow/check_round_round_circle.svg.meta       |    53 +
 .../Vector/Yellow/check_square_color.svg           |     8 +
 .../Vector/Yellow/check_square_color.svg.meta      |    53 +
 .../Vector/Yellow/check_square_color_checkmark.svg |    10 +
 .../Yellow/check_square_color_checkmark.svg.meta   |    53 +
 .../Vector/Yellow/check_square_color_cross.svg     |    10 +
 .../Yellow/check_square_color_cross.svg.meta       |    53 +
 .../Vector/Yellow/check_square_color_square.svg    |    10 +
 .../Yellow/check_square_color_square.svg.meta      |    53 +
 .../Vector/Yellow/check_square_grey.svg            |     8 +
 .../Vector/Yellow/check_square_grey.svg.meta       |    53 +
 .../Vector/Yellow/check_square_grey_checkmark.svg  |    10 +
 .../Yellow/check_square_grey_checkmark.svg.meta    |    53 +
 .../Vector/Yellow/check_square_grey_cross.svg      |    10 +
 .../Vector/Yellow/check_square_grey_cross.svg.meta |    53 +
 .../Vector/Yellow/check_square_grey_square.svg     |    10 +
 .../Yellow/check_square_grey_square.svg.meta       |    53 +
 .../Vector/Yellow/icon_checkmark.svg               |     7 +
 .../Vector/Yellow/icon_checkmark.svg.meta          |    53 +
 .../kenney_ui-pack/Vector/Yellow/icon_circle.svg   |     7 +
 .../Vector/Yellow/icon_circle.svg.meta             |    53 +
 .../kenney_ui-pack/Vector/Yellow/icon_cross.svg    |     7 +
 .../Vector/Yellow/icon_cross.svg.meta              |    53 +
 .../Vector/Yellow/icon_outline_checkmark.svg       |     7 +
 .../Vector/Yellow/icon_outline_checkmark.svg.meta  |    53 +
 .../Vector/Yellow/icon_outline_circle.svg          |     7 +
 .../Vector/Yellow/icon_outline_circle.svg.meta     |    53 +
 .../Vector/Yellow/icon_outline_cross.svg           |     7 +
 .../Vector/Yellow/icon_outline_cross.svg.meta      |    53 +
 .../Vector/Yellow/icon_outline_square.svg          |     7 +
 .../Vector/Yellow/icon_outline_square.svg.meta     |    53 +
 .../kenney_ui-pack/Vector/Yellow/icon_square.svg   |     7 +
 .../Vector/Yellow/icon_square.svg.meta             |    53 +
 .../kenney_ui-pack/Vector/Yellow/slide_hangle.svg  |     8 +
 .../Vector/Yellow/slide_hangle.svg.meta            |    53 +
 .../Vector/Yellow/slide_horizontal_color.svg       |     7 +
 .../Vector/Yellow/slide_horizontal_color.svg.meta  |    53 +
 .../Yellow/slide_horizontal_color_section.svg      |     7 +
 .../Yellow/slide_horizontal_color_section.svg.meta |    53 +
 .../Yellow/slide_horizontal_color_section_wide.svg |     7 +
 .../slide_horizontal_color_section_wide.svg.meta   |    53 +
 .../Vector/Yellow/slide_horizontal_grey.svg        |     7 +
 .../Vector/Yellow/slide_horizontal_grey.svg.meta   |    53 +
 .../Yellow/slide_horizontal_grey_section.svg       |     7 +
 .../Yellow/slide_horizontal_grey_section.svg.meta  |    53 +
 .../Yellow/slide_horizontal_grey_section_wide.svg  |     7 +
 .../slide_horizontal_grey_section_wide.svg.meta    |    53 +
 .../Vector/Yellow/slide_vertical_color.svg         |     7 +
 .../Vector/Yellow/slide_vertical_color.svg.meta    |    53 +
 .../Vector/Yellow/slide_vertical_color_section.svg |     7 +
 .../Yellow/slide_vertical_color_section.svg.meta   |    53 +
 .../Yellow/slide_vertical_color_section_wide.svg   |     7 +
 .../slide_vertical_color_section_wide.svg.meta     |    53 +
 .../Vector/Yellow/slide_vertical_grey.svg          |     7 +
 .../Vector/Yellow/slide_vertical_grey.svg.meta     |    53 +
 .../Vector/Yellow/slide_vertical_grey_section.svg  |     7 +
 .../Yellow/slide_vertical_grey_section.svg.meta    |    53 +
 .../Yellow/slide_vertical_grey_section_wide.svg    |     7 +
 .../slide_vertical_grey_section_wide.svg.meta      |    53 +
 .../NewUI/kenney_ui-pack/Vector/Yellow/star.svg    |    18 +
 .../kenney_ui-pack/Vector/Yellow/star.svg.meta     |    53 +
 .../kenney_ui-pack/Vector/Yellow/star_outline.svg  |     7 +
 .../Vector/Yellow/star_outline.svg.meta            |    53 +
 .../Vector/Yellow/star_outline_depth.svg           |    12 +
 .../Vector/Yellow/star_outline_depth.svg.meta      |    53 +
 .../textures/NewUI/kenney_ui-pack/Visit Kenney.url |     2 +
 .../NewUI/kenney_ui-pack/Visit Kenney.url.meta     |     7 +
 .../NewUI/kenney_ui-pack/Visit Patreon.url         |     2 +
 .../NewUI/kenney_ui-pack/Visit Patreon.url.meta    |     7 +
 .../Assets/textures/NewUI/mobile-controls-1.meta   |     8 +
 .../textures/NewUI/mobile-controls-1/License.txt   |    28 +
 .../NewUI/mobile-controls-1/License.txt.meta       |     7 +
 .../textures/NewUI/mobile-controls-1/Preview.png   |   Bin 0 -> 41718 bytes
 .../NewUI/mobile-controls-1/Preview.png.meta       |   130 +
 .../textures/NewUI/mobile-controls-1/Sample.png    |   Bin 0 -> 22058 bytes
 .../NewUI/mobile-controls-1/Sample.png.meta        |   130 +
 .../textures/NewUI/mobile-controls-1/Sprites.meta  |     8 +
 .../mobile-controls-1/Sprites/Highlights A.meta    |     8 +
 .../Sprites/Highlights A/Default.meta              |     8 +
 .../Highlights A/Default/button_bean_highlight.png |   Bin 0 -> 1339 bytes
 .../Default/button_bean_highlight.png.meta         |   130 +
 .../Default/button_circle_highlight.png            |   Bin 0 -> 2030 bytes
 .../Default/button_circle_highlight.png.meta       |   130 +
 .../Default/button_circle_wide_highlight.png       |   Bin 0 -> 2047 bytes
 .../Default/button_circle_wide_highlight.png.meta  |   130 +
 .../Default/button_diamond_highlight.png           |   Bin 0 -> 1563 bytes
 .../Default/button_diamond_highlight.png.meta      |   130 +
 .../Default/button_diamond_highlight_wide.png      |   Bin 0 -> 1718 bytes
 .../Default/button_diamond_highlight_wide.png.meta |   130 +
 .../Default/button_hexagon_highlight.png           |   Bin 0 -> 1758 bytes
 .../Default/button_hexagon_highlight.png.meta      |   130 +
 .../Default/button_hexagon_wide_highlight.png      |   Bin 0 -> 1839 bytes
 .../Default/button_hexagon_wide_highlight.png.meta |   130 +
 .../Default/button_square_highlight.png            |   Bin 0 -> 552 bytes
 .../Default/button_square_highlight.png.meta       |   130 +
 .../Default/button_square_wide_highlight.png       |   Bin 0 -> 618 bytes
 .../Default/button_square_wide_highlight.png.meta  |   130 +
 .../Default/direction_left_highlight.png           |   Bin 0 -> 1331 bytes
 .../Default/direction_left_highlight.png.meta      |   130 +
 .../Default/direction_right_highlight.png          |   Bin 0 -> 1287 bytes
 .../Default/direction_right_highlight.png.meta     |   130 +
 .../Default/dpad_element_east_highlight.png        |   Bin 0 -> 932 bytes
 .../Default/dpad_element_east_highlight.png.meta   |   130 +
 .../Default/dpad_element_north_highlight.png       |   Bin 0 -> 781 bytes
 .../Default/dpad_element_north_highlight.png.meta  |   130 +
 .../Default/dpad_element_south_highlight.png       |   Bin 0 -> 737 bytes
 .../Default/dpad_element_south_highlight.png.meta  |   130 +
 .../Default/dpad_element_west_highlight.png        |   Bin 0 -> 917 bytes
 .../Default/dpad_element_west_highlight.png.meta   |   130 +
 .../Highlights A/Default/dpad_highlight.png        |   Bin 0 -> 1011 bytes
 .../Highlights A/Default/dpad_highlight.png.meta   |   130 +
 .../Default/dpad_separate_highlight.png            |   Bin 0 -> 2170 bytes
 .../Default/dpad_separate_highlight.png.meta       |   130 +
 .../Highlights A/Default/dpad_small_highlight.png  |   Bin 0 -> 896 bytes
 .../Default/dpad_small_highlight.png.meta          |   130 +
 .../Default/joystick_circle_nub_highlight.png      |   Bin 0 -> 2080 bytes
 .../Default/joystick_circle_nub_highlight.png.meta |   130 +
 .../Default/joystick_circle_pad_highlight.png      |   Bin 0 -> 3097 bytes
 .../Default/joystick_circle_pad_highlight.png.meta |   130 +
 .../Default/joystick_hexagon_nub_highlight.png     |   Bin 0 -> 2065 bytes
 .../joystick_hexagon_nub_highlight.png.meta        |   130 +
 .../Default/joystick_hexagon_pad_highlight.png     |   Bin 0 -> 3053 bytes
 .../joystick_hexagon_pad_highlight.png.meta        |   130 +
 .../Default/joystick_polygon_nub_highlight.png     |   Bin 0 -> 2103 bytes
 .../joystick_polygon_nub_highlight.png.meta        |   130 +
 .../Default/joystick_polygon_pad_highlight.png     |   Bin 0 -> 3120 bytes
 .../joystick_polygon_pad_highlight.png.meta        |   130 +
 .../Default/joystick_square_nub_highlight.png      |   Bin 0 -> 373 bytes
 .../Default/joystick_square_nub_highlight.png.meta |   130 +
 .../Default/joystick_square_pad_highlight.png      |   Bin 0 -> 805 bytes
 .../Default/joystick_square_pad_highlight.png.meta |   130 +
 .../Sprites/Highlights A/Large (2\303\227).meta"   |     8 +
 .../Large (2\303\227)/button_bean_highlight.png"   |   Bin 0 -> 2350 bytes
 .../button_bean_highlight.png.meta"                |   130 +
 .../Large (2\303\227)/button_circle_highlight.png" |   Bin 0 -> 2974 bytes
 .../button_circle_highlight.png.meta"              |   130 +
 .../button_circle_wide_highlight.png"              |   Bin 0 -> 3112 bytes
 .../button_circle_wide_highlight.png.meta"         |   130 +
 .../button_diamond_highlight.png"                  |   Bin 0 -> 1932 bytes
 .../button_diamond_highlight.png.meta"             |   130 +
 .../button_diamond_highlight_wide.png"             |   Bin 0 -> 2254 bytes
 .../button_diamond_highlight_wide.png.meta"        |   130 +
 .../button_hexagon_highlight.png"                  |   Bin 0 -> 2511 bytes
 .../button_hexagon_highlight.png.meta"             |   130 +
 .../button_hexagon_wide_highlight.png"             |   Bin 0 -> 2627 bytes
 .../button_hexagon_wide_highlight.png.meta"        |   130 +
 .../Large (2\303\227)/button_square_highlight.png" |   Bin 0 -> 1143 bytes
 .../button_square_highlight.png.meta"              |   130 +
 .../button_square_wide_highlight.png"              |   Bin 0 -> 1181 bytes
 .../button_square_wide_highlight.png.meta"         |   130 +
 .../direction_left_highlight.png"                  |   Bin 0 -> 1858 bytes
 .../direction_left_highlight.png.meta"             |   130 +
 .../direction_right_highlight.png"                 |   Bin 0 -> 1892 bytes
 .../direction_right_highlight.png.meta"            |   130 +
 .../dpad_element_east_highlight.png"               |   Bin 0 -> 1231 bytes
 .../dpad_element_east_highlight.png.meta"          |   130 +
 .../dpad_element_north_highlight.png"              |   Bin 0 -> 1012 bytes
 .../dpad_element_north_highlight.png.meta"         |   130 +
 .../dpad_element_south_highlight.png"              |   Bin 0 -> 971 bytes
 .../dpad_element_south_highlight.png.meta"         |   130 +
 .../dpad_element_west_highlight.png"               |   Bin 0 -> 1240 bytes
 .../dpad_element_west_highlight.png.meta"          |   130 +
 .../Large (2\303\227)/dpad_highlight.png"          |   Bin 0 -> 1443 bytes
 .../Large (2\303\227)/dpad_highlight.png.meta"     |   130 +
 .../Large (2\303\227)/dpad_separate_highlight.png" |   Bin 0 -> 3198 bytes
 .../dpad_separate_highlight.png.meta"              |   130 +
 .../Large (2\303\227)/dpad_small_highlight.png"    |   Bin 0 -> 1320 bytes
 .../dpad_small_highlight.png.meta"                 |   130 +
 .../joystick_circle_nub_highlight.png"             |   Bin 0 -> 3045 bytes
 .../joystick_circle_nub_highlight.png.meta"        |   130 +
 .../joystick_circle_pad_highlight.png"             |   Bin 0 -> 5143 bytes
 .../joystick_circle_pad_highlight.png.meta"        |   130 +
 .../joystick_hexagon_nub_highlight.png"            |   Bin 0 -> 3007 bytes
 .../joystick_hexagon_nub_highlight.png.meta"       |   130 +
 .../joystick_hexagon_pad_highlight.png"            |   Bin 0 -> 4998 bytes
 .../joystick_hexagon_pad_highlight.png.meta"       |   130 +
 .../joystick_polygon_nub_highlight.png"            |   Bin 0 -> 3129 bytes
 .../joystick_polygon_nub_highlight.png.meta"       |   130 +
 .../joystick_polygon_pad_highlight.png"            |   Bin 0 -> 5134 bytes
 .../joystick_polygon_pad_highlight.png.meta"       |   130 +
 .../joystick_square_nub_highlight.png"             |   Bin 0 -> 729 bytes
 .../joystick_square_nub_highlight.png.meta"        |   130 +
 .../joystick_square_pad_highlight.png"             |   Bin 0 -> 1320 bytes
 .../joystick_square_pad_highlight.png.meta"        |   130 +
 .../mobile-controls-1/Sprites/Highlights B.meta    |     8 +
 .../Sprites/Highlights B/Default.meta              |     8 +
 .../Highlights B/Default/button_bean_highlight.png |   Bin 0 -> 1354 bytes
 .../Default/button_bean_highlight.png.meta         |   130 +
 .../Default/button_circle_highlight.png            |   Bin 0 -> 2026 bytes
 .../Default/button_circle_highlight.png.meta       |   130 +
 .../Default/button_circle_wide_highlight.png       |   Bin 0 -> 2040 bytes
 .../Default/button_circle_wide_highlight.png.meta  |   130 +
 .../Default/button_diamond_highlight.png           |   Bin 0 -> 1820 bytes
 .../Default/button_diamond_highlight.png.meta      |   130 +
 .../Default/button_diamond_highlight_wide.png      |   Bin 0 -> 1850 bytes
 .../Default/button_diamond_highlight_wide.png.meta |   130 +
 .../Default/button_hexagon_highlight.png           |   Bin 0 -> 1850 bytes
 .../Default/button_hexagon_highlight.png.meta      |   130 +
 .../Default/button_hexagon_wide_highlight.png      |   Bin 0 -> 1895 bytes
 .../Default/button_hexagon_wide_highlight.png.meta |   130 +
 .../Default/button_square_highlight.png            |   Bin 0 -> 634 bytes
 .../Default/button_square_highlight.png.meta       |   130 +
 .../Default/button_square_wide_highlight.png       |   Bin 0 -> 714 bytes
 .../Default/button_square_wide_highlight.png.meta  |   130 +
 .../Default/direction_left_highlight.png           |   Bin 0 -> 1660 bytes
 .../Default/direction_left_highlight.png.meta      |   130 +
 .../Default/direction_right_highlight.png          |   Bin 0 -> 1567 bytes
 .../Default/direction_right_highlight.png.meta     |   130 +
 .../Default/dpad_element_east_highlight.png        |   Bin 0 -> 1337 bytes
 .../Default/dpad_element_east_highlight.png.meta   |   130 +
 .../Default/dpad_element_north_highlight.png       |   Bin 0 -> 1090 bytes
 .../Default/dpad_element_north_highlight.png.meta  |   130 +
 .../Default/dpad_element_south_highlight.png       |   Bin 0 -> 1042 bytes
 .../Default/dpad_element_south_highlight.png.meta  |   130 +
 .../Default/dpad_element_west_highlight.png        |   Bin 0 -> 1323 bytes
 .../Default/dpad_element_west_highlight.png.meta   |   130 +
 .../Highlights B/Default/dpad_highlight.png        |   Bin 0 -> 1447 bytes
 .../Highlights B/Default/dpad_highlight.png.meta   |   130 +
 .../Default/dpad_separate_highlight.png            |   Bin 0 -> 2825 bytes
 .../Default/dpad_separate_highlight.png.meta       |   130 +
 .../Highlights B/Default/dpad_small_highlight.png  |   Bin 0 -> 1167 bytes
 .../Default/dpad_small_highlight.png.meta          |   130 +
 .../Default/joystick_circle_nub_highlight.png      |   Bin 0 -> 2083 bytes
 .../Default/joystick_circle_nub_highlight.png.meta |   130 +
 .../Default/joystick_circle_pad_highlight.png      |   Bin 0 -> 3113 bytes
 .../Default/joystick_circle_pad_highlight.png.meta |   130 +
 .../Default/joystick_hexagon_nub_highlight.png     |   Bin 0 -> 2063 bytes
 .../joystick_hexagon_nub_highlight.png.meta        |   130 +
 .../Default/joystick_hexagon_pad_highlight.png     |   Bin 0 -> 3044 bytes
 .../joystick_hexagon_pad_highlight.png.meta        |   130 +
 .../Default/joystick_polygon_nub_highlight.png     |   Bin 0 -> 2101 bytes
 .../joystick_polygon_nub_highlight.png.meta        |   130 +
 .../Default/joystick_polygon_pad_highlight.png     |   Bin 0 -> 3129 bytes
 .../joystick_polygon_pad_highlight.png.meta        |   130 +
 .../Default/joystick_square_nub_highlight.png      |   Bin 0 -> 423 bytes
 .../Default/joystick_square_nub_highlight.png.meta |   130 +
 .../Default/joystick_square_pad_highlight.png      |   Bin 0 -> 958 bytes
 .../Default/joystick_square_pad_highlight.png.meta |   130 +
 .../Sprites/Highlights B/Large (2\303\227).meta"   |     8 +
 .../Large (2\303\227)/button_bean_highlight.png"   |   Bin 0 -> 2372 bytes
 .../button_bean_highlight.png.meta"                |   130 +
 .../Large (2\303\227)/button_circle_highlight.png" |   Bin 0 -> 2986 bytes
 .../button_circle_highlight.png.meta"              |   130 +
 .../button_circle_wide_highlight.png"              |   Bin 0 -> 3097 bytes
 .../button_circle_wide_highlight.png.meta"         |   130 +
 .../button_diamond_highlight.png"                  |   Bin 0 -> 2387 bytes
 .../button_diamond_highlight.png.meta"             |   130 +
 .../button_diamond_highlight_wide.png"             |   Bin 0 -> 2464 bytes
 .../button_diamond_highlight_wide.png.meta"        |   130 +
 .../button_hexagon_highlight.png"                  |   Bin 0 -> 2579 bytes
 .../button_hexagon_highlight.png.meta"             |   130 +
 .../button_hexagon_wide_highlight.png"             |   Bin 0 -> 2670 bytes
 .../button_hexagon_wide_highlight.png.meta"        |   130 +
 .../Large (2\303\227)/button_square_highlight.png" |   Bin 0 -> 1349 bytes
 .../button_square_highlight.png.meta"              |   130 +
 .../button_square_wide_highlight.png"              |   Bin 0 -> 1477 bytes
 .../button_square_wide_highlight.png.meta"         |   130 +
 .../direction_left_highlight.png"                  |   Bin 0 -> 2267 bytes
 .../direction_left_highlight.png.meta"             |   130 +
 .../direction_right_highlight.png"                 |   Bin 0 -> 2299 bytes
 .../direction_right_highlight.png.meta"            |   130 +
 .../dpad_element_east_highlight.png"               |   Bin 0 -> 1777 bytes
 .../dpad_element_east_highlight.png.meta"          |   130 +
 .../dpad_element_north_highlight.png"              |   Bin 0 -> 1491 bytes
 .../dpad_element_north_highlight.png.meta"         |   130 +
 .../dpad_element_south_highlight.png"              |   Bin 0 -> 1424 bytes
 .../dpad_element_south_highlight.png.meta"         |   130 +
 .../dpad_element_west_highlight.png"               |   Bin 0 -> 1797 bytes
 .../dpad_element_west_highlight.png.meta"          |   130 +
 .../Large (2\303\227)/dpad_highlight.png"          |   Bin 0 -> 2188 bytes
 .../Large (2\303\227)/dpad_highlight.png.meta"     |   130 +
 .../Large (2\303\227)/dpad_separate_highlight.png" |   Bin 0 -> 4003 bytes
 .../dpad_separate_highlight.png.meta"              |   130 +
 .../Large (2\303\227)/dpad_small_highlight.png"    |   Bin 0 -> 1835 bytes
 .../dpad_small_highlight.png.meta"                 |   130 +
 .../joystick_circle_nub_highlight.png"             |   Bin 0 -> 3072 bytes
 .../joystick_circle_nub_highlight.png.meta"        |   130 +
 .../joystick_circle_pad_highlight.png"             |   Bin 0 -> 5203 bytes
 .../joystick_circle_pad_highlight.png.meta"        |   130 +
 .../joystick_hexagon_nub_highlight.png"            |   Bin 0 -> 3021 bytes
 .../joystick_hexagon_nub_highlight.png.meta"       |   130 +
 .../joystick_hexagon_pad_highlight.png"            |   Bin 0 -> 5031 bytes
 .../joystick_hexagon_pad_highlight.png.meta"       |   130 +
 .../joystick_polygon_nub_highlight.png"            |   Bin 0 -> 3128 bytes
 .../joystick_polygon_nub_highlight.png.meta"       |   130 +
 .../joystick_polygon_pad_highlight.png"            |   Bin 0 -> 5184 bytes
 .../joystick_polygon_pad_highlight.png.meta"       |   130 +
 .../joystick_square_nub_highlight.png"             |   Bin 0 -> 853 bytes
 .../joystick_square_nub_highlight.png.meta"        |   130 +
 .../joystick_square_pad_highlight.png"             |   Bin 0 -> 1982 bytes
 .../joystick_square_pad_highlight.png.meta"        |   130 +
 .../NewUI/mobile-controls-1/Sprites/Icons.meta     |     8 +
 .../mobile-controls-1/Sprites/Icons/Default.meta   |     8 +
 .../Sprites/Icons/Default/icon_arrow.png           |   Bin 0 -> 386 bytes
 .../Sprites/Icons/Default/icon_arrow.png.meta      |   130 +
 .../Sprites/Icons/Default/icon_arrow_curved.png    |   Bin 0 -> 877 bytes
 .../Icons/Default/icon_arrow_curved.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_arrow_rotate.png    |   Bin 0 -> 939 bytes
 .../Icons/Default/icon_arrow_rotate.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_burst.png           |   Bin 0 -> 438 bytes
 .../Sprites/Icons/Default/icon_burst.png.meta      |   130 +
 .../Sprites/Icons/Default/icon_button_a.png        |   Bin 0 -> 424 bytes
 .../Sprites/Icons/Default/icon_button_a.png.meta   |   130 +
 .../Sprites/Icons/Default/icon_button_b.png        |   Bin 0 -> 339 bytes
 .../Sprites/Icons/Default/icon_button_b.png.meta   |   130 +
 .../Sprites/Icons/Default/icon_button_l.png        |   Bin 0 -> 199 bytes
 .../Sprites/Icons/Default/icon_button_l.png.meta   |   130 +
 .../Sprites/Icons/Default/icon_button_r.png        |   Bin 0 -> 365 bytes
 .../Sprites/Icons/Default/icon_button_r.png.meta   |   130 +
 .../Sprites/Icons/Default/icon_button_x.png        |   Bin 0 -> 502 bytes
 .../Sprites/Icons/Default/icon_button_x.png.meta   |   130 +
 .../Sprites/Icons/Default/icon_button_y.png        |   Bin 0 -> 419 bytes
 .../Sprites/Icons/Default/icon_button_y.png.meta   |   130 +
 .../Sprites/Icons/Default/icon_checkmark.png       |   Bin 0 -> 401 bytes
 .../Sprites/Icons/Default/icon_checkmark.png.meta  |   130 +
 .../Sprites/Icons/Default/icon_cog.png             |   Bin 0 -> 1221 bytes
 .../Sprites/Icons/Default/icon_cog.png.meta        |   130 +
 .../Sprites/Icons/Default/icon_cross.png           |   Bin 0 -> 461 bytes
 .../Sprites/Icons/Default/icon_cross.png.meta      |   130 +
 .../Sprites/Icons/Default/icon_crosshair.png       |   Bin 0 -> 703 bytes
 .../Sprites/Icons/Default/icon_crosshair.png.meta  |   130 +
 .../Sprites/Icons/Default/icon_fire.png            |   Bin 0 -> 479 bytes
 .../Sprites/Icons/Default/icon_fire.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_hand.png            |   Bin 0 -> 427 bytes
 .../Sprites/Icons/Default/icon_hand.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_jump.png            |   Bin 0 -> 389 bytes
 .../Sprites/Icons/Default/icon_jump.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_key.png             |   Bin 0 -> 684 bytes
 .../Sprites/Icons/Default/icon_key.png.meta        |   130 +
 .../Sprites/Icons/Default/icon_lock.png            |   Bin 0 -> 661 bytes
 .../Sprites/Icons/Default/icon_lock.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_menu.png            |   Bin 0 -> 198 bytes
 .../Sprites/Icons/Default/icon_menu.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_microphone.png      |   Bin 0 -> 475 bytes
 .../Sprites/Icons/Default/icon_microphone.png.meta |   130 +
 .../Sprites/Icons/Default/icon_money.png           |   Bin 0 -> 473 bytes
 .../Sprites/Icons/Default/icon_money.png.meta      |   130 +
 .../Sprites/Icons/Default/icon_music.png           |   Bin 0 -> 427 bytes
 .../Sprites/Icons/Default/icon_music.png.meta      |   130 +
 .../Sprites/Icons/Default/icon_music_disabled.png  |   Bin 0 -> 466 bytes
 .../Icons/Default/icon_music_disabled.png.meta     |   130 +
 .../Sprites/Icons/Default/icon_pause.png           |   Bin 0 -> 209 bytes
 .../Sprites/Icons/Default/icon_pause.png.meta      |   130 +
 .../Sprites/Icons/Default/icon_pedal.png           |   Bin 0 -> 427 bytes
 .../Sprites/Icons/Default/icon_pedal.png.meta      |   130 +
 .../Sprites/Icons/Default/icon_pedal_brake.png     |   Bin 0 -> 323 bytes
 .../Icons/Default/icon_pedal_brake.png.meta        |   130 +
 .../Sprites/Icons/Default/icon_play.png            |   Bin 0 -> 379 bytes
 .../Sprites/Icons/Default/icon_play.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_save.png            |   Bin 0 -> 278 bytes
 .../Sprites/Icons/Default/icon_save.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_search.png          |   Bin 0 -> 487 bytes
 .../Sprites/Icons/Default/icon_search.png.meta     |   130 +
 .../Sprites/Icons/Default/icon_shield.png          |   Bin 0 -> 1245 bytes
 .../Sprites/Icons/Default/icon_shield.png.meta     |   130 +
 .../Sprites/Icons/Default/icon_size_larger.png     |   Bin 0 -> 373 bytes
 .../Icons/Default/icon_size_larger.png.meta        |   130 +
 .../Sprites/Icons/Default/icon_size_smaller.png    |   Bin 0 -> 383 bytes
 .../Icons/Default/icon_size_smaller.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_skull.png           |   Bin 0 -> 464 bytes
 .../Sprites/Icons/Default/icon_skull.png.meta      |   130 +
 .../Sprites/Icons/Default/icon_sound.png           |   Bin 0 -> 489 bytes
 .../Sprites/Icons/Default/icon_sound.png.meta      |   130 +
 .../Sprites/Icons/Default/icon_sound_disabled.png  |   Bin 0 -> 500 bytes
 .../Icons/Default/icon_sound_disabled.png.meta     |   130 +
 .../Sprites/Icons/Default/icon_star.png            |   Bin 0 -> 429 bytes
 .../Sprites/Icons/Default/icon_star.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_steering_wheel.png  |   Bin 0 -> 570 bytes
 .../Icons/Default/icon_steering_wheel.png.meta     |   130 +
 .../Sprites/Icons/Default/icon_sword.png           |   Bin 0 -> 950 bytes
 .../Sprites/Icons/Default/icon_sword.png.meta      |   130 +
 .../Sprites/Icons/Default/icon_talk.png            |   Bin 0 -> 400 bytes
 .../Sprites/Icons/Default/icon_talk.png.meta       |   130 +
 .../Sprites/Icons/Default/icon_target.png          |   Bin 0 -> 608 bytes
 .../Sprites/Icons/Default/icon_target.png.meta     |   130 +
 .../Sprites/Icons/Default/icon_wrench.png          |   Bin 0 -> 457 bytes
 .../Sprites/Icons/Default/icon_wrench.png.meta     |   130 +
 .../Sprites/Icons/Large (2\303\227).meta"          |     8 +
 .../Icons/Large (2\303\227)/icon_arrow.png"        |   Bin 0 -> 705 bytes
 .../Icons/Large (2\303\227)/icon_arrow.png.meta"   |   130 +
 .../Icons/Large (2\303\227)/icon_arrow_curved.png" |   Bin 0 -> 1455 bytes
 .../Large (2\303\227)/icon_arrow_curved.png.meta"  |   130 +
 .../Icons/Large (2\303\227)/icon_arrow_rotate.png" |   Bin 0 -> 1581 bytes
 .../Large (2\303\227)/icon_arrow_rotate.png.meta"  |   130 +
 .../Icons/Large (2\303\227)/icon_burst.png"        |   Bin 0 -> 707 bytes
 .../Icons/Large (2\303\227)/icon_burst.png.meta"   |   130 +
 .../Icons/Large (2\303\227)/icon_button_a.png"     |   Bin 0 -> 647 bytes
 .../Large (2\303\227)/icon_button_a.png.meta"      |   130 +
 .../Icons/Large (2\303\227)/icon_button_b.png"     |   Bin 0 -> 495 bytes
 .../Large (2\303\227)/icon_button_b.png.meta"      |   130 +
 .../Icons/Large (2\303\227)/icon_button_l.png"     |   Bin 0 -> 273 bytes
 .../Large (2\303\227)/icon_button_l.png.meta"      |   130 +
 .../Icons/Large (2\303\227)/icon_button_r.png"     |   Bin 0 -> 534 bytes
 .../Large (2\303\227)/icon_button_r.png.meta"      |   130 +
 .../Icons/Large (2\303\227)/icon_button_x.png"     |   Bin 0 -> 779 bytes
 .../Large (2\303\227)/icon_button_x.png.meta"      |   130 +
 .../Icons/Large (2\303\227)/icon_button_y.png"     |   Bin 0 -> 588 bytes
 .../Large (2\303\227)/icon_button_y.png.meta"      |   130 +
 .../Icons/Large (2\303\227)/icon_checkmark.png"    |   Bin 0 -> 600 bytes
 .../Large (2\303\227)/icon_checkmark.png.meta"     |   130 +
 .../Sprites/Icons/Large (2\303\227)/icon_cog.png"  |   Bin 0 -> 2076 bytes
 .../Icons/Large (2\303\227)/icon_cog.png.meta"     |   130 +
 .../Icons/Large (2\303\227)/icon_cross.png"        |   Bin 0 -> 722 bytes
 .../Icons/Large (2\303\227)/icon_cross.png.meta"   |   130 +
 .../Icons/Large (2\303\227)/icon_crosshair.png"    |   Bin 0 -> 1214 bytes
 .../Large (2\303\227)/icon_crosshair.png.meta"     |   130 +
 .../Sprites/Icons/Large (2\303\227)/icon_fire.png" |   Bin 0 -> 809 bytes
 .../Icons/Large (2\303\227)/icon_fire.png.meta"    |   130 +
 .../Sprites/Icons/Large (2\303\227)/icon_hand.png" |   Bin 0 -> 667 bytes
 .../Icons/Large (2\303\227)/icon_hand.png.meta"    |   130 +
 .../Sprites/Icons/Large (2\303\227)/icon_jump.png" |   Bin 0 -> 583 bytes
 .../Icons/Large (2\303\227)/icon_jump.png.meta"    |   130 +
 .../Sprites/Icons/Large (2\303\227)/icon_key.png"  |   Bin 0 -> 1196 bytes
 .../Icons/Large (2\303\227)/icon_key.png.meta"     |   130 +
 .../Sprites/Icons/Large (2\303\227)/icon_lock.png" |   Bin 0 -> 1203 bytes
 .../Icons/Large (2\303\227)/icon_lock.png.meta"    |   130 +
 .../Sprites/Icons/Large (2\303\227)/icon_menu.png" |   Bin 0 -> 277 bytes
 .../Icons/Large (2\303\227)/icon_menu.png.meta"    |   130 +
 .../Icons/Large (2\303\227)/icon_microphone.png"   |   Bin 0 -> 758 bytes
 .../Large (2\303\227)/icon_microphone.png.meta"    |   130 +
 .../Icons/Large (2\303\227)/icon_money.png"        |   Bin 0 -> 789 bytes
 .../Icons/Large (2\303\227)/icon_money.png.meta"   |   130 +
 .../Icons/Large (2\303\227)/icon_music.png"        |   Bin 0 -> 641 bytes
 .../Icons/Large (2\303\227)/icon_music.png.meta"   |   130 +
 .../Large (2\303\227)/icon_music_disabled.png"     |   Bin 0 -> 756 bytes
 .../icon_music_disabled.png.meta"                  |   130 +
 .../Icons/Large (2\303\227)/icon_pause.png"        |   Bin 0 -> 296 bytes
 .../Icons/Large (2\303\227)/icon_pause.png.meta"   |   130 +
 .../Icons/Large (2\303\227)/icon_pedal.png"        |   Bin 0 -> 702 bytes
 .../Icons/Large (2\303\227)/icon_pedal.png.meta"   |   130 +
 .../Icons/Large (2\303\227)/icon_pedal_brake.png"  |   Bin 0 -> 490 bytes
 .../Large (2\303\227)/icon_pedal_brake.png.meta"   |   130 +
 .../Sprites/Icons/Large (2\303\227)/icon_play.png" |   Bin 0 -> 596 bytes
 .../Icons/Large (2\303\227)/icon_play.png.meta"    |   130 +
 .../Sprites/Icons/Large (2\303\227)/icon_save.png" |   Bin 0 -> 386 bytes
 .../Icons/Large (2\303\227)/icon_save.png.meta"    |   130 +
 .../Icons/Large (2\303\227)/icon_search.png"       |   Bin 0 -> 793 bytes
 .../Icons/Large (2\303\227)/icon_search.png.meta"  |   130 +
 .../Icons/Large (2\303\227)/icon_shield.png"       |   Bin 0 -> 2018 bytes
 .../Icons/Large (2\303\227)/icon_shield.png.meta"  |   130 +
 .../Icons/Large (2\303\227)/icon_size_larger.png"  |   Bin 0 -> 593 bytes
 .../Large (2\303\227)/icon_size_larger.png.meta"   |   130 +
 .../Icons/Large (2\303\227)/icon_size_smaller.png" |   Bin 0 -> 604 bytes
 .../Large (2\303\227)/icon_size_smaller.png.meta"  |   130 +
 .../Icons/Large (2\303\227)/icon_skull.png"        |   Bin 0 -> 757 bytes
 .../Icons/Large (2\303\227)/icon_skull.png.meta"   |   130 +
 .../Icons/Large (2\303\227)/icon_sound.png"        |   Bin 0 -> 817 bytes
 .../Icons/Large (2\303\227)/icon_sound.png.meta"   |   130 +
 .../Large (2\303\227)/icon_sound_disabled.png"     |   Bin 0 -> 818 bytes
 .../icon_sound_disabled.png.meta"                  |   130 +
 .../Sprites/Icons/Large (2\303\227)/icon_star.png" |   Bin 0 -> 703 bytes
 .../Icons/Large (2\303\227)/icon_star.png.meta"    |   130 +
 .../Large (2\303\227)/icon_steering_wheel.png"     |   Bin 0 -> 984 bytes
 .../icon_steering_wheel.png.meta"                  |   130 +
 .../Icons/Large (2\303\227)/icon_sword.png"        |   Bin 0 -> 1411 bytes
 .../Icons/Large (2\303\227)/icon_sword.png.meta"   |   130 +
 .../Sprites/Icons/Large (2\303\227)/icon_talk.png" |   Bin 0 -> 665 bytes
 .../Icons/Large (2\303\227)/icon_talk.png.meta"    |   130 +
 .../Icons/Large (2\303\227)/icon_target.png"       |   Bin 0 -> 1104 bytes
 .../Icons/Large (2\303\227)/icon_target.png.meta"  |   130 +
 .../Icons/Large (2\303\227)/icon_wrench.png"       |   Bin 0 -> 774 bytes
 .../Icons/Large (2\303\227)/icon_wrench.png.meta"  |   130 +
 .../NewUI/mobile-controls-1/Sprites/Style A.meta   |     8 +
 .../mobile-controls-1/Sprites/Style A/Default.meta |     8 +
 .../Sprites/Style A/Default/button_bean.png        |   Bin 0 -> 1051 bytes
 .../Sprites/Style A/Default/button_bean.png.meta   |   130 +
 .../Sprites/Style A/Default/button_circle.png      |   Bin 0 -> 1549 bytes
 .../Sprites/Style A/Default/button_circle.png.meta |   130 +
 .../Sprites/Style A/Default/button_circle_wide.png |   Bin 0 -> 1619 bytes
 .../Style A/Default/button_circle_wide.png.meta    |   130 +
 .../Sprites/Style A/Default/button_diamond.png     |   Bin 0 -> 1106 bytes
 .../Style A/Default/button_diamond.png.meta        |   130 +
 .../Style A/Default/button_diamond_wide.png        |   Bin 0 -> 1196 bytes
 .../Style A/Default/button_diamond_wide.png.meta   |   130 +
 .../Sprites/Style A/Default/button_hexagon.png     |   Bin 0 -> 1290 bytes
 .../Style A/Default/button_hexagon.png.meta        |   130 +
 .../Style A/Default/button_hexagon_wide.png        |   Bin 0 -> 1360 bytes
 .../Style A/Default/button_hexagon_wide.png.meta   |   130 +
 .../Sprites/Style A/Default/button_square.png      |   Bin 0 -> 600 bytes
 .../Sprites/Style A/Default/button_square.png.meta |   130 +
 .../Sprites/Style A/Default/button_square_wide.png |   Bin 0 -> 664 bytes
 .../Style A/Default/button_square_wide.png.meta    |   130 +
 .../Sprites/Style A/Default/direction_left.png     |   Bin 0 -> 1045 bytes
 .../Style A/Default/direction_left.png.meta        |   130 +
 .../Sprites/Style A/Default/direction_right.png    |   Bin 0 -> 1062 bytes
 .../Style A/Default/direction_right.png.meta       |   130 +
 .../Sprites/Style A/Default/dpad.png               |   Bin 0 -> 1198 bytes
 .../Sprites/Style A/Default/dpad.png.meta          |   130 +
 .../Sprites/Style A/Default/dpad_element_east.png  |   Bin 0 -> 806 bytes
 .../Style A/Default/dpad_element_east.png.meta     |   130 +
 .../Sprites/Style A/Default/dpad_element_north.png |   Bin 0 -> 782 bytes
 .../Style A/Default/dpad_element_north.png.meta    |   130 +
 .../Sprites/Style A/Default/dpad_element_south.png |   Bin 0 -> 726 bytes
 .../Style A/Default/dpad_element_south.png.meta    |   130 +
 .../Sprites/Style A/Default/dpad_element_west.png  |   Bin 0 -> 831 bytes
 .../Style A/Default/dpad_element_west.png.meta     |   130 +
 .../Sprites/Style A/Default/dpad_separate.png      |   Bin 0 -> 1974 bytes
 .../Sprites/Style A/Default/dpad_separate.png.meta |   130 +
 .../Sprites/Style A/Default/dpad_small.png         |   Bin 0 -> 1097 bytes
 .../Sprites/Style A/Default/dpad_small.png.meta    |   130 +
 .../Style A/Default/joystick_circle_nub_a.png      |   Bin 0 -> 1776 bytes
 .../Style A/Default/joystick_circle_nub_a.png.meta |   130 +
 .../Style A/Default/joystick_circle_nub_b.png      |   Bin 0 -> 1653 bytes
 .../Style A/Default/joystick_circle_nub_b.png.meta |   130 +
 .../Style A/Default/joystick_circle_nub_c.png      |   Bin 0 -> 1565 bytes
 .../Style A/Default/joystick_circle_nub_c.png.meta |   130 +
 .../Style A/Default/joystick_circle_pad_a.png      |   Bin 0 -> 3022 bytes
 .../Style A/Default/joystick_circle_pad_a.png.meta |   130 +
 .../Style A/Default/joystick_circle_pad_b.png      |   Bin 0 -> 3029 bytes
 .../Style A/Default/joystick_circle_pad_b.png.meta |   130 +
 .../Style A/Default/joystick_circle_pad_c.png      |   Bin 0 -> 3190 bytes
 .../Style A/Default/joystick_circle_pad_c.png.meta |   130 +
 .../Style A/Default/joystick_circle_pad_d.png      |   Bin 0 -> 2827 bytes
 .../Style A/Default/joystick_circle_pad_d.png.meta |   130 +
 .../Style A/Default/joystick_hexagon_nub_a.png     |   Bin 0 -> 1670 bytes
 .../Default/joystick_hexagon_nub_a.png.meta        |   130 +
 .../Style A/Default/joystick_hexagon_nub_b.png     |   Bin 0 -> 1536 bytes
 .../Default/joystick_hexagon_nub_b.png.meta        |   130 +
 .../Style A/Default/joystick_hexagon_nub_c.png     |   Bin 0 -> 1460 bytes
 .../Default/joystick_hexagon_nub_c.png.meta        |   130 +
 .../Style A/Default/joystick_hexagon_pad_a.png     |   Bin 0 -> 3091 bytes
 .../Default/joystick_hexagon_pad_a.png.meta        |   130 +
 .../Style A/Default/joystick_hexagon_pad_b.png     |   Bin 0 -> 3103 bytes
 .../Default/joystick_hexagon_pad_b.png.meta        |   130 +
 .../Style A/Default/joystick_hexagon_pad_c.png     |   Bin 0 -> 3271 bytes
 .../Default/joystick_hexagon_pad_c.png.meta        |   130 +
 .../Style A/Default/joystick_hexagon_pad_d.png     |   Bin 0 -> 2895 bytes
 .../Default/joystick_hexagon_pad_d.png.meta        |   130 +
 .../Style A/Default/joystick_polygon_nub_a.png     |   Bin 0 -> 1683 bytes
 .../Default/joystick_polygon_nub_a.png.meta        |   130 +
 .../Style A/Default/joystick_polygon_nub_b.png     |   Bin 0 -> 1551 bytes
 .../Default/joystick_polygon_nub_b.png.meta        |   130 +
 .../Style A/Default/joystick_polygon_nub_c.png     |   Bin 0 -> 1481 bytes
 .../Default/joystick_polygon_nub_c.png.meta        |   130 +
 .../Style A/Default/joystick_polygon_pad_a.png     |   Bin 0 -> 3192 bytes
 .../Default/joystick_polygon_pad_a.png.meta        |   130 +
 .../Style A/Default/joystick_polygon_pad_b.png     |   Bin 0 -> 3208 bytes
 .../Default/joystick_polygon_pad_b.png.meta        |   130 +
 .../Style A/Default/joystick_polygon_pad_c.png     |   Bin 0 -> 3363 bytes
 .../Default/joystick_polygon_pad_c.png.meta        |   130 +
 .../Style A/Default/joystick_polygon_pad_d.png     |   Bin 0 -> 3024 bytes
 .../Default/joystick_polygon_pad_d.png.meta        |   130 +
 .../Style A/Default/joystick_square_nub_a.png      |   Bin 0 -> 777 bytes
 .../Style A/Default/joystick_square_nub_a.png.meta |   130 +
 .../Style A/Default/joystick_square_nub_b.png      |   Bin 0 -> 586 bytes
 .../Style A/Default/joystick_square_nub_b.png.meta |   130 +
 .../Style A/Default/joystick_square_nub_c.png      |   Bin 0 -> 468 bytes
 .../Style A/Default/joystick_square_nub_c.png.meta |   130 +
 .../Style A/Default/joystick_square_pad_a.png      |   Bin 0 -> 978 bytes
 .../Style A/Default/joystick_square_pad_a.png.meta |   130 +
 .../Style A/Default/joystick_square_pad_b.png      |   Bin 0 -> 975 bytes
 .../Style A/Default/joystick_square_pad_b.png.meta |   130 +
 .../Style A/Default/joystick_square_pad_c.png      |   Bin 0 -> 1177 bytes
 .../Style A/Default/joystick_square_pad_c.png.meta |   130 +
 .../Style A/Default/joystick_square_pad_d.png      |   Bin 0 -> 749 bytes
 .../Style A/Default/joystick_square_pad_d.png.meta |   130 +
 .../Sprites/Style A/Large (2\303\227).meta"        |     8 +
 .../Style A/Large (2\303\227)/button_bean.png"     |   Bin 0 -> 1831 bytes
 .../Large (2\303\227)/button_bean.png.meta"        |   130 +
 .../Style A/Large (2\303\227)/button_circle.png"   |   Bin 0 -> 2444 bytes
 .../Large (2\303\227)/button_circle.png.meta"      |   130 +
 .../Large (2\303\227)/button_circle_wide.png"      |   Bin 0 -> 2689 bytes
 .../Large (2\303\227)/button_circle_wide.png.meta" |   130 +
 .../Style A/Large (2\303\227)/button_diamond.png"  |   Bin 0 -> 1468 bytes
 .../Large (2\303\227)/button_diamond.png.meta"     |   130 +
 .../Large (2\303\227)/button_diamond_wide.png"     |   Bin 0 -> 1706 bytes
 .../button_diamond_wide.png.meta"                  |   130 +
 .../Style A/Large (2\303\227)/button_hexagon.png"  |   Bin 0 -> 2121 bytes
 .../Large (2\303\227)/button_hexagon.png.meta"     |   130 +
 .../Large (2\303\227)/button_hexagon_wide.png"     |   Bin 0 -> 2245 bytes
 .../button_hexagon_wide.png.meta"                  |   130 +
 .../Style A/Large (2\303\227)/button_square.png"   |   Bin 0 -> 1004 bytes
 .../Large (2\303\227)/button_square.png.meta"      |   130 +
 .../Large (2\303\227)/button_square_wide.png"      |   Bin 0 -> 1048 bytes
 .../Large (2\303\227)/button_square_wide.png.meta" |   130 +
 .../Style A/Large (2\303\227)/direction_left.png"  |   Bin 0 -> 1496 bytes
 .../Large (2\303\227)/direction_left.png.meta"     |   130 +
 .../Style A/Large (2\303\227)/direction_right.png" |   Bin 0 -> 1503 bytes
 .../Large (2\303\227)/direction_right.png.meta"    |   130 +
 .../Sprites/Style A/Large (2\303\227)/dpad.png"    |   Bin 0 -> 1917 bytes
 .../Style A/Large (2\303\227)/dpad.png.meta"       |   130 +
 .../Large (2\303\227)/dpad_element_east.png"       |   Bin 0 -> 1197 bytes
 .../Large (2\303\227)/dpad_element_east.png.meta"  |   130 +
 .../Large (2\303\227)/dpad_element_north.png"      |   Bin 0 -> 1080 bytes
 .../Large (2\303\227)/dpad_element_north.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_south.png"      |   Bin 0 -> 1014 bytes
 .../Large (2\303\227)/dpad_element_south.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_west.png"       |   Bin 0 -> 1217 bytes
 .../Large (2\303\227)/dpad_element_west.png.meta"  |   130 +
 .../Style A/Large (2\303\227)/dpad_separate.png"   |   Bin 0 -> 3208 bytes
 .../Large (2\303\227)/dpad_separate.png.meta"      |   130 +
 .../Style A/Large (2\303\227)/dpad_small.png"      |   Bin 0 -> 1764 bytes
 .../Style A/Large (2\303\227)/dpad_small.png.meta" |   130 +
 .../Large (2\303\227)/joystick_circle_nub_a.png"   |   Bin 0 -> 2890 bytes
 .../joystick_circle_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_b.png"   |   Bin 0 -> 2644 bytes
 .../joystick_circle_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_c.png"   |   Bin 0 -> 2529 bytes
 .../joystick_circle_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_a.png"   |   Bin 0 -> 5170 bytes
 .../joystick_circle_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_b.png"   |   Bin 0 -> 5170 bytes
 .../joystick_circle_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_c.png"   |   Bin 0 -> 5536 bytes
 .../joystick_circle_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_d.png"   |   Bin 0 -> 4772 bytes
 .../joystick_circle_pad_d.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_a.png"  |   Bin 0 -> 3047 bytes
 .../joystick_hexagon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_b.png"  |   Bin 0 -> 2792 bytes
 .../joystick_hexagon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_c.png"  |   Bin 0 -> 2672 bytes
 .../joystick_hexagon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_a.png"  |   Bin 0 -> 5067 bytes
 .../joystick_hexagon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_b.png"  |   Bin 0 -> 5083 bytes
 .../joystick_hexagon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_c.png"  |   Bin 0 -> 5460 bytes
 .../joystick_hexagon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_d.png"  |   Bin 0 -> 4678 bytes
 .../joystick_hexagon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_a.png"  |   Bin 0 -> 3265 bytes
 .../joystick_polygon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_b.png"  |   Bin 0 -> 3040 bytes
 .../joystick_polygon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_c.png"  |   Bin 0 -> 2915 bytes
 .../joystick_polygon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_a.png"  |   Bin 0 -> 5309 bytes
 .../joystick_polygon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_b.png"  |   Bin 0 -> 5335 bytes
 .../joystick_polygon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_c.png"  |   Bin 0 -> 5684 bytes
 .../joystick_polygon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_d.png"  |   Bin 0 -> 4932 bytes
 .../joystick_polygon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_square_nub_a.png"   |   Bin 0 -> 1171 bytes
 .../joystick_square_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_b.png"   |   Bin 0 -> 931 bytes
 .../joystick_square_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_c.png"   |   Bin 0 -> 811 bytes
 .../joystick_square_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_a.png"   |   Bin 0 -> 1659 bytes
 .../joystick_square_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_b.png"   |   Bin 0 -> 1644 bytes
 .../joystick_square_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_c.png"   |   Bin 0 -> 2060 bytes
 .../joystick_square_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_d.png"   |   Bin 0 -> 1208 bytes
 .../joystick_square_pad_d.png.meta"                |   130 +
 .../NewUI/mobile-controls-1/Sprites/Style B.meta   |     8 +
 .../mobile-controls-1/Sprites/Style B/Default.meta |     8 +
 .../Sprites/Style B/Default/button_bean.png        |   Bin 0 -> 1106 bytes
 .../Sprites/Style B/Default/button_bean.png.meta   |   130 +
 .../Sprites/Style B/Default/button_circle.png      |   Bin 0 -> 1679 bytes
 .../Sprites/Style B/Default/button_circle.png.meta |   130 +
 .../Sprites/Style B/Default/button_circle_wide.png |   Bin 0 -> 1717 bytes
 .../Style B/Default/button_circle_wide.png.meta    |   130 +
 .../Sprites/Style B/Default/button_diamond.png     |   Bin 0 -> 1373 bytes
 .../Style B/Default/button_diamond.png.meta        |   130 +
 .../Style B/Default/button_diamond_wide.png        |   Bin 0 -> 1469 bytes
 .../Style B/Default/button_diamond_wide.png.meta   |   130 +
 .../Sprites/Style B/Default/button_hexagon.png     |   Bin 0 -> 1410 bytes
 .../Style B/Default/button_hexagon.png.meta        |   130 +
 .../Style B/Default/button_hexagon_wide.png        |   Bin 0 -> 1472 bytes
 .../Style B/Default/button_hexagon_wide.png.meta   |   130 +
 .../Sprites/Style B/Default/button_square.png      |   Bin 0 -> 633 bytes
 .../Sprites/Style B/Default/button_square.png.meta |   130 +
 .../Sprites/Style B/Default/button_square_wide.png |   Bin 0 -> 706 bytes
 .../Style B/Default/button_square_wide.png.meta    |   130 +
 .../Sprites/Style B/Default/direction_left.png     |   Bin 0 -> 1278 bytes
 .../Style B/Default/direction_left.png.meta        |   130 +
 .../Sprites/Style B/Default/direction_right.png    |   Bin 0 -> 1279 bytes
 .../Style B/Default/direction_right.png.meta       |   130 +
 .../Sprites/Style B/Default/dpad.png               |   Bin 0 -> 1324 bytes
 .../Sprites/Style B/Default/dpad.png.meta          |   130 +
 .../Sprites/Style B/Default/dpad_element_east.png  |   Bin 0 -> 954 bytes
 .../Style B/Default/dpad_element_east.png.meta     |   130 +
 .../Sprites/Style B/Default/dpad_element_north.png |   Bin 0 -> 864 bytes
 .../Style B/Default/dpad_element_north.png.meta    |   130 +
 .../Sprites/Style B/Default/dpad_element_south.png |   Bin 0 -> 856 bytes
 .../Style B/Default/dpad_element_south.png.meta    |   130 +
 .../Sprites/Style B/Default/dpad_element_west.png  |   Bin 0 -> 996 bytes
 .../Style B/Default/dpad_element_west.png.meta     |   130 +
 .../Sprites/Style B/Default/dpad_separate.png      |   Bin 0 -> 2397 bytes
 .../Sprites/Style B/Default/dpad_separate.png.meta |   130 +
 .../Sprites/Style B/Default/dpad_small.png         |   Bin 0 -> 1234 bytes
 .../Sprites/Style B/Default/dpad_small.png.meta    |   130 +
 .../Style B/Default/joystick_circle_nub_a.png      |   Bin 0 -> 1846 bytes
 .../Style B/Default/joystick_circle_nub_a.png.meta |   130 +
 .../Style B/Default/joystick_circle_nub_b.png      |   Bin 0 -> 1770 bytes
 .../Style B/Default/joystick_circle_nub_b.png.meta |   130 +
 .../Style B/Default/joystick_circle_nub_c.png      |   Bin 0 -> 1727 bytes
 .../Style B/Default/joystick_circle_nub_c.png.meta |   130 +
 .../Style B/Default/joystick_circle_pad_a.png      |   Bin 0 -> 3141 bytes
 .../Style B/Default/joystick_circle_pad_a.png.meta |   130 +
 .../Style B/Default/joystick_circle_pad_b.png      |   Bin 0 -> 3146 bytes
 .../Style B/Default/joystick_circle_pad_b.png.meta |   130 +
 .../Style B/Default/joystick_circle_pad_c.png      |   Bin 0 -> 3334 bytes
 .../Style B/Default/joystick_circle_pad_c.png.meta |   130 +
 .../Style B/Default/joystick_circle_pad_d.png      |   Bin 0 -> 2948 bytes
 .../Style B/Default/joystick_circle_pad_d.png.meta |   130 +
 .../Style B/Default/joystick_hexagon_nub_a.png     |   Bin 0 -> 1790 bytes
 .../Default/joystick_hexagon_nub_a.png.meta        |   130 +
 .../Style B/Default/joystick_hexagon_nub_b.png     |   Bin 0 -> 1704 bytes
 .../Default/joystick_hexagon_nub_b.png.meta        |   130 +
 .../Style B/Default/joystick_hexagon_nub_c.png     |   Bin 0 -> 1665 bytes
 .../Default/joystick_hexagon_nub_c.png.meta        |   130 +
 .../Style B/Default/joystick_hexagon_pad_a.png     |   Bin 0 -> 3157 bytes
 .../Default/joystick_hexagon_pad_a.png.meta        |   130 +
 .../Style B/Default/joystick_hexagon_pad_b.png     |   Bin 0 -> 3162 bytes
 .../Default/joystick_hexagon_pad_b.png.meta        |   130 +
 .../Style B/Default/joystick_hexagon_pad_c.png     |   Bin 0 -> 3344 bytes
 .../Default/joystick_hexagon_pad_c.png.meta        |   130 +
 .../Style B/Default/joystick_hexagon_pad_d.png     |   Bin 0 -> 2963 bytes
 .../Default/joystick_hexagon_pad_d.png.meta        |   130 +
 .../Style B/Default/joystick_polygon_nub_a.png     |   Bin 0 -> 1793 bytes
 .../Default/joystick_polygon_nub_a.png.meta        |   130 +
 .../Style B/Default/joystick_polygon_nub_b.png     |   Bin 0 -> 1716 bytes
 .../Default/joystick_polygon_nub_b.png.meta        |   130 +
 .../Style B/Default/joystick_polygon_nub_c.png     |   Bin 0 -> 1682 bytes
 .../Default/joystick_polygon_nub_c.png.meta        |   130 +
 .../Style B/Default/joystick_polygon_pad_a.png     |   Bin 0 -> 3279 bytes
 .../Default/joystick_polygon_pad_a.png.meta        |   130 +
 .../Style B/Default/joystick_polygon_pad_b.png     |   Bin 0 -> 3290 bytes
 .../Default/joystick_polygon_pad_b.png.meta        |   130 +
 .../Style B/Default/joystick_polygon_pad_c.png     |   Bin 0 -> 3445 bytes
 .../Default/joystick_polygon_pad_c.png.meta        |   130 +
 .../Style B/Default/joystick_polygon_pad_d.png     |   Bin 0 -> 3099 bytes
 .../Default/joystick_polygon_pad_d.png.meta        |   130 +
 .../Style B/Default/joystick_square_nub_a.png      |   Bin 0 -> 825 bytes
 .../Style B/Default/joystick_square_nub_a.png.meta |   130 +
 .../Style B/Default/joystick_square_nub_b.png      |   Bin 0 -> 611 bytes
 .../Style B/Default/joystick_square_nub_b.png.meta |   130 +
 .../Style B/Default/joystick_square_nub_c.png      |   Bin 0 -> 504 bytes
 .../Style B/Default/joystick_square_nub_c.png.meta |   130 +
 .../Style B/Default/joystick_square_pad_a.png      |   Bin 0 -> 1128 bytes
 .../Style B/Default/joystick_square_pad_a.png.meta |   130 +
 .../Style B/Default/joystick_square_pad_b.png      |   Bin 0 -> 1123 bytes
 .../Style B/Default/joystick_square_pad_b.png.meta |   130 +
 .../Style B/Default/joystick_square_pad_c.png      |   Bin 0 -> 1333 bytes
 .../Style B/Default/joystick_square_pad_c.png.meta |   130 +
 .../Style B/Default/joystick_square_pad_d.png      |   Bin 0 -> 897 bytes
 .../Style B/Default/joystick_square_pad_d.png.meta |   130 +
 .../Sprites/Style B/Large (2\303\227).meta"        |     8 +
 .../Style B/Large (2\303\227)/button_bean.png"     |   Bin 0 -> 1959 bytes
 .../Large (2\303\227)/button_bean.png.meta"        |   130 +
 .../Style B/Large (2\303\227)/button_circle.png"   |   Bin 0 -> 2716 bytes
 .../Large (2\303\227)/button_circle.png.meta"      |   130 +
 .../Large (2\303\227)/button_circle_wide.png"      |   Bin 0 -> 2963 bytes
 .../Large (2\303\227)/button_circle_wide.png.meta" |   130 +
 .../Style B/Large (2\303\227)/button_diamond.png"  |   Bin 0 -> 1809 bytes
 .../Large (2\303\227)/button_diamond.png.meta"     |   130 +
 .../Large (2\303\227)/button_diamond_wide.png"     |   Bin 0 -> 2108 bytes
 .../button_diamond_wide.png.meta"                  |   130 +
 .../Style B/Large (2\303\227)/button_hexagon.png"  |   Bin 0 -> 2383 bytes
 .../Large (2\303\227)/button_hexagon.png.meta"     |   130 +
 .../Large (2\303\227)/button_hexagon_wide.png"     |   Bin 0 -> 2495 bytes
 .../button_hexagon_wide.png.meta"                  |   130 +
 .../Style B/Large (2\303\227)/button_square.png"   |   Bin 0 -> 1147 bytes
 .../Large (2\303\227)/button_square.png.meta"      |   130 +
 .../Large (2\303\227)/button_square_wide.png"      |   Bin 0 -> 1185 bytes
 .../Large (2\303\227)/button_square_wide.png.meta" |   130 +
 .../Style B/Large (2\303\227)/direction_left.png"  |   Bin 0 -> 1806 bytes
 .../Large (2\303\227)/direction_left.png.meta"     |   130 +
 .../Style B/Large (2\303\227)/direction_right.png" |   Bin 0 -> 1808 bytes
 .../Large (2\303\227)/direction_right.png.meta"    |   130 +
 .../Sprites/Style B/Large (2\303\227)/dpad.png"    |   Bin 0 -> 2139 bytes
 .../Style B/Large (2\303\227)/dpad.png.meta"       |   130 +
 .../Large (2\303\227)/dpad_element_east.png"       |   Bin 0 -> 1350 bytes
 .../Large (2\303\227)/dpad_element_east.png.meta"  |   130 +
 .../Large (2\303\227)/dpad_element_north.png"      |   Bin 0 -> 1211 bytes
 .../Large (2\303\227)/dpad_element_north.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_south.png"      |   Bin 0 -> 1161 bytes
 .../Large (2\303\227)/dpad_element_south.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_west.png"       |   Bin 0 -> 1389 bytes
 .../Large (2\303\227)/dpad_element_west.png.meta"  |   130 +
 .../Style B/Large (2\303\227)/dpad_separate.png"   |   Bin 0 -> 3832 bytes
 .../Large (2\303\227)/dpad_separate.png.meta"      |   130 +
 .../Style B/Large (2\303\227)/dpad_small.png"      |   Bin 0 -> 1885 bytes
 .../Style B/Large (2\303\227)/dpad_small.png.meta" |   130 +
 .../Large (2\303\227)/joystick_circle_nub_a.png"   |   Bin 0 -> 3081 bytes
 .../joystick_circle_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_b.png"   |   Bin 0 -> 2916 bytes
 .../joystick_circle_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_c.png"   |   Bin 0 -> 2811 bytes
 .../joystick_circle_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_a.png"   |   Bin 0 -> 5241 bytes
 .../joystick_circle_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_b.png"   |   Bin 0 -> 5242 bytes
 .../joystick_circle_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_c.png"   |   Bin 0 -> 5627 bytes
 .../joystick_circle_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_d.png"   |   Bin 0 -> 4839 bytes
 .../joystick_circle_pad_d.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_a.png"  |   Bin 0 -> 3190 bytes
 .../joystick_hexagon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_b.png"  |   Bin 0 -> 3027 bytes
 .../joystick_hexagon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_c.png"  |   Bin 0 -> 2959 bytes
 .../joystick_hexagon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_a.png"  |   Bin 0 -> 5163 bytes
 .../joystick_hexagon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_b.png"  |   Bin 0 -> 5169 bytes
 .../joystick_hexagon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_c.png"  |   Bin 0 -> 5561 bytes
 .../joystick_hexagon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_d.png"  |   Bin 0 -> 4750 bytes
 .../joystick_hexagon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_a.png"  |   Bin 0 -> 3320 bytes
 .../joystick_polygon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_b.png"  |   Bin 0 -> 3155 bytes
 .../joystick_polygon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_c.png"  |   Bin 0 -> 3082 bytes
 .../joystick_polygon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_a.png"  |   Bin 0 -> 5403 bytes
 .../joystick_polygon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_b.png"  |   Bin 0 -> 5441 bytes
 .../joystick_polygon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_c.png"  |   Bin 0 -> 5806 bytes
 .../joystick_polygon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_d.png"  |   Bin 0 -> 5044 bytes
 .../joystick_polygon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_square_nub_a.png"   |   Bin 0 -> 1305 bytes
 .../joystick_square_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_b.png"   |   Bin 0 -> 1092 bytes
 .../joystick_square_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_c.png"   |   Bin 0 -> 989 bytes
 .../joystick_square_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_a.png"   |   Bin 0 -> 1890 bytes
 .../joystick_square_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_b.png"   |   Bin 0 -> 1868 bytes
 .../joystick_square_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_c.png"   |   Bin 0 -> 2311 bytes
 .../joystick_square_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_d.png"   |   Bin 0 -> 1427 bytes
 .../joystick_square_pad_d.png.meta"                |   130 +
 .../NewUI/mobile-controls-1/Sprites/Style C.meta   |     8 +
 .../mobile-controls-1/Sprites/Style C/Default.meta |     8 +
 .../Sprites/Style C/Default/button_bean.png        |   Bin 0 -> 501 bytes
 .../Sprites/Style C/Default/button_bean.png.meta   |   130 +
 .../Sprites/Style C/Default/button_circle.png      |   Bin 0 -> 655 bytes
 .../Sprites/Style C/Default/button_circle.png.meta |   130 +
 .../Sprites/Style C/Default/button_circle_wide.png |   Bin 0 -> 692 bytes
 .../Style C/Default/button_circle_wide.png.meta    |   130 +
 .../Sprites/Style C/Default/button_diamond.png     |   Bin 0 -> 475 bytes
 .../Style C/Default/button_diamond.png.meta        |   130 +
 .../Style C/Default/button_diamond_wide.png        |   Bin 0 -> 499 bytes
 .../Style C/Default/button_diamond_wide.png.meta   |   130 +
 .../Sprites/Style C/Default/button_hexagon.png     |   Bin 0 -> 486 bytes
 .../Style C/Default/button_hexagon.png.meta        |   130 +
 .../Style C/Default/button_hexagon_wide.png        |   Bin 0 -> 547 bytes
 .../Style C/Default/button_hexagon_wide.png.meta   |   130 +
 .../Sprites/Style C/Default/button_square.png      |   Bin 0 -> 293 bytes
 .../Sprites/Style C/Default/button_square.png.meta |   130 +
 .../Sprites/Style C/Default/button_square_wide.png |   Bin 0 -> 308 bytes
 .../Style C/Default/button_square_wide.png.meta    |   130 +
 .../Sprites/Style C/Default/direction_left.png     |   Bin 0 -> 489 bytes
 .../Style C/Default/direction_left.png.meta        |   130 +
 .../Sprites/Style C/Default/direction_right.png    |   Bin 0 -> 468 bytes
 .../Style C/Default/direction_right.png.meta       |   130 +
 .../Sprites/Style C/Default/dpad.png               |   Bin 0 -> 607 bytes
 .../Sprites/Style C/Default/dpad.png.meta          |   130 +
 .../Sprites/Style C/Default/dpad_element_east.png  |   Bin 0 -> 491 bytes
 .../Style C/Default/dpad_element_east.png.meta     |   130 +
 .../Sprites/Style C/Default/dpad_element_north.png |   Bin 0 -> 422 bytes
 .../Style C/Default/dpad_element_north.png.meta    |   130 +
 .../Sprites/Style C/Default/dpad_element_south.png |   Bin 0 -> 424 bytes
 .../Style C/Default/dpad_element_south.png.meta    |   130 +
 .../Sprites/Style C/Default/dpad_element_west.png  |   Bin 0 -> 481 bytes
 .../Style C/Default/dpad_element_west.png.meta     |   130 +
 .../Sprites/Style C/Default/dpad_separate.png      |   Bin 0 -> 936 bytes
 .../Sprites/Style C/Default/dpad_separate.png.meta |   130 +
 .../Sprites/Style C/Default/dpad_small.png         |   Bin 0 -> 560 bytes
 .../Sprites/Style C/Default/dpad_small.png.meta    |   130 +
 .../Style C/Default/joystick_circle_nub_a.png      |   Bin 0 -> 721 bytes
 .../Style C/Default/joystick_circle_nub_a.png.meta |   130 +
 .../Style C/Default/joystick_circle_nub_b.png      |   Bin 0 -> 682 bytes
 .../Style C/Default/joystick_circle_nub_b.png.meta |   130 +
 .../Style C/Default/joystick_circle_nub_c.png      |   Bin 0 -> 662 bytes
 .../Style C/Default/joystick_circle_nub_c.png.meta |   130 +
 .../Style C/Default/joystick_circle_pad_a.png      |   Bin 0 -> 1315 bytes
 .../Style C/Default/joystick_circle_pad_a.png.meta |   130 +
 .../Style C/Default/joystick_circle_pad_b.png      |   Bin 0 -> 1322 bytes
 .../Style C/Default/joystick_circle_pad_b.png.meta |   130 +
 .../Style C/Default/joystick_circle_pad_c.png      |   Bin 0 -> 1441 bytes
 .../Style C/Default/joystick_circle_pad_c.png.meta |   130 +
 .../Style C/Default/joystick_circle_pad_d.png      |   Bin 0 -> 1187 bytes
 .../Style C/Default/joystick_circle_pad_d.png.meta |   130 +
 .../Style C/Default/joystick_hexagon_nub_a.png     |   Bin 0 -> 739 bytes
 .../Default/joystick_hexagon_nub_a.png.meta        |   130 +
 .../Style C/Default/joystick_hexagon_nub_b.png     |   Bin 0 -> 698 bytes
 .../Default/joystick_hexagon_nub_b.png.meta        |   130 +
 .../Style C/Default/joystick_hexagon_nub_c.png     |   Bin 0 -> 678 bytes
 .../Default/joystick_hexagon_nub_c.png.meta        |   130 +
 .../Style C/Default/joystick_hexagon_pad_a.png     |   Bin 0 -> 1321 bytes
 .../Default/joystick_hexagon_pad_a.png.meta        |   130 +
 .../Style C/Default/joystick_hexagon_pad_b.png     |   Bin 0 -> 1321 bytes
 .../Default/joystick_hexagon_pad_b.png.meta        |   130 +
 .../Style C/Default/joystick_hexagon_pad_c.png     |   Bin 0 -> 1444 bytes
 .../Default/joystick_hexagon_pad_c.png.meta        |   130 +
 .../Style C/Default/joystick_hexagon_pad_d.png     |   Bin 0 -> 1187 bytes
 .../Default/joystick_hexagon_pad_d.png.meta        |   130 +
 .../Style C/Default/joystick_polygon_nub_a.png     |   Bin 0 -> 747 bytes
 .../Default/joystick_polygon_nub_a.png.meta        |   130 +
 .../Style C/Default/joystick_polygon_nub_b.png     |   Bin 0 -> 704 bytes
 .../Default/joystick_polygon_nub_b.png.meta        |   130 +
 .../Style C/Default/joystick_polygon_nub_c.png     |   Bin 0 -> 683 bytes
 .../Default/joystick_polygon_nub_c.png.meta        |   130 +
 .../Style C/Default/joystick_polygon_pad_a.png     |   Bin 0 -> 1341 bytes
 .../Default/joystick_polygon_pad_a.png.meta        |   130 +
 .../Style C/Default/joystick_polygon_pad_b.png     |   Bin 0 -> 1358 bytes
 .../Default/joystick_polygon_pad_b.png.meta        |   130 +
 .../Style C/Default/joystick_polygon_pad_c.png     |   Bin 0 -> 1478 bytes
 .../Default/joystick_polygon_pad_c.png.meta        |   130 +
 .../Style C/Default/joystick_polygon_pad_d.png     |   Bin 0 -> 1232 bytes
 .../Default/joystick_polygon_pad_d.png.meta        |   130 +
 .../Style C/Default/joystick_square_nub_a.png      |   Bin 0 -> 309 bytes
 .../Style C/Default/joystick_square_nub_a.png.meta |   130 +
 .../Style C/Default/joystick_square_nub_b.png      |   Bin 0 -> 271 bytes
 .../Style C/Default/joystick_square_nub_b.png.meta |   130 +
 .../Style C/Default/joystick_square_nub_c.png      |   Bin 0 -> 226 bytes
 .../Style C/Default/joystick_square_nub_c.png.meta |   130 +
 .../Style C/Default/joystick_square_pad_a.png      |   Bin 0 -> 494 bytes
 .../Style C/Default/joystick_square_pad_a.png.meta |   130 +
 .../Style C/Default/joystick_square_pad_b.png      |   Bin 0 -> 511 bytes
 .../Style C/Default/joystick_square_pad_b.png.meta |   130 +
 .../Style C/Default/joystick_square_pad_c.png      |   Bin 0 -> 694 bytes
 .../Style C/Default/joystick_square_pad_c.png.meta |   130 +
 .../Style C/Default/joystick_square_pad_d.png      |   Bin 0 -> 302 bytes
 .../Style C/Default/joystick_square_pad_d.png.meta |   130 +
 .../Sprites/Style C/Large (2\303\227).meta"        |     8 +
 .../Style C/Large (2\303\227)/button_bean.png"     |   Bin 0 -> 868 bytes
 .../Large (2\303\227)/button_bean.png.meta"        |   130 +
 .../Style C/Large (2\303\227)/button_circle.png"   |   Bin 0 -> 1167 bytes
 .../Large (2\303\227)/button_circle.png.meta"      |   130 +
 .../Large (2\303\227)/button_circle_wide.png"      |   Bin 0 -> 1288 bytes
 .../Large (2\303\227)/button_circle_wide.png.meta" |   130 +
 .../Style C/Large (2\303\227)/button_diamond.png"  |   Bin 0 -> 780 bytes
 .../Large (2\303\227)/button_diamond.png.meta"     |   130 +
 .../Large (2\303\227)/button_diamond_wide.png"     |   Bin 0 -> 851 bytes
 .../button_diamond_wide.png.meta"                  |   130 +
 .../Style C/Large (2\303\227)/button_hexagon.png"  |   Bin 0 -> 865 bytes
 .../Large (2\303\227)/button_hexagon.png.meta"     |   130 +
 .../Large (2\303\227)/button_hexagon_wide.png"     |   Bin 0 -> 983 bytes
 .../button_hexagon_wide.png.meta"                  |   130 +
 .../Style C/Large (2\303\227)/button_square.png"   |   Bin 0 -> 452 bytes
 .../Large (2\303\227)/button_square.png.meta"      |   130 +
 .../Large (2\303\227)/button_square_wide.png"      |   Bin 0 -> 523 bytes
 .../Large (2\303\227)/button_square_wide.png.meta" |   130 +
 .../Style C/Large (2\303\227)/direction_left.png"  |   Bin 0 -> 823 bytes
 .../Large (2\303\227)/direction_left.png.meta"     |   130 +
 .../Style C/Large (2\303\227)/direction_right.png" |   Bin 0 -> 785 bytes
 .../Large (2\303\227)/direction_right.png.meta"    |   130 +
 .../Sprites/Style C/Large (2\303\227)/dpad.png"    |   Bin 0 -> 1170 bytes
 .../Style C/Large (2\303\227)/dpad.png.meta"       |   130 +
 .../Large (2\303\227)/dpad_element_east.png"       |   Bin 0 -> 839 bytes
 .../Large (2\303\227)/dpad_element_east.png.meta"  |   130 +
 .../Large (2\303\227)/dpad_element_north.png"      |   Bin 0 -> 674 bytes
 .../Large (2\303\227)/dpad_element_north.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_south.png"      |   Bin 0 -> 674 bytes
 .../Large (2\303\227)/dpad_element_south.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_west.png"       |   Bin 0 -> 789 bytes
 .../Large (2\303\227)/dpad_element_west.png.meta"  |   130 +
 .../Style C/Large (2\303\227)/dpad_separate.png"   |   Bin 0 -> 1865 bytes
 .../Large (2\303\227)/dpad_separate.png.meta"      |   130 +
 .../Style C/Large (2\303\227)/dpad_small.png"      |   Bin 0 -> 1016 bytes
 .../Style C/Large (2\303\227)/dpad_small.png.meta" |   130 +
 .../Large (2\303\227)/joystick_circle_nub_a.png"   |   Bin 0 -> 1311 bytes
 .../joystick_circle_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_b.png"   |   Bin 0 -> 1235 bytes
 .../joystick_circle_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_c.png"   |   Bin 0 -> 1185 bytes
 .../joystick_circle_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_a.png"   |   Bin 0 -> 2683 bytes
 .../joystick_circle_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_b.png"   |   Bin 0 -> 2680 bytes
 .../joystick_circle_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_c.png"   |   Bin 0 -> 2970 bytes
 .../joystick_circle_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_d.png"   |   Bin 0 -> 2384 bytes
 .../joystick_circle_pad_d.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_a.png"  |   Bin 0 -> 1314 bytes
 .../joystick_hexagon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_b.png"  |   Bin 0 -> 1244 bytes
 .../joystick_hexagon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_c.png"  |   Bin 0 -> 1198 bytes
 .../joystick_hexagon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_a.png"  |   Bin 0 -> 2615 bytes
 .../joystick_hexagon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_b.png"  |   Bin 0 -> 2614 bytes
 .../joystick_hexagon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_c.png"  |   Bin 0 -> 2912 bytes
 .../joystick_hexagon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_d.png"  |   Bin 0 -> 2320 bytes
 .../joystick_hexagon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_a.png"  |   Bin 0 -> 1348 bytes
 .../joystick_polygon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_b.png"  |   Bin 0 -> 1282 bytes
 .../joystick_polygon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_c.png"  |   Bin 0 -> 1236 bytes
 .../joystick_polygon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_a.png"  |   Bin 0 -> 2615 bytes
 .../joystick_polygon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_b.png"  |   Bin 0 -> 2638 bytes
 .../joystick_polygon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_c.png"  |   Bin 0 -> 2927 bytes
 .../joystick_polygon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_d.png"  |   Bin 0 -> 2374 bytes
 .../joystick_polygon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_square_nub_a.png"   |   Bin 0 -> 451 bytes
 .../joystick_square_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_b.png"   |   Bin 0 -> 386 bytes
 .../joystick_square_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_c.png"   |   Bin 0 -> 302 bytes
 .../joystick_square_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_a.png"   |   Bin 0 -> 1031 bytes
 .../joystick_square_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_b.png"   |   Bin 0 -> 1048 bytes
 .../joystick_square_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_c.png"   |   Bin 0 -> 1399 bytes
 .../joystick_square_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_d.png"   |   Bin 0 -> 671 bytes
 .../joystick_square_pad_d.png.meta"                |   130 +
 .../NewUI/mobile-controls-1/Sprites/Style D.meta   |     8 +
 .../mobile-controls-1/Sprites/Style D/Default.meta |     8 +
 .../Sprites/Style D/Default/button_bean.png        |   Bin 0 -> 501 bytes
 .../Sprites/Style D/Default/button_bean.png.meta   |   130 +
 .../Sprites/Style D/Default/button_circle.png      |   Bin 0 -> 655 bytes
 .../Sprites/Style D/Default/button_circle.png.meta |   130 +
 .../Sprites/Style D/Default/button_circle_wide.png |   Bin 0 -> 692 bytes
 .../Style D/Default/button_circle_wide.png.meta    |   130 +
 .../Sprites/Style D/Default/button_diamond.png     |   Bin 0 -> 475 bytes
 .../Style D/Default/button_diamond.png.meta        |   130 +
 .../Style D/Default/button_diamond_wide.png        |   Bin 0 -> 499 bytes
 .../Style D/Default/button_diamond_wide.png.meta   |   130 +
 .../Sprites/Style D/Default/button_hexagon.png     |   Bin 0 -> 486 bytes
 .../Style D/Default/button_hexagon.png.meta        |   130 +
 .../Style D/Default/button_hexagon_wide.png        |   Bin 0 -> 547 bytes
 .../Style D/Default/button_hexagon_wide.png.meta   |   130 +
 .../Sprites/Style D/Default/button_square.png      |   Bin 0 -> 293 bytes
 .../Sprites/Style D/Default/button_square.png.meta |   130 +
 .../Sprites/Style D/Default/button_square_wide.png |   Bin 0 -> 306 bytes
 .../Style D/Default/button_square_wide.png.meta    |   130 +
 .../Sprites/Style D/Default/direction_left.png     |   Bin 0 -> 489 bytes
 .../Style D/Default/direction_left.png.meta        |   130 +
 .../Sprites/Style D/Default/direction_right.png    |   Bin 0 -> 468 bytes
 .../Style D/Default/direction_right.png.meta       |   130 +
 .../Sprites/Style D/Default/dpad.png               |   Bin 0 -> 607 bytes
 .../Sprites/Style D/Default/dpad.png.meta          |   130 +
 .../Sprites/Style D/Default/dpad_element_east.png  |   Bin 0 -> 491 bytes
 .../Style D/Default/dpad_element_east.png.meta     |   130 +
 .../Sprites/Style D/Default/dpad_element_north.png |   Bin 0 -> 422 bytes
 .../Style D/Default/dpad_element_north.png.meta    |   130 +
 .../Sprites/Style D/Default/dpad_element_south.png |   Bin 0 -> 424 bytes
 .../Style D/Default/dpad_element_south.png.meta    |   130 +
 .../Sprites/Style D/Default/dpad_element_west.png  |   Bin 0 -> 481 bytes
 .../Style D/Default/dpad_element_west.png.meta     |   130 +
 .../Sprites/Style D/Default/dpad_separate.png      |   Bin 0 -> 936 bytes
 .../Sprites/Style D/Default/dpad_separate.png.meta |   130 +
 .../Sprites/Style D/Default/dpad_small.png         |   Bin 0 -> 560 bytes
 .../Sprites/Style D/Default/dpad_small.png.meta    |   130 +
 .../Style D/Default/joystick_circle_nub_a.png      |   Bin 0 -> 721 bytes
 .../Style D/Default/joystick_circle_nub_a.png.meta |   130 +
 .../Style D/Default/joystick_circle_nub_b.png      |   Bin 0 -> 682 bytes
 .../Style D/Default/joystick_circle_nub_b.png.meta |   130 +
 .../Style D/Default/joystick_circle_nub_c.png      |   Bin 0 -> 662 bytes
 .../Style D/Default/joystick_circle_nub_c.png.meta |   130 +
 .../Style D/Default/joystick_circle_pad_a.png      |   Bin 0 -> 1315 bytes
 .../Style D/Default/joystick_circle_pad_a.png.meta |   130 +
 .../Style D/Default/joystick_circle_pad_b.png      |   Bin 0 -> 1322 bytes
 .../Style D/Default/joystick_circle_pad_b.png.meta |   130 +
 .../Style D/Default/joystick_circle_pad_c.png      |   Bin 0 -> 1441 bytes
 .../Style D/Default/joystick_circle_pad_c.png.meta |   130 +
 .../Style D/Default/joystick_circle_pad_d.png      |   Bin 0 -> 1187 bytes
 .../Style D/Default/joystick_circle_pad_d.png.meta |   130 +
 .../Style D/Default/joystick_hexagon_nub_a.png     |   Bin 0 -> 739 bytes
 .../Default/joystick_hexagon_nub_a.png.meta        |   130 +
 .../Style D/Default/joystick_hexagon_nub_b.png     |   Bin 0 -> 698 bytes
 .../Default/joystick_hexagon_nub_b.png.meta        |   130 +
 .../Style D/Default/joystick_hexagon_nub_c.png     |   Bin 0 -> 678 bytes
 .../Default/joystick_hexagon_nub_c.png.meta        |   130 +
 .../Style D/Default/joystick_hexagon_pad_a.png     |   Bin 0 -> 1321 bytes
 .../Default/joystick_hexagon_pad_a.png.meta        |   130 +
 .../Style D/Default/joystick_hexagon_pad_b.png     |   Bin 0 -> 1321 bytes
 .../Default/joystick_hexagon_pad_b.png.meta        |   130 +
 .../Style D/Default/joystick_hexagon_pad_c.png     |   Bin 0 -> 1444 bytes
 .../Default/joystick_hexagon_pad_c.png.meta        |   130 +
 .../Style D/Default/joystick_hexagon_pad_d.png     |   Bin 0 -> 1187 bytes
 .../Default/joystick_hexagon_pad_d.png.meta        |   130 +
 .../Style D/Default/joystick_polygon_nub_a.png     |   Bin 0 -> 747 bytes
 .../Default/joystick_polygon_nub_a.png.meta        |   130 +
 .../Style D/Default/joystick_polygon_nub_b.png     |   Bin 0 -> 704 bytes
 .../Default/joystick_polygon_nub_b.png.meta        |   130 +
 .../Style D/Default/joystick_polygon_nub_c.png     |   Bin 0 -> 683 bytes
 .../Default/joystick_polygon_nub_c.png.meta        |   130 +
 .../Style D/Default/joystick_polygon_pad_a.png     |   Bin 0 -> 1341 bytes
 .../Default/joystick_polygon_pad_a.png.meta        |   130 +
 .../Style D/Default/joystick_polygon_pad_b.png     |   Bin 0 -> 1358 bytes
 .../Default/joystick_polygon_pad_b.png.meta        |   130 +
 .../Style D/Default/joystick_polygon_pad_c.png     |   Bin 0 -> 1478 bytes
 .../Default/joystick_polygon_pad_c.png.meta        |   130 +
 .../Style D/Default/joystick_polygon_pad_d.png     |   Bin 0 -> 1232 bytes
 .../Default/joystick_polygon_pad_d.png.meta        |   130 +
 .../Style D/Default/joystick_square_nub_a.png      |   Bin 0 -> 309 bytes
 .../Style D/Default/joystick_square_nub_a.png.meta |   130 +
 .../Style D/Default/joystick_square_nub_b.png      |   Bin 0 -> 271 bytes
 .../Style D/Default/joystick_square_nub_b.png.meta |   130 +
 .../Style D/Default/joystick_square_nub_c.png      |   Bin 0 -> 226 bytes
 .../Style D/Default/joystick_square_nub_c.png.meta |   130 +
 .../Style D/Default/joystick_square_pad_a.png      |   Bin 0 -> 494 bytes
 .../Style D/Default/joystick_square_pad_a.png.meta |   130 +
 .../Style D/Default/joystick_square_pad_b.png      |   Bin 0 -> 511 bytes
 .../Style D/Default/joystick_square_pad_b.png.meta |   130 +
 .../Style D/Default/joystick_square_pad_c.png      |   Bin 0 -> 694 bytes
 .../Style D/Default/joystick_square_pad_c.png.meta |   130 +
 .../Style D/Default/joystick_square_pad_d.png      |   Bin 0 -> 301 bytes
 .../Style D/Default/joystick_square_pad_d.png.meta |   130 +
 .../Sprites/Style D/Large (2\303\227).meta"        |     8 +
 .../Style D/Large (2\303\227)/button_bean.png"     |   Bin 0 -> 868 bytes
 .../Large (2\303\227)/button_bean.png.meta"        |   130 +
 .../Style D/Large (2\303\227)/button_circle.png"   |   Bin 0 -> 1167 bytes
 .../Large (2\303\227)/button_circle.png.meta"      |   130 +
 .../Large (2\303\227)/button_circle_wide.png"      |   Bin 0 -> 1288 bytes
 .../Large (2\303\227)/button_circle_wide.png.meta" |   130 +
 .../Style D/Large (2\303\227)/button_diamond.png"  |   Bin 0 -> 780 bytes
 .../Large (2\303\227)/button_diamond.png.meta"     |   130 +
 .../Large (2\303\227)/button_diamond_wide.png"     |   Bin 0 -> 851 bytes
 .../button_diamond_wide.png.meta"                  |   130 +
 .../Style D/Large (2\303\227)/button_hexagon.png"  |   Bin 0 -> 865 bytes
 .../Large (2\303\227)/button_hexagon.png.meta"     |   130 +
 .../Large (2\303\227)/button_hexagon_wide.png"     |   Bin 0 -> 983 bytes
 .../button_hexagon_wide.png.meta"                  |   130 +
 .../Style D/Large (2\303\227)/button_square.png"   |   Bin 0 -> 452 bytes
 .../Large (2\303\227)/button_square.png.meta"      |   130 +
 .../Large (2\303\227)/button_square_wide.png"      |   Bin 0 -> 523 bytes
 .../Large (2\303\227)/button_square_wide.png.meta" |   130 +
 .../Style D/Large (2\303\227)/direction_left.png"  |   Bin 0 -> 823 bytes
 .../Large (2\303\227)/direction_left.png.meta"     |   130 +
 .../Style D/Large (2\303\227)/direction_right.png" |   Bin 0 -> 785 bytes
 .../Large (2\303\227)/direction_right.png.meta"    |   130 +
 .../Sprites/Style D/Large (2\303\227)/dpad.png"    |   Bin 0 -> 1170 bytes
 .../Style D/Large (2\303\227)/dpad.png.meta"       |   130 +
 .../Large (2\303\227)/dpad_element_east.png"       |   Bin 0 -> 839 bytes
 .../Large (2\303\227)/dpad_element_east.png.meta"  |   130 +
 .../Large (2\303\227)/dpad_element_north.png"      |   Bin 0 -> 675 bytes
 .../Large (2\303\227)/dpad_element_north.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_south.png"      |   Bin 0 -> 674 bytes
 .../Large (2\303\227)/dpad_element_south.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_west.png"       |   Bin 0 -> 788 bytes
 .../Large (2\303\227)/dpad_element_west.png.meta"  |   130 +
 .../Style D/Large (2\303\227)/dpad_separate.png"   |   Bin 0 -> 1865 bytes
 .../Large (2\303\227)/dpad_separate.png.meta"      |   130 +
 .../Style D/Large (2\303\227)/dpad_small.png"      |   Bin 0 -> 1016 bytes
 .../Style D/Large (2\303\227)/dpad_small.png.meta" |   130 +
 .../Large (2\303\227)/joystick_circle_nub_a.png"   |   Bin 0 -> 1311 bytes
 .../joystick_circle_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_b.png"   |   Bin 0 -> 1235 bytes
 .../joystick_circle_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_c.png"   |   Bin 0 -> 1185 bytes
 .../joystick_circle_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_a.png"   |   Bin 0 -> 2683 bytes
 .../joystick_circle_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_b.png"   |   Bin 0 -> 2680 bytes
 .../joystick_circle_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_c.png"   |   Bin 0 -> 2970 bytes
 .../joystick_circle_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_d.png"   |   Bin 0 -> 2384 bytes
 .../joystick_circle_pad_d.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_a.png"  |   Bin 0 -> 1314 bytes
 .../joystick_hexagon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_b.png"  |   Bin 0 -> 1244 bytes
 .../joystick_hexagon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_c.png"  |   Bin 0 -> 1198 bytes
 .../joystick_hexagon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_a.png"  |   Bin 0 -> 2615 bytes
 .../joystick_hexagon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_b.png"  |   Bin 0 -> 2614 bytes
 .../joystick_hexagon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_c.png"  |   Bin 0 -> 2912 bytes
 .../joystick_hexagon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_d.png"  |   Bin 0 -> 2320 bytes
 .../joystick_hexagon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_a.png"  |   Bin 0 -> 1348 bytes
 .../joystick_polygon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_b.png"  |   Bin 0 -> 1282 bytes
 .../joystick_polygon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_c.png"  |   Bin 0 -> 1236 bytes
 .../joystick_polygon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_a.png"  |   Bin 0 -> 2615 bytes
 .../joystick_polygon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_b.png"  |   Bin 0 -> 2638 bytes
 .../joystick_polygon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_c.png"  |   Bin 0 -> 2927 bytes
 .../joystick_polygon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_d.png"  |   Bin 0 -> 2374 bytes
 .../joystick_polygon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_square_nub_a.png"   |   Bin 0 -> 451 bytes
 .../joystick_square_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_b.png"   |   Bin 0 -> 387 bytes
 .../joystick_square_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_c.png"   |   Bin 0 -> 301 bytes
 .../joystick_square_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_a.png"   |   Bin 0 -> 1031 bytes
 .../joystick_square_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_b.png"   |   Bin 0 -> 1048 bytes
 .../joystick_square_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_c.png"   |   Bin 0 -> 1399 bytes
 .../joystick_square_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_d.png"   |   Bin 0 -> 671 bytes
 .../joystick_square_pad_d.png.meta"                |   130 +
 .../NewUI/mobile-controls-1/Sprites/Style E.meta   |     8 +
 .../mobile-controls-1/Sprites/Style E/Default.meta |     8 +
 .../Sprites/Style E/Default/button_bean.png        |   Bin 0 -> 699 bytes
 .../Sprites/Style E/Default/button_bean.png.meta   |   130 +
 .../Sprites/Style E/Default/button_circle.png      |   Bin 0 -> 866 bytes
 .../Sprites/Style E/Default/button_circle.png.meta |   130 +
 .../Sprites/Style E/Default/button_circle_wide.png |   Bin 0 -> 907 bytes
 .../Style E/Default/button_circle_wide.png.meta    |   130 +
 .../Sprites/Style E/Default/button_diamond.png     |   Bin 0 -> 482 bytes
 .../Style E/Default/button_diamond.png.meta        |   130 +
 .../Style E/Default/button_diamond_wide.png        |   Bin 0 -> 534 bytes
 .../Style E/Default/button_diamond_wide.png.meta   |   130 +
 .../Sprites/Style E/Default/button_hexagon.png     |   Bin 0 -> 653 bytes
 .../Style E/Default/button_hexagon.png.meta        |   130 +
 .../Style E/Default/button_hexagon_wide.png        |   Bin 0 -> 722 bytes
 .../Style E/Default/button_hexagon_wide.png.meta   |   130 +
 .../Sprites/Style E/Default/button_square.png      |   Bin 0 -> 350 bytes
 .../Sprites/Style E/Default/button_square.png.meta |   130 +
 .../Sprites/Style E/Default/button_square_wide.png |   Bin 0 -> 373 bytes
 .../Style E/Default/button_square_wide.png.meta    |   130 +
 .../Sprites/Style E/Default/direction_left.png     |   Bin 0 -> 561 bytes
 .../Style E/Default/direction_left.png.meta        |   130 +
 .../Sprites/Style E/Default/direction_right.png    |   Bin 0 -> 539 bytes
 .../Style E/Default/direction_right.png.meta       |   130 +
 .../Sprites/Style E/Default/dpad.png               |   Bin 0 -> 715 bytes
 .../Sprites/Style E/Default/dpad.png.meta          |   130 +
 .../Sprites/Style E/Default/dpad_element_east.png  |   Bin 0 -> 563 bytes
 .../Style E/Default/dpad_element_east.png.meta     |   130 +
 .../Sprites/Style E/Default/dpad_element_north.png |   Bin 0 -> 493 bytes
 .../Style E/Default/dpad_element_north.png.meta    |   130 +
 .../Sprites/Style E/Default/dpad_element_south.png |   Bin 0 -> 493 bytes
 .../Style E/Default/dpad_element_south.png.meta    |   130 +
 .../Sprites/Style E/Default/dpad_element_west.png  |   Bin 0 -> 536 bytes
 .../Style E/Default/dpad_element_west.png.meta     |   130 +
 .../Sprites/Style E/Default/dpad_separate.png      |   Bin 0 -> 1119 bytes
 .../Sprites/Style E/Default/dpad_separate.png.meta |   130 +
 .../Sprites/Style E/Default/dpad_small.png         |   Bin 0 -> 670 bytes
 .../Sprites/Style E/Default/dpad_small.png.meta    |   130 +
 .../Style E/Default/joystick_circle_nub_a.png      |   Bin 0 -> 894 bytes
 .../Style E/Default/joystick_circle_nub_a.png.meta |   130 +
 .../Style E/Default/joystick_circle_nub_b.png      |   Bin 0 -> 842 bytes
 .../Style E/Default/joystick_circle_nub_b.png.meta |   130 +
 .../Style E/Default/joystick_circle_nub_c.png      |   Bin 0 -> 785 bytes
 .../Style E/Default/joystick_circle_nub_c.png.meta |   130 +
 .../Style E/Default/joystick_circle_pad_a.png      |   Bin 0 -> 1826 bytes
 .../Style E/Default/joystick_circle_pad_a.png.meta |   130 +
 .../Style E/Default/joystick_circle_pad_b.png      |   Bin 0 -> 1833 bytes
 .../Style E/Default/joystick_circle_pad_b.png.meta |   130 +
 .../Style E/Default/joystick_circle_pad_c.png      |   Bin 0 -> 1999 bytes
 .../Style E/Default/joystick_circle_pad_c.png.meta |   130 +
 .../Style E/Default/joystick_circle_pad_d.png      |   Bin 0 -> 1606 bytes
 .../Style E/Default/joystick_circle_pad_d.png.meta |   130 +
 .../Style E/Default/joystick_hexagon_nub_a.png     |   Bin 0 -> 910 bytes
 .../Default/joystick_hexagon_nub_a.png.meta        |   130 +
 .../Style E/Default/joystick_hexagon_nub_b.png     |   Bin 0 -> 853 bytes
 .../Default/joystick_hexagon_nub_b.png.meta        |   130 +
 .../Style E/Default/joystick_hexagon_nub_c.png     |   Bin 0 -> 794 bytes
 .../Default/joystick_hexagon_nub_c.png.meta        |   130 +
 .../Style E/Default/joystick_hexagon_pad_a.png     |   Bin 0 -> 1864 bytes
 .../Default/joystick_hexagon_pad_a.png.meta        |   130 +
 .../Style E/Default/joystick_hexagon_pad_b.png     |   Bin 0 -> 1879 bytes
 .../Default/joystick_hexagon_pad_b.png.meta        |   130 +
 .../Style E/Default/joystick_hexagon_pad_c.png     |   Bin 0 -> 2034 bytes
 .../Default/joystick_hexagon_pad_c.png.meta        |   130 +
 .../Style E/Default/joystick_hexagon_pad_d.png     |   Bin 0 -> 1645 bytes
 .../Default/joystick_hexagon_pad_d.png.meta        |   130 +
 .../Style E/Default/joystick_polygon_nub_a.png     |   Bin 0 -> 929 bytes
 .../Default/joystick_polygon_nub_a.png.meta        |   130 +
 .../Style E/Default/joystick_polygon_nub_b.png     |   Bin 0 -> 887 bytes
 .../Default/joystick_polygon_nub_b.png.meta        |   130 +
 .../Style E/Default/joystick_polygon_nub_c.png     |   Bin 0 -> 828 bytes
 .../Default/joystick_polygon_nub_c.png.meta        |   130 +
 .../Style E/Default/joystick_polygon_pad_a.png     |   Bin 0 -> 1893 bytes
 .../Default/joystick_polygon_pad_a.png.meta        |   130 +
 .../Style E/Default/joystick_polygon_pad_b.png     |   Bin 0 -> 1902 bytes
 .../Default/joystick_polygon_pad_b.png.meta        |   130 +
 .../Style E/Default/joystick_polygon_pad_c.png     |   Bin 0 -> 2058 bytes
 .../Default/joystick_polygon_pad_c.png.meta        |   130 +
 .../Style E/Default/joystick_polygon_pad_d.png     |   Bin 0 -> 1675 bytes
 .../Default/joystick_polygon_pad_d.png.meta        |   130 +
 .../Style E/Default/joystick_square_nub_a.png      |   Bin 0 -> 358 bytes
 .../Style E/Default/joystick_square_nub_a.png.meta |   130 +
 .../Style E/Default/joystick_square_nub_b.png      |   Bin 0 -> 315 bytes
 .../Style E/Default/joystick_square_nub_b.png.meta |   130 +
 .../Style E/Default/joystick_square_nub_c.png      |   Bin 0 -> 239 bytes
 .../Style E/Default/joystick_square_nub_c.png.meta |   130 +
 .../Style E/Default/joystick_square_pad_a.png      |   Bin 0 -> 608 bytes
 .../Style E/Default/joystick_square_pad_a.png.meta |   130 +
 .../Style E/Default/joystick_square_pad_b.png      |   Bin 0 -> 616 bytes
 .../Style E/Default/joystick_square_pad_b.png.meta |   130 +
 .../Style E/Default/joystick_square_pad_c.png      |   Bin 0 -> 797 bytes
 .../Style E/Default/joystick_square_pad_c.png.meta |   130 +
 .../Style E/Default/joystick_square_pad_d.png      |   Bin 0 -> 383 bytes
 .../Style E/Default/joystick_square_pad_d.png.meta |   130 +
 .../Sprites/Style E/Large (2\303\227).meta"        |     8 +
 .../Style E/Large (2\303\227)/button_bean.png"     |   Bin 0 -> 1164 bytes
 .../Large (2\303\227)/button_bean.png.meta"        |   130 +
 .../Style E/Large (2\303\227)/button_circle.png"   |   Bin 0 -> 1465 bytes
 .../Large (2\303\227)/button_circle.png.meta"      |   130 +
 .../Large (2\303\227)/button_circle_wide.png"      |   Bin 0 -> 1622 bytes
 .../Large (2\303\227)/button_circle_wide.png.meta" |   130 +
 .../Style E/Large (2\303\227)/button_diamond.png"  |   Bin 0 -> 801 bytes
 .../Large (2\303\227)/button_diamond.png.meta"     |   130 +
 .../Large (2\303\227)/button_diamond_wide.png"     |   Bin 0 -> 897 bytes
 .../button_diamond_wide.png.meta"                  |   130 +
 .../Style E/Large (2\303\227)/button_hexagon.png"  |   Bin 0 -> 1086 bytes
 .../Large (2\303\227)/button_hexagon.png.meta"     |   130 +
 .../Large (2\303\227)/button_hexagon_wide.png"     |   Bin 0 -> 1204 bytes
 .../button_hexagon_wide.png.meta"                  |   130 +
 .../Style E/Large (2\303\227)/button_square.png"   |   Bin 0 -> 549 bytes
 .../Large (2\303\227)/button_square.png.meta"      |   130 +
 .../Large (2\303\227)/button_square_wide.png"      |   Bin 0 -> 622 bytes
 .../Large (2\303\227)/button_square_wide.png.meta" |   130 +
 .../Style E/Large (2\303\227)/direction_left.png"  |   Bin 0 -> 893 bytes
 .../Large (2\303\227)/direction_left.png.meta"     |   130 +
 .../Style E/Large (2\303\227)/direction_right.png" |   Bin 0 -> 844 bytes
 .../Large (2\303\227)/direction_right.png.meta"    |   130 +
 .../Sprites/Style E/Large (2\303\227)/dpad.png"    |   Bin 0 -> 1320 bytes
 .../Style E/Large (2\303\227)/dpad.png.meta"       |   130 +
 .../Large (2\303\227)/dpad_element_east.png"       |   Bin 0 -> 944 bytes
 .../Large (2\303\227)/dpad_element_east.png.meta"  |   130 +
 .../Large (2\303\227)/dpad_element_north.png"      |   Bin 0 -> 759 bytes
 .../Large (2\303\227)/dpad_element_north.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_south.png"      |   Bin 0 -> 768 bytes
 .../Large (2\303\227)/dpad_element_south.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_west.png"       |   Bin 0 -> 880 bytes
 .../Large (2\303\227)/dpad_element_west.png.meta"  |   130 +
 .../Style E/Large (2\303\227)/dpad_separate.png"   |   Bin 0 -> 2070 bytes
 .../Large (2\303\227)/dpad_separate.png.meta"      |   130 +
 .../Style E/Large (2\303\227)/dpad_small.png"      |   Bin 0 -> 1166 bytes
 .../Style E/Large (2\303\227)/dpad_small.png.meta" |   130 +
 .../Large (2\303\227)/joystick_circle_nub_a.png"   |   Bin 0 -> 1585 bytes
 .../joystick_circle_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_b.png"   |   Bin 0 -> 1495 bytes
 .../joystick_circle_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_c.png"   |   Bin 0 -> 1395 bytes
 .../joystick_circle_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_a.png"   |   Bin 0 -> 3568 bytes
 .../joystick_circle_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_b.png"   |   Bin 0 -> 3595 bytes
 .../joystick_circle_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_c.png"   |   Bin 0 -> 3931 bytes
 .../joystick_circle_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_d.png"   |   Bin 0 -> 3152 bytes
 .../joystick_circle_pad_d.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_a.png"  |   Bin 0 -> 1610 bytes
 .../joystick_hexagon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_b.png"  |   Bin 0 -> 1512 bytes
 .../joystick_hexagon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_c.png"  |   Bin 0 -> 1415 bytes
 .../joystick_hexagon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_a.png"  |   Bin 0 -> 3480 bytes
 .../joystick_hexagon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_b.png"  |   Bin 0 -> 3523 bytes
 .../joystick_hexagon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_c.png"  |   Bin 0 -> 3856 bytes
 .../joystick_hexagon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_d.png"  |   Bin 0 -> 3068 bytes
 .../joystick_hexagon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_a.png"  |   Bin 0 -> 1710 bytes
 .../joystick_polygon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_b.png"  |   Bin 0 -> 1616 bytes
 .../joystick_polygon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_c.png"  |   Bin 0 -> 1526 bytes
 .../joystick_polygon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_a.png"  |   Bin 0 -> 3590 bytes
 .../joystick_polygon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_b.png"  |   Bin 0 -> 3625 bytes
 .../joystick_polygon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_c.png"  |   Bin 0 -> 3950 bytes
 .../joystick_polygon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_d.png"  |   Bin 0 -> 3185 bytes
 .../joystick_polygon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_square_nub_a.png"   |   Bin 0 -> 558 bytes
 .../joystick_square_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_b.png"   |   Bin 0 -> 473 bytes
 .../joystick_square_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_c.png"   |   Bin 0 -> 374 bytes
 .../joystick_square_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_a.png"   |   Bin 0 -> 1207 bytes
 .../joystick_square_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_b.png"   |   Bin 0 -> 1217 bytes
 .../joystick_square_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_c.png"   |   Bin 0 -> 1595 bytes
 .../joystick_square_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_d.png"   |   Bin 0 -> 774 bytes
 .../joystick_square_pad_d.png.meta"                |   130 +
 .../NewUI/mobile-controls-1/Sprites/Style F.meta   |     8 +
 .../mobile-controls-1/Sprites/Style F/Default.meta |     8 +
 .../Sprites/Style F/Default/button_bean.png        |   Bin 0 -> 747 bytes
 .../Sprites/Style F/Default/button_bean.png.meta   |   130 +
 .../Sprites/Style F/Default/button_circle.png      |   Bin 0 -> 948 bytes
 .../Sprites/Style F/Default/button_circle.png.meta |   130 +
 .../Sprites/Style F/Default/button_circle_wide.png |   Bin 0 -> 992 bytes
 .../Style F/Default/button_circle_wide.png.meta    |   130 +
 .../Sprites/Style F/Default/button_diamond.png     |   Bin 0 -> 499 bytes
 .../Style F/Default/button_diamond.png.meta        |   130 +
 .../Style F/Default/button_diamond_wide.png        |   Bin 0 -> 548 bytes
 .../Style F/Default/button_diamond_wide.png.meta   |   130 +
 .../Sprites/Style F/Default/button_hexagon.png     |   Bin 0 -> 693 bytes
 .../Style F/Default/button_hexagon.png.meta        |   130 +
 .../Style F/Default/button_hexagon_wide.png        |   Bin 0 -> 757 bytes
 .../Style F/Default/button_hexagon_wide.png.meta   |   130 +
 .../Sprites/Style F/Default/button_square.png      |   Bin 0 -> 354 bytes
 .../Sprites/Style F/Default/button_square.png.meta |   130 +
 .../Sprites/Style F/Default/button_square_wide.png |   Bin 0 -> 377 bytes
 .../Style F/Default/button_square_wide.png.meta    |   130 +
 .../Sprites/Style F/Default/direction_left.png     |   Bin 0 -> 575 bytes
 .../Style F/Default/direction_left.png.meta        |   130 +
 .../Sprites/Style F/Default/direction_right.png    |   Bin 0 -> 557 bytes
 .../Style F/Default/direction_right.png.meta       |   130 +
 .../Sprites/Style F/Default/dpad.png               |   Bin 0 -> 689 bytes
 .../Sprites/Style F/Default/dpad.png.meta          |   130 +
 .../Sprites/Style F/Default/dpad_element_east.png  |   Bin 0 -> 566 bytes
 .../Style F/Default/dpad_element_east.png.meta     |   130 +
 .../Sprites/Style F/Default/dpad_element_north.png |   Bin 0 -> 502 bytes
 .../Style F/Default/dpad_element_north.png.meta    |   130 +
 .../Sprites/Style F/Default/dpad_element_south.png |   Bin 0 -> 496 bytes
 .../Style F/Default/dpad_element_south.png.meta    |   130 +
 .../Sprites/Style F/Default/dpad_element_west.png  |   Bin 0 -> 545 bytes
 .../Style F/Default/dpad_element_west.png.meta     |   130 +
 .../Sprites/Style F/Default/dpad_separate.png      |   Bin 0 -> 1131 bytes
 .../Sprites/Style F/Default/dpad_separate.png.meta |   130 +
 .../Sprites/Style F/Default/dpad_small.png         |   Bin 0 -> 646 bytes
 .../Sprites/Style F/Default/dpad_small.png.meta    |   130 +
 .../Style F/Default/joystick_circle_nub_a.png      |   Bin 0 -> 903 bytes
 .../Style F/Default/joystick_circle_nub_a.png.meta |   130 +
 .../Style F/Default/joystick_circle_nub_b.png      |   Bin 0 -> 862 bytes
 .../Style F/Default/joystick_circle_nub_b.png.meta |   130 +
 .../Style F/Default/joystick_circle_nub_c.png      |   Bin 0 -> 834 bytes
 .../Style F/Default/joystick_circle_nub_c.png.meta |   130 +
 .../Style F/Default/joystick_circle_pad_a.png      |   Bin 0 -> 1922 bytes
 .../Style F/Default/joystick_circle_pad_a.png.meta |   130 +
 .../Style F/Default/joystick_circle_pad_b.png      |   Bin 0 -> 1926 bytes
 .../Style F/Default/joystick_circle_pad_b.png.meta |   130 +
 .../Style F/Default/joystick_circle_pad_c.png      |   Bin 0 -> 2093 bytes
 .../Style F/Default/joystick_circle_pad_c.png.meta |   130 +
 .../Style F/Default/joystick_circle_pad_d.png      |   Bin 0 -> 1681 bytes
 .../Style F/Default/joystick_circle_pad_d.png.meta |   130 +
 .../Style F/Default/joystick_hexagon_nub_a.png     |   Bin 0 -> 919 bytes
 .../Default/joystick_hexagon_nub_a.png.meta        |   130 +
 .../Style F/Default/joystick_hexagon_nub_b.png     |   Bin 0 -> 870 bytes
 .../Default/joystick_hexagon_nub_b.png.meta        |   130 +
 .../Style F/Default/joystick_hexagon_nub_c.png     |   Bin 0 -> 846 bytes
 .../Default/joystick_hexagon_nub_c.png.meta        |   130 +
 .../Style F/Default/joystick_hexagon_pad_a.png     |   Bin 0 -> 1918 bytes
 .../Default/joystick_hexagon_pad_a.png.meta        |   130 +
 .../Style F/Default/joystick_hexagon_pad_b.png     |   Bin 0 -> 1926 bytes
 .../Default/joystick_hexagon_pad_b.png.meta        |   130 +
 .../Style F/Default/joystick_hexagon_pad_c.png     |   Bin 0 -> 2088 bytes
 .../Default/joystick_hexagon_pad_c.png.meta        |   130 +
 .../Style F/Default/joystick_hexagon_pad_d.png     |   Bin 0 -> 1680 bytes
 .../Default/joystick_hexagon_pad_d.png.meta        |   130 +
 .../Style F/Default/joystick_polygon_nub_a.png     |   Bin 0 -> 927 bytes
 .../Default/joystick_polygon_nub_a.png.meta        |   130 +
 .../Style F/Default/joystick_polygon_nub_b.png     |   Bin 0 -> 891 bytes
 .../Default/joystick_polygon_nub_b.png.meta        |   130 +
 .../Style F/Default/joystick_polygon_nub_c.png     |   Bin 0 -> 868 bytes
 .../Default/joystick_polygon_nub_c.png.meta        |   130 +
 .../Style F/Default/joystick_polygon_pad_a.png     |   Bin 0 -> 1942 bytes
 .../Default/joystick_polygon_pad_a.png.meta        |   130 +
 .../Style F/Default/joystick_polygon_pad_b.png     |   Bin 0 -> 1957 bytes
 .../Default/joystick_polygon_pad_b.png.meta        |   130 +
 .../Style F/Default/joystick_polygon_pad_c.png     |   Bin 0 -> 2112 bytes
 .../Default/joystick_polygon_pad_c.png.meta        |   130 +
 .../Style F/Default/joystick_polygon_pad_d.png     |   Bin 0 -> 1711 bytes
 .../Default/joystick_polygon_pad_d.png.meta        |   130 +
 .../Style F/Default/joystick_square_nub_a.png      |   Bin 0 -> 343 bytes
 .../Style F/Default/joystick_square_nub_a.png.meta |   130 +
 .../Style F/Default/joystick_square_nub_b.png      |   Bin 0 -> 301 bytes
 .../Style F/Default/joystick_square_nub_b.png.meta |   130 +
 .../Style F/Default/joystick_square_nub_c.png      |   Bin 0 -> 242 bytes
 .../Style F/Default/joystick_square_nub_c.png.meta |   130 +
 .../Style F/Default/joystick_square_pad_a.png      |   Bin 0 -> 618 bytes
 .../Style F/Default/joystick_square_pad_a.png.meta |   130 +
 .../Style F/Default/joystick_square_pad_b.png      |   Bin 0 -> 623 bytes
 .../Style F/Default/joystick_square_pad_b.png.meta |   130 +
 .../Style F/Default/joystick_square_pad_c.png      |   Bin 0 -> 806 bytes
 .../Style F/Default/joystick_square_pad_c.png.meta |   130 +
 .../Style F/Default/joystick_square_pad_d.png      |   Bin 0 -> 390 bytes
 .../Style F/Default/joystick_square_pad_d.png.meta |   130 +
 .../Sprites/Style F/Large (2\303\227).meta"        |     8 +
 .../Style F/Large (2\303\227)/button_bean.png"     |   Bin 0 -> 1231 bytes
 .../Large (2\303\227)/button_bean.png.meta"        |   130 +
 .../Style F/Large (2\303\227)/button_circle.png"   |   Bin 0 -> 1564 bytes
 .../Large (2\303\227)/button_circle.png.meta"      |   130 +
 .../Large (2\303\227)/button_circle_wide.png"      |   Bin 0 -> 1737 bytes
 .../Large (2\303\227)/button_circle_wide.png.meta" |   130 +
 .../Style F/Large (2\303\227)/button_diamond.png"  |   Bin 0 -> 809 bytes
 .../Large (2\303\227)/button_diamond.png.meta"     |   130 +
 .../Large (2\303\227)/button_diamond_wide.png"     |   Bin 0 -> 913 bytes
 .../button_diamond_wide.png.meta"                  |   130 +
 .../Style F/Large (2\303\227)/button_hexagon.png"  |   Bin 0 -> 1149 bytes
 .../Large (2\303\227)/button_hexagon.png.meta"     |   130 +
 .../Large (2\303\227)/button_hexagon_wide.png"     |   Bin 0 -> 1271 bytes
 .../button_hexagon_wide.png.meta"                  |   130 +
 .../Style F/Large (2\303\227)/button_square.png"   |   Bin 0 -> 572 bytes
 .../Large (2\303\227)/button_square.png.meta"      |   130 +
 .../Large (2\303\227)/button_square_wide.png"      |   Bin 0 -> 643 bytes
 .../Large (2\303\227)/button_square_wide.png.meta" |   130 +
 .../Style F/Large (2\303\227)/direction_left.png"  |   Bin 0 -> 913 bytes
 .../Large (2\303\227)/direction_left.png.meta"     |   130 +
 .../Style F/Large (2\303\227)/direction_right.png" |   Bin 0 -> 865 bytes
 .../Large (2\303\227)/direction_right.png.meta"    |   130 +
 .../Sprites/Style F/Large (2\303\227)/dpad.png"    |   Bin 0 -> 1279 bytes
 .../Style F/Large (2\303\227)/dpad.png.meta"       |   130 +
 .../Large (2\303\227)/dpad_element_east.png"       |   Bin 0 -> 948 bytes
 .../Large (2\303\227)/dpad_element_east.png.meta"  |   130 +
 .../Large (2\303\227)/dpad_element_north.png"      |   Bin 0 -> 767 bytes
 .../Large (2\303\227)/dpad_element_north.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_south.png"      |   Bin 0 -> 770 bytes
 .../Large (2\303\227)/dpad_element_south.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_west.png"       |   Bin 0 -> 886 bytes
 .../Large (2\303\227)/dpad_element_west.png.meta"  |   130 +
 .../Style F/Large (2\303\227)/dpad_separate.png"   |   Bin 0 -> 2079 bytes
 .../Large (2\303\227)/dpad_separate.png.meta"      |   130 +
 .../Style F/Large (2\303\227)/dpad_small.png"      |   Bin 0 -> 1122 bytes
 .../Style F/Large (2\303\227)/dpad_small.png.meta" |   130 +
 .../Large (2\303\227)/joystick_circle_nub_a.png"   |   Bin 0 -> 1605 bytes
 .../joystick_circle_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_b.png"   |   Bin 0 -> 1533 bytes
 .../joystick_circle_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_c.png"   |   Bin 0 -> 1475 bytes
 .../joystick_circle_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_a.png"   |   Bin 0 -> 3662 bytes
 .../joystick_circle_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_b.png"   |   Bin 0 -> 3696 bytes
 .../joystick_circle_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_c.png"   |   Bin 0 -> 4041 bytes
 .../joystick_circle_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_d.png"   |   Bin 0 -> 3232 bytes
 .../joystick_circle_pad_d.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_a.png"  |   Bin 0 -> 1636 bytes
 .../joystick_hexagon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_b.png"  |   Bin 0 -> 1548 bytes
 .../joystick_hexagon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_c.png"  |   Bin 0 -> 1494 bytes
 .../joystick_hexagon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_a.png"  |   Bin 0 -> 3532 bytes
 .../joystick_hexagon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_b.png"  |   Bin 0 -> 3582 bytes
 .../joystick_hexagon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_c.png"  |   Bin 0 -> 3920 bytes
 .../joystick_hexagon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_d.png"  |   Bin 0 -> 3105 bytes
 .../joystick_hexagon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_a.png"  |   Bin 0 -> 1732 bytes
 .../joystick_polygon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_b.png"  |   Bin 0 -> 1643 bytes
 .../joystick_polygon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_c.png"  |   Bin 0 -> 1597 bytes
 .../joystick_polygon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_a.png"  |   Bin 0 -> 3659 bytes
 .../joystick_polygon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_b.png"  |   Bin 0 -> 3701 bytes
 .../joystick_polygon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_c.png"  |   Bin 0 -> 4030 bytes
 .../joystick_polygon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_d.png"  |   Bin 0 -> 3240 bytes
 .../joystick_polygon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_square_nub_a.png"   |   Bin 0 -> 538 bytes
 .../joystick_square_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_b.png"   |   Bin 0 -> 456 bytes
 .../joystick_square_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_c.png"   |   Bin 0 -> 379 bytes
 .../joystick_square_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_a.png"   |   Bin 0 -> 1218 bytes
 .../joystick_square_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_b.png"   |   Bin 0 -> 1230 bytes
 .../joystick_square_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_c.png"   |   Bin 0 -> 1608 bytes
 .../joystick_square_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_d.png"   |   Bin 0 -> 782 bytes
 .../joystick_square_pad_d.png.meta"                |   130 +
 .../NewUI/mobile-controls-1/Sprites/Style G.meta   |     8 +
 .../mobile-controls-1/Sprites/Style G/Default.meta |     8 +
 .../Sprites/Style G/Default/button_bean.png        |   Bin 0 -> 873 bytes
 .../Sprites/Style G/Default/button_bean.png.meta   |   130 +
 .../Sprites/Style G/Default/button_circle.png      |   Bin 0 -> 1186 bytes
 .../Sprites/Style G/Default/button_circle.png.meta |   130 +
 .../Sprites/Style G/Default/button_circle_wide.png |   Bin 0 -> 1262 bytes
 .../Style G/Default/button_circle_wide.png.meta    |   130 +
 .../Sprites/Style G/Default/button_diamond.png     |   Bin 0 -> 514 bytes
 .../Style G/Default/button_diamond.png.meta        |   130 +
 .../Style G/Default/button_diamond_wide.png        |   Bin 0 -> 630 bytes
 .../Style G/Default/button_diamond_wide.png.meta   |   130 +
 .../Sprites/Style G/Default/button_hexagon.png     |   Bin 0 -> 786 bytes
 .../Style G/Default/button_hexagon.png.meta        |   130 +
 .../Style G/Default/button_hexagon_wide.png        |   Bin 0 -> 847 bytes
 .../Style G/Default/button_hexagon_wide.png.meta   |   130 +
 .../Sprites/Style G/Default/button_square.png      |   Bin 0 -> 360 bytes
 .../Sprites/Style G/Default/button_square.png.meta |   130 +
 .../Sprites/Style G/Default/button_square_wide.png |   Bin 0 -> 385 bytes
 .../Style G/Default/button_square_wide.png.meta    |   130 +
 .../Sprites/Style G/Default/direction_left.png     |   Bin 0 -> 620 bytes
 .../Style G/Default/direction_left.png.meta        |   130 +
 .../Sprites/Style G/Default/direction_right.png    |   Bin 0 -> 605 bytes
 .../Style G/Default/direction_right.png.meta       |   130 +
 .../Sprites/Style G/Default/dpad.png               |   Bin 0 -> 750 bytes
 .../Sprites/Style G/Default/dpad.png.meta          |   130 +
 .../Sprites/Style G/Default/dpad_element_east.png  |   Bin 0 -> 586 bytes
 .../Style G/Default/dpad_element_east.png.meta     |   130 +
 .../Sprites/Style G/Default/dpad_element_north.png |   Bin 0 -> 567 bytes
 .../Style G/Default/dpad_element_north.png.meta    |   130 +
 .../Sprites/Style G/Default/dpad_element_south.png |   Bin 0 -> 521 bytes
 .../Style G/Default/dpad_element_south.png.meta    |   130 +
 .../Sprites/Style G/Default/dpad_element_west.png  |   Bin 0 -> 573 bytes
 .../Style G/Default/dpad_element_west.png.meta     |   130 +
 .../Sprites/Style G/Default/dpad_separate.png      |   Bin 0 -> 1156 bytes
 .../Sprites/Style G/Default/dpad_separate.png.meta |   130 +
 .../Sprites/Style G/Default/dpad_small.png         |   Bin 0 -> 702 bytes
 .../Sprites/Style G/Default/dpad_small.png.meta    |   130 +
 .../Style G/Default/joystick_circle_nub_a.png      |   Bin 0 -> 1776 bytes
 .../Style G/Default/joystick_circle_nub_a.png.meta |   130 +
 .../Style G/Default/joystick_circle_nub_b.png      |   Bin 0 -> 1653 bytes
 .../Style G/Default/joystick_circle_nub_b.png.meta |   130 +
 .../Style G/Default/joystick_circle_nub_c.png      |   Bin 0 -> 1565 bytes
 .../Style G/Default/joystick_circle_nub_c.png.meta |   130 +
 .../Style G/Default/joystick_circle_pad_a.png      |   Bin 0 -> 2129 bytes
 .../Style G/Default/joystick_circle_pad_a.png.meta |   130 +
 .../Style G/Default/joystick_circle_pad_b.png      |   Bin 0 -> 2137 bytes
 .../Style G/Default/joystick_circle_pad_b.png.meta |   130 +
 .../Style G/Default/joystick_circle_pad_c.png      |   Bin 0 -> 2297 bytes
 .../Style G/Default/joystick_circle_pad_c.png.meta |   130 +
 .../Style G/Default/joystick_circle_pad_d.png      |   Bin 0 -> 1917 bytes
 .../Style G/Default/joystick_circle_pad_d.png.meta |   130 +
 .../Style G/Default/joystick_hexagon_nub_a.png     |   Bin 0 -> 1670 bytes
 .../Default/joystick_hexagon_nub_a.png.meta        |   130 +
 .../Style G/Default/joystick_hexagon_nub_b.png     |   Bin 0 -> 1536 bytes
 .../Default/joystick_hexagon_nub_b.png.meta        |   130 +
 .../Style G/Default/joystick_hexagon_nub_c.png     |   Bin 0 -> 1460 bytes
 .../Default/joystick_hexagon_nub_c.png.meta        |   130 +
 .../Style G/Default/joystick_hexagon_pad_a.png     |   Bin 0 -> 2096 bytes
 .../Default/joystick_hexagon_pad_a.png.meta        |   130 +
 .../Style G/Default/joystick_hexagon_pad_b.png     |   Bin 0 -> 2112 bytes
 .../Default/joystick_hexagon_pad_b.png.meta        |   130 +
 .../Style G/Default/joystick_hexagon_pad_c.png     |   Bin 0 -> 2263 bytes
 .../Default/joystick_hexagon_pad_c.png.meta        |   130 +
 .../Style G/Default/joystick_hexagon_pad_d.png     |   Bin 0 -> 1882 bytes
 .../Default/joystick_hexagon_pad_d.png.meta        |   130 +
 .../Style G/Default/joystick_polygon_nub_a.png     |   Bin 0 -> 1683 bytes
 .../Default/joystick_polygon_nub_a.png.meta        |   130 +
 .../Style G/Default/joystick_polygon_nub_b.png     |   Bin 0 -> 1551 bytes
 .../Default/joystick_polygon_nub_b.png.meta        |   130 +
 .../Style G/Default/joystick_polygon_nub_c.png     |   Bin 0 -> 1481 bytes
 .../Default/joystick_polygon_nub_c.png.meta        |   130 +
 .../Style G/Default/joystick_polygon_pad_a.png     |   Bin 0 -> 2210 bytes
 .../Default/joystick_polygon_pad_a.png.meta        |   130 +
 .../Style G/Default/joystick_polygon_pad_b.png     |   Bin 0 -> 2232 bytes
 .../Default/joystick_polygon_pad_b.png.meta        |   130 +
 .../Style G/Default/joystick_polygon_pad_c.png     |   Bin 0 -> 2379 bytes
 .../Default/joystick_polygon_pad_c.png.meta        |   130 +
 .../Style G/Default/joystick_polygon_pad_d.png     |   Bin 0 -> 2001 bytes
 .../Default/joystick_polygon_pad_d.png.meta        |   130 +
 .../Style G/Default/joystick_square_nub_a.png      |   Bin 0 -> 777 bytes
 .../Style G/Default/joystick_square_nub_a.png.meta |   130 +
 .../Style G/Default/joystick_square_nub_b.png      |   Bin 0 -> 586 bytes
 .../Style G/Default/joystick_square_nub_b.png.meta |   130 +
 .../Style G/Default/joystick_square_nub_c.png      |   Bin 0 -> 468 bytes
 .../Style G/Default/joystick_square_nub_c.png.meta |   130 +
 .../Style G/Default/joystick_square_pad_a.png      |   Bin 0 -> 643 bytes
 .../Style G/Default/joystick_square_pad_a.png.meta |   130 +
 .../Style G/Default/joystick_square_pad_b.png      |   Bin 0 -> 650 bytes
 .../Style G/Default/joystick_square_pad_b.png.meta |   130 +
 .../Style G/Default/joystick_square_pad_c.png      |   Bin 0 -> 831 bytes
 .../Style G/Default/joystick_square_pad_c.png.meta |   130 +
 .../Style G/Default/joystick_square_pad_d.png      |   Bin 0 -> 414 bytes
 .../Style G/Default/joystick_square_pad_d.png.meta |   130 +
 .../Sprites/Style G/Large (2\303\227).meta"        |     8 +
 .../Style G/Large (2\303\227)/button_bean.png"     |   Bin 0 -> 1507 bytes
 .../Large (2\303\227)/button_bean.png.meta"        |   130 +
 .../Style G/Large (2\303\227)/button_circle.png"   |   Bin 0 -> 1937 bytes
 .../Large (2\303\227)/button_circle.png.meta"      |   130 +
 .../Large (2\303\227)/button_circle_wide.png"      |   Bin 0 -> 2183 bytes
 .../Large (2\303\227)/button_circle_wide.png.meta" |   130 +
 .../Style G/Large (2\303\227)/button_diamond.png"  |   Bin 0 -> 814 bytes
 .../Large (2\303\227)/button_diamond.png.meta"     |   130 +
 .../Large (2\303\227)/button_diamond_wide.png"     |   Bin 0 -> 1115 bytes
 .../button_diamond_wide.png.meta"                  |   130 +
 .../Style G/Large (2\303\227)/button_hexagon.png"  |   Bin 0 -> 1301 bytes
 .../Large (2\303\227)/button_hexagon.png.meta"     |   130 +
 .../Large (2\303\227)/button_hexagon_wide.png"     |   Bin 0 -> 1438 bytes
 .../button_hexagon_wide.png.meta"                  |   130 +
 .../Style G/Large (2\303\227)/button_square.png"   |   Bin 0 -> 610 bytes
 .../Large (2\303\227)/button_square.png.meta"      |   130 +
 .../Large (2\303\227)/button_square_wide.png"      |   Bin 0 -> 683 bytes
 .../Large (2\303\227)/button_square_wide.png.meta" |   130 +
 .../Style G/Large (2\303\227)/direction_left.png"  |   Bin 0 -> 987 bytes
 .../Large (2\303\227)/direction_left.png.meta"     |   130 +
 .../Style G/Large (2\303\227)/direction_right.png" |   Bin 0 -> 940 bytes
 .../Large (2\303\227)/direction_right.png.meta"    |   130 +
 .../Sprites/Style G/Large (2\303\227)/dpad.png"    |   Bin 0 -> 1378 bytes
 .../Style G/Large (2\303\227)/dpad.png.meta"       |   130 +
 .../Large (2\303\227)/dpad_element_east.png"       |   Bin 0 -> 987 bytes
 .../Large (2\303\227)/dpad_element_east.png.meta"  |   130 +
 .../Large (2\303\227)/dpad_element_north.png"      |   Bin 0 -> 900 bytes
 .../Large (2\303\227)/dpad_element_north.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_south.png"      |   Bin 0 -> 816 bytes
 .../Large (2\303\227)/dpad_element_south.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_west.png"       |   Bin 0 -> 930 bytes
 .../Large (2\303\227)/dpad_element_west.png.meta"  |   130 +
 .../Style G/Large (2\303\227)/dpad_separate.png"   |   Bin 0 -> 2122 bytes
 .../Large (2\303\227)/dpad_separate.png.meta"      |   130 +
 .../Style G/Large (2\303\227)/dpad_small.png"      |   Bin 0 -> 1198 bytes
 .../Style G/Large (2\303\227)/dpad_small.png.meta" |   130 +
 .../Large (2\303\227)/joystick_circle_nub_a.png"   |   Bin 0 -> 2890 bytes
 .../joystick_circle_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_b.png"   |   Bin 0 -> 2644 bytes
 .../joystick_circle_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_c.png"   |   Bin 0 -> 2529 bytes
 .../joystick_circle_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_a.png"   |   Bin 0 -> 4209 bytes
 .../joystick_circle_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_b.png"   |   Bin 0 -> 4238 bytes
 .../joystick_circle_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_c.png"   |   Bin 0 -> 4583 bytes
 .../joystick_circle_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_d.png"   |   Bin 0 -> 3815 bytes
 .../joystick_circle_pad_d.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_a.png"  |   Bin 0 -> 3047 bytes
 .../joystick_hexagon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_b.png"  |   Bin 0 -> 2792 bytes
 .../joystick_hexagon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_c.png"  |   Bin 0 -> 2672 bytes
 .../joystick_hexagon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_a.png"  |   Bin 0 -> 3945 bytes
 .../joystick_hexagon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_b.png"  |   Bin 0 -> 3989 bytes
 .../joystick_hexagon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_c.png"  |   Bin 0 -> 4316 bytes
 .../joystick_hexagon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_d.png"  |   Bin 0 -> 3548 bytes
 .../joystick_hexagon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_a.png"  |   Bin 0 -> 3265 bytes
 .../joystick_polygon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_b.png"  |   Bin 0 -> 3040 bytes
 .../joystick_polygon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_c.png"  |   Bin 0 -> 2915 bytes
 .../joystick_polygon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_a.png"  |   Bin 0 -> 4126 bytes
 .../joystick_polygon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_b.png"  |   Bin 0 -> 4175 bytes
 .../joystick_polygon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_c.png"  |   Bin 0 -> 4494 bytes
 .../joystick_polygon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_d.png"  |   Bin 0 -> 3745 bytes
 .../joystick_polygon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_square_nub_a.png"   |   Bin 0 -> 1171 bytes
 .../joystick_square_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_b.png"   |   Bin 0 -> 931 bytes
 .../joystick_square_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_c.png"   |   Bin 0 -> 811 bytes
 .../joystick_square_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_a.png"   |   Bin 0 -> 1253 bytes
 .../joystick_square_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_b.png"   |   Bin 0 -> 1267 bytes
 .../joystick_square_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_c.png"   |   Bin 0 -> 1644 bytes
 .../joystick_square_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_d.png"   |   Bin 0 -> 832 bytes
 .../joystick_square_pad_d.png.meta"                |   130 +
 .../NewUI/mobile-controls-1/Sprites/Style H.meta   |     8 +
 .../mobile-controls-1/Sprites/Style H/Default.meta |     8 +
 .../Sprites/Style H/Default/button_bean.png        |   Bin 0 -> 846 bytes
 .../Sprites/Style H/Default/button_bean.png.meta   |   130 +
 .../Sprites/Style H/Default/button_circle.png      |   Bin 0 -> 1085 bytes
 .../Sprites/Style H/Default/button_circle.png.meta |   130 +
 .../Sprites/Style H/Default/button_circle_wide.png |   Bin 0 -> 1163 bytes
 .../Style H/Default/button_circle_wide.png.meta    |   130 +
 .../Sprites/Style H/Default/button_diamond.png     |   Bin 0 -> 507 bytes
 .../Style H/Default/button_diamond.png.meta        |   130 +
 .../Style H/Default/button_diamond_wide.png        |   Bin 0 -> 620 bytes
 .../Style H/Default/button_diamond_wide.png.meta   |   130 +
 .../Sprites/Style H/Default/button_hexagon.png     |   Bin 0 -> 765 bytes
 .../Style H/Default/button_hexagon.png.meta        |   130 +
 .../Style H/Default/button_hexagon_wide.png        |   Bin 0 -> 824 bytes
 .../Style H/Default/button_hexagon_wide.png.meta   |   130 +
 .../Sprites/Style H/Default/button_square.png      |   Bin 0 -> 365 bytes
 .../Sprites/Style H/Default/button_square.png.meta |   130 +
 .../Sprites/Style H/Default/button_square_wide.png |   Bin 0 -> 390 bytes
 .../Style H/Default/button_square_wide.png.meta    |   130 +
 .../Sprites/Style H/Default/direction_left.png     |   Bin 0 -> 611 bytes
 .../Style H/Default/direction_left.png.meta        |   130 +
 .../Sprites/Style H/Default/direction_right.png    |   Bin 0 -> 596 bytes
 .../Style H/Default/direction_right.png.meta       |   130 +
 .../Sprites/Style H/Default/dpad.png               |   Bin 0 -> 705 bytes
 .../Sprites/Style H/Default/dpad.png.meta          |   130 +
 .../Sprites/Style H/Default/dpad_element_east.png  |   Bin 0 -> 575 bytes
 .../Style H/Default/dpad_element_east.png.meta     |   130 +
 .../Sprites/Style H/Default/dpad_element_north.png |   Bin 0 -> 563 bytes
 .../Style H/Default/dpad_element_north.png.meta    |   130 +
 .../Sprites/Style H/Default/dpad_element_south.png |   Bin 0 -> 521 bytes
 .../Style H/Default/dpad_element_south.png.meta    |   130 +
 .../Sprites/Style H/Default/dpad_element_west.png  |   Bin 0 -> 566 bytes
 .../Style H/Default/dpad_element_west.png.meta     |   130 +
 .../Sprites/Style H/Default/dpad_separate.png      |   Bin 0 -> 1137 bytes
 .../Sprites/Style H/Default/dpad_separate.png.meta |   130 +
 .../Sprites/Style H/Default/dpad_small.png         |   Bin 0 -> 658 bytes
 .../Sprites/Style H/Default/dpad_small.png.meta    |   130 +
 .../Style H/Default/joystick_circle_nub_a.png      |   Bin 0 -> 1846 bytes
 .../Style H/Default/joystick_circle_nub_a.png.meta |   130 +
 .../Style H/Default/joystick_circle_nub_b.png      |   Bin 0 -> 1770 bytes
 .../Style H/Default/joystick_circle_nub_b.png.meta |   130 +
 .../Style H/Default/joystick_circle_nub_c.png      |   Bin 0 -> 1727 bytes
 .../Style H/Default/joystick_circle_nub_c.png.meta |   130 +
 .../Style H/Default/joystick_circle_pad_a.png      |   Bin 0 -> 2081 bytes
 .../Style H/Default/joystick_circle_pad_a.png.meta |   130 +
 .../Style H/Default/joystick_circle_pad_b.png      |   Bin 0 -> 2089 bytes
 .../Style H/Default/joystick_circle_pad_b.png.meta |   130 +
 .../Style H/Default/joystick_circle_pad_c.png      |   Bin 0 -> 2245 bytes
 .../Style H/Default/joystick_circle_pad_c.png.meta |   130 +
 .../Style H/Default/joystick_circle_pad_d.png      |   Bin 0 -> 1894 bytes
 .../Style H/Default/joystick_circle_pad_d.png.meta |   130 +
 .../Style H/Default/joystick_hexagon_nub_a.png     |   Bin 0 -> 1790 bytes
 .../Default/joystick_hexagon_nub_a.png.meta        |   130 +
 .../Style H/Default/joystick_hexagon_nub_b.png     |   Bin 0 -> 1704 bytes
 .../Default/joystick_hexagon_nub_b.png.meta        |   130 +
 .../Style H/Default/joystick_hexagon_nub_c.png     |   Bin 0 -> 1665 bytes
 .../Default/joystick_hexagon_nub_c.png.meta        |   130 +
 .../Style H/Default/joystick_hexagon_pad_a.png     |   Bin 0 -> 2053 bytes
 .../Default/joystick_hexagon_pad_a.png.meta        |   130 +
 .../Style H/Default/joystick_hexagon_pad_b.png     |   Bin 0 -> 2063 bytes
 .../Default/joystick_hexagon_pad_b.png.meta        |   130 +
 .../Style H/Default/joystick_hexagon_pad_c.png     |   Bin 0 -> 2213 bytes
 .../Default/joystick_hexagon_pad_c.png.meta        |   130 +
 .../Style H/Default/joystick_hexagon_pad_d.png     |   Bin 0 -> 1868 bytes
 .../Default/joystick_hexagon_pad_d.png.meta        |   130 +
 .../Style H/Default/joystick_polygon_nub_a.png     |   Bin 0 -> 1793 bytes
 .../Default/joystick_polygon_nub_a.png.meta        |   130 +
 .../Style H/Default/joystick_polygon_nub_b.png     |   Bin 0 -> 1716 bytes
 .../Default/joystick_polygon_nub_b.png.meta        |   130 +
 .../Style H/Default/joystick_polygon_nub_c.png     |   Bin 0 -> 1682 bytes
 .../Default/joystick_polygon_nub_c.png.meta        |   130 +
 .../Style H/Default/joystick_polygon_pad_a.png     |   Bin 0 -> 2160 bytes
 .../Default/joystick_polygon_pad_a.png.meta        |   130 +
 .../Style H/Default/joystick_polygon_pad_b.png     |   Bin 0 -> 2172 bytes
 .../Default/joystick_polygon_pad_b.png.meta        |   130 +
 .../Style H/Default/joystick_polygon_pad_c.png     |   Bin 0 -> 2320 bytes
 .../Default/joystick_polygon_pad_c.png.meta        |   130 +
 .../Style H/Default/joystick_polygon_pad_d.png     |   Bin 0 -> 1983 bytes
 .../Default/joystick_polygon_pad_d.png.meta        |   130 +
 .../Style H/Default/joystick_square_nub_a.png      |   Bin 0 -> 825 bytes
 .../Style H/Default/joystick_square_nub_a.png.meta |   130 +
 .../Style H/Default/joystick_square_nub_b.png      |   Bin 0 -> 611 bytes
 .../Style H/Default/joystick_square_nub_b.png.meta |   130 +
 .../Style H/Default/joystick_square_nub_c.png      |   Bin 0 -> 504 bytes
 .../Style H/Default/joystick_square_nub_c.png.meta |   130 +
 .../Style H/Default/joystick_square_pad_a.png      |   Bin 0 -> 626 bytes
 .../Style H/Default/joystick_square_pad_a.png.meta |   130 +
 .../Style H/Default/joystick_square_pad_b.png      |   Bin 0 -> 631 bytes
 .../Style H/Default/joystick_square_pad_b.png.meta |   130 +
 .../Style H/Default/joystick_square_pad_c.png      |   Bin 0 -> 805 bytes
 .../Style H/Default/joystick_square_pad_c.png.meta |   130 +
 .../Style H/Default/joystick_square_pad_d.png      |   Bin 0 -> 405 bytes
 .../Style H/Default/joystick_square_pad_d.png.meta |   130 +
 .../Sprites/Style H/Large (2\303\227).meta"        |     8 +
 .../Style H/Large (2\303\227)/button_bean.png"     |   Bin 0 -> 1398 bytes
 .../Large (2\303\227)/button_bean.png.meta"        |   130 +
 .../Style H/Large (2\303\227)/button_circle.png"   |   Bin 0 -> 1801 bytes
 .../Large (2\303\227)/button_circle.png.meta"      |   130 +
 .../Large (2\303\227)/button_circle_wide.png"      |   Bin 0 -> 2005 bytes
 .../Large (2\303\227)/button_circle_wide.png.meta" |   130 +
 .../Style H/Large (2\303\227)/button_diamond.png"  |   Bin 0 -> 814 bytes
 .../Large (2\303\227)/button_diamond.png.meta"     |   130 +
 .../Large (2\303\227)/button_diamond_wide.png"     |   Bin 0 -> 1115 bytes
 .../button_diamond_wide.png.meta"                  |   130 +
 .../Style H/Large (2\303\227)/button_hexagon.png"  |   Bin 0 -> 1290 bytes
 .../Large (2\303\227)/button_hexagon.png.meta"     |   130 +
 .../Large (2\303\227)/button_hexagon_wide.png"     |   Bin 0 -> 1426 bytes
 .../button_hexagon_wide.png.meta"                  |   130 +
 .../Style H/Large (2\303\227)/button_square.png"   |   Bin 0 -> 611 bytes
 .../Large (2\303\227)/button_square.png.meta"      |   130 +
 .../Large (2\303\227)/button_square_wide.png"      |   Bin 0 -> 684 bytes
 .../Large (2\303\227)/button_square_wide.png.meta" |   130 +
 .../Style H/Large (2\303\227)/direction_left.png"  |   Bin 0 -> 971 bytes
 .../Large (2\303\227)/direction_left.png.meta"     |   130 +
 .../Style H/Large (2\303\227)/direction_right.png" |   Bin 0 -> 922 bytes
 .../Large (2\303\227)/direction_right.png.meta"    |   130 +
 .../Sprites/Style H/Large (2\303\227)/dpad.png"    |   Bin 0 -> 1311 bytes
 .../Style H/Large (2\303\227)/dpad.png.meta"       |   130 +
 .../Large (2\303\227)/dpad_element_east.png"       |   Bin 0 -> 968 bytes
 .../Large (2\303\227)/dpad_element_east.png.meta"  |   130 +
 .../Large (2\303\227)/dpad_element_north.png"      |   Bin 0 -> 896 bytes
 .../Large (2\303\227)/dpad_element_north.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_south.png"      |   Bin 0 -> 807 bytes
 .../Large (2\303\227)/dpad_element_south.png.meta" |   130 +
 .../Large (2\303\227)/dpad_element_west.png"       |   Bin 0 -> 925 bytes
 .../Large (2\303\227)/dpad_element_west.png.meta"  |   130 +
 .../Style H/Large (2\303\227)/dpad_separate.png"   |   Bin 0 -> 2102 bytes
 .../Large (2\303\227)/dpad_separate.png.meta"      |   130 +
 .../Style H/Large (2\303\227)/dpad_small.png"      |   Bin 0 -> 1136 bytes
 .../Style H/Large (2\303\227)/dpad_small.png.meta" |   130 +
 .../Large (2\303\227)/joystick_circle_nub_a.png"   |   Bin 0 -> 3081 bytes
 .../joystick_circle_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_b.png"   |   Bin 0 -> 2916 bytes
 .../joystick_circle_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_nub_c.png"   |   Bin 0 -> 2811 bytes
 .../joystick_circle_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_a.png"   |   Bin 0 -> 4151 bytes
 .../joystick_circle_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_b.png"   |   Bin 0 -> 4186 bytes
 .../joystick_circle_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_c.png"   |   Bin 0 -> 4511 bytes
 .../joystick_circle_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_circle_pad_d.png"   |   Bin 0 -> 3810 bytes
 .../joystick_circle_pad_d.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_a.png"  |   Bin 0 -> 3190 bytes
 .../joystick_hexagon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_b.png"  |   Bin 0 -> 3027 bytes
 .../joystick_hexagon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_nub_c.png"  |   Bin 0 -> 2959 bytes
 .../joystick_hexagon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_a.png"  |   Bin 0 -> 3887 bytes
 .../joystick_hexagon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_b.png"  |   Bin 0 -> 3920 bytes
 .../joystick_hexagon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_c.png"  |   Bin 0 -> 4251 bytes
 .../joystick_hexagon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_hexagon_pad_d.png"  |   Bin 0 -> 3529 bytes
 .../joystick_hexagon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_a.png"  |   Bin 0 -> 3320 bytes
 .../joystick_polygon_nub_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_b.png"  |   Bin 0 -> 3155 bytes
 .../joystick_polygon_nub_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_nub_c.png"  |   Bin 0 -> 3082 bytes
 .../joystick_polygon_nub_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_a.png"  |   Bin 0 -> 4067 bytes
 .../joystick_polygon_pad_a.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_b.png"  |   Bin 0 -> 4115 bytes
 .../joystick_polygon_pad_b.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_c.png"  |   Bin 0 -> 4429 bytes
 .../joystick_polygon_pad_c.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_polygon_pad_d.png"  |   Bin 0 -> 3728 bytes
 .../joystick_polygon_pad_d.png.meta"               |   130 +
 .../Large (2\303\227)/joystick_square_nub_a.png"   |   Bin 0 -> 1305 bytes
 .../joystick_square_nub_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_b.png"   |   Bin 0 -> 1092 bytes
 .../joystick_square_nub_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_nub_c.png"   |   Bin 0 -> 989 bytes
 .../joystick_square_nub_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_a.png"   |   Bin 0 -> 1245 bytes
 .../joystick_square_pad_a.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_b.png"   |   Bin 0 -> 1259 bytes
 .../joystick_square_pad_b.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_c.png"   |   Bin 0 -> 1630 bytes
 .../joystick_square_pad_c.png.meta"                |   130 +
 .../Large (2\303\227)/joystick_square_pad_d.png"   |   Bin 0 -> 827 bytes
 .../joystick_square_pad_d.png.meta"                |   130 +
 .../NewUI/mobile-controls-1/Spritesheets.meta      |     8 +
 .../Spritesheets/highlights-a-default.png          |   Bin 0 -> 22624 bytes
 .../Spritesheets/highlights-a-default.png.meta     |   130 +
 .../Spritesheets/highlights-a-default.xml          |    28 +
 .../Spritesheets/highlights-a-default.xml.meta     |     7 +
 .../Spritesheets/highlights-a-large.png            |   Bin 0 -> 42365 bytes
 .../Spritesheets/highlights-a-large.png.meta       |   130 +
 .../Spritesheets/highlights-a-large.xml            |    28 +
 .../Spritesheets/highlights-a-large.xml.meta       |     7 +
 .../Spritesheets/highlights-b-default.png          |   Bin 0 -> 23791 bytes
 .../Spritesheets/highlights-b-default.png.meta     |   130 +
 .../Spritesheets/highlights-b-default.xml          |    28 +
 .../Spritesheets/highlights-b-default.xml.meta     |     7 +
 .../Spritesheets/highlights-b-large.png            |   Bin 0 -> 47160 bytes
 .../Spritesheets/highlights-b-large.png.meta       |   130 +
 .../Spritesheets/highlights-b-large.xml            |    28 +
 .../Spritesheets/highlights-b-large.xml.meta       |     7 +
 .../Spritesheets/icons-default.png                 |   Bin 0 -> 12447 bytes
 .../Spritesheets/icons-default.png.meta            |   130 +
 .../Spritesheets/icons-default.xml                 |    44 +
 .../Spritesheets/icons-default.xml.meta            |     7 +
 .../mobile-controls-1/Spritesheets/icons-large.png |   Bin 0 -> 25826 bytes
 .../Spritesheets/icons-large.png.meta              |   130 +
 .../mobile-controls-1/Spritesheets/icons-large.xml |    44 +
 .../Spritesheets/icons-large.xml.meta              |     7 +
 .../Spritesheets/style-a-default.png               |   Bin 0 -> 46216 bytes
 .../Spritesheets/style-a-default.png.meta          |   130 +
 .../Spritesheets/style-a-default.xml               |    48 +
 .../Spritesheets/style-a-default.xml.meta          |     7 +
 .../Spritesheets/style-a-large.png                 |   Bin 0 -> 91956 bytes
 .../Spritesheets/style-a-large.png.meta            |   130 +
 .../Spritesheets/style-a-large.xml                 |    48 +
 .../Spritesheets/style-a-large.xml.meta            |     7 +
 .../Spritesheets/style-b-default.png               |   Bin 0 -> 48947 bytes
 .../Spritesheets/style-b-default.png.meta          |   130 +
 .../Spritesheets/style-b-default.xml               |    48 +
 .../Spritesheets/style-b-default.xml.meta          |     7 +
 .../Spritesheets/style-b-large.png                 |   Bin 0 -> 97727 bytes
 .../Spritesheets/style-b-large.png.meta            |   130 +
 .../Spritesheets/style-b-large.xml                 |    48 +
 .../Spritesheets/style-b-large.xml.meta            |     7 +
 .../Spritesheets/style-c-default.png               |   Bin 0 -> 25438 bytes
 .../Spritesheets/style-c-default.png.meta          |   130 +
 .../Spritesheets/style-c-default.xml               |    48 +
 .../Spritesheets/style-c-default.xml.meta          |     7 +
 .../Spritesheets/style-c-large.png                 |   Bin 0 -> 58600 bytes
 .../Spritesheets/style-c-large.png.meta            |   130 +
 .../Spritesheets/style-c-large.xml                 |    48 +
 .../Spritesheets/style-c-large.xml.meta            |     7 +
 .../Spritesheets/style-d-default.png               |   Bin 0 -> 25438 bytes
 .../Spritesheets/style-d-default.png.meta          |   130 +
 .../Spritesheets/style-d-default.xml               |    48 +
 .../Spritesheets/style-d-default.xml.meta          |     7 +
 .../Spritesheets/style-d-large.png                 |   Bin 0 -> 58600 bytes
 .../Spritesheets/style-d-large.png.meta            |   130 +
 .../Spritesheets/style-d-large.xml                 |    48 +
 .../Spritesheets/style-d-large.xml.meta            |     7 +
 .../Spritesheets/style-e-default.png               |   Bin 0 -> 33778 bytes
 .../Spritesheets/style-e-default.png.meta          |   130 +
 .../Spritesheets/style-e-default.xml               |    48 +
 .../Spritesheets/style-e-default.xml.meta          |     7 +
 .../Spritesheets/style-e-large.png                 |   Bin 0 -> 72882 bytes
 .../Spritesheets/style-e-large.png.meta            |   130 +
 .../Spritesheets/style-e-large.xml                 |    48 +
 .../Spritesheets/style-e-large.xml.meta            |     7 +
 .../Spritesheets/style-f-default.png               |   Bin 0 -> 39857 bytes
 .../Spritesheets/style-f-default.png.meta          |   130 +
 .../Spritesheets/style-f-default.xml               |    48 +
 .../Spritesheets/style-f-default.xml.meta          |     7 +
 .../Spritesheets/style-f-large.png                 |   Bin 0 -> 104987 bytes
 .../Spritesheets/style-f-large.png.meta            |   130 +
 .../Spritesheets/style-f-large.xml                 |    48 +
 .../Spritesheets/style-f-large.xml.meta            |     7 +
 .../Spritesheets/style-g-default.png               |   Bin 0 -> 39110 bytes
 .../Spritesheets/style-g-default.png.meta          |   130 +
 .../Spritesheets/style-g-default.xml               |    48 +
 .../Spritesheets/style-g-default.xml.meta          |     7 +
 .../Spritesheets/style-g-large.png                 |   Bin 0 -> 83181 bytes
 .../Spritesheets/style-g-large.png.meta            |   130 +
 .../Spritesheets/style-g-large.xml                 |    48 +
 .../Spritesheets/style-g-large.xml.meta            |     7 +
 .../Spritesheets/style-h-default.png               |   Bin 0 -> 39542 bytes
 .../Spritesheets/style-h-default.png.meta          |   130 +
 .../Spritesheets/style-h-default.xml               |    48 +
 .../Spritesheets/style-h-default.xml.meta          |     7 +
 .../Spritesheets/style-h-large.png                 |   Bin 0 -> 83665 bytes
 .../Spritesheets/style-h-large.png.meta            |   130 +
 .../Spritesheets/style-h-large.xml                 |    48 +
 .../Spritesheets/style-h-large.xml.meta            |     7 +
 .../textures/NewUI/mobile-controls-1/Vector.meta   |     8 +
 .../mobile-controls-1/Vector/Highlights A.meta     |     8 +
 .../Vector/Highlights A/button_bean_highlight.svg  |    12 +
 .../Highlights A/button_bean_highlight.svg.meta    |    53 +
 .../Highlights A/button_circle_highlight.svg       |    12 +
 .../Highlights A/button_circle_highlight.svg.meta  |    53 +
 .../Highlights A/button_circle_wide_highlight.svg  |    12 +
 .../button_circle_wide_highlight.svg.meta          |    53 +
 .../Highlights A/button_diamond_highlight.svg      |    12 +
 .../Highlights A/button_diamond_highlight.svg.meta |    53 +
 .../Highlights A/button_diamond_highlight_wide.svg |    12 +
 .../button_diamond_highlight_wide.svg.meta         |    53 +
 .../Highlights A/button_hexagon_highlight.svg      |    12 +
 .../Highlights A/button_hexagon_highlight.svg.meta |    53 +
 .../Highlights A/button_hexagon_wide_highlight.svg |    12 +
 .../button_hexagon_wide_highlight.svg.meta         |    53 +
 .../Highlights A/button_square_highlight.svg       |    12 +
 .../Highlights A/button_square_highlight.svg.meta  |    53 +
 .../Highlights A/button_square_wide_highlight.svg  |    12 +
 .../button_square_wide_highlight.svg.meta          |    53 +
 .../Highlights A/direction_left_highlight.svg      |    12 +
 .../Highlights A/direction_left_highlight.svg.meta |    53 +
 .../Highlights A/direction_right_highlight.svg     |    12 +
 .../direction_right_highlight.svg.meta             |    53 +
 .../Highlights A/dpad_element_east_highlight.svg   |    12 +
 .../dpad_element_east_highlight.svg.meta           |    53 +
 .../Highlights A/dpad_element_north_highlight.svg  |    12 +
 .../dpad_element_north_highlight.svg.meta          |    53 +
 .../Highlights A/dpad_element_south_highlight.svg  |    12 +
 .../dpad_element_south_highlight.svg.meta          |    53 +
 .../Highlights A/dpad_element_west_highlight.svg   |    12 +
 .../dpad_element_west_highlight.svg.meta           |    53 +
 .../Vector/Highlights A/dpad_highlight.svg         |    12 +
 .../Vector/Highlights A/dpad_highlight.svg.meta    |    53 +
 .../Highlights A/dpad_separate_highlight.svg       |    30 +
 .../Highlights A/dpad_separate_highlight.svg.meta  |    53 +
 .../Vector/Highlights A/dpad_small_highlight.svg   |    12 +
 .../Highlights A/dpad_small_highlight.svg.meta     |    53 +
 .../Highlights A/joystick_circle_nub_highlight.svg |    12 +
 .../joystick_circle_nub_highlight.svg.meta         |    53 +
 .../Highlights A/joystick_circle_pad_highlight.svg |    12 +
 .../joystick_circle_pad_highlight.svg.meta         |    53 +
 .../joystick_hexagon_nub_highlight.svg             |    12 +
 .../joystick_hexagon_nub_highlight.svg.meta        |    53 +
 .../joystick_hexagon_pad_highlight.svg             |    12 +
 .../joystick_hexagon_pad_highlight.svg.meta        |    53 +
 .../joystick_polygon_nub_highlight.svg             |    12 +
 .../joystick_polygon_nub_highlight.svg.meta        |    53 +
 .../joystick_polygon_pad_highlight.svg             |    17 +
 .../joystick_polygon_pad_highlight.svg.meta        |    53 +
 .../Highlights A/joystick_square_nub_highlight.svg |    12 +
 .../joystick_square_nub_highlight.svg.meta         |    53 +
 .../Highlights A/joystick_square_pad_highlight.svg |    12 +
 .../joystick_square_pad_highlight.svg.meta         |    53 +
 .../mobile-controls-1/Vector/Highlights B.meta     |     8 +
 .../Vector/Highlights B/button_bean_highlight.svg  |    12 +
 .../Highlights B/button_bean_highlight.svg.meta    |    53 +
 .../Highlights B/button_circle_highlight.svg       |    12 +
 .../Highlights B/button_circle_highlight.svg.meta  |    53 +
 .../Highlights B/button_circle_wide_highlight.svg  |    12 +
 .../button_circle_wide_highlight.svg.meta          |    53 +
 .../Highlights B/button_diamond_highlight.svg      |    12 +
 .../Highlights B/button_diamond_highlight.svg.meta |    53 +
 .../Highlights B/button_diamond_highlight_wide.svg |    12 +
 .../button_diamond_highlight_wide.svg.meta         |    53 +
 .../Highlights B/button_hexagon_highlight.svg      |    12 +
 .../Highlights B/button_hexagon_highlight.svg.meta |    53 +
 .../Highlights B/button_hexagon_wide_highlight.svg |    12 +
 .../button_hexagon_wide_highlight.svg.meta         |    53 +
 .../Highlights B/button_square_highlight.svg       |    12 +
 .../Highlights B/button_square_highlight.svg.meta  |    53 +
 .../Highlights B/button_square_wide_highlight.svg  |    12 +
 .../button_square_wide_highlight.svg.meta          |    53 +
 .../Highlights B/direction_left_highlight.svg      |    12 +
 .../Highlights B/direction_left_highlight.svg.meta |    53 +
 .../Highlights B/direction_right_highlight.svg     |    12 +
 .../direction_right_highlight.svg.meta             |    53 +
 .../Highlights B/dpad_element_east_highlight.svg   |    12 +
 .../dpad_element_east_highlight.svg.meta           |    53 +
 .../Highlights B/dpad_element_north_highlight.svg  |    12 +
 .../dpad_element_north_highlight.svg.meta          |    53 +
 .../Highlights B/dpad_element_south_highlight.svg  |    12 +
 .../dpad_element_south_highlight.svg.meta          |    53 +
 .../Highlights B/dpad_element_west_highlight.svg   |    12 +
 .../dpad_element_west_highlight.svg.meta           |    53 +
 .../Vector/Highlights B/dpad_highlight.svg         |    12 +
 .../Vector/Highlights B/dpad_highlight.svg.meta    |    53 +
 .../Highlights B/dpad_separate_highlight.svg       |    30 +
 .../Highlights B/dpad_separate_highlight.svg.meta  |    53 +
 .../Vector/Highlights B/dpad_small_highlight.svg   |    12 +
 .../Highlights B/dpad_small_highlight.svg.meta     |    53 +
 .../Highlights B/joystick_circle_nub_highlight.svg |    12 +
 .../joystick_circle_nub_highlight.svg.meta         |    53 +
 .../Highlights B/joystick_circle_pad_highlight.svg |    12 +
 .../joystick_circle_pad_highlight.svg.meta         |    53 +
 .../joystick_hexagon_nub_highlight.svg             |    12 +
 .../joystick_hexagon_nub_highlight.svg.meta        |    53 +
 .../joystick_hexagon_pad_highlight.svg             |    12 +
 .../joystick_hexagon_pad_highlight.svg.meta        |    53 +
 .../joystick_polygon_nub_highlight.svg             |    12 +
 .../joystick_polygon_nub_highlight.svg.meta        |    53 +
 .../joystick_polygon_pad_highlight.svg             |    13 +
 .../joystick_polygon_pad_highlight.svg.meta        |    53 +
 .../Highlights B/joystick_square_nub_highlight.svg |    12 +
 .../joystick_square_nub_highlight.svg.meta         |    53 +
 .../Highlights B/joystick_square_pad_highlight.svg |    12 +
 .../joystick_square_pad_highlight.svg.meta         |    53 +
 .../NewUI/mobile-controls-1/Vector/Icons.meta      |     8 +
 .../mobile-controls-1/Vector/Icons/icon_arrow.svg  |    12 +
 .../Vector/Icons/icon_arrow.svg.meta               |    53 +
 .../Vector/Icons/icon_arrow_curved.svg             |    12 +
 .../Vector/Icons/icon_arrow_curved.svg.meta        |    53 +
 .../Vector/Icons/icon_arrow_rotate.svg             |    12 +
 .../Vector/Icons/icon_arrow_rotate.svg.meta        |    53 +
 .../mobile-controls-1/Vector/Icons/icon_burst.svg  |     6 +
 .../Vector/Icons/icon_burst.svg.meta               |    53 +
 .../Vector/Icons/icon_button_a.svg                 |     6 +
 .../Vector/Icons/icon_button_a.svg.meta            |    53 +
 .../Vector/Icons/icon_button_b.svg                 |     6 +
 .../Vector/Icons/icon_button_b.svg.meta            |    53 +
 .../Vector/Icons/icon_button_l.svg                 |     6 +
 .../Vector/Icons/icon_button_l.svg.meta            |    53 +
 .../Vector/Icons/icon_button_r.svg                 |     6 +
 .../Vector/Icons/icon_button_r.svg.meta            |    53 +
 .../Vector/Icons/icon_button_x.svg                 |     6 +
 .../Vector/Icons/icon_button_x.svg.meta            |    53 +
 .../Vector/Icons/icon_button_y.svg                 |     6 +
 .../Vector/Icons/icon_button_y.svg.meta            |    53 +
 .../Vector/Icons/icon_checkmark.svg                |     6 +
 .../Vector/Icons/icon_checkmark.svg.meta           |    53 +
 .../mobile-controls-1/Vector/Icons/icon_cog.svg    |    47 +
 .../Vector/Icons/icon_cog.svg.meta                 |    53 +
 .../mobile-controls-1/Vector/Icons/icon_cross.svg  |     6 +
 .../Vector/Icons/icon_cross.svg.meta               |    53 +
 .../Vector/Icons/icon_crosshair.svg                |    12 +
 .../Vector/Icons/icon_crosshair.svg.meta           |    53 +
 .../mobile-controls-1/Vector/Icons/icon_fire.svg   |     6 +
 .../Vector/Icons/icon_fire.svg.meta                |    53 +
 .../mobile-controls-1/Vector/Icons/icon_hand.svg   |     6 +
 .../Vector/Icons/icon_hand.svg.meta                |    53 +
 .../mobile-controls-1/Vector/Icons/icon_jump.svg   |     6 +
 .../Vector/Icons/icon_jump.svg.meta                |    53 +
 .../mobile-controls-1/Vector/Icons/icon_key.svg    |    12 +
 .../Vector/Icons/icon_key.svg.meta                 |    53 +
 .../mobile-controls-1/Vector/Icons/icon_lock.svg   |    12 +
 .../Vector/Icons/icon_lock.svg.meta                |    53 +
 .../mobile-controls-1/Vector/Icons/icon_menu.svg   |     6 +
 .../Vector/Icons/icon_menu.svg.meta                |    53 +
 .../Vector/Icons/icon_microphone.svg               |     6 +
 .../Vector/Icons/icon_microphone.svg.meta          |    53 +
 .../mobile-controls-1/Vector/Icons/icon_money.svg  |     6 +
 .../Vector/Icons/icon_money.svg.meta               |    53 +
 .../mobile-controls-1/Vector/Icons/icon_music.svg  |     6 +
 .../Vector/Icons/icon_music.svg.meta               |    53 +
 .../Vector/Icons/icon_music_disabled.svg           |     6 +
 .../Vector/Icons/icon_music_disabled.svg.meta      |    53 +
 .../mobile-controls-1/Vector/Icons/icon_pause.svg  |     6 +
 .../Vector/Icons/icon_pause.svg.meta               |    53 +
 .../mobile-controls-1/Vector/Icons/icon_pedal.svg  |     6 +
 .../Vector/Icons/icon_pedal.svg.meta               |    53 +
 .../Vector/Icons/icon_pedal_brake.svg              |     6 +
 .../Vector/Icons/icon_pedal_brake.svg.meta         |    53 +
 .../mobile-controls-1/Vector/Icons/icon_play.svg   |     6 +
 .../Vector/Icons/icon_play.svg.meta                |    53 +
 .../mobile-controls-1/Vector/Icons/icon_save.svg   |     6 +
 .../Vector/Icons/icon_save.svg.meta                |    53 +
 .../mobile-controls-1/Vector/Icons/icon_search.svg |     6 +
 .../Vector/Icons/icon_search.svg.meta              |    53 +
 .../mobile-controls-1/Vector/Icons/icon_shield.svg |    12 +
 .../Vector/Icons/icon_shield.svg.meta              |    53 +
 .../Vector/Icons/icon_size_larger.svg              |     6 +
 .../Vector/Icons/icon_size_larger.svg.meta         |    53 +
 .../Vector/Icons/icon_size_smaller.svg             |     6 +
 .../Vector/Icons/icon_size_smaller.svg.meta        |    53 +
 .../mobile-controls-1/Vector/Icons/icon_skull.svg  |     6 +
 .../Vector/Icons/icon_skull.svg.meta               |    53 +
 .../mobile-controls-1/Vector/Icons/icon_sound.svg  |     6 +
 .../Vector/Icons/icon_sound.svg.meta               |    53 +
 .../Vector/Icons/icon_sound_disabled.svg           |     6 +
 .../Vector/Icons/icon_sound_disabled.svg.meta      |    53 +
 .../mobile-controls-1/Vector/Icons/icon_star.svg   |     6 +
 .../Vector/Icons/icon_star.svg.meta                |    53 +
 .../Vector/Icons/icon_steering_wheel.svg           |     6 +
 .../Vector/Icons/icon_steering_wheel.svg.meta      |    53 +
 .../mobile-controls-1/Vector/Icons/icon_sword.svg  |    12 +
 .../Vector/Icons/icon_sword.svg.meta               |    53 +
 .../mobile-controls-1/Vector/Icons/icon_talk.svg   |    12 +
 .../Vector/Icons/icon_talk.svg.meta                |    53 +
 .../mobile-controls-1/Vector/Icons/icon_target.svg |     6 +
 .../Vector/Icons/icon_target.svg.meta              |    53 +
 .../mobile-controls-1/Vector/Icons/icon_wrench.svg |     6 +
 .../Vector/Icons/icon_wrench.svg.meta              |    53 +
 .../NewUI/mobile-controls-1/Vector/Style A.meta    |     8 +
 .../Vector/Style A/button_bean.svg                 |    13 +
 .../Vector/Style A/button_bean.svg.meta            |    53 +
 .../Vector/Style A/button_circle.svg               |    13 +
 .../Vector/Style A/button_circle.svg.meta          |    53 +
 .../Vector/Style A/button_circle_wide.svg          |    13 +
 .../Vector/Style A/button_circle_wide.svg.meta     |    53 +
 .../Vector/Style A/button_diamond.svg              |    13 +
 .../Vector/Style A/button_diamond.svg.meta         |    53 +
 .../Vector/Style A/button_diamond_wide.svg         |    13 +
 .../Vector/Style A/button_diamond_wide.svg.meta    |    53 +
 .../Vector/Style A/button_hexagon.svg              |    13 +
 .../Vector/Style A/button_hexagon.svg.meta         |    53 +
 .../Vector/Style A/button_hexagon_wide.svg         |    13 +
 .../Vector/Style A/button_hexagon_wide.svg.meta    |    53 +
 .../Vector/Style A/button_square.svg               |    13 +
 .../Vector/Style A/button_square.svg.meta          |    53 +
 .../Vector/Style A/button_square_wide.svg          |    13 +
 .../Vector/Style A/button_square_wide.svg.meta     |    53 +
 .../Vector/Style A/direction_left.svg              |    13 +
 .../Vector/Style A/direction_left.svg.meta         |    53 +
 .../Vector/Style A/direction_right.svg             |    13 +
 .../Vector/Style A/direction_right.svg.meta        |    53 +
 .../mobile-controls-1/Vector/Style A/dpad.svg      |    18 +
 .../mobile-controls-1/Vector/Style A/dpad.svg.meta |    53 +
 .../Vector/Style A/dpad_element_east.svg           |    14 +
 .../Vector/Style A/dpad_element_east.svg.meta      |    53 +
 .../Vector/Style A/dpad_element_north.svg          |    14 +
 .../Vector/Style A/dpad_element_north.svg.meta     |    53 +
 .../Vector/Style A/dpad_element_south.svg          |    14 +
 .../Vector/Style A/dpad_element_south.svg.meta     |    53 +
 .../Vector/Style A/dpad_element_west.svg           |    14 +
 .../Vector/Style A/dpad_element_west.svg.meta      |    53 +
 .../Vector/Style A/dpad_separate.svg               |    38 +
 .../Vector/Style A/dpad_separate.svg.meta          |    53 +
 .../Vector/Style A/dpad_small.svg                  |    18 +
 .../Vector/Style A/dpad_small.svg.meta             |    53 +
 .../Vector/Style A/joystick_circle_nub_a.svg       |    18 +
 .../Vector/Style A/joystick_circle_nub_a.svg.meta  |    53 +
 .../Vector/Style A/joystick_circle_nub_b.svg       |    18 +
 .../Vector/Style A/joystick_circle_nub_b.svg.meta  |    53 +
 .../Vector/Style A/joystick_circle_nub_c.svg       |    17 +
 .../Vector/Style A/joystick_circle_nub_c.svg.meta  |    53 +
 .../Vector/Style A/joystick_circle_pad_a.svg       |    17 +
 .../Vector/Style A/joystick_circle_pad_a.svg.meta  |    53 +
 .../Vector/Style A/joystick_circle_pad_b.svg       |    17 +
 .../Vector/Style A/joystick_circle_pad_b.svg.meta  |    53 +
 .../Vector/Style A/joystick_circle_pad_c.svg       |    21 +
 .../Vector/Style A/joystick_circle_pad_c.svg.meta  |    53 +
 .../Vector/Style A/joystick_circle_pad_d.svg       |    13 +
 .../Vector/Style A/joystick_circle_pad_d.svg.meta  |    53 +
 .../Vector/Style A/joystick_hexagon_nub_a.svg      |    18 +
 .../Vector/Style A/joystick_hexagon_nub_a.svg.meta |    53 +
 .../Vector/Style A/joystick_hexagon_nub_b.svg      |    18 +
 .../Vector/Style A/joystick_hexagon_nub_b.svg.meta |    53 +
 .../Vector/Style A/joystick_hexagon_nub_c.svg      |    17 +
 .../Vector/Style A/joystick_hexagon_nub_c.svg.meta |    53 +
 .../Vector/Style A/joystick_hexagon_pad_a.svg      |    17 +
 .../Vector/Style A/joystick_hexagon_pad_a.svg.meta |    53 +
 .../Vector/Style A/joystick_hexagon_pad_b.svg      |    17 +
 .../Vector/Style A/joystick_hexagon_pad_b.svg.meta |    53 +
 .../Vector/Style A/joystick_hexagon_pad_c.svg      |    21 +
 .../Vector/Style A/joystick_hexagon_pad_c.svg.meta |    53 +
 .../Vector/Style A/joystick_hexagon_pad_d.svg      |    13 +
 .../Vector/Style A/joystick_hexagon_pad_d.svg.meta |    53 +
 .../Vector/Style A/joystick_polygon_nub_a.svg      |    18 +
 .../Vector/Style A/joystick_polygon_nub_a.svg.meta |    53 +
 .../Vector/Style A/joystick_polygon_nub_b.svg      |    18 +
 .../Vector/Style A/joystick_polygon_nub_b.svg.meta |    53 +
 .../Vector/Style A/joystick_polygon_nub_c.svg      |    17 +
 .../Vector/Style A/joystick_polygon_nub_c.svg.meta |    53 +
 .../Vector/Style A/joystick_polygon_pad_a.svg      |    18 +
 .../Vector/Style A/joystick_polygon_pad_a.svg.meta |    53 +
 .../Vector/Style A/joystick_polygon_pad_b.svg      |    18 +
 .../Vector/Style A/joystick_polygon_pad_b.svg.meta |    53 +
 .../Vector/Style A/joystick_polygon_pad_c.svg      |    22 +
 .../Vector/Style A/joystick_polygon_pad_c.svg.meta |    53 +
 .../Vector/Style A/joystick_polygon_pad_d.svg      |    14 +
 .../Vector/Style A/joystick_polygon_pad_d.svg.meta |    53 +
 .../Vector/Style A/joystick_square_nub_a.svg       |    18 +
 .../Vector/Style A/joystick_square_nub_a.svg.meta  |    53 +
 .../Vector/Style A/joystick_square_nub_b.svg       |    18 +
 .../Vector/Style A/joystick_square_nub_b.svg.meta  |    53 +
 .../Vector/Style A/joystick_square_nub_c.svg       |    17 +
 .../Vector/Style A/joystick_square_nub_c.svg.meta  |    53 +
 .../Vector/Style A/joystick_square_pad_a.svg       |    17 +
 .../Vector/Style A/joystick_square_pad_a.svg.meta  |    53 +
 .../Vector/Style A/joystick_square_pad_b.svg       |    17 +
 .../Vector/Style A/joystick_square_pad_b.svg.meta  |    53 +
 .../Vector/Style A/joystick_square_pad_c.svg       |    21 +
 .../Vector/Style A/joystick_square_pad_c.svg.meta  |    53 +
 .../Vector/Style A/joystick_square_pad_d.svg       |    13 +
 .../Vector/Style A/joystick_square_pad_d.svg.meta  |    53 +
 .../NewUI/mobile-controls-1/Vector/Style B.meta    |     8 +
 .../Vector/Style B/button_bean.svg                 |    13 +
 .../Vector/Style B/button_bean.svg.meta            |    53 +
 .../Vector/Style B/button_circle.svg               |    13 +
 .../Vector/Style B/button_circle.svg.meta          |    53 +
 .../Vector/Style B/button_circle_wide.svg          |    13 +
 .../Vector/Style B/button_circle_wide.svg.meta     |    53 +
 .../Vector/Style B/button_diamond.svg              |    13 +
 .../Vector/Style B/button_diamond.svg.meta         |    53 +
 .../Vector/Style B/button_diamond_wide.svg         |    13 +
 .../Vector/Style B/button_diamond_wide.svg.meta    |    53 +
 .../Vector/Style B/button_hexagon.svg              |    13 +
 .../Vector/Style B/button_hexagon.svg.meta         |    53 +
 .../Vector/Style B/button_hexagon_wide.svg         |    13 +
 .../Vector/Style B/button_hexagon_wide.svg.meta    |    53 +
 .../Vector/Style B/button_square.svg               |    13 +
 .../Vector/Style B/button_square.svg.meta          |    53 +
 .../Vector/Style B/button_square_wide.svg          |    13 +
 .../Vector/Style B/button_square_wide.svg.meta     |    53 +
 .../Vector/Style B/direction_left.svg              |    13 +
 .../Vector/Style B/direction_left.svg.meta         |    53 +
 .../Vector/Style B/direction_right.svg             |    13 +
 .../Vector/Style B/direction_right.svg.meta        |    53 +
 .../mobile-controls-1/Vector/Style B/dpad.svg      |    18 +
 .../mobile-controls-1/Vector/Style B/dpad.svg.meta |    53 +
 .../Vector/Style B/dpad_element_east.svg           |    14 +
 .../Vector/Style B/dpad_element_east.svg.meta      |    53 +
 .../Vector/Style B/dpad_element_north.svg          |    14 +
 .../Vector/Style B/dpad_element_north.svg.meta     |    53 +
 .../Vector/Style B/dpad_element_south.svg          |    14 +
 .../Vector/Style B/dpad_element_south.svg.meta     |    53 +
 .../Vector/Style B/dpad_element_west.svg           |    14 +
 .../Vector/Style B/dpad_element_west.svg.meta      |    53 +
 .../Vector/Style B/dpad_separate.svg               |    38 +
 .../Vector/Style B/dpad_separate.svg.meta          |    53 +
 .../Vector/Style B/dpad_small.svg                  |    18 +
 .../Vector/Style B/dpad_small.svg.meta             |    53 +
 .../Vector/Style B/joystick_circle_nub_a.svg       |    18 +
 .../Vector/Style B/joystick_circle_nub_a.svg.meta  |    53 +
 .../Vector/Style B/joystick_circle_nub_b.svg       |    18 +
 .../Vector/Style B/joystick_circle_nub_b.svg.meta  |    53 +
 .../Vector/Style B/joystick_circle_nub_c.svg       |    17 +
 .../Vector/Style B/joystick_circle_nub_c.svg.meta  |    53 +
 .../Vector/Style B/joystick_circle_pad_a.svg       |    17 +
 .../Vector/Style B/joystick_circle_pad_a.svg.meta  |    53 +
 .../Vector/Style B/joystick_circle_pad_b.svg       |    17 +
 .../Vector/Style B/joystick_circle_pad_b.svg.meta  |    53 +
 .../Vector/Style B/joystick_circle_pad_c.svg       |    21 +
 .../Vector/Style B/joystick_circle_pad_c.svg.meta  |    53 +
 .../Vector/Style B/joystick_circle_pad_d.svg       |    13 +
 .../Vector/Style B/joystick_circle_pad_d.svg.meta  |    53 +
 .../Vector/Style B/joystick_hexagon_nub_a.svg      |    18 +
 .../Vector/Style B/joystick_hexagon_nub_a.svg.meta |    53 +
 .../Vector/Style B/joystick_hexagon_nub_b.svg      |    18 +
 .../Vector/Style B/joystick_hexagon_nub_b.svg.meta |    53 +
 .../Vector/Style B/joystick_hexagon_nub_c.svg      |    17 +
 .../Vector/Style B/joystick_hexagon_nub_c.svg.meta |    53 +
 .../Vector/Style B/joystick_hexagon_pad_a.svg      |    17 +
 .../Vector/Style B/joystick_hexagon_pad_a.svg.meta |    53 +
 .../Vector/Style B/joystick_hexagon_pad_b.svg      |    17 +
 .../Vector/Style B/joystick_hexagon_pad_b.svg.meta |    53 +
 .../Vector/Style B/joystick_hexagon_pad_c.svg      |    21 +
 .../Vector/Style B/joystick_hexagon_pad_c.svg.meta |    53 +
 .../Vector/Style B/joystick_hexagon_pad_d.svg      |    13 +
 .../Vector/Style B/joystick_hexagon_pad_d.svg.meta |    53 +
 .../Vector/Style B/joystick_polygon_nub_a.svg      |    18 +
 .../Vector/Style B/joystick_polygon_nub_a.svg.meta |    53 +
 .../Vector/Style B/joystick_polygon_nub_b.svg      |    18 +
 .../Vector/Style B/joystick_polygon_nub_b.svg.meta |    53 +
 .../Vector/Style B/joystick_polygon_nub_c.svg      |    17 +
 .../Vector/Style B/joystick_polygon_nub_c.svg.meta |    53 +
 .../Vector/Style B/joystick_polygon_pad_a.svg      |    18 +
 .../Vector/Style B/joystick_polygon_pad_a.svg.meta |    53 +
 .../Vector/Style B/joystick_polygon_pad_b.svg      |    18 +
 .../Vector/Style B/joystick_polygon_pad_b.svg.meta |    53 +
 .../Vector/Style B/joystick_polygon_pad_c.svg      |    22 +
 .../Vector/Style B/joystick_polygon_pad_c.svg.meta |    53 +
 .../Vector/Style B/joystick_polygon_pad_d.svg      |    14 +
 .../Vector/Style B/joystick_polygon_pad_d.svg.meta |    53 +
 .../Vector/Style B/joystick_square_nub_a.svg       |    18 +
 .../Vector/Style B/joystick_square_nub_a.svg.meta  |    53 +
 .../Vector/Style B/joystick_square_nub_b.svg       |    18 +
 .../Vector/Style B/joystick_square_nub_b.svg.meta  |    53 +
 .../Vector/Style B/joystick_square_nub_c.svg       |    17 +
 .../Vector/Style B/joystick_square_nub_c.svg.meta  |    53 +
 .../Vector/Style B/joystick_square_pad_a.svg       |    17 +
 .../Vector/Style B/joystick_square_pad_a.svg.meta  |    53 +
 .../Vector/Style B/joystick_square_pad_b.svg       |    17 +
 .../Vector/Style B/joystick_square_pad_b.svg.meta  |    53 +
 .../Vector/Style B/joystick_square_pad_c.svg       |    21 +
 .../Vector/Style B/joystick_square_pad_c.svg.meta  |    53 +
 .../Vector/Style B/joystick_square_pad_d.svg       |    13 +
 .../Vector/Style B/joystick_square_pad_d.svg.meta  |    53 +
 .../NewUI/mobile-controls-1/Vector/Style C.meta    |     8 +
 .../Vector/Style C/button_bean.svg                 |     6 +
 .../Vector/Style C/button_bean.svg.meta            |    53 +
 .../Vector/Style C/button_circle.svg               |     6 +
 .../Vector/Style C/button_circle.svg.meta          |    53 +
 .../Vector/Style C/button_circle_wide.svg          |     6 +
 .../Vector/Style C/button_circle_wide.svg.meta     |    53 +
 .../Vector/Style C/button_diamond.svg              |     6 +
 .../Vector/Style C/button_diamond.svg.meta         |    53 +
 .../Vector/Style C/button_diamond_wide.svg         |     6 +
 .../Vector/Style C/button_diamond_wide.svg.meta    |    53 +
 .../Vector/Style C/button_hexagon.svg              |     6 +
 .../Vector/Style C/button_hexagon.svg.meta         |    53 +
 .../Vector/Style C/button_hexagon_wide.svg         |     6 +
 .../Vector/Style C/button_hexagon_wide.svg.meta    |    53 +
 .../Vector/Style C/button_square.svg               |     6 +
 .../Vector/Style C/button_square.svg.meta          |    53 +
 .../Vector/Style C/button_square_wide.svg          |     6 +
 .../Vector/Style C/button_square_wide.svg.meta     |    53 +
 .../Vector/Style C/direction_left.svg              |     6 +
 .../Vector/Style C/direction_left.svg.meta         |    53 +
 .../Vector/Style C/direction_right.svg             |     6 +
 .../Vector/Style C/direction_right.svg.meta        |    53 +
 .../mobile-controls-1/Vector/Style C/dpad.svg      |     6 +
 .../mobile-controls-1/Vector/Style C/dpad.svg.meta |    53 +
 .../Vector/Style C/dpad_element_east.svg           |     6 +
 .../Vector/Style C/dpad_element_east.svg.meta      |    53 +
 .../Vector/Style C/dpad_element_north.svg          |     6 +
 .../Vector/Style C/dpad_element_north.svg.meta     |    53 +
 .../Vector/Style C/dpad_element_south.svg          |     6 +
 .../Vector/Style C/dpad_element_south.svg.meta     |    53 +
 .../Vector/Style C/dpad_element_west.svg           |     6 +
 .../Vector/Style C/dpad_element_west.svg.meta      |    53 +
 .../Vector/Style C/dpad_separate.svg               |     6 +
 .../Vector/Style C/dpad_separate.svg.meta          |    53 +
 .../Vector/Style C/dpad_small.svg                  |     6 +
 .../Vector/Style C/dpad_small.svg.meta             |    53 +
 .../Vector/Style C/joystick_circle_nub_a.svg       |     6 +
 .../Vector/Style C/joystick_circle_nub_a.svg.meta  |    53 +
 .../Vector/Style C/joystick_circle_nub_b.svg       |     6 +
 .../Vector/Style C/joystick_circle_nub_b.svg.meta  |    53 +
 .../Vector/Style C/joystick_circle_nub_c.svg       |     6 +
 .../Vector/Style C/joystick_circle_nub_c.svg.meta  |    53 +
 .../Vector/Style C/joystick_circle_pad_a.svg       |     6 +
 .../Vector/Style C/joystick_circle_pad_a.svg.meta  |    53 +
 .../Vector/Style C/joystick_circle_pad_b.svg       |     6 +
 .../Vector/Style C/joystick_circle_pad_b.svg.meta  |    53 +
 .../Vector/Style C/joystick_circle_pad_c.svg       |     6 +
 .../Vector/Style C/joystick_circle_pad_c.svg.meta  |    53 +
 .../Vector/Style C/joystick_circle_pad_d.svg       |     6 +
 .../Vector/Style C/joystick_circle_pad_d.svg.meta  |    53 +
 .../Vector/Style C/joystick_hexagon_nub_a.svg      |     6 +
 .../Vector/Style C/joystick_hexagon_nub_a.svg.meta |    53 +
 .../Vector/Style C/joystick_hexagon_nub_b.svg      |     6 +
 .../Vector/Style C/joystick_hexagon_nub_b.svg.meta |    53 +
 .../Vector/Style C/joystick_hexagon_nub_c.svg      |     6 +
 .../Vector/Style C/joystick_hexagon_nub_c.svg.meta |    53 +
 .../Vector/Style C/joystick_hexagon_pad_a.svg      |     6 +
 .../Vector/Style C/joystick_hexagon_pad_a.svg.meta |    53 +
 .../Vector/Style C/joystick_hexagon_pad_b.svg      |     6 +
 .../Vector/Style C/joystick_hexagon_pad_b.svg.meta |    53 +
 .../Vector/Style C/joystick_hexagon_pad_c.svg      |     6 +
 .../Vector/Style C/joystick_hexagon_pad_c.svg.meta |    53 +
 .../Vector/Style C/joystick_hexagon_pad_d.svg      |     6 +
 .../Vector/Style C/joystick_hexagon_pad_d.svg.meta |    53 +
 .../Vector/Style C/joystick_polygon_nub_a.svg      |     6 +
 .../Vector/Style C/joystick_polygon_nub_a.svg.meta |    53 +
 .../Vector/Style C/joystick_polygon_nub_b.svg      |     6 +
 .../Vector/Style C/joystick_polygon_nub_b.svg.meta |    53 +
 .../Vector/Style C/joystick_polygon_nub_c.svg      |     6 +
 .../Vector/Style C/joystick_polygon_nub_c.svg.meta |    53 +
 .../Vector/Style C/joystick_polygon_pad_a.svg      |     6 +
 .../Vector/Style C/joystick_polygon_pad_a.svg.meta |    53 +
 .../Vector/Style C/joystick_polygon_pad_b.svg      |     6 +
 .../Vector/Style C/joystick_polygon_pad_b.svg.meta |    53 +
 .../Vector/Style C/joystick_polygon_pad_c.svg      |     6 +
 .../Vector/Style C/joystick_polygon_pad_c.svg.meta |    53 +
 .../Vector/Style C/joystick_polygon_pad_d.svg      |     6 +
 .../Vector/Style C/joystick_polygon_pad_d.svg.meta |    53 +
 .../Vector/Style C/joystick_square_nub_a.svg       |     6 +
 .../Vector/Style C/joystick_square_nub_a.svg.meta  |    53 +
 .../Vector/Style C/joystick_square_nub_b.svg       |     6 +
 .../Vector/Style C/joystick_square_nub_b.svg.meta  |    53 +
 .../Vector/Style C/joystick_square_nub_c.svg       |     6 +
 .../Vector/Style C/joystick_square_nub_c.svg.meta  |    53 +
 .../Vector/Style C/joystick_square_pad_a.svg       |     6 +
 .../Vector/Style C/joystick_square_pad_a.svg.meta  |    53 +
 .../Vector/Style C/joystick_square_pad_b.svg       |     6 +
 .../Vector/Style C/joystick_square_pad_b.svg.meta  |    53 +
 .../Vector/Style C/joystick_square_pad_c.svg       |     6 +
 .../Vector/Style C/joystick_square_pad_c.svg.meta  |    53 +
 .../Vector/Style C/joystick_square_pad_d.svg       |     6 +
 .../Vector/Style C/joystick_square_pad_d.svg.meta  |    53 +
 .../NewUI/mobile-controls-1/Vector/Style D.meta    |     8 +
 .../Vector/Style D/button_bean.svg                 |     6 +
 .../Vector/Style D/button_bean.svg.meta            |    53 +
 .../Vector/Style D/button_circle.svg               |     6 +
 .../Vector/Style D/button_circle.svg.meta          |    53 +
 .../Vector/Style D/button_circle_wide.svg          |     6 +
 .../Vector/Style D/button_circle_wide.svg.meta     |    53 +
 .../Vector/Style D/button_diamond.svg              |     6 +
 .../Vector/Style D/button_diamond.svg.meta         |    53 +
 .../Vector/Style D/button_diamond_wide.svg         |     6 +
 .../Vector/Style D/button_diamond_wide.svg.meta    |    53 +
 .../Vector/Style D/button_hexagon.svg              |     6 +
 .../Vector/Style D/button_hexagon.svg.meta         |    53 +
 .../Vector/Style D/button_hexagon_wide.svg         |     6 +
 .../Vector/Style D/button_hexagon_wide.svg.meta    |    53 +
 .../Vector/Style D/button_square.svg               |     6 +
 .../Vector/Style D/button_square.svg.meta          |    53 +
 .../Vector/Style D/button_square_wide.svg          |     6 +
 .../Vector/Style D/button_square_wide.svg.meta     |    53 +
 .../Vector/Style D/direction_left.svg              |     6 +
 .../Vector/Style D/direction_left.svg.meta         |    53 +
 .../Vector/Style D/direction_right.svg             |     6 +
 .../Vector/Style D/direction_right.svg.meta        |    53 +
 .../mobile-controls-1/Vector/Style D/dpad.svg      |     6 +
 .../mobile-controls-1/Vector/Style D/dpad.svg.meta |    53 +
 .../Vector/Style D/dpad_element_east.svg           |     6 +
 .../Vector/Style D/dpad_element_east.svg.meta      |    53 +
 .../Vector/Style D/dpad_element_north.svg          |     6 +
 .../Vector/Style D/dpad_element_north.svg.meta     |    53 +
 .../Vector/Style D/dpad_element_south.svg          |     6 +
 .../Vector/Style D/dpad_element_south.svg.meta     |    53 +
 .../Vector/Style D/dpad_element_west.svg           |     6 +
 .../Vector/Style D/dpad_element_west.svg.meta      |    53 +
 .../Vector/Style D/dpad_separate.svg               |     6 +
 .../Vector/Style D/dpad_separate.svg.meta          |    53 +
 .../Vector/Style D/dpad_small.svg                  |     6 +
 .../Vector/Style D/dpad_small.svg.meta             |    53 +
 .../Vector/Style D/joystick_circle_nub_a.svg       |     6 +
 .../Vector/Style D/joystick_circle_nub_a.svg.meta  |    53 +
 .../Vector/Style D/joystick_circle_nub_b.svg       |     6 +
 .../Vector/Style D/joystick_circle_nub_b.svg.meta  |    53 +
 .../Vector/Style D/joystick_circle_nub_c.svg       |     6 +
 .../Vector/Style D/joystick_circle_nub_c.svg.meta  |    53 +
 .../Vector/Style D/joystick_circle_pad_a.svg       |     6 +
 .../Vector/Style D/joystick_circle_pad_a.svg.meta  |    53 +
 .../Vector/Style D/joystick_circle_pad_b.svg       |     6 +
 .../Vector/Style D/joystick_circle_pad_b.svg.meta  |    53 +
 .../Vector/Style D/joystick_circle_pad_c.svg       |     6 +
 .../Vector/Style D/joystick_circle_pad_c.svg.meta  |    53 +
 .../Vector/Style D/joystick_circle_pad_d.svg       |     6 +
 .../Vector/Style D/joystick_circle_pad_d.svg.meta  |    53 +
 .../Vector/Style D/joystick_hexagon_nub_a.svg      |     6 +
 .../Vector/Style D/joystick_hexagon_nub_a.svg.meta |    53 +
 .../Vector/Style D/joystick_hexagon_nub_b.svg      |     6 +
 .../Vector/Style D/joystick_hexagon_nub_b.svg.meta |    53 +
 .../Vector/Style D/joystick_hexagon_nub_c.svg      |     6 +
 .../Vector/Style D/joystick_hexagon_nub_c.svg.meta |    53 +
 .../Vector/Style D/joystick_hexagon_pad_a.svg      |     6 +
 .../Vector/Style D/joystick_hexagon_pad_a.svg.meta |    53 +
 .../Vector/Style D/joystick_hexagon_pad_b.svg      |     6 +
 .../Vector/Style D/joystick_hexagon_pad_b.svg.meta |    53 +
 .../Vector/Style D/joystick_hexagon_pad_c.svg      |     6 +
 .../Vector/Style D/joystick_hexagon_pad_c.svg.meta |    53 +
 .../Vector/Style D/joystick_hexagon_pad_d.svg      |     6 +
 .../Vector/Style D/joystick_hexagon_pad_d.svg.meta |    53 +
 .../Vector/Style D/joystick_polygon_nub_a.svg      |     6 +
 .../Vector/Style D/joystick_polygon_nub_a.svg.meta |    53 +
 .../Vector/Style D/joystick_polygon_nub_b.svg      |     6 +
 .../Vector/Style D/joystick_polygon_nub_b.svg.meta |    53 +
 .../Vector/Style D/joystick_polygon_nub_c.svg      |     6 +
 .../Vector/Style D/joystick_polygon_nub_c.svg.meta |    53 +
 .../Vector/Style D/joystick_polygon_pad_a.svg      |     6 +
 .../Vector/Style D/joystick_polygon_pad_a.svg.meta |    53 +
 .../Vector/Style D/joystick_polygon_pad_b.svg      |     6 +
 .../Vector/Style D/joystick_polygon_pad_b.svg.meta |    53 +
 .../Vector/Style D/joystick_polygon_pad_c.svg      |     6 +
 .../Vector/Style D/joystick_polygon_pad_c.svg.meta |    53 +
 .../Vector/Style D/joystick_polygon_pad_d.svg      |     6 +
 .../Vector/Style D/joystick_polygon_pad_d.svg.meta |    53 +
 .../Vector/Style D/joystick_square_nub_a.svg       |     6 +
 .../Vector/Style D/joystick_square_nub_a.svg.meta  |    53 +
 .../Vector/Style D/joystick_square_nub_b.svg       |     6 +
 .../Vector/Style D/joystick_square_nub_b.svg.meta  |    53 +
 .../Vector/Style D/joystick_square_nub_c.svg       |     6 +
 .../Vector/Style D/joystick_square_nub_c.svg.meta  |    53 +
 .../Vector/Style D/joystick_square_pad_a.svg       |     6 +
 .../Vector/Style D/joystick_square_pad_a.svg.meta  |    53 +
 .../Vector/Style D/joystick_square_pad_b.svg       |     6 +
 .../Vector/Style D/joystick_square_pad_b.svg.meta  |    53 +
 .../Vector/Style D/joystick_square_pad_c.svg       |     6 +
 .../Vector/Style D/joystick_square_pad_c.svg.meta  |    53 +
 .../Vector/Style D/joystick_square_pad_d.svg       |     6 +
 .../Vector/Style D/joystick_square_pad_d.svg.meta  |    53 +
 .../NewUI/mobile-controls-1/Vector/Style E.meta    |     8 +
 .../Vector/Style E/button_bean.svg                 |     8 +
 .../Vector/Style E/button_bean.svg.meta            |    53 +
 .../Vector/Style E/button_circle.svg               |     8 +
 .../Vector/Style E/button_circle.svg.meta          |    53 +
 .../Vector/Style E/button_circle_wide.svg          |     8 +
 .../Vector/Style E/button_circle_wide.svg.meta     |    53 +
 .../Vector/Style E/button_diamond.svg              |     8 +
 .../Vector/Style E/button_diamond.svg.meta         |    53 +
 .../Vector/Style E/button_diamond_wide.svg         |     8 +
 .../Vector/Style E/button_diamond_wide.svg.meta    |    53 +
 .../Vector/Style E/button_hexagon.svg              |     8 +
 .../Vector/Style E/button_hexagon.svg.meta         |    53 +
 .../Vector/Style E/button_hexagon_wide.svg         |     8 +
 .../Vector/Style E/button_hexagon_wide.svg.meta    |    53 +
 .../Vector/Style E/button_square.svg               |     8 +
 .../Vector/Style E/button_square.svg.meta          |    53 +
 .../Vector/Style E/button_square_wide.svg          |     8 +
 .../Vector/Style E/button_square_wide.svg.meta     |    53 +
 .../Vector/Style E/direction_left.svg              |     8 +
 .../Vector/Style E/direction_left.svg.meta         |    53 +
 .../Vector/Style E/direction_right.svg             |     8 +
 .../Vector/Style E/direction_right.svg.meta        |    53 +
 .../mobile-controls-1/Vector/Style E/dpad.svg      |    13 +
 .../mobile-controls-1/Vector/Style E/dpad.svg.meta |    53 +
 .../Vector/Style E/dpad_element_east.svg           |     9 +
 .../Vector/Style E/dpad_element_east.svg.meta      |    53 +
 .../Vector/Style E/dpad_element_north.svg          |     9 +
 .../Vector/Style E/dpad_element_north.svg.meta     |    53 +
 .../Vector/Style E/dpad_element_south.svg          |     9 +
 .../Vector/Style E/dpad_element_south.svg.meta     |    53 +
 .../Vector/Style E/dpad_element_west.svg           |     9 +
 .../Vector/Style E/dpad_element_west.svg.meta      |    53 +
 .../Vector/Style E/dpad_separate.svg               |    21 +
 .../Vector/Style E/dpad_separate.svg.meta          |    53 +
 .../Vector/Style E/dpad_small.svg                  |    13 +
 .../Vector/Style E/dpad_small.svg.meta             |    53 +
 .../Vector/Style E/joystick_circle_nub_a.svg       |     8 +
 .../Vector/Style E/joystick_circle_nub_a.svg.meta  |    53 +
 .../Vector/Style E/joystick_circle_nub_b.svg       |     8 +
 .../Vector/Style E/joystick_circle_nub_b.svg.meta  |    53 +
 .../Vector/Style E/joystick_circle_nub_c.svg       |     7 +
 .../Vector/Style E/joystick_circle_nub_c.svg.meta  |    53 +
 .../Vector/Style E/joystick_circle_pad_a.svg       |    12 +
 .../Vector/Style E/joystick_circle_pad_a.svg.meta  |    53 +
 .../Vector/Style E/joystick_circle_pad_b.svg       |    12 +
 .../Vector/Style E/joystick_circle_pad_b.svg.meta  |    53 +
 .../Vector/Style E/joystick_circle_pad_c.svg       |    16 +
 .../Vector/Style E/joystick_circle_pad_c.svg.meta  |    53 +
 .../Vector/Style E/joystick_circle_pad_d.svg       |     8 +
 .../Vector/Style E/joystick_circle_pad_d.svg.meta  |    53 +
 .../Vector/Style E/joystick_hexagon_nub_a.svg      |     8 +
 .../Vector/Style E/joystick_hexagon_nub_a.svg.meta |    53 +
 .../Vector/Style E/joystick_hexagon_nub_b.svg      |     8 +
 .../Vector/Style E/joystick_hexagon_nub_b.svg.meta |    53 +
 .../Vector/Style E/joystick_hexagon_nub_c.svg      |     7 +
 .../Vector/Style E/joystick_hexagon_nub_c.svg.meta |    53 +
 .../Vector/Style E/joystick_hexagon_pad_a.svg      |    12 +
 .../Vector/Style E/joystick_hexagon_pad_a.svg.meta |    53 +
 .../Vector/Style E/joystick_hexagon_pad_b.svg      |    12 +
 .../Vector/Style E/joystick_hexagon_pad_b.svg.meta |    53 +
 .../Vector/Style E/joystick_hexagon_pad_c.svg      |    16 +
 .../Vector/Style E/joystick_hexagon_pad_c.svg.meta |    53 +
 .../Vector/Style E/joystick_hexagon_pad_d.svg      |     8 +
 .../Vector/Style E/joystick_hexagon_pad_d.svg.meta |    53 +
 .../Vector/Style E/joystick_polygon_nub_a.svg      |     8 +
 .../Vector/Style E/joystick_polygon_nub_a.svg.meta |    53 +
 .../Vector/Style E/joystick_polygon_nub_b.svg      |     8 +
 .../Vector/Style E/joystick_polygon_nub_b.svg.meta |    53 +
 .../Vector/Style E/joystick_polygon_nub_c.svg      |     7 +
 .../Vector/Style E/joystick_polygon_nub_c.svg.meta |    53 +
 .../Vector/Style E/joystick_polygon_pad_a.svg      |    13 +
 .../Vector/Style E/joystick_polygon_pad_a.svg.meta |    53 +
 .../Vector/Style E/joystick_polygon_pad_b.svg      |    13 +
 .../Vector/Style E/joystick_polygon_pad_b.svg.meta |    53 +
 .../Vector/Style E/joystick_polygon_pad_c.svg      |    17 +
 .../Vector/Style E/joystick_polygon_pad_c.svg.meta |    53 +
 .../Vector/Style E/joystick_polygon_pad_d.svg      |     9 +
 .../Vector/Style E/joystick_polygon_pad_d.svg.meta |    53 +
 .../Vector/Style E/joystick_square_nub_a.svg       |     8 +
 .../Vector/Style E/joystick_square_nub_a.svg.meta  |    53 +
 .../Vector/Style E/joystick_square_nub_b.svg       |     8 +
 .../Vector/Style E/joystick_square_nub_b.svg.meta  |    53 +
 .../Vector/Style E/joystick_square_nub_c.svg       |     7 +
 .../Vector/Style E/joystick_square_nub_c.svg.meta  |    53 +
 .../Vector/Style E/joystick_square_pad_a.svg       |    12 +
 .../Vector/Style E/joystick_square_pad_a.svg.meta  |    53 +
 .../Vector/Style E/joystick_square_pad_b.svg       |    12 +
 .../Vector/Style E/joystick_square_pad_b.svg.meta  |    53 +
 .../Vector/Style E/joystick_square_pad_c.svg       |    16 +
 .../Vector/Style E/joystick_square_pad_c.svg.meta  |    53 +
 .../Vector/Style E/joystick_square_pad_d.svg       |     8 +
 .../Vector/Style E/joystick_square_pad_d.svg.meta  |    53 +
 .../NewUI/mobile-controls-1/Vector/Style F.meta    |     8 +
 .../Vector/Style F/button_bean.svg                 |     8 +
 .../Vector/Style F/button_bean.svg.meta            |    53 +
 .../Vector/Style F/button_circle.svg               |     8 +
 .../Vector/Style F/button_circle.svg.meta          |    53 +
 .../Vector/Style F/button_circle_wide.svg          |     8 +
 .../Vector/Style F/button_circle_wide.svg.meta     |    53 +
 .../Vector/Style F/button_diamond.svg              |     8 +
 .../Vector/Style F/button_diamond.svg.meta         |    53 +
 .../Vector/Style F/button_diamond_wide.svg         |     8 +
 .../Vector/Style F/button_diamond_wide.svg.meta    |    53 +
 .../Vector/Style F/button_hexagon.svg              |     8 +
 .../Vector/Style F/button_hexagon.svg.meta         |    53 +
 .../Vector/Style F/button_hexagon_wide.svg         |     8 +
 .../Vector/Style F/button_hexagon_wide.svg.meta    |    53 +
 .../Vector/Style F/button_square.svg               |     8 +
 .../Vector/Style F/button_square.svg.meta          |    53 +
 .../Vector/Style F/button_square_wide.svg          |     8 +
 .../Vector/Style F/button_square_wide.svg.meta     |    53 +
 .../Vector/Style F/direction_left.svg              |     8 +
 .../Vector/Style F/direction_left.svg.meta         |    53 +
 .../Vector/Style F/direction_right.svg             |     8 +
 .../Vector/Style F/direction_right.svg.meta        |    53 +
 .../mobile-controls-1/Vector/Style F/dpad.svg      |    13 +
 .../mobile-controls-1/Vector/Style F/dpad.svg.meta |    53 +
 .../Vector/Style F/dpad_element_east.svg           |     9 +
 .../Vector/Style F/dpad_element_east.svg.meta      |    53 +
 .../Vector/Style F/dpad_element_north.svg          |     9 +
 .../Vector/Style F/dpad_element_north.svg.meta     |    53 +
 .../Vector/Style F/dpad_element_south.svg          |     9 +
 .../Vector/Style F/dpad_element_south.svg.meta     |    53 +
 .../Vector/Style F/dpad_element_west.svg           |     9 +
 .../Vector/Style F/dpad_element_west.svg.meta      |    53 +
 .../Vector/Style F/dpad_separate.svg               |    21 +
 .../Vector/Style F/dpad_separate.svg.meta          |    53 +
 .../Vector/Style F/dpad_small.svg                  |    13 +
 .../Vector/Style F/dpad_small.svg.meta             |    53 +
 .../Vector/Style F/joystick_circle_nub_a.svg       |     8 +
 .../Vector/Style F/joystick_circle_nub_a.svg.meta  |    53 +
 .../Vector/Style F/joystick_circle_nub_b.svg       |     8 +
 .../Vector/Style F/joystick_circle_nub_b.svg.meta  |    53 +
 .../Vector/Style F/joystick_circle_nub_c.svg       |     7 +
 .../Vector/Style F/joystick_circle_nub_c.svg.meta  |    53 +
 .../Vector/Style F/joystick_circle_pad_a.svg       |    12 +
 .../Vector/Style F/joystick_circle_pad_a.svg.meta  |    53 +
 .../Vector/Style F/joystick_circle_pad_b.svg       |    12 +
 .../Vector/Style F/joystick_circle_pad_b.svg.meta  |    53 +
 .../Vector/Style F/joystick_circle_pad_c.svg       |    16 +
 .../Vector/Style F/joystick_circle_pad_c.svg.meta  |    53 +
 .../Vector/Style F/joystick_circle_pad_d.svg       |     8 +
 .../Vector/Style F/joystick_circle_pad_d.svg.meta  |    53 +
 .../Vector/Style F/joystick_hexagon_nub_a.svg      |     8 +
 .../Vector/Style F/joystick_hexagon_nub_a.svg.meta |    53 +
 .../Vector/Style F/joystick_hexagon_nub_b.svg      |     8 +
 .../Vector/Style F/joystick_hexagon_nub_b.svg.meta |    53 +
 .../Vector/Style F/joystick_hexagon_nub_c.svg      |     7 +
 .../Vector/Style F/joystick_hexagon_nub_c.svg.meta |    53 +
 .../Vector/Style F/joystick_hexagon_pad_a.svg      |    12 +
 .../Vector/Style F/joystick_hexagon_pad_a.svg.meta |    53 +
 .../Vector/Style F/joystick_hexagon_pad_b.svg      |    12 +
 .../Vector/Style F/joystick_hexagon_pad_b.svg.meta |    53 +
 .../Vector/Style F/joystick_hexagon_pad_c.svg      |    16 +
 .../Vector/Style F/joystick_hexagon_pad_c.svg.meta |    53 +
 .../Vector/Style F/joystick_hexagon_pad_d.svg      |     8 +
 .../Vector/Style F/joystick_hexagon_pad_d.svg.meta |    53 +
 .../Vector/Style F/joystick_polygon_nub_a.svg      |     8 +
 .../Vector/Style F/joystick_polygon_nub_a.svg.meta |    53 +
 .../Vector/Style F/joystick_polygon_nub_b.svg      |     8 +
 .../Vector/Style F/joystick_polygon_nub_b.svg.meta |    53 +
 .../Vector/Style F/joystick_polygon_nub_c.svg      |     7 +
 .../Vector/Style F/joystick_polygon_nub_c.svg.meta |    53 +
 .../Vector/Style F/joystick_polygon_pad_a.svg      |    13 +
 .../Vector/Style F/joystick_polygon_pad_a.svg.meta |    53 +
 .../Vector/Style F/joystick_polygon_pad_b.svg      |    13 +
 .../Vector/Style F/joystick_polygon_pad_b.svg.meta |    53 +
 .../Vector/Style F/joystick_polygon_pad_c.svg      |    17 +
 .../Vector/Style F/joystick_polygon_pad_c.svg.meta |    53 +
 .../Vector/Style F/joystick_polygon_pad_d.svg      |     9 +
 .../Vector/Style F/joystick_polygon_pad_d.svg.meta |    53 +
 .../Vector/Style F/joystick_square_nub_a.svg       |     8 +
 .../Vector/Style F/joystick_square_nub_a.svg.meta  |    53 +
 .../Vector/Style F/joystick_square_nub_b.svg       |     8 +
 .../Vector/Style F/joystick_square_nub_b.svg.meta  |    53 +
 .../Vector/Style F/joystick_square_nub_c.svg       |     7 +
 .../Vector/Style F/joystick_square_nub_c.svg.meta  |    53 +
 .../Vector/Style F/joystick_square_pad_a.svg       |    12 +
 .../Vector/Style F/joystick_square_pad_a.svg.meta  |    53 +
 .../Vector/Style F/joystick_square_pad_b.svg       |    12 +
 .../Vector/Style F/joystick_square_pad_b.svg.meta  |    53 +
 .../Vector/Style F/joystick_square_pad_c.svg       |    16 +
 .../Vector/Style F/joystick_square_pad_c.svg.meta  |    53 +
 .../Vector/Style F/joystick_square_pad_d.svg       |     8 +
 .../Vector/Style F/joystick_square_pad_d.svg.meta  |    53 +
 .../NewUI/mobile-controls-1/Vector/Style G.meta    |     8 +
 .../Vector/Style G/button_bean.svg                 |     8 +
 .../Vector/Style G/button_bean.svg.meta            |    53 +
 .../Vector/Style G/button_circle.svg               |     8 +
 .../Vector/Style G/button_circle.svg.meta          |    53 +
 .../Vector/Style G/button_circle_wide.svg          |     8 +
 .../Vector/Style G/button_circle_wide.svg.meta     |    53 +
 .../Vector/Style G/button_diamond.svg              |     8 +
 .../Vector/Style G/button_diamond.svg.meta         |    53 +
 .../Vector/Style G/button_diamond_wide.svg         |     8 +
 .../Vector/Style G/button_diamond_wide.svg.meta    |    53 +
 .../Vector/Style G/button_hexagon.svg              |     8 +
 .../Vector/Style G/button_hexagon.svg.meta         |    53 +
 .../Vector/Style G/button_hexagon_wide.svg         |     8 +
 .../Vector/Style G/button_hexagon_wide.svg.meta    |    53 +
 .../Vector/Style G/button_square.svg               |     8 +
 .../Vector/Style G/button_square.svg.meta          |    53 +
 .../Vector/Style G/button_square_wide.svg          |     8 +
 .../Vector/Style G/button_square_wide.svg.meta     |    53 +
 .../Vector/Style G/direction_left.svg              |     8 +
 .../Vector/Style G/direction_left.svg.meta         |    53 +
 .../Vector/Style G/direction_right.svg             |     8 +
 .../Vector/Style G/direction_right.svg.meta        |    53 +
 .../mobile-controls-1/Vector/Style G/dpad.svg      |    13 +
 .../mobile-controls-1/Vector/Style G/dpad.svg.meta |    53 +
 .../Vector/Style G/dpad_element_east.svg           |     9 +
 .../Vector/Style G/dpad_element_east.svg.meta      |    53 +
 .../Vector/Style G/dpad_element_north.svg          |     9 +
 .../Vector/Style G/dpad_element_north.svg.meta     |    53 +
 .../Vector/Style G/dpad_element_south.svg          |     9 +
 .../Vector/Style G/dpad_element_south.svg.meta     |    53 +
 .../Vector/Style G/dpad_element_west.svg           |     9 +
 .../Vector/Style G/dpad_element_west.svg.meta      |    53 +
 .../Vector/Style G/dpad_separate.svg               |    21 +
 .../Vector/Style G/dpad_separate.svg.meta          |    53 +
 .../Vector/Style G/dpad_small.svg                  |    13 +
 .../Vector/Style G/dpad_small.svg.meta             |    53 +
 .../Vector/Style G/joystick_circle_nub_a.svg       |    18 +
 .../Vector/Style G/joystick_circle_nub_a.svg.meta  |    53 +
 .../Vector/Style G/joystick_circle_nub_b.svg       |    18 +
 .../Vector/Style G/joystick_circle_nub_b.svg.meta  |    53 +
 .../Vector/Style G/joystick_circle_nub_c.svg       |    17 +
 .../Vector/Style G/joystick_circle_nub_c.svg.meta  |    53 +
 .../Vector/Style G/joystick_circle_pad_a.svg       |    12 +
 .../Vector/Style G/joystick_circle_pad_a.svg.meta  |    53 +
 .../Vector/Style G/joystick_circle_pad_b.svg       |    12 +
 .../Vector/Style G/joystick_circle_pad_b.svg.meta  |    53 +
 .../Vector/Style G/joystick_circle_pad_c.svg       |    16 +
 .../Vector/Style G/joystick_circle_pad_c.svg.meta  |    53 +
 .../Vector/Style G/joystick_circle_pad_d.svg       |     8 +
 .../Vector/Style G/joystick_circle_pad_d.svg.meta  |    53 +
 .../Vector/Style G/joystick_hexagon_nub_a.svg      |    18 +
 .../Vector/Style G/joystick_hexagon_nub_a.svg.meta |    53 +
 .../Vector/Style G/joystick_hexagon_nub_b.svg      |    18 +
 .../Vector/Style G/joystick_hexagon_nub_b.svg.meta |    53 +
 .../Vector/Style G/joystick_hexagon_nub_c.svg      |    17 +
 .../Vector/Style G/joystick_hexagon_nub_c.svg.meta |    53 +
 .../Vector/Style G/joystick_hexagon_pad_a.svg      |    12 +
 .../Vector/Style G/joystick_hexagon_pad_a.svg.meta |    53 +
 .../Vector/Style G/joystick_hexagon_pad_b.svg      |    12 +
 .../Vector/Style G/joystick_hexagon_pad_b.svg.meta |    53 +
 .../Vector/Style G/joystick_hexagon_pad_c.svg      |    16 +
 .../Vector/Style G/joystick_hexagon_pad_c.svg.meta |    53 +
 .../Vector/Style G/joystick_hexagon_pad_d.svg      |     8 +
 .../Vector/Style G/joystick_hexagon_pad_d.svg.meta |    53 +
 .../Vector/Style G/joystick_polygon_nub_a.svg      |    18 +
 .../Vector/Style G/joystick_polygon_nub_a.svg.meta |    53 +
 .../Vector/Style G/joystick_polygon_nub_b.svg      |    18 +
 .../Vector/Style G/joystick_polygon_nub_b.svg.meta |    53 +
 .../Vector/Style G/joystick_polygon_nub_c.svg      |    17 +
 .../Vector/Style G/joystick_polygon_nub_c.svg.meta |    53 +
 .../Vector/Style G/joystick_polygon_pad_a.svg      |    13 +
 .../Vector/Style G/joystick_polygon_pad_a.svg.meta |    53 +
 .../Vector/Style G/joystick_polygon_pad_b.svg      |    13 +
 .../Vector/Style G/joystick_polygon_pad_b.svg.meta |    53 +
 .../Vector/Style G/joystick_polygon_pad_c.svg      |    17 +
 .../Vector/Style G/joystick_polygon_pad_c.svg.meta |    53 +
 .../Vector/Style G/joystick_polygon_pad_d.svg      |     9 +
 .../Vector/Style G/joystick_polygon_pad_d.svg.meta |    53 +
 .../Vector/Style G/joystick_square_nub_a.svg       |    18 +
 .../Vector/Style G/joystick_square_nub_a.svg.meta  |    53 +
 .../Vector/Style G/joystick_square_nub_b.svg       |    18 +
 .../Vector/Style G/joystick_square_nub_b.svg.meta  |    53 +
 .../Vector/Style G/joystick_square_nub_c.svg       |    17 +
 .../Vector/Style G/joystick_square_nub_c.svg.meta  |    53 +
 .../Vector/Style G/joystick_square_pad_a.svg       |    12 +
 .../Vector/Style G/joystick_square_pad_a.svg.meta  |    53 +
 .../Vector/Style G/joystick_square_pad_b.svg       |    12 +
 .../Vector/Style G/joystick_square_pad_b.svg.meta  |    53 +
 .../Vector/Style G/joystick_square_pad_c.svg       |    16 +
 .../Vector/Style G/joystick_square_pad_c.svg.meta  |    53 +
 .../Vector/Style G/joystick_square_pad_d.svg       |     8 +
 .../Vector/Style G/joystick_square_pad_d.svg.meta  |    53 +
 .../NewUI/mobile-controls-1/Vector/Style H.meta    |     8 +
 .../Vector/Style H/button_bean.svg                 |     8 +
 .../Vector/Style H/button_bean.svg.meta            |    53 +
 .../Vector/Style H/button_circle.svg               |     8 +
 .../Vector/Style H/button_circle.svg.meta          |    53 +
 .../Vector/Style H/button_circle_wide.svg          |     8 +
 .../Vector/Style H/button_circle_wide.svg.meta     |    53 +
 .../Vector/Style H/button_diamond.svg              |     8 +
 .../Vector/Style H/button_diamond.svg.meta         |    53 +
 .../Vector/Style H/button_diamond_wide.svg         |     8 +
 .../Vector/Style H/button_diamond_wide.svg.meta    |    53 +
 .../Vector/Style H/button_hexagon.svg              |     8 +
 .../Vector/Style H/button_hexagon.svg.meta         |    53 +
 .../Vector/Style H/button_hexagon_wide.svg         |     8 +
 .../Vector/Style H/button_hexagon_wide.svg.meta    |    53 +
 .../Vector/Style H/button_square.svg               |     8 +
 .../Vector/Style H/button_square.svg.meta          |    53 +
 .../Vector/Style H/button_square_wide.svg          |     8 +
 .../Vector/Style H/button_square_wide.svg.meta     |    53 +
 .../Vector/Style H/direction_left.svg              |     8 +
 .../Vector/Style H/direction_left.svg.meta         |    53 +
 .../Vector/Style H/direction_right.svg             |     8 +
 .../Vector/Style H/direction_right.svg.meta        |    53 +
 .../mobile-controls-1/Vector/Style H/dpad.svg      |    13 +
 .../mobile-controls-1/Vector/Style H/dpad.svg.meta |    53 +
 .../Vector/Style H/dpad_element_east.svg           |     9 +
 .../Vector/Style H/dpad_element_east.svg.meta      |    53 +
 .../Vector/Style H/dpad_element_north.svg          |     9 +
 .../Vector/Style H/dpad_element_north.svg.meta     |    53 +
 .../Vector/Style H/dpad_element_south.svg          |     9 +
 .../Vector/Style H/dpad_element_south.svg.meta     |    53 +
 .../Vector/Style H/dpad_element_west.svg           |     9 +
 .../Vector/Style H/dpad_element_west.svg.meta      |    53 +
 .../Vector/Style H/dpad_separate.svg               |    21 +
 .../Vector/Style H/dpad_separate.svg.meta          |    53 +
 .../Vector/Style H/dpad_small.svg                  |    13 +
 .../Vector/Style H/dpad_small.svg.meta             |    53 +
 .../Vector/Style H/joystick_circle_nub_a.svg       |    18 +
 .../Vector/Style H/joystick_circle_nub_a.svg.meta  |    53 +
 .../Vector/Style H/joystick_circle_nub_b.svg       |    18 +
 .../Vector/Style H/joystick_circle_nub_b.svg.meta  |    53 +
 .../Vector/Style H/joystick_circle_nub_c.svg       |    17 +
 .../Vector/Style H/joystick_circle_nub_c.svg.meta  |    53 +
 .../Vector/Style H/joystick_circle_pad_a.svg       |    12 +
 .../Vector/Style H/joystick_circle_pad_a.svg.meta  |    53 +
 .../Vector/Style H/joystick_circle_pad_b.svg       |    12 +
 .../Vector/Style H/joystick_circle_pad_b.svg.meta  |    53 +
 .../Vector/Style H/joystick_circle_pad_c.svg       |    16 +
 .../Vector/Style H/joystick_circle_pad_c.svg.meta  |    53 +
 .../Vector/Style H/joystick_circle_pad_d.svg       |     8 +
 .../Vector/Style H/joystick_circle_pad_d.svg.meta  |    53 +
 .../Vector/Style H/joystick_hexagon_nub_a.svg      |    18 +
 .../Vector/Style H/joystick_hexagon_nub_a.svg.meta |    53 +
 .../Vector/Style H/joystick_hexagon_nub_b.svg      |    18 +
 .../Vector/Style H/joystick_hexagon_nub_b.svg.meta |    53 +
 .../Vector/Style H/joystick_hexagon_nub_c.svg      |    17 +
 .../Vector/Style H/joystick_hexagon_nub_c.svg.meta |    53 +
 .../Vector/Style H/joystick_hexagon_pad_a.svg      |    12 +
 .../Vector/Style H/joystick_hexagon_pad_a.svg.meta |    53 +
 .../Vector/Style H/joystick_hexagon_pad_b.svg      |    12 +
 .../Vector/Style H/joystick_hexagon_pad_b.svg.meta |    53 +
 .../Vector/Style H/joystick_hexagon_pad_c.svg      |    16 +
 .../Vector/Style H/joystick_hexagon_pad_c.svg.meta |    53 +
 .../Vector/Style H/joystick_hexagon_pad_d.svg      |     8 +
 .../Vector/Style H/joystick_hexagon_pad_d.svg.meta |    53 +
 .../Vector/Style H/joystick_polygon_nub_a.svg      |    18 +
 .../Vector/Style H/joystick_polygon_nub_a.svg.meta |    53 +
 .../Vector/Style H/joystick_polygon_nub_b.svg      |    18 +
 .../Vector/Style H/joystick_polygon_nub_b.svg.meta |    53 +
 .../Vector/Style H/joystick_polygon_nub_c.svg      |    17 +
 .../Vector/Style H/joystick_polygon_nub_c.svg.meta |    53 +
 .../Vector/Style H/joystick_polygon_pad_a.svg      |    13 +
 .../Vector/Style H/joystick_polygon_pad_a.svg.meta |    53 +
 .../Vector/Style H/joystick_polygon_pad_b.svg      |    13 +
 .../Vector/Style H/joystick_polygon_pad_b.svg.meta |    53 +
 .../Vector/Style H/joystick_polygon_pad_c.svg      |    17 +
 .../Vector/Style H/joystick_polygon_pad_c.svg.meta |    53 +
 .../Vector/Style H/joystick_polygon_pad_d.svg      |     9 +
 .../Vector/Style H/joystick_polygon_pad_d.svg.meta |    53 +
 .../Vector/Style H/joystick_square_nub_a.svg       |    18 +
 .../Vector/Style H/joystick_square_nub_a.svg.meta  |    53 +
 .../Vector/Style H/joystick_square_nub_b.svg       |    18 +
 .../Vector/Style H/joystick_square_nub_b.svg.meta  |    53 +
 .../Vector/Style H/joystick_square_nub_c.svg       |    17 +
 .../Vector/Style H/joystick_square_nub_c.svg.meta  |    53 +
 .../Vector/Style H/joystick_square_pad_a.svg       |    12 +
 .../Vector/Style H/joystick_square_pad_a.svg.meta  |    53 +
 .../Vector/Style H/joystick_square_pad_b.svg       |    12 +
 .../Vector/Style H/joystick_square_pad_b.svg.meta  |    53 +
 .../Vector/Style H/joystick_square_pad_c.svg       |    16 +
 .../Vector/Style H/joystick_square_pad_c.svg.meta  |    53 +
 .../Vector/Style H/joystick_square_pad_d.svg       |     8 +
 .../Vector/Style H/joystick_square_pad_d.svg.meta  |    53 +
 .../NewUI/mobile-controls-1/Visit Kenney.url       |     6 +
 .../NewUI/mobile-controls-1/Visit Kenney.url.meta  |     7 +
 .../NewUI/mobile-controls-1/Visit Patreon.url      |     2 +
 .../NewUI/mobile-controls-1/Visit Patreon.url.meta |     7 +
 .../Assets/textures/Supermercado/Background.mat    |   138 +
 .../textures/Supermercado/Background.mat.meta      |     8 +
 .../textures/Supermercado/Pantalla carga.png       |   Bin 0 -> 495616 bytes
 .../textures/Supermercado/Pantalla carga.png.meta  |   130 +
 .../ProjectSettings/ProjectSettings.asset          |     4 +-
 6767 files changed, 391693 insertions(+), 33129 deletions(-)

=== COMMIT: 65a3b6d | Tue Jun 2 12:39:43 2026 -0600 | Solucionar bug de Power up que se pasaba y no se veia nada y mas anuncios penalizando al jugador en caso de querer salirse o reiniciar nive incluso perder, anuncio al ganar 3 partidads seguidas sin usar el x2, banner que se ve en el menu ===
 ...01.json => index-2026-06-02T18-34-57-0719.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 13680 -> 13932 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 +-
 ...69.json => index-2026-06-02T18-35-02-0118.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 13680 -> 13932 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 +-
 .../PlaceholderAds/Interstitials/1024x768.prefab   | 651 +++++++++++----------
 .../Assets/Scenes/Menu_principal.unity             |   1 +
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |   2 -
 .../Assets/Scripts/Juego/Anuncios/Anuncios.cs      | 179 +++++-
 .../Assets/Scripts/Juego/Gameplay/Pausa.cs         |  15 +-
 .../Scripts/Juego/Menu/PowerUP/Seleccion_PU.cs     |   8 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  12 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  21 +-
 .../ProjectSettings/ProjectSettings.asset          |   4 +-
 19 files changed, 585 insertions(+), 368 deletions(-)

=== COMMIT: 570d60d | Wed Jun 3 11:30:20 2026 -0600 | Solucionar bug de ganar y no aparece anuncio, modificar colisiones, solucionar bug de misiones de no poder retroceder, quitar los banners en ciertas secciones para evitar tapar informacion ===
 ...19.json => index-2026-06-03T17-19-38-0135.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 13932 -> 14184 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   4 ++--
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 ++++++++++-----------
 ...18.json => index-2026-06-03T17-19-43-0392.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 13932 -> 14184 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   4 ++--
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 ++++++++++-----------
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   4 ++--
 Supermarkert Run/Assets/Objetos/Mapa/Fila.prefab   |  20 ++++++++--------
 .../Assets/Objetos/Mapa/Fila3 Variant.prefab       |   4 ++--
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  10 ++++----
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |  22 +++++++++++------
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  12 ++++------
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |   3 +++
 .../ProjectSettings/ProjectSettings.asset          |   4 ++--
 18 files changed, 73 insertions(+), 66 deletions(-)

=== COMMIT: a4225e2 | Thu Jun 4 13:15:53 2026 -0600 | Hacer que el juego se voltee de manera horizontal, bug de atravesar paredes y no se ocultaba el estante, colocar id del juego y los id para anuncios ===
 ...35.json => index-2026-06-04T19-04-33-0684.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 14184 -> 14688 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   6 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 ++---
 ...92.json => index-2026-06-04T18-25-07-0417.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 14184 -> 14688 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 ++---
 .../Resources/GoogleMobileAdsSettings.asset        |   2 +-
 .../AndroidManifest.xml                            |   2 +-
 .../Assets/Resources/PerformanceTestRunInfo.json   |   1 +
 .../Resources/PerformanceTestRunInfo.json.meta     |   7 ++
 .../Resources/PerformanceTestRunSettings.json      |   1 +
 .../Resources/PerformanceTestRunSettings.json.meta |   7 ++
 .../Assets/Scripts/Juego/Anuncios/Anuncios.cs      |  18 ++-
 .../Scripts/Jugador/Camara_Objetos_Desaparecer.cs  |  23 ++--
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  17 ++-
 .../Assets/textures/Menu/IconoJuego.png            | Bin 0 -> 98686 bytes
 .../Assets/textures/Menu/IconoJuego.png.meta       | 130 +++++++++++++++++++++
 .../ProjectSettings/ProjectSettings.asset          |  12 +-
 22 files changed, 223 insertions(+), 63 deletions(-)

=== COMMIT: b2fcb3c | Thu Jun 4 21:17:43 2026 -0600 | Se modifico la UI para que el banner aparezca en caso de error en la API de google de admob que no modifica el anuncio no exista problema con UI y se regreso todo a pruebas ===
 ...84.json => index-2026-06-05T03-12-08-0786.json} |     0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  |   Bin 14688 -> 17460 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |     6 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |   Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |    26 +-
 ...17.json => index-2026-06-05T03-12-12-0493.json} |     0
 .../3x543z5q/armeabi-v7a/.ninja_deps               |   Bin 14688 -> 17460 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |     8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |   Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |    26 +-
 .../Resources/GoogleMobileAdsSettings.asset        |     2 +-
 Supermarkert Run/Assets/Objetos/Muerte 1.prefab    |     2 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |    58 +-
 .../AndroidManifest.xml                            |     2 +-
 .../Assets/Resources/PerformanceTestRunInfo.json   |     1 -
 .../Resources/PerformanceTestRunSettings.json      |     1 -
 .../Resources/PerformanceTestRunSettings.json.meta |     7 -
 .../Assets/Scenes/Menu_principal.unity             |    37 +-
 .../Assets/Scripts/Juego/Anuncios/Anuncios.cs      |    97 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |    10 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |     2 -
 Supermarkert Run/Assets/_Recovery/0.unity          | 24414 +++++++++++++++++++
 .../0.unity.meta}                                  |     4 +-
 .../ProjectSettings/ProjectSettings.asset          |     6 +-
 24 files changed, 24560 insertions(+), 149 deletions(-)

=== COMMIT: 1e8d734 | Wed Jun 10 22:14:26 2026 -0600 | fix: corregir selección de carrito al volver de gameplay y errores de anuncios ===
 ...86.json => index-2026-06-11T02-42-17-0899.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 17460 -> 18720 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 +--
 ...93.json => index-2026-06-11T02-42-24-0057.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 17460 -> 18720 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 +--
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |  18 +-
 .../Assets/Scenes/Menu_principal.unity             | 229 ++++++++++++++++++++-
 .../Assets/Scripts/Juego/Anuncios/Anuncios.cs      | 127 +++++++++---
 .../Scripts/Juego/Gameplay/GuardadoEstructura.cs   |  22 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   5 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |   2 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |   2 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |  16 +-
 .../ProjectSettings/ProjectSettings.asset          |   4 +-
 19 files changed, 405 insertions(+), 88 deletions(-)

=== COMMIT: b848313 | Thu Jun 11 10:39:33 2026 -0600 | Se modificaron las caracteristicas de los scriptable objects de mediano y grande recibiendo un nerfeo, y ya se dice precio a los mapas y obtendras, modificandose dinamicamente si se modifica el idioma o no ===
 ...99.json => index-2026-06-11T04-21-08-0506.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 18720 -> 18972 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   4 +--
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 +++++++++---------
 ...57.json => index-2026-06-11T04-21-12-0679.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 18720 -> 18972 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   4 +--
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 +++++++++---------
 .../Assets/Scenes/Menu_principal.unity             |   2 +-
 .../Scripts/Car Supermarkert/Mediano/Mediano.asset |   2 +-
 .../Car Supermarkert/Mediano/Mediano2.asset        |   2 +-
 .../Car Supermarkert/Mediano/Mediano3.asset        |   2 +-
 .../Car Supermarkert/Mediano/Mediano4.asset        |   2 +-
 .../Car Supermarkert/Mediano/Mediano5.asset        |   4 +--
 .../Scripts/Car Supermarkert/Pesado/Pesado.asset   |   4 +--
 .../Scripts/Car Supermarkert/Pesado/Pesado2.asset  |   4 +--
 .../Scripts/Car Supermarkert/Pesado/Pesado3.asset  |   6 ++---
 .../Scripts/Car Supermarkert/Pesado/Pesado4.asset  |   6 ++---
 .../Scripts/Car Supermarkert/Pesado/Pesado5.asset  |   6 ++---
 .../Assets/Scripts/Juego/Configuraciones/Idioma.cs |  10 ++++++-
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |  30 ++++++++++++++++-----
 23 files changed, 83 insertions(+), 57 deletions(-)

=== COMMIT: d79a6f8 | Mon Jun 15 10:02:41 2026 -0600 | Solucionar un bug de idioma que mostraba lo que te daba el mapa en vez de lo que costaba en idiomas como ingles y portugues ===
 ...06.json => index-2026-06-11T16-46-36-0272.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 18972 -> 19224 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   4 ++--
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 ++++++++++-----------
 ...79.json => index-2026-06-11T16-46-40-0383.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 18972 -> 19224 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   4 ++--
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 ++++++++++-----------
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |   4 ++--
 .../ProjectSettings/ProjectSettings.asset          |   2 +-
 12 files changed, 33 insertions(+), 33 deletions(-)

=== COMMIT: a0db631 | Mon Jun 15 11:18:32 2026 -0600 | Actualizar el readme ===
 README.md                                          | 114 ++++++++++++++++++++-
 ...72.json => index-2026-06-15T16-10-29-0570.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 19224 -> 19476 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 ++---
 ...83.json => index-2026-06-15T16-10-34-0381.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 19224 -> 19476 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 ++---
 .../ProjectSettings/ProjectSettings.asset          |   2 +-
 img/file_01KTT6JDK0JEV70X0TPZDJ872B.png            | Bin 0 -> 220231 bytes
 img/file_01KTT6JDZGS2PMPHHAHR643A7F.png            | Bin 0 -> 235087 bytes
 img/file_01KTT6JE7A5KTA1E7PTXVY6R7Q.png            | Bin 0 -> 362594 bytes
 img/file_01KTT6JEB33MDXTPNNXXPAFB39.png            | Bin 0 -> 283479 bytes
 img/file_01KTT6JFX4S6QYXT38NJPMWV4A.png            | Bin 0 -> 214122 bytes
 17 files changed, 144 insertions(+), 32 deletions(-)

=== COMMIT: d61a76d | Thu Jun 18 18:53:09 2026 -0600 | Modificar el tamaño de los objetos caidos, hacer que la UI de misiones funcione, hacer que el boton de objetos caido se apague si el objeto que iba a recoger desaparece, que la seleccion del mapa elegido anteriormente siga entre partidas, solucionar el bug de multiples estantes encendidos aunque ya se agarraron seguian encendidos mas que nada con mas de un area ahora si se apaga si no es prioridad, hacer que el jugador se frene si o no si va a recoger un objeto de estante, animacion de encogerse de los objetos pequeños señalizando cuando van a desaparecer. ===
 Supermarkert Run/Assets/Resources/Hamburguesa.mat  | 15 ++++-
 .../Assets/Resources/PepelHigienico 1.obj.meta     |  4 +-
 Supermarkert Run/Assets/Resources/caja.obj.meta    |  4 +-
 .../Assets/Resources/escoba 1.obj.meta             |  4 +-
 Supermarkert Run/Assets/Resources/libro.prefab     | 12 ++++
 .../Assets/Resources/manzana 1.obj.meta            |  4 +-
 .../Assets/Resources/microondas 1.obj.meta         |  4 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 67 +++++++++++++++++++
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 75 ++++++++++++++++++++++
 .../Scripts/Juego/Gameplay/Dinero_Obtenido.cs      |  5 +-
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |  1 +
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  | 19 +++---
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  | 43 ++++++++++++-
 .../Assets/Scripts/estantes/Objeto_caido.cs        | 30 ++++++++-
 .../ProjectSettings/ProjectSettings.asset          |  4 +-
 15 files changed, 265 insertions(+), 26 deletions(-)

=== COMMIT: acc8e6d | Tue Jun 23 14:39:07 2026 -0600 | Se soluciono el bug de que si un enemigo golpea al jugador este se puede mover aunque siga dejando cosas, ahora el resbalon es mediante fisicas ===
 ...70.json => index-2026-06-23T20-35-49-0262.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 19476 -> 19980 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   8 ++--
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 +++++-----
 ...81.json => index-2026-06-23T20-35-53-0606.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 19476 -> 19980 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   8 ++--
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 +++++-----
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   2 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  53 ++++++++++++++-------
 .../ProjectSettings/ProjectSettings.asset          |   2 +-
 13 files changed, 73 insertions(+), 52 deletions(-)

=== COMMIT: 9cc1076 | Tue Jun 23 15:57:00 2026 -0600 | se agrego glow a los objetos tirados ===
 .../New_Model/Estantes_escoba_con_escobas.fbx.meta |   4 +-
 .../Resources/PepelHigienico 1Recogible.prefab     | 187 ++++++++++++++++++++
 .../PepelHigienico 1Recogible.prefab.meta          |   7 +
 Supermarkert Run/Assets/Resources/caja.obj.meta    |   2 +-
 .../Assets/Resources/cajaJugoRecogible.prefab      | 187 ++++++++++++++++++++
 .../Assets/Resources/cajaJugoRecogible.prefab.meta |   7 +
 .../Assets/Resources/cajaRecogible.prefab          | 187 ++++++++++++++++++++
 .../Assets/Resources/cajaRecogible.prefab.meta     |   7 +
 .../Assets/Resources/escoba 1Recogible.prefab      | 187 ++++++++++++++++++++
 .../Assets/Resources/escoba 1Recogible.prefab.meta |   7 +
 .../Assets/Resources/hamburguesa 1Recogible.prefab | 187 ++++++++++++++++++++
 .../Resources/hamburguesa 1Recogible.prefab.meta   |   7 +
 .../Assets/Resources/libro 1Recogible.prefab       | 193 +++++++++++++++++++++
 .../Assets/Resources/libro 1Recogible.prefab.meta  |   7 +
 .../Assets/Resources/manzana 1Recogible.prefab     | 187 ++++++++++++++++++++
 .../Resources/manzana 1Recogible.prefab.meta       |   7 +
 .../Assets/Resources/microondas 1Recogible.prefab  | 187 ++++++++++++++++++++
 .../Resources/microondas 1Recogible.prefab.meta    |   7 +
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |  33 ++--
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |  28 ++-
 .../Assets/shader/Glow/ObjetoTirado.mat            |  66 +++++++
 .../Assets/shader/Glow/ObjetoTirado.mat.meta       |   8 +
 22 files changed, 1677 insertions(+), 22 deletions(-)

=== COMMIT: d22bcef | Wed Jun 24 15:10:46 2026 -0600 | Se modificaron los mapas(se agregaron mas obstaculos y se agrego la seccion de frutas), nuevo modelo de escoba cuando se recoge o cae ===
 ...62.json => index-2026-06-24T19-40-08-0086.json} |    0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  |  Bin 19980 -> 20484 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |    8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |   26 +-
 ...06.json => index-2026-06-24T19-40-13-0414.json} |    0
 .../3x543z5q/armeabi-v7a/.ninja_deps               |  Bin 19980 -> 20484 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |    8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |   26 +-
 .../Resources/PlaceholderAds/Banners/BANNER.prefab |  265 +--
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |    1 +
 .../Assets/Objetos/Mapa/Charco_Agua.prefab         |    2 +-
 .../Carrito_aleatorio.prefab                       |    4 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |  122 ++
 .../Escoba.fbx => Resources/escoba 1.fbx}          |  Bin
 .../escoba 1.fbx.meta}                             |    4 +-
 .../Resources/{escoba 1.obj => escoba 11.obj}      |    0
 .../{escoba 1.obj.meta => escoba 11.obj.meta}      |    0
 .../Assets/Resources/escoba 1Recogible.prefab      |   62 +-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   | 2043 ++++++++++++++++----
 .../Mapa grande/NavMesh-NavMesh Surface.asset      |  Bin 102408 -> 197160 bytes
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  | 1860 +++++++++++++-----
 .../Mapa mediano/NavMesh-NavMesh Surface.asset     |  Bin 50976 -> 47640 bytes
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  275 ++-
 .../NavMesh-NavMesh Surface.asset"                 |  Bin 24740 -> 27756 bytes
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |    8 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |    6 +-
 .../Mapa/{SpawMapa1.asset => SpawPequenio.asset}   |   22 +-
 ...pawMapa1.asset.meta => SpawPequenio.asset.meta} |    0
 .../Assets/Scripts/Juego/Mapa/SpawnGrande.asset    |  149 ++
 ...pawnMapa3.asset.meta => SpawnGrande.asset.meta} |    0
 .../Assets/Scripts/Juego/Mapa/SpawnMapa3.asset     |  109 --
 .../Mapa/{SpawnMapa2.asset => SpawnMediano.asset}  |   36 +-
 ...awnMapa2.asset.meta => SpawnMediano.asset.meta} |    0
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |    6 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |    5 +-
 .../Assets/Scripts/estantes/Objeto_random_carro.cs |   11 +-
 Supermarkert Run/Assets/UI Toolkit.meta            |    8 +
 .../Assets/UI Toolkit/UnityThemes.meta             |    8 +
 .../UnityThemes/UnityDefaultRuntimeTheme.tss       |    1 +
 .../UnityThemes/UnityDefaultRuntimeTheme.tss.meta  |   12 +
 .../Assets/shader/Glow/ObjetoTirado.mat            |    4 +-
 Supermarkert Run/Assets/textures/Menu/lupa.png     |  Bin 0 -> 117305 bytes
 .../Assets/textures/Menu/lupa.png.meta             |  130 ++
 .../Assets/textures/UI_GAME/Manzana.png            |  Bin 0 -> 14425 bytes
 .../Assets/textures/UI_GAME/Manzana.png.meta       |  130 ++
 .../ProjectSettings/ProjectSettings.asset          |    2 +-
 48 files changed, 4113 insertions(+), 1240 deletions(-)

=== COMMIT: 3279cc2 | Thu Jun 25 12:48:43 2026 -0600 | Ahora el carro aleatorio tiene 10 objetos random que se pueden recoger, se eliminaron los blenders, y cambios de arquitectura de codigo, ademas de un shade llamado BiliboardPickud ===
 .../Assets/Objetos/New_Model/Escoba.blend          | Bin 121822 -> 0 bytes
 .../Assets/Objetos/New_Model/Escoba.blend.meta     | 110 ---
 .../Assets/Objetos/New_Model/Estante_escobas.blend | Bin 106318 -> 0 bytes
 .../Objetos/New_Model/Estante_escobas.blend.meta   | 110 ---
 .../New_Model/Estantes_escoba_con_escobas.blend    | Bin 119373 -> 0 bytes
 .../Estantes_escoba_con_escobas.blend.meta         | 110 ---
 .../Carrito_aleatorio.prefab                       | 891 ++++++++++++++++++++-
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |  15 +
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  15 +
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  15 +
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   3 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  83 +-
 .../Assets/Scripts/estantes/Estante.cs             |   2 +-
 .../Assets/Scripts/estantes/Objeto_caido.cs        |   6 +-
 .../Assets/Scripts/estantes/Objeto_random_carro.cs | 110 ++-
 .../textures/Carritos/Carrito_Aleatorio.meta       |   8 +
 .../Carrito_Aleatorio/BillboardPickup.shader       |  90 +++
 .../Carrito_Aleatorio/BillboardPickup.shader.meta  |   9 +
 .../Carrito_Aleatorio/Custom_BillboardPickup.mat   |  38 +
 .../Custom_BillboardPickup.mat.meta                |   8 +
 .../Assets/textures/Supermercado/FondoAzul.png     | Bin 0 -> 164686 bytes
 .../textures/Supermercado/FondoAzul.png.meta       | 130 +++
 .../ProjectSettings/ProjectSettings.asset          |   2 +-
 23 files changed, 1387 insertions(+), 368 deletions(-)

=== COMMIT: 1094e8e | Fri Jun 26 13:32:45 2026 -0600 | Ahora ratero su icono tiene animacion, ahora la ruleta tiene sonido, y se soluciono el bug de menu de que el carrito no aparecia, el bug de papel de resource, ahora la funcion para saber si el carro se tomo o no ya es pura, y el carro random ahora si arroja objeto cuando lo recoges ===
 ...86.json => index-2026-06-25T18-56-08-0622.json} |    0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  |  Bin 20484 -> 20736 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |    4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |   26 +-
 ...14.json => index-2026-06-25T18-56-12-0787.json} |    0
 .../3x543z5q/armeabi-v7a/.ninja_deps               |  Bin 20484 -> 20736 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |    4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |   26 +-
 .../Assets/Objetos/Enemigo/Ratero.prefab           |  365 +----
 .../Carrito_aleatorio.prefab                       | 1477 +++++++++++++++++++-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        |    2 +-
 .../Assets/Scenes/Menu_principal.unity             |    6 +-
 .../Assets/Scripts/Juego/Menu/Animacion_Carrito.cs |   13 +-
 .../Assets/Scripts/Juego/Menu/Animacion_NPC.cs     |   27 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |   16 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   18 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   25 +-
 Supermarkert Run/Assets/Scripts/estantes/Areas.cs  |    4 +-
 .../Assets/Scripts/estantes/Objeto_random_carro.cs |  210 ++-
 Supermarkert Run/Assets/Sonidos/Acierto.wav        |  Bin 0 -> 154634 bytes
 Supermarkert Run/Assets/Sonidos/Acierto.wav.meta   |   32 +
 Supermarkert Run/Assets/Sonidos/Desacierto.wav     |  Bin 0 -> 154634 bytes
 .../Assets/Sonidos/Desacierto.wav.meta             |   32 +
 Supermarkert Run/Assets/Sonidos/SonidoRuleta.wav   |  Bin 0 -> 389198 bytes
 .../Assets/Sonidos/SonidoRuleta.wav.meta           |   32 +
 .../Default/button_rectangle_depth_gloss.png.meta  |   24 +-
 .../Red/Default/check_square_grey_cross.png.meta   |   24 +-
 29 files changed, 1863 insertions(+), 504 deletions(-)

=== COMMIT: 1209d0f | Sun Jun 28 16:17:13 2026 -0600 | Solucionar bug de tomar objetos si no tienes espacio y agregar nuevo icono de monedad, y manos rapidas afecta cuando agarras un objeto de estante o carro o cuando los dejas en la caja ===
 ...22.json => index-2026-06-28T21-42-48-0884.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 20736 -> 21240 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 ++---
 ...87.json => index-2026-06-28T21-42-56-0879.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 20736 -> 21240 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 ++---
 Supermarkert Run/Assets/Objetos/Ganar 1.prefab     |  82 ++++++++++++-
 .../Assets/Scenes/Menu_principal.unity             |  10 +-
 Supermarkert Run/Assets/Scripts/Caja/Caja.cs       |   2 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |  22 ++--
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   3 +-
 .../Assets/textures/Jugador_Enemigo/Personaje.mat  |   8 +-
 Supermarkert Run/Assets/textures/Menu/moneda.png   | Bin 0 -> 27802 bytes
 .../Assets/textures/Menu/moneda.png.meta           | 130 +++++++++++++++++++++
 .../ProjectSettings/ProjectSettings.asset          |   2 +-
 19 files changed, 272 insertions(+), 55 deletions(-)

=== COMMIT: ff8a22f | Wed Jul 1 13:29:17 2026 -0600 | Refactorizar la clase car en nuevas clase, creacion del sistema de skins individual guardaod del sistema de niveles y poder del carrito y ahora las skins se selecciona de otra manera, muchos cambios que no puedo contar al 100% porque no los recuerdo todos ===
 Supermarkert Run/Assets/Objetos/BTNSkin.prefab     |  137 ++
 .../Assets/Objetos/BTNSkin.prefab.meta             |    7 +
 .../Assets/Objetos/Enemigo/enemigo.prefab          |   26 -
 .../Assets/Objetos/Jugador/Jugador/Jugador.prefab  |   73 +-
 .../carro.mat                                      |    2 +-
 .../Assets/Scenes/Menu_principal.unity             | 1964 +++++++-------------
 .../Assets/Scripts/AI/EnemigoRatero.cs             |    2 +-
 .../Assets/Scripts/AI/Seleccion_Carrito_Ai.cs      |    3 +-
 .../Assets/Scripts/Car Supermarkert/Car.cs         |  130 +-
 .../Assets/Scripts/Car Supermarkert/CarRuntime.cs  |   31 +
 .../Scripts/Car Supermarkert/CarRuntime.cs.meta    |    2 +
 .../Scripts/Car Supermarkert/Get_Content_Car.cs    |   47 +-
 .../Car Supermarkert/Liviano/CarroPequenio.asset   |   38 +
 .../Liviano/CarroPequenio.asset.meta               |    8 +
 .../Scripts/Car Supermarkert/Personalizacion.cs    |  154 +-
 .../Scripts/Car Supermarkert/SkinDatabase.cs       |   24 +
 .../Scripts/Car Supermarkert/SkinDatabase.cs.meta  |    2 +
 .../Assets/Scripts/Car Supermarkert/Skins.meta     |    8 +
 .../Scripts/Car Supermarkert/Skins/skin1.asset     |   29 +
 .../Car Supermarkert/Skins/skin1.asset.meta        |    8 +
 .../Scripts/Juego/Gameplay/GuardadoEstructura.cs   |   47 +-
 .../Juego/Gameplay/Pase_Conexion_Menu_Gameplay.cs  |   63 +-
 .../Scripts/Juego/Gameplay/SistemaGuardadoNube.cs  |   48 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   50 +-
 .../Assets/Scripts/Juego/Menu/Button_Skin_Item.cs  |   34 +
 .../Scripts/Juego/Menu/Button_Skin_Item.cs.meta    |    2 +
 .../Assets/Scripts/Juego/Menu/NPC_Menu.cs          |   86 -
 .../Assets/Scripts/Juego/Menu/NPC_Menu.cs.meta     |   11 -
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |    2 +-
 Supermarkert Run/Assets/Scripts/Jugador/Mision.cs  |   16 +-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |   41 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |  321 +---
 .../Assets/Scripts/Jugador/Seleccion_Menu_Skin.cs  |  148 ++
 .../Scripts/Jugador/Seleccion_Menu_Skin.cs.meta    |    2 +
 .../Assets/Scripts/estantes/Objeto_random_carro.cs |    1 -
 35 files changed, 1712 insertions(+), 1855 deletions(-)

=== COMMIT: 3f8f21e | Thu Jul 2 13:55:40 2026 -0600 | solucionar el bug de que el carro al comprar no se obtenia, implementar ya el sistema de mejoras y el de skins, y es todo lo que recuerdo ===
 Supermarkert Run/Assets/Objetos/BTNSkin.prefab     |   156 +-
 .../Assets/Scenes/Menu_principal.unity             |  9951 +++++---
 .../Assets/Scripts/Car Supermarkert/Car.cs         |   127 -
 ...rroPequenio.asset => OrquestadorPequenio.asset} |    10 +-
 ...o.asset.meta => OrquestadorPequenio.asset.meta} |     2 +-
 .../OrquestadorAumentadorNivelCarro.cs             |   130 +
 .../OrquestadorAumentadorNivelCarro.cs.meta        |     2 +
 .../Scripts/Car Supermarkert/Personalizacion.cs    |   120 +-
 .../Assets/Scripts/Juego/Configuraciones/Idioma.cs |     5 -
 .../Juego/Gameplay/Pase_Conexion_Menu_Gameplay.cs  |     5 +
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |     2 +
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |     2 +-
 .../Assets/Scripts/Jugador/Seleccion_Menu_Skin.cs  |    36 +-
 Supermarkert Run/Assets/_Recovery/0 (1).unity      | 24095 +++++++++++++++++++
 Supermarkert Run/Assets/_Recovery/0 (1).unity.meta |     7 +
 .../Assets/textures/Menu/Materials/Aumento.mat     |   155 +
 .../textures/Menu/Materials/Aumento.mat.meta       |     8 +
 17 files changed, 30827 insertions(+), 3986 deletions(-)

=== COMMIT: 5b5cf7a | Thu Jul 2 22:24:51 2026 -0600 | agregar las skins de manera automatizada, sonido al mejorar y un icono para el de agarre ===
 .../Assets/Scenes/Menu_principal.unity             |  163 +-
 .../Scripts/Car Supermarkert/Personalizacion.cs    |    8 +-
 .../Scripts/Car Supermarkert/Skins/skin1.asset     | 4413 +++++++++++++++++++-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |    7 +-
 Supermarkert Run/Assets/Sonidos/sonidoMejora.wav   |  Bin 0 -> 327758 bytes
 .../Assets/Sonidos/sonidoMejora.wav.meta           |   32 +
 Supermarkert Run/Assets/textures/Menu/agarre.png   |  Bin 0 -> 85529 bytes
 .../Assets/textures/Menu/agarre.png.meta           |  130 +
 8 files changed, 4730 insertions(+), 23 deletions(-)

=== COMMIT: f7baa55 | Fri Jul 3 23:15:56 2026 -0600 | Creacion de orquestador para mediano y grande, guardado de skins en local, las skins ahora id ===
 .../Assets/Scenes/Menu_principal.unity             | 1106 +++++++++++++++++++-
 .../OrquestadorAumentadorNivelCarro.cs             |   13 +-
 .../Car Supermarkert/OrquestadorGrande.asset       |   46 +
 .../Car Supermarkert/OrquestadorGrande.asset.meta  |    8 +
 .../Car Supermarkert/OrquestadorMediano.asset      |   46 +
 .../Car Supermarkert/OrquestadorMediano.asset.meta |    8 +
 .../{Liviano => }/OrquestadorPequenio.asset        |    2 +
 .../{Liviano => }/OrquestadorPequenio.asset.meta   |    0
 .../Scripts/Car Supermarkert/Personalizacion.cs    |  125 ++-
 .../Scripts/Car Supermarkert/SkinDatabase.cs       |    1 +
 .../Scripts/Juego/Gameplay/GuardadoEstructura.cs   |    6 +-
 .../Scripts/Juego/Gameplay/SistemaGuardadoNube.cs  |    2 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   28 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |    2 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |    2 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |    6 +-
 16 files changed, 1354 insertions(+), 47 deletions(-)

=== COMMIT: b122ad8 | Mon Jul 6 13:13:55 2026 -0600 | Arreglar el bug de que la UI no se actualizaba al comprar, ver porque no se guardan los datos personalizados, y el carro mediano y grande ahora deben comprarse ===
 ...84.json => index-2026-07-06T19-09-20-0039.json} |    0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  |  Bin 21240 -> 21996 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |    8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |   26 +-
 ...79.json => index-2026-07-06T19-09-24-0559.json} |    0
 .../3x543z5q/armeabi-v7a/.ninja_deps               |  Bin 21240 -> 21996 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |    8 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |   26 +-
 .../Assets/Scenes/Menu_principal.unity             |  467 ++++-
 .../Scripts/Car Supermarkert/CarritoComprado.cs    |   10 +
 .../Car Supermarkert/CarritoComprado.cs.meta       |    2 +
 .../Car Supermarkert/CarritoCompradoGrande.asset   |   16 +
 .../CarritoCompradoGrande.asset.meta               |    8 +
 .../Car Supermarkert/CarritoCompradoMediano.asset  |   16 +
 .../CarritoCompradoMediano.asset.meta              |    8 +
 .../Car Supermarkert/CarritoCompradoPequenio.asset |   16 +
 .../CarritoCompradoPequenio.asset.meta             |    8 +
 .../Scripts/Car Supermarkert/Personalizacion.cs    |    9 +-
 .../Scripts/Car Supermarkert/Skins/skin1.asset     | 1895 +++++++++++++-------
 .../Scripts/Juego/Gameplay/GuardadoEstructura.cs   |   30 +-
 .../Juego/Gameplay/Pase_Conexion_Menu_Gameplay.cs  |   16 +
 .../Scripts/Juego/Gameplay/SistemaGuardadoNube.cs  |   15 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   27 +-
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |    1 +
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |   60 +-
 .../Assets/Scripts/Jugador/Seleccion_Menu_Skin.cs  |    1 +
 .../ProjectSettings/ProjectSettings.asset          |    2 +-
 29 files changed, 1999 insertions(+), 676 deletions(-)

=== COMMIT: 7eec719 | Tue Jul 7 18:20:45 2026 -0600 | Agregar Nueva UI para personalizado ===
 ...39.json => index-2026-07-07T02-41-21-0213.json} |    0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  |  Bin 21996 -> 22248 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |    4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |   26 +-
 ...59.json => index-2026-07-07T02-41-25-0901.json} |    0
 .../3x543z5q/armeabi-v7a/.ninja_deps               |  Bin 21996 -> 22248 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |    4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     |  Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |   26 +-
 Supermarkert Run/Assets/Font/ARCO SDF.asset        |  122 +-
 .../Assets/Objetos/BTNPersonalizar.prefab          |  600 ++++
 .../Assets/Objetos/BTNPersonalizar.prefab.meta     |    7 +
 .../Assets/Scenes/Menu_principal.unity             | 3478 +++++---------------
 .../OrquestadorAumentadorNivelCarro.cs             |    1 +
 .../Scripts/Car Supermarkert/Personalizacion.cs    |  156 +-
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |   11 +-
 .../Assets/Scripts/Juego/Mapa/Seleccion_Mapa.cs    |    1 -
 Supermarkert Run/Assets/Scripts/Jugador/DINERO.cs  |    7 +-
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |    2 +
 .../textures/Menu/ButtonPersonalizar (1).png       |  Bin 0 -> 3417 bytes
 .../textures/Menu/ButtonPersonalizar (1).png.meta  |  130 +
 .../textures/Menu/PanelImagenPersonalizado.png     |  Bin 0 -> 19850 bytes
 .../Menu/PanelImagenPersonalizado.png.meta         |  130 +
 Supermarkert Run/Assets/textures/Menu/barras.png   |  Bin 0 -> 9963 bytes
 .../Assets/textures/Menu/barras.png.meta           |  130 +
 .../ProjectSettings/ProjectSettings.asset          |    2 +-
 27 files changed, 2095 insertions(+), 2742 deletions(-)

=== COMMIT: 3819868 | Tue Jul 7 22:16:38 2026 -0600 | Solucion de bugs de UI de personalizacion ===
 .../Assets/Objetos/BTNPersonalizar.prefab          |  12 +-
 .../Assets/Scenes/Menu_principal.unity             |   8 +-
 .../Scripts/Car Supermarkert/Personalizacion.cs    |  25 ++--
 .../Assets/Scripts/Juego/Menu/Seleccion.cs         |   9 +-
 .../Assets/textures/Menu/barras (1).png            | Bin 0 -> 5088 bytes
 .../Assets/textures/Menu/barras (1).png.meta       | 130 +++++++++++++++++++++
 6 files changed, 160 insertions(+), 24 deletions(-)

=== COMMIT: 60cb220 | Thu Jul 9 18:03:29 2026 -0600 | Arreglar bugs de compras de carro, y mejora hacer que aparezca el texto de sin dinero si no hay dinero, un indicador de que tan lejos estas del enemigo, y un manager para rateros ===
 ...13.json => index-2026-07-08T04-24-55-0953.json} |   0
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_deps  | Bin 22248 -> 22500 bytes
 .../RelWithDebInfo/3x543z5q/arm64-v8a/.ninja_log   |   4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 23608 -> 23608 bytes
 .../3x543z5q/arm64-v8a/configure_fingerprint.bin   |  26 +-
 ...01.json => index-2026-07-08T04-25-00-0465.json} |   0
 .../3x543z5q/armeabi-v7a/.ninja_deps               | Bin 22248 -> 22500 bytes
 .../RelWithDebInfo/3x543z5q/armeabi-v7a/.ninja_log |   4 +-
 .../swappywrapper.dir/UnitySwappyWrapper.cpp.o     | Bin 17060 -> 17060 bytes
 .../3x543z5q/armeabi-v7a/configure_fingerprint.bin |  26 +-
 Supermarkert Run/Assets/Objetos/UI 1.prefab        | 585 +++++++++++++++++++++
 Supermarkert Run/Assets/Scenes/Mapa grande.unity   |  31 ++
 Supermarkert Run/Assets/Scenes/Mapa mediano.unity  |  31 ++
 .../Assets/Scenes/Mapa peque\303\261o.unity"       |  35 +-
 .../OcclusionCullingData.asset"                    |   2 +-
 .../Assets/Scenes/Menu_principal.unity             |   8 +-
 .../Assets/Scripts/AI/EnemigoRatero.cs             | 282 ++++++----
 .../Assets/Scripts/AI/RateroManager.cs             | 189 +++++++
 .../Assets/Scripts/AI/RateroManager.cs.meta        |   2 +
 .../Scripts/Juego/Gameplay/Sistema_Guardado.cs     |  26 +-
 .../Scripts/Juego/Gameplay/SliderColorGradient.cs  |  48 ++
 .../Juego/Gameplay/SliderColorGradient.cs.meta     |   2 +
 .../Assets/Scripts/Juego/Mapa/Mapa_Grande.asset    |   2 +-
 .../Assets/Scripts/Juego/Mapa/Mapa_Mediano.asset   |   4 +-
 .../Assets/Scripts/Juego/Mapa/Obstaculos.cs        |   7 +
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  13 +
 .../Scripts/Jugador/Seleccion_Menu_Carrito.cs      |   1 +
 Supermarkert Run/Assets/shader/Invisible.mat       | 141 +++++
 Supermarkert Run/Assets/shader/Invisible.mat.meta  |   8 +
 .../Assets/textures/Menu/Corriendo.png             | Bin 0 -> 7423 bytes
 .../Assets/textures/Menu/Corriendo.png.meta        | 130 +++++
 .../ProjectSettings/ProjectSettings.asset          |   2 +-
 32 files changed, 1455 insertions(+), 154 deletions(-)

=== COMMIT: 89d32eb | Thu Jul 9 18:15:13 2026 -0600 | Solucionar bug de no hacer animacion en ratero ===
 .../Assets/Scripts/AI/EnemigoRatero.cs             | 134 +++------------------
 1 file changed, 19 insertions(+), 115 deletions(-)

=== COMMIT: fe34dc1 | Thu Jul 9 22:08:48 2026 -0600 | Agregar la mejora aleatoria y en player en el metodo estar protegido hacer que si se resbala aunque no tenga choque mayor automaticamente pueda perder un objeto y resolver bugs como recogers objetos durante el resbalon o dejarlos durante el resbalon o choque ===
 .../Carrito_aleatorio.prefab                       |   1 -
 .../Assets/Scenes/Menu_principal.unity             | 854 ++++++++++++++++++++-
 .../Scripts/Car Supermarkert/Personalizacion.cs    | 215 +++++-
 Supermarkert Run/Assets/Scripts/Jugador/Player.cs  |  28 +-
 4 files changed, 1059 insertions(+), 39 deletions(-)
