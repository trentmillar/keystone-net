using Microsoft.Extensions.Options;

namespace Keystone.Core.Configuration
{
    /// <summary>
    /// Configuration settings from json config file.
    /// </summary>
    public class KeystoneCoreOptions
    {
        public string Environment { get; set; } = "Development";
        public string Name { get; set; } = "Keystone";
        public string Brand { get; set; } = "Keystone";
        public string AdminPath { get; set; } = "keystone";
        public bool Compress { get; set; } = true;
        public bool Headless { get; set; } = false;
        public bool AutoUpdate { get; set; } = false;
        public uint Port { get; set; } = 3000;
        public string Host { get; set; } = "127.0.0.1";
        


    }
}