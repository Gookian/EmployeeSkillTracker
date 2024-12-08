using EmployeeService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    public interface IPersonController
    {
        /// <summary>
        /// Отдает список всех сотрудников с их скилами.
        /// </summary>
        /// <returns>Список всех сотрудников <see cref="IEnumerable{Person}" /> или ошибка с кодом 500 при исключении.</returns>
        public ActionResult<IEnumerable<Person>> GetAllPersons();

        /// <summary>
        /// Отдает сотрудника по его идентификатору <paramref name="id" /> (идентификатору) <see cref="System.Int64" />.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>
        /// <para>Статус успешного обновления <see cref="StatusCodeResult.StatusCode" /> = 200</para>
        /// <para>Статус когда сотрудник не найден <see cref="StatusCodeResult.StatusCode" /> = 404</para>
        /// <para>Статус при некорректном запросе <see cref="StatusCodeResult.StatusCode" /> = 400</para>
        /// <para>Статус при возникновении сбоя <see cref="StatusCodeResult.StatusCode" /> = 500</para>
        /// </returns>
        public ActionResult<Person> GetPersonById(long id);

        /// <summary>
        /// Создаёт нового сотрудника на основе <see cref="Person" />.
        /// </summary>
        /// <param name="person">Объект сотрудника для добавления.</param>
        /// <returns>
        /// <para>Статус успешного добавления сотрудника <see cref="StatusCodeResult.StatusCode" /> = 200</para>
        /// <para>Статус при некорректном запросе <see cref="StatusCodeResult.StatusCode" /> = 400</para>
        /// <para>Статус при возникновении сбоя <see cref="StatusCodeResult.StatusCode" /> = 500</para>
        /// </returns>
        public ActionResult<Person> CreatePerson([FromBody] Person person);

        /// <summary>
        /// Обновляет данные сотрудника по его <paramref name="id" /> (идентификатору) <see cref="System.Int64" /> с учетом данных <see cref="Person" />.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника для обновления.</param>
        /// <param name="person">Обновлённые данные сотрудника.</param>
        /// <returns>
        /// <para>Статус успешного обновления <see cref="StatusCodeResult.StatusCode" /> = 200</para>
        /// <para>Статус когда сотрудник не найден <see cref="StatusCodeResult.StatusCode" /> = 404</para>
        /// <para>Статус при некорректном запросе <see cref="StatusCodeResult.StatusCode" /> = 400</para>
        /// <para>Статус при возникновении сбоя <see cref="StatusCodeResult.StatusCode" /> = 500</para>
        /// </returns>
        public IActionResult UpdatePerson(long id, [FromBody] Person person);

        /// <summary>
        /// Удаляет сотрудника по его идентификатору <paramref name="id" /> (идентификатору) <see cref="System.Int64" />.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника для удаления.</param>
        /// <returns>
        /// <para>Статус успешного удаления <see cref="StatusCodeResult.StatusCode" /> = 200</para>
        /// <para>Статус когда сотрудник не найден <see cref="StatusCodeResult.StatusCode" /> = 404</para>
        /// <para>Статус при некорректном запросе <see cref="StatusCodeResult.StatusCode" /> = 400</para>
        /// <para>Статус при возникновении сбоя <see cref="StatusCodeResult.StatusCode" /> = 500</para>
        /// </returns>
        public IActionResult DeletePerson(long id);
    }
}