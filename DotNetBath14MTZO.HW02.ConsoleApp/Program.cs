using DotNetBath14MTZO.HW02.ConsoleApp.Dapperexamples;
using DotNetBath14MTZO.HW02.ConsoleApp.DotNetExamples;
using DotNetBath14MTZO.HW02.ConsoleApp.EfCoreExamples;

DotNetExample dotNetExample = new DotNetExample();
//dotNetExample.Read();
//dotNetExample.Edit("F6C147D4-99F2-44E2-8094-57CBFC409C89");
//dotNetExample.Create("Blog Tilte 9","Blog Author 9","Blog Content 9");
//dotNetExample.Update("16B27C82-040D-4DFB-A4D4-29D96588520F", "Title", "Author", "Content");
//dotNetExample.Delete("16B27C82-040D-4DFB-A4D4-29D96588520F");

//Dapper

DapperExample dapper = new DapperExample();
//dapper.Read();
//dapper.Edit("D42789B4-29CA-4B21-A0D5-6B77822C4108");
//dapper.Create("Title 10","Author 10","Content 10");
//dapper.Update("9874F4B0-8725-4288-B6C8-B1CCA5DC21C7","Blog Title 10","Blog Author 10","Blog Content 10");
//dapper.Delete("409443A0-54E1-487C-9EE8-D47EEC674542");

//Ef Core
EfCoreExample efCoreExample = new EfCoreExample();
//efCoreExample.Read();
//efCoreExample.Edit("");
//efCoreExample.Edit("D42789B4-29CA-4B21-A0D5-6B77822C4108");
//efCoreExample.Create("Blog Title", "Blog Author", "Blog Context");
//efCoreExample.Update("6b5a4e78-5675-4d99-9de4-c4a13291c0df", "Blog Title 12", "Blog Author 12", "Blog Content 12");
efCoreExample.Delete("c5e8b9a3-65e7-4df1-8780-27444685048c");

Console.WriteLine();
