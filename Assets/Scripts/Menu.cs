using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitter le jeu !");
        Application.Quit(); // Quitte le jeu (ne fonctionne pas dans l'éditeur)
        
        // Pour tester dans l'éditeur Unity
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void Scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
