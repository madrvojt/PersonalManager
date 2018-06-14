#  Personal manager workshop (Part 4)

### 1. Add Nuget Sqlite-Net

https://github.com/praeclarum/sqlite-net

Its nessesary add this to main and platform project


### 2. Prepare Entity (Folder Entity)

``` csharp
public class TaskItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Message { get; set; }

    }
```

### 3. Create Database Helper 

Add DatabaseLoader class


``` csharp
public static class DatabaseLoader
    {

        public static SQLiteConnection Connection;


        static DatabaseLoader()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath
            (Environment.SpecialFolder.MyDocuments), "MyData.db");
            Connection = new SQLiteConnection(databasePath);
            Connection.CreateTable<TaskItem>();
        }
    }
```

### 4. Save items to database

Add Save items to AddTaskPage


``` csharp
 var connection = DatabaseLoader.Connection;
 var s = connection.Insert(new TaskItem()
    {
        Message = EntryTask.Text
    });
```

### 5. Load items to database

Add this to TasksPage


``` csharp
 protected override void OnAppearing()
        {
            base.OnAppearing();
            var connection = DatabaseLoader.Connection;
            var items = connection.Table<TaskItem>().ToList().Select(s => 
            s.Message).ToList();
            TasksListView.ItemsSource = items;
        }
```