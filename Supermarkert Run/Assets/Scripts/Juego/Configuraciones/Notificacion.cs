using UnityEngine;


public struct NotificacionInformacionStruct
{
    public struct Espaniol
    {
        public string titulo;
        public string contenido;
    }

    public struct Ingles
    {
        public string titulo;
        public string contenido;
    }

    public struct Portugues
    {
        public string titulo;
        public string contenido;
    }

    public Espaniol espaniol;
    public Ingles ingles;
    public Portugues portugues;

    // CONSTRUCTOR AUXILIAR: Para instanciar todo rápido en una sola línea
    public NotificacionInformacionStruct(
        string t_es, string c_es,
        string t_en, string c_en,
        string t_pt, string c_pt)
    {
        espaniol.titulo = t_es;
        espaniol.contenido = c_es;

        ingles.titulo = t_en;
        ingles.contenido = c_en;

        portugues.titulo = t_pt;
        portugues.contenido = c_pt;
    }
}

public class Notificacion
{
    /*ALERTA UN POPUP*/
    public static void MostrarAlertaNativa(NotificacionInformacionStruct informacionStruct)
    {
#if UNITY_ANDROID && !UNITY_EDITOR

    var lengua = Idioma.GetLengua();
    string titulo = "", mensaje = "";

    switch(lengua)
        {
            case Idioma.Lengua.ESPANIOL:
                titulo = informacionStruct.espaniol.titulo;
                mensaje = informacionStruct.espaniol.contenido;
                break;
            case Idioma.Lengua.INGLES:
                titulo = informacionStruct.ingles.titulo;
                mensaje = informacionStruct.ingles.contenido;
                break;
            case Idioma.Lengua.PORTUGUES:
                titulo = informacionStruct.portugues.titulo;
                mensaje = informacionStruct.portugues.contenido;
                break;
        }
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
