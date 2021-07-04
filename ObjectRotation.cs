using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
