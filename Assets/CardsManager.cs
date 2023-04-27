using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public Card MainCard;
    public string[] Ejercicios;

    public GameObject Credits;
    public GameObject Erase;

    int _currentExcercise;

    public void Start()
    {
        _currentExcercise = 0;
        SetupCard();
    }

    public void SwapExcercise()
    {
        _currentExcercise++;
        if (_currentExcercise >= Ejercicios.Length)
            _currentExcercise = 0;

        SetupCard();
    }

    public void SwapHiddenData()
    {
        Credits.SetActive(!Credits.activeInHierarchy);
        Erase.SetActive(!Erase.activeInHierarchy);
    }

    public void EraseEverything()
    {
        PlayerPrefs.DeleteAll();
        _currentExcercise = 0;
        SetupCard();
        SwapHiddenData();
    }

    void SetupCard()
    {
        MainCard.Initialize(Ejercicios[_currentExcercise]);
    }
}
