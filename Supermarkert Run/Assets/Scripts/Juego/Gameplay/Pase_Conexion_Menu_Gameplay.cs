using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pase_Conexion_Menu_Gameplay : MonoBehaviour
{
    static Pase_Conexion_Menu_Gameplay conector;
    public enum Tipo_Carro { PEQUEÑO, MEDIANO, GRANDE }
    Tipo_Carro sel;
    int ele;

    [SerializeField] private SkinDatabase skinDatabase;
    [SerializeField] private OrquestadorAumentadorNivelCarro pequenio, mediano, grande; 

    private void Awake()
    {
        if (Pase_Conexion_Menu_Gameplay.conector != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Pase_Conexion_Menu_Gameplay.conector = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        FindFirstObjectByType<Sistema_Guardado>().CargarCarros(pequenio, mediano, grande);
    }

    public Tipo_Carro Get_Seleccion() => sel;

    public int Get_Eleccion() => ele;

    public void Set_Seleccion_Carro(Tipo_Carro new_value) => sel = new_value;
    public void Set_Seleccion_Skin(int new_value) => ele = new_value;
    
    public CarSkinData GetSkin(int index)
    {
        return skinDatabase.GetSkin(index);
    }

    public void SetSkin(int index, CarSkinData data)
    {
        skinDatabase.skins[index] = data;
    }

    public List<CarSkinData> GetListSkins() => skinDatabase.skins;

    public int GetCountSkins() => skinDatabase.skins.Count;

    public OrquestadorAumentadorNivelCarro GetOrquestador()
    {
        return sel switch
        {
            Tipo_Carro.PEQUEÑO => pequenio,
            Tipo_Carro.MEDIANO => mediano,
            Tipo_Carro.GRANDE => grande,
            _ => null,
        };
    }

    public (OrquestadorAumentadorNivelCarro, OrquestadorAumentadorNivelCarro, OrquestadorAumentadorNivelCarro) GetOrquestadores()
    {
        return (pequenio, mediano, grande);
    }
}
