using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> Buttons;

    public void Start()
    {
        for (int i = 1; i < Buttons.Count ; i++)
        {
            CanSelect(i,Buttons[i - 1]);
        }
    }

    public void StartGame()
    {
        var fase = GameManager.Instance.LoadState();
        if (fase != 0)
        {
            SceneManager.LoadScene("level_selection");
        }
        else
        {
            SceneManager.LoadScene("room_1");
        }
    }

    public void Load(int fase)
    {
        SceneManager.LoadScene("room_" + fase);
    }

    public void CanSelect(int fase, GameObject obj)
    {
        if (GameManager.Instance.LoadState() >= fase)
        {
            obj.SetActive(true);
        }
    }
}
