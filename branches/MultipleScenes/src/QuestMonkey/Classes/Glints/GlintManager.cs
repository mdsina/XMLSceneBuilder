using System.Collections.Generic;
using HiddenObjectStudio.Core.LocationManagement;
using HiddenObjectStudio.Core;

namespace QuestMonkey
{
	public class GlintManager
	{
		private Config Config;

		private Dictionary<string, SceneGlints> _sceneGlints;

		public GlintManager()
		{
			Config = new Config();

			_sceneGlints = new Dictionary<string, SceneGlints>();
		}

		public void Load(LocationManager locationManager)
		{
			foreach (SceneInfo sceneInfo in locationManager.AllScenes)
			{
				AddSceneGlints(sceneInfo);
			}
		}

		public void Reload(LocationManager locationManager)
		{
			_sceneGlints.Clear();

			Load(locationManager);
		}

		public void AddGlintToScene(string glintName, string layerName, SceneInfo scene)
		{
			SceneGlints sceneGlints = GetSceneGlints(scene);

			if (sceneGlints == null)
			{
				sceneGlints = AddSceneGlints(scene);
			}
			
			if (sceneGlints.GetGlintByName(glintName) == null)
			{
				sceneGlints.AddGlint(glintName, layerName);
			}
		}

		public void RemoveGlintFromScene(string glintName, SceneInfo scene)
		{
			SceneGlints sceneGlints = GetSceneGlints(scene);

			if (sceneGlints != null)
			{
				sceneGlints.RemoveGlint(glintName);
			}
		}

		public SceneGlints GetSceneGlints(SceneInfo scene)
		{
			if (!string.IsNullOrEmpty(scene.GlintsFileName))
			{
				string key = GenerateKeyForScene(scene);

				SceneGlints foundSceneGlints;

				_sceneGlints.TryGetValue(key, out foundSceneGlints);

				if (foundSceneGlints != null)
				{
					return foundSceneGlints;
				}
				else
				{
					return null;
				}
			}
			else
			{
				return null;
			}
		}

		public SceneGlints AddSceneGlints(SceneInfo scene)
		{
			if (scene.GlintsFileName == string.Empty)
			{
				scene.GlintsFileName = "glints.xml";
			}

			string key = GenerateKeyForScene(scene);

			string fileName = Config.ScenesPath + "\\" + scene.FolderName + "\\" + scene.GlintsFileName;

			SceneGlints newSceneGlints = new SceneGlints(fileName);

			_sceneGlints.Add(key, newSceneGlints);

			return newSceneGlints;

		}

		public List<Glint> GetAllGlintsOnLocation(string locationName, LocationManager locationManager)
		{
			List<Glint> allGlintsOnLocation = new List<Glint>();

			Location location = locationManager.GetLocation(locationName);

			SceneGlints glintsOnMainScene = GetSceneGlints(location.AllScenes[0]);

			if (glintsOnMainScene != null)
			{
				foreach (Glint glint in glintsOnMainScene.GetAllGlints())
				{
					allGlintsOnLocation.Add(glint);
				}
			}
			

			foreach (SceneInfo subscreen in location.AllSubscreens)
			{
				SceneGlints glintsOnSubscreen = GetSceneGlints(subscreen);

				if (glintsOnSubscreen != null)
				{
					foreach (Glint glint in glintsOnSubscreen.GetAllGlints())
					{
						allGlintsOnLocation.Add(glint);
					}
				}
			}

			return allGlintsOnLocation;
		}

		public bool IsAnyFileModified()
		{
			foreach (string key in _sceneGlints.Keys)
			{
				if (_sceneGlints[key].IsFileModified())
				{
					return true;
				}
			}

			return false;
		}
		
		public void SaveAll()
		{
			foreach (string key in _sceneGlints.Keys)
			{
				_sceneGlints[key].Save();
			}
		}

		private string GenerateKeyForScene(SceneInfo sceneInfo)
		{
			return sceneInfo.OwnerLocation.Name + ": " + Config.ScenesPath + "\\" + sceneInfo.SceneFilePath;
		}
	}
}
