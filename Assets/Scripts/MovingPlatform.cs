using UnityEngine;
using System.Collections;
//2dO: Platform is moving, player's not. Need to do something with it
public class MovingPlatform : MonoBehaviour {
	
	public bool reverse;
	public Transform destination;
	
	Vector3 start_position;	
	Vector3 move_direction;
	
	float speed_koef = 0.005f; //2DO change it with time delta_time_step
	float time_position = 0.0f;
	bool is_moving;	
 
	void Start () {
		is_moving = true; //always moving by default
		Transform current_position = GetComponent<Transform>();
		start_position = current_position.localPosition;
		move_direction = destination.localPosition - current_position.localPosition;
	}
	
 
	void Update () {
		if(is_moving) {
			
			if (time_position < 1.0f) {
				Transform current_position = GetComponent<Transform>();	
				current_position.localPosition = start_position + time_position * move_direction;
				time_position += speed_koef;
			} else if (reverse) {
				move_direction = -move_direction;	//reverse it
				Vector3 swap_start = start_position; //swap start and destination points
				start_position = destination.localPosition;
				destination.localPosition = swap_start;
				time_position = 0.0f; //reset timer
			}
		}	 
	}
}
