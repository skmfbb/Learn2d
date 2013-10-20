using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

    public float speed = 10.0F;
    public float jumpSpeed = 20.0F;
    public float gravity = 10.0F;
    private Vector3 move_direction = Vector3.zero;
	
	
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
            if (Input.GetButton("Jump")) {
                move_direction.y = jumpSpeed;
			}
        } else {
			move_direction.x = speed * Input.GetAxis("Horizontal"); //only horizontal move control while flying
		}
			
        move_direction.y -= gravity * Time.deltaTime;
        controller.Move(move_direction * Time.deltaTime);
	}
	

}
