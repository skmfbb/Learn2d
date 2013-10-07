using UnityEditor;
using UnityEngine;
using System.IO;
// Creates basic projects folders
public class MakeProjectFolder : MonoBehaviour {
	[MenuItem("ProjectTools/CreateFolders %l")]
	static void createFolder() {
		string project_path = Application.dataPath + "/";
		
		Debug.Log("Creating folders...");
		
		Directory.CreateDirectory(project_path + "Audio");
		Directory.CreateDirectory(project_path + "Materials");
		Directory.CreateDirectory(project_path + "Meshes");
		Directory.CreateDirectory(project_path + "Fonts");
		Directory.CreateDirectory(project_path + "Scripts");
		Directory.CreateDirectory(project_path + "Textures");
		
		AssetDatabase.Refresh();
		
	}
}
