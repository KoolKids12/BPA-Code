using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotate : MonoBehaviour
{
  void Update () 
  {
    transform.localRotation = transform.localRotation * Quaternion.Inverse(transform.rotation);
  }
}
