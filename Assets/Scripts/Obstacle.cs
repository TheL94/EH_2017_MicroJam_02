using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    float movementSpeed;
    Spawner spawner;

	public void Init (float _movementSpeed, Spawner _spawner)
    {
        movementSpeed = _movementSpeed;
        spawner = _spawner;
    }
	
	void Update ()
    {
        transform.Translate(Vector3.forward *(movementSpeed * Time.deltaTime));
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ExitPoint")
        {
            spawner.AddPoints();
            Destroy(gameObject);
        }
    }
}
