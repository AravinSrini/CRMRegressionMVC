Configuration
-------------
	var memoryCacheConfig = new ConfigurationBuilder();
	string cacheName = "CacheOfMyCustomTypes";
	
Self-initialization
-------------------
	ICacheProvider<MyCustomType> cacheProvider= new MemoryCacheProvider<MyCustomType>(cacheName, memoryCacheConfig);

	
Registering with the Unity IoC (via Extension methods)
------------------------------------------------------    
    UnityContainer.RegisterMemoryCacheProvider(cacheName, memoryCacheConfig, "memorycache");
	
    public static class ExtensionMethods
    {
        /// <summary>
        /// Registers a singleton instance of the MemoryCacheProvider
        /// </summary>
        /// <param name="unityContainer">The Unity Container</param>
        /// <param name="ns">Namespace (aka Cache name)</param>
        /// <param name="configBuilder"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IUnityContainer RegisterMemoryCacheProvider(this IUnityContainer unityContainer, string ns, ConfigurationBuilder configBuilder, string name="default")
        {
            unityContainer.RegisterType(typeof(ICacheProvider<>), typeof(MemoryCacheProvider<>),
                name,
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(ns,configBuilder));

            return unityContainer;
        }
     }

Basic operations
----------------
		private ICacheProvider<string> _stringCacheProvider;

        private ICacheProvider<string> InitializeStringCache()
        {
            if (_stringCacheProvider == null)
            {
                var cacheConfig = new ConfigurationBuilder();
                const string cacheName = "CacheOfStrings";

                _stringCacheProvider = new MemoryCacheProvider<string>(cacheName, cacheConfig);
            }

            return _stringCacheProvider;
        }

        private void AddItem()
        {
            var cacheProvider = InitializeStringCache();

            cacheProvider.AddOrUpdateItem("superman", "Kent, Clark", TimeSpan.FromSeconds(90));
            cacheProvider.AddOrUpdateItem("batman", "Wayne, Bruce", TimeSpan.FromSeconds(90));
            cacheProvider.AddOrUpdateItem("spiderman", "Parker, Peter", TimeSpan.FromSeconds(90));
        }

        private void GetItem()
        {
            var cacheProvider = InitializeStringCache();

            string value;
            cacheProvider.GetItem("batman", out value);
        }
	