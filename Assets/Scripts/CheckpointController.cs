using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {
	
	public Transform start_checkpoint; 
	private Vector3 last_check_point;
	
	public TextMesh debug_info;
	
	void Start() {
		last_check_point = start_checkpoint.position;
		transform.position = last_check_point;	
	}
	
	void OnTriggerEnter(Collider other) {
	
		if (other.tag == "CheckPoint") {
 			last_check_point = other.transform.position;
		} else if (other.tag == "DeathPoint") {
			transform.position = last_check_point;
			debug_info.text = "SUCK IT, YOU'RE DEAD AGAIN";
		} else if (other.tag == "LevelEnd") {
			debug_info.text = "-- THE END --\nMaybe now you can try to kill yourself";
		} else if (other.tag == "InterestPoint") { //something awsome must happen now
			TextMesh curr = (TextMesh)other.GetComponent("TextMesh");
			curr.fontSize = 8;
		}
		
		
    }
}
