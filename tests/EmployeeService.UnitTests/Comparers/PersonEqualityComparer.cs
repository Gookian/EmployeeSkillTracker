using EmployeeService.Models;

namespace EmployeeService.UnitTests.Comparers
{
    public class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person? x, Person? y)
        {
            if (x == null || y == null)
                return false;

            return GetHashCode(x) == GetHashCode(y);
        }

        public int GetHashCode(Person obj)
        {
            var skillComparer = new SkillEqualityComparer();
            int hash = 18;
            hash ^= obj.Id.GetHashCode();
            hash ^= obj.Name.GetHashCode();
            hash ^= obj.DisplayName.GetHashCode();

            foreach (var skill in obj.Skills)
            {
                hash ^= skillComparer.GetHashCode(skill);
            }

            return hash;
        }
    }
}