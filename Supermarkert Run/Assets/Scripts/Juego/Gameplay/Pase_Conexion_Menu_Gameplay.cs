using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pase_Conexion_Menu_Gameplay : MonoBehaviour
{
    static Pase_Conexion_Menu_Gameplay conector;
    public enum Tipo_Carro { PEQUEÑO, MEDIANO, GRANDE }
    Tipo_Carro sel;
    int ele, eleccionSombrero;

    [SerializeField] private SkinDatabase skinDatabase;
    [SerializeField] private OrquestadorAumentadorNivelCarro pequenio, mediano, grande; 
    [SerializeField] private CarritoComprado pequenio_comprado ,mediano_comprado, grande_comprado;
    [SerializeField] private SombreroDatabase sombreroDatabase;

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
        Debug.LogWarning($"Los carros son de este tipo en compra {pequenio_comprado.tipo_Carro}, {mediano_comprado.tipo_Carro}, {grande_comprado.tipo_Carro}");
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


    public CarritoComprado GetComprado(Tipo_Carro tipo_Carro)
    {
        switch (tipo_Carro)
        {
            case Tipo_Carro.PEQUEÑO: return pequenio_comprado; 
            case Tipo_Carro.MEDIANO : return mediano_comprado; 
            case Tipo_Carro.GRANDE : return grande_comprado; 
        }


        return null;
    }


    public int GetCountSombreros() => sombreroDatabase.sombreros.Count;

    public SombreroData GetSombrero(int i) => sombreroDatabase.sombreros[i];

    public void SetSombreroComprado(int id) => sombreroDatabase.SetComprar(id);

    public List<SombreroData> GetSombrerosComprados => sombreroDatabase.GetComprados();

    public void SetSombrero(int index, SombreroData data)
    {
        sombreroDatabase.sombreros[index] = data;
    }

    public int Get_Eleccion_Sombrero() => eleccionSombrero;
    public void Set_Eleccion_Sombrero(int new_value) => eleccionSombrero = new_value;
}
