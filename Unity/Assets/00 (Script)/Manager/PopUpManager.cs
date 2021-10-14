using System.Security.Cryptography.X509Certificates;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public Transform popupParent;
    
    private CanvasGroup popupCanvasGroup;

    public RestartPopUp restartPopUp;

    private Dictionary<string, PopUp> popupDic = new Dictionary<string, PopUp>();
    private Stack<PopUp> popupStack = new Stack<PopUp>();

    public static PopUpManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("다수의 팝업매니저가 실행중입니다.");
        }
        instance = this;
    }

    void Start()
    {
        popupCanvasGroup = popupParent.GetComponent<CanvasGroup>();
        if(popupCanvasGroup == null)
        {
            popupCanvasGroup = popupParent.gameObject.AddComponent<CanvasGroup>();
        }
        popupCanvasGroup.alpha = 0;
        popupCanvasGroup.interactable = false;
        popupCanvasGroup.blocksRaycasts = false;

        popupDic.Add("restart", Instantiate(restartPopUp, popupParent));
    }

    public void OpenPopUp(string name, int closeCount = 1)
    {
        if(popupStack.Count == 0) //최초로 열리는 팝업
        {
            popupCanvasGroup.interactable = true;
            DOTween.To(
                () =>popupCanvasGroup.alpha, 
                value => popupCanvasGroup.alpha = value,
                1, 
                1f
            ).OnComplete(() =>
            {
                popupCanvasGroup.blocksRaycasts = true;
            });
        }

        popupStack.Push(popupDic[name]);
        popupDic[name].Open(closeCount);
    }

    public void ClosePopUp()
    {
        popupStack.Pop().Close();
        if(popupStack.Count == 0)
        {
            DOTween.To(
                () => popupCanvasGroup.alpha,
                value => popupCanvasGroup.alpha = value,
                0,
                1f
            ).OnComplete(() =>
            {
                popupCanvasGroup.interactable = false;
                popupCanvasGroup.blocksRaycasts = false;
            });
        }
    }

    public void RestartPopUP()
    {
        Debug.Log("Restart");
    }
}