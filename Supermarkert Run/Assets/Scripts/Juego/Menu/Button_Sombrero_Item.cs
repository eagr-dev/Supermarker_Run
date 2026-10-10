using UnityEngine;
using UnityEngine.UI;

public class Button_Sombrero_Item : MonoBehaviour
{
    [SerializeField] private Image iconoColorImage;
    [SerializeField] private Button botonSkins;

    private int skinID;
    private SeleccionSombrero scriptMenu;

    public void ConfigurarBoton(int id, SombreroData datos, SeleccionSombrero menu)
    {
        skinID = id;
        scriptMenu = menu;

        // 3. ¡OPTIMIZACIÓN! Pintamos la imagen base con el color estructural
        iconoColorImage.sprite = datos.icon;

        // 4. Configurar el evento Click de Unity
        botonSkins.onClick.RemoveAllListeners();
        botonSkins.onClick.AddListener(AlHacerClick);
    }

    private void AlHacerClick()
    {
        // Pasamos el ID al menú al presionar el botón
        scriptMenu.SetSombrero(skinID);
    }
}
