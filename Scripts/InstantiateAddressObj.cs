using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class InstantiateObj : MonoBehaviour
{
	public AssetReferenceGameObject[] instantiate;
	public int indexShow;
	public GameObject parent;

	public async void ShowSingle()
	{
		parent.SetActive(false);
		for (int i = 0; i < instantiate.Length; i++)
		{
			AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(instantiate[i], parent.transform);
			await handle.Task;
			GameObject obj = handle.Result;
			if(i != indexShow)
			{
				obj.SetActive(false);
			}
		}
		parent.SetActive(true);
	}
	
	public async void ShowAll()
	{
		parent.SetActive(false);
		for (int i = 0; i < instantiate.Length; i++)
		{
			AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(instantiate[i], parent.transform);
			await handle.Task;
			GameObject obj = handle.Result;
		}
		parent.SetActive(true);
	}
}