using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BottenScript : MonoBehaviour
{
    public int quiznumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PushBotton()
    {
        switch (quiznumber)
        {
            case 0 when GameManager.Instance.Gamemode == "bookmode": 
                TextScript.Instance.choisetext = "ê∞ÇÍÇƒ";
                TextScript.Instance.diarytext[quiznumber].color = Color.yellow;
                break;
            case 1 when GameManager.Instance.Gamemode == "signmode":
                TextScript.Instance.pastetext.color = Color.yellow;
                break;
        }
    }
    public void PushStartButton()
    {
        SceneManager.LoadScene("PlayScene");
    }

}
