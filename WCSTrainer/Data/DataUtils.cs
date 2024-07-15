using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;

namespace WCSTrainer.Data {
    public class DataUtils {
        private readonly DbContext _context;

        public DataUtils(DbContext context) {
            _context = context;
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
    }
}
