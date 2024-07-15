using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WCSTrainer.Models;

namespace WCSTrainer.Data {
    public class DataUtils {
        private readonly WCSTrainerContext _context;

        public DataUtils(WCSTrainerContext context) {
            _context = context;
        }

        public async Task<Employee?> GetEmployeeById(int id) {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Location?> GetLocationById(int id) {
            return await _context.Locations.FindAsync(id);
        }

        public async Task<Skill?> GetSkillById(int id) {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<TrainerGroup?> GetTrainerGroupById(int id) {
            return await _context.TrainerGroups.FindAsync(id);
        }

        public async Task<TrainingOrder?> GetTrainingOrderById(int id) {
            return await _context.TrainingOrders.FindAsync(id);
        }

        public async Task<Verification?> GetVerificationById(int id) {
            return await _context.Verifications.FindAsync(id);
        }
    }
}
