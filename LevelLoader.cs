using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelLoader : MonoBehaviour
    {
        private static int mainMenu_index = 1;








        //------------------ loads a level by name-----------------
        public static void LoadLevel(string levelName)
        {
            // if the scene is in the BuildSettings, load the scene
            if (Application.CanStreamedLevelBeLoaded(levelName))
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("GAMEMANAGER LoadLevel Error: invalid scene specified!");
            }
        }

        //--------------------------------------








        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {

                if (levelIndex == mainMenu_index)
                {
                    MainMenu.Open_T();
                }

                SceneManager.LoadScene(levelIndex);
            }
        }


        public static void Reload_Level()
        {
            LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }


        public static void Load_Next_Level()
        {

            int next_sceneIndex = (SceneManager.GetActiveScene().buildIndex + 1)
                % SceneManager.sceneCountInBuildSettings;

            next_sceneIndex = Mathf.Clamp(next_sceneIndex, mainMenu_index, next_sceneIndex);
            LoadLevel(next_sceneIndex);
        }



        public static void Load_MainMenu()
        {
            LoadLevel(mainMenu_index);
        }

    } 
}
