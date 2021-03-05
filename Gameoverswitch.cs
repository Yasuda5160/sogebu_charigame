using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Gameoverswitch : MonoBehaviour
{
    Camera player;
    PlayerView PlayerView;
    // Use this for initialization
    void Start()
    {
        player = Camera.main;
        PlayerView = player.GetComponent<PlayerView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerView.touch)
        {
            SceneManager.LoadScene("Gameover");
        }
    }
}