using EmployeeService.Models;

/// <summary>
/// Интерфейс для работы с репозиторием сотрудников.
/// </summary>
namespace EmployeeService.Repositories
{
    public interface IPersonRepository
    {
        /// <summary>
        /// Получает список всех сотрудников из базы данных с учетом их скилов.
        /// </summary>
        /// <returns>Список всех сотрудников <see cref="System.Collections.Generic.IEnumerable{Person}" />.</returns>
        Task<IEnumerable<Person>> GetAllAsync();

        /// <summary>
        /// Находит сотрудника по его идентификатору <see cref="System.Int64" /> <paramref name="id" /> в базе данных.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Сотрудника <see cref="Person" /> с заданным идентификатором или <c>null</c>, если сотрудник не найден.</returns>
        Task<Person?> GetByIdAsync(long id);

        /// <summary>
        /// Добавляет нового сотрудника <paramref name="person" /> в базу данных.
        /// </summary>
        /// <param name="person">Объект сотрудника для добавления.</param>
        /// <returns>Никакого значения не возвращает.</returns>
        Task AddAsync(Person person);

        /// <summary>
        /// Обновляет данные существующего сотрудника <paramref name="person" />.
        /// </summary>
        /// <param name="person">Обновлённые данные сотрудника.</param>
        /// <returns>Никакого значения не возвращает. Если сотрудник с заданным идентификатором не найден, выбрасывает исключение.</returns>
        /// <exception cref="Exception" />
        Task UpdateAsync(Person person);

        /// <summary>
        /// Удаляет сотрудника по его идентификатору <see cref="System.Int64" /> <paramref name="id" />.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника для удаления.</param>
        /// <returns>Никакого значения не возвращает. Если сотрудник с заданным идентификатором не найден, выбрасывает исключение.</returns>
        /// <exception cref="Exception" />
        Task DeleteAsync(long id);
    }
}