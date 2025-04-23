# AutoApp Инструкция. Как запустить проект и БД

1.	MS Visual Studio. Скачать по ссылке (версия Community): https://visualstudio.microsoft.com/ru/
2.	Установить, следуя шагам установщика, ОБЯЗАТЕЛЬНО выбрать в рабочих нагрузках «Разработка классических приложений .NET» и установить
3.	БД. Скачать СУБД MSSQL по ссылке: https://www.microsoft.com/ru-RU/download/details.aspx?id=101064
4.	Установить, следуя шагам установщика (MS SQL Server и MS Management Studio)
5.	При подключении к БД будет выведено имя вашего сервера, скопируйте его
 ![image](https://github.com/user-attachments/assets/270fa80c-65d0-4781-a144-9c7ac06a1c61)
6.	В каталоге проекта лежит файл «script.sql» - это и есть скрипт бд, перетащите файл в MSSQL и нажмите кнопку «Выполнить» 
 ![image](https://github.com/user-attachments/assets/7707441e-c5e3-4eef-a316-9360c6f70eb2)
7.	Откройте папку src, далее папку проекта и дважды кликните по файлу с расширением .sln
8.	Справа, в обозревателе решений открыть файл App.config
   ![image](https://github.com/user-attachments/assets/ab12c3de-47bc-4f68-bf7d-e8fcfa8d2c21)
9.	В данной строке заменить data source=LAPTOP-6DVCDANM;на data source=ВАШЕ НАЗВАНИЕ СЕРВЕРА MSSQL;
    ![image](https://github.com/user-attachments/assets/eb19df77-d360-4690-a76c-0b5e0651df1c)
10.	Нажать на кнопку «Пуск»
    ![image](https://github.com/user-attachments/assets/012fff06-de25-41dc-8438-0fad2762468a)

## Данные для входа
Личный кабинет менеджера:
manager1
manager1

Личный кабинет клиента:
client1
client1
