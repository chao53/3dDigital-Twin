using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*查找按钮组件并添加事件(点击事件)*/
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}