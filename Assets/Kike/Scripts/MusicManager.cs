using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
            audioSource = GetComponent<AudioSource>(); // Obtener el AudioSource

            // Reproducir m�sica si no est� sonando
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // Asegurarse de que la m�sica comience
            }
        }
        else
        {
            Destroy(gameObject); // Si ya hay una instancia, destruir este objeto
        }
    }

   
}

