using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShrink : MonoBehaviour
{
    Vector3 temp;
    [SerializeField] GameObject shrinkingObject;
public void ShrinkPlayer() 
{
    temp = transform.localScale;
    temp.x += -.5f;
    temp.y += -.5f;
    temp.z += -.5f;

    transform.localScale = temp ;
}
void TurnOffShrink()
    {
       shrinkingObject = GameObject.FindGameObjectWithTag ("Shrink");
       shrinkingObject.SetActive(false);
    }
 
  void OnTriggerEnter (Collider other)
   {
       if (other.gameObject.tag == "Shrink");
       {
           ShrinkPlayer();
           TurnOffShrink();
       }
   }
}