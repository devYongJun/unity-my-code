#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.IO;

namespace devy
{

	static public class DataManager
	{
		static public bool IsExistFile(string filename)
		{
#if !WEB_BUILD
			string path = PathForDocumentsFile(filename);
			return File.Exists(path);
#else
		return null;
#endif
		}
		static public string ReadStringFromFile(string filename)
		{
#if !WEB_BUILD
			string path = PathForDocumentsFile(filename);

			if (!File.Exists(path))
			{
				return null;
			}

			return System.IO.File.ReadAllText(path);
#else
		return null;
#endif
		}

		static public string PathForDocumentsFile(string filename)
		{
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				string path = Application.persistentDataPath;
				//Debug.Log ("IOS Application.persistentDataPath :" + Application.persistentDataPath);
				return Path.Combine(path, filename);
			}

			else if (Application.platform == RuntimePlatform.Android)
			{
				string path = Application.persistentDataPath;
				path = path.Substring(0, path.LastIndexOf('/'));
				//Debug.Log ("AOS Application.persistentDataPath :" + Application.persistentDataPath);
				return Path.Combine(path, filename);
			}
			else
			{
				string path = Application.dataPath;
				path = path.Substring(0, path.LastIndexOf('/'));
				string returnStr = Path.Combine(path, filename);
				//Debug.Log("returnStr:"+returnStr);
				return returnStr;
			}
		}

		static public void WriteStringToFile(string str, string filename)
		{
#if !WEB_BUILD
			string path = PathForDocumentsFile(filename);
			FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);

			StreamWriter sw = new StreamWriter(file);
			sw.WriteLine(str);

			sw.Close();
			file.Close();
#endif

#if UNITY_EDITOR
			AssetDatabase.Refresh();
#endif
		}
	}
}