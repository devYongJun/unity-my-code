using UnityEngine;
using System.Collections;

namespace devy
{
	public class DontDestroy : MonoBehaviour
	{
		void Awake()
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}
