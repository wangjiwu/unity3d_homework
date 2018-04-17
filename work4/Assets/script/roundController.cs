﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baseCode;
public class roundController : MonoBehaviour ,sceneController , UserAction {
	public string status = "running"; // running , pause , gameover
	DiskFactory diskFac ;
	int roundLever = 1;     //初始化等级为1
	int numOfDiskAlredySend = 0;     //
    int numOfDiskAlredySendInAll = 0;
    int numOfDiskAlredyClick = 0;
    float time = 0;
	float sendDiskTime = 1;
    public bool isCool = false;

    CCActionManager actionManager;
	public ScoreController scoreCtrl = new ScoreController();
    public void returnHot()       //设置冷冻操作
    {
        isCool = false;
    }
    public void setCool()
    {
        Debug.Log("11111");
        isCool = true;

    }
    public int getRoundLever()
    {
        return roundLever;
    }

    public int getLostDisk()
    {
        return numOfDiskAlredySendInAll - numOfDiskAlredyClick;
    }


    void Awake(){
		Director director = Director.getInstance ();
		director.currentSceneController = this;
		this.gameObject.AddComponent<DiskFactory>();
		this.gameObject.AddComponent<CCActionManager> ();
		this.gameObject.AddComponent<UserGui> ();

	}
	// Use this for initialization
	void Start () {
	    diskFac = Singleton<DiskFactory>.Instance;
		actionManager = Singleton<CCActionManager>.Instance;
	}
	
	// Update is called once per frame
	void Update () {

        if(isCool)
        {

        }

		if (roundLever > 5) {
			if(diskFac.getNowUsedDisk() == 0)
				status = "gameover";
			return;
		}
		else if (numOfDiskAlredySend >= 10) {
			numOfDiskAlredySend = 0;
			roundLever++;

		}
		time += Time.deltaTime ;
		checkIfSendDisk ();

	}


	public void hitDisk(GameObject disk){
		diskInfo temp = diskFac.getHitDisk (disk);
		if (temp != null) {
			scoreCtrl.addScore (temp.lever);
            numOfDiskAlredyClick++;
            diskFac.freeDisk (temp);
		}

	
	}

	private void checkIfSendDisk(){
		if(time > sendDiskTime){
			float randomNumOfSend = Random.Range (0f, roundLever);
			int numOfSendDisk;  // 判断一次性发出的碟子个数
	        
			if (randomNumOfSend <= 1) {
				numOfSendDisk = 1;
			} else if (randomNumOfSend <= 2) {
				numOfSendDisk = 2;
			} else {
				numOfSendDisk = 3;
			}
			sendSomeDisks (numOfSendDisk);
			time = 0;
		}
	}

	private void sendSomeDisks(int num){
		for (int loop = 0; loop < num; loop++) {
			float randomNumOfLever = Random.Range (0f, roundLever);
			int thisDiskLever;
			//决定要送的碟的lever
			if (randomNumOfLever <= 1) {
				thisDiskLever = 1;
			} else if (randomNumOfLever <= 2) {
				thisDiskLever = 2;
			} else {
				thisDiskLever = 3;
			}
			sendOneDisk (thisDiskLever);
		}


	}

	private void sendOneDisk(int sendLever){
		numOfDiskAlredySend++;
        numOfDiskAlredySendInAll++;
		diskInfo oneDisk = diskFac.getDisk ( sendLever );
        diskMove moveAction = diskMove.getDiskMove(oneDisk, sendLever, isCool);
        actionManager.RunAction(oneDisk.disk, moveAction, null);
        
		
		
	}

	public void loadResources(){
		
	}

	public void reset(){
		actionManager.reset ();
		diskFac.reset ();
		scoreCtrl.reset ();
		roundLever = 1;
        numOfDiskAlredySend = 0;     
        numOfDiskAlredySendInAll = 0;
        numOfDiskAlredyClick = 0;
        status = "running";
	}

}
