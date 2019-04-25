using System;
using System.Collections.Generic;
using Swgoh.Dto.Requests;
using Swgoh.Dto.Swgoh.Dto;
using Swgoh.Service.Constants;

namespace Swgoh.Service.Services
{
    internal interface IGuildService
    {
        List<Guild> GetGuilds(GuildsRequest guildsRequest);
    }

    internal class GuildService : ServiceBase, IGuildService
    {
        private readonly ISwgohFlurlService _swgohFlurlService;
        private readonly string _path;

        public GuildService(ISwgohFlurlService swgohFlurlService)
        {
            _swgohFlurlService = swgohFlurlService;
            _path = Client.BaseAddress + UrlConstants.Player;
        }

        public List<Guild> GetGuilds(GuildsRequest guildsRequest)
        {
            throw new NotImplementedException();
        }
    }
}
