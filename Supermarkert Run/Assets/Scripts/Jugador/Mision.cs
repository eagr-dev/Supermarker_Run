using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mision : MonoBehaviour
{
    //private List<string> objects_mision = new List<string>();
    private readonly List<System.Tuple<string, bool, bool>> objetos = new();
    [SerializeField] private int misiones_hechas = 0;
    int misiones_hacer = 0;
    public TMP_Text Espacio_Disponible;
    public GameObject Sin_espacio;
    Car carro;
    [SerializeField] private AudioSource Obtener_objeto;
    [SerializeField] private ParticleSystem Punto;
    [SerializeField] private Player player;
    static readonly int misiones_default = 10, maximo_misiones = 100;
    public Vector3 posicion_carro = new();

    [Header("UI Misiones")]
    [SerializeField] private TMP_Text[] text_misiones = new TMP_Text[10];
    [SerializeField] private TMP_Text posicion_texto;
    int inicio_lista = 0, final_lista = 10;
    Color no_tomado = new(0, 0, 0);
    Color tomado = new(1, 0, 0);
    Color en_caja = new(0, 1, 0);

    [Header("Material Para Objetos Caidos")]
    [SerializeField] Material material_objeto;

    private void Start()
    {
        ParticleSystem.EmissionModule emission = Punto.emission;
        emission.enabled = false;
        misiones_hacer = Cantidad_Nivel();
        Set_objetos();
        carro = player.Get_Carro();
        player.Init(carro);
        carro.objetos_actuales = 0;
        Espacio_Disponible.text = carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
        Limpiar_Textos();
        Mostrar();
    }
    public static int Cantidad_Nivel()
    {
        int misiones_obtenibles = (misiones_default + (int)(Nivel.nivel - 1));
        int misiones = misiones_obtenibles <= maximo_misiones ? misiones_obtenibles : maximo_misiones;
        return misiones;
    }

    private void Set_objetos()
    {
        bool defecto = false;
        int iterador = 0;
        int intentos = 0;
        const int maximo_intentos = 100;


        while (objetos.Count < misiones_hacer && iterador < maximo_intentos)
        {
            int area = Random.Range(0, 7);
            int nombre_objeto = Random.Range(0, 9);
            string obj = Areas.Objetos[area][nombre_objeto];
            if (!Se_repite_objeto(obj))
            {
                objetos.Add(new System.Tuple<string, bool, bool>(obj, defecto, defecto));
                iterador++;
            }
            intentos++;
            if (iterador >= misiones_hacer) return;
            if (intentos >= maximo_intentos) return;
        }

        if (objetos.Count < misiones_hacer)
        {
            Debug.LogWarning($"No se pudieron generar suficientes objetos únicos. Se generaron {objetos.Count} de {misiones_hacer}");
        }

    }

    private bool Se_repite_objeto(string obj_comparar)
    {
        var version = new System.Tuple<string, bool, bool>(obj_comparar, false, false);
        return objetos.Contains(version);
    }

    private System.Tuple<int, bool> Se_repite_objeto_tomado(string obj_comparar)
    {
        var version = new System.Tuple<string, bool, bool>(obj_comparar, true, false);
        int index = objetos.FindIndex(new System.Predicate<System.Tuple<string, bool, bool>>(
        tupla => tupla.Item1 == obj_comparar
        ));
        return new System.Tuple<int, bool>(index, objetos.Contains(version));
    }

    // ============================================================
    // ANÁLISIS DEL CHOQUE NORMAL
    // ============================================================
    public void Eliminar_Al_Chocar()
    {
        if (carro.objetos_actuales == 0) return;

        System.Tuple<string, bool, bool> tuple = new("", false, false);
        foreach (var objeto in objetos)
        {
            if (objeto.Item2 && !objeto.Item3)
                tuple = objeto;
        }
        int index = objetos.FindIndex(new System.Predicate<System.Tuple<string, bool, bool>>(
        tupla => tupla == tuple
        ));
        Debug.Log($"el indice es {index}");
        if (index == -1) return;
        objetos[index] = new System.Tuple<string, bool, bool>(tuple.Item1, false, false);
        LanzarObjetoChoco(tuple.Item1, transform.position, transform.forward * 5f);// 5 metros adelante
        misiones_hechas--;
        carro.objetos_actuales--;
        Mostrar();
    }

    // ============================================================
    // ROBO: Objetos vuelan del JUGADOR → ENEMIGO
    // ============================================================
    public void Eliminar_Todo_Al_Chocar_Y_Dar(ref List<string> tuples, Vector3 posicionEnemigo)
    {
        if (carro.objetos_actuales <= 0) return;
        Debug.Log("El jugador está siendo robado");
        tuples.Clear();               
        for (int i = 0; i < objetos.Count; i++)
        {
            if (objetos[i].Item2 && !objetos[i].Item3)
            {
                Debug.Log($"Objeto perdido: {objetos[i].Item1}");
                objetos[i] = new System.Tuple<string, bool, bool>(objetos[i].Item1, false, false);
                tuples.Add(objetos[i].Item1);
                misiones_hechas--;
                // Lanzar del JUGADOR → ENEMIGO
                LanzarObjetoConTrayectoria(objetos[i].Item1, posicion_carro, posicionEnemigo);
            }
        }
        carro.objetos_actuales = 0;
        Mostrar();
    }

    // ============================================================
    // RECUPERACIÓN: Objetos vuelan del ENEMIGO → JUGADOR
    // ============================================================
    public void Recuperar_Todos_Los_Objetos(List<string> objetosRobados, Vector3 posicionEnemigo)
    {
        Debug.Log("¡El jugador recuperó sus objetos!");               
        foreach (string nombreObjeto in objetosRobados)
        {
            int index = objetos.FindIndex(tupla => tupla.Item1 == nombreObjeto);
            if (index != -1)
            {
                // No actualizamos el estado en la lista 'objetos' aquí, en su lugar llamamos
                // a Verificar_Objeto_este_mision() que hará el resto.

                // Lanzar del ENEMIGO → JUGADOR
                Debug.Log($"objeto recuperado {nombreObjeto}");
                if (!Verificar_Objeto_este_mision(nombreObjeto))
                    continue;
                posicion_carro = new(posicion_carro.x, 0.5f, posicion_carro.z);
                LanzarObjetoConTrayectoria(nombreObjeto, posicionEnemigo, posicion_carro);

                // La lógica de actualizar estado, contador y UI se movió a 
                // el método Verificar_Objeto_este_mision(), que será llamado al final de la corrutina 
                // de lanzamiento o si se usa el método de la segunda versión que actualiza directamente.
                // Por ahora, usando el método de la segunda versión para actualizar el estado:

                // Usamos la lógica de la segunda versión para actualizar el estado del objeto
                // *Nota: La implementación original de Recuperar_Todos_Los_Objetos de la segunda versión 
                // no estaba actualizando el estado aquí, solo llamaba a RegresarObjetoRobado y 
                // Verificar_Objeto_este_mision. Mantendremos esa lógica.
                
            }
        }
        Mostrar();
        Espacio_Disponible.text = carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
    }

    public bool Verificar_Objeto_este_mision(string obj)
    {
        if (carro.objetos_actuales > carro.cant_limite_carga)
        {
            StartCoroutine(Tiempo_Aparicion());
            return false;
        }

        var obj_tomo = Se_repite_objeto_tomado(obj);
        if (obj_tomo.Item2 || obj_tomo.Item1 < 0)
            return false;
        if (objetos[obj_tomo.Item1].Item3) return false;

        var emision = Punto.emission;
        emision.enabled = true;
        Obtener_objeto.Play();
        Punto.Play();
        carro.objetos_actuales++;
        objetos[obj_tomo.Item1] = new System.Tuple<string, bool, bool>(
        obj,
        true,
        false
        );
        Espacio_Disponible.text = carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
        misiones_hechas++;
        Mostrar();

        return true;
    }


    public IEnumerator AnimacionTomarObjeto(string obj, Vector3 posicion_estante)
    {
        player.SetDeadZoneJoystick(1000);
        //Esperar a que el jugador se detenga para iniciar
        yield return new WaitForSeconds(1);

        GameObject gameObject = Areas.Get_GameObject(obj);

        GameObject instancia = Instantiate(gameObject);

        Vector3 posicion_carro = player.Get_transform_carro().position;

        Vector3 direccion = posicion_carro - posicion_estante;

        yield return StartCoroutine(AnimarLanzamiento(instancia, posicion_estante, direccion));

        Destroy(instancia);
        player.SetDeadZoneJoystick(0);
    }

    public List<string> Volver_Objetos_Caja()
    {
        List<string> objetos_entregados = new();
        for (int i = 0; i < objetos.Count; i++)
        {
            if (!objetos[i].Item2) continue;
            Debug.Log($"Se dejo al objeto {objetos[i].Item1} en la caja");
            objetos[i] = new System.Tuple<string, bool, bool>(
              objetos[i].Item1,
              false,
              true
            );
            objetos_entregados.Add(objetos[i].Item1);
        }
        Mostrar();
        return objetos_entregados;
    }

    public IEnumerator AnimacionDejarObjetosCaja(Vector3 posicionCaja, string nombreObjeto, float tiempo)
    {
        carro.objetos_actuales--;
        Espacio_Disponible.text = carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
        float scale = 0.5f;

        GameObject objeto = Areas.Get_GameObject(nombreObjeto);
        GameObject instancia = Instantiate(objeto);

        //Modificar la escala
        instancia.transform.localScale = new(scale, scale, scale);

        //CALCULAR LA DIRECCIÓN (la diferencia entre destino y origen)
        Vector3 posicionInicial = transform.position;
        Vector3 direccion = posicionCaja - posicionInicial;

        yield return StartCoroutine(AnimarLanzamiento(instancia, posicionInicial, direccion, tiempo));

        Destroy(instancia);
    }



    private IEnumerator Tiempo_Aparicion()
    {
        Sin_espacio.SetActive(true);
        yield return new WaitForSeconds(1);
        carro.objetos_actuales = 0;
        Sin_espacio.SetActive(false);
    }

    public void Mostrar()
    {
        Espacio_Disponible.text = carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
        posicion_texto.text = inicio_lista.ToString() + " : " + final_lista.ToString();
        for (int iterador = inicio_lista; iterador < final_lista; iterador++)
        {
            text_misiones[iterador % misiones_default].text = objetos[iterador].Item1;
            if (objetos[iterador].Item2 && !objetos[iterador].Item3)
                text_misiones[iterador % misiones_default].color = tomado;
            else if (!objetos[iterador].Item2 && objetos[iterador].Item3)
                text_misiones[iterador % misiones_default].color = en_caja;
            else
                text_misiones[iterador % misiones_default].color = no_tomado;
        }
    }

    private void Limpiar_Textos()
    {
        posicion_texto.text = "";
        for (int i = 0; i < 10; i++)
        {
            text_misiones[i].text = "";
        }
    }

    public void BTN_Pag_Sig()
    {
        inicio_lista = final_lista >= objetos.Count ? inicio_lista : final_lista;
        final_lista = objetos.Count > (final_lista + misiones_default) ? (final_lista + misiones_default) : objetos.Count;
        Limpiar_Textos();
        Mostrar();
    }

    public void BTN_Pag_Ant()
    {
        final_lista = inicio_lista <= 0 ? final_lista : inicio_lista;
        inicio_lista = objetos.Count < (inicio_lista - misiones_default) ? (inicio_lista - misiones_default) : 0;
        Limpiar_Textos();
        Mostrar();
    }

    public float Porcentaje() => (float)misiones_hechas / (float)misiones_hacer;

    public float PorcentajePorNumeroEntregado(int index) => (float)(index + 1) / (float)misiones_hacer;

    public bool Jugador_gano() => Porcentaje() == 1;

    // ============================================================
    // CREAR INSTANCIA DE OBJETO (Unificado)
    // ============================================================
    private GameObject ObjetoLanzado(string name)
    {
        GameObject objeto = Areas.Get_GameObject(name);
        GameObject instancia = Instantiate(objeto);
        List<Material> materials = new();
        instancia.transform.GetChild(0).GetComponent<MeshRenderer>().GetMaterials(materials);
        materials.Add(material_objeto);
        instancia.transform.GetChild(0).GetComponent<MeshRenderer>().SetMaterials(materials);
        return instancia;
    }

    private void InformacionObjeto(ref GameObject instancia, string nombre)
    {
        float size = 3;
        instancia.tag = "Objeto";
        instancia.name = nombre; // Usar el nombre del objeto para el nombre de la instancia
        instancia.AddComponent<Objeto_caido>();
        Rigidbody rb = instancia.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        BoxCollider colider = instancia.AddComponent<BoxCollider>();
        colider.isTrigger = true;
        colider.size = new Vector3(size, size, size);
    }

    // ============================================================
    // MÉTODOS DE LANZAMIENTO (Unificado)
    // ============================================================

    // Para objetos que simplemente caen tras un choque normal (van una distancia fija)
    private void LanzarObjetoChoco(string name, Vector3 positionA, Vector3 positionB)
    {
        // Calcular posición de destino
        Vector3 posicionDestino = positionA + positionB;

        // Verificar si hay obstáculo en el destino
        Vector3 posicionAjustada = VerificarYAjustarDestino(posicionDestino, positionA);

        // Recalcular dirección si se ajustó
        Vector3 direccionAjustada =  posicionAjustada != posicionDestino ? posicionAjustada - positionA : positionB;

        // Crear y lanzar el objeto
        GameObject instancia = ObjetoLanzado(name);
        InformacionObjeto(ref instancia, name);
        StartCoroutine(AnimarLanzamiento(instancia, positionA, direccionAjustada));
    }

    // ============================================================
    // FUNCIÓN: Verificar y ajustar destino
    // ============================================================
    private Vector3 VerificarYAjustarDestino(Vector3 posicionDestino, Vector3 posicionOrigen)
    {
        // Crear verificador temporal
        GameObject verificador = new("Verificador_Temporal");
        verificador.transform.position = posicionDestino;

        // Agregar componentes
        Rigidbody rb = verificador.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        BoxCollider col = verificador.AddComponent<BoxCollider>();
        col.isTrigger = true;
        col.size = Vector3.one * 0.5f; // Tamaño pequeño para detectar

        // Esperar un frame para que el physics detecte
        // Usamos Physics.OverlapBox inmediatamente en su lugar
        Collider[] colisiones = Physics.OverlapBox(
            posicionDestino,
            col.size / 2f,
            Quaternion.identity
        );

        Vector3 posicionFinal = posicionDestino;
        //bool hayObstaculo = false;

        // Verificar si hay obstáculos
        foreach (Collider colision in colisiones)
        {
            // Ignorar jugador y suelo
            if(!colision.CompareTag("Untagged") || colision.name == verificador.name)
                continue;

            //Debug.Log($"Obstáculo detectado en destino: {colision.name}");
            //hayObstaculo = true;

            // Ajustar posición: caer justo delante del obstáculo
            Vector3 direccionAlObstaculo = colision.transform.position - posicionOrigen;
            direccionAlObstaculo.y = 0;
            direccionAlObstaculo = direccionAlObstaculo.normalized;

            // Reducir distancia para caer antes del obstáculo
            float distanciaReducida = Vector3.Distance(posicionOrigen, posicionDestino) * 0.5f;
            posicionFinal = posicionOrigen + direccionAlObstaculo * distanciaReducida;
            posicionFinal.y = posicionDestino.y; // Mantener altura

            break; // Solo considerar el primer obstáculo
        }

        // Destruir verificador
        Destroy(verificador);

        /*if (hayObstaculo)
        {
            Debug.Log($"Destino ajustado: {posicionDestino} → {posicionFinal}");
        }*/

        return posicionFinal;
    }

    // Para objetos robados/recuperados (vuelan de A a B y se destruyen)
    // El bool 'esRecuperacion' se usa si se necesita una lógica específica al final de la animación, 
    // pero por ahora es innecesario ya que la actualización de estado se hace fuera de la corrutina 
    // en Recuperar_Todos_Los_Objetos.
    private void LanzarObjetoConTrayectoria(string name, Vector3 posicionOrigen, Vector3 posicionDestino)
    {
        GameObject instancia = ObjetoLanzado(name);

        // Ajustamos la posición inicial para que parezca que sale de ese punto
        instancia.transform.position = posicionOrigen;

        Vector3 direccion = posicionDestino - posicionOrigen;
        StartCoroutine(AnimarYDestruir(instancia, posicionOrigen, direccion));
        
    }

    // Los métodos LanzarObjetoRobado y RegresarObjetoRobado de la segunda versión quedan obsoletos y simplificados
    // por LanzarObjetoConTrayectoria.

    // ============================================================
    // CORRUTINAS DE ANIMACIÓN (Unificado)
    // ============================================================

    private IEnumerator AnimarYDestruir(GameObject instancia, Vector3 posicionInicio, Vector3 direccion)
    {
        // El AnimarLanzamiento de la segunda versión está preparado para recibir 'metros_volar' (que es la 'direccion') 
        // y calcular el punto final con 'posicionInicial + metros_volar'.
        instancia.transform.localScale = new(0.5f, 0.5f, 0.5f);
        yield return StartCoroutine(AnimarLanzamiento(instancia, posicionInicio, direccion));
        Destroy(instancia);
    }

    private IEnumerator AnimarLanzamiento(GameObject objeto, Vector3 inicio, Vector3 metros_volar, float duracion = 1)
    {
        // Configuración del lanzamiento
        Vector3 posicionInicial = inicio; // Desde donde se lanza
        Vector3 posicionFinal = posicionInicial + metros_volar;

        float altura = 3f; // Altura máxima del arco

        float tiempoTranscurrido = 0f;

        // Rotación aleatoria para efecto visual
        Vector3 rotacionPorSegundo = new(
      Random.Range(0f, 360f),
      Random.Range(0f, 360f),
      Random.Range(0f, 360f)
    );

        while (tiempoTranscurrido < duracion)
        {
            tiempoTranscurrido += Time.deltaTime;
            float progreso = tiempoTranscurrido / duracion; // 0 a 1

            // Interpolación lineal horizontal (X y Z)
            Vector3 posicionActual = Vector3.Lerp(posicionInicial, posicionFinal, progreso);

            // Parábola para la altura (Y)
            // Fórmula: y = -4h * (x - 0.5)^2 + h
            // Esto crea un arco que sube y baja
            float alturaParabola = -4f * altura * Mathf.Pow(progreso - 0.5f, 2f) + altura;
            posicionActual.y = posicionInicial.y + alturaParabola;

            objeto.transform.position = posicionActual;

            // Rotación continua para efecto visual
            objeto.transform.Rotate(rotacionPorSegundo * Time.deltaTime);

            yield return null;
        }

        // Asegurar posición final
        objeto.transform.position = posicionFinal;
    }
}