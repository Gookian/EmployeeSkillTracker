using EmployeeService.Models;

namespace EmployeeService.UnitTests.Comparers
{
    public class SkillEqualityComparer : IEqualityComparer<Skill>
    {
        public bool Equals(Skill? x, Skill? y)
        {
            if (x == null || y == null)
                return false;

            return GetHashCode(x) == GetHashCode(y);
        }

        public int GetHashCode(Skill obj)
        {
            int hash = 17;
            hash ^= obj.Name.GetHashCode();
            hash ^= obj.Level.GetHashCode();

            return hash;
        }
    }
}