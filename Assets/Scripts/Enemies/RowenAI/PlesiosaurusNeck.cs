using UnityEngine;
using System.Collections;

public class PlesiosaurusNeck : MonoBehaviour {

	Transform myTransform;
	Vector3 targetPosition;
	Transform target;
	SpriteRenderer mySprite;

	void Start () {
		myTransform = transform;

		target = GameObject.Find ("Head").transform;

		mySprite = GetComponent <SpriteRenderer> ();

	}

	void Update () {
		Vector3 dir = target.position - transform.position;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg + 90;

		if(myTransform.parent.parent == null){
		myTransform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}
		if(myTransform.parent.parent != null && myTransform.position.y < target.position.y){
			mySprite.enabled = false;
		}
		if(myTransform.parent.parent != null && myTransform.position.y > target.position.y){
			mySprite.enabled = true;
		}
	}
}