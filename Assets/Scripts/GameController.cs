using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameController : NetworkBehaviour {

	public GameObject hazard;
    public GameObject enemy;
    public GameObject player;
    public GameObject skycam;
    public GameObject cam;
    public Vector3 spawnValues;
	public int hazardCount;
	
	public float spawnWait;
	public float startWait;
	public float waveWait;


	public Text scoreText;
	public int score;

	public Text restartText;
	public Text gameOverText;
    private int waveNum;
	private bool gameOver;
	private bool restart;
    private int mode;

	void Start() {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";

	    StartCoroutine (SpawnWaves());
	    score = 0;
		UpdateScore();
	}

	void Update() {
		if(restart) {
			if(Input.GetKeyDown(KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	
	IEnumerator SpawnWaves() {
	    yield return new WaitForSeconds(startWait);

	    while(true) {
            SetWave();
            for (int i=0;i<hazardCount;i++) {
                Debug.Log("spawn");
                Vector3 spawnPosition = new Vector3 
	                  (Random.Range(-spawnValues.x,spawnValues.x),
	                  spawnValues.y,
	                  spawnValues.z);
	            Quaternion spawnRotation = Quaternion.identity;
                //no rotation aside from inherent)
                float rnd = Random.Range(0f, 1f);
                if (rnd<=.9) {
                   var h= Instantiate(hazard, spawnPosition, spawnRotation);
                    //NetworkServer.Spawn(h);
                    CmdServerSpawner(h);
                } else if (mode!=1 && rnd>.9) {

                    var h=Instantiate(enemy, spawnPosition, spawnRotation);
                    CmdServerSpawner(h);
                }
                yield return new WaitForSeconds(spawnWait);
	        }
	        yield return new WaitForSeconds(waveWait);
            

            if (gameOver) {
	        	restartText.text = "Press 'R' for Restart";
	        	restart = true;
	        	break;
	        }
	    }

	}

    [Command]
    void CmdServerSpawner(GameObject h) {
        NetworkServer.Spawn(h);
    }

    public void SetWave() {
        switch (waveNum) {
            case 0:
                waveWait = 0;
                startWait = 0;
                hazardCount = 100;
                spawnWait = .2f;
                mode = 1;
                break;

            case 1:
                
                break;

            case 2:
                mode = 0;
                break;

            case 3:
                mode = 2;
                break;


            default:
                break;
        }
        waveNum++;
        
        //mode = Random.Range(0, 3);
        //mode = 0;
        player=GameObject.FindGameObjectWithTag("player");
        player.GetComponent<PlayerController>().mode = mode;
        switch (mode) {
            case 0:
                skycam.GetComponent<SkyRot>().rot = new Vector3(-1, 0, 0);
                break;

            case 1:
                skycam.GetComponent<SkyRot>().rot = new Vector3(0, 1, 0);
                break;

            case 2:
                skycam.GetComponent<SkyRot>().rot = new Vector3(0, 0, 1);
                break;
        }
        skycam.GetComponent<SkyRot>().rotSpd += 1;
    }

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore();
	}


	void UpdateScore() {
		scoreText.text = "Score: " + score;

	}
    void start() { waveNum = 0; }
    void WinCheck() {
        if (waveNum > 10) {
            //
        }
    }
	public void GameOver() {
		gameOverText.text="Game Over!";
		gameOver = true;
	}

}
