using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

    public float speed = 10.0F;
    public float jumpSpeed = 20.0F;
    public float gravity = 10.0F;
    private Vector3 moveDirection = Vector3.zero;
	private CHARACTER_STATE current_state = 0; // Allows to know which kind of animation should be played
	
 	
	enum CHARACTER_STATE {
		MOVE_LEFT = 0,
		MOVE_RIGHT,
		LOOK_LEFT,
		LOOK_RIGHT
	};
	
	animator character_animation;
	
	void Start () {
		//setting default animation params
		character_animation = (animator)GetComponent("animator");	
		character_animation.setFps(12);
		character_animation.setSize(6,3);
	}
	
    void Update() {
		updateMove();
		updateState();
		updateAnimation();
    }
	
	void updateMove() {
		
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0); //this is a 2D game, so only X-axis
        	moveDirection = transform.TransformDirection(moveDirection);
       	 	moveDirection *= speed;
            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
			}
        } else {
			moveDirection.x = speed * Input.GetAxis("Horizontal"); //only horizontal move control while flying
		}
			
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
	
	void updateState() {
 
		if (moveDirection.x > 0) {
			current_state = CHARACTER_STATE.MOVE_RIGHT;
		}  else	
		if (moveDirection.x < 0) {
			current_state = CHARACTER_STATE.MOVE_LEFT;
		} else 
		if (moveDirection.x < 0.2f) { // as temp solution. Disables low inertion value and switches animation. 
			moveDirection.x = 0.0f;
			if (current_state == CHARACTER_STATE.MOVE_LEFT) {
					current_state = CHARACTER_STATE.LOOK_LEFT;
			}
			if (current_state == CHARACTER_STATE.MOVE_RIGHT) {
					current_state = CHARACTER_STATE.LOOK_RIGHT;
			}
			
		}
	}
	
	void updateAnimation() {
	
		if (current_state == CHARACTER_STATE.MOVE_RIGHT) {
			character_animation.animate(0, 0, 6); //only for current spritesheet
		} else  
		if (current_state == CHARACTER_STATE.MOVE_LEFT) {
	 		character_animation.animate(1, 0, 6);
		} else
		if (current_state == CHARACTER_STATE.LOOK_RIGHT) {
	 		character_animation.animate(2, 0, 1);
		} else
		if (current_state == CHARACTER_STATE.LOOK_LEFT) {
	 		character_animation.animate(2, 1, 1);
		}
	}
}
