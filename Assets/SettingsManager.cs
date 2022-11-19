using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Animator Animator;

    public void Open()
    {
        Animator.SetBool("open",true);
    }

    public void Close()
    {
        Animator.SetBool("open",false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("home");
    }

}
