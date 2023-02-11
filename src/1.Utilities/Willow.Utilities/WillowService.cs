using Microsoft.Extensions.Logging;
using Willow.Extensions.Caching.Abstractions;
using Willow.Extensions.ObjectMappers.Abstractions;
using Willow.Extensions.Serializers.Abstractions;
using Willow.Extensions.Translations.Abstractions;
using Willow.Extensions.UsersManagement.Abstractions;

namespace Willow.Utilities
{
    public class WillowService
    {
        public readonly ITranslator Translator;
        public readonly ICacheAdapter CacheAdapter;
        public readonly IMapperAdapter MapperFacade;
        public readonly ILoggerFactory LoggerFactory;
        public readonly IJsonSerializer Serializer;
        public readonly IUserInfoService UserInfoService;

        public WillowService(ITranslator translator,
            ILoggerFactory loggerFactory,
            IJsonSerializer serializer,
            IUserInfoService userInfoService,
            ICacheAdapter cacheAdapter,
            IMapperAdapter mapperFacade)
        {
            Translator = translator;
            LoggerFactory = loggerFactory;
            Serializer = serializer;
            UserInfoService = userInfoService;
            CacheAdapter = cacheAdapter;
            MapperFacade = mapperFacade;
        }
    }
}
