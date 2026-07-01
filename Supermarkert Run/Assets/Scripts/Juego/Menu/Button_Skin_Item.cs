using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Button_Skin_Item : MonoBehaviour
{
    [SerializeField] private Image iconoColorImage; 
    [SerializeField] private Button botonSkins;

    private int skinID;
    private Seleccion_Menu_Carrito scriptMenu;

    // Configura el botón usando el ID (índice) y la estructura de la skin
    public void ConfigurarBoton(int id, CarSkinData datos, Seleccion_Menu_Carrito menu)
    {
        skinID = id;
        scriptMenu = menu;

        // 3. ¡OPTIMIZACIÓN! Pintamos la imagen base con el color estructural
        iconoColorImage.color = datos.color;

        // 4. Configurar el evento Click de Unity
        botonSkins.onClick.RemoveAllListeners();
        botonSkins.onClick.AddListener(AlHacerClick);
    }

    private void AlHacerClick()
    {
        // Pasamos el ID al menú al presionar el botón
        scriptMenu.Set_Car_Menu(BuildStructs.PCMG.Get_Seleccion(), skinID);
    }


}
