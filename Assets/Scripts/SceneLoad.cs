using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
   public void LoadSceneByName(int sceneNumber)
    {
      SceneManager.LoadScene(sceneNumber);; // Loads the scene and replaces the current one
    }
}
