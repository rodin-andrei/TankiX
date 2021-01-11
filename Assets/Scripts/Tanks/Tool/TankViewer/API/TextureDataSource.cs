using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Tanks.Tool.TankViewer.API
{
	public class TextureDataSource : MonoBehaviour
	{
		private List<string> filePaths;

		private string basePath;

		private UnityWebRequest webRequest;

		private int index;

		private List<TextureData> data = new List<TextureData>();

		public Action onStartUpdatingAction;

		public Action onCompleteUpdatingAction;

		private List<TextureData> convertedToNormalMap = new List<TextureData>();

		public bool TexturesAreReady
		{
			get;
			private set;
		}

		public void UpdateData()
		{
			TexturesAreReady = false;
			Clean();
			onStartUpdatingAction();
			basePath = Path.GetFullPath("workspace");
			if (!Directory.Exists(basePath))
			{
				Directory.CreateDirectory(basePath);
			}
			filePaths = Directory.GetFiles(basePath).ToList();
			for (int num = filePaths.Count - 1; num >= 0; num--)
			{
				string text = Path.GetExtension(filePaths[num]).ToLower();
				if (!text.Equals(".png") && !text.Equals(".jpg"))
				{
					filePaths.RemoveAt(num);
				}
			}
			index = 0;
			if (filePaths.Count > 0)
			{
				LoadNextTexture();
			}
			else
			{
				Complete();
			}
		}

		private void Update()
		{
			if (webRequest != null && webRequest.isError)
			{
				Debug.Log(webRequest.error + " url:  " + webRequest.url);
			}
			if (webRequest != null && webRequest.isDone && !TexturesAreReady)
			{
				Texture2D texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
				data.Add(new TextureData(filePaths[index], TextureLoadingUtility.CreateTextureWithGamma(texture)));
				convertedToNormalMap.Add(new TextureData(filePaths[index], TextureLoadingUtility.CreateNormalMap(texture)));
				UnityEngine.Object.Destroy(texture);
				index++;
				if (index < filePaths.Count)
				{
					LoadNextTexture();
				}
				else
				{
					Complete();
				}
			}
		}

		private void Complete()
		{
			webRequest = null;
			TexturesAreReady = true;
			onCompleteUpdatingAction();
		}

		private void LoadNextTexture()
		{
			webRequest = UnityWebRequest.GetTexture(filePaths[index]);
			webRequest.Send();
		}

		public List<TextureData> GetData()
		{
			return data;
		}

		public List<TextureData> GetNormalMapsData()
		{
			return convertedToNormalMap;
		}

		private void Clean()
		{
			for (int i = 0; i < data.Count; i++)
			{
				UnityEngine.Object.Destroy(data[i].texture2D);
				if (convertedToNormalMap[i] != null)
				{
					UnityEngine.Object.Destroy(convertedToNormalMap[i].texture2D);
				}
			}
			data.Clear();
			convertedToNormalMap.Clear();
		}
	}
}
