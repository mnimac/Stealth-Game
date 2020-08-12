using UnityEngine;

public class Camera : MonoBehaviour
{
   public Transform target;
   public Vector3 offset;

   void LateUpdate(){
       transform.position = target.position + offset;
   }
}
