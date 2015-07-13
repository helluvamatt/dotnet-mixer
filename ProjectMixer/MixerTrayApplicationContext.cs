using Common.TrayApplication;
using Common.UI.Hotkeys;
using Common.UI.Win32Interop;
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
using System.Windows.Forms;

namespace ProjectMixer
{
	class MixerTrayApplicationContext : Common.TrayApplication.TrayApplicationContext<SettingsObject>
	{
		private HotkeyManager _HotkeyManager;

		public MixerTrayApplicationContext() : base()
		{
			_HotkeyManager = new HotkeyManager();
		}

		#region Hotkey Names

		public const string HK_SELECTOR = "Selector";

		#endregion

		#region Properties

		private const string INI_FILE_NAME = "ProjectMixer.ini";
		private string IniFile
		{
			get
			{
				return Path.Combine(AppDataPath, INI_FILE_NAME);
			}
		}

		#endregion

		#region TrayApplicationContext implementation

		protected override void OnInitializeContext()
		{
			// Initialize the hotkey manager
			_HotkeyManager.AddHook(HK_SELECTOR, Resources.Hotkey_Selector_Name, Resources.Hotkey_Selector_Desc, hotkey_ShowSelector);

			// TODO Continue initializing the application

			// Load application configuration
			LoadSettingsAsync(Settings => {

				// Initialize the database
				//_DatabaseManager.SetDatabase(Settings.DatabaseType, Settings.DatabaseProperties);

				// Initialize hotkeys
				foreach (KeyValuePair<string, GlobalHotkeyHook> entry in _HotkeyManager.GetHooks())
				{
					if (Settings.Hotkeys != null && Settings.Hotkeys.ContainsKey(entry.Key))
					{
						entry.Value.Key = Settings.Hotkeys[entry.Key];
					}
					if (Settings.HotkeyEnabled != null && Settings.HotkeyEnabled.ContainsKey(entry.Key))
					{
						entry.Value.Enabled = Settings.HotkeyEnabled[entry.Key];
					}
				}
				_HotkeyManager.Enabled = Settings.HotkeysEnabled;

				// Populate settings
				if (optionsForm != null)
				{
					optionsForm.PopulateSettings();
				}

			}, IniFile);
		}

		protected override OptionsForm OnBuildOptionsForm()
		{
			MixerOptionsForm form = new MixerOptionsForm();
			form.OptionChanged += MixerOptionsForm_OptionChanged;
			return form;
		}

		protected override void OnBuildContextMenu(ContextMenuStrip menu)
		{
			// Build the context menu: manageMenuItem
			ToolStripMenuItem manageMenuItem = new ToolStripMenuItem(Resources.MenuItemManage);
			manageMenuItem.Click += ManageMenuItem_Click;

			// Build the context menu: exitMenuItem
			ToolStripMenuItem exitMenuItem = new ToolStripMenuItem(Resources.MenuItemExit);
			exitMenuItem.Click += exitMenuItem_Click;

			// Build contextMenu
			menu.Items.Add(manageMenuItem);
			menu.Items.Add(new ToolStripSeparator());
			menu.Items.Add(exitMenuItem);
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

		#endregion

		#region Event handlers

		private void MixerOptionsForm_OptionChanged(object sender, OptionChangedEventArgs args)
		{
			// TODO
		}

		private void exitMenuItem_Click(object sender, EventArgs e)
		{
			ExitThread();
		}

		private void ManageMenuItem_Click(object sender, EventArgs e)
		{
			CreateOptionsForm();
		}

		#region Hotkey handlers

		private void hotkey_ShowSelector()
		{
			// TODO Show selector form
		}

		#endregion

		#endregion
	}
}
