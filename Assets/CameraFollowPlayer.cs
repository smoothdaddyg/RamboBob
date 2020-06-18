using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

	public GameObject player;
	
	// Update is called once per frame
	void Update () {

		// set the camera's position to the players position (-10f is for Z axis, so camera is not right on top of player)
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
	}

}
