using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFaderNUI : MonoBehaviour {

    public Image UP;
    private bool IsFadeIn = false;
    private bool isStart = true;
    private string StringToLoad = "";

    public void Start()
    {
    }

    public void LoadScene(string levelName)
    {
        gameObject.SetActive(true);
        IsFadeIn = true;
        isStart = false;
		StringToLoad = levelName;
    }

    void Update()
    {
		
        if (isStart && UP.color.a > 0.01)
        {
			Color c = UP.color;
			c.a = iTween.FloatUpdate(c.a, 0, 5);
			UP.color = c;
        }
		else if(UP.color.a < 0.01 && isStart)
        {
            isStart = false;
			gameObject.SetActive(false);
        }
		
		if (IsFadeIn && UP.color.a < 0.99)
        {
			Color c = UP.color;
			c.a = iTween.FloatUpdate(c.a, 1, 5);
			UP.color = c;
        }
		else if(IsFadeIn && UP.color.a > 0.99)
        {
            Application.LoadLevel(StringToLoad);
        }
    }
}
