using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gmanager : MonoBehaviour
{

    public GameObject Title;
    public GameObject Rtry;
    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }
    private GameObject[] enemy;
    private GameObject[] player;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(1920, 1080, false);
        panel.SetActive(false);
        Title.SetActive(false);
        Rtry.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectsWithTag("Player");
        if(enemy.Length==0)
        {
            panel.SetActive(true);
            Title.SetActive(true);
        }
        if(player.Length==0)
        {
            Rtry.SetActive(true);
            Title.SetActive(true);
        }
    }
}
