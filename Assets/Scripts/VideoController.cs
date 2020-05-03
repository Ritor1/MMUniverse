using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    /*
     Пришлось по старинке через текстуру, т.к. при компиляции видео пропадало
         */
    public VideoPlayer vid;
    public GameObject TitleWin;
    //[System.Obsolete]
    //public MovieTexture pMove;

    //[System.Obsolete]
    //private void Start()
    //{
        //pMove.Play();

    //}

    //[System.Obsolete]
    //void OnGUI()
    //{

        //Graphics.DrawTexture(new Rect(Screen.width/2 - 160, Screen.height/2 - 120, 320, 240), pMove);

    //}

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown("escape")) {
            Debug.Log("Video is closed");
            //pMove.Stop();
            //vid.Stop();
            //OnDisable();
            //OnVideoEnd(vid);
            TitleWin.SetActive(true);
        }
    }
    void OnEnable() //Сначала подписываем нашу функцию на событие конца видео
    {
        //vid.loopPointReached += OnVideoEnd;
    }

    void OnDisable() //Отписываем для предотвращения утечки памяти
    {
        //vid.loopPointReached -= OnVideoEnd;
    }

    void OnVideoEnd(UnityEngine.Video.VideoPlayer causedVideoPlayer)
    {
        //Нужный вам код, который будет выполняться, когда видео закончится
        //Debug.Log("Video is closed");
        TitleWin.SetActive(true);
    }
}
