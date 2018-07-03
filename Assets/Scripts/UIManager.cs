using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public static UIManager instance;
    [SerializeField]
    private GameObject screenWin;
    [SerializeField]
    private GameObject screenLose;
    [SerializeField]
    private GameObject screenMenu;
    [SerializeField]
    private Text coinsText;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        coinsText.text = CoinsManager.Instance.CurrentCoins + "";
    }
    public void WinGame()
    {
        StartCoroutine(AnimationScreensOpen(screenWin, 5));
    }
    public void LoseGame()
    {
        StartCoroutine(AnimationScreensOpen(screenLose, 5));
    }
    public void MenuOpen()
    {
        StartCoroutine(AnimationScreensOpen(screenMenu, 5));
    }

    public void MenuClose()
    {
        StartCoroutine(AnimationScreensClose(screenMenu, 5));
    }
    IEnumerator AnimationScreensOpen(GameObject screen, float smooth)
    {
        screen.SetActive(false);
        screen.transform.localScale = Vector3.zero;
        Vector3 currentScale = Vector3.zero;
        screen.SetActive(true);
        while(currentScale.x < 1)
        {
            currentScale += Vector3.one * smooth * Time.deltaTime;
            yield return new WaitForEndOfFrame();
            screen.transform.localScale = currentScale;
        }
        screen.transform.localScale = Vector3.one;
        yield return 0;
    }
    IEnumerator AnimationScreensClose(GameObject screen, float smooth)
    {
        screen.transform.localScale = Vector3.one;
        Vector3 currentScale = Vector3.one;
     
        while (currentScale.x > 0)
        {
            currentScale -= Vector3.one * smooth * Time.deltaTime;
            yield return new WaitForEndOfFrame();
            screen.transform.localScale = currentScale;
        }
        screen.transform.localScale = Vector3.zero;
        screen.SetActive(false);
        yield return 0;
    }

}
