using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrow : MonoBehaviour
{
    Vector3 objectScale;
    [SerializeField] GameObject growingObject;
    
public void GrowPlayer() 
{
    objectScale = transform.localScale;
    objectScale.x += 0.5f; 
    objectScale.y += 0.5f;
    objectScale.z += 0.5f;

    transform.localScale = objectScale;
}
void TurnOffGrow()
    {
       growingObject = GameObject.FindGameObjectWithTag ("Grow");
       growingObject.SetActive(false);
    }
 
  void OnTriggerEnter (Collider other)
   {
       if (other.gameObject.tag == "Grow")
       {
           GrowPlayer();
           TurnOffGrow();
       }
   }
}