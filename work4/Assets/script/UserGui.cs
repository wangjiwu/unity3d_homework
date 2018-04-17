using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baseCode;
public class UserGui : MonoBehaviour {
	roundController roundCtrl;
    diskMove action;
    float width = Screen.width / 6;
    float height = Screen.height / 12;

    string textOut = "";
    // Use this for initialization
    void Start () {
		roundCtrl = (roundController)Director.getInstance ().currentSceneController;
 
    }
	
	// Update is called once per frame
	void Update () {
		if (roundCtrl.status == "gameover") {
			return;
		}
		checkClick ();
	}
    //IEnumerator TimeCutDown(float gap)
    //{
    //    yield return new WaitForSeconds(gap);
    //    textOut = "";
    //    StopAllCoroutines();

    //}

    IEnumerator recoverFromCool(float gap)
    {
        yield return new WaitForSeconds(gap);
        roundCtrl.returnHot();
        StopAllCoroutines();
    }

    void OnGUI(){

		GUI.Box (new Rect (width*5.3f, 15, width, height*2) ,"");
		GUI.Label (new Rect (width * 5.4f, 40, 120, 25), "得分: " + roundCtrl.scoreCtrl.getScore() );
        GUI.Label(new Rect(width * 5.4f, 65, 120, 25), "逃跑飞碟数: " + roundCtrl.getLostDisk());
        GUI.Label(new Rect(0, height, 220, 100), "发动此技能后，飞碟冻住，5秒内 后面出现的飞碟都将变得缓慢");
        if (GUI.Button(new Rect(0, 0, width, height), "冻住，不洗澡")) 
        {
            //Debug.Log("11111");
            roundCtrl.setCool();
            ////过3秒
            StartCoroutine(recoverFromCool(3));
            //action.returnHot();

        }
      
        GUIStyle bb = new GUIStyle();
        bb.normal.background = null;    //这是设置背景填充的
        bb.normal.textColor = new Color(1, 0, 0);   //设置字体颜色的
        bb.fontSize = 40;       //当然，这是字体大小
        if(roundCtrl.getRoundLever() == 1)
        {
            textOut = "别紧张，这是第一波";
            //StartCoroutine(TimeCutDown(1));

        } else if (roundCtrl.getRoundLever() == 2)
        {
            textOut = "飞碟增多了，第二波到了";
            //StartCoroutine(TimeCutDown(1));
        }
        else if (roundCtrl.getRoundLever() == 3)
        {
            textOut = "稳住，这是第三波";
           // StartCoroutine(TimeCutDown(1));
        }
        else if (roundCtrl.getRoundLever() == 4)
        {
            textOut = "加油，这是第四波";
            //StartCoroutine(TimeCutDown(1));
        }
        else if (roundCtrl.getRoundLever() == 5)
        {
            textOut = "坚持住，这是最后一波";
           // StartCoroutine (TimeCutDown(1));
        }
        GUI.Label(new Rect(width *1.6f, height*2, width*1.5f, height*2), textOut, bb);


        //if (createTime > 0 && roundCtrl.isCool)
        //{
        //    StartCoroutine(TimeCutDown(1));
        //    GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 20f, 20f), createTime.ToString());
        //}

        //if (GUI.Button(new Rect(0,height*2, width, height), "时间恢复"))
        //{
        //    Debug.Log("11111");
        //    roundCtrl.returnHot();
        //    //过一秒
        //    StartCoroutine(TimeCutDown(1));
        //    //action.returnHot();
        //}

        if (roundCtrl.status == "gameover")
        {
            
            bb.normal.background = null;    //这是设置背景填充的
            bb.normal.textColor=new Color(1,0,0);   //设置字体颜色的
            bb.fontSize = 40;       //当然，这是字体大小
            GUI.Label(new Rect(width * 2.5f, height * 5, width, height), "游戏结束", bb);
            bb.fontSize = 30;
            GUI.Label(new Rect(width * 1.5f, height * 6, width, height), "您的分数为：" + roundCtrl.scoreCtrl.getScore() + "   您的丢失盘子为：" + roundCtrl.getLostDisk(), bb);
            if (GUI.Button(new Rect(width * 2.5f, height *7, width, height), "点击重新开始"))
            {
                roundCtrl.status = "running";
                roundCtrl.reset();
            }

        }

    }

	void checkClick(){
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 mp = Input.mousePosition;
			Camera cam = Camera.main;
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				((roundController)Director.getInstance ().currentSceneController).hitDisk (hit.transform.gameObject);
			}
		}
	}
}
