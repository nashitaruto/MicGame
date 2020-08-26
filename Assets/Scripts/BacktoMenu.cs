using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacktoMenu : MonoBehaviour
{
    float fadeSpeed = 0.01f;
    float red, green, blue, alfa;
    public bool isFadeIn = true;
    public bool isFadeOut = false;
    GameObject restartbutton;
    GameObject quitbutton;
    GameObject restarttext;
    GameObject quittext;
    GameObject jstick;
    Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        restartbutton = GameObject.Find("RestartButton");
        quitbutton = GameObject.Find("QuitButton");
        restarttext = GameObject.Find("RestartText");
        quittext = GameObject.Find("QuitText");
        jstick = GameObject.Find("Floating Joystick");
        restartbutton.SetActive(false) ;
        quitbutton.SetActive(false);

        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        StartFadeIn();
    }

    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }

        if (isFadeOut)
        {
            StartFadeOut();
        }
    }
    public void StartFadeIn()
    {
        alfa -= fadeSpeed;
        SetAlpha();
        if (alfa <= 0)
        {
            isFadeIn = false;
            jstick.SetActive(true);
        }
    }
    public void StartFadeOut()
    {
        alfa += fadeSpeed;         
        SetAlpha();
        if (alfa >= 1)
        {
            isFadeOut = false;
            restartbutton.SetActive(true);
            restarttext.GetComponent<Text>().text = "RESTART";
            quitbutton.SetActive(true);
            quittext.GetComponent<Text>().text = "QUIT";
            jstick.SetActive(false);

        }

    }
    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
