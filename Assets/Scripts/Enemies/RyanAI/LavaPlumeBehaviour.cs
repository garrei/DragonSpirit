using UnityEngine;
using System.Collections;

public class LavaPlumeBehaviour : MonoBehaviour {
	Animator anim;
	float activeTimer = 4;
	bool isActive;
	BoxCollider2D myCollider;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent <Animator> ();
		myCollider = GetComponent <BoxCollider2D> ();
		isActive = true;

	}
	
	// Update is called once per frame
	void Update () 
	{
			anim.SetBool ("Active", isActive);

			
		if (activeTimer <= Time.time) 
		{
			isActive = !isActive;
			myCollider.enabled = !myCollider.enabled;
			activeTimer = Time.time + 4f;
		}
			
	
	}
}
