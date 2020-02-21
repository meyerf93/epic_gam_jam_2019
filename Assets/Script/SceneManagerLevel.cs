using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerLevel : MonoBehaviour
{

	public static SceneManagerLevel Instance;

    public AudioSource openPause;
    public AudioSource quitPause;

    public GameObject panel;
	public Text Time_value;
	public Text Level_value;
	public Text Score_value;

	public Animator transition;

	public Text Level_from;
	public Text Level_to;

	public Sprite Up;
	public Sprite Down;

	public Image Stairs;

	public int multipler_score;
	public int power_score;
	public int multipler_sec;
        
	private bool IsPaused = false;

	private float time_at_start;
	private float actual_run;

	public void Awake()
	{
		Instance = this;
	}
	public void Start()
	{
		time_at_start = Time.time;
	}

	private void Update()
    {
        if (IsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                quitPause.Play();
                IsPaused = false;
                Time.timeScale = 1;

                if (panel != null)
                {
                    panel.SetActive(false);
                }
                
            }
        }
        else
        {
            setTimer();
			setStage();
			setScore();
            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                openPause.Play();
                IsPaused = true;

                Time.timeScale = 0;

                if (panel != null)
                {
                    panel.SetActive(true);
                }
                
            }
        }
	}
    
	public void switchQuit()
    {
		Time.timeScale = 1;
        SceneManager.LoadScene("Fin");
    }

	private void setTimer()
	{
		float actual_Time = Time.time;

		actual_run =  actual_Time - time_at_start;

        
		if(actual_run%60 > 0)
		{
			int Minutes = (int)(actual_run % 60);
			int Second = (int)(actual_run / 60);
			Time_value.text = Second.ToString() + " : " + Minutes;
		}
		else
		{
			int Second = (int)(actual_run / 60);
			Time_value.text = Second.ToString();
		}
        
	}

	private void setStage()
	{
		int level = LevelGenerator.Instance.GetLevel;
		Level_value.text = level.ToString();
	}

	private void setScore()
	{
		int score_of_level = (int)Mathf.Pow((float)(LevelGenerator.Instance.GetLevel * multipler_score),(float)(power_score));
		int final_score = score_of_level - (int)(actual_run*multipler_sec);

		PlayerPrefs.SetInt("Player Score", final_score);
       

		Score_value.text = final_score.ToString();
	}
    
	public void setLevelTransition(int level_from, int level_to)
	{
		Level_from.text = level_from.ToString();
		Level_to.text = level_to.ToString();

		if(level_from > level_to)
		{
			Stairs.sprite = Down;
		}
		else
		{
			Stairs.sprite = Up;
		}

		transition.SetTrigger("transition_stage");
	}
}
