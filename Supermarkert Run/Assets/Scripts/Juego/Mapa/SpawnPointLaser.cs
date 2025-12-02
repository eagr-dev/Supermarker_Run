using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SpawnPointLaser : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField] private SpawnPointsData spawnData;

    [Header("Configuración Láser")]
    [SerializeField] private float distanciaLaser = 100f;
    [SerializeField] private LayerMask capasDetectables;
    [SerializeField] private KeyCode teclaSpawnear = KeyCode.G;

    [Header("Visualización Láser")]
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Color colorLaser = Color.red;
    [SerializeField] private float anchoLaser = 0.05f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        ConfigurarLineRenderer();
    }

    void Update()
    {
        DibujarLaser();

#if UNITY_EDITOR
        if (Input.GetKeyDown(teclaSpawnear))
        {
            SpawnearPuntoEnLaser();
        }
#endif
    }

    private void ConfigurarLineRenderer()
    {
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.startWidth = anchoLaser;
        lineRenderer.endWidth = anchoLaser;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = colorLaser;
        lineRenderer.endColor = colorLaser;
        lineRenderer.positionCount = 2;
    }

    private void DibujarLaser()
    {
        if (lineRenderer == null || cam == null) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 puntoFinal;

        if (Physics.Raycast(ray, out RaycastHit hit, distanciaLaser, capasDetectables))
        {
            puntoFinal = hit.point;
        }
        else
        {
            puntoFinal = ray.origin + ray.direction * distanciaLaser;
        }

        lineRenderer.SetPosition(0, ray.origin);
        lineRenderer.SetPosition(1, puntoFinal);
    }

    private void SpawnearPuntoEnLaser()
    {
        if (spawnData == null)
        {
            Debug.LogError("No hay SpawnPointsData asignado");
            return;
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, distanciaLaser, capasDetectables))
        {
            // Crear GameObject invisible
            GameObject spawnObject = new GameObject("spawnObject");
            spawnObject.transform.position = hit.point;
            spawnObject.transform.rotation = Quaternion.identity;

#if UNITY_EDITOR
            // Marcar como EditorOnly para que no se incluya en builds
            spawnObject.tag = "EditorOnly";
#endif

            // Guardar en ScriptableObject
            spawnData.puntos.Add(new SpawnPointsData.SpawnPoint(hit.point, Quaternion.identity));

            Debug.Log($"✓ Punto {spawnData.puntos.Count} creado en: {hit.point}");

#if UNITY_EDITOR
            EditorUtility.SetDirty(spawnData);
            AssetDatabase.SaveAssets();
#endif
        }
        else
        {
            Debug.LogWarning("El láser no impactó ninguna superficie");
        }
    }

    private void OnDrawGizmos()
    {
        if (spawnData == null) return;

        Gizmos.color = Color.green;

        foreach (var punto in spawnData.puntos)
        {
            Gizmos.DrawWireSphere(punto.posicion, 0.3f);
        }
    }
}