using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

    
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && !audio.isPlaying) {
 			audio.Play();
		}
    }
 
}
