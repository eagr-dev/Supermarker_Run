using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

// ========== SCRIPTABLE OBJECT ==========
[CreateAssetMenu(fileName = "SpawnPointsData", menuName = "Game/Spawn Points Data")]
public class SpawnPointsData : ScriptableObject
{
    [System.Serializable]
    public class SpawnPoint
    {
        public Vector3 posicion;
        public Quaternion rotacion;

        public SpawnPoint(Vector3 pos, Quaternion rot)
        {
            posicion = pos;
            rotacion = rot;
        }
    }

    public List<SpawnPoint> puntos = new List<SpawnPoint>();
}
