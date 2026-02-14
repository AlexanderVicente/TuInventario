using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    public static List<Comic> _listMarvel, _listDC;

    public void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "42";
        }
        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        //indicamos las key que queremos leer 
        GetTitleDataRequest request = new GetTitleDataRequest
        {
            Keys = new List<string>() {"Marvel", "DCComics" }
        };

        PlayFabClientAPI.GetTitleData(request, dataResult =>
        {
            string dataMarvel = dataResult.Data["Marvel"];
            string dataDC = dataResult.Data["DCComics"];

            _listMarvel = JsonConvert.DeserializeObject<List<Comic>>(dataMarvel);
            _listDC = JsonConvert.DeserializeObject<List<Comic>>(dataDC);

            //_listComic = JsonUtility.FromJson<ListComic>("{\"result\":" + data + "}");

        }, error => { });
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
}