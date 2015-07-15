using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectMixer.Data.Entities;
using log4net;

namespace ProjectMixer.Data
{
	public class ProfileManager
	{
		private ILog Logger { get; set; }

		private Dictionary<string, Profile> _Profiles;

		public ProfileManager()
		{
			Logger = LogManager.GetLogger(typeof(ProfileManager));
            _Profiles = new Dictionary<string, Profile>();
		}

		#region Loading and Saving

		public void Load(string filename, Action callback)
		{
			try
			{
				// TODO Read `filename` file into string, parse as JSON:
				string json = "";
				List<Profile> profileList = JsonConvert.DeserializeObject<List<Profile>>(json);

				// Process into dictionary:
				Dictionary<string, Profile> profilesNew = new Dictionary<string, Profile>();
				foreach (Profile profile in profileList)
				{
					profilesNew.Add(profile.Name, profile);
				}

				// Atomic action to replace profiles with newly loaded profiles from file
				_Profiles = profilesNew;
			}
			catch (JsonException e)
			{
				Logger.Error("Failed to load profiles, failed to parse JSON:", e);
			}
			catch (ArgumentException e)
			{
				Logger.Error("Failed to load profiles, non-unique Name detected.");
			}

		}

		public void Save(string filename, Action callback)
		{
			// TODO Serialize to JSON and save to file
		}

		#endregion
	}
}
