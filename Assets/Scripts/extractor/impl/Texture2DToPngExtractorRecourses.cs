using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.extractor.impl {
    public class Texture2DToPngExtractorRecourses : ExtractorRecourses {
        public void extraxt(object asset, string path) {
            Texture2D texture = (UnityEngine.Texture2D)asset;

            string assetPath = AssetDatabase.GetAssetPath(texture);
            Debug.Log(assetPath);
            TextureImporter tImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            Debug.Log(tImporter == null);
            if (tImporter != null) {
                tImporter.textureType = TextureImporterType.Default;

                tImporter.isReadable = true;

                AssetDatabase.ImportAsset(assetPath);
                AssetDatabase.Refresh();
            }

            byte[] _bytes = texture.EncodeToPNG();
            System.IO.File.WriteAllBytes(path, _bytes);
            Debug.Log(_bytes.Length / 1024 + "Kb was saved as: " + path);
        }
    }
}