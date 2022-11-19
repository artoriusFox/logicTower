using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Code;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodeController : MonoBehaviour
{
    public Animator AnimatorCodeInterface;
    public TMP_InputField Code;
    public Robot MainTarget;
    private List<Function> _sequence = new List<Function>();
    private MainLoop _loop;
    public void OpenCodeInterface()
    {
        GameManager.Instance.player.StopPlayer = true;
        AnimatorCodeInterface.SetTrigger("Show");
    }
    public void HideCodeInterface()
    {
        GameManager.Instance.player.StopPlayer = false;
        AnimatorCodeInterface.SetTrigger("Hide");
    }

    public void RunCode()
    {
        if (!MainTarget.Blocked)
        {
            ConvertCodeToFunctions();
            _loop = new MainLoop(MainTarget, _sequence);
            var coruotine = StartCoroutine(_loop.Play());
            MainTarget.SetCoroutinePlaying(coruotine);
            MainTarget.SetBlocked();
        }
        
        GameManager.Instance.floatingTextManager.Show("bip-bop",
            20,
            Color.green,
            MainTarget.transform.position,
            Vector3.up * 0.5f,
            0.5f);
    }

    private void ConvertCodeToFunctions()
    {
        _sequence = new List<Function>();
        var funcions = Code.text.Split(";");
        var insideLoop = false;
        var listFunctionsLoop = new List<Function>();
        var loopTimes = 0;
        foreach (var f in funcions)
        {
            if (f.Contains("faça"))
            {
                loopTimes = GetLoopTimes(f);
                insideLoop = true;
                continue;
            }

           
            if (f.Contains("fim"))
            {
                insideLoop = false;
                for (int i = 1; i < loopTimes; i++)
                {
                    _sequence.AddRange(listFunctionsLoop);
                }
                listFunctionsLoop = new List<Function>();
                continue;
            }
            
            int times = GetTimes(f);
            
            if (insideLoop)
            {
                ConvertCodeToFunctions(times, f, listFunctionsLoop);

            }

            
            ConvertCodeToFunctions(times, f, _sequence);
            
        }
    }

    private int GetLoopTimes(string lineCode)
    {
        int startIndex = lineCode.IndexOf("(", StringComparison.Ordinal);
        int endIndex = lineCode.IndexOf(" vezes)", StringComparison.Ordinal); 
        var number = lineCode.Substring(startIndex + 1, endIndex - startIndex - 1);
        if (String.IsNullOrEmpty(number))
        {
            return 1;
        }
        Debug.Log("loop de "+ number);
        return int.Parse(number);
    }

    private void ConvertCodeToFunctions(int times, string function ,List<Function> sequence)
    {
        for (int i = 0; i < times; i++)
        {
            if (function.Contains("AndarParaDireita")) AddOnSequence(GetFunction("AndarParaDireita"), sequence);
            else if (function.Contains("AndarParaCima")) AddOnSequence(GetFunction("AndarParaCima"), sequence);
            else if (function.Contains("AndarParaBaixo")) AddOnSequence(GetFunction("AndarParaBaixo"), sequence);
            else if (function.Contains("AndarParaEsquerda")) AddOnSequence(GetFunction("AndarParaEsquerda"), sequence);
            else
            {
                GameManager.Instance.floatingTextManager.Show("bip-bop :( Não conheço o comando:" + function,
                    20,
                    Color.red,
                    MainTarget.transform.position,
                    Vector3.up * 0.8f,
                    1.5f);
            }
        }
    }

    private Function GetFunction(String function)
    {
        switch (function)
        {
            case "AndarParaDireita": return new MoveFoward(function);
            case "AndarParaCima": return new MoveUp(function);
            case "AndarParaBaixo": return new MoveDown(function);
            case "AndarParaEsquerda": return new MoveBack(function);
        }

        return null;
    }

    private void AddOnSequence(Function function, List<Function> sequence)
    {
        AddOnSequence(function,10,sequence);
    }

    private void AddOnSequence(Function function, int times, List<Function> sequence)
    {
        for (int i = 0; i < times; i++)
        {
            sequence.Add(function);
        }
        
    }

    public int GetTimes(string lineCode)
    {
        var number = "";
        try
        {
            if (lineCode.Length == 0)
            {
                return 0;
            }

            if (!lineCode.Contains("(") || !lineCode.Contains(")"))
                return 0;

            int startIndex = lineCode.IndexOf("(", StringComparison.Ordinal);
            int endIndex = lineCode.IndexOf(")", StringComparison.Ordinal); 
            number = lineCode.Substring(startIndex + 1, endIndex - startIndex - 1);
            if (String.IsNullOrEmpty(number))
            {
                return 1;
            }

            return int.Parse(number);
        }
        catch
        {
            GameManager.Instance.floatingTextManager.Show(number+"? bip-bop :(",
                20,
                Color.red,
                MainTarget.transform.position,
                Vector3.up * 0.8f,
                1.5f);
        }

        return 0;
    }

    public void AddCode(string code)
    {
        if (this.Code.text.Trim() != "") code = "\n"+code;
        this.Code.text += code;
    }

    // public void addLoop()
    // {
    //     AddCode("faça(X vezes)");
    //     AddCode("inicio;");
    //     AddCode("");
    //     AddCode("fim;");
    // }
}
