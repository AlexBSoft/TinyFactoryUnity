using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public struct ItemPack
{
    public string PackName;
    public GameObject[] ItemList;
}

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int hp = 6;
    public float timer_secs = 1f;

    public ItemPack[] itemPack;
    public GameObject current_item;

    public int TargetRandomList;
    public int TargetRandom;
    private int random;
    private bool scored =false;
    private bool timerActive = false;
    private bool togglertoggle = false;

    private float TimerTime = 0;

    public int StatisticMiss = 0;

    public bool gameRunning = false;
    public bool introScreen = true;

    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        TargetRandomList = Random.Range(0, itemPack.Length);
        TargetRandom = Random.Range(0, itemPack[TargetRandomList].ItemList.Length);
        audioData = GetComponent<AudioSource>();
        GameIntro();
    }


    // Update is called once per frame
    void Update()
    {
        if(!gameRunning)
            return;

        GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().SetText("Score: "+score+"\n Lives: "+hp);
        GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>().SetText(""+(3-Mathf.Round(TimerTime)));

        if(timerActive)
            TimerTime += Time.deltaTime;

        if(TimerTime > 2f && timerActive){
            togglertoggle = true;

            
            timerActive = false;
            SpawnObject(2);
        }

        if(hp <= 0)
            GameOver();

        if (Input.GetKeyUp("e"))
        {
            ClickButton(2);
        }
        if (Input.GetKeyUp("w"))
        {
            ClickButton(1);
        }
        
        if(current_item == null)
            SpawnObject();
        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            Debug.Log(rayHit.transform);
        }*/
    }

    public void DeleterToggle(){
        if(TargetRandom != random)
            audioData.Play(0);
        else if(!togglertoggle)
            GameObject.Find("SoundOK").GetComponent<AudioSource>().Play(0);
        if(togglertoggle){
            if(TargetRandom != random)
                hp--;
            audioData.Play(0);
            StatisticMiss++;
            togglertoggle = false;
        }
    }

    public void DeleterToggle2(){
        if(TargetRandom == random)
            audioData.Play(0);
    }

    public void CenterToggle(){
        timerActive = true;
        TimerTime = 0f;
        GameObject.Find("conveyor").GetComponent<SpriteAnimator>().TogglePause();
    }

    public void ClickButton(int action){
        if (!gameRunning)
            return;

        // Reject
        if(action == 1 && !scored){
            if(TargetRandom != random)
                score++;
            else
                hp--;
        }
        // OK
        if(action == 2 && !scored){
            if(TargetRandom == random)
                score++;
            else
                hp--;
        }
        if(!scored)
            SpawnObject(action);
        scored = true;
    }

    public void SpawnObject(int action = 1){
        // Actual spawning
        if(current_item == null){
            
            scored = false;
            random = Random.Range(0, itemPack[TargetRandomList].ItemList.Length);
            if(random != TargetRandom && Random.Range(0, 10) < 5) // Add more target items
                random = Random.Range(0, itemPack[TargetRandomList].ItemList.Length);
            GameObject current = Instantiate(itemPack[TargetRandomList].ItemList[random], transform.position, Quaternion.identity);
            current.GetComponent<Animation>().Play("MoveObjectAnimation");
            Debug.Log(current);
            current_item = current;
        // Despawning - go away
        }else{
            timerActive = false;
            GameObject.Find("conveyor").GetComponent<SpriteAnimator>().TogglePause();
            if(action == 1)
                current_item.GetComponent<Animation>().Play("MoveObjectAnimation2");
            else
                current_item.GetComponent<Animation>().Play("MoveObjectAnimation1");
                //Destroy(current_item);
                //current_item = null;
        }
    }

    public void GameOver(){
        gameRunning = false;
        GameObject.Find("LosePanel").transform.GetChild(0).gameObject.SetActive(true);

        GameObject.Find("LoseScore").GetComponent<TextMeshProUGUI>().SetText("Score: "+score+"\n Missed: "+StatisticMiss);

        //GameObject.Find("LosePanel").gameObject SetActive(true);


    }

    public void GameIntro(){
        
        GameObject.Find("OKImage").transform.GetComponent<Image>().sprite = itemPack[TargetRandomList].ItemList[TargetRandom].GetComponent<SpriteRenderer>().sprite;
        //GetComponent<Image>().sprite = deerImg;
    }

    public void StartGame(){
        GameObject.Find("StartPanel").transform.GetChild(0).gameObject.SetActive(false);
        gameRunning = true;
    }

    public void RestartGame(){
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        //gameRunning = true;
    }

}
