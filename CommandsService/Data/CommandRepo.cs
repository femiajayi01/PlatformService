using CommandsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;
        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentException(nameof(command));
            }

            command.PlatformId = platformId;
            _context.Commands.Add(command);
        }

        public void CreatePlatforms(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentException(nameof(platform));
            }

            _context.Platforms.Add(platform);
        }

        public bool ExternalPlatformExists(int externalPlatformId)
        {
            return _context.Platforms.Any(p => p.ExternalID == externalPlatformId);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _context.Commands
                .Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefault();
        }
        
        public IEnumerable<Command> GetCommandsForPlatforms(int platformId)
        {
            return _context.Commands
                .Where(c => c.PlatformId == platformId)
                .OrderBy(c => c.Platform.Name);
        }

        public bool PlatformExists(int platformId)
        {
            return _context.Platforms.Any(p => p.Id == platformId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
