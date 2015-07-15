using System.Collections.Generic;

namespace ProjectMixer.Data.Entities
{
	/// <summary>
	/// Represents a snapshot of mixer settings
	/// </summary>
	public class Profile
	{
		/// <summary>
		/// Unique name that will used as the identifier
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Mixer entries
		/// </summary>
		public List<ProfileMixerEntry> Entries { get; private set; }

		/// <summary>
		/// Length of time in milliseconds to fade volumes (default: 0 = no fade)
		/// </summary>
		public long FadeLength { get; set; }

		/// <summary>
		/// Default constructor
		/// </summary>
		public Profile()
		{
			Entries = new List<ProfileMixerEntry>();
		}

		/// <summary>
		/// Represents a single mixer fader
		/// </summary>
		public class ProfileMixerEntry
		{
			/// <summary>
			/// Mixer level for this entry
			/// </summary>
			public float Level { get; set; }

			// TODO Package/application/program id

		}
	}
}
