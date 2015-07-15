using Common.Data;
using Common.UI.Hotkeys;
using Common.UI.Win32Interop;
using log4net;
using ProjectMixer.Data;
using ProjectMixer.Data.Entities;
using ProjectMixer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectMixer.UI
{
	public partial class MixerOptionsForm : Common.TrayApplication.OptionsForm
	{
		private ILog Logger { get; set; }

		private SettingsManager<SettingsObject> _SettingsManager;
		private HotkeyManager _HotkeyManager;

		public MixerOptionsForm(SettingsManager<SettingsObject> sm, HotkeyManager hm)
		{
			// Init logger
			Logger = LogManager.GetLogger(GetType());

			InitializeComponent();

			_SettingsManager = sm;
			_HotkeyManager = hm;
		}

		#region OptionsForm impl

		public override void PopulateSettings()
		{
			// Hotkeys tab
			hotkeysEnabledCheckBox.CheckedChanged -= hotkeysEnabledCheckBox_CheckedChanged;
			hotkeysEnabledCheckBox.Checked = _SettingsManager.SettingsObject.HotkeysEnabled;
			hotkeysEnabledCheckBox.CheckedChanged += hotkeysEnabledCheckBox_CheckedChanged;
			hotkeyListLayoutPanel.Enabled = _SettingsManager.SettingsObject.HotkeysEnabled;

			// Populate hotkeys
			hotkeyListLayoutPanel.Controls.Clear();
			int index = 0;
			foreach (KeyValuePair<string, GlobalHotkeyHook> entry in _HotkeyManager.GetHooks())
			{
				Logger.InfoFormat("Adding hotkey definition: {0} - {1}", entry.Key, entry.Value.Name);
				HotkeyListItem item = new HotkeyListItem(entry.Key, entry.Value);
				item.Dock = DockStyle.Fill;
				item.HotkeyChanged += hotkeyListItems_HotkeyChanged;
				hotkeyListLayoutPanel.Controls.Add(item, 0, index);
				index++;
			}

		}

		#endregion

		#region Event handlers

		#region Form global

		private void optionsFormTabControl_DrawItem(object sender, DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;

			// Get the item from the collection.
			TabPage _tabPage = optionsFormTabControl.TabPages[e.Index];

			// Get the real bounds for the tab rectangle.
			Rectangle _tabBounds = optionsFormTabControl.GetTabRect(e.Index);

			// Draw background
			if (e.State == DrawItemState.Selected)
			{
				g.FillRectangle(Brushes.White, e.Bounds);
			}
			else
			{
				g.FillRectangle(new SolidBrush(BackColor), e.Bounds);
			}

			// Draw icon image
			if (_tabPage == profilesTabPage)
			{
				g.DrawImage(Resources.ic_speaker, _tabBounds.X, _tabBounds.Y, _tabBounds.Height, _tabBounds.Height);
				_tabBounds.X += _tabBounds.Height;
			}
			else if (_tabPage == settingsTabPage)
			{
				g.DrawImage(Resources.ic_action_settings, _tabBounds.X, _tabBounds.Y, _tabBounds.Height, _tabBounds.Height);
				_tabBounds.X += _tabBounds.Height;
			}
			else if (_tabPage == hotkeysTabPage)
			{
				g.DrawImage(Resources.ic_shortcuts, _tabBounds.X, _tabBounds.Y, _tabBounds.Height, _tabBounds.Height);
				_tabBounds.X += _tabBounds.Height;
			}

			// Draw string
			SolidBrush _brush = new SolidBrush(Color.Black);
			StringFormat _stringFlags = new StringFormat();
			_stringFlags.Alignment = StringAlignment.Near;
			_stringFlags.LineAlignment = StringAlignment.Center;
			g.DrawString(_tabPage.Text, e.Font, _brush, _tabBounds, new StringFormat(_stringFlags));
		}

		#endregion

		#region Hotkeys

		private void hotkeysEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool en = hotkeysEnabledCheckBox.Checked;
            _HotkeyManager.Enabled = en;
			_SettingsManager.SettingsObject.HotkeysEnabled = en;
			hotkeyListLayoutPanel.Enabled = en;
			OnOptionChanged("HotkeysEnabled", en);
        }

		private void hotkeyListItems_HotkeyChanged(object sender, HotkeyListItem.HotkeySetComboEventArgs e)
		{
			// Save hotkey settings
			if (_SettingsManager.SettingsObject.Hotkeys == null) _SettingsManager.SettingsObject.Hotkeys = new Dictionary<string, GlobalHotkeyHook.KeyCombo>();
			_SettingsManager.SettingsObject.Hotkeys[e.ItemID] = e.ItemHook.Key;
			if (_SettingsManager.SettingsObject.HotkeyEnabled == null) _SettingsManager.SettingsObject.HotkeyEnabled = new Dictionary<string, bool>();
			_SettingsManager.SettingsObject.HotkeyEnabled[e.ItemID] = e.ItemHook.Enabled;
			OnOptionChanged("Hotkeys", _SettingsManager.SettingsObject.Hotkeys);
		}

		#endregion

		#endregion

		#region Utility methods

		#region Hotkeys tab



		#endregion

		#endregion

	}
}
