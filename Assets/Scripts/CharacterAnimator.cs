using UnityEngine;
using System.Collections;

public class CharacterAnimator : SpriteAnimator {

 	enum CHARACTER_STATE {
		MOVE_LEFT = 0,
		MOVE_RIGHT,
		LOOK_LEFT,
		LOOK_RIGHT,
		JUMP_LEFT,
		JUMP_RIGHT
	};
	
	private CHARACTER_STATE current_state = 0; // Allows to know which kind of animation should be played
	
	public void updateAll(Vector3 move_direction) {
		updateState(move_direction);
		updateAnimation();
	}
	
	private void updateState(Vector3 move_direction) {
 		
		CharacterController controller = GetComponent<CharacterController>();
		
		if (!controller.isGrounded) {//jumping states
			
			if (move_direction.x < 0) {
				current_state = CHARACTER_STATE.JUMP_LEFT;
			} else if (move_direction.x > 0){		
				current_state = CHARACTER_STATE.JUMP_RIGHT;
			} else { //jump from standing position
				if (current_state == CHARACTER_STATE.LOOK_LEFT) {
						current_state = CHARACTER_STATE.JUMP_LEFT;
				} else if (current_state == CHARACTER_STATE.LOOK_RIGHT) {
						current_state = CHARACTER_STATE.JUMP_RIGHT;
				}
			} 				
		} else { //others
			
			if (move_direction.x > 0) {
				current_state = CHARACTER_STATE.MOVE_RIGHT;
			}  else	if (move_direction.x < 0) {
				current_state = CHARACTER_STATE.MOVE_LEFT;
			} else if (move_direction.x < 2.0f) { // as temp solution. Disables low inertion value and switches animation. 
				
				move_direction.x = 0.0f;
				if (current_state == CHARACTER_STATE.MOVE_LEFT || current_state == CHARACTER_STATE.JUMP_LEFT) {
						current_state = CHARACTER_STATE.LOOK_LEFT;
				}
				if (current_state == CHARACTER_STATE.MOVE_RIGHT || current_state == CHARACTER_STATE.JUMP_RIGHT) {
						current_state = CHARACTER_STATE.LOOK_RIGHT;
				}
			}
			
		}
	}
	
	private void updateAnimation() {
 		//only for current spritesheet
		if (current_state == CHARACTER_STATE.MOVE_RIGHT) {
			animate(0, 4, 8); 
		} else if (current_state == CHARACTER_STATE.MOVE_LEFT) {
	 		animate(5, 4, 6);
		} else if (current_state == CHARACTER_STATE.LOOK_RIGHT) {
	 		animate(4, 0, 1);
		} else if (current_state == CHARACTER_STATE.LOOK_LEFT) {
	 		animate(9, 0, 1);
		} else if (current_state == CHARACTER_STATE.JUMP_LEFT) {
	 		animate(7, 5, 1);
		} else if (current_state == CHARACTER_STATE.JUMP_RIGHT) {
	 		animate(2, 5, 1);
		}
	}
}
