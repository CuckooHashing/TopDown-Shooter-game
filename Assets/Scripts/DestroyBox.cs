using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour {
    
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject.transform.parent.gameObject);
       
    }


}
