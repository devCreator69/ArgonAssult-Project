using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShrink : MonoBehaviour
{
    Vector3 objectScale;
    [SerializeField] GameObject shrinkingObject;
public void ShrinkPlayer() 
{
    objectScale = transform.localScale;
    objectScale.x += -.5f;
    objectScale.y += -.5f;
    objectScale.z += -.5f;

    transform.localScale = objectScale ;
}
void TurnOffShrink()
    {
       shrinkingObject = GameObject.FindGameObjectWithTag ("Shrink");
       shrinkingObject.SetActive(false);
    }
 
  void OnTriggerEnter (Collider other)
   {
       if (other.gameObject.tag == "Shrink")
       {
           ShrinkPlayer();
           TurnOffShrink();
       }
   }
}