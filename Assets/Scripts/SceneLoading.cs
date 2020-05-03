using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [Header("Номер загружаемой сцены")]
    public int sceneID;

    [Header("Картинки для окна загрузки")]
    public Sprite[] Loading_images;

    [Header("Картинки окна загрузки")]
    public Image Loading_win;

    [Header("Значение случайного выбора картинок")]
    private int rand_win;

    [Header("Картинки полосы загрузки")]
    public Image Loading_img;

    [Header("Текст уровня загрузки")]
    public Text Loading_text;

    // Start is called before the first frame update
    void Start()
    {
        rand_win = Random.Range(0,5);
        Loading_win.sprite = Loading_images[rand_win];
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad(){ 
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone) {
            float progress = operation.priority / 0.9f;
            Loading_img.fillAmount = operation.progress;
            Loading_text.text = string.Format("{0:0}%", progress*100); 
            yield return null;
        }
    }
}
