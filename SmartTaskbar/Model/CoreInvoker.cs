﻿using System;
using SmartTaskbar.Core;
using SmartTaskbar.Core.Settings;
using SmartTaskbar.Languages;

namespace SmartTaskbar.Model
{
    public class CoreInvoker : IDisposable
    {
        private readonly CultureResource _cultureResource;

        public CoreInvoker()
        {
            ModeSwitch = new AutoModeSwitcher(this);
            _cultureResource = new CultureResource(this);
        }

        public UserSettings UserSettings { get; set; } = InvokeMethods.GetUserSettings();

        public AutoModeSwitcher ModeSwitch { get; }

        public void Dispose() => ModeSwitch?.Dispose();

        public void ReloadSetting() => UserSettings = InvokeMethods.GetUserSettings();

        public void SaveUserSettings()
        {
            InvokeMethods.SaveUserSettings(UserSettings);
            _cultureResource.LanguageChange();
        }

        public string GetText(string name) => _cultureResource.GetText(name);
    }
}