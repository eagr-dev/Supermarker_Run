using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnPointLaser))]
public class SpawnPointLaserEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SpawnPointLaser laser = (SpawnPointLaser)target;

        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox(
            "Apunta con el láser donde quieras crear un spawn point y presiona G.\n" +
            "Se creará un GameObject invisible llamado 'spawnObject' que permanecerá en la escena.",
            MessageType.Info
        );
    }
}

