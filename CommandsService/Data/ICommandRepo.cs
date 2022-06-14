using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        // Platforms
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatforms(Platform platform);
        bool PlatformExists(int PlatformId);
        bool ExternalPlatformExists(int externalPlatformId);

        // Commands
        IEnumerable<Command> GetCommandsForPlatforms(int platformId);
        Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId, Command command);

    }
}
