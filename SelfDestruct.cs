using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // This script can self destruct anything, gameObject refering to whatever its attached to
    [SerializeField] float timeTillDestroy = 2f;
    void Start() 
    {
        Destroy(gameObject, timeTillDestroy);
    }
}
