using Common.UI.Hotkeys;
using ProjectMixer.Data;
using ProjectMixer.Properties;
using ProjectMixer.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMixer
{
	class MixerTrayApplicationContext : Common.TrayApplication.TrayApplicationContext<SettingsObject>
	{
		private HotkeyManager _HotkeyManager;

		protected override void OnInitializeContext()
		{
			_HotkeyManager = new HotkeyManager();
			// TODO
		}

		protected override Common.TrayApplication.OptionsForm BuildOptionsForm()
		{
			return new MixerOptionsForm();
		}

		protected override void BuildContextMenu()
		{
			// TODO
		}

		protected override Icon ApplicationIcon
		{
			get
			{
				return new Icon(GetType(), "appicon.ico");
			}
		}

		protected override string ApplicationName
		{
			get
			{
				return Resources.ApplicationName;
			}
		}

		protected override string AppDataPath
		{
			get
			{
				return Path.GetDirectoryName(Path.GetFullPath(Uri.UnescapeDataString(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath)));
			}
		}

		protected override void Dispose(bool disposing)
		{
			_HotkeyManager.Dispose();
			base.Dispose(disposing);
		}
	}
}
