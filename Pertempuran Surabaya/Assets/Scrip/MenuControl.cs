using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
   public GameObject video;
   public void ButtonStart()
   {
   		SceneManager.LoadScene(1);
        video.SetActive(true);
   }
   public void ButtonCredit()
   {
   		SceneManager.LoadScene(2);
   }
   public void ButtonQuit()
   {
   		Application.Quit();
   }
}
