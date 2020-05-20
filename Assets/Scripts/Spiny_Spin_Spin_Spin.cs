using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiny_Spin_Spin_Spin : MonoBehaviour {
    public float speed;
	void Update () {
        transform.Rotate(new Vector3(0,speed, 0) * Time.deltaTime);
    }
}
