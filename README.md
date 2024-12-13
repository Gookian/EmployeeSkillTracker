

# EmployeeSkillsTracker

EmployeeSkillTracker — это backend часть одностраничного приложения, предназначенного для управления и отслеживания навыков сотрудников в компании. Приложение позволяет менеджерам и руководителям видеть актуальные данные о компетенциях своей команды, включая уровень владения различными навыками.

## Содержание

- [О проекте](#О-проекте)
- [Технологии](#Технологии)
- [Установка](#Установка)

## Технологии

Список технологий и инструментов, использованных в проекте:

- Язык программирования: `C#`.
- Фреймворк: `ASP.NET Core`.
- База данных: `PostgreSQL`.
- Другие инструменты и библиотеки: `EntityFrameworkCore`, `Swashbuckle.AspNetCore` `Serilog` `Docker`, `Docker-compose`, `NUnit`, `Moq`.

## Запуск проекта docker-compose

1. Скопировать репозиторий:
   ```bash
   git clone https://github.com/Gookian/EmployeeSkillTracker.git
   ```
2. Нужно создать сеть для Docker:
   ```bash
   docker network create employee_skill_tracker_network
   ```
3. Перейти в репозиторию ./EmployeeSkilsTracker и выполнить команду
   ```bash
   docker-compose up --build
   ```

## Сборка проекта EmployeeService

1. Скопировать репозиторий:
   ```bash
   git clone https://github.com/Gookian/EmployeeSkillTracker.git
   ```
2. Открыть проект в Visual Studio 2022;
3. Изменить строку подключения к базе данных на свою:
   ```json
    "ConnectionStrings": {
   	"DefaultConnection": "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=employee_skills"
    }
   ```
4. Собрать и запустить проект EmployeeService.
