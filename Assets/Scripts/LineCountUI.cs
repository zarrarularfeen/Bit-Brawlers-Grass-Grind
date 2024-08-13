using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineCountUI : MonoBehaviour
{
    private int linecount;
    public GameObject obj;
    public TextMeshProUGUI linecounttext;
    private DrawManager drawmanagerscript;

    // Start is called before the first frame update
    void Start()
    {
        drawmanagerscript = obj.GetComponent<DrawManager>();
        linecount = drawmanagerscript.linecount;
        linecounttext.text = "      " + string.Format("{0}", linecount);
        
    }

    // Update is called once per frame
    void Update()
    {
        linecount = drawmanagerscript.linecount;
        if (linecount > -1)
        {
            linecounttext.text = "      " + string.Format("{0}", linecount);
        }
    }
}
