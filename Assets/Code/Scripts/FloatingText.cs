using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
  public bool Active;
  public GameObject Go;
  public Text Text;
  public Vector3 Motion;
  public Vector3 Position;
  public float Duration;
  public float LastShown;

  public void Show()
  {
    LastShown = Time.time;
    SetActive(true);

  }

  public void Hide()
  {
    SetActive(false);
  }

  private void SetActive(bool active)
  {
    Active = active;
    Go.SetActive(Active);
  }

  public void UpdateFloatingText()
  {
    if (Active)
    {
      if (Time.time - LastShown > Duration)
      {
        Hide();
      }

      Position += (Motion) * Time.deltaTime;

      Go.transform.position = Camera.main.WorldToScreenPoint(Position);
    }
  }

}
