using UnityEditor;
using UnityEngine;
using System.IO;

public class MakePrefab : MonoBehaviour {
 
	[MenuItem("ProjectTools/CreatePrefabs")]
	
	static void createSelectedPrefabs() {
		GameObject[] selected = Selection.gameObjects;
		
		string curr_path;  
		for(int i = 0; i < selected.Length; i++) {
			curr_path = "Assets/" + selected[i].name + ".prefab";
			
			if (AssetDatabase.LoadAssetAtPath(curr_path, typeof(GameObject))) {
				
				if (EditorUtility.DisplayDialog("Do you Want to", "Prefab already exists, rewrite?", "Yes", "No")) {
					GameObject curr = PrefabUtility.CreatePrefab(curr_path, selected[i]);
					PrefabUtility.ReplacePrefab(selected[i], curr);
				}
				
			} else {
				PrefabUtility.CreatePrefab(curr_path, selected[i]);
			}
	 
		}
	}
}