using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject TextContainer;
    public GameObject TextPrefab;

    private List<FloatingText> _floatingTexts = new List<FloatingText>();

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        var floatingText = GetFloatingText();
        floatingText.Text.text = msg;
        floatingText.Text.fontSize = fontSize;
        floatingText.Text.color = color;
        floatingText.Position = position;
        floatingText.Motion = motion;
        floatingText.Duration = duration;
        floatingText.Show();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = _floatingTexts.Find(t => !t.Active);


        if (txt == null)
        {
            txt = new FloatingText();
            txt.Go = Instantiate(TextPrefab);
            txt.Go.transform.SetParent(TextContainer.transform);
            txt.Text = txt.Go.GetComponent<Text>();

            _floatingTexts.Add(txt);
        }

        return txt;
    }

    private void Update()
    {
        foreach (var txt in _floatingTexts)
        {
            txt.UpdateFloatingText();
        }
    }
}