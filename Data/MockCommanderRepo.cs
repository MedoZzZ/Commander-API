using System.Windows.Input;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            List<Command>? commands =
            [
                new Command { Id = 0, HowTo = "Boil egg", Line = "Boil Water", Platform = "Pan & Kettle" },
                new Command { Id = 1, HowTo = "Cutting bread", Line = "Get a knife", Platform = "knife & wooden board" },
                new Command { Id = 2, HowTo = "Cup of tea", Line = "Boil some Water", Platform = "boiler & fire" }
        ];
            return commands;        
    }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil egg", Line = "Boil Water", Platform = "Pan & Kettle" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}