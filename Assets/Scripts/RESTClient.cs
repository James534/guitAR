using UnityEngine;
using System.Collections;

public class RESTClient : MonoBehaviour
{
    string results = "";
    string filteredStr = "";
    public static string str = "";

    public WWW GET(string url, System.Action onComplete)
    {
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www, onComplete));
        return www;
    }

    IEnumerator WaitForRequest(WWW www, System.Action onComplete)
    {
        yield return www;
        if (www.error == null)
        {
            results = www.text;
            onComplete();
        }
        else
        {
            Debug.Log("Error " + www.error);
        }
    }

    public string Results
    {
        get
        {
            return results;
        }
    }

    void callBackFn()
    {
        System.String[] stringArray = Results.Split(new string[] { "," }, System.StringSplitOptions.None);
        //Debug.Log("Results " +Results);
        results = Results;
        //Debug.Log("callbackfn " + stringArray);
    }

    MainScript ms;

    // Use this for initialization
    void Start()
    {
        ms = GetComponent<MainScript>();
    }

    // Update is called once per frame
    void Update()
    {
        new WaitForSeconds(0.5f);

        GET("ec2-54-218-176-121.us-west-2.compute.amazonaws.com/requests/playRequest.php", callBackFn).ToString();
        //Debug.Log("----------------------");
        Debug.Log("temp " + results);
        if (results.Length > 0)
        {
            str = results;
        }
        /*
        int t = results.LastIndexOf("action") + 9;
        int t2 = results.IndexOf('"', t);
        filteredStr = results.Substring(t, t2 - t);*/
        //Debug.Log("Filtered string "+filteredStr);
        //Debug.Log("=======================");
    }
}