using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public Text []diarytext;
    public Text copytext;
    public Text pastetext;
    public Text signtext;
    public  string[] Text= {"ê∞ÇÍÇƒ","ì‹Ç¡Çƒ"};
    private string signText="ãÛÇ™Å@Å@Å@Ç¢ÇÈ";
    public static TextScript Instance;
    
    public string choisetext;


    void Start()
    {
        Instance = this;
        //diarytext=new Text[5];
    }

    // Update is called once per frame
    void Update()
    {
        Instance = this;

        if (GameManager.Instance.Gamemode == "bookmode")
        {
            diarytext[0].text = Text[0];
        }
        if (GameManager.Instance.Gamemode == "signmode")
        {
            pastetext.text = Text[1];
            signtext.text= signText;
        }
        if (GameManager.Instance.Gamemode == "")
        {
            diarytext[0].text = "";
            signtext.text = "";
            pastetext.text = "";
        }
    }
    



}
