﻿using System.IO;

using nJupiter.Configuration;

using NUnit.Framework;

namespace nJupiter.UnitTests.Configuration {

	[TestFixture]
	internal class FileConfigFactoryTest {
		const string systemConfigPath = @"C:\Projects\nJupiter\Development\Shared Resources\Config\System.config";
		const string nonExistingFile = @"C:\Projects\nJupiter\Development\Shared Resources\Config\NonExistingFile.config";
		
		[Test]
		public void CreateWithWatcher_CreateFromPath_ReturnConfigWithWatcher() {
			Assume.That(File.Exists(systemConfigPath));
			var config = FileConfigFactory.CreateWithWatcher(systemConfigPath);
			Assert.IsNotNull(config);
			Assert.IsNotNull(config.ConfigSource);
			Assert.IsNotNull(config.ConfigSource.Watcher);
			Assert.AreEqual("System", config.ConfigKey);
		}

		[Test]
		public void CreateWithWatcher_CreateFromPathWithCustomKey_ReturnConfigWithWatcher() {
			Assume.That(File.Exists(systemConfigPath));
			string key = "myKey";
			var config = FileConfigFactory.CreateWithWatcher(key, systemConfigPath);
			Assert.IsNotNull(config);
			Assert.IsNotNull(config.ConfigSource);
			Assert.IsNotNull(config.ConfigSource.Watcher);
			Assert.AreEqual(key, config.ConfigKey);
		}

		[Test]
		public void CreateWithWatcher_CreateFromFileInfo_ReturnConfigWithWatcher() {
			Assume.That(File.Exists(systemConfigPath));
			var config = FileConfigFactory.CreateWithWatcher(new FileInfo(systemConfigPath));
			Assert.IsNotNull(config);
			Assert.IsNotNull(config.ConfigSource);
			Assert.IsNotNull(config.ConfigSource.Watcher);
			Assert.AreEqual("System", config.ConfigKey);
		}

		[Test]
		public void CreateWithWatcher_CreateFromFileInfoWithCustomKey_ReturnConfigWithWatcher() {
			Assume.That(File.Exists(systemConfigPath));
			const string key = "myKey";
			var config = FileConfigFactory.CreateWithWatcher(key, new FileInfo(systemConfigPath));
			Assert.IsNotNull(config);
			Assert.IsNotNull(config.ConfigSource);
			Assert.IsNotNull(config.ConfigSource.Watcher);
			Assert.AreEqual(key, config.ConfigKey);
		}

		[Test]
		public void CreateWithWatcher_CreateFromPathNonExistingFile_ReturnConfigWithWatcher() {
			Assume.That(!File.Exists(nonExistingFile));
			Assert.Throws<FileNotFoundException>(() => FileConfigFactory.CreateWithWatcher(nonExistingFile));
		}

		[Test]
		public void Create_CreateFromPath_ReturnConfigWithWatcher() {
			Assume.That(File.Exists(systemConfigPath));
			var config = FileConfigFactory.Create(systemConfigPath);
			Assert.IsNotNull(config);
			Assert.IsNotNull(config.ConfigSource);
			Assert.IsNull(config.ConfigSource.Watcher);
			Assert.AreEqual("System", config.ConfigKey);
		}

		[Test]
		public void Create_CreateFromPathWithCustomKey_ReturnConfigWithWatcher() {
			Assume.That(File.Exists(systemConfigPath));
			string key = "myKey";
			var config = FileConfigFactory.Create(key, systemConfigPath);
			Assert.IsNotNull(config);
			Assert.IsNotNull(config.ConfigSource);
			Assert.IsNull(config.ConfigSource.Watcher);
			Assert.AreEqual(key, config.ConfigKey);
		}

		[Test]
		public void Create_CreateFromFileInfo_ReturnConfigWithWatcher() {
			Assume.That(File.Exists(systemConfigPath));
			var config = FileConfigFactory.Create(new FileInfo(systemConfigPath));
			Assert.IsNotNull(config);
			Assert.IsNotNull(config.ConfigSource);
			Assert.IsNull(config.ConfigSource.Watcher);
			Assert.AreEqual("System", config.ConfigKey);
		}

		[Test]
		public void Create_CreateFromFileInfoWithCustomKey_ReturnConfigWithWatcher() {
			Assume.That(File.Exists(systemConfigPath));
			const string key = "myKey";
			var config = FileConfigFactory.Create(key, new FileInfo(systemConfigPath));
			Assert.IsNotNull(config);
			Assert.IsNotNull(config.ConfigSource);
			Assert.IsNull(config.ConfigSource.Watcher);
			Assert.AreEqual(key, config.ConfigKey);
		}

	}
}