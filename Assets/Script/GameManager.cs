using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public   Sprite[] image;
    public float duration = 1.0f; // 表示にかける時間（秒）
    private SpriteRenderer book;
    private SpriteRenderer sign;//看板
    private SpriteRenderer black;
    private SpriteRenderer background;
    public GameObject Background;
    public string Gamemode="";
    public bool IsBookmodecheak = false;
    public bool IsSignmodecheak = false;
    public static GameManager Instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        background=Background.GetComponent<SpriteRenderer>()  ;

        background.sprite=image[0];
        book = GameObject.Find("Book").GetComponent<SpriteRenderer>();
        sign = GameObject.Find("Sign").GetComponent<SpriteRenderer>();
        black = GameObject.Find("BlackBoard").GetComponent<SpriteRenderer>();

        // 初期状態は透明
        Color c=book.color;
        c.a = 0f;
        book.color = c;
        sign.color = c;
        black.color = c;

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.B) && Gamemode == "")
        {
            StartCoroutine(FadeIn(book));
            Gamemode = "bookmode";
            //IsBookmodecheak = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Gamemode=="bookmode" )
        {
            StartCoroutine(FadeOut(book));
            Gamemode = "";
            //IsBookmodecheak = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Gamemode == "")
        {
            StartCoroutine(FadeIn(sign));
            Gamemode= "signmode";
            //IsSignmodecheak = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Gamemode=="signmode")
        {
            StartCoroutine(FadeOut(sign));
            Gamemode = "";
            //IsSignmodecheak = false;
        }

        if (Input.GetKeyDown(KeyCode.C) && TextScript.Instance.choisetext != "")//晴れ用
        {
            TextScript.Instance.copytext.text= "copy:" + TextScript.Instance.choisetext;
            TextScript.Instance.diarytext[0].color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.V) && TextScript.Instance.choisetext != "")//雲って用
        {
            TextScript.Instance.Text[1]=TextScript.Instance.choisetext;
            if (TextScript.Instance.choisetext == "晴れて")
            {
                TextScript.Instance.pastetext.color = Color.red;
                StartCoroutine(FadeIn(black));
                background.sprite = image[1];
                StartCoroutine(FadeOut(black));
            }
        }



    }
    private System.Collections.IEnumerator FadeIn(SpriteRenderer spr)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            Color c = spr.color;
            c.a = t;
            spr.color = c;
            yield return null;
        }
    }
    private System.Collections.IEnumerator FadeOut(SpriteRenderer spr)
    {
        float elapsed = 1f;
        while (elapsed >0)
        {
            elapsed -= Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            Color c = spr.color;
            c.a = t;
            spr.color = c;
            yield return null;
        }
    }

}
