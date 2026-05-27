using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : BehaviorEnemy
{
    public Areas.Area_product Tag;
    enum EstanteVisible { CAJA = 11, JUGO, ESCOBA, COMIDA, LIBRO, MANZANA, TECNOLOGIA, ROLLO};
    EstanteVisible estanteVisible;

    const int primerEstante = 1;
    const int cantidadEstantes = 10;

    private List<int> Get_List_Rand()
    {
        int posicionUltimoHijo = cantidadEstantes + primerEstante;
        List<int> list_return = new();

        for(int i = primerEstante; i < posicionUltimoHijo; ++i)
        {
            list_return.Add(i);
        }

        for(int i = 0; i < Areas.objetos_contiene;i++)
        {
            int random = Random.Range(0, Areas.objetos_contiene);
            int aux = list_return[i];
            list_return[i] = list_return[random];
            list_return[random] = aux; 
        }

        return list_return;
    }

    private void Acomodar_Estantes()
    {
        int count = 0;
        Estante[] hijosEstantes = transform.GetComponentsInChildren<Estante>();
        var list = Get_List_Rand();
        foreach (Estante estante in hijosEstantes)
        {
            estante.transform.SetSiblingIndex(list[count]);
            estante.Set_Product(Tag, count++);
        }
    }

    private void HacerEstanteCorrespondienteVisible()
    {
        transform.GetChild((int)EstanteVisible.CAJA).gameObject.SetActive(false);
        switch(Tag)
        {
            case Areas.Area_product.Articulos_Escolares:
                estanteVisible = EstanteVisible.LIBRO;
                break;
            case Areas.Area_product.Bebidas:
                estanteVisible = EstanteVisible.JUGO;
                break;
            case Areas.Area_product.Carros:
                estanteVisible = EstanteVisible.CAJA;
                break;
            case Areas.Area_product.Comida:
                estanteVisible = EstanteVisible.COMIDA;
                break;
            case Areas.Area_product.Electrodomesticos:
                estanteVisible = EstanteVisible.TECNOLOGIA;
                break;
            case Areas.Area_product.Fruta_Verdura:
                estanteVisible = EstanteVisible.MANZANA;
                break;
            case Areas.Area_product.Higiene_Personal:
                estanteVisible = EstanteVisible.ROLLO;
                break;
            case Areas.Area_product.Limpieza_Hogar:
                estanteVisible = EstanteVisible.ESCOBA;
                break;
            case Areas.Area_product.NINGUNO:
                estanteVisible = EstanteVisible.CAJA;
                break;
        }
        Debug.Log($"el estante que se vera es {estanteVisible}");
        transform.GetChild((int)estanteVisible).gameObject.SetActive(true);
    }

    public void OcultarEstante()
    {
        transform.GetChild((int)estanteVisible).gameObject.SetActive(false);
    }

    public void VisibilizarEstante()
    {
        transform.GetChild((int)estanteVisible).gameObject.SetActive(true);
    }

    private void Start()
    {
        Acomodar_Estantes();
        HacerEstanteCorrespondienteVisible();
    }

    protected override void OnColisionConJugador(Collision collision)
    {
        Mision mision = collision.gameObject.GetComponent<Mision>();
        mision.Eliminar_Al_Chocar();
    }
}
