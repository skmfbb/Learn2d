using UnityEngine;
using System.Collections.Generic;

public class GrassPlatformManager : MonoBehaviour {

    //Single element of this List is a Vector3 that contains info about platform group
    //x,y - platform group start position
    //z - number of blocks
    private List<Vector3> levelPlatformsConfig = new List<Vector3>();
    private const float levelDepth = 4f;
	
	public Transform platformPrefab;

	// Use this for initialization
	void Start () {
        ReadLevelPlatformsConfig();
		GeneratePlatforms();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //read from external source, at this point generating here
    void ReadLevelPlatformsConfig()
    {
        levelPlatformsConfig.Add(new Vector3(1, 1, 5));
        levelPlatformsConfig.Add(new Vector3(7, 3, 3));
        levelPlatformsConfig.Add(new Vector3(3, 3, 2));
		levelPlatformsConfig.Add(new Vector3(5, 1, 10));
    }

	void GeneratePlatforms()
	{
		foreach(Vector3 platformGroup in levelPlatformsConfig)
		{
            Vector2 startPos = new Vector2(platformGroup.x, platformGroup.y);
            for (int platformNum = 0; platformNum < platformGroup.z; platformNum++)
            {
                Instantiate(platformPrefab, new Vector3(startPos.x + platformNum * 1, startPos.y, levelDepth), Quaternion.identity);
            }
		}
	}
}
