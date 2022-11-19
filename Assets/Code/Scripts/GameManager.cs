using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public FloatingTextManager floatingTextManager;
    public GameObject tablet;

    private void Update()
    {
        
    }

    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    
    public void GiveTablet()
    {
        floatingTextManager.Show("Recebeu o tablet" ,
            30,
            Color.yellow,
            player.transform.position,
            Vector3.up * 2f,
            1f);
        tablet.gameObject.SetActive(true);
    }

    public void SaveState(int fase)
    {
        if(LoadState() < fase) PlayerPrefs.SetInt("fase",fase);
    }
    
    public int LoadState()
    {
        var fase = PlayerPrefs.GetInt("fase");
        return fase != null ? fase : 0;
    }
    
    public void OnClickExit()
    {
        Application.Quit();

    }
}
