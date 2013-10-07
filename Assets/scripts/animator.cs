﻿using UnityEngine;
using System.Collections;

public class animator : MonoBehaviour {
	
	private int columns_size;
	private int rows_size;
	private int fps;
	
	public void setSize(int _columns_size, int _rows_size) {
		columns_size = _columns_size;
		rows_size = _rows_size;
	}
	
	public void setFps(int _fps) {
		fps = _fps;
	}
	
	public void animate(int curr_row, int start_frame, int curr_frames_count) {
		
		MeshRenderer renderer = (MeshRenderer) GetComponent ("MeshRenderer");	
		
		float frame_width = 1.0f / columns_size;
		float frame_height = 1.0f / rows_size;
		
		int curr_frame = start_frame + ((int)(Time.time*fps))%(curr_frames_count);
		 
	 	renderer.material.SetTextureOffset("_MainTex", new Vector2(frame_width*curr_frame, frame_height*(rows_size - curr_row - 1)));
		renderer.material.SetTextureScale("_MainTex", new Vector2(1.0f/columns_size, 1.0f/rows_size));
	}
}
