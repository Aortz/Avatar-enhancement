using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameCamera : MonoBehaviour
{
    void LateUpdate(){
        transform.LookAt(transform.position + Camera.main.transform.forward);
   }
}
