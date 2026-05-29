using UnityEngine;

public class Notificacion
{
    /*ALERTA UN POPUP*/
    public static void MostrarAlertaNativa(string titulo, string mensaje)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
    AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

    currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
        AndroidJavaObject dialogBuilder = new AndroidJavaObject("android.app.AlertDialog$Builder", currentActivity);
        
        dialogBuilder.Call<AndroidJavaObject>("setTitle", titulo);
        dialogBuilder.Call<AndroidJavaObject>("setMessage", mensaje);
        dialogBuilder.Call<AndroidJavaObject>("setCancelable", true);
        dialogBuilder.Call<AndroidJavaObject>("setPositiveButton", "OK", null);
        
        AndroidJavaObject dialog = dialogBuilder.Call<AndroidJavaObject>("create");
        dialog.Call("show");
    }));
#endif
    }
}
