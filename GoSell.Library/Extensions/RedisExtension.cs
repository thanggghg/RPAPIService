using GoSell.Library.Db;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Core.Implementations;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace GoSell.Library.Extensions
{
    public static class RedisExtension
    {
        private const int DEFAULT_MIN_WORKER_THREADS = 100;
        private const int DEFAULT_MIN_IO_THREADS = 100;
        private const string HmGetScript = (@"return redis.call('HMGET', KEYS[1], unpack(ARGV))");
        public static IServiceCollection AddCachesMemoryOrRedis(this IServiceCollection services, string sectionName = "Redis", IConfiguration configuration = null)
        {
            var _configuration = configuration == null ? services.BuildServiceProvider().GetService<IConfiguration>() : configuration;

            var redisSection = _configuration.GetSectionWithEnvironment(sectionName);
            Console.WriteLine($"redis: {redisSection}");
            if (redisSection == null)
            {
                throw new ArgumentNullException("Redis configuration should not be null.");
            }

            var redisConfiguration = redisSection.Get<RedisConfiguration>();

            services.AddSingleton(redisConfiguration);
            services.AddSingleton<IDistributedCache, RedisCache>();
            services.AddSingleton<IRedisClient, RedisClient>();
            services.AddSingleton<IRedisConnectionPoolManager, RedisConnectionPoolManager>();
            services.AddSingleton<ISerializer, NewtonsoftSerializer>();

            services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);
            SetMinThreads();
            return services;
        }

        public static void SetMinThreads()
        {
            int defaultMinWorkerThreads = DEFAULT_MIN_WORKER_THREADS;
            int defaultMinIoThreads = DEFAULT_MIN_IO_THREADS;

            string workerThreads = Environment.GetEnvironmentVariable("DefaultMinWorkerThreads");
            string iocpThreads = Environment.GetEnvironmentVariable("DefaultMinIoThreads");

            if (!string.IsNullOrEmpty(workerThreads))
            {
                int.TryParse(workerThreads, out defaultMinWorkerThreads);
            }

            if (!string.IsNullOrEmpty(iocpThreads))
            {
                int.TryParse(iocpThreads, out defaultMinIoThreads);
            }

            ThreadPool.SetMinThreads(defaultMinWorkerThreads, defaultMinIoThreads);
        }
        internal static RedisValue[] HashMemberGet(this StackExchange.Redis.IDatabase cache, string key, params string[] members)
        {
            var result = cache.ScriptEvaluate(
                HmGetScript,
                new RedisKey[] { key },
                GetRedisMembers(members));

            return (RedisValue[])result;
        }

        internal static async Task<RedisValue[]> HashMemberGetAsync(
            this StackExchange.Redis.IDatabase cache,
            string key,
            params string[] members)
        {
            var result = await cache.ScriptEvaluateAsync(
                HmGetScript,
                new RedisKey[] { key },
                GetRedisMembers(members)).ConfigureAwait(false);

            return (RedisValue[])result;
        }

        private static RedisValue[] GetRedisMembers(params string[] members)
        {
            var redisMembers = new RedisValue[members.Length];
            for (int i = 0; i < members.Length; i++)
            {
                redisMembers[i] = (RedisValue)members[i];
            }

            return redisMembers;
        }
    }
}
