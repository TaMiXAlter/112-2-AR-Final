using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scenes : MonoBehaviour
{
    void Change_Scenes(int sceneIndex){
        SceneManager.LoadScene(sceneIndex);
    }
}
