using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIRelevant : MonoBehaviour
{

 //   public Text textScore;
  //  public int score;

 //   private float timeCount;
    //// Start is called before the first frame update
    void Start()
    {
     //   score = 0;
    }

    ////// Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape)&&Time.timeScale!=0)
        //{
        //    Time.timeScale = 0;
        //    pauseEnd.SetActive(true);
        //    pauseBack.SetActive(true);
        //    playerCamera.GetComponent<LookWithMouse>().enabled = false;
        //    Cursor.lockState = CursorLockMode.None;
        //}
        //if (timeCount > 1)
        //{
        //    score += 5;
        //    textScore.text = score.ToString();
        //    timeCount = 0;
        //}
        //else
        //    timeCount += Time.deltaTime;
    }


    public void GameQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void GameStart()
    {
        //camera.SetActive(false);
        //player.SetActive(true);
        //start.SetActive(false);
        //end.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void BackToGame()
    {
        //Time.timeScale = 1f;
        //pauseEnd.SetActive(false);
        //pauseBack.SetActive(false);
        //playerCamera.GetComponent<LookWithMouse>().enabled = true;
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
