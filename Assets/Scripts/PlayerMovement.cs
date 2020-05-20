using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xmin, xmax, zmin, zmax;
}
public class PlayerMovement : MonoBehaviour {

	public float speed;
	public Boundary gard;

    public GameObject shot;
    public Transform PlayerBullet;
    public float FireRate;

    private float NextFire;

    private void Update()
    {
        if ((Input.GetButton("Jump")) && (Time.time > NextFire))
        {
            NextFire = Time.time + FireRate;
            Instantiate(shot, PlayerBullet.position, PlayerBullet.rotation);
        }
    }
    void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		var movement = new Vector3 (moveHorizontal, 0.1f, moveVertical);
		var rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = movement * speed;
		rigidbody.position = new Vector3 (Mathf.Clamp (rigidbody.position.x, gard.xmin, gard.xmax), 0.0f, Mathf.Clamp (rigidbody.position.z, gard.zmin, gard.zmax)); 

	}
}
