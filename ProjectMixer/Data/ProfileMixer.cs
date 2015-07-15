using ProjectMixer.Data.Entities;

namespace ProjectMixer.Data
{
	public class ProfileMixer
	{
		/// <summary>
		/// Number of milliseconds per frame
		/// 20 ms ~ 50 FPS
		/// 40 ms ~ 25 FPS
		/// </summary>
		private const long FRAME_LENGTH = 20;

		public ProfileMixer()
		{

		}

		public void ApplyProfile(Profile profile)
		{
			// TODO This needs to be asynchronous that then posts messages to the event thread
			long frameCount = profile.FadeLength / FRAME_LENGTH;


		}

	}
}
