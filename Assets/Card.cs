using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public TextMeshProUGUI TitleLabel;
    public TextMeshProUGUI CountLabel;
    public TextMeshProUGUI SeriesLabel;

    int _count;
    List<int> _series;
    string _cardKey;

    public void Initialize(string title)
    {
        TitleLabel.text = title;
        SeriesLabel.text = string.Empty;
        _count = 15;
        CountLabel.text = _count.ToString();

        _cardKey = TitleLabel.text.ToLower();

        _series = new List<int>();
        var savedData = PlayerPrefs.GetString(_cardKey);

        var loadedSeries = savedData.Split("/").ToList();
        if (loadedSeries.Count == 1 && loadedSeries[0] == "")
            loadedSeries = null;

        if (loadedSeries != null)
        {
            foreach (var item in loadedSeries)
            {
                _series.Add(int.Parse(item));
            }
        }

        ShowSeries();
    }

    public void CounterAdd()
    {
        _count++;
        if (_count >= 60)
            _count = 60;
        CountLabel.text = _count.ToString();
    }

    public void CounterSub()
    {
        _count--;
        if (_count <= 1)
            _count = 1;
        CountLabel.text = _count.ToString();
    }

    public void AddSeries()
    {
        _series.Add(_count);

        ShowSeries();
    }

    public void ShowSeries()
    {
        SeriesLabel.text = "";
        for (int i = 0; i < _series.Count; i++)
        {
            SeriesLabel.text += _series[i].ToString();
            if (i < _series.Count - 1)
                SeriesLabel.text += "/";
        }
    }

    public void LoadExcercise()
    {
        var result = PlayerPrefs.GetString(_cardKey);
    }

    public void SaveExcercise()
    {
        PlayerPrefs.SetString(_cardKey, SeriesLabel.text);
    }

}
