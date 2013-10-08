using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

    public float speed = 10.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 10.0F;
    private Vector3 moveDirection = Vector3.zero;
	private MOVEMENT current_move = 0;
	
	enum MOVEMENT {
		MOVE_LEFT = 0,
		MOVE_RIGHT,
		LEFT,
		RIGHT
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
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        	moveDirection = transform.TransformDirection(moveDirection);
       	 	moveDirection *= speed;
            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
			}
        } else {
			moveDirection.x = speed * Input.GetAxis("Horizontal");
		}
			
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
	
	void updateState() {
 
		if (moveDirection.x > 0) {
			current_move = MOVEMENT.MOVE_RIGHT;
		}  else	
		if (moveDirection.x < 0) {
			current_move = MOVEMENT.MOVE_LEFT;
		} else 
		if (moveDirection.x < 0.2f) {	
			moveDirection.x = 0.0f;
			if (current_move == MOVEMENT.MOVE_LEFT) {
					current_move = MOVEMENT.LEFT;
			}
			if (current_move == MOVEMENT.MOVE_RIGHT) {
					current_move = MOVEMENT.RIGHT;
			}
			
		}
	}
	
	void updateAnimation() {
	
		if (current_move == MOVEMENT.MOVE_RIGHT) {
			character_animation.animate(0, 0, 6);
		}  
		if (current_move == MOVEMENT.MOVE_LEFT) {
	 		character_animation.animate(1, 0, 6);
		}
		if (current_move == MOVEMENT.RIGHT) {
	 		character_animation.animate(2, 0, 1);
		}
		if (current_move == MOVEMENT.LEFT) {
	 		character_animation.animate(2, 1, 1);
		}
	}
}
