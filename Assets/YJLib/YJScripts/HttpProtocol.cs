using System;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace devy
{
    public class HttpProtocol : MonoBehaviour
    {
#if !UnityEditor
        [ContextMenu("Test Request")]
        public void TestRequest()
        {
            Uri uri = new Uri("{URL_STRING}");
            string json = "{JSON_STRING}";
            StartCoroutine(Request(uri, "POST", json, (request)=>
            {
                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.LogError($"TestRequest() Error : {request.error}");
                }
                else
                {
                    Debug.LogError($"TestRequest() Done : {request.downloadHandler.text}");
                }
            }));
        }
#endif

        IEnumerator Request(Uri uri, string method, string data = null, Action<UnityWebRequest> done = null)
        {
            UnityWebRequest request;

            switch (method)
            {
                case UnityWebRequest.kHttpVerbGET:
                    request = UnityWebRequest.Get(uri);
                    yield return request.SendWebRequest();
                    done?.Invoke(request);
                    break;
                case UnityWebRequest.kHttpVerbPOST:
                    request = UnityWebRequest.Post(uri, data);
                    request.method = UnityWebRequest.kHttpVerbPOST;
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(data));
                    request.SetRequestHeader("Content-Type", "application/json");
                    request.SetRequestHeader("Accept", "application/json");
                    yield return request.SendWebRequest();
                    done?.Invoke(request);
                    break;
                case UnityWebRequest.kHttpVerbPUT:
                    request = UnityWebRequest.Put(uri, data);
                    request.method = UnityWebRequest.kHttpVerbPUT;
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(data));
                    request.SetRequestHeader("Content-Type", "application/json");
                    request.SetRequestHeader("Accept", "application/json");
                    yield return request.SendWebRequest();
                    done?.Invoke(request);
                    break;
                default:
                    Debug.Assert(true, $"처리되지않는 리퀘스트 요청 : {method}");
                    break;
            }
        }
    }
}

