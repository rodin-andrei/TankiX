using System;

[Serializable]
public class BundleInfo
{
	public string bundleName;

	public string hash;

	public long crc;

	public long cacheCrc;

	public long size;

	public string[] dependenciesNames;

	public AssetInfo[] assets;

	public int modificationHash;
}