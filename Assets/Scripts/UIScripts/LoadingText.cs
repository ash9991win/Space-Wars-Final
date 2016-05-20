using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingText : MonoBehaviour {

    public int NumDots = 3;

    Text loadingText;
    string text = "Connecting";
    string dots = "";

	// Use this for initialization
	void Start ()
    {
        loadingText = GetComponent<Text>();
        loadingText.text = text;
	}
	
	void OnEnable()
    {
        loadingText = GetComponent<Text>();
        StartCoroutine(LoadingTextLoop());
    }

    IEnumerator LoadingTextLoop()
    {
        while (true)
        {
            loadingText.text = text + dots;

            if (dots.Length < NumDots)
            {
                dots = dots + ".";
            }
            else
            {
                dots = "";
            }

            yield return new WaitForSeconds(0.5f);
            yield return null; 
        }
    }
}
