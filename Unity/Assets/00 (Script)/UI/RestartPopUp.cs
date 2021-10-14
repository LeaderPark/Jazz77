using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartPopUp : PopUp
{
    public Button restartBtn;

    public int closeCount = 1;

    protected override void Awake()
    {
        base.Awake();
        restartBtn.onClick.AddListener(() =>
        {
            PopUpManager.instance.RestartPopUP();
        });
    }

    public override void Open(int closeCount)
    {
        base.Open(closeCount);
        this.closeCount = closeCount;
    }

    public override void Close()
    {
        base.Close();
        this.closeCount--;
        if(this.closeCount > 0)
        {
            PopUpManager.instance.ClosePopUp();
        }
    }
}

