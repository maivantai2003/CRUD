using OTLINQ;

List<Student> students = new List<Student>() { new Student()
{
    Id=1,Name="Nguyễn Văn A",ClassId=1
},new Student()
{
    Id=2,Name="Nguyễn Văn B",ClassId=2
},new Student()
{
    Id=3,Name="Nguyễn Văn c",ClassId=1
},new Student()
{
    Id=4,Name="Nguyễn Văn D",ClassId=2
},new Student()
{
    Id=5,Name="Nguyễn Văn E",ClassId=1
} };
List<Class> classes = new List<Class>() { new Class() { Id=1,Name="12C1"}, new Class() { Id = 2, Name = "12C2" } };
List<int> intList = new List<int> { 1, 2, 3, 4, 5,5,6,7,8,9, 6, 7, 8, 9, 10 };
List<int> dataSource1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
List<int> dataSource2 = new List<int>() { 1, };
//Method Syntax
var MS = dataSource1.Intersect(dataSource2).ToList();
//Query Syntax
var QS = (from num in dataSource1
          select num)
          .Except(dataSource2).ToList();
foreach (var item in QS)
{
    Console.Write(item + " ");
}
Console.ReadKey();