using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score
{
    public int value;
    public string name;
    public string pseudo;


    
    public Score(int value, string name,string speudo)
    {
        this.value = value;
        this.name = name;
        this.pseudo = speudo;
    }
}
public class EndSceneManage : MonoBehaviour
{
    public Text actual_score;

    public InputField player_name;

    private List<Score> table_score;

	public Text[] Score;
	public Text[] Pseudo;

   

    // Start is called before the first frame update
    void Start()
    {
        actual_score.text = PlayerPrefs.GetInt("Player Score").ToString();
        table_score = new List<Score>();

		for (int i = 0; i < Score.Length; i++)
		{
			table_score.Add(new Score(PlayerPrefs.GetInt("Player_" + i), "Player_" + i, PlayerPrefs.GetString("Player_" + i + "_pseudo")));
		}
        

		table_score = table_score.OrderByDescending(o => o.value).ToList();
		Display_Score();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save_Score()
    {
        int temp_point = int.Parse(actual_score.text);
        PlayerPrefs.SetInt(player_name.text,temp_point);

		Score temps_score = table_score.Find(y => y.value == table_score.Min(r => r.value));
        if(temps_score == null)
        {
            Score element = table_score.Find(r => r.name == "Player_14");

			table_score.Remove(element);
			element.value = temp_point;
			element.pseudo = player_name.text;
			table_score.Add(element);

			PlayerPrefs.SetInt("Player_14", temp_point);
			PlayerPrefs.SetString("Player_14_pseudo", element.pseudo);
			table_score = table_score.OrderByDescending(o => o.value).ToList();

        }
        else
        {
			table_score.Remove(temps_score);

            temps_score.value = temp_point;
			temps_score.pseudo = player_name.text;
			table_score.Add(temps_score);

			PlayerPrefs.SetInt(temps_score.name, temp_point);
            PlayerPrefs.SetString(temps_score.name+"_pseudo", temps_score.pseudo);
			table_score = table_score.OrderByDescending(o => o.value).ToList();
        }
		Display_Score();
		SceneManager.LoadScene("Titre");
    }

	private void Display_Score()
	{
		for(int i = 0; i < Score.Length; i++)
		{
			Score element = table_score[i];
			Score[i].text = element.value.ToString();
			if(element.pseudo == "")
			{
				element.pseudo = "bloby";
			}
			Pseudo[i].text = element.pseudo + " : ";
		}
	}
}
