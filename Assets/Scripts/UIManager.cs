using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager I;

    public GameObject GameOverPanel;
    public Text Lives;
    public Text Points;

    void Awake ()
    {
        if (I == null)
            I = this;
        else
            DestroyImmediate(gameObject);
	}
	
	public void SetLives(int _lives)
    {
        Lives.text = "Lives " + _lives;
    }

    public void SetPoints(int _points)
    {
        Points.text = "Points " + _points;
    }

    public void OnLost()
    {
        GameOverPanel.SetActive(true);
    }
}
