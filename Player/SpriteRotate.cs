using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotate : MonoBehaviour
{
  public Animator animator;
  void Update () 
  {
    animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
    
    transform.localRotation = transform.localRotation * Quaternion.Inverse(transform.rotation);
  }
}
