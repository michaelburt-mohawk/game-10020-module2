using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IHittable>() != null)
        {
            Debug.Log(other);
            IHittable toggle = other.GetComponent<Toggle>();
            toggle.Hit(gameObject);
        }
    }
}
