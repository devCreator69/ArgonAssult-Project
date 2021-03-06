using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [Header ("General Setup Settings")]
   [Tooltip("How fast ship moves up and down based upon player input")]
   [SerializeField] float controlSpeed = 25f;
   [SerializeField] float xRange = 9f;
   [SerializeField] float yRangeUp = 7f;
   [SerializeField] float yRangeDown = 9f;

   [Header("Laser gun array")][SerializeField] GameObject [] lasers;
   [Header("Exhaust Emmison")][SerializeField] GameObject [] exhaustFlames;

   [Header("Screen position based tuning")]
   [SerializeField] float positionPitchFactor = -3f;
   [SerializeField] float positionYawFactor = 2f;
   [Header("Player input based tuning")]
   [SerializeField] float contolPitchFactor = -10f;
   [SerializeField] float controlRollFactor = -20f;

   float xThrow, yThrow;

   void Update()
   {
      ProcessTranslation();
      ProcessRotation();
      ProcessFiring();
   }

   void ProcessRotation()
   {
      float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
      float pitchDueToControlThrow = yThrow * contolPitchFactor; //yThrow on its own has too small an impact so thats why its multiplied by the created variable controlPichFactor
     
      float pitch = pitchDueToPosition + pitchDueToControlThrow;
      float yaw = transform.localPosition.x * positionYawFactor;
      float roll = xThrow * controlRollFactor;

      transform.localRotation = Quaternion.Euler(pitch, yaw, roll); // Quarternion is a complex roataion process that yeilds the correct order of motion
   }

   void ProcessTranslation()
   {
      xThrow = Input.GetAxis("Horizontal");
      yThrow = Input.GetAxis("Vertical");
      
      float xOffset = xThrow * Time.deltaTime * controlSpeed;
      float rawXPosition = transform.localPosition.x + xOffset;
      float clampedXPosition = Mathf.Clamp(rawXPosition, -xRange, xRange); // Cant move out of camera range

      float yOffset = yThrow * Time.deltaTime * controlSpeed;
      float rawYPosition = transform.localPosition.y + yOffset;
      float clampedYPosition = Mathf.Clamp(rawYPosition, yRangeDown, yRangeUp);

      transform.localPosition = new Vector3 (clampedXPosition, clampedYPosition, transform.localPosition.z);
   }
   void ProcessFiring()
   {
      if(Input.GetButton("Fire1"))
      {
         SetLasersActive(true);
      }
      else
      {
         SetLasersActive(false);
      }
   }
  public void SetLasersActive(bool isActive) 
  //Access particles system emission bc if the the game object directly is turned off
  //all lasers vanish, even ones in backgrounf which have already been shot
  //just want current shooting to be disabled
  {
     foreach(GameObject laser in lasers)
      {
        var emissionModule = laser.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isActive;
      }
  }
  public void SetExhaustFlamesActive(bool isActive)
  {
    foreach(GameObject exhaustFlames in exhaustFlames)
     {
       var emissionStorage = exhaustFlames.GetComponent<ParticleSystem>().emission;
       emissionStorage.enabled = isActive;
     }
  }
}
