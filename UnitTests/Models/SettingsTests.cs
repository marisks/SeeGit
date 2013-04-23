﻿using SeeGit;
using SeeGit.Models;
using System;
using Xunit;

namespace UnitTests.Models
{
    public class SettingsTests
    {
        public class TheCtor
        {
            [Fact]
            public void SetsProperties()
            {
                var settings = new Settings();

                // Get From File Test
                Assert.Equal(true, Convert.ToBoolean(settings.GetSetting("TrueSetting", String.Empty)));

                // Default Setting Test
                Assert.Equal("default", settings.GetSetting("asdf", "default", true));

                // Check Create method
                Assert.Equal("default", settings.GetSetting("asdf", String.Empty));

                // Set Setting Test
                settings.SetSetting("mySetting", "False");
                Assert.Equal("False", settings.GetSetting("mySetting", String.Empty));

                // Remove Setting
                string fileValue = settings.GetSetting("ToBeRemovedSetting", "xmlvalue");
                settings.RemoveSetting("ToBeRemovedSetting");
                Assert.NotEqual(fileValue, settings.GetSetting("ToBeRemovedSetting", "notthexml"));
                settings.Save();
            }
        }
    }
}