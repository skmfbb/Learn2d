using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {
	
	public Transform start_checkpoint; 
	private Vector3 last_check_point;
	
	void Start() {
		last_check_point = start_checkpoint.position;
		transform.position = last_check_point;	
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "CheckPoint") {
 			last_check_point = other.transform.position;	
		} else if (other.tag == "DeathPoint") {
			transform.position = last_check_point;
		}
    }
}
