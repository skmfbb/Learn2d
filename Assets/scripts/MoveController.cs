using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

    public float speed = 6.0F;
    public float jump_speed = 1.0F;
    public float gravity = 14.0F;
 
	private Vector3 move_direction = Vector3.zero;
	private int curr_jumping_time = 0;
	private int max_jumping_time = 8; //max time value, when player can hold "jump" button and increase jump speed
	CharacterAnimator character_animation;
	
	void Start () {
		//setting default animation params
		character_animation = (CharacterAnimator)GetComponent("CharacterAnimator");	
		character_animation.setFps(12);
		character_animation.setSize(8,10);
	}
	
    void Update() {
		updateMove();
		character_animation.updateAll(move_direction);
    }
	
	void updateMove() {
		
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
			move_direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0); //this is a 2D game, so only X-axis
        	move_direction = transform.TransformDirection(move_direction);
       	 	move_direction *= speed;
			
			curr_jumping_time = 0;
            if (Input.GetButton("Jump")) {
                move_direction.y = jump_speed;
			}
        } else {

			move_direction.x = speed * Input.GetAxis("Horizontal"); //only horizontal move control while flying
			//jumping force control
			curr_jumping_time++;
 			if (Input.GetButton("Jump") && curr_jumping_time < max_jumping_time) {
                	move_direction.y += jump_speed;	
			} else {
				curr_jumping_time = max_jumping_time; // if "jump" button was once upped, no more force increasing
			}
		}
			
        move_direction.y -= gravity * Time.deltaTime;
        controller.Move(move_direction * Time.deltaTime);
	}
	
}
