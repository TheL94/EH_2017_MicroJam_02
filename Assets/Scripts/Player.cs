using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public int Life = 3;

    Shape _currentShape;
    public Shape CurrentShape
    {
        get { return _currentShape; }
        set
        {
            _currentShape = ModifyScale(value, _currentShape);
        }
    }

	void Start ()
    {
        UIManager.I.SetLives(Life);
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.W))
            CurrentShape = Shape.Horizontal; 
		else if(Input.GetKey(KeyCode.S))
            CurrentShape = Shape.Vertical;
        else
            CurrentShape = Shape.Full;
    }

    public Shape ModifyScale(Shape _newShape, Shape _oldShape)
    {
        if (_newShape == _oldShape)
            return _oldShape;

        switch (_newShape)
        {
            case Shape.Full:
                transform.DOScale(Vector3.one, 1f);
                break;
            case Shape.Vertical:
                transform.DOScale(new Vector3(0.25f, 1.25f, 1f), 1f);
                break;
            case Shape.Horizontal:
                transform.DOScale(new Vector3(1.25f, 0.25f, 1f), 1f);
                break;
        }

        return _newShape; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            Life -= 1;
            UIManager.I.SetLives(Life);
            if (Life <= 0)
                Debug.Log("Lost");
        }
    }

    public enum Shape { Full, Vertical, Horizontal }
}
