using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;


public class AirTable
{
    const string url = "https://api.airtable.com/v0/appJb8q14E2tBCvp9/";
    const string table = "High%20Scores";
    const string key = "keyImDBcjsMFbTOz0";

    public static IEnumerator CanConnect(Value<bool> returnValue)
    {
        UnityWebRequest webRequest = new UnityWebRequest(url + table, "GET");
        webRequest.SetRequestHeader("Authorization", $"Bearer {key}");
        yield return webRequest.SendWebRequest();
        returnValue.value = !webRequest.isNetworkError;
    }

    public static IEnumerator GetRecords<T>(string table, string view, int maxRecords, Result<T> result)
    {
        var request = new UnityWebRequest(url + table, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Authorization", $"Bearer {key}");
        request.SetRequestHeader("Content-Type", "application/json");
        request.url += $"?view={view}";
        request.url += $"&maxRecords={maxRecords}";
        result.request = request;
        yield return request.SendWebRequest();
        result.data = JsonUtility.FromJson<T>(request.downloadHandler.text);
    }

    public static IEnumerator CreateRecord<T>(string table, T record)
    {
        var request = new UnityWebRequest(url + table, "POST");
        var postData = JsonUtility.ToJson(record, false);
        var rawData = Encoding.UTF8.GetBytes(postData);
        request.uploadHandler = new UploadHandlerRaw(rawData);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Authorization", $"Bearer {key}");
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        yield return null;
    }

    public class Result<T>
    {
        public UnityWebRequest request;
        public T data;
    }

    [Serializable]
    public class HighScoreRecords
    {
        public List<HighScoreRecord> records;

        [Serializable]
        public class HighScoreRecord
        {
            public HighScores fields;

            [Serializable]
            public class HighScores
            {
                public string Name;
                public float Depth;
                public float Time;
            }
        }
    }

    public class Value<T>
    {
        public T value;
    }
}