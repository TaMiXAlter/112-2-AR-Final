using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Scenes_Manager : MonoBehaviour
{
    public void Change_To_Scene(int scene_index){

        SceneManager.LoadScene(scene_index);
    }
}
