CREATE TABLE Сотрудники
(
Никнейм NVARCHAR (50) NOT NULL PRIMARY KEY,
ФИО NVARCHAR (50) NOT NULL,
Роль NVARCHAR (15) NOT NULL,
Пароль NVARCHAR (MAX) NOT NULL,
)

ALTER TABLE [Сотрудники] 
ADD CONSTRAINT A1
CHECK ((Роль = N'Администратор' OR Роль = N'Модератор'))