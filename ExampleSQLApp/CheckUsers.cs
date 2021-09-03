using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSQLApp
{
    class CheckUsers
    {
        
        ////подключили данные пользователя
        //String loginUser = loginField.Text;
        //String passUser = passField.Text;

        ////создали 3 объекта
        //DB db = new DB();

        //DataTable table = new DataTable();

        //MySqlDataAdapter adapter = new MySqlDataAdapter();

        ///*указали определенную команду, которая должна выполниться по отношению к базе данных
        //здесь же мы указали, к какой базе данных мы подключаемся*/
        //MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` =" +
        //    "@uL and `Password` = @uP", db.getConnection());

        ////вместо заглушек указали определенные переменные
        //command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
        //    command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

        //    //дальше выбрали нужную комманту - выполнили её
        //    adapter.SelectCommand = command;
            
        //    //все полученные данные поместили внутрь объекта table, которая является таблицей
        //    adapter.Fill(table); /* некая табличка, в которой мы можем посчитать количество 
        //    элементов. В которой мы можем обратиться уже к каждому отдельному элементу, 
        //    к каждой записи и тд.*/

        //    /*проверили, сколько у нас есть рядов(записей), если у нас есть хоть несколько рядов, то
        //    мы знаем, что пользователь авторизован. Иначе - нет.*/
        //    if (table.Rows.Count > 0)
        //    {
        //        MessageBox.Show("Used is authorized");
        //    }
        //    else
        //    {
        //        MessageBox.Show("User is not authorized");
        //    }
    }
}
