using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;

namespace WCSTrainer.Data {
    public class DataUtils {
        private readonly WCSTrainerContext _context;

        private List<Location> Locations;

        public DataUtils(WCSTrainerContext context) {
            _context = context;
            initVars();
        }

        public async void initVars() {
            Locations = await _context.Locations.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(int id) {
            return await _context.Set<Employee>().FindAsync(id);
        }

        public async Task<Location?> GetLocationById(int id) {
            return await _context.Set<Location>().FindAsync(id);
        }

        public async Task<Skill?> GetSkillById(int id) {
            return await _context.Set<Skill>().FindAsync(id);
        }

        public async Task<TrainerGroup?> GetTrainerGroupById(int id) {
            return await _context.Set<TrainerGroup>().FindAsync(id);
        }

        public async Task<TrainingOrder?> GetTrainingOrderById(int id) {
            return await _context.Set<TrainingOrder>().FindAsync(id);
        }

        public async Task<Verification?> GetVerificationById(int id) {
            return await _context.Set<Verification>().FindAsync(id);
        }

        public Location? GetLocationFromId(int id) {
            foreach (var loc in Locations) {
                if (loc.Id == id) {
                    return loc;
                }
            }
            return null;
        }
    }
}
