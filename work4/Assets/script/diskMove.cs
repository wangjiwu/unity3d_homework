using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baseCode;
public class diskMove : SSAction {
  
    public Vector3 aim;
	public float speed;
	public diskInfo thisDisk;
	public float time = 0;
 
	// Use this for initialization
	public override void Start () {
		
	}

    public void setSlow()   //使速度变慢
    {
        speed = 1f;
    }
    public static diskMove getDiskMove( diskInfo disk , int lever, bool speeds_control ){
		diskMove action = ScriptableObject.CreateInstance<diskMove> ();
		switch (lever) {
		case 1:
			action.speed = 6f;
			break;
		case 2:
			action.speed = 8f;
			break;
		case 3:
			action.speed = 10f;
			break;
		}

        if(speeds_control)
        {
            action.speed = 1f;
        }
   
        action.thisDisk = disk;

		action.aim = new Vector3(Random.Range(-3f, 3f) , Random.Range(-3f, 3f) , Random.Range(4.5f, 10f) );
		return action;

	}

	// Update is called once per frame
	public override void Update () {


        gameobject.transform.position = Vector3.MoveTowards (gameobject.transform.position, aim, speed * Time.deltaTime);

		if (this.transform.position == aim) {
			this.destroy = true;
			this.enable = false;
			Singleton<DiskFactory>.Instance.freeDisk (thisDisk);
			thisDisk.disk.SetActive(false) ;
		}
	}
}
